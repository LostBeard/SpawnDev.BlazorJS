'use strict';

// Todd Tanner
// 2022
// SpawnDev.BlazorJS.WebWorkers

var checkIfGlobalThis = function (it) {
    return it && it.Math == Math && it;
};

// https://github.com/zloirock/core-js/issues/86#issuecomment-115759028
const globalThisObj =
    // eslint-disable-next-line es/no-global-this -- safe
    checkIfGlobalThis(typeof globalThis == 'object' && globalThis) ||
    checkIfGlobalThis(typeof window == 'object' && window) ||
    // eslint-disable-next-line no-restricted-globals -- safe
    checkIfGlobalThis(typeof self == 'object' && self) ||
    checkIfGlobalThis(typeof global == 'object' && global) ||
    // eslint-disable-next-line no-new-func -- fallback
    (function () { return this; })() || Function('return this')();

const globalThisTypeName = globalThisObj.constructor.name;

var dynamicImportSupported = true;
// this detection is a bit of a hack but dynamic import support testing is hit or miss also
// TODO - test on firefix mobile/mac/linux
if (navigator.userAgent && navigator.userAgent.indexOf('Firefox') > -1) {
    dynamicImportSupported = false;
    console.log('WARNING: Firefox may not support dynamic import in workers. WebWorkers may not work.');
}

// catch any incoming connetions that happen while .Net is loading
var _missedConnections = [];
function takeOverOnConnectEvent(newConnectFunction) {
    var tmp = _missedConnections;
    _missedConnections = [];
    globalThisObj.onconnect = newConnectFunction;
    return tmp;
}
if (globalThisTypeName == 'SharedWorkerGlobalScope') {
    globalThisObj.onconnect = function (e) {
        _missedConnections.push(e.ports[0]);
    };
}

var disableHotReload = true;
var verboseWebWorkers = location.search.indexOf('verbose=true') > -1;
// at the moment verbose must be false because an unknown issue is causing Blazor to fail without any errors if it is enabled
var consoleLog = function () {
    if (!verboseWebWorkers) return;
    console.log(...arguments);
};

// _content/SpawnDev.BlazorJS.WebWorkers/spawndev.blazorjs.webworkers.js
consoleLog('spawndev.blazorjs.webworkers: started');
consoleLog('location.href', location.href);
var _frameworkPath = '';
if (location.href.indexOf('_content/SpawnDev.BlazorJS.WebWorkers') > 0) {
    _frameworkPath = new URL(`../../_framework/`, location.href).toString();
} else {
    _frameworkPath = new URL(`_framework/`, location.href).toString();
}
consoleLog('_frameworkPath', _frameworkPath);

consoleLog('spawndev.blazorjs.webworkers: loading fake window environment');
importScripts(_frameworkPath + '../_content/SpawnDev.BlazorJS.WebWorkers/spawndev.blazorjs.webworkers.faux-env.js');

var stallForDebuggerSeconds = 0;
if (stallForDebuggerSeconds) {
    console.log(`Waiting ${stallForDebuggerSeconds} seconds for debugging`);
    var e = new Date().getTime() + (seconds * 1000);
    while (new Date().getTime() <= e) { }
    console.log(`Resuming`);
}

if (disableHotReload) {
    consoleLog('disabling hot reload on this thread');
    const scriptInjectedSentinel = '_dotnet_watch_ws_injected'
    globalThisObj[scriptInjectedSentinel] = true
}

