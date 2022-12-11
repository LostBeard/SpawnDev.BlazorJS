

# SpawnDev.BlazorJS
[![NuGet](https://img.shields.io/nuget/dt/SpawnDev.BlazorJS.svg?label=SpawnDev.BlazorJS)](https://www.nuget.org/packages/SpawnDev.BlazorJS)  

Supports .Net 7

An easy Javascript interop library desgined specifcally for client side Blazor.

Use Javascript libraries in Blazor without writing any Javascript code.

Get and Set global properties
```cs
var innerHeight = JS.Get<int>("window.innerHeight");
JS.Set("document.title", "Hello World!");
```

Get and Set object properties (BlazorJS extends IJSInProcessObjectReference)
```cs
JS.Set("window.myGlobalVar", 5);
var window = JS.Get<IJSInProcessObjectReference>("window");
var innerHeight = window.Get<int>("myGlobalVar");
```

Call methods
```cs
var item = JS.Call<string?>("localStorage.getItem", "itemName");
```

Create a new Javascript object
```cs
var worker = JS.CreateNew("Worker", myWorkerScript);
```

Pass callbacks to Javascript
```cs
JS.Set("testCallback", Callback.Create<string>((strArg) => {
    Console.WriteLine($"Javascript sent: {strArg}");
    // this prints "Hello callback!"
}));
```
```js
// in Javascript
testCallback('Hello callback!');
```

# SpawnDev.BlazorJS.WebWorkers
(Nuget coming soon...)  
Run CPU intensive tasks on a dedicated worker or on a shared worker with WebWorkers!

Example WebWorkerService setup and usage

```cs
// Program.cs
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.Test;
using SpawnDev.BlazorJS.Test.Services;
using SpawnDev.BlazorJS.WebWorkers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
if (JS.IsWindow)
{
    // we can skip adding dom objects in non UI threads
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");
}
// add services
builder.Services.AddSingleton((sp) => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// SpawnDev.BlazorJS.WebWorkers
builder.Services.AddSingleton<WebWorkerService>();
// app specific services...
builder.Services.AddSingleton<MathsService>();
// build 
WebAssemblyHost host = builder.Build();
// init WebWorkerService
var workerService = host.Services.GetRequiredService<WebWorkerService>();
await workerService.InitAsync();
await host.RunAsync();
```

Using the WebWorkers
```cs

// Create a WebWorker
var webWorker = await workerService.CreateWorker();

// Call a registered service on the worker thread with your arguments
int ret = await webWorker.InvokeAsync<MyService, int>("MyLongRunningMethod", 100, 500);
Console.WriteLine($"ret: {ret}");

// Optionally listen for event messages
worker.OnMessage += (sender, msg) =>
{
    if (msg.TargetName == "progress")
    {
        PiProgress msgData = msg.GetData<PiProgress>();
        piProgress = msgData.Progress;
        StateHasChanged();
    }
};

// From SharedWebWorker or WebWorker threads send an event to conencted parents/owners
workerService.SendEventToParents("progress", new PiProgress { Progress = piProgress });

// Or on send an event to a connected worker
webWorker.SendEvent("progress", new PiProgress { Progress = piProgress });

// Create a SharedWebWorker
// Calling the CreateSharedWorker in another window will get the worker with the same name
var sharedWebWorker = await workerService.CreateSharedWorker("workername");

// Just like WebWorker but shared
// Call a registered service on the worker thread with your arguments
int ret = await sharedWebWorker.InvokeAsync<MyService, int>("MyLongRunningMethod", 100, 500);
Console.WriteLine($"ret: {ret}");
```

Inspired by Tewr's BlazorWorker implementation. Thank you! I wrote my implementation from scratch as I needed workers in .Net 7.  
https://github.com/Tewr/BlazorWorker

I shamelessly copied one of Tewr's test pages for the WebWorkers demo.  
BlazorJS and WebWorkers Demo  
https://blazorjs.spawndev.com/

# JSObject

Use the extended functions of IJSInProcessObjectReference to work with Javascript objects or use the growing library of over 100 of the most common Javascript objects, including ones for Window, HTMLDocument, WebStorage (locaStorage and sessionStorage), WebGL, WebRTC, and more in SpawnDev.BlazorJS.JSObjects. JSObjects are wrappers around IJSInProcessObjectReference that allow strongly typed use.

# Custom JSObjects  
Implement your own JSObject classes for Javascript objects not already available in the BlazorJS.JSObjects library.

Instead of this (simple but not as reusable)
```cs
var audio = JS.CreateNew("Audio", "https://some_audio_online");
audio.CallVoid("play");
```

Do this...  
Create a custom JSObject class
```cs
[JsonConverter(typeof(JSObjectConverter<Audio>))]
public class Audio : JSObject
{
    public Audio(IJSInProcessObjectReference _ref) : base(_ref) { }
    public Audio(string url) : base(JS.CreateNew("Audio", url)) { }
    public void Play() => JSRef.CallVoid("play");
}
```

Then use your new object
```cs
var audio = new Audio("https://some_audio_online");
audio.Play();
```

[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/donate/?hosted_button_id=7QTATH4UGGY9U)

