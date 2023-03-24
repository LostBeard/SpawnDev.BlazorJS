using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Test;
using SpawnDev.BlazorJS.Test.Services;
using SpawnDev.BlazorJS.WebWorkers;

#if DEBUG
JSObject.UndisposedHandleVerboseMode = true;
#endif

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// Add services
builder.Services.AddScoped((sp) => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// Add SpawnDev.BlazorJS.BlazorJSRuntime
builder.Services.AddBlazorJSRuntime();
// Add SpawnDev.BlazorJS.WebWorkers.WebWorkerService
builder.Services.AddWebWorkerService();
// Add WebWorkerPool service (WIP. optional)
builder.Services.AddSingleton<WebWorkerPool>();
// Add app services that will be called on the main thread and/or worker threads (Worker services must use interfaces)
builder.Services.AddSingleton<IFaceAPIService, FaceAPIService>();
builder.Services.AddSingleton<IMathsService, MathsService>();
// More app services
builder.Services.AddSingleton<MediaDevices>();
builder.Services.AddSingleton<MediaDevicesService>();
// Radzen UI services
builder.Services.AddSingleton<DialogService>();
builder.Services.AddSingleton<NotificationService>();
builder.Services.AddSingleton<TooltipService>();
builder.Services.AddSingleton<ContextMenuService>();
// build and Init using BlazorJSRunAsync (instead of RunAsync)
await builder.Build().BlazorJSRunAsync();
