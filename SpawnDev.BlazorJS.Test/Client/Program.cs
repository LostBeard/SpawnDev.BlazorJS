using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.Diagnostics;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Test;
using SpawnDev.BlazorJS.Test.Services;
using SpawnDev.BlazorJS.Toolbox;
using SpawnDev.BlazorJS.WebWorkers;

#if DEBUG
JSObject.UndisposedHandleVerboseMode = true;
#endif

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// Modify JSRuntime.JsonSerializerOptions (WARNING: Modifying this can cause unexpected results. Test thoroughly.)
builder.Services.AddJSRuntimeJsonOptions(jsRuntimeJsonOptions => {
#if DEBUG
    Console.WriteLine($"JSRuntime JsonConverters count: {jsRuntimeJsonOptions.Converters.Count}");
#endif
});
// Add services
builder.Services.AddScoped((sp) => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// Add SpawnDev.BlazorJS.BlazorJSRuntime
builder.Services.AddBlazorJSRuntime();
// Add SpawnDev.BlazorJS.WebWorkers.WebWorkerService
builder.Services.AddWebWorkerService();
// WebWorkerPool service (WIP. optional. Not required for WebWorkerService)
builder.Services.AddSingleton<WebWorkerPool>();
// More app specific services
builder.Services.AddSingleton(builder.Configuration); // used to demo appsettings reading in workers
builder.Services.AddSingleton<MediaDevices>();
builder.Services.AddSingleton<MediaDevicesService>();
// Add app services that will be called on the main thread and/or worker threads (Worker services must use interfaces)
builder.Services.AddSingleton<IFaceAPIService, FaceAPIService>();
builder.Services.AddSingleton<IMathsService, MathsService>();

// Radzen UI services
builder.Services.AddSingleton<DialogService>();
builder.Services.AddSingleton<NotificationService>();
builder.Services.AddSingleton<TooltipService>();
builder.Services.AddSingleton<ContextMenuService>();

//Console.WriteLine($"appsettings test in context {BlazorJSRuntime.JS.GlobalThisTypeName}: " + builder.Configuration["Message"]);

#if DEBUG || true
var host = builder.Build();

var JS = host.Services.GetRequiredService<BlazorJSRuntime>();

var jsobjectAnalyzer = new JSObjectAnalyzer(JS);
var window = JS.Get<Window>("window");
var windowInfo = jsobjectAnalyzer.Analyze(window);
JS.Log("_windowInfo", windowInfo);
JS.Set("_windowInfo", windowInfo);

var localStorage = JS.Get<Storage>("localStorage");
var localStorageInfo = jsobjectAnalyzer.Analyze(localStorage);

JS.Log("_localStorageInfo", localStorageInfo);
JS.Set("_localStorageInfo", localStorageInfo);

JS.Set("_testWorker", new ActionCallback<bool>(async (verbose) => { 
    var webWorkerService = host.Services.GetRequiredService<WebWorkerService>();    
    var worker = await webWorkerService.GetWebWorker(verbose);
    var math = worker.GetService<IMathsService>();
    var ret = await math.EstimatePI(100);
    Console.WriteLine(ret);
}));
JS.Set("_testWorkerAndDispose", new ActionCallback<bool>(async (verbose) => {
    var webWorkerService = host.Services.GetRequiredService<WebWorkerService>();
    using var worker = await webWorkerService.GetWebWorker(verbose);
    var math = worker.GetService<IMathsService>();
    var ret = await math.EstimatePI(100);
    Console.WriteLine(ret);
}));

await host.BlazorJSRunAsync();

#else

// build and Init using BlazorJSRunAsync (instead of RunAsync)
await builder.Build().BlazorJSRunAsync();

#endif
