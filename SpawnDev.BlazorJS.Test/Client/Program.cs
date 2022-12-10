using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.Test;
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
// ...
// build 
WebAssemblyHost host = builder.Build();
// init any services that need it (ideally services are initialized as needed on the pages that use them instead of here.)
var workerService = host.Services.GetRequiredService<WebWorkerService>();
await workerService.InitAsync();
WebWorker? _webWorker = null;
//SharedWebWorker? _sharedWebWorker = null;
// optionally start spinning up a worker now
Task<WebWorker> _preStarted = workerService.CreateWorker(false);
// optionally start spinning up a shared worker now
// shared workers are named. ask for a worker by name in any thread
// the nice thing about shared workers is that they only need to spin up once no matter how many tabs are loaded
_ = workerService.CreateSharedWorker("test");
if (JS.IsWindow)
{
    // main thread
    JS.Set("_newWorker", Callback.Create(new Action<bool>(async (verbose) =>
    {
        using var webWorker = await workerService.CreateWorker(verbose);
        var ret = await webWorker.InvokeAsync<WebWorkerService, int>(nameof(WebWorkerService.TestFuncAsync), 100, 500);
        Console.WriteLine($"ret: {ret}");
    })));
    JS.Set("_getWorker", Callback.Create(new Action<bool>(async (verbose) =>
    {
        if (_webWorker == null) _webWorker = await workerService.CreateWorker(verbose);
        var ret = await _webWorker.InvokeAsync<WebWorkerService, int>(nameof(WebWorkerService.TestFuncAsync), 100, 500);
        Console.WriteLine($"ret: {ret}");
    })));
    JS.Set("_getSharedWorker", Callback.Create(new Action<bool?>(async (verbose) =>
    {
        using var _sharedWebWorker = await workerService.CreateSharedWorker("test", verbose.HasValue && verbose.Value);
        var ret = await _sharedWebWorker.InvokeAsync<WebWorkerService, int>(nameof(WebWorkerService.TestFuncAsync), 100, 500);
        Console.WriteLine($"ret: {ret}");
        var nmt = true;
    })));
    JS.Set("_getSharedWorkerPre", Callback.Create(new Action<bool?>(async (verbose) =>
    {
        using var _sharedWebWorker = await workerService.CreateSharedWorker("test", verbose.HasValue && verbose.Value);
        var ret = await _sharedWebWorker.InvokeAsync<WebWorkerService, int>(nameof(WebWorkerService.TestFuncAsync), 100, 500);
        Console.WriteLine($"ret: {ret}");
        var nmt = true;
    })));
    JS.Set("_getPrespun", Callback.Create(new Action<bool?>(async (verbose) =>
    {
        var worker = await _preStarted;
        var ret = await worker.InvokeAsync<WebWorkerService, int>(nameof(WebWorkerService.TestFuncAsync), 100, 500);
        Console.WriteLine($"ret: {ret}");
        var nmt = true;
    })));
}
else
{
    // worker thread
    JS.Log("This is a background worker.");
}
await host.RunAsync();