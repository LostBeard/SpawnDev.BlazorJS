

# SpawnDev.BlazorJS
[![NuGet](https://img.shields.io/nuget/dt/SpawnDev.BlazorJS.svg?label=SpawnDev.BlazorJS)](https://www.nuget.org/packages/SpawnDev.BlazorJS)  
An easy Javascript interop library desgined specifcally for client side Blazor.

Use Javascript libraries in Blazor without writing any Javascript code.

```cs
// Get and Set global properties
var innerHeight = JS.Get<int>("window.innerHeight");
JS.Set("document.title", "Hello World!");


// Get and Set object properties (Extends IJSInProcessObjectReference)
var window = JS.Get<IJSInProcessObjectReference>("window");
var innerHeight = window.Get<int>("innerHeight");
// Call methods
var item = JS.Call<string?>("localStorage.getItem", "itemName");


// Create a new Javascript object
var worker = JS.CreateNew("Worker", myWorkerScript);


// Pass callbacks to Javascript
JS.Set("testCallback", Callback.Create<string>((strArg) => {
    Console.WriteLine($"Javascript sent: {strArg}");
    // this prints "Hello callback!"
}));

// in Javascript
testCallback('Hello callback!');
```

Use the extended functions of IJSInProcessObjectReference to work with Javascript objects or use the growing library of over 80 of the most common Javascript objects, including ones for WebGL, ab WebRTC already usable in SpawnDev.BlazorJS.JSObjects.

# SpawnDev.BlazorJS.WebWorkers
(Nuget coming soon...)  
Run CPU intensive tasks on a dedicated worker or on a shared worker with WebWorkers!

As simple as...  
Register the WebWorkerService
```cs
// Program.cs
builder.Services.AddSingleton<WebWorkerService>();

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


Inspired by Tewr's BlazorWorker implementation. I even copied one of his test pages for the demo.  
https://github.com/Tewr/BlazorWorker

Demo  
https://blazorjs.spawndev.com/

