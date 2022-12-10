'use strict';

// can be detected if self if needed
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

var consoleLog = function () {
    if (!verbose) return;
    console.log(...arguments);
};

const locationQueryParams = new Proxy(new URLSearchParams(location.search), {
    get: (searchParams, prop) => searchParams.get(prop),
});

var verbose = locationQueryParams.verbose === 'true';

console.log('locationQueryParams', locationQueryParams);

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
//
consoleLog('spawndev.blazorjs.webworkers: loading blazor.webassembly.js');
importScripts(_frameworkPath + 'blazor.webassembly.js');
//importScripts(_frameworkPath + '../_content/SpawnDev.BlazorJS.WebWorkers/blazor.webassembly.pretty.js');

// Blazor startup configuration
// https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/environments?view=aspnetcore-7.0
Blazor.start({
    loadBootResource: function (type, name, defaultUri, integrity) {
        var newUri = `${_frameworkPath}${name}`;
        //consoleLog(`Loading: '${type}', '${name}', '${defaultUri}', '${integrity}', '${newUri}'`);
        if (name === 'blazor.boot.json') {
            return (async () => {
                var response = await fetch(newUri, {
                    cache: 'no-cache',
                    integrity: integrity,
                    headers: { 'Custom-Header': 'Custom Value' }
                });
                var responseClone = response.clone();
                var json = await responseClone.json();
                // this is where we can modify json.entryAssembly or other boot config settings
                consoleLog('blazor.boot.json', json);
                consoleLog('entryAssembly', json.entryAssembly);
                var newRsponse = new Response(JSON.stringify(json), response);
                return newRsponse;
            })();
        }
        return newUri;
    }
});