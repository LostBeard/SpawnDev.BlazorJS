using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JsonConverters;
using System.Reflection;
using System.Text.Json;

namespace SpawnDev.BlazorJS
{
    public partial class BlazorJSRuntime
    {
        internal static readonly IJSInProcessRuntime _js;
        public static BlazorJSRuntime JS { get; internal set; }
        internal static JsonSerializerOptions? RuntimeJsonSerializerOptions { get; private set; }
        public Window? WindowThis { get; private set; } = null;
        public DedicatedWorkerGlobalScope? DedicateWorkerThis { get; private set; } = null;
        public SharedWorkerGlobalScope? SharedWorkerThis { get; private set; } = null;
        public ServiceWorkerGlobalScope? ServiceWorkerThis { get; private set; } = null;
        /// <summary>
        /// globalThis.constructor?.name ?? ""
        /// </summary>
        public string GlobalThisTypeName { get; private set; } = "";
        public JSObject GlobalThis { get; private set; }
        public bool IsWindow => GlobalThis is Window;
        public bool IsWorker => IsDedicatedWorkerGlobalScope || IsSharedWorkerGlobalScope || IsServiceWorkerGlobalScope;
        public bool IsDedicatedWorkerGlobalScope => GlobalThis is DedicatedWorkerGlobalScope;
        public bool IsSharedWorkerGlobalScope => GlobalThis is SharedWorkerGlobalScope;
        public bool IsServiceWorkerGlobalScope => GlobalThis is ServiceWorkerGlobalScope;
        public GlobalScope GlobalScope { get; private set; } = GlobalScope.None;
        /// <summary>
        /// A new Guid instance id generated when the app starts
        /// </summary>
        public string InstanceId { get; }
        Performance? Performance { get; }
        /// <summary>
        /// The crossOriginIsolated read-only property returns a boolean value that indicates whether the website is in a cross-origin isolation state. A website is in a cross-origin isolated state, when the response header Cross-Origin-Opener-Policy has the value same-origin and the Cross-Origin-Embedder-Policy header has the value require-corp or credentialless
        /// </summary>
        public bool CrossOriginIsolated => JS.Get<bool>("crossOriginIsolated");
        static BlazorJSRuntime()
        {
            _js = (IJSInProcessRuntime)typeof(WebAssemblyHost).Assembly.GetType("Microsoft.AspNetCore.Components.WebAssembly.Services.DefaultWebAssemblyJSRuntime")!.GetField("Instance", BindingFlags.NonPublic | BindingFlags.Static)!.GetValue(null)!;
            RuntimeJsonSerializerOptions = (JsonSerializerOptions)typeof(JSRuntime).GetProperty("JsonSerializerOptions", BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(_js, null)!;
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

        /// <summary>
        /// Returns true if the current GlobalScope flag is set in supplied scope var.<br />
        /// Always returns false for GlobalScope enum flags Default, and None.
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public bool IsScope(GlobalScope scope) => (GlobalScope & scope) != 0;
        public bool IfScope(GlobalScope scope, Action method)
        {
            if ((GlobalScope & scope) == 0) return false;
            method.Invoke();
            return true;
        }

        public async Task<bool> IfScopeAsync(GlobalScope scope, Func<Task> method)
        {
            if ((GlobalScope & scope) == 0) return false;
            await method.Invoke();
            return true;
        }
        internal BlazorJSRuntime()
        {
            InstanceId = Guid.NewGuid().ToString();
            if (IsUndefined("globalThis.constructor") && !IsUndefined("window"))
            {
                // this happens in Firefox context scripts. They are running in a Window global scope
                // globalThis is not a Window but has a window object
            }
            else
            {
                GlobalThisTypeName = Get<string>("globalThis.constructor.name");
            }
            GlobalScope = GlobalScope.None;
            switch (GlobalThisTypeName)
            {
                case nameof(Window):
                    // In Firefox extension content mode window !== globalThis, but globalThis.constructor.name is patched to say 'Window' (instead of 'undefined')
                    WindowThis = Get<Window>("window");
                    GlobalThis = Get<Window>("globalThis");
                    //WindowThis = Get<Window>("globalThis");
                    //GlobalThis = WindowThis;
                    GlobalScope = GlobalScope.Window;
                    Performance = WindowThis.Performance;
                    StartUpTime = Performance.Now();
                    break;
                case nameof(DedicatedWorkerGlobalScope):
                    DedicateWorkerThis = Get<DedicatedWorkerGlobalScope>("globalThis");
                    GlobalThis = DedicateWorkerThis;
                    GlobalScope = GlobalScope.DedicatedWorker;
                    Performance = DedicateWorkerThis.Performance;
                    StartUpTime = Performance.Now();
                    break;
                case nameof(SharedWorkerGlobalScope):
                    SharedWorkerThis = Get<SharedWorkerGlobalScope>("globalThis");
                    GlobalThis = SharedWorkerThis;
                    GlobalScope = GlobalScope.SharedWorker;
                    Performance = SharedWorkerThis.Performance;
                    StartUpTime = Performance.Now();
                    break;
                case nameof(ServiceWorkerGlobalScope):
                    ServiceWorkerThis = Get<ServiceWorkerGlobalScope>("globalThis");
                    GlobalThis = ServiceWorkerThis;
                    GlobalScope = GlobalScope.ServiceWorker;
                    Performance = ServiceWorkerThis.Performance;
                    StartUpTime = Performance.Now();
                    break;
                default:
                    GlobalThis = Get<JSObject>("globalThis");
                    Performance = Get<Performance?>("performance");
                    StartUpTime = Performance?.Now() ?? 0;
                    break;
            }
            
#if DEBUG && true
            Log("JS.GlobalThisTypeName", GlobalThisTypeName, StartUpTime);
            Set("JSInterop.debugLevel", 1);
            if (IsWindow)
            {
                Log($"IsStandalone: {IsDisplayModeStandalone()}");
            }
#endif
        }
        /// <summary>
        /// Time elapsed until BlazorJSRuntime is initialized.
        /// </summary>
        public double StartUpTime { get; private set; }
        /// <summary>
        /// Time elapsed until all background services have been started. Before page load.
        /// </summary>
        public double ReadyTime { get; internal set; }
        internal void SetReady()
        {
            ReadyTime = Performance?.Now() ?? 0;
        }
        public bool IsDisplayModeStandalone()
        {
            if (WindowThis != null)
            {
                try
                {
                    using var m = WindowThis.MatchMedia("(display-mode: standalone)");
                    return m.Matches;
                }
                catch { }
            }
            return false;
        }

        public string EnvironmentVersion { get; } = Environment.Version.ToString();
        public string FrameworkVersion { get; } = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription.Replace(".NET", "", StringComparison.OrdinalIgnoreCase).Trim();
        public string InformationalVersion { get; } = typeof(JSObject).Assembly.GetAssemblyInformationalVersion();
        /// <summary>
        /// Returns the Assembly File Version of the SpawnDev.BlazorJS
        /// </summary>
        public string FileVersion { get; } = typeof(JSObject).Assembly.GetAssemblyFileVersion();

        public void DisposeCallback(string callbackerID) => JSInterop.DisposeCallbacker(callbackerID);

        //public AsyncIterator? GetAsyncIterator(IJSInProcessObjectReference targetObject) => targetObject.Get<AsyncIterator?>("Symbol.asyncIterator");

        /// <summary>
        /// Load a non-module script if a specified global var is not defined.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="ifThisGlobalVarIsUndefined"></param>
        /// <returns></returns>
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
                    CallbackGroup callbacks = new CallbackGroup();
                    script.Set("onload", callbacks.Add(Callback.Create(() =>
                    {
                        callbacks.Dispose();
                        cb.Invoke(true);
                    })));
                    script.Set("onerror", callbacks.Add(Callback.Create(() =>
                    {
                        callbacks.Dispose();
                        cb.Invoke(false);
                    })));
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
        /// <summary>
        /// The import() syntax, commonly called dynamic import, is a function-like expression that allows loading an ECMAScript module asynchronously and dynamically into a potentially non-module environment.
        /// </summary>
        /// <param name="moduleName">The module to import from. The evaluation of the specifier is host-specified, but always follows the same algorithm as static import declarations.</param>
        /// <returns>Returns a promise which fulfills to a module namespace object: an object containing all exports from moduleName.</returns>
        public async Task<ModuleNamespaceObject?> Import(string moduleName)
        {
            var jsRef = await _js.InvokeAsync<IJSInProcessObjectReference?>("import", moduleName);
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
        /// <summary>
        /// document.createElement shortcut method
        /// </summary>
        /// <param name="elementType"></param>
        /// <returns></returns>
        public IJSInProcessObjectReference DocumentCreateElement(string elementType) => Call<IJSInProcessObjectReference>("document.createElement", elementType);
        /// <summary>
        /// document.createElement shortcut method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elementType"></param>
        /// <returns></returns>
        public T DocumentCreateElement<T>(string elementType) where T : JSObject => Call<T>("document.createElement", elementType);
        /// <summary>
        /// Passes both values to Javascript and tests for equality there
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
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
        // bool IsUndefined(JSObject obj, object? identifier = null) => JSInterop.TypeOf(obj, identifier) == "undefined";
        public bool IsUndefined(string identifier) => JSInterop.GlobalTypeOf(identifier) == "undefined";
        //public string TypeOf(JSObject obj, object? identifier = null) => JSInterop.TypeOf(obj, identifier);
        //public string TypeOf(JSObject obj, int identifier) => JSInterop.TypeOf(obj, identifier);
        public string TypeOf(string identifier) => JSInterop.GlobalTypeOf(identifier);

        public string TypeOf(JSObject obj) => JSInterop.TypeOf(obj, null);

        public void Log(params object?[] args) => CallApplyVoid("console.log", args);
        //public string GetConstructorName(object identifier)
        //{
        //    var jso =
        //    Get<string>($"{identifier}.constructor.name");
        //}
        //public string GetConstructorName(JSObject obj, object identifier)
        //{
        //    if (obj == null || obj.JSRef == null) return "";
        //    try
        //    {
        //        return obj.JSRef.PropertyInstanceOf(identifier);
        //    }
        //    catch { }
        //    return "";
        //}
        public Task<Response> Fetch(Request resource) => JS.CallAsync<Response>("fetch", resource);
        public Task<Response> Fetch(string resource) => JS.CallAsync<Response>("fetch", resource);
        public Task<Response> Fetch(string resource, FetchOptions options) => JS.CallAsync<Response>("fetch", resource, options);
        public void SetTimeout(Action callback, int msDelay) => JS.CallVoid("setTimeout", Callback.CreateOne(callback), msDelay);
        public void SetTimeout(Callback callback, int msDelay) => JS.CallVoid("setTimeout", callback, msDelay);
    }
}
