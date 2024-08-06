using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Demo;
using SpawnDev.BlazorJS.Toolbox;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazorJSRuntime(out var JS);

JS.Log($"InstanceId: {JS.InstanceId}");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var host = await builder.Build().StartBackgroundServices();

#if DEBUG

JS.Set("__test", new { name = "something", config = new { visible = true } });

var isUndefined1 = JS.Get<bool>("__test.config.visible");
var isUndefined2 = JS.Get<bool>("__test.config?.visible");
var isUndefined3 = JS.Get<bool>("__test.config2?.visible");
var isUndefined4 = JS.Get<bool>("__test1?.config2.visible1");
var nmt = true;
#endif

await host.BlazorJSRunAsync();
