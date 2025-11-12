using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BackgroundServices;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.Demo;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Toolbox;
using System.Text;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazorJSRuntime(out var JS);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var host = builder.Build();

await host.Services.StartBackgroundServices();

JS.Set("_testit", (string msg) =>
{
    Console.WriteLine($"_testit called with message: {msg}");
});


var nmt = true;
var http = host.Services.GetRequiredService<HttpClient>();
var gg = true;
#if DEBUG && false
long usedManagedMemory = GC.GetTotalMemory(forceFullCollection: true);
long heapSize = HeapView.GetHeapBufferSize();
JS.Log($"usedManagedMemory: {usedManagedMemory}/{heapSize}");
var mem = new Uint8Array(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 });
usedManagedMemory = GC.GetTotalMemory(forceFullCollection: true);
heapSize = HeapView.GetHeapBufferSize();
JS.Log($"usedManagedMemory: {usedManagedMemory}/{heapSize}");
var bb = mem.ReadBytes();
usedManagedMemory = GC.GetTotalMemory(forceFullCollection: true);
heapSize = HeapView.GetHeapBufferSize();
JS.Log($"usedManagedMemory: {usedManagedMemory}/{heapSize}");
var nmt = true;

#endif
await host.BlazorJSRunAsync();
