using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.Diagnostics;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Reflection;
using SpawnDev.BlazorJS.Test;
using SpawnDev.BlazorJS.Test.Services;
using SpawnDev.BlazorJS.Toolbox;
using SpawnDev.BlazorJS.WebWorkers;

#if DEBUG
JSObject.UndisposedHandleVerboseMode = false;
#endif

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// Modify JSRuntime.JsonSerializerOptions (WARNING: Modifying this can cause unexpected results. Test thoroughly.)
builder.Services.AddJSRuntimeJsonOptions(jsRuntimeJsonOptions =>
{
#if DEBUG && false
    Console.WriteLine($"JSRuntime JsonConverters count: {jsRuntimeJsonOptions.Converters.Count}");
#endif
});
// Add services
builder.Services.AddScoped((sp) => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
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
#if DEBUG
    webWorkerService.TaskPool.PoolSize = 0;  // once web workers startup the VS debugger does not work properly
#else
    webWorkerService.TaskPool.PoolSize = 0; //webWorkerService.GlobalScope == GlobalScope.Window ? 2 : 0;
#endif
});

// Test startup when KeyedServices are used (new in Blazor .Net 8)
// This is to test a bug in SpawnDev.BlazorJS (issue #24) that has been fixed as of 2.2.47
builder.Services.AddKeyedSingleton(typeof(string), "apples", (_, key) => DateTime.Now.ToString() + $" {key}");
builder.Services.AddKeyedSingleton(typeof(string), "grapes", (_, key) => DateTime.Now.ToString() + $" {key}");


// The below service is used to test CallDispatcher used with WebWorkers (Used in UnitTests)
builder.Services.AddSingleton<AsyncCallDispatcherTest>();
// More app specific services
builder.Services.AddSingleton(builder.Configuration); // used to demo appsettings reading in workers
builder.Services.AddSingleton<MediaDevices>();
builder.Services.AddSingleton<MediaDevicesService>();
// Add app services that will be called on the main thread and/or worker threads (Worker services must use interfaces)
builder.Services.AddSingleton<IFaceAPIService, FaceAPIService>(GlobalScope.DedicatedAndSharedWorkers);
builder.Services.AddSingleton<IMathsService, MathsService>();

// Radzen UI services
builder.Services.AddSingleton<DialogService>();
builder.Services.AddSingleton<NotificationService>();
builder.Services.AddSingleton<TooltipService>();
builder.Services.AddSingleton<ContextMenuService>();

builder.Services.AddSingleton<JSObjectAnalyzer>();

//Console.WriteLine($"appsettings test in context {BlazorJSRuntime.JS.GlobalThisTypeName}: " + builder.Configuration["Message"]);

#if DEBUG || true
var host = builder.Build();

//var ms1= host.Services.GetKeyedService<string>("apples");

//var ms = host.Services.GetRequiredService<IMathsService>();

var JS = host.Services.GetRequiredService<BlazorJSRuntime>();

//var sym = new Symbol("desc_test");

//JS.Log("sym", sym);

//var methods = typeof(IMathsService).GetMethods();

//var tmethod = methods.FirstOrDefault(o => o.Name == "TestGenerics");
//var typedMethod = tmethod.MakeGenericMethod(typeof(string), typeof(int));
//var h1 = typedMethod.GetMethodHash();
//var mmmm = SerializableMethodInfo.DeserializeMethodInfo(SerializableMethodInfo.SerializeMethodInfo(typedMethod));
//var h2 = mmmm.GetMethodHash();
//var rett3 = mmmm.Invoke(ms, new object?[] { "hoora", 626 });
//var artisawesome3 = true;

//var nmt5 = true;

//foreach (MethodInfo item in methods)
//{
//    //var stopwatch = Stopwatch.StartNew();
//    //var i = 0;
//    //while(stopwatch.Elapsed.TotalSeconds < 1.0d)
//    //{
//    //    var signature = item.GetMethodSignatureHash();
//    //    i++;
//    //}
//    Console.WriteLine(item.GetMethodSignature());
//}



//var nmtt = true;

//var number = JS.ReturnMe<Number>(155);
//var g = number * 8;


