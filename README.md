<p align="center">
  <a href="#">
    <img alt="SpawnDev.BlazorJS" width="128px" height="128px" src="https://raw.githubusercontent.com/LostBeard/SpawnDev.BlazorJS/main/SpawnDev.BlazorJS.Test/wwwroot/icon-128.png"></img>
  </a>
</p>

# NuGet

| Package | Description |
|---------|-------------|
|**[SpawnDev.BlazorJS](#spawndevblazorjs)** <br /> [![NuGet version](https://badge.fury.io/nu/SpawnDev.BlazorJS.svg)](https://www.nuget.org/packages/SpawnDev.BlazorJS)| Enhanced Blazor WebAssembly Javascript interop | 
|**[SpawnDev.BlazorJS.WebWorkers](#spawndevblazorjswebworkers)** <br /> [![NuGet version](https://badge.fury.io/nu/SpawnDev.BlazorJS.WebWorkers.svg)](https://www.nuget.org/packages/SpawnDev.BlazorJS.WebWorkers)| Blazor WASM WebWorkers, SharedWebWorkers, and ServiceWorker |

[Documentation](https://lostbeard.github.io/blazorjs-docs/)  
[Help write the documentation](https://github.com/LostBeard/blazorjs-docs)  
[Live Demo](https://blazorjs.spawndev.com/)
 
# SpawnDev.BlazorJS
[![NuGet](https://img.shields.io/nuget/dt/SpawnDev.BlazorJS.svg?label=SpawnDev.BlazorJS)](https://www.nuget.org/packages/SpawnDev.BlazorJS) 

Full Blazor WebAssembly and Javascript interop. Create, access properties, call methods, and add/remove event handlers of any Javascript objects the .Net way without writing Javascript.  

### Supports:
- Blazor WebAssembly .Net 6, 7, and 8 
- - Recommended VS Template: Blazor WebAssembly Standalone App
- Blazor United .Net 8 (in WebAssembly project only) 
- - Recommended VS Template: Blazor Web App (Auto or WebAssembly interactive mode)

For more information about Blazor types:  
[Blazor: versions, benefits and when to use it
](https://www.c-sharpcorner.com/article/blazor-versions-benefits-and-when-to-use-it/)

### Features:
- 260+ strongly typed JSObject wrappers ([listed here](https://blazorjs.spawndev.com/JSObjectTypeInfo)) included in BlazorJS including DOM, Crypto, WebGL, WebRTC, and Promises allow direct interaction with Javascript
- Use Javascript libraries in Blazor without writing any Javascript code
- BlazorJSRuntime wraps the default JSRuntime adding additional functionality
- Create new Javascript objects directly from Blazor
- Get and set Javascript object properties as well as access methods
- Easily pass .Net methods to Javascript using JSEventCallback, Callback.Create or Callback.CreateOne methods
- 2 options for wrapping your Javascript objects for direct manipulation from Blazor (No javascript required!)
- - Create a class that inherits JSObject and defines the methods, properties, events, and constructors of your Javascript object (best option)
- - Create an interface that implements IJSObject and defines the methods and properties of your Javascript object (more limited than JSObject option)
- Use SpawnDev.BlazorJS.WebWorkers to enable calling Blazor services in SharedWorkers and DedicatedWorkers
- Run Blazor WASM in ServiceWorkers to handle ServiceWorker events in .Net
- Supports Promises, Union method parameters, passing undefined to Javascript, and more

# Issues and Feature requests
I'm here to help. If you find a bug or missing properties, methods, or Javascript objects please submit an issue [here](https://github.com/LostBeard/SpawnDev.BlazorJS/issues) on GitHub. I will help as soon as possible.

# BlazorJSRuntime 
Getting started. Using BlazorJS requires 2 changes to your Program.cs.
- Add the BlazorJSRuntime service with builder.Services.AddBlazorJSRuntime()
- Initialize BlazorJSRuntime by calling builder.Build().BlazorJSRunAsync() instead of builder.Build().RunAsync()

```cs
// ... other usings
using SpawnDev.BlazorJS;

// ... normal builder code
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// Services section
// Add SpawnDev.BlazorJS.BlazorJSRuntime
builder.Services.AddBlazorJSRuntime();
// ... more app services (such as WebWorkerService if needed)
// build and Init using BlazorJSRunAsync (instead of RunAsync)
await builder.Build().BlazorJSRunAsync();
```

Inject into components
```cs
[Inject]
BlazorJSRuntime JS { get; set; }
```

Examples uses
```cs
// Get and Set
var innerHeight = JS.Get<int>("window.innerHeight");
JS.Set("document.title", "Hello World!");

// Call
var item = JS.Call<string?>("localStorage.getItem", "itemName");
JS.CallVoid("addEventListener", "resize", Callback.Create(() => Console.WriteLine("WindowResized"), _callBacks));

// Attach events
using var window = JS.Get<Window>("window");
window.OnOffline += Window_OnOffline;
```

## IMPORTANT NOTE - Async vs Sync Javascript calls
The BlazorJSRuntime behaves differently than the default Blazor JSRuntime. BlazorJSRuntime is more of a 1 to 1 mapping to Javascript. 

When calling Javascript methods that are not asynchronous and do not return a Promise you need to use the synchronous BlazorJSRuntime methods Call, CallVoid, or Get. 
Unlike the default Blazor JSRuntime which would allow the use of InvokeAsync, you must use the synchronous BlazorJSRuntime methods.

Use synchronous BlazorJSRuntime calls for synchronous Javascrtipt methods. 
BlazorJSRuntime CallAsync would throw an error if used on the below Javascript method.

```js
// Javascript
function AddNum(num1, num2){
    return num1 + num2;
}
```

```cs
// C#
var total = JS.Call<int>("AddNum", 20, 22);
// total == 42 here
```


Use asynchronous BlazorJSRuntime calls for asynchronous Javascript methods.
```js
// Javascript
async function AddNum(num1, num2){
    return num1 + num2;
}
```

```cs
// C#
var total = await JS.CallAsync<int>("AddNum", 20, 22);
// total == 42 here
```

Use asynchronous BlazorJSRuntime calls for methods that return a Promise.
```js
// Javascript
function AddNum(num1, num2){
    return new Promise((resolve, reject)=>{
        resolve(num1 + num2);
    });
}
```

```cs
// C#
var total = await JS.CallAsync<int>("AddNum", 20, 22);
// total == 42 here
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
IJSInProcessObjectReference worker = JS.New("Worker", myWorkerScript);
```

# JSEventCallback

Now used extensively throughout the JSObject collection, JSEventCallback allows a clean .Net style way to add and remove .Net callbacks for Javascript events.

With JSEventCallback the operands += and -= can be used to attach and detach .Net callbacks to Javascript events. All reference handling is done automatically when events are added and removed.

Example taken from the Window JSObject class which inherits from EventTarget.
```cs
// This is how JSEventCallback is implemented in the Window class
public JSEventCallback<StorageEvent> OnStorage { get => new JSEventCallback<StorageEvent>(o => AddEventListener("storage", o), o => RemoveEventListener("storage", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
```

Example event attach detach
```cs

void AttachEventHandlersExample()
{
    using var window = JS.Get<Window>("window");
    // If this is the first time Window_OnStorage has been attached to an event a .Net reference is automatically created and held for future use and removal
    window.OnStorage += Window_OnStorage;
    // the window JSObject reference can safely be disposed as the .Net reference is attached to Window_OnStorage internally
}
void DetachEventHandlersExample()
{
    using var window = JS.Get<Window>("window");
    // If this is the last reference of Window_OnStorage being removed then the .Net reference will automatically be disposed.
    // IMPORTANT - detaching is important for preventing resource leaks. .Net references are only released when the reference count reaches zero (same number of -= as += used)
    window.OnStorage -= Window_OnStorage;
}

void Window_OnStorage(StorageEvent storageEvent)
{
    Console.WriteLine($"StorageEvent: {storageEvent.Key} has changed");
}
```

# Action and Func serialization
BlazorJS supports serialization of both Func and Action types. Internally the BlazorJS.Callback object is used. Serialized and deserialized Action and Func objects must call their DisposeJS() extension method to dispose the auto created and associated Callback and/or Function objects.

Action test from BlazorJSUnitTests.cs
```cs
var tcs = new TaskCompletionSource<bool>();
var callback = () =>
{
    tcs.TrySetResult(true);
};
JS.CallVoid("setTimeout", callback, 100);
await tcs.Task;
callback.DisposeJS();
```

Func<,> test from BlazorJSUnitTests.cs
```cs
int testValue = 42;
var origFunc = new Func<int, int>((val) =>
{
    return val;
});
// set a global Javascript var to our Func<int>
// if this is the first time this Func is passed to Javascript a Callback will be created and associated to this Func for use in future serialization
// the auto created Callback must be disposed by calling the extension method Func.DisposeJS()
JS.Set("_funcCallback", origFunc);
// read back in our Func as an Func 
// internally a Javascript Function reference is created and associated with this Func.
// the auto created Function must be disposed by calling the extension method Func.DisposeJS()
var readFunc = JS.Get<Func<int, int>>("_funcCallback");
var readVal = readFunc(testValue);
if (readVal != testValue) throw new Exception("Unexpected result");
// dispose the Function created and associated with the read Func
readFunc.DisposeJS();
// dispose the Callback created and associated with the original Func
origFunc.DisposeJS();
```

# Callback

The Callback object is used internally to support Action and Func serialization. It can be used for a bit more control over the lifetime of you callbacks. Pass methods to Javascript using the Callback.Create and Callback.CreateOne methods. These methods use type arguments to set the types expected for incoming arguments (if any) and the expected return type (if any.) async methods are passed as Promises.

Pass lambda callbacks to Javascript
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

Pass method callbacks to Javascript
```cs
string SomeNetFn(string input){
    return $"Recvd: {input}";
}

JS.Set("someNetFn", Callback.CreateOne<string, string>(SomeNetFn));
```
```js
// in Javascript
someNetFn('Hello callback!');

// prints
Recvd: Hello callback!
```

Pass async method callbacks to Javascript
Under the hood, BlazorJS is returning a Promise to Javascript when the method is called

```cs
async Task<string> SomeNetFnAsync(string input){
    return $"Recvd: {input}";
}

JS.Set("someNetFnAsync", Callback.CreateOne<string, string>(SomeNetFnAsync));
```
```js
// in Javascript
await someNetFnAsync('Hello callback!');

// prints
Recvd: Hello callback!
```

# IJSObject Interface
SpawnDev.BlazorJS can now wrap Javascript objects using interfaces. Just like objects derived from the JSObject class, IJSObject interfaces internally use IJSInProcessObjectReference to wrap a Javascript object for direct manipulation and can be passed to and from Javascript. The main difference is IJSObjects use DispatchProxy to implement the desired interface at runtime instead of requiring a type that inherits JSObject. Currently SpawnDev.BlazorJS does not provide any interfaces for Javascript objects or apis but interfaces are simple to set up.

IJSObject Example
```cs
// create an interface for your Javascript object that implements IJSObject
public interface IWindow : IJSObject 
{
    string Name { get; set; }
    void Alert(string msg = "");
    // ...
}

// use your IJSObject interface to interact with the Javascript object
public void IJSObjectInterfaceTest() {
    var w = JS.Get<IWindow>("window");
    var randName = Guid.NewGuid().ToString();
    // directly set the window.name property
    w.Name = randName;
    // verify the read back
    if (w.Name != randName) throw new Exception("Interface property set/get failed");
}
```

# JSObject Base Class

JSObjects are wrappers around IJSInProcessReference objects that can be passed to and from Javascript and allow strongly typed access to the underlying object. JSObjects take a bit more work to set up but offer more versatility.

JSObject type wrapper example (same as the IJSObject interface example above but with JSObject)
```cs
// create a class for your Javascript object that inherits from JSObject
public class Window : JSObject 
{
    // required constructor
    public Window(IJSInProcessObjectReference _ref) : base(_ref) { }
    public string Name { get => JSRef.Get<string>("name"); set => JSRef.Set("name", value); }
    public void Alert(string msg = "") => JSRef.CallVoid(msg);
    // ...
}

// use the JSObject class to interact with the Javascript object
public void JSObjectClassTest() {
    var w = JS.Get<Window>("window");
    var randName = Guid.NewGuid().ToString();
    // directly set the window.name property
    w.Name = randName;
    // verify the read back
    if (w.Name != randName) throw new Exception("Interface property set/get failed");
}
```

Use the extended functions of IJSInProcessObjectReference to work with Javascript objects or use the growing library of over 100 of the most common Javascript objects, including ones for Window, HTMLDocument, WebStorage (localStorage and sessionStorage), WebGL, WebRTC, and more in SpawnDev.BlazorJS.JSObjects. JSObjects are wrappers around IJSInProcessObjectReference that allow strongly typed use.

Below shows a section of the SpawnDev.BlazorJS.JSObjects.Window class. Window's base type, EventTarget, inherits from JSObject.
```cs
public class Window : EventTarget {
    // all JSObject types must have this constructor
    public Window(IJSInProcessObjectReference _ref) : base(_ref) { }
    // here is a property with both getter and setter
    public string? Name { get => JSRef.Get<string>("name"); set => JSRef.Set("name", value); }
    // here is a read only property that returns another JSObject type
    public WebStorage LocalStorage => JSRef.Get<WebStorage>("localStorage");
    // here are methods
    public long SetTimeout(Callback callback, double delay) => JSRef.Call<long>("setTimeout", callback, delay);
    public void ClearTimeout(long requestId) => JSRef.CallVoid("clearTimeout", requestId);    
    // ... 
}
```

Below the JSObject derived Window class is used
```cs
// below the JSObject derived Window class is used
using var window = JS.Get<Window>("window");
var randName = Guid.NewGuid().ToString();
// set and get properties
window.Name = randName;
var name = window.Name;
// call methods
window.Alert("Hello!");
```

## Promise
SpawnDev.BlazorJS.JSObjects.Promise - is a JSObject wrapper for the Javascript Promise class.
Promises can be created in .Net to wrap async methods or Tasks. They are essentially Javascript's version of Task.

Ways to create a Promise in .Net
```cs
var promise = new Promise();
// pass to Javascript api
...
// then later resolve
promise.Resolve();
```

Create Promise from lambda
```cs
var promise = new Promise(async () => {
    await Task.Delay(5000);
});
// pass to Javascript api

```
Create Promise from lambda with return value
```cs
var promise = new Promise<string>(async () => {
    await Task.Delay(5000);
    return "Hello world!";
});
// pass to Javascript api
```
Create Promise from Task
```cs
var taskSource = new TaskCompletionSource<string>();
var promise = new Promise<string>(taskSource.Task);
// pass to Javascript api
...
// then later resolve
taskSource.TrySetResult("Hello world!");
```

Below is a an example that uses Promises to utilize the [Web Locks API](https://developer.mozilla.org/en-US/docs/Web/API/Web_Locks_API)

```cs
using var navigator = JS.Get<Navigator>("navigator");
using var locks = navigator.Locks;

Console.WriteLine($"lock: 1");

using var waitLock = locks.Request("my_lock", Callback.CreateOne((Lock lockObj) => new Promise(async () => {
    Console.WriteLine($"lock acquired 3");
    await Task.Delay(5000);
    Console.WriteLine($"lock released 4");
})));

using var waitLock2 = locks.Request("my_lock", Callback.CreateOne((Lock lockObj) => new Promise(async () => {
    Console.WriteLine($"lock acquired 5");
    await Task.Delay(5000);
    Console.WriteLine($"lock released 6");
})));

Console.WriteLine($"lock: 2");
```

## Custom JSObjects  
Implement your own JSObject classes for Javascript objects not already available in the BlazorJS.JSObjects library.

Instead of this (simple but not as reusable)
```cs
var audio = JS.New("Audio", "https://some_audio_online");
audio.CallVoid("play");
```
You can do this...  
Create a custom JSObject wrapper
```cs
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

# Union
## Use the Union\<T1, T2, ...\> type with method parameters for strong typing while allowing unrelated types just like in TypeScript.

```cs
void UnionTypeTestMethod(string varName, Union<bool?, string?>? unionTypeValue)
{
    JS.Set(varName, unionTypeValue);
}

var stringValue = "Hello world!";
UnionTypeTestMethod("_stringUnionValue", stringValue);
if (stringValue != JS.Get<string?>("_stringUnionValue")) throw new Exception("Unexpected result");

var boolValue = true;
UnionTypeTestMethod("_boolUnionValue", boolValue);
if (boolValue != JS.Get<bool?>("_boolUnionValue")) throw new Exception("Unexpected result");
```


# Undefinable
## Use Undefinable\<T\> type to pass undefined to Javascript
Some Javascript API calls may have optional parameters that behave differently depending on if you pass a null versus undefined. You can now retain strong typing on JSObject method calls and support passing undefined for JSObject parameters.

New Undefinable\<T\> type. 

Example from Test app unit tests
```cs
// an example method with a parameter that can also be null or undefined
// T of Undefinable<T> must be nullable
void MethodWithUndefinableParams(string varName, Undefinable<bool?>? window)
{
    JS.Set(varName, window);
}

bool? w = false;
// test to show the value is passed normally
MethodWithUndefinableParams("_willBeDefined2", w);
bool? r = JS.Get<bool?>("_willBeDefined2");
if (r != w) throw new Exception("Unexpected result");

w = null;
// null defaults to passing as undefined
MethodWithUndefinableParams("_willBeUndefined2", w);
if (!JS.IsUndefined("_willBeUndefined2")) throw new Exception("Unexpected result");

// if you need to pass null to an Undefinable parameter use Undefinable<T?>.Null
MethodWithUndefinableParams("_willBeNull2", Undefinable<bool?>.Null);
if (JS.IsUndefined("_willBeNull2")) throw new Exception("Unexpected result");

// another way to pass undefined
MethodWithUndefinableParams("_willAlsoBeUndefined2", Undefinable<bool?>.Undefined);
if (!JS.IsUndefined("_willAlsoBeUndefined2")) throw new Exception("Unexpected result");
```

If using JSObjects you can also use JSObject.Undefined\<T\> to create an instance that will be passed to Javascript as undefined.

```cs
// Create an instance of the Window JSObject class that is revived in Javascript as undefined
var undefinedWindow = JSObject.Undefined<Window>();
// undefinedWindow is an instance of Window that is revived in Javascript as undefined
JS.Set("_undefinedWindow", undefinedWindow);
var isUndefined = JS.IsUndefined("_undefinedWindow");
// isUndefined == true here
```

# SpawnDev.BlazorJS.WebWorkers
[![NuGet](https://img.shields.io/nuget/dt/SpawnDev.BlazorJS.WebWorkers.svg?label=SpawnDev.BlazorJS.WebWorkers)](https://www.nuget.org/packages/SpawnDev.BlazorJS.WebWorkers) 

- Easily call Blazor Services in separate threads with WebWorkers and SharedWebWorkers 

- Works in Blazor WASM .Net 6, 7, and 8.

- Does not require SharedArrayBuffer and therefore does not require the special HTTP headers associated with using it.

- Supports and uses transferable objects whenever possible

- Run Blazor WASM in a Service Worker

Tested working in the following browsers (tested with .Net 8.) Chrome Android does not currently support SharedWorkers. 

| Browser         | WebWorker Status | SharedWebWorker Status |
|-----------------|------------------|------------------------|
| Chrome          | ✔ | ✔ |
| MS Edge         | ✔ | ✔ |
| Firefox         | ✔ | ✔ | 
| Chrome Android  | ✔ | ❌ (SharedWorker not supported by browser) |
| MS Edge Android | ✔ | ❌ (SharedWorker not supported by browser) |
| Firefox Android | ✔ | ✔ | 

Firefox WebWorkers note:  
Firefox does not support dynamic modules in workers, which originally made BlazorJS.WebWorkers fail in that browser.
The web worker script now tries to detect this and changes the blazor wasm scripts before they are loaded to workaround this limitation. It is possible some other browsers may have this issue but may not be detected properly.

Issues can be reported [here](https://github.com/LostBeard/SpawnDev.BlazorJS/issues) on GitHub.

Example WebWorkerService setup and usage. 

```cs
// Program.cs
...
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.WebWorkers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// Add SpawnDev.BlazorJS.BlazorJSRuntime
builder.Services.AddBlazorJSRuntime();
// Add SpawnDev.BlazorJS.WebWorkers.WebWorkerService
builder.Services.AddWebWorkerService();
// Add WebWorkerPool service (WIP. optional not used by WebWorkerService)
builder.Services.AddSingleton<WebWorkerPool>();
// Add app services that will be called on the main thread and/or worker threads (Worker services must use interfaces)
builder.Services.AddSingleton<IFaceAPIService, FaceAPIService>();
builder.Services.AddSingleton<IMathsService, MathsService>();
// More app services
builder.Services.AddScoped((sp) => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// ...

// build and Init using BlazorJSRunAsync (instead of RunAsync)
await builder.Build().BlazorJSRunAsync();
```

## WebWorker
You can use the properties ```WebWorkerService.SharedWebWorkerSupported``` and ```WebWorkerService.WebWorkerSupported``` to check for support. 

For a simple fallback when not supported:  
- If WebWorkerService.GetWebWorker() returns a WebWorker, use WebWorker.GetService\<T\>().   
- If WebWorkerService.GetWebWorker() returns a null, use IServiceProvider.GetService\<T\>().

Example component code that uses a service (IMyService) in a WebWorker if supported and in the default Window context if not.
```cs
[Inject]
WebWorkerService workerService { get; set; }

[Inject]
IServiceProvider serviceProvider { get; set; }

// MyServiceAuto will be IMyService running in the WebWorker context if available and IMyService running in the Window context if not
IMyService MyService { get; set; }

WebWorker? webWorker { get; set; }

protected override async Task OnInitializedAsync()
{
    // GetWebWorker() will return null if workerService.WebWorkerSupported == false
    webWorker = await workerService.GetWebWorker();
    // get the WebWorker's service instance if available or this Window's service instance if not
    MyService = webWorker != null ? webWorker.GetService<IMyService>() : serviceProvider.GetService<IMyService>();
    await base.OnInitializedAsync();
}
```

Another example with a progress callback.
```cs

// Create a WebWorker

[Inject]
WebWorkerService workerService { get; set; }
 
 // ...

var webWorker = await workerService.GetWebWorker();

// Call GetService<ServiceInterface> on a web worker to get a proxy for the service on the web worker.
// GetService can only be called with Interface types
var workerMathService = webWorker.GetService<IMathsService>();

// Call async methods on your worker service 
var result = await workerMathService.CalculatePi(piDecimalPlaces);

// Action types can be passed for progress reporting
var result = await workerMathService.CalculatePiWithActionProgress(piDecimalPlaces, new Action<int>((i) =>
{
    // the worker thread can call this method to report progress if desired
    piProgress = i;
    StateHasChanged();
}));
```

## SharedWebWorker
Calling GetSharedWebWorker in another window with the same sharedWorkerName will return the same SharedWebWorker
```cs
// Create or get SHaredWebWorker with the provided sharedWorkerName
var sharedWebWorker = await workerService.GetSharedWebWorker("workername");

// Just like WebWorker but shared
var workerMathService = sharedWebWorker.GetService<IMathsService>();

// Call async methods on your shared worker service
var result = await workerMathService.CalculatePi(piDecimalPlaces);

```

## Send events
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

// From SharedWebWorker or WebWorker threads send an event to connected parents
workerService.SendEventToParents("progress", new PiProgress { Progress = piProgress });

// Or on send an event to a connected worker
webWorker.SendEvent("progress", new PiProgress { Progress = piProgress });
```

## Worker Transferable JSObjects

[Faster is better.](https://developer.chrome.com/blog/transferable-objects-lightning-fast/) SpawnDev WebWorkers use [transferable objects](https://developer.mozilla.org/en-US/docs/Web/API/Web_Workers_API/Transferable_objects) by default for better performance, but it can be disabled with WorkerTransferAttribute. Setting WorkerTransfer to false will cause the property, return value, or parameter to be copied to the receiving thread instead of transferred.


Example
```cs
public class ProcessFrameResult : IDisposable
{
    [WorkerTransfer(false)]
    public ArrayBuffer? ArrayBuffer { get; set; }
    public byte[]? HomographyBytes { get; set; }
    public void Dispose(){
        ArrayBuffer?.Dispose();
    }
}

[return: WorkerTransfer(false)]
public async Task<ProcessFrameResult?> ProcessFrame([WorkerTransfer(false)] ArrayBuffer? frameBuffer, int width, int height, int _canny0, int _canny1, double _needlePatternSize)
{
    var ret = new ProcessFrameResult();
    // ...
    return ret;
}
```

In the above example; the WorkerTransferAttribute on the return type set to false will prevent all properties of the return type from being transferred.

### Transferable JSObject types. Source [MDN](https://developer.mozilla.org/en-US/docs/Web/API/Web_Workers_API/Transferable_objects#supported_objects)
ArrayBuffer  
MessagePort  
ReadableStream  
WritableStream  
TransformStream  
AudioData  
ImageBitmap  
VideoFrame  
OffscreenCanvas  
RTCDataChannel  


## ServiceWorker
As of version 2.2.21 SpawnDev.BlazorJS.WebWorkers supports running Blazor WASM apps in ServiceWorkers. Your app can now register a class to run in the ServiceWorker to handle ServiceWorker events.

### wwwroot/service-worker.js
Create or modify to match the line below.
```js
importScripts('_content/SpawnDev.BlazorJS.WebWorkers/spawndev.blazorjs.webworkers.js');
```

### Program.cs
A minimal Program.cs
```cs
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// SpawnDev.BlazorJS
builder.Services.AddBlazorJSRuntime();
// SpawnDev.BlazorJS.WebWorkers
builder.Services.AddWebWorkerService();
// Register a ServiceWorker handler (AppServiceWorker here) that inherits from ServiceWorkerEventHandler
builder.Services.RegisterServiceWorker<AppServiceWorker>();
// Or Unregister the ServiceWorker if no longer desired
//builder.Services.UnregisterServiceWorker();
// SpawnDev.BlazorJS startup (replaces RunAsync())
await builder.Build().BlazorJSRunAsync();
```

### AppServiceWorker.cs
A verbose service worker implementation example.
- Handle ServiceWorker events by overriding the ServiceWorkerEventHandler base class virtual methods.
- The ServiceWorker event handlers are only called when running in a ServiceWorkerGlobalScope context.
- The AppServiceWorker singleton may be started in any scope and therefore must be scope aware. (For example, do not try to use localStorage in a Worker scope.)
```cs
public class AppServiceWorker : ServiceWorkerEventHandler
{
    public AppServiceWorker(BlazorJSRuntime js, ServiceWorkerConfig serviceWorkerConfig) : base(js, serviceWorkerConfig)
    {

    }

    // called before any ServiceWorker events are handled
    protected override async Task OnInitializedAsync()
    {
        // This service may start in any scope. This will be called before the app runs.
        // If JS.IsWindow == true be careful not stall here.
        // you can do initialization based on the scope that is running
        Log("GlobalThisTypeName", JS.GlobalThisTypeName);
    }

    protected override async Task ServiceWorker_OnInstallAsync(ExtendableEvent e)
    {
        Log($"ServiceWorker_OnInstallAsync");
        _ = ServiceWorkerThis!.SkipWaiting();   // returned task can be ignored
    }

    protected override async Task ServiceWorker_OnActivateAsync(ExtendableEvent e)
    {
        Log($"ServiceWorker_OnActivateAsync");
        await ServiceWorkerThis!.Clients.Claim();
    }

    protected override async Task<Response> ServiceWorker_OnFetchAsync(FetchEvent e)
    {
        Log($"ServiceWorker_OnFetchAsync", e.Request.Method, e.Request.Url);
        Response ret;
        try
        {
            ret = await JS.Fetch(e.Request);
        }
        catch (Exception ex)
        {
            ret = new Response(ex.Message, new ResponseOptions { Status = 500, StatusText = ex.Message, Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } } });
            Log($"ServiceWorker_OnFetchAsync failed: {ex.Message}");
        }
        return ret;
    }

    protected override async Task ServiceWorker_OnMessageAsync(ExtendableMessageEvent e)
    {
        Log($"ServiceWorker_OnMessageAsync");
    }

    protected override async Task ServiceWorker_OnPushAsync(PushEvent e)
    {
        Log($"ServiceWorker_OnPushAsync");
    }

    protected override void ServiceWorker_OnPushSubscriptionChange(Event e)
    {
        Log($"ServiceWorker_OnPushSubscriptionChange");
    }

    protected override async Task ServiceWorker_OnSyncAsync(SyncEvent e)
    {
        Log($"ServiceWorker_OnSyncAsync");
    }

    protected override async Task ServiceWorker_OnNotificationCloseAsync(NotificationEvent e)
    {
        Log($"ServiceWorker_OnNotificationCloseAsync");
    }

    protected override async Task ServiceWorker_OnNotificationClickAsync(NotificationEvent e)
    {
        Log($"ServiceWorker_OnNotificationClickAsync");
    }
}

```


# IDisposable 
NOTE: The above code shows quick examples. Some objects implement IDisposable, such as JSObject, Callback, and IJSInProcessObjectReference types. 

JSObject types will dispose of their IJSInProcessObjectReference object when their finalizer is called if not previously disposed. 

Callback types must be disposed unless created with the Callback.CreateOne method, in which case they will dispose themselves after the first callback. Disposing a Callback prevents it from being called.

IJSInProcessObjectReference does not dispose of interop resources with a finalizer and MUST be disposed when no longer needed. Failing to dispose these will cause memory leaks.

IDisposable objects returned from a WebWorker or SharedWorker service are automatically disposed after the data has been sent to the calling thread.

# Support

Issues can be reported [here](https://github.com/LostBeard/SpawnDev.BlazorJS/issues) on GitHub.

SpawnDev.BlazorJS.WebWorkers is inspired by Tewr's BlazorWorker implementation. Thank you!  
https://github.com/Tewr/BlazorWorker

BlazorJS and WebWorkers Demo  
https://blazorjs.spawndev.com/

Current site under development using Blazor WASM  
https://www.spawndev.com/  

Buy me a coffee 

[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/donate/?hosted_button_id=7QTATH4UGGY9U)