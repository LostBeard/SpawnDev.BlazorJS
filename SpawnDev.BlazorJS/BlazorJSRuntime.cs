using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JsonConverters;
using System.Reflection;
using System.Text.Json;

namespace SpawnDev.BlazorJS
{
    public partial class BlazorJSRuntime : IBlazorJSRuntime
    {
        internal static readonly IJSInProcessRuntime _js;
        public static BlazorJSRuntime JS { get; internal set; }
        internal static JsonSerializerOptions? RuntimeJsonSerializerOptions { get; private set; }
        public Window? WindowThis { get; private set; } = null;
        public DedicatedWorkerGlobalScope? DedicateWorkerThis { get; private set; } = null;
        public SharedWorkerGlobalScope? SharedWorkerThis { get; private set; } = null;
        public string GlobalThisTypeName { get; private set; }
        public JSObject GlobalThis { get; private set; }
        public bool IsWindow => GlobalThis is Window;
        public bool IsWorker => IsDedicatedWorkerGlobalScope || IsSharedWorkerGlobalScope || IsServiceWorkerGlobalScope;
        public bool IsDedicatedWorkerGlobalScope => GlobalThis is DedicatedWorkerGlobalScope;
        public bool IsSharedWorkerGlobalScope => GlobalThis is SharedWorkerGlobalScope;
        public bool IsServiceWorkerGlobalScope => GlobalThis is ServiceWorkerGlobalScope;

