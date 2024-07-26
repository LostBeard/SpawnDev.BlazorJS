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

var host = builder.Build();
await host.StartBackgroundServices();


using var caches = new CacheStorage();
var DefaultCache = await caches.Open("default");
try
{
    var text = await DefaultCache.ReadText("/.etc/somefile.txt");
    var nmt = true;
}
catch (Exception ex)
{
    var nmt = ex.Message;
}

await host.BlazorJSRunAsync();
