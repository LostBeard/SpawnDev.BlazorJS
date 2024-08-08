using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.Demo;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazorJSRuntime(out var JS);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var host = await builder.Build().StartBackgroundServices();
#if DEBUG && false
// null-conditional test
JS.Set("__test", new { name = "something", config = new { visible = true } });
var testVar1 = JS.Get<bool>("__test.config.visible");
var testVar2 = JS.Get<bool>("__test.config?.visible");
var testVar3 = JS.Get<bool>("__test.config2?.visible");
var testVar4 = JS.Call<bool>("__test.config2?.doesNotExist");
JS.Set("__test.config2?.doesNotExist", true);
JS.Delete("__test");
#endif
await host.BlazorJSRunAsync();
