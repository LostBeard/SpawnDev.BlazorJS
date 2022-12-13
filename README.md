

# SpawnDev.BlazorJS
[![NuGet](https://img.shields.io/nuget/dt/SpawnDev.BlazorJS.svg?label=SpawnDev.BlazorJS)](https://www.nuget.org/packages/SpawnDev.BlazorJS)  

Supports .Net 7

An easy Javascript interop library desgined specifcally for client side Blazor.

- Use Javascript libraries in Blazor without writing any Javascript code.

- Alternative access to IJSRuntime JS is globally available without injection and is usable on the first line of Program.cs
- Get and set global proeprties via JS.Set and JS.Get
- Create new Javascript objects with JS.New
- Get and set object properties via IJSInProcessObjectReference extended methods
- Create Callbacks that can be sent to Javascript event listeners or assigned to javascript variables

- Easily call Services in separate threads with WebWorkers and SharedWebWorkers

NOTE: The below code shows quick examples. Some objects implement IDisposable, such as all JSObject, IJSInProcessObjectReference, and Callback, and need to be disposed when no longer used.

# JS
```cs
// Get Set
var innerHeight = JS.Get<int>("window.innerHeight");
JS.Set("document.title", "Hello World!");

// Call
var item = JS.Call<string?>("localStorage.getItem", "itemName");
JS.CallVoid("addEventListener", "resize", Callback.Create(() => Console.WriteLine("WindowResized"), _callBacks));
```

# IJSInProcessObjectReference extended
```cs
// Get Set
var window = JS.Get<IJSInProcessObjectReference>("window");
window.Set("myVar", 5);
var myVar = window.Get<int>("myVar");

// Call
window.CallVoid("addEventListener", "resize", Callback.Create(() => Console.WriteLine("WindowResized")));
```


Create a new Javascript object
```cs
var worker = JS.New("Worker", myWorkerScript);
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

# JSObject

Use the extended functions of IJSInProcessObjectReference to work with Javascript objects or use the growing library of over 100 of the most common Javascript objects, including ones for Window, HTMLDocument, WebStorage (locaStorage and sessionStorage), WebGL, WebRTC, and more in SpawnDev.BlazorJS.JSObjects. JSObjects are wrappers around IJSInProcessObjectReference that allow strongly typed use.

# Custom JSObjects  
Implement your own JSObject classes for Javascript objects not already available in the BlazorJS.JSObjects library.

Instead of this (simple but not as reusable)
```cs
var audio = JS.New("Audio", "https://some_audio_online");
audio.CallVoid("play");
```

Do this...  
Create a custom JSObject class
```cs
[JsonConverter(typeof(JSObjectConverter<Audio>))]
public class Audio : JSObject
{
    public Audio(IJSInProcessObjectReference _ref) : base(_ref) { }
    public Audio(string url) : base(JS.New("Audio", url)) { }
    public void Play() => JSRef.CallVoid("play");
}
```

Then use your new object
```cs
var audio = new Audio("https://some_audio_online");
audio.Play();
```

# SpawnDev.BlazorJS.WebWorkers
[![NuGet](https://img.shields.io/nuget/dt/SpawnDev.BlazorJS.WebWorkers.svg?label=SpawnDev.BlazorJS.WebWorkers)](https://www.nuget.org/packages/SpawnDev.BlazorJS.WebWorkers) 

Run CPU intensive tasks on a dedicated worker or on a shared worker with WebWorkers!

Example WebWorkerService setup and usage

```cs
// Program.cs
...
using SpawnDev.BlazorJS;
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

# WebWorker
```cs

// Create a WebWorker
var webWorker = await workerService.GetWebWorker();

// Call a registered service on the worker thread with your arguments
// Action types can be passed for progress reporting
var result = await webWorker.InvokeAsync<MathsService, string>("CalculatePiWithActionProgress", piDecimalPlaces, new Action<int>((i) =>
{
    piProgress = i;
    StateHasChanged();
}));
```

# SharedWebWorker
Calling GetSharedWebWorker in another window with the same sharedWorkerName will return the same SharedWebWorker
```cs
// Create or get SHaredWebWorker with the provided sharedWorkerName
var sharedWebWorker = await workerService.GetSharedWebWorker("workername");

// Just like WebWorker but shared
// Call a registered service on the worker thread with your arguments
var result = await webWorker.InvokeAsync<MathsService, string>("CalculatePiWithActionProgress", piDecimalPlaces, new Action<int>((i) =>
{
    piProgress = i;
    StateHasChanged();
}));
```

# Send events
```cs
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

// From SharedWebWorker or WebWorker threads send an event to conencted parents
workerService.SendEventToParents("progress", new PiProgress { Progress = piProgress });

// Or on send an event to a connected worker
webWorker.SendEvent("progress", new PiProgress { Progress = piProgress });
```

Inspired by Tewr's BlazorWorker implementation. Thank you! I wrote my implementation from scratch as I needed workers in .Net 7.  
https://github.com/Tewr/BlazorWorker

BlazorJS and WebWorkers Demo  
https://blazorjs.spawndev.com/

Buy me a coffee  

[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/donate/?hosted_button_id=7QTATH4UGGY9U)
