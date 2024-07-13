using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.Diagnostics;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Reflection;
using SpawnDev.BlazorJS.Test;
using SpawnDev.BlazorJS.Test.Services;
using SpawnDev.BlazorJS.Test.UnitTests;
using SpawnDev.BlazorJS.Toolbox;
using SpawnDev.BlazorJS.WebWorkers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
// Add SpawnDev.BlazorJS.BlazorJSRuntime
builder.Services.AddBlazorJSRuntime(out var JS);
// Add SpawnDev.BlazorJS.WebWorkers.WebWorkerService
builder.Services.AddWebWorkerService();

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

builder.Services.AddSingleton<CryptoService>();
//
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

#if DEBUG && true
var host = await builder.Build().StartBackgroundServices();
// 


await host.BlazorJSRunAsync();
#else
// build and Init using BlazorJSRunAsync (instead of RunAsync)
await builder.Build().BlazorJSRunAsync();
#endif
