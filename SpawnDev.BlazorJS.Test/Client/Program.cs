using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.Diagnostics;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Reflection;
using SpawnDev.BlazorJS.Test;
using SpawnDev.BlazorJS.Test.Services;
using SpawnDev.BlazorJS.Toolbox;
using SpawnDev.BlazorJS.WebWorkers;
using System.Text.Json;

#if DEBUG
JSObject.UndisposedHandleVerboseMode = false;
#endif

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// Modify JSRuntime.JsonSerializerOptions (WARNING: Modifying this can cause unexpected results. Test thoroughly.)
builder.Services.AddJSRuntimeJsonOptions(jsRuntimeJsonOptions =>
{
#if DEBUG && false
    Console.WriteLine($"JSRuntime JsonConverters count: {jsRuntimeJsonOptions.Converters.Count}");
#endif
});
// Add SpawnDev.BlazorJS.BlazorJSRuntime
builder.Services.AddBlazorJSRuntime();
// Add SpawnDev.BlazorJS.WebWorkers.WebWorkerService
builder.Services.AddWebWorkerService(webWorkerService =>
{
    // Optionally configure the WebWorkerService service before it is used
    // Default WebWorkerService.TaskPool settings: PoolSize = 0, MaxPoolSize = 1, AutoGrow = true
    // Below sets TaskPool max size to 2. By default the TaskPool size will grow as needed up to the max pool size.
    // Setting max pool size to -1 will set it to the value of navigator.hardwareConcurrency
    webWorkerService.TaskPool.MaxPoolSize = 2;
    // Below is telling the WebWorkerService TaskPool to set the initial size to 2 if running in a Window scope and 0 otherwise
    // This starts up 2 WebWorkers to handle TaskPool tasks as needed
    // Setting this to -1 will set the initial pool size to max pool size
#if DEBUG
    webWorkerService.TaskPool.PoolSize = 0;  // once web workers startup the VS debugger does not work properly
#else
    webWorkerService.TaskPool.PoolSize = 0; //webWorkerService.GlobalScope == GlobalScope.Window ? 2 : 0;
#endif
});

// Add services
builder.Services.AddScoped((sp) => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Test startup when KeyedServices are used (new in Blazor .Net 8)
// This is to test a bug in SpawnDev.BlazorJS (issue #24) that has been fixed as of 2.2.47
builder.Services.AddKeyedSingleton(typeof(string), "apples", (_, key) => DateTime.Now.ToString() + $" {key}");
builder.Services.AddKeyedSingleton(typeof(string), "grapes", (_, key) => DateTime.Now.ToString() + $" {key}");

// The below service is used to test CallDispatcher used with WebWorkers (Used in UnitTests)
builder.Services.AddSingleton<AsyncCallDispatcherTest>();
// More app specific services
builder.Services.AddSingleton(builder.Configuration); // used to demo appsettings reading in workers
builder.Services.AddSingleton<MediaDevices>();
builder.Services.AddSingleton<MediaDevicesService>();
// Add app services that will be called on the main thread and/or worker threads
builder.Services.AddSingleton<IFaceAPIService, FaceAPIService>();
builder.Services.AddSingleton<IMathsService, MathsService>();

// Radzen UI services
builder.Services.AddSingleton<DialogService>();
builder.Services.AddSingleton<NotificationService>();
builder.Services.AddSingleton<TooltipService>();
builder.Services.AddSingleton<ContextMenuService>();

// App service
builder.Services.AddSingleton<JSObjectAnalyzer>();

#if DEBUG
var host = builder.Build();
await host.StartBackgroundServices();
//
var JS = host.Services.GetRequiredService<BlazorJSRuntime>();
JS.Set("_testWindows", new AsyncFuncCallback<string>(async () =>
{
    var webWorkerService = host.Services.GetRequiredService<WebWorkerService>();
    var windowInstances = webWorkerService.Windows;
    var instanceId = JS.InstanceId;
    var tasks = new List<Task>();
    foreach (var windowInstance in windowInstances)
    {
        tasks.Add(Async.RunAsync(async () =>
        {
            var removeInstanceId = await windowInstance.Dispatcher!.Run(() => JS.InstanceId);
            await windowInstance.Dispatcher.Run(() => TestA.WriteLine("Hello " + removeInstanceId + " from " + instanceId));
        }));
    }
    try
    {
        await Task.WhenAll(tasks);
    }
    catch (Exception ex)
    {
        JS.Log($"WhenAll error:", ex.Message, ex.StackTrace);
    }
    return "ok";
}));
//var actt = new Action(() => {
//    var sharedArrayBuffer = new SharedArrayBuffer(1);
//    Int32Array array = new Int32Array(sharedArrayBuffer);
//    Span<int> nativeArray = array; // error  
//});

using var cancellationSource = new SharedCancellationTokenSource();
JS.Set("_cancellationSource", cancellationSource);
JS.Log("_cancellationSource", cancellationSource);
var copy = JS.Get<SharedCancellationTokenSource>("_cancellationSource");

JS.Set("_cancellationToken", cancellationSource.Token);
JS.Log("_cancellationToken", cancellationSource.Token);
var copyToken = JS.Get<SharedCancellationToken>("_cancellationToken");


//using var arrayBuffer = new ArrayBuffer(16);
//JS.Set("_arrayBuffer", arrayBuffer);
//JS.Log("_arrayBuffer", arrayBuffer);
//using var intArray = new Int32Array(arrayBuffer);
//JS.Set("_intArray", intArray);
//JS.Log("_intArray", intArray);

//try
//{
//    var g1 = JS.Get<int[]>("_arrayBuffer");
//    var gg = true;
//}
//catch
//{
//    var gg = true;
//}
//try
//{
//    var g2 = JS.Get<int[]>("intArray");
//    var gg = true;
//}
//catch
//{
//    var gg = true;
//}
// 
await host.BlazorJSRunAsync();
#else
// build and Init using BlazorJSRunAsync (instead of RunAsync)
await builder.Build().BlazorJSRunAsync();
#endif

static class TestA
{
    public static void WriteLine(string msg) => Console.WriteLine(msg);
}