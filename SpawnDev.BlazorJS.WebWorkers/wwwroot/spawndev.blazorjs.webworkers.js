'use strict';

// Todd Tanner
// 2022 - 2023
// SpawnDev.BlazorJS.WebWorkers
// _content/SpawnDev.BlazorJS.WebWorkers/spawndev.blazorjs.webworkers.js
// this script loads a fake window and DOM environment 
// and makes the Blazor WASM work in a WebWorker scope

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

// important for SharedWorker
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
var consoleLog = function () {
    if (!verboseWebWorkers) return;
    console.log(...arguments);
};

consoleLog('spawndev.blazorjs.webworkers: started');
consoleLog('location.href', location.href);
// location.href is this script
// location.href == 'https://localhost:7191/_content/SpawnDev.BlazorJS.WebWorkers/spawndev.blazorjs.webworkers.js?verbose=false'

consoleLog('spawndev.blazorjs.webworkers: loading fake window environment');
importScripts('spawndev.blazorjs.webworkers.faux-env.js');
// faux dom and window environment has been created
// set document.baseURI to the apps basePath (which is relative to this scripts path)
document.baseURI = new URL(`../../`, location.href).toString();
consoleLog('document.baseURI', document.baseURI);

if (disableHotReload) {
    consoleLog('disabling hot reload on this thread');
    const scriptInjectedSentinel = '_dotnet_watch_ws_injected'
    globalThisObj[scriptInjectedSentinel] = true
}

async function hasDynamicImport() {
    try {
        await import('data:text/javascript;base64,Cg==');
        return true;
    } catch (e) {
        return false;
    }
}

var initWebWorkerBlazor = async function () {
    var dynamicImportSupported = await hasDynamicImport();
    // Firefox, and possibly some other browsers, do not support dynamic module import (import) in workers.
    // https://bugzilla.mozilla.org/show_bug.cgi?id=1540913
    // Some scripts will have to be patched on the fly if import is not supported.
    if (!dynamicImportSupported) {
        consoleLog("import is not supported. A workaround will be used.");
    } else {
        consoleLog('import is supported.');
    }
    // patch globalThisObj.fetch to use document.baseURI for the relative path base path
    let fetchOrig = globalThisObj.fetch;
    globalThisObj.fetch = function (resource, options) {
        consoleLog("webWorkersFetch", typeof resource, resource);
        if (typeof resource === 'string') {
            // resource is a string
            const newUrl = new URL(resource, document.baseURI);
            return fetchOrig(newUrl, options);
        } else {
            // resource is a Request object
            // currently not modified. could cause issues if a relative path was used to create the Request object.
            return fetchOrig(resource, options);
        }
    };
    // helper method
    async function getText(href) {
        var response = await fetch(new URL(href, document.baseURI), {
            cache: 'force-cache',
        });
        return await response.text();
    }
    // Get index.html
    var indexHtmlSrc = await getText('index.html');
    var indexHtmlScripts = [];
    var blazorWebAssemblyJSIndex = -1;
    function getIndexHtmlScripts() {
        var scriptPatt = /<script\s*(.*?)(?:\s*\/>|\s*>(.*?)<\/script>)/gms;
        var m;
        do {
            m = scriptPatt.exec(indexHtmlSrc);
            if (m) {
                let scriptTagAttributes = m[1];
                let scriptTagBody = m[2];
                let scriptSrcMatch = scriptTagAttributes && /src="(.+?)"/.exec(scriptTagAttributes);
                let webworkerEnabled = scriptTagAttributes && /\bwebworker-enabled\b/.exec(scriptTagAttributes);
                if (scriptSrcMatch) {
                    // remote script
                    let scriptSrc = scriptSrcMatch[1];
                    let isBlazorWebAssemblyJS = scriptSrc.includes('_framework/blazor.webassembly.js');
                    consoleLog('webworkerEnabled', webworkerEnabled, scriptSrc);
                    if (webworkerEnabled || isBlazorWebAssemblyJS) {
                        if (isBlazorWebAssemblyJS) {
                            blazorWebAssemblyJSIndex = indexHtmlScripts.length;
                        }
                        indexHtmlScripts.push({
                            src: scriptSrc
                        });
                    }
                } else if (scriptTagBody && webworkerEnabled) {
                    // inline script
                    indexHtmlScripts.push({
                        body: scriptTagBody
                    });
                }
            }
        } while (m);
        if (blazorWebAssemblyJSIndex == -1) {
            blazorWebAssemblyJSIndex = indexHtmlScripts.length;
            indexHtmlScripts.push({
                src: '_framework/blazor.webassembly.js'
            });
        }
    }
    getIndexHtmlScripts();
    globalThisObj.importOverride = async function (src) {
        consoleLog('importOverride', src);
        var jsStr = await getText(src);
        jsStr = fixModuleScript(jsStr);
        let fn = new Function(jsStr);
        var ret = fn.apply(createProxiedObject(globalThisObj), []);
        if (!ret) ret = createProxiedObject({});
        return ret;
    }
    // this method fixes 'dynamic import scripts' to work in an environment that does not support 'dynamic import scripts'
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
    async function initializeBlazor() {
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
        // <script src="_framework/blazor.webassembly.js"></script>
        // load webworker-enabled scripts in order found in index.html (and _framework/blazor.webassembly.js)
        for (var i = 0; i < indexHtmlScripts.length; i++) {
            let s = indexHtmlScripts[i];
            let scriptEl = bodyEl.appendChild(document.createElement('script'));
            if (s.src) scriptEl.setAttribute('src', s.src);
            if (s.body) scriptEl.text = s.body;
            if (i == blazorWebAssemblyJSIndex) {
                // load script text so we can do some on-the-fly patching to fix compatibility with WebWorkers
                let jsStr = await getText(s.src);
                // fix dynamic imports (if neeeded)
                if (!dynamicImportSupported) {
                    // convert dynamic imports in blazorWebAssembly and its imports
                    jsStr = fixModuleScript(jsStr);
                }
                scriptEl.text = jsStr;
            }
        }
        // init document
        document.initDocument();
    }
    await initializeBlazor();
};
initWebWorkerBlazor();
