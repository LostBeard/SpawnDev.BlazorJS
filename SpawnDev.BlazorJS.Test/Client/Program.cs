using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Test;
using SpawnDev.BlazorJS.Test.Services;
using SpawnDev.BlazorJS.WebWorkers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
if (JS.IsWindow)
{
    // we can skip adding dom objects in non UI threads
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");
}
// add services
builder.Services.AddSingleton((sp) => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// SpawnDev.BlazorJS.WebWorkers
builder.Services.AddSingleton<WebWorkerService>();
builder.Services.AddSingleton<FaceAPIService>();
builder.Services.AddSingleton<MediaDevices>();
builder.Services.AddSingleton<MathsService>();
builder.Services.AddSingleton<MediaDevicesService>();
// Radzen
builder.Services.AddSingleton<DialogService>();
builder.Services.AddSingleton<NotificationService>();
builder.Services.AddSingleton<TooltipService>();
builder.Services.AddSingleton<ContextMenuService>();
// build 
WebAssemblyHost host = builder.Build();
// init WebWorkerService
var webWorkerService = host.Services.GetRequiredService<WebWorkerService>();
await webWorkerService.InitAsync();
#region TestingSection
WebWorker? _testWorker = null;
if (JS.IsWindow)
{
    // window thread
    JS.Set("_getTest", Callback.Create(new Action<bool?>(async (verbose) =>
    {
        if (_testWorker == null) _testWorker = await webWorkerService.GetWebWorker(verbose.HasValue && verbose.Value);
    })));
    JS.Set("_disposeTest", Callback.Create(new Action<bool?>(async (verbose) =>
    {
        _testWorker?.Dispose();
        _testWorker = null;
    })));
    JS.Set("_getWorker", Callback.Create(new Action<bool?>(async (verbose) =>
    {
        using var webWorker = await webWorkerService.GetWebWorker(verbose.HasValue && verbose.Value);
        var ret = await webWorker.InvokeAsync<MathsService, string>(nameof(MathsService.CalculatePiWithActionProgress), 100, new Action<int>((i) =>
        {
            Console.WriteLine($"Progress: {i}");
        }));
        Console.WriteLine($"ret: {ret}");
    })));
    JS.Set("_getSharedWorker", Callback.Create(new Action<bool?>(async (verbose) =>
    {
        using var webWorker = await webWorkerService.GetSharedWebWorker(verboseMode: verbose.HasValue && verbose.Value);
        var ret = await webWorker.InvokeAsync<MathsService, string>(nameof(MathsService.CalculatePiWithActionProgress), 100, new Action<int>((i) =>
        {
            Console.WriteLine($"Progress: {i}");
        }));
        Console.WriteLine($"ret: {ret}");
    })));
}
else if (JS.IsDedicatedWorkerGlobalScope)
{
    //Console.WriteLine($"IsDedicatedWorkerGlobalScope: -----------------");
    //// dedicated worker thread
    //var webWorker = webWorkerService.DedicatedWorkerParent;
    //var ret = await webWorker.InvokeAsync<MathsService, string>(nameof(MathsService.CalculatePiWithActionProgress), 100, new Action<int>((i) =>
    //{
    //    Console.WriteLine($"Progress: {i}");
    //}));
    //Console.WriteLine($"ret: {ret}");
}
else if (JS.IsWorker)
{
    // worker thread

}
#endregion
await host.RunAsync();