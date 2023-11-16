'use strict';

// Todd Tanner
// 2022 - 2023
// SpawnDev.BlazorJS.WebWorkers
// _content/SpawnDev.BlazorJS.WebWorkers/spawndev.blazorjs.webworkers.js
// this script loads a fake window and document environment
// to enable loading the Blazor WASM app in a DedicatedWorkerGlobalScope, a SharedWorkerGlobalScope or a ServiceWorkerGlobalScope

var checkIfGlobalThis = function (it) {
    return it && it.Math == Math && it;
};

// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/globalThis
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

var disableHotReload = true;
var verboseWebWorkers = location.search.indexOf('verbose=true') > -1;

var consoleLog = function () {
    if (!verboseWebWorkers) return;
    console.log(...arguments);
};

consoleLog('spawndev.blazorjs.webworkers: started');
consoleLog('location.href', location.href);

// in some contexts, event handlers need to be added immediately and cannot wait for Blazor WASM's async startup
// for example:
// in a shared worker, the onconnect event handler needs to be set immediately to catch all invocations of the event
// at this time, I ma not sure about fetch on service worker contexts. some debug code is being left until known.
if (globalThisTypeName == 'SharedWorkerGlobalScope') {
    // important for SharedWorker
    // catch any incoming connetions that happen while .Net is loading
    let _missedConnections = [];
    globalThisObj.takeOverOnConnectEvent = function (newConnectFunction) {
        var tmp = _missedConnections;
        _missedConnections = [];
        globalThisObj.onconnect = newConnectFunction;
        return tmp;
    }
    globalThisObj.onconnect = function (e) {
        _missedConnections.push(e.ports[0]);
    };
} else if (globalThisTypeName == 'ServiceWorkerGlobalScope') {
    let holdEvents = true;
    let missedServiceWorkerEventts = [];
    function handleMissedEvent(e) {
        if (!holdEvents) return;
        consoleLog('ServiceWorker missed event:', e.type, e);
        if (e.waitUntil && e.type != 'fetch') {
            var waitUntilPromise = new Promise(function (resolve, reject) {
                e.waitResolve = resolve;
                e.waitReject = reject;
            });
            e.waitUntil(waitUntilPromise);
        }
        if (e.respondWith && e.type == 'fetch') {
            var responsePromise = new Promise(function (resolve, reject) {
                e.responseResolve = resolve;
                e.responseReject = reject;
            });
            e.respondWith(responsePromise);
        }
        missedServiceWorkerEventts.push(e);
    }
    self.addEventListener('install', handleMissedEvent);
    self.addEventListener('activate', handleMissedEvent);
    self.addEventListener('fetch', handleMissedEvent);
    self.addEventListener('message', handleMissedEvent);
    self.addEventListener('notificationclick', handleMissedEvent);
    self.addEventListener('notificationclose', handleMissedEvent);
    self.addEventListener('push', handleMissedEvent);
    self.addEventListener('pushsubscriptionchange', handleMissedEvent);
    self.addEventListener('sync', handleMissedEvent);
    globalThisObj.GetMissedServiceWorkerEvents = function () {
        holdEvents = false;
        var ret = missedServiceWorkerEventts;
        missedServiceWorkerEventts = [];
        return ret;
    };
}

// location.href is this script
// - location.href == 'https://localhost:7191/_content/SpawnDev.BlazorJS.WebWorkers/spawndev.blazorjs.webworkers.js?verbose=false'
// or a service worker script
// - location.href == 'https://localhost:7191/service-worker.js'
// if documentBaseURIIsModified == true, 
// - fetch will be replaced with one that uses the modified documentBaseURI as its base path for relative path fetches as is expected in Blazor WASM apps
var documentBaseURIIsModified = false;
var documentBaseURI = (function () {
    var uri = new URL(`./`, location.href);
    if (uri.pathname.includes('_content/')) {
        documentBaseURIIsModified = true;
        var subpath = uri.pathname.substring(0, uri.pathname.indexOf('_content/'));
        return new URL(subpath, location.href).toString();
    }
    return uri.toString();
})();
consoleLog('documentBaseURI', documentBaseURI);
const webWorkersContent = new URL(`_content/SpawnDev.BlazorJS.WebWorkers/`, documentBaseURI).toString();
consoleLog('spawndev.blazorjs.webworkers: loading fake window environment');
// faux DOM and document environment
//importScripts('spawndev.blazorjs.webworkers.faux-env.js');
importScripts(new URL('spawndev.blazorjs.webworkers.faux-env.js', webWorkersContent).toString());
// faux dom and window environment has been created (currently empty)
// set document.baseURI to the apps basePath (which is relative to this scripts path)
document.baseURI = documentBaseURI;
if (disableHotReload) {
    consoleLog('disabling hot reload on this thread');
    const scriptInjectedSentinel = '_dotnet_watch_ws_injected'
    globalThisObj[scriptInjectedSentinel] = true
}

