# SpawnDev.BlazorJS
[![NuGet](https://img.shields.io/nuget/dt/SpawnDev.BlazorJS.svg?label=SpawnDev.BlazorJS)](https://www.nuget.org/packages/SpawnDev.BlazorJS) 

Full Blazor WebAssembly and Javascript interop. Create, access properties, call methods, and add/remove event handlers of any Javascript objects the .Net way without writing Javascript.  

**[SpawnDev.BlazorJS.WebWorkers](https://github.com/LostBeard/SpawnDev.BlazorJS.WebWorkers)** is now in a separate repo [here.](https://github.com/LostBeard/SpawnDev.BlazorJS.WebWorkers)

[Live Demo](https://blazorjs.spawndev.com/)  

### Supported .Net Versions
- Blazor WebAssembly .Net 6, 7, and 8 
- - Tested VS Template: Blazor WebAssembly Standalone App
- Blazor United .Net 8 (in WebAssembly project only) 
- - Tested VS Template: Blazor Web App (Interactive WebAssembly mode without prerendering)

### Features:
- Full support for all [Web APIs](https://developer.mozilla.org/en-US/docs/Web/API). If we missed anything, open an issue and it will be updated ASAP.
- Over 350 strongly typed JSObject wrappers ([listed here](https://blazorjs.spawndev.com/JSObjectTypeInfo)) included in BlazorJS including DOM, Crypto, WebGL, WebRTC, Atomics, TypedArrays, and Promises allow direct interaction with Javascript
- Use Javascript libraries in Blazor without writing any Javascript code
- BlazorJSRuntime wraps the default JSRuntime adding additional functionality
- Create new Javascript objects directly from Blazor
- Get and set Javascript object properties as well as access methods
- Easily pass .Net methods to Javascript using JSEventCallback, Callback.Create or Callback.CreateOne methods
- 2 options for wrapping your Javascript objects for direct manipulation from Blazor (No javascript required!)
- - Create a class that inherits JSObject and defines the methods, properties, events, and constructors of your Javascript object (best option)
- - Create an interface that implements IJSObject and defines the methods and properties of your Javascript object (more limited than JSObject option)
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

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add SpawnDev.BlazorJS.BlazorJSRuntime
builder.Services.AddBlazorJSRuntime();

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

The Callback object is used to support Action and Func serialization. It can be used for a bit more control over the lifetime of you callbacks. Pass methods to Javascript using the Callback.Create and Callback.CreateOne methods. These methods use type arguments to set the types expected for incoming arguments (if any) and the expected return type (if any.) async methods are passed as Promises.

Pass lambda callbacks to Javascript
```cs
JS.Set("testCallback", Callback.Create((string strArg) => {
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

JS.Set("someNetFn", Callback.CreateOne(SomeNetFn));
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
async Task<string> SomeNetFnAsync(string input)
{
    await Task.Delay(1000);
    return $"Recvd: {input}";
}

JS.Set("someNetFnAsync", Callback.CreateOne(SomeNetFnAsync));
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
public void IJSObjectInterfaceTest() 
{
    var w = JS.Get<IWindow>("window");
    var randName = Guid.NewGuid().ToString();
    // directly set the window.name property
    w.Name = randName;
    // verify the read back
    if (w.Name != randName) throw new Exception("Interface property set/get failed");
}
```

# JSObjects
Over 350 Javascript types are ready to go in **SpawnDev.BlazorJS**. The interfaces are designed to match thte Javascript [Web API interfaces](https://developer.mozilla.org/en-US/docs/Web/API#interfaces) as closely as possible. Below are some examples.

## HTMLVideoElement
From [HTMLVideoElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLVideoElement):  
> Implemented by the \<video> element, the HTMLVideoElement interface provides special properties and methods for manipulating video objects. It also inherits properties and methods of HTMLMediaElement and HTMLElement.


Example using SpawnDev.BlazorJS.JSObjects.HTMLVideoElement  

From HTMLVideoElementExample.cs  
```cs
@page "/HTMLVideoElementExample"
@implements IDisposable

<div>
    <video style="width: 640px; height: 480px;" controls autoplay muted @ref=videoElRef></video>
</div>
<div>
    Source: @videoName
</div>
<div>
    Duration: @duration.ToString()
</div>
<div>
    Metadata: @metadata
</div>
<div>
    @foreach (var video in videos)
    {
        <button onclick="@(() => SetSource(video.Key, video.Value))">@video.Key</button>
    }
</div>
<pre>
    @((MarkupString)log)
</pre>

@code {
    [Inject]
    BlazorJSRuntime JS { get; set; }
    ElementReference? videoElRef;
    HTMLVideoElement? videoEl = null;
    TimeSpan duration = TimeSpan.Zero;
    string videoName = "";
    string metadata = "";
    string log = "";
    Dictionary<string, string> videos = new Dictionary<string, string>
    {
        { "Elephants Dream", "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4" },
        { "Big Buck Bunny", "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4" },
        { "Tears Of Steel", "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/TearsOfSteel.mp4" },
        { "Sintel", "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/Sintel.mp4" },
        { "None", "" },
    };
    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            videoEl = (HTMLVideoElement)videoElRef!;
            videoEl.OnLoadedMetadata += VideoEl_OnLoadedMetadata;
            videoEl.OnAbort += VideoEl_OnAbort;
            videoEl.OnError += VideoEl_OnError;
        }
    }
    void SetSource(string name, string source)
    {
        if (videoEl == null) return; 
        Log($"SetSource: {name}");
        videoName = name;
        videoEl.Src = source;
        StateHasChanged();
    }
    void VideoEl_OnLoadedMetadata()
    {
        Log("VideoEl_OnLoadedMetadata");
        metadata = $"{videoEl!.VideoWidth}x{videoEl!.VideoHeight}";
        duration = TimeSpan.FromSeconds(videoEl!.Duration ?? 0);
        StateHasChanged();
    }
    void VideoEl_OnError()
    {
        Log("VideoEl_OnError");
    }
    void VideoEl_OnAbort()
    {
        Log("VideoEl_OnAbort");
        metadata = $"{videoEl!.VideoWidth}x{videoEl!.VideoHeight}";
        duration = TimeSpan.FromSeconds(videoEl!.Duration ?? 0);
        StateHasChanged();
    }
    public void Dispose()
    {
        if (videoEl != null)
        {
            videoEl.OnLoadedMetadata -= VideoEl_OnLoadedMetadata;
            videoEl.OnAbort -= VideoEl_OnAbort;
            videoEl.OnError -= VideoEl_OnError;
            videoEl.Dispose();
            videoEl = null;
        }
    }
    void Log(string message)
    {
        log += $"{message}<br/>";
    }
}
```

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
use the growing library of over 350 of the most common Javascript objects, including ones for 
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

Create Promise from lambda method
```cs
var promise = new Promise(async () => {
    await Task.Delay(5000);
});
// pass to Javascript api

```
Create Promise from lambda method with return value
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
Create a custom Audio JSObject wrapper (Example only. Already exists.)
```cs
public class Audio : JSObject
{
    // deserialization constructor
    public Audio(IJSInProcessObjectReference _ref) : base(_ref) { }
    
    // constructor that accepts a string url
    public Audio(string url) : base(JS.New("Audio", url)) { }
    
    // method decalaration
    public void Play() => JSRef.CallVoid("play");
}
```

Then use the Audio JSObject
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

Undefinable\<T\> type. 

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
- SpawnDev.BlazorJS.WebWorkers has moved to its own repo: [SpawnDev.BlazorJS.WebWorkers](https://github.com/LostBeard/SpawnDev.BlazorJS.WebWorkers) 
- 
[![NuGet](https://img.shields.io/nuget/dt/SpawnDev.BlazorJS.WebWorkers.svg?label=SpawnDev.BlazorJS.WebWorkers)](https://www.nuget.org/packages/SpawnDev.BlazorJS.WebWorkers) 

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

Consider sponsoring me to give me more time to work on SpawnDev.BlazorJS and other open source projects.
[Sponsor](https://github.com/sponsors/LostBeard)

[SpawnDev Discord](https://discord.gg/UkGfHtRdSt)

Buy me a coffee 

[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/donate/?hosted_button_id=7QTATH4UGGY9U)

Issues can be reported [here](https://github.com/LostBeard/SpawnDev.BlazorJS/issues) on GitHub.

# Demos
BlazorJS and WebWorkers Demo  
https://blazorjs.spawndev.com/

Current site under development using Blazor WASM  
https://www.spawndev.com/  
