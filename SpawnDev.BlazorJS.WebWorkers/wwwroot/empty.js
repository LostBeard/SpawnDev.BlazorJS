// to test dynamic import support this script will be loaded.
// it is intentionally empty.
// supports content-sceurity-policy that prohibits script-src from data: (previous test method)

// dynamic import support tested using the below method which tries to load this (mostly) empty script
//async function hasDynamicImport() {
//    try {
//        await import('empty.js');
//        return true;
//    } catch (e) {
//        return false;
//    }
//}

// previous test method that was not compatible with stricter CSPs
//async function hasDynamicImport() {
//    // ServiceWorkers have issues with dynamic imports even if detection says it is detected as supported; may jsut not have been loaded usign 'module' keyword
//    if (browserExtension) {
//        return true;
//    }
//    if (globalThisTypeName == 'ServiceWorkerGlobalScope') {
//        return false;
//    }
//    try {
//        await import('data:text/javascript;base64,Cg==');
//        return true;
//    } catch (e) {
//        return false;
//    }
//}