        static BlazorJSRuntime()
        {
            _js = (IJSInProcessRuntime)typeof(WebAssemblyHost).Assembly.GetType("Microsoft.AspNetCore.Components.WebAssembly.Services.DefaultWebAssemblyJSRuntime").GetField("Instance", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
            RuntimeJsonSerializerOptions = (JsonSerializerOptions)typeof(JSRuntime).GetProperty("JsonSerializerOptions", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_js, null);
            RuntimeJsonSerializerOptions.Converters.Add(new UnionConverterFactory());
            RuntimeJsonSerializerOptions.Converters.Add(new UndefinableConverterFactory());
            RuntimeJsonSerializerOptions.Converters.Add(new JSInProcessObjectReferenceUndefinedConverter());
            RuntimeJsonSerializerOptions.Converters.Add(new JSObjectConverterFactory());
            RuntimeJsonSerializerOptions.Converters.Add(new JSObjectArrayConverterFactory());
            RuntimeJsonSerializerOptions.Converters.Add(new IJSObjectConverterFactory());
            RuntimeJsonSerializerOptions.Converters.Add(new IJSObjectArrayConverterFactory());
            RuntimeJsonSerializerOptions.Converters.Add(new TaskConverterFactory());
            RuntimeJsonSerializerOptions.Converters.Add(new ActionConverterFactory());
            RuntimeJsonSerializerOptions.Converters.Add(new FuncConverterFactory());
            RuntimeJsonSerializerOptions.Converters.Add(new HybridObjectConverterFactory());
        }

        internal BlazorJSRuntime()
        {
            GlobalThisTypeName = GetConstructorName("globalThis");
            switch (GlobalThisTypeName)
            {
                case nameof(Window):
                    WindowThis = Get<Window>("globalThis");
                    GlobalThis = WindowThis;
                    break;
                case nameof(DedicatedWorkerGlobalScope):
                    DedicateWorkerThis = Get<DedicatedWorkerGlobalScope>("globalThis");
                    GlobalThis = DedicateWorkerThis;
                    break;
                case nameof(SharedWorkerGlobalScope):
                    SharedWorkerThis = Get<SharedWorkerGlobalScope>("globalThis");
                    GlobalThis = SharedWorkerThis;
                    break;
                default:
                    GlobalThis = Get<JSObject>("globalThis");
                    break;
            }
#if DEBUG
            Log("JS.GlobalThisTypeName", GlobalThisTypeName);
            Set("JSInterop.debugLevel", 1);
#endif
        }

        /// <summary>
        /// Called by the BlazorJS Javscript module via the Blazor afterStarted call
        /// </summary>
        //async Task AfterStarted()
        //{
        //    // 
        //    Log("> AfterStarted called!");
        //    Log($"{BackgroundServiceTypes.Count} Background services registered");
        //    await Task.Delay(1000);
        //    Log("< AfterStarted called!");
        //}

        public string InformationalVersion { get; } = typeof(JSObject).Assembly.GetAssemblyInformationalVersion();
        public string FileVersion { get; } = typeof(JSObject).Assembly.GetAssemblyFileVersion();

        public void DisposeCallback(string callbackerID) => JSInterop.DisposeCallbacker(callbackerID);

        public AsyncIterator? GetAsyncIterator(IJSInProcessObjectReference targetObject) => targetObject.Get<AsyncIterator?>("Symbol.asyncIterator");

        public Task<bool> LoadScript(string src, string? ifThisGlobalVarIsUndefined = null)
        {
            var t = new TaskCompletionSource<bool>();
            if (!string.IsNullOrEmpty(ifThisGlobalVarIsUndefined) && !IsUndefined(ifThisGlobalVarIsUndefined))
            {
                t.TrySetResult(true);
            }
            else
            {
                LoadScript(src, (r) => t.TrySetResult(r));
            }
            return t.Task;
        }
        public void LoadScript(string src, Action<bool> callback)
        {
            Action<bool> cb = callback;
            using (var script = DocumentCreateElement("script"))
            {
                if (cb != null)
                {
                    CallbackGroup calbacks = new CallbackGroup();
                    script.Set("onload", Callback.Create(() =>
                    {
                        calbacks.Dispose();
                        cb.Invoke(true);
                    }, calbacks));
                    script.Set("onerror", Callback.Create(() =>
                    {
                        calbacks.Dispose();
                        cb.Invoke(false);
                    }, calbacks));
                }
                script.Set("src", src);
                DocumentHeadAppendChild(script);
            }
        }
        public async Task LoadScripts(string[] sources)
        {
            var tasks = new List<Task>();
            foreach (var src in sources) tasks.Add(LoadScript(src));
            await Task.WhenAll(tasks);
        }
        public async Task<ModuleNamespaceObject?> Import(string modulePath)
        {
            var jsRef = await _js.InvokeAsync<IJSInProcessObjectReference?>("import", modulePath);
            return jsRef == null ? null : new ModuleNamespaceObject(jsRef);
        }
        // window
        public IJSInProcessObjectReference GetWindow() => Get<IJSInProcessObjectReference>("window");
        public T GetWindow<T>() where T : JSObject => Get<T>("window");
        // document
        public IJSInProcessObjectReference GetDocument() => Get<IJSInProcessObjectReference>("document");
        public T GetDocument<T>() where T : JSObject => Get<T>("document");
        // document.head
        public IJSInProcessObjectReference GetDocumentHead() => Get<IJSInProcessObjectReference>("document.head");
        public T GetDocumentHead<T>() where T : JSObject => Get<T>("document.head");
        // document.body
        public IJSInProcessObjectReference GetDocumentBody() => Get<IJSInProcessObjectReference>("document.body");
        public T GetDocumentBody<T>() where T : JSObject => Get<T>("document.body");
        public void DocumentHeadAppendChild(IJSInProcessObjectReference element) => CallVoid("document.head.appendChild", element);
        public void DocumentBodyAppendChild(IJSInProcessObjectReference element) => CallVoid("document.body.appendChild", element);
        // document.CreateElement
        public IJSInProcessObjectReference DocumentCreateElement(string elementType) => Call<IJSInProcessObjectReference>("document.createElement", elementType);
        public T DocumentCreateElement<T>(string elementType) where T : JSObject => Call<T>("document.createElement", elementType);
        public static bool JSEquals(object obj1, object obj2) => JSInterop.IsEqual(obj1, obj2);
        public T ReturnMe<T>(object obj) => JSInterop.ReturnMe<T>(obj);
        public T ReturnMe<T>(T obj) => JSInterop.ReturnMe<T>(obj);
        public JSObject FromElementReference(ElementReference elementRef) => ReturnMe<JSObject>(elementRef);
        public IJSInProcessObjectReference ToJSRef(ElementReference elementRef) => ReturnMe<IJSInProcessObjectReference>(elementRef);
        public T FromElementReference<T>(ElementReference elementRef) where T : JSObject => (T)Activator.CreateInstance(typeof(T), ReturnMe<IJSInProcessObjectReference>(elementRef));
        public IJSInProcessObjectReference NewApply(string className, object?[]? args = null) => JSInterop.ReturnNew<IJSInProcessObjectReference>(className, args);
        public IJSInProcessObjectReference New(string className) => NewApply(className);
        public IJSInProcessObjectReference New(string className, object arg0) => NewApply(className, new object[] { arg0 });
        public IJSInProcessObjectReference New(string className, object arg0, object arg1) => NewApply(className, new object[] { arg0, arg1 });
        public IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2) => NewApply(className, new object[] { arg0, arg1, arg2 });
        public IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3) => NewApply(className, new object[] { arg0, arg1, arg2, arg3 });
        public IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4) => NewApply(className, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5) => NewApply(className, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6) => NewApply(className, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7) => NewApply(className, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8) => NewApply(className, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8, object arg9) => NewApply(className, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        public bool IsUndefined(JSObject obj, string identifier = "") => JSInterop.TypeOf(obj, identifier) == "undefined";
        public bool IsUndefined(string identifier) => JSInterop.TypeOf(null, identifier) == "undefined";
        public string TypeOf(JSObject obj, string identifier = "") => JSInterop.TypeOf(obj, identifier);
        public string TypeOf(string identifier) => JSInterop.TypeOf(null, identifier);
        public void Log(params object?[] args) => CallApplyVoid("console.log", args);
        public string GetConstructorName(string identifier) => Get<string>($"{identifier}.constructor.name");
    }
}
