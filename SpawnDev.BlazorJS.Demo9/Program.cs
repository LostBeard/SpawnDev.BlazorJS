using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.Demo9;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazorJSRuntime(out var JS);


var host = builder.Build();

// Microsoft.AspNetCore.Components.WebAssembly.Services.DefaultWebAssemblyJSRuntime
var js = host.Services.GetRequiredService<IJSRuntime>();
var nmt = true;

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
