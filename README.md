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
[Edit Documentation](https://github.com/LostBeard/blazorjs-docs)  
[Live Demo](https://blazorjs.spawndev.com/)  
 
# SpawnDev.BlazorJS
[![NuGet](https://img.shields.io/nuget/dt/SpawnDev.BlazorJS.svg?label=SpawnDev.BlazorJS)](https://www.nuget.org/packages/SpawnDev.BlazorJS) 

Full Blazor WebAssembly and Javascript interop. Create, access properties, call methods, and add/remove event handlers of any Javascript objects the .Net way without writing Javascript.  

### Supported .Net Versions
- Blazor WebAssembly .Net 6, 7, and 8 
- - Tested VS Template: Blazor WebAssembly Standalone App
- Blazor United .Net 8 (in WebAssembly project only) 
- - Tested VS Template: Blazor Web App (Auto or WebAssembly interactive mode)

For more information about Blazor types:  
[Blazor: versions, benefits and when to use it
](https://www.c-sharpcorner.com/article/blazor-versions-benefits-and-when-to-use-it/)

### Features:
- Full support for all [Web APIs](https://developer.mozilla.org/en-US/docs/Web/API). If you find anything in the Web API we have missed, open an issue and it will be updated ASAP.
- Over 300 strongly typed JSObject wrappers ([listed here](https://blazorjs.spawndev.com/JSObjectTypeInfo)) included in BlazorJS including DOM, Crypto, WebGL, WebRTC, Atomics, TypedArrays, and Promises allow direct interaction with Javascript
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

// AddEventListener and RemoveEventListener are supported on all EventTarget objects
window.AddEventListener("resize", Window_OnResize, true);

window.RemoveEventListener("resize", Window_OnResize, true);
```

## IMPORTANT NOTE - Async vs Sync Javascript calls
SpawnDev's BlazorJSRuntime behaves differently than Microsoft's Blazor JSRuntime. SpawnDev's BlazorJSRuntime is more of a 1 to 1 mapping to Javascript. 

When calling Javascript methods that are not asynchronous and do not return a Promise you need to use the synchronous BlazorJSRuntime methods Call, CallVoid, or Get. 
Unlike the default Blazor JSRuntime which would allow the use of InvokeAsync, you must use the synchronous BlazorJSRuntime methods.

Use synchronous BlazorJSRuntime calls for synchronous Javascript methods. 
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
```

### JSEventCallback arguments are optional
Methods attached using JSEventCallbacks are strongly typed, and like Javascript, all arguments are optional. This will improve performance as unused variables will not be brought into Blazor during the event.

Example event attach detach (from above) without using any callback arguments.
```cs
void AttachEventHandlersExample()
{
    using var window = JS.Get<Window>("window");
    window.OnStorage += Window_OnStorage;
}
void DetachEventHandlersExample()
{
    using var window = JS.Get<Window>("window");
    window.OnStorage -= Window_OnStorage;
}
// The method below is not using the optional StorageEvent argument
void Window_OnStorage()
{
    Console.WriteLine($"StorageEvent");
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
SpawnDev.BlazorJS can now wrap Javascript objects using interfaces. Just like objects derived from the JSObject class, IJSObject interfaces internally use IJSInProcessObjectReference to wrap a Javascript object for direct manipulation and can be passed to and from Javascript. The main difference is IJSObjects use DispatchProxy to implement the desired interface at runtime instead of requiring a type that inherits JSObject. Currently SpawnDev.BlazorJS does not provide any interfaces for Javascript objects or APIs but interfaces are simple to set up.

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

# JSObjects
Over 300 Javascript types are ready to go in **SpawnDev.BlazorJS**. The interfaces are designed to match thte Javascript [Web API interfaces](https://developer.mozilla.org/en-US/docs/Web/API#interfaces) as closely as possible. Below are some examples.

## HTMLVideoElement
From [HTMLVideoElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLVideoElement):  
> Implemented by the \<video> element, the HTMLVideoElement interface provides special properties and methods for manipulating video objects. It also inherits properties and methods of HTMLMediaElement and HTMLElement.

```html
<video @ref= >
```

```cs
[Inject] 
BlazorJSRuntime JS { get; set; }

ElementReference

override void OnInitialized()
{
    using Storage localStorage = JS.Get<Storage>("localStorage");
    localStorage.SetItem("myKey", "myValue");
    var myValue = localStorage.GetItem("myKey");
    // myValue == "myValue"
}
```


***Example coming soon***

## HTMLCanvasElement
***Example coming soon***

## Storage - LocalStorage, SessionStorage
```cs
[Inject] 
BlazorJSRuntime JS { get; set; }

override void OnInitialized()
{
    using Storage localStorage = JS.Get<Storage>("localStorage");
    localStorage.SetItem("myKey", "myValue");
    var myValue = localStorage.GetItem("myKey");
    // myValue == "myValue"
}
```

## IndexedDB
From [IndexedDB on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IndexedDB_API):  
> IndexedDB is a low-level API for client-side storage of significant amounts of structured data, including files/blobs.

The below code was written to test various features of the IndexedDB API and this code specifically tests using a Tuple as an ObjectStore key.

```cs
[Inject] 
BlazorJSRuntime JS { get; set; }

public class Fruit
{
    public (byte[], long) MyKey { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
}

override void OnInitialized()
{
    var dbName = "garden_tuple";
    var dbStoreName = "fruit";
    // Get the global IDBFactory (equivalent to 'JS.Get<IDBFactory>("indexedDB")')
    using var idbFactory = new IDBFactory();    
    var idb = await idbFactory.OpenAsync(dbName, 2, (evt) =>
    {
        // upgrade needed
        using var request = evt.Target;
        using var db = request.Result;
        var stores = db.ObjectStoreNames;
        if (!stores.Contains(dbStoreName))
        {
            using var store = db.CreateObjectStore<string, Fruit>(dbStoreName, new IDBObjectStoreCreateOptions { KeyPath = "name" });
            store.CreateIndex<(byte[], long)>("tuple_index", "myKey");
        }
    });

    // transaction
    using var tx = idb.Transaction(dbStoreName, "readwrite");
    using var objectStore = tx.ObjectStore<string, Fruit>(dbStoreName);

    // add some data
    await objectStore.PutAsync(new Fruit { Name = "apple", Color = "red", MyKey = (new byte[] { 1, 2, 3 }, 5) });
    await objectStore.PutAsync(new Fruit { Name = "orange", Color = "orange", MyKey = (new byte[] { 1, 2, 5 }, 5) });
    await objectStore.PutAsync(new Fruit { Name = "lemon", Color = "yellow", MyKey = (new byte[] { 1, 2, 5 }, 5) });
    await objectStore.PutAsync(new Fruit { Name = "lime", Color = "green", MyKey = (new byte[] { 33, 33, 45 }, 5) });

    // get an IDBIndex
    using var myIndex = objectStore.Index<(byte[], long)>("tuple_index");

    // create a range using ValueTuple type
    using var range = IDBKeyRange<(byte[], long)>.Bound((new byte[] { 0, 0, 0 }, 0), (new byte[] { 5, 5, 5 }, long.MaxValue));

    var included = range.Includes((new byte[] { 1, 2, 4 }, 5));

    var cmpRet0 = idbFactory.Cmp<(byte[], long)>((new byte[] { 1, 2, 3 }, 6), (new byte[] { 1, 2, 3 }, 5));
    var cmpRet1 = idbFactory.Cmp<(byte[], long)>((new byte[] { 1, 2, 3 }, 5), (new byte[] { 1, 2, 3 }, 5));
    var cmpRet2 = idbFactory.Cmp<(byte[], long)>((new byte[] { 1, 2, 2 }, 5), (new byte[] { 1, 2, 3 }, 5));
    var cmpRet3 = idbFactory.Cmp<(byte[], long)>((new byte[] { 1, 2, 4 }, 5), (new byte[] { 1, 2, 3 }, 4));

    // getAll on IDBIndex using the above range
    using var getAll = await myIndex.GetAllAsync(range);

    // below prints "apple", "orange", "lemon"
    // the "lime" entry's byte[] is outside of our range and therefore not included
    foreach (var item in getAll.ToArray())
    {
        JS.Log(item.Name);
    }

    // get on IDBIndex. returns null if not found.
    var get = await myIndex.GetAsync((new byte[] { 1, 2, 5 }, 5));
    JS.Log("get", get);

    // getAll on ObjectStore
    var getAllStore = await objectStore.GetAllAsync();
    JS.Log("getAllStore", getAllStore);

    // IDBCursor iteration
    using var cursor = await myIndex.OpenCursorAsync();
    var hasData = cursor != null;
    while (hasData)
    {
        var canCont1 = await cursor.CanContinue();
        JS.Log("Entry", cursor!.Value);
        hasData = await cursor!.ContinueAsync();
        var canCont2 = await cursor.CanContinue();
        var nmt = true;
    }
    JS.Log("Done");
}
```

## Cache
From [Cache on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Cache)  
> The Cache interface provides a persistent storage mechanism for Request / Response object pairs that are cached in long lived memory.  

***Example coming soon***

## TypedArray
SpawnDev.BlazorJS supports all TypedArray types.  
***Example coming soon***

## Atomics
From [Atomics on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Atomics):  
> The Atomics namespace object contains static methods for carrying out atomic operations. They are used with SharedArrayBuffer and ArrayBuffer objects.


***Example coming soon***

# JSObject Base Class

JSObjects are wrappers around IJSInProcessReference objects that can be passed to and from Javascript and allow strongly typed access to the underlying object.

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

Use the extended functions of IJSInProcessObjectReference to work with Javascript objects or
use the growing library of over 300 of the most common Javascript objects, including ones for 
Window, Document, Storage (localStorage and sessionStorage), WebGL, WebRTC, and more in 
SpawnDev.BlazorJS.JSObjects. JSObjects are wrappers around IJSInProcessObjectReference that 
allow strongly typed use.

Below shows a section of the SpawnDev.BlazorJS.JSObjects.Window class. Window's base type, EventTarget, inherits from JSObject.
```cs
public class Window : EventTarget {
    // all JSObject types must have this constructor
    public Window(IJSInProcessObjectReference _ref) : base(_ref) { }
    // here is a property with both getter and setter
    public string? Name { get => JSRef.Get<string>("name"); set => JSRef.Set("name", value); }
    // here is a read only property that returns another JSObject type
    public Storage LocalStorage => JSRef.Get<Storage>("localStorage");
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

Below is a an example that uses Promises to utilize the [Web Locks API](https://developer.mozilla.org/en-US/docs/Web/API/Web_Locks_API) (**Note**: The below code is designed to demonstrate the use of a Promise. This is not the recommended way of using LockManager. See [WebWorkerService.Locks](#webworkerservicelocks) for more info.)

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

Issues can be reported [here](https://github.com/LostBeard/SpawnDev.BlazorJS/issues) on GitHub.

## WebWorkerService
The WebWorkerService singleton contains many methods for working with multiple instances of your Blazor app running in any scope, whether Window, Worker, SharedWorker, or ServiceWorker. 

### Primary WebWorkerService members:
- **Info** - This property provides basic info about the currently running instance, like instance id and the global scope type.
- [**TaskPool**](#webworkerservicetaskpool) - This WebWorkerPool property gives quick and easy access to any number of Blazor instances running in dedicated worker threads. Access your services in separate threads. TaskPool threads can be started at startup or set to start as needed.
- [**WindowTask**](#webworkerservicewindowtask) - If the current scope is a Window it dispatches on the current scope. If the current scope is a WebWorker and its parent is a Window it will dispatch on the parent Window's scope. Only available in a Window context, or in a WebWorker created by a Window.
- [**Instances**](#webworkerserviceinstances) - This property gives access to every running instance of your Blazor App in the active browser. This includes every scope including other Windows, Workers, SharedWorkers, and ServiceWorkers. Call directly into any running instance from any instance.
- [**Locks**](#webworkerservicelocks) - This property is an instance of LockManager acquired from Navigator.Locks. LockManager provides access to cross-thread locks in all browser scopes. Locks work in a very similar manner to the .Net Mutex.
- [**GetWebWorker**](#webworker) - This async method creates and returns a new instance of WebWorker when it is ready.
- [**GetSharedWebWorker**](#sharedwebworker) - This async method returns an instance of SharedWebWorker with the given name, accessible by all Blazor instances. The worker is created the if it does not already exist. 

### Notes and Common Issues
WebWorkers are separate instances of your Blazor WASM app running in [Workers](https://developer.mozilla.org/en-US/docs/Web/API/Worker). These instances are called into using [postMessage](https://developer.mozilla.org/en-US/docs/Web/API/Worker/postMessage).

#### Developer console shows blazor startup message more than once.
Workers share the window's console. Startup messages and other console messages from them is normal.

#### Missing Javascript dependencies in WebWorkers
See [Javascript dependencies in WebWorkers](#javascript-dependencies-in-webworkers)

#### Serialization and WebWorkers
Communication with WebWorkers is done using [postMessage](https://developer.mozilla.org/en-US/docs/Web/API/Worker/postMessage). Because postMessage is a Javascript method, the data passed to it will be serialized and deserialized using the JSRuntime serializer. Not all .Net types are supported by the JSRuntime serializer so calling methods with unsupported parameter or return types will throw an exception.

### Example WebWorkerService setup and usage. 

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
builder.Services.AddWebWorkerService(webWorkerService =>
{
    // Optionally configure the WebWorkerService service before it is used
    // Default WebWorkerService.TaskPool settings: PoolSize = 0, MaxPoolSize = 1, AutoGrow = true
    // Below sets TaskPool max size to 2. By default the TaskPool size will grow as needed up to the max pool size.
    // Setting max pool size to -1 will set it to the value of navigator.hardwareConcurrency
    webWorkerService.TaskPool.MaxPoolSize = 2;
    // Below is telling the WebWorkerService TaskPool to set the initial size to 2 if running in a Window scope and 0 otherwise
    // This starts up 2 WebWorkers to handle TaskPool tasks as needed
    // Setting this to -1 will set the initial pool size to max pool size
    webWorkerService.TaskPool.PoolSize = webWorkerService.GlobalScope == GlobalScope.Window ? 2 : 0;
});
// Add services
builder.Services.AddSingleton<IFaceAPIService, FaceAPIService>();
builder.Services.AddSingleton<IMathsService, MathsService>();
builder.Services.AddScoped((sp) => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// ...

// build and Init using BlazorJSRunAsync (instead of RunAsync)
await builder.Build().BlazorJSRunAsync();
```

## AsyncCallDispatcher
**AsyncCallDispatcher** is the base class used for accessing other instances of Blazor. **AsyncCallDispatcher** provides a few different calling conventions for instance to instance communication.

Where **AsyncCallDispatcher** is used:  
- The classes **AppInstance**, [**WebWorker**](#webworker), [**SharedWebWorker**](#sharedwebworker), and **WebWorkerPool** all inherit from **AsyncCallDispatcher**.
- [**WebWorkerService.TaskPool**](#webworkerservicetaskpool) - an instance of **WebWorkerPool**, which inherits from **AsyncCallDispatcher**
- **[WebWorkerService.WindowTask](#webworkerservicewindowtask)** - an instance of **AsyncCallDispatcher**
- [**WebWorkerService.Instances**](#webworkerserviceinstances) - a **List&lt;AppInstance&gt;**. **AppInstance** inherits from **AsyncCallDispatcher**  

### Supported Instance To Instance Calling Conventions

**Expressions** - Run(), Set()  
- Supports generics, property get and set, asynchronous and synchronous method calls.
- Supports calling private methods from inside the owning class.

**Delegates** - Invoke()  
- Supports generics, asynchronous and synchronous method calls.  
- Supports calling private methods from inside the owning class.

**Interface proxy** - GetService()
- Supports generics, and asynchronous method calls. (uses DispatchProxy)  
- Does not support static methods, private methods, synchronous calls, or properties.
- Requires services to be registered using an interface.

WebWorkerService.TaskPool Example that demonstrates using **AsyncCallDispatcher's** Expression, Delegate, and Interface proxy invokers to call service methods in a TaskPool WebWorker.

```cs
public interface IMyService
{
    Task<string> WorkerMethodAsync(string input);
}
public class MyService : IMyService
{
    WebWorkerService WebWorkerService;
    public MyService(WebWorkerService webWorkerService)
    {
        WebWorkerService = webWorkerService;
    }
    private string WorkerMethod(string input)
    {
        return $"Hello {input} from {WebWorkerService.InstanceId}";
    }
    public async Task<string> WorkerMethodAsync(string input)
    {
        return $"Hello {input} from {WebWorkerService.InstanceId}";
    }
    public async Task CallWorkerMethod()
    {
        // Call the private method WorkerMethod on this scope (normal)
        Console.WriteLine(WorkerMethod(WebWorkerService.InstanceId));

        // Call a private synchronous method in a WebWorker thread using a Delegate
        Console.WriteLine(await WebWorkerService.TaskPool.Invoke(WorkerMethod, WebWorkerService.InstanceId));

        // Call a private synchronous method in a WebWorker thread using an Expression
        Console.WriteLine(await WebWorkerService.TaskPool.Run(() => WorkerMethod(WebWorkerService.InstanceId)));

        // Call a public async method in a WebWorker thread using an Expression, specifying the registered service to call via a Type parameter (as well as the return type)
        Console.WriteLine(await worker.Run<IMyService, string>(myService => myService.WorkerMethodAsync(WebWorkerService.InstanceId)));

        // Call a public async method in a WebWorker thread using am Interface Proxy
        var service = WebWorkerService.TaskPool.GetService<IMyService>();
        Console.WriteLine(await service.WorkerMethodAsync(WebWorkerService.InstanceId));
    }
}
```

## WebWorkerService.TaskPool
WebWorkerService.TaskPool is ready to call any registered service in a background thread. If WebWorkers are not supported, TaskPool calls will run in the Window scope. The TaskPool settings can be configured when calling AddWebWorkerService(). By default, no worker tasks are started automatically at startup and the max pool size is set to 1. See above example.

## WebWorkerService.Instances
WebWorkerService.Instances is a **List&lt;AppInstance&gt;** where each item represents a running instance. The **AppInstance** class provides some basic information about the running Blazor instance and also allows calling into the instance via its base class [**AsyncCallDispatcher**]($asynccalldispatcher)

The below example iterates all running window instances, reads a service proeprty, and calls a method in that instance.  
```cs
// below gets an instance of AppInstance for each instance running in a Window global scope
var windowInstances = WebWorkerService.Instances.Where(o => o.Info.Scope == GlobalScope.Window).ToList();
var localInstanceId = WebWorkerService.InstanceId;
foreach (var windowInstance in windowInstances)
{
    // below line is an example of how to read a property from another instance
    // here we are reading the BlazorJSRuntime service's InstanceId property from a window instance
    var remoteInstanceId = await windowInstance!.Run(() => JS.InstanceId);
    // below line is an example of how to call a method (here, the static method Console.WriteLine) in another instance
    await windowInstance.Run(() => Console.WriteLine("Hello " + remoteInstanceId + " from " + localInstanceId));
}
```

## WebWorkerService.WindowTask
Sometimes WebWorkers may need to call back into the Window thread that owns them. This can easily be achieved using WebWorkerService.WindowTask. If the current scope is a Window it dispatches on the current scope. If the current scope is a WebWorker and its parent is a Window it will dispatch on the parent Window's scope. Only available in a Window context, or in a WebWorker created by a Window.

```cs
public class MyService
{
    WebWorkerService WebWorkerService;
    public MyService(WebWorkerService webWorkerService)
    {
        WebWorkerService = webWorkerService;
    }
    string CalledOnWindow(string input)
    {
        return $"Hello {input} from {WebWorkerService.InstanceId}";
    }
    public async Task StartedInWorker()
    {   
        // Do some work ...         
        // report back to Window (Expression example)
        // Call the private method CalledOnWindow on the Window thread using an Expression
        Console.WriteLine(await WebWorkerService.WindowTask.Run(() => CalledOnWindow(WebWorkerService.InstanceId)));

        // Do some more work ...         
        // report back to Window again (Delegate example)
        // Call the private method CalledOnWindow on the Window thread using a Delegate
        Console.WriteLine(await WebWorkerService.WindowTask.Invoke(CalledOnWindow, WebWorkerService.InstanceId));
    }
}
```

### Using SharedCancellationToken to cancel a WebWorker task

As of version 2.2.91 ```SharedCancellationToken``` is a supported parameter type and can be used to cancel a running task. SharedCancellationToken works in a similar way to CancellationToken. SharedCancellationTokenSource works in a similar way to CancellationTokenSource.

```cs
public async Task WebWorkerSharedCancellationTokenTest()
{
    if (!WebWorkerService.WebWorkerSupported)
    {
        throw new Exception("Worker not supported by browser. Expected failure.");
    }
    // Cancel the task after 2 seconds
    using var cts = new SharedCancellationTokenSource(2000);
    var i = await WebWorkerService.TaskPool.Run(() => CancellableMethod(10000, cts.Token));
    if (i == -1) throw new Exception("Task Cancellation failed");
}

// Returns -1 if not cancelled
// This method will run for 10 seconds if not cancelled
private static async Task<long> CancellableMethod(double maxRunTimeMS, SharedCancellationToken token)
{
    var startTime = DateTime.Now;
    var maxRunTime = TimeSpan.FromMilliseconds(maxRunTimeMS);
    long i = 0;
    while (DateTime.Now - startTime < maxRunTime)
    {
        // do some work ...
        i += 1;
        // check if cancelled message received
        if (token.IsCancellationRequested) return i;
    }
    return -1;
}
```

#### Limitation: SharedCancellationToken requires cross-origin isolation
```SharedCancellationToken``` and ```SharedCancellationTokenSource``` use a ```SharedArrayBuffer``` for signaling instead of postMessage like ```CancellationToken``` uses. This adds the benefit of working in both synchronous and asynchronous methods. However, they have their own limitation of requiring a cross-origin isolation due to ```SharedArrayBuffer``` restrictions.

### Using CancellationToken to cancel a WebWorker task

As of version 2.2.88 ```CancellationToken``` is a supported parameter type and can be used to cancel a running task.  

```cs
public async Task TaskPoolExpressionWithCancellationTokenTest2()
{
    if (!WebWorkerService.WebWorkerSupported)
    {
        throw new Exception("Worker not supported by browser. Expected failure.");
    }
    // Cancel the task after 2 seconds
    using var cts = new CancellationTokenSource(2000);
    var cancelled = await WebWorkerService.TaskPool.Run(() => CancellableMethod(10000, cts.Token));
    if (!cancelled) throw new Exception("Task Cancellation failed");
}

// Returns true if cancelled  
// This method will run for 10 seconds if not cancelled  
private static async Task<bool> CancellableMethod(double maxRunTimeMS, CancellationToken token)
{
    var startTime = DateTime.Now;
    var maxRunTime = TimeSpan.FromMilliseconds(maxRunTimeMS);
    while (DateTime.Now - startTime < maxRunTime)
    {
        // do some work ...
        await Task.Delay(50);
        // check if cancelled message received
        if (await token.IsCancellationRequestedAsync()) return true;
    }
    return false;
}
```

#### Limitation: CancellationToken requires the receiving method to be async
When a CancellationTokenSource cancels a token that has been passed to a WebWorker a postMessage is sent to the WebWorker(s) to notify them and they call cancel on their instance of a CancellationTokenSource. The problem, is that this requires the method that uses the CancellationToken allows the message event handler time to receive the cancellation message by yielding the thread briefly (```await Task.Delay(1)```) before rechecking if the CancellationToken is cancelled. The extension methods ```CancellationToken.IsCancellationRequestedAsync()``` and ```CancellationToken.ThrowIfCancellationRequestedAsync()``` do this automatically internally. Therefore, CancellationToken will not work in a synchronous method as the message event will never receive the cancellation message. SharedCancellationToken does not have this limitation.

## WebWorkerService.Locks
**WebWorkerService.Locks** is an instance of [LockManager](https://developer.mozilla.org/en-US/docs/Web/API/LockManager) acquired from  ```navigator.locks```. The MDN documentation for [LockManager](https://developer.mozilla.org/en-US/docs/Web/API/LockManager) is explains the interface and has examples.

From MDN [LockManager.request()](https://developer.mozilla.org/en-US/docs/Web/API/LockManager/request)
> The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
>
> The mode property of the options parameter may be either "exclusive" or "shared".
>
> Request an "exclusive" lock when it should only be held by one code instance at a time. This applies to code in both tabs and workers. Use this to represent mutually exclusive access to a resource. When an "exclusive" lock for a given name is held, no other lock with the same name can be held.
>
> Request a "shared" lock when multiple instances of the code can share access to a resource. When a "shared" lock for a given name is held, other "shared" locks for the same name can be granted, but no "exclusive" locks with that name can be held or granted.
>
> This shared/exclusive lock pattern is common in database transaction architecture, for example to allow multiple simultaneous readers (each requests a "shared" lock) but only one writer (a single "exclusive" lock). This is known as the readers-writer pattern. In the IndexedDB API, this is exposed as "readonly" and "readwrite" transactions which have the same semantics.

### WebWorkerService.Locks.Request()

Locks.RequestHandle() example:  
```cs
public async Task SynchronizeDatabase()
{
    JS.Log("requesting lock");
    await WebWorkerService.Locks.Request("my_lock", async (lockInfo) =>
    {
        // because this is an exclusive lock, 
        // the code in this callback will never run in more than 1 thread at a time.
        JS.Log("have lock", lockInfo);
        // simulating async work like synchronizing a browser db to the server
        await Task.Delay(1000);
        // the lock is not released until this async method exits
        JS.Log("releasing lock");
    });
    JS.Log("released lock");
}
```

### WebWorkerService.Locks.RequestHandle()

LockManager.RequestHandle() is an extension method that instead of taking a callback to call when the lock is acquired, it waits for the lock and then returns a TaskCompletionSource that is used to release the lock.

The below example is functionally equivalent to the one above. LockManager.RequestHandle() becomes more useful when a lock needs to be held for an extended period of time.

Locks.RequestHandle() example:  
```cs
public async Task SynchronizeDatabase()
{
    JS.Log("requesting lock");
    TaskCompletionSource tcs = await WebWorkerService.Locks.RequestHandle("my_lock");
    // because this is an exclusive lock,
    // the code between here and 'tcs.SetResult();' will never run in more than 1 thread at a time.
    JS.Log("have lock");
    // simulating async work like synchronizing a browser db to the server
    await Task.Delay(1000);
    // the lock is not released until this async method exits
    JS.Log("releasing lock");
    tcs.SetResult();
    JS.Log("released lock");
}
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

// From SharedWebWorker or WebWorker threads, send an event to connected parent(s)
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


## Javascript dependencies in WebWorkers
When loading a WebWorker, SpawnDev.BlazorJS.WebWorkers ignores all &lt;script&gt; tags in index.html except those marked with the attribute "webworker-enabled". If those scripts will be referenced in workers add the attribute ```webworker-enabled```. This applies to both inline and external scripts.

index.html (partial view)  
```html
    <script webworker-enabled>
        console.log('This script will run in all scopes including window and worker due to the webworker-enabled attribute');
    </script>
    <script>
        console.log('This script will only run in a window scope');
    </script>
```


## ServiceWorker
As of version 2.2.21 SpawnDev.BlazorJS.WebWorkers supports running Blazor WASM apps in ServiceWorkers. Your app can now register a class to run in the ServiceWorker to handle ServiceWorker events.

#### wwwroot/service-worker.js
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

# Blazor Web App compatibility
.Net 8 introduced a new hosting model that allows mixing [Blazor server render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#interactive-server-side-rendering-interactive-ssr) and [Blazor WebAssembly render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#client-side-rendering-csr). [Prerendering](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#prerendering) was also added to improve initial rendering times. "Prerendering is the process of initially rendering page content on the server without enabling event handlers for rendered controls." 

One of the primary goals of SpawnDev.BlazorJS is to give [Web API](https://developer.mozilla.org/en-US/docs/Web/API) access to Blazor WebAssembly that mirrors Javascript's own Web API. This includes calling conventions. For example, a call that is synchronous in Javascript is synchronous in Blazor, an asynchronous call is asynchronous. To provide that, SpawnDev.BlazorJS requires access to Micorosft's IJSInProcessRuntime and IJSInProcessRuntime is only available in Blazor WebAssembly.


## Compatible ```Blazor Web App``` options:  
Prerendering is not compatible with SpawnDev.BlazorJS because it runs on the server. So we need to let Blazor know that SpawnDev.BlazorJS components must be rendered only with WebAssembly. How this is done depends on your project settings.

### ```Interactive render mode``` - ```Auto (Server and WebAssembly)``` or ```WebAssembly```  

### ```Interactivity location``` - ```Per page/component```  

In the Server project ```App.razor```:  
```html
    <Routes />
```

In WebAssembly pages and components that require SpawnDev.BlazorJS:  
```cs
@rendermode @(new InteractiveWebAssemblyRenderMode(prerender: false))
```
  
### ```Interactivity location``` - ```Global```   
In the Server project ```App.razor```:  
```html
    <Routes @rendermode="new InteractiveWebAssemblyRenderMode(prerender: false)"  />
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

Consider sponsoring me to give me more time to work on SpawnDev.BlazorJS.
[Sponsor](https://github.com/sponsors/LostBeard)

[SpawnDev Discord](https://discord.gg/UkGfHtRdSt)

Buy me a coffee 

[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/donate/?hosted_button_id=7QTATH4UGGY9U)