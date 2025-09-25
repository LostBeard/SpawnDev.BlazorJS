using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.Demo;
using SpawnDev.BlazorJS.Toolbox;
using System.Text;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazorJSRuntime(out var JS);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var host = await builder.Build().StartBackgroundServices();

JS.Set("_testit", (string msg) =>
{
    Console.WriteLine($"_testit called with message: {msg}");
});
#if DEBUG && true

#endif
await host.BlazorJSRunAsync();
