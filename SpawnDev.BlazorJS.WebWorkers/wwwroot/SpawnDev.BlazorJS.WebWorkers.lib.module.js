// https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/?view=aspnetcore-7.0#inject-a-script-after-blazor-starts

// currently SpawnDev.BlazorJS.WebWorkers does not need javascript code to be loaded by Blazor
// probably removing this file soon if not needed

export function beforeStart(options, extensions) {
    //console.log("webworkers beforeStart");
}

export function afterStarted(blazor) {
    //console.log("webworkers afterStarted");
}