async function hasDynamicImport() {
    // ServiceWorkers have issues with dynamic imports even if detection says it is supported 
    if (globalThisTypeName == 'ServiceWorkerGlobalScope') {
        return false;
    }
    try {
        await import('data:text/javascript;base64,Cg==');
        return true;
    } catch (e) {
        return false;
    }
}

var initWebWorkerBlazor = async function () {
    var WebWorkerEnabledAttributeName = 'webworker-enabled';
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
    if (documentBaseURIIsModified) {
        let fetchOrig = globalThisObj.fetch;
        globalThisObj.fetch = function (resource, options) {
            consoleLog("webWorkersFetch", typeof resource, resource);
            if (typeof resource === 'string') {
                // resource is a string
                let newUrl = new URL(resource, document.baseURI);
                return fetchOrig(newUrl, options);
            } else {
                // resource is a Request object
                // currently not modified. could cause issues if a relative path was used to create the Request object.
                return fetchOrig(resource, options);
            }
        };
    }
    // fetch getText method
    async function getText(href) {
        var response = await fetch(new URL(href, document.baseURI));
        return await response.text();
    }
    // Get index.html and parse it for scripts
    function getScriptNodes(indexHtmlSrc) {
        var scriptNodes = [];
        var scriptPatt = /<script\s*(.*?)(?:\s*\/>|\s*>(.*?)<\/script>)/gms;
        var attributesPatt = /([^\s=]+)(?:=(?:"([^"]*)"|'([^"]*)'|([^\s=]+)))?/gm;
        var m = scriptPatt.exec(indexHtmlSrc);
        while(m) {
            let scriptNode = {
                attributes: {},
                text: m[2],
            }
            let scriptTagAttributes = m[1];
            let attrMatch = attributesPatt.exec(scriptTagAttributes);
            while (attrMatch) {
                let attrName = attrMatch[1];
                let attrValue = '';
                if (attrMatch[2]) attrValue = attrMatch[2];
                else if (attrMatch[3]) attrValue = attrMatch[3];
                else if (attrMatch[4]) attrValue = attrMatch[4];
                scriptNode.attributes[attrName] = attrValue;
                attrMatch = attributesPatt.exec(scriptTagAttributes);
            }
            scriptNodes.push(scriptNode);
            m = scriptPatt.exec(indexHtmlSrc);
        }
        return scriptNodes;
    }
    // detect the Blazor runtime type
    // can be:
    // '' - none or unknown
    // 'wasm' - Using Blazor WebAssembly standalone runtime
    // 'hybrid' - Using Blazor Hybrid runtime
    // do on the fly worker compatiblility patching if needed 
    // add webworker-enabled attribute to the runtime if it is not already there
    async function detectBlazorRuntime(scriptNodes) {
        for (var scriptNode of scriptNodes) {
            let src = scriptNode.attributes.src;
            if (!src) continue;
            if (src.includes('_framework/blazor.webassembly.js')) {
                if (typeof scriptNode.attributes[WebWorkerEnabledAttributeName] === 'undefined') {
                    scriptNode.attributes[WebWorkerEnabledAttributeName] = '';
                }
                if (!dynamicImportSupported) {
                    // load script text so we can do some on-the-fly patching to fix compatibility with WebWorkers
                    let jsStr = await getText(src);
                    // fix dynamic imports
                    scriptNode.text = fixModuleScript(jsStr, src);
                }
                return 'wasm';
            }
            if (src.includes('_framework/blazor.web.js')) {
                if (typeof scriptNode.attributes[WebWorkerEnabledAttributeName] === 'undefined') {
                    scriptNode.attributes[WebWorkerEnabledAttributeName] = '';
                }
                // load script text so we can do some on-the-fly patching to fix compatibility with WebWorkers
                let jsStr = await getText(src);
                // hybrid runtime doesn't start web assembly when it laods by default
                // it waits until a webassembly rendered component is loaded but that won't happen so we patch
                // the runtime to allow access to the method that actually starts webassembly directly
                // self.__blazorInternal.startLoadingWebAssemblyIfNotStarted()
                jsStr = jsStr.replace(/(this\.initialComponents=\[\],)/, '$1self.__blazorInternal=this,');
                if (!dynamicImportSupported) {
                    // fix dynamic imports
                    jsStr = fixModuleScript(jsStr, src);
                }
                scriptNode.text = jsStr;
                return 'hybrid';
            }
        }
        return '';
    }
    //
    globalThisObj.importOverride = async function (src) {
        consoleLog('importOverride', src);
        var jsStr = await getText(src);
        jsStr = fixModuleScript(jsStr, src);
        let fn = new Function(jsStr);
        var ret = fn.apply(createProxiedObject(globalThisObj), []);
        if (!ret) ret = createProxiedObject({});
        return ret;
    }
    // this method fixes 'dynamic import scripts' to work in an environment that does not support 'dynamic import scripts'
    // it is designed for and tested agaisnt the Blazor WASM runtime.
    // it may not work on other modules
    function fixModuleScript(jsStr, src) {
        // handle things that are automatically handled by import
        src = new URL(src, document.baseURI).toString();
        var scriptUrl = JSON.stringify(src);
        consoleLog('fixModuleScript.scriptUrl', src, scriptUrl);
        // fix import.meta.url - The full URL to the module
        jsStr = jsStr.replace(/\bimport\.meta\.url\b/g, scriptUrl);
        // import.meta
        jsStr = jsStr.replace(/\bimport\.meta\b/g, `{ url: ${scriptUrl} }`);
        // import
        jsStr = jsStr.replace(/\bimport\(/g, 'importOverride(');
        // export
        // https://www.geeksforgeeks.org/what-is-export-default-in-javascript/
        // handle exports from
        // lib modules
        // Ex(_content/SpawnDev.BlazorJS/SpawnDev.BlazorJS.lib.module.js)
        // export function beforeStart(options, extensions) {
        // export function afterStarted(options, extensions) {
        var exportPatt = /\bexport[ \t]+function[ \t]+([^ \t(]+)/g;
        jsStr = jsStr.replace(exportPatt, '_exportsOverride.$1 = function $1');
        // To match: _framework/blazor-hotreload.
        // export async function receiveHotReloadAsync() {
        exportPatt = /\bexport[ \t]+async[ \t]+function[ \t]+([^ \t(]+)/g;
        jsStr = jsStr.replace(exportPatt, '_exportsOverride.$1 = async function $1');
        // handle exports from
        // dotnet.7.0.0.amub20uvka.js
        // export default createDotnetRuntime
        exportPatt = /\bexport[ \t]+default[ \t]+([^ \t;]+)/g;
        jsStr = jsStr.replace(exportPatt, '_exportsOverride.default = $1');
        // export{Be as default,Fe as dotnet,We as exit};
        // below changes the above line to the below line changing the 'VAR as KEY' to 'KEY:VAR'
        // export{default:Be,dotnet:Fe,exit:We};
        exportPatt = /([a-zA-Z0-9]+)\s+as\s+([a-zA-Z0-9]+)/g;
        jsStr = jsStr.replace(exportPatt, '$2:$1');
        // export { dotnet, exit, INTERNAL };
        exportPatt = /\bexport\b[ \t]*(\{[^}]+\})/g;
        jsStr = jsStr.replace(exportPatt, '_exportsOverride = Object.assign(_exportsOverride, $1)');
        var modulize = `let _exportsOverride = {}; ${jsStr}; return _exportsOverride;`;
        return modulize;
    }
    async function initializeBlazor() {
        // get index.html text for parsing
        var indexHtmlSrc = await getText('./');
        var scriptNodes = getScriptNodes(indexHtmlSrc);
        // detect runtime type and do runtime patching if needed
        var blazorRuntimeType = await detectBlazorRuntime(scriptNodes);
        consoleLog(`BlazorRuntimeType: '${blazorRuntimeType}'`);
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
        // load webworker-enabled scripts in order found in the root html file
        for (var scriptNode of scriptNodes) {
            let webWorkerEnabledValue = scriptNode.attributes[WebWorkerEnabledAttributeName];
            let isWebWorkerEnabled = typeof webWorkerEnabledValue !== 'undefined' && webWorkerEnabledValue !== 'false';
            if (!isWebWorkerEnabled) continue;
            let scriptEl = document.createElement('script');
            if (scriptNode.parentNode && scriptNode.parentNode.tagName.toLowerCase() === 'head') {
                headEl.appendChild(scriptEl);
            } else {
                bodyEl.appendChild(scriptEl);
            }
            for (var attr in scriptNode.attributes) {
                let attrValue = scriptNode.attributes[attr];
                scriptEl.setAttribute(attr, attrValue);
            }
            if (scriptNode.text) scriptEl.text = scriptNode.text;
        }
        // init document
        document.initDocument();
        // If using the Blazor Hybrid runtime we have to start the webassembly runtime manually (requires previous patching of the runtime done above)
        if (blazorRuntimeType === 'hybrid') {
            consoleLog('Starting Blazor Hybrids webassembly runtime');
            self.__blazorInternal.startWebAssemblyIfNotStarted();
        }
    }
    await initializeBlazor();
};
initWebWorkerBlazor();
