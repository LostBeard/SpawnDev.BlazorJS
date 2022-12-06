using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Test;

namespace SpawnDev.BlazorJS.Test
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton(serviceProvider => (IJSInProcessRuntime)serviceProvider.GetRequiredService<IJSRuntime>());

            var host = builder.Build();
            await JS.InitAsync(host.Services.GetRequiredService<IJSInProcessRuntime>());


            var www = JS.Get<Window>("window");
            var testArray = new[] { www, www, www };

            JS.Set("mywindows", testArray);
            var testArrayRead = JS.Get<Window[]>("mywindows");
            var testArrayRewd = JS.Get<IJSInProcessObjectReference[]>("mywindows");
            var t = testArrayRead[0].InnerWidth;
            var q = testArrayRewd[0].Get<int>("innerWidth");
            var eq = JS.JSEquals(3, 2);
            var eq1 = JS.JSEquals(2, 2);
            var innkidth = www.InnerWidth;

            var cache = await Cache.OpenCache("TestCacheYay");

            var tt = new JSObject((IJSInProcessObjectReference)null);


            JS.Set("testSetFn", Callback.Create(() => { Console.WriteLine("Who calls me?"); }));

            var fn = new FunctionHandle("return new Promise(resolve => setTimeout(resolve, 5000, 5));");
            var five = await fn.CallFnAsync<int>();
            //var f5 = await five.ThenAsync<int>();
            var innerWidth = JS.Get<int>("window.innerWidth");
            var window = JS.Get<Window>("window");
            JS.Set("window2", window);
            JS.Set("window2", window);
            var inneeWidth = JS.Get<int>("innerWidth");
            var inneeWigth = window.JSRef.Get<int>("innerWidth");
            var windsw = JS.Get<Window>("window2");

            await host.RunAsync();
        }
    }
}