var initWebWorkerBlazor = async () => {
    async function initializeBlazor() {
        // the app base directory is 2 folders up
        if (document.baseURI.indexOf('_content/') > 0) {
            document.baseURI = new URL(document.baseURI + '../../').toString();
        }
        consoleLog('document.baseURI', document.baseURI);
        // setup standard document
        var htmlEl = document.appendChild(document.createElement('html'));
        var headEl = htmlEl.appendChild(document.createElement('head'));
        var bodyEl = htmlEl.appendChild(document.createElement('body'));
        // add blazor specific stuff
        // <div id="app">
        var appDiv = bodyEl.appendChild(document.createElement('div'));
        appDiv.setAttribute('id', 'app');
        // <div id="blazor-error-ui">
        var errorDiv = bodyEl.appendChild(document.createElement('div'));
        errorDiv.setAttribute('id', 'blazor-error-ui');
        // <script src="_framework/blazor.webassembly.js" autostart="false"></script>
        var blazorWASMScriptEl = bodyEl.appendChild(document.createElement('script'));
        blazorWASMScriptEl.setAttribute('autostart', "false");
        blazorWASMScriptEl.setAttribute('src', '_framework/blazor.webassembly.js');
        //blazorWASMScriptEl.setAttribute('src', '_content/SpawnDev.BlazorJS.WebWorkers/blazor.webassembly.pretty.js');
        // init document
        if (dynamicImportSupported) {
            document.initDocument();
        }
        else
        {
            consoleLog('Loading workaround to counter lack of dynamic import support in some browsers (Firefox, others?)');
            var integrity = '';
            //var blazorWasmJsUri = new URL('_content/SpawnDev.BlazorJS.WebWorkers/blazor.webassembly.pretty.js', document.baseURI);
            var blazorWasmJsUri = new URL('_framework/blazor.webassembly.js', document.baseURI);
            var response = await fetch(blazorWasmJsUri, {
                cache: 'no-cache',
                //integrity: integrity,
            });
            var jsStr = await response.text();
            function fixModuleScript(jsStr) {
                // handle things that are automatically handled by import
                // import.meta.url
                jsStr = jsStr.replace(new RegExp('\\bimport\\.meta\\.url\\b', 'g'), `document.baseURI`);
                // import.meta
                jsStr = jsStr.replace(new RegExp('\\bimport\\.meta\\b', 'g'), `{ url: location.href }`);
                // import
                jsStr = jsStr.replace(new RegExp('\\bimport\\(', 'g'), 'importOverride(');
                // export
                // https://www.geeksforgeeks.org/what-is-export-default-in-javascript/
                // handle exports from
                // lib modules
                // Ex(_content/SpawnDev.BlazorJS/SpawnDev.BlazorJS.lib.module.js)
                // export function beforeStart(options, extensions) {
                // export function afterStarted(options, extensions) {
                var exportPatt = /\bexport[ \t]+function[ \t]+([^ \t(]+)/g;
                jsStr = jsStr.replace(exportPatt, '_exportsOverride.$1 = function $1');
                // handle exports from
                // dotnet.7.0.0.amub20uvka.js
                // export default createDotnetRuntime
                exportPatt = /\bexport[ \t]+default[ \t]+([^ \t;]+)/g;
                jsStr = jsStr.replace(exportPatt, '_exportsOverride.default = $1');
                // export { dotnet, exit, INTERNAL };
                exportPatt = /\bexport[ \t]+(\{[^}]+\})/g;
                jsStr = jsStr.replace(exportPatt, '_exportsOverride = Object.assign(_exportsOverride, $1)');
                //var n = 0;
                //var m = null;
                //exportPatt = new RegExp('\\bexport\\b.*?(?:;|$)', 'gm');
                //do {
                //    m = exportPatt.exec(jsStr);
                //    if (m) {
                //        n++;
                //        console.log('export', n, m[0]);
                //    }
                //} while (m);
                var modulize = `let _exportsOverride = {}; ${jsStr}; return _exportsOverride;`;
                return modulize;
            }
            globalThisObj.importOverride = async function (src) {
                consoleLog('importOverride', src);
                var response = await fetch(src, {
                    cache: 'no-cache',
                    //integrity: integrity,
                });
                var jsStr = await response.text();
                jsStr = fixModuleScript(jsStr);
                let fn = new Function(jsStr);
                var ret = fn.apply(createProxiedObject(globalThisObj), []);
                if (!ret) ret = createProxiedObject({});
                return ret;
            }
            jsStr = fixModuleScript(jsStr);
            //console.log("jsStr", jsStr);
            blazorWASMScriptEl.text = jsStr;
            document.initDocument();
        }
    }
    await initializeBlazor();

    // Blazor startup configuration
    // https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/environments?view=aspnetcore-7.0
    Blazor.start({
        loadBootResource: function (type, name, defaultUri, integrity) {
            var newUri = `${_frameworkPath}${name}`;
            //console.log(`Loading: '${type}', '${name}', '${defaultUri}', '${integrity}', '${newUri}'`);
            if (name === 'blazor.boot.json') {
                return (async () => {
                    var response = await fetch(newUri, {
                        cache: 'no-cache',
                        integrity: integrity,
                    });
                    var responseClone = response.clone();
                    var json = await responseClone.json();
                    // this is where we can modify json.entryAssembly or other boot config settings
                    //consoleLog('blazor.boot.json', json);
                    //json.debugBuild = false;
                    //json.linkerEnabled = false;
                    consoleLog('blazor.boot.json::entryAssembly', json.entryAssembly);
                    var newRsponse = new Response(JSON.stringify(json), response);
                    return newRsponse;
                })();
            } else if (name === 'blazor.webassembly.js') {

            }
            return newUri;
        }
    });

};
initWebWorkerBlazor();