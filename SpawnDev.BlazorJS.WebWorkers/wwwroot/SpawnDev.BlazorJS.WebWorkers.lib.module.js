//'use strict';

//function checkIfGlobalThis(it) {
//    // Math is known to exist as a global in every environment.
//    return it && it.Math === Math && it;
//}

//const globalObject =
//    // eslint-disable-next-line es/no-global-this -- safe
//    checkIfGlobalThis(typeof globalThis == 'object' && globalThis) ||
//    checkIfGlobalThis(typeof window == 'object' && window) ||
//    // eslint-disable-next-line no-restricted-globals -- safe
//    checkIfGlobalThis(typeof self == 'object' && self) ||
//    checkIfGlobalThis(typeof global == 'object' && global) ||
//    // eslint-disable-next-line no-new-func -- fallback
//    (function () { return this; })() || Function('return this')();
//// https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/?view=aspnetcore-7.0#inject-a-script-after-blazor-starts

//// currently SpawnDev.BlazorJS.WebWorkers does not need javascript code to be loaded by Blazor
//// probably removing this file soon if not needed

//export function beforeStart(options, extensions) {
//    console.log("webworkers beforeStart");
//}

//export function afterStarted(blazor) {
//    globalObject.__blazor = blazor;
//    console.log("webworkers afterStarted");
//}
