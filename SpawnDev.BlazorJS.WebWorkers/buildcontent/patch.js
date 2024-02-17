// Todd Tanner
// 2024
// this patch.js script is prepended to blazor.webassembly.js
// and all of the js files in _framework are modified to ...
// - use importShim instead of import
// - use exportShim instead of export
// this allows the Blazor _frameowrk scripts to load in browser scope (window, worker, shared worker, service worker)
// requires SpawnDev.BlazorJS.WebWorkers when running in non-window context to provide a faux document and window environment

// if loaded into browser extension content mode, document and history will be undefined, but their globalThis versions are set.
if (typeof document === 'undefined') document = globalThis.document;
if (typeof history === 'undefined') history = globalThis.history;
// create globalThis.blazorConfig if it does not exist
globalThis.blazorConfig = globalThis.blazorConfig ?? {};
// add defaults to globalThis.blazorConfig
globalThis.blazorConfig = Object.assign(
    {
        documentBaseURI: globalThis.document ? globalThis.document.baseURI : new URL('./', globalThis.location.href),
        blazorBaseURI: '',
        frameworkFolderName: '_framework',
        contentFolderName: '_content',
    },
    globalThis.blazorConfig
);
if (!globalThis.blazorConfig.blazorBaseURI) {
    globalThis.blazorConfig.blazorBaseURI = (function () {
        var uri = new URL(`./`, location.href);
        if (uri.pathname.includes(`${globalThis.blazorConfig.contentFolderName}/`)) {
            var subpath = uri.pathname.substring(0, uri.pathname.indexOf(`${globalThis.blazorConfig.contentFolderName}/`));
            return new URL(subpath, location.href).toString();
        } else if (uri.pathname.includes(`${globalThis.blazorConfig.frameworkFolderName}/`)) {
            var subpath = uri.pathname.substring(0, uri.pathname.indexOf(`${globalThis.blazorConfig.frameworkFolderName}/`));
            return new URL(subpath, location.href).toString();
        }
        return uri.toString();
    })();
}
if (typeof globalThis.constructor.name === 'undefined' && globalThis.window) {
    // Running in Firefox extension content mode
    globalThis.constructor.name = 'Window';
}
// sets the document.baseURI to Blazor app's base url
if (globalThis.constructor.name !== 'Window' && globalThis.document) {
    globalThis.document.baseURI = globalThis.blazorConfig.blazorBaseURI;
}
// patched _framework scripts will call exportShim with their filename and optionally their exports
// returns the script's exports object which may be modified to finish the export
globalThis.exportShimValues = {};
globalThis.exportShim = (filename, exports) => {
    if (exports) {
        globalThis.exportShimValues[filename] = exports;
    } else if (!globalThis.exportShimValues[filename]) {
        globalThis.exportShimValues[filename] = {};
    }
    return globalThis.exportShimValues[filename];
};
// dynamic import shim for patched _framework scripts
// uses dynamic import in Window scope
// uses importScripts in non-window scope (DedicatedWorker, SharedWorker, ServiceWorker)
globalThis.dynamicImportSupported = globalThis.constructor.name === 'Window';
globalThis.importShim = function(moduleName) {
    var filename = moduleName.split('?')[0].split('#')[0]
    filename = filename.indexOf('/') === -1 ? filename : filename.substring(filename.lastIndexOf('/') + 1);
    filename = filename.substring(0, filename.lastIndexOf('.js') + 3);
    return new Promise(async function(resolve, reject) {
        // _framework module scipts have been modified to call exportShim instead of using export { Var as ExportName, ... }, export default ..., etc.
        if (globalThis.dynamicImportSupported !== false) {
            try {
                var tmp = await import(moduleName);
                globalThis.dynamicImportSupported = true;
                var exports = globalThis.exportShimValues[filename] ?? {};
                globalThis.exportShimValues[filename] = Object.assign(exports, tmp);
                exports = globalThis.exportShimValues[filename];
                resolve(exports);
                return;
            } catch (ex) {
                // dynamic import not supported
                globalThis.dynamicImportSupported = false;
            }
        }
        if (typeof globalThis.importScripts !== 'undefined') {
            importScripts(moduleName);
            var exports = globalThis.exportShimValues[filename] ?? {};
            resolve(exports);
            return;
        }
        // unsupported environment
        reject();
    });
};
// import.meta has been patched in module scripts to call this method with their script name instead
// that way we can determine the correct meta.url property
globalThis.importShim.meta = function (filename) {
    var meta = {
        // only scripts
        url: new URL(`${globalThis.blazorConfig.frameworkFolderName}/${filename}`, globalThis.blazorConfig.blazorBaseURI).toString(),
    };
    return meta;
};
