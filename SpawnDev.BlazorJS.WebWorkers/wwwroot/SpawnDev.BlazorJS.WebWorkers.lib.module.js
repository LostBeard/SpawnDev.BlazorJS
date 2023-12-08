//'use strict';

//function checkIfGlobalThis(it) {
//    // Math is known to exist as a global in every environment.
//    return it && it.Math === Math && it;
//}

//// currently SpawnDev.BlazorJS.WebWorkers does not need javascript code to be loaded by Blazor
//// probably removing this file soon if not needed

//export function beforeStart(options, extensions) {
//    console.log("webworkers beforeStart");
//}

//export function afterStarted(blazor) {
//    console.log("webworkers afterStarted");
//    if (typeof JSInterop._afterWebWorkersStarted === 'function') {
//        let callback = JSInterop._afterWebWorkersStarted;
//        delete JSInterop._afterStarted;
//        callback();
//    }
//}
