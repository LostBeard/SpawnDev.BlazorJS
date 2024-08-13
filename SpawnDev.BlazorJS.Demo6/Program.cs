using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.Demo6;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazorJSRuntime(out var JS);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var host = await builder.Build().StartBackgroundServices();

JS.Set("testCallback", Callback.Create((string strArg) =>
{
    Console.WriteLine($"Javascript sent: {strArg}");
    // this prints "Hello callback!"
}));

await host.BlazorJSRunAsync();

