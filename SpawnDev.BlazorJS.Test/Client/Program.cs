using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Test;
using SpawnDev.BlazorJS.Test.Services;
using SpawnDev.BlazorJS.WebWorkers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var globalThisType = JS.GetConstructorName("globalThis");
Console.WriteLine("Program.cs ctor " + builder.HostEnvironment.BaseAddress + $" GlobalThisType: {JS.GlobalThisTypeName} {globalThisType}");
if (JS.IsWindow)
{
    // we can skip adding dom objects (optional)
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");
}
// add services
builder.Services.AddSingleton((sp) => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// SpawnDev.BlazorJS.WebWorkers
builder.Services.AddSingleton<WebWorkerService>();
builder.Services.AddSingleton<MathsService>();
// build 
WebAssemblyHost host = builder.Build();
// init any services that need it (ideally services are initialized as needed on the pages that use them instead of here.)
var workerService = host.Services.GetRequiredService<WebWorkerService>();
await workerService.InitAsync();
// scope specific code
if (JS.IsWindow)
{
   // WebWorker? _webWorker = null;
    //SharedWebWorker? _sharedWebWorker = null;
    // optionally start spinning up a worker now
    //var _worker = await workerService.CreateWorker(false, false);
    // optionally start spinning up a shared worker now
    // shared workers are named. ask for a worker by name in any thread
    // the nice thing about shared workers is that they only need to spin up once no matter how many tabs are loaded
    //_ = workerService.CreateSharedWorker("test");
    // main thread
    // these examples call into the WebWorkerService, but any registered service can be called
    //JS.Set("_newWorker", Callback.Create(new Action<bool>(async (verbose) =>
    //{
    //    using var webWorker = await workerService.CreateWorker(verbose);
    //    var ret = await webWorker.InvokeAsync<WebWorkerService, int>(nameof(WebWorkerService.TestFuncAsync), 100, 500);
    //    Console.WriteLine($"ret: {ret}");
    //})));
    //JS.Set("_getWorker", Callback.Create(new Action<bool>(async (verbose) =>
    //{
    //    if (_webWorker == null) _webWorker = await workerService.CreateWorker(verbose);
    //    var ret = await _webWorker.InvokeAsync<WebWorkerService, int>(nameof(WebWorkerService.TestFuncAsync), 100, 500);
    //    Console.WriteLine($"ret: {ret}");
    //})));
    //JS.Set("_getSharedWorker", Callback.Create(new Action<bool?>(async (verbose) =>
    //{
    //    using var _sharedWebWorker = await workerService.CreateSharedWorker("test", verbose.HasValue && verbose.Value);
    //    var ret = await _sharedWebWorker.InvokeAsync<WebWorkerService, int>(nameof(WebWorkerService.TestFuncAsync), 100, 500);
    //    Console.WriteLine($"ret: {ret}");
    //})));
    //JS.Set("_getPrespun", Callback.Create(new Action<bool?>(async (verbose) =>
    //{
    //    await _worker.WhenReady;
    //    var ret = await _worker.InvokeAsync<MathsService, double>(nameof(MathsService.EstimatePI), 1);
    //    //var ret = await _worker.InvokeAsync<WebWorkerService, int>(nameof(WebWorkerService.TestFuncAsync), 100, 500);
    //    Console.WriteLine($"ret: {ret}");
    //})));
}
else
{
    //var parent = workerService.DedicatedWorkerParent;
    //// worker thread
    //JS.Log("This is a background worker.");
    //// test events
    //_ = Task.Run(async () =>
    //{
    //    while (true)
    //    {
    //        workerService.DedicatedWorkerParent.SendEvent("datetest", DateTime.Now.ToString());
    //        await Task.Delay(5000);
    //    }
    //});


    //var ret = await parent.InvokeAsync<MathsService, double>(nameof(MathsService.EstimatePI), 1);
   // Console.WriteLine($"DedicatedWorkerParent ret: {ret}");
}
await host.RunAsync();