//var strObj = JS.ReturnMe<SpawnDev.BlazorJS.JSObjects.String>("grrr");
//var gr = strObj + " ok";

//var str = JS.ReturnMe<JSObject>("apples");
//JS.Set("_str", str);

//JS.Set("_111", JS.ReturnMe<JSObject>(111));
//var nmt = true;

//var www = JS.Get<IJSInProcessObjectReference>("Symbol.asyncIterator");

////object? tmpp = null;
////var oh = JsonSerializer.Serialize(tmpp);

var jsobjectAnalyzer = host.Services.GetRequiredService<JSObjectAnalyzer>();

//var javascriptDescriptorReader = new JavascriptObjectReflection(JS);

//var window = JS.WindowThis;
//var temp = javascriptDescriptorReader.GetJavascriptObjectProperties(window);
//JS.Set("_temp", temp);
//var nmt = "";

//var analyzing = false;
//JSObject.OnJSObjectCreated = (obj) =>
//{
//    if (jsobjectAnalyzer.ShouldAnalyze(obj) && !analyzing)
//    {
//        analyzing = true;
//        jsobjectAnalyzer.Analyze(obj);
//        analyzing = false;
//    }
//};
////var promise = new Promise();
////var promiseInfo = jsobjectAnalyzer.Analyze(promise);

//var window = JS.Get<Window>("window");
//var windowInfo = jsobjectAnalyzer.Analyze(window);
//JS.Log("_windowInfo", windowInfo);
//JS.Set("_windowInfo", windowInfo);

//var localStorage = JS.Get<Storage>("localStorage");
//var localStorageInfo = jsobjectAnalyzer.Analyze(localStorage);

//JS.Log("_localStorageInfo", localStorageInfo);
//JS.Set("_localStorageInfo", localStorageInfo);

JS.Set("_testWorker", new ActionCallback(async () =>
{
    var webWorkerService = host.Services.GetRequiredService<WebWorkerService>();
    var worker = await webWorkerService.GetWebWorker();
    var math = worker.GetService<IMathsService>();
    var ret = await math.EstimatePI(100);
    Console.WriteLine(ret);
}));
JS.Set("_testWorkerAndDispose", new ActionCallback(async () =>
{
    var webWorkerService = host.Services.GetRequiredService<WebWorkerService>();
    using var worker = await webWorkerService.GetWebWorker();
    var math = worker.GetService<IMathsService>();
    var ret = await math.EstimatePI(100);
    Console.WriteLine(ret);
}));

JS.Set("_analyze", new ActionCallback<JSObject>(async (obj) =>
{
    jsobjectAnalyzer.Analyze(obj);
}));

JS.Set("_log", new ActionCallback<JSObject>((obj) =>
{
    JS.Log(obj);
}));


JS.Set("_return", new FuncCallback<JSObject, JSObject>((obj) =>
{
    return obj;
}));


JS.Set("__testt", new ActionCallback(() =>
{
    JS.Set("_fruit", new Dictionary<string, object> { { "apples_good", true } });
}));

JS.Set("_testIterator", new ActionCallback(async () =>
{
    var obj = JS.Get<JSObject>("delayedResponses");
    var asyncIterator = await obj.JSRef.CallAsync<AsyncIterator>("Symbol.asyncIterator");
    IteratorResult? result = await asyncIterator.Next();
    while (!result.Done)
    {
        JS.Log("Result: ", result.GetValue<JSObject>());
        result = await asyncIterator.Next();
    }
    JS.Log("Done");
}));

JS.Set("_testIterator2", new ActionCallback(async () =>
{
    var obj = JS.Get<JSObject>("delayedResponses");
    var asyncIterator = obj.JSRef.Call<AsyncIterator>(Symbol.AsyncIterator);
    IteratorResult? result = await asyncIterator.Next();
    while (!result.Done)
    {
        JS.Log("Result: ", result.GetValue<JSObject>());
        result = await asyncIterator.Next();
    }
    JS.Log("Done");
}));

await host.BlazorJSRunAsync();

#else

// build and Init using BlazorJSRunAsync (instead of RunAsync)
await builder.Build().BlazorJSRunAsync();

#endif
