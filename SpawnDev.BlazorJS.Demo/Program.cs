using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev;
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

// Example usage of Union type
// Create a Union<string, int, long> with an int value using implicit conversion
Union<string, int, long> result = 6;

// Use Match to handle each type and return a single type result
string message = await result.Match(
    async str => $"String: {str}",
    num => Task.FromResult($"Number: {num}"),
    num => Task.FromResult($"Number: {num}")
);

// Use Map (or MapAsync) to process the Union based on the type and return a new Union
Union<string, ulong, long> t1 = result.Map((string v) => 99).Map<ulong>((int v) => (ulong)(v * 5));
Union<string, int, long> t2 = await result.MapAsync(async (string v) => v + "1");
Union<string, int, long> t3 = await result.MapAsync(async (int v) => v * 5 + "");

// Use Reduce to get a single type result
// Here we reduce Union<string, int, long> to Union<string, long> to string
string finalValue = result.Reduce((int v) => v.ToString()).Reduce((long v) => v.ToString());

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
