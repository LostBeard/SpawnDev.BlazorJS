//var locationPathname = new URL(globalThis.location.href).pathname;
//var locationFilename = locationPathname.substring(locationPathname.lastIndexOf('/') + 1);
//if (locationFilename.indexOf('blazor.webassembly.js') !== -1) {
//    globalThis.blazorConfig.autoStart = true;
//}
if (globalThis.blazorConfig && globalThis.blazorConfig.autoStart) {
    if (globalThis.blazorConfig.webAssemblyConfig) {
        Blazor.start(globalThis.blazorConfig.webAssemblyConfig);
    } else {
        Blazor.start();
    }
}