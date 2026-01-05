using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.Internal;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JsonConverters;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.Json;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// BlazorJSRuntime provides access to the Javascript environment in a Blazor WebAssembly application.<br/>
    /// It relies on the IJSInProcessRuntime for synchronous interop with the Javascript environment.<br/>
    /// </summary>
    public partial class BlazorJSRuntime
    {
        static Lazy<Type> _WebAssemblyJSObjectReferenceType = new Lazy<Type>(() => typeof(Microsoft.JSInterop.WebAssembly.WebAssemblyJSRuntime).Assembly.GetType("Microsoft.JSInterop.WebAssembly.WebAssemblyJSObjectReference")!);
        internal static Type WebAssemblyJSObjectReferenceType => _WebAssemblyJSObjectReferenceType.Value;
        internal static JsonConverterCollection RuntimeJsonConverters { get; private set; } = new JsonConverterCollection();
        internal static IJSInProcessRuntime JSRuntime;
        /// <summary>
        /// BlazorJSRuntime provides access to the Javascript environment in a Blazor WebAssembly application
        /// </summary>
        public static BlazorJSRuntime JS { get; internal set; } = default!;
        internal static JsonSerializerOptions? RuntimeJsonSerializerOptions { get; private set; }
        /// <summary>
        /// globalThis JSObject instance
        /// </summary>
        public JSObject? GlobalThis { get; private set; }
        /// <summary>
        /// If the globalThis is a Window, WindowThis will refer to globalThis, otherwise null.
        /// </summary>
        public Window? WindowThis { get; private set; }
        /// <summary>
        /// If the globalThis is a DedicatedWorkerGlobalScope, DedicateWorkerThis will refer to globalThis, otherwise null.
        /// </summary>
        public DedicatedWorkerGlobalScope? DedicateWorkerThis { get; private set; }
        /// <summary>
        /// If the globalThis is a SharedWorkerGlobalScope, SharedWorkerThis will refer to globalThis, otherwise null.
        /// </summary>
        public SharedWorkerGlobalScope? SharedWorkerThis { get; private set; }
        /// <summary>
        /// If the globalThis is a ServiceWorkerGlobalScope, ServiceWorkerThis will refer to globalThis, otherwise null.
        /// </summary>
        public ServiceWorkerGlobalScope? ServiceWorkerThis { get; private set; }
        /// <summary>
        /// globalThis.constructor?.name ?? ""
        /// </summary>
        public string GlobalThisTypeName { get; private set; }
        /// <summary>
        /// Returns true if globalThis is a Window
        /// </summary>
        public bool IsWindow => GlobalScope == GlobalScope.Window;
        /// <summary>
        /// Returns true if globalThis is a DedicatedWorkerGlobalScope, SharedWorkerGlobalScope, or a ServiceWorkerGlobalScope
        /// </summary>
        public bool IsWorker => IsDedicatedWorkerGlobalScope || IsSharedWorkerGlobalScope || IsServiceWorkerGlobalScope;
        /// <summary>
        /// Returns true if globalThis is a DedicatedWorkerGlobalScope
        /// </summary>
        public bool IsDedicatedWorkerGlobalScope => GlobalScope == GlobalScope.DedicatedWorker;
        /// <summary>
        /// Returns true if globalThis is a SharedWorkerGlobalScope
        /// </summary>
        public bool IsSharedWorkerGlobalScope => GlobalScope == GlobalScope.SharedWorker;
        /// <summary>
        /// Returns true if globalThis is a ServiceWorkerGlobalScope
        /// </summary>
        public bool IsServiceWorkerGlobalScope => GlobalScope == GlobalScope.ServiceWorker;
        /// <summary>
        /// GlobalScope enum
        /// </summary>
        public GlobalScope GlobalScope { get; private set; }
        /// <summary>
        /// A new instance id generated when the app starts
        /// </summary>
        public string InstanceId { get; private set; }
        /// <summary>
        /// Time elapsed until BlazorJSRuntime is initialized.
        /// </summary>
        [Obsolete("Now the same as ReadyTime")]
        public double StartUpTime => ReadyTime;
        /// <summary>
        /// Time elapsed until all background services have been started. Before page load.
        /// </summary>
        public double ReadyTime { get; internal set; }
        //Performance? Performance { get; set; }
        /// <summary>
        /// Returns true if running in a browser
        /// </summary>
        public bool IsBrowser => OperatingSystem.IsBrowser();
        /// <summary>
        /// Returns true if the in-process JS runtime is available
        /// </summary>
        public bool HasInProcessRuntime => JSRuntime != null;
        /// <summary>
        /// The crossOriginIsolated read-only property returns a boolean value that indicates whether the website is in a cross-origin isolation state. A website is in a cross-origin isolated state, when the response header Cross-Origin-Opener-Policy has the value same-origin and the Cross-Origin-Embedder-Policy header has the value require-corp or credentialless
        /// </summary>
        public bool? CrossOriginIsolated => _CrossOriginIsolated?.Value;
        private Lazy<bool?>? _CrossOriginIsolated = null;
        static Stopwatch sw = Stopwatch.StartNew();
        static BlazorJSRuntime()
        {
            if (OperatingSystem.IsBrowser())
            {
                var defaultWebAssemblyJSRuntimeType = typeof(WebAssemblyHost).Assembly.GetType("Microsoft.AspNetCore.Components.WebAssembly.Services.DefaultWebAssemblyJSRuntime");
                if (defaultWebAssemblyJSRuntimeType == null) FatalError("DefaultWebAssemblyJSRuntime Type is null");
                var instanceField = defaultWebAssemblyJSRuntimeType.GetField("Instance", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                if (instanceField == null) FatalError("DefaultWebAssemblyJSRuntime.Instance FieldInfo is null");
                JSRuntime = (IJSInProcessRuntime)instanceField.GetValue(null)!;
                if (JSRuntime == null) FatalError("IJSInProcessRuntime instance not found");
                RuntimeJsonSerializerOptions = (JsonSerializerOptions)typeof(JSRuntime).GetProperty("JsonSerializerOptions", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)!.GetValue(JSRuntime, null)!;
                RuntimeJsonSerializerOptions.Converters.Add(new TypeJsonConverter());
                RuntimeJsonSerializerOptions.Converters.Add(new ITupleConverterFactory());
                RuntimeJsonSerializerOptions.Converters.Add(new UnionConverterFactory());
                RuntimeJsonSerializerOptions.Converters.Add(new UndefinableConverterFactory());
                RuntimeJsonSerializerOptions.Converters.Add(new JSInProcessObjectReferenceUndefinedConverter());
                RuntimeJsonSerializerOptions.Converters.Add(new JSObjectConverterFactory());
                RuntimeJsonSerializerOptions.Converters.Add(new IJSObjectConverterFactory());
                RuntimeJsonSerializerOptions.Converters.Add(new TaskConverterFactory());
                RuntimeJsonSerializerOptions.Converters.Add(new ActionConverterFactory());
                RuntimeJsonSerializerOptions.Converters.Add(new FuncConverterFactory());
                RuntimeJsonSerializerOptions.Converters.Add(new BigIntegerConverter());
                RuntimeJsonSerializerOptions.Converters.Add(new DynamicJSObjectConverterFactory());
                RuntimeJsonSerializerOptions.Converters.Add(RuntimeJsonConverters);
                RuntimeJsonSerializerOptions.Converters.Add(new JSObjectReferenceArrayConverterFactory(RuntimeJsonSerializerOptions));
                RuntimeJsonSerializerOptions.Converters.Add(new JSObjectReferenceListConverterFactory(RuntimeJsonSerializerOptions));
                RuntimeJsonSerializerOptions.Converters.Add(new HybridObjectConverterFactory(RuntimeJsonSerializerOptions));
            }
        }
        [DoesNotReturn]
        static void FatalError(string msg) => throw new NullReferenceException($"SpawnDev.BlazorJSRuntime fatal error: {msg}");
        /// <summary>
        /// Returns true if the current GlobalScope flag is set in supplied scope var.<br />
        /// Always returns false for GlobalScope enum flags Default, and None.
        /// </summary>
        public bool IsScope(GlobalScope scope) => (GlobalScope & scope) != 0;
        internal BlazorJSRuntime()
        {
            Init();
        }
        void Init()
        {
            JS ??= this;
            var id = Convert.ToHexString(RandomNumberGenerator.GetBytes(8));
            var chunkSize = 4;
            InstanceId = string.Join("-", Enumerable.Range(0, id.Length / chunkSize).Select(i => id.Substring(i * chunkSize, chunkSize)));
            if (HasInProcessRuntime)
            {
                GlobalThisTypeName = ConstructorName() ?? "";
                switch (GlobalThisTypeName)
                {
                    case nameof(Window):
                        // in firefox browser extension running in content mode, a window and globalThis are not the same so they are loaded separately here to normalize usage
                        WindowThis = Get<Window>("window");
                        GlobalThis = Get<Window>("globalThis");
                        GlobalScope = GlobalScope.Window;
                        break;
                    case nameof(DedicatedWorkerGlobalScope):
                        DedicateWorkerThis = Get<DedicatedWorkerGlobalScope>("globalThis");
                        GlobalThis = DedicateWorkerThis;
                        GlobalScope = GlobalScope.DedicatedWorker;
                        break;
                    case nameof(SharedWorkerGlobalScope):
                        SharedWorkerThis = Get<SharedWorkerGlobalScope>("globalThis");
                        GlobalThis = SharedWorkerThis;
                        GlobalScope = GlobalScope.SharedWorker;
                        break;
                    case nameof(ServiceWorkerGlobalScope):
                        ServiceWorkerThis = Get<ServiceWorkerGlobalScope>("globalThis");
                        GlobalThis = ServiceWorkerThis;
                        GlobalScope = GlobalScope.ServiceWorker;
                        break;
                    default:
                        GlobalThis = Get<JSObject>("globalThis");
                        GlobalScope = GlobalScope.BrowserOther;
                        break;
                }
            }
            else
            {
                GlobalScope = GlobalScope.NonBrowser;
            }
        }
        /// <summary>
        /// Callable from Javascript to verify BlazorJSRuntime is running
        /// </summary>
        /// <returns></returns>
        [JSInvokable("RuntimeReadyCheck")]
        public static bool RuntimeReadyCheck()
        {
            var interopReady = JS?.InteropReadyCheck();
            return interopReady == true;
        }
        internal void SetReady()
        {
            if (!sw.IsRunning) return;
            // ready
            RuntimeJsonConverters.Lock();
            sw.Stop();
            ReadyTime = sw.Elapsed.TotalMilliseconds;
        }
        bool InteropReady = false;
        bool InteropReadyCheck()
        {
            if (InteropReady) return true;
            if (JSRuntime != null)
            {
                try
                {
                    InteropReady = JSRuntime.Invoke<bool>("blazorJSInterop.interopReadyCheck");
                    Console.WriteLine($"InteropReadyCheck succ: {InteropReady}");
                    return InteropReady;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"InteropReadyCheck error: {ex.Message}");
                }
            }
            return false;
        }
        /// <summary>
        /// Returns window.MatchMedia("(display-mode: standalone)").Matches
        /// </summary>
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
        /// <summary>
        /// Returns the Environment version
        /// </summary>
        public string EnvironmentVersion { get; } = Environment.Version.ToString();
        /// <summary>
        /// Returns the .Net runtime version
        /// </summary>
        public string FrameworkVersion { get; } = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription.Replace(".NET", "", StringComparison.OrdinalIgnoreCase).Trim();
        /// <summary>
        /// Returns the BlazorJSRuntime assembly informational version
        /// </summary>
        public string InformationalVersion { get; } = typeof(JSObject).Assembly.GetAssemblyInformationalVersion();
        /// <summary>
        /// Returns the BlazorJSRuntime assembly file version
        /// </summary>
        public string FileVersion { get; } = typeof(JSObject).Assembly.GetAssemblyFileVersion();
        /// <summary>
        /// Load the given script by adding a document head script element if the specified global var is not defined.
        /// </summary>
        public async Task LoadScript(string src, string? ifThisGlobalVarIsUndefined = null)
        {
            if (!string.IsNullOrEmpty(ifThisGlobalVarIsUndefined) && !IsUndefined(ifThisGlobalVarIsUndefined)) return;
            await LoadScript(src);
        }
        /// <summary>
        /// Load the given script by adding a document head script element, if in a window scope.<br/>
        /// If in a WorkerGlobalScope, load the given script using importScripts.
        /// </summary>
        public async Task LoadScript(string src)
        {
            if (GlobalThis is WorkerGlobalScope workerGlobalScope)
            {
                workerGlobalScope.ImportScripts(src);
            }
            else if (WindowThis != null)
            {
                using var script = new HTMLScriptElement();
                script.Src = src;
                DocumentHeadAppendChild(script);
                await script.OnLoadAsync();
            }
            else
            {
                throw new NotImplementedException("Unsupported global scope");
            }
        }
        /// <summary>
        /// Loads the specified scripts
        /// </summary>
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
        public Task<ModuleNamespaceObject?> Import(string moduleName) => CallAsync<ModuleNamespaceObject?>("import", moduleName);
        /// <summary>
        /// Import a module and assign it to the specified global variable name<br/>
        /// Ex.:<br/>
        /// await JS.Import("acorn", "https://www.acornlib.com/acorn.js")<br/>
        /// Is roughly equivalent to:<br/>
        /// import * as acorn from "https://www.acornlib.com/acorn.js"<br/>
        /// </summary>
        /// <param name="name">Name of the module object that will be used as a kind of namespace when referring to the imports. Must be a valid JavaScript identifier.</param>
        /// <param name="moduleName">The module to import from. The evaluation of the specifier is host-specified, but always follows the same algorithm as static import declarations.</param>
        /// <returns></returns>
        public async Task<ModuleNamespaceObject?> Import(string name, string moduleName)
        {
            ModuleNamespaceObject ret;
            if (JS.IsUndefined(name))
            {
                ret = (await Import(moduleName))!;
                JS.Set(name, ret);
            }
            else
            {
                ret = JS.Get<ModuleNamespaceObject>(name);
            }
            return ret;
        }
        /// <summary>
        /// The import() syntax, commonly called dynamic import, is a function-like expression that allows loading an ECMAScript module asynchronously and dynamically into a potentially non-module environment.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="moduleName">The module to import from. The evaluation of the specifier is host-specified, but always follows the same algorithm as static import declarations.</param>
        /// <returns></returns>
        public Task<T> Import<T>(string moduleName) => CallAsync<T>("import", moduleName);
        /// <summary>
        /// Import a module and assign it to the specified global variable name<br/>
        /// Ex.:<br/>
        /// await JS.Import("acorn", "https://www.acornlib.com/acorn.js")<br/>
        /// Is roughly equivalent to:<br/>
        /// import * as acorn from "https://www.acornlib.com/acorn.js"<br/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">Name of the module object that will be used as a kind of namespace when referring to the imports. Must be a valid JavaScript identifier.</param>
        /// <param name="moduleName">The module to import from. The evaluation of the specifier is host-specified, but always follows the same algorithm as static import declarations.</param>
        /// <returns></returns>
        public async Task<T> Import<T>(string name, string moduleName)
        {
            T ret;
            if (JS.IsUndefined(name))
            {
                ret = await Import<T>(moduleName);
                JS.Set(name, ret);
            }
            else
            {
                ret = JS.Get<T>(name);
            }
            return ret;
        }
        /// <summary>
        /// Returns the window object or null
        /// </summary>
        public Window? GetWindow() => Get<Window?>("window");
        /// <summary>
        /// Returns the document object or null
        /// </summary>
        public Document? GetDocument() => Get<Document?>("document");
        /// <summary>
        /// Returns the document.head object or null
        /// </summary>
        public HTMLHeadElement? GetDocumentHead() => Get<HTMLHeadElement?>("document.head");
        /// <summary>
        /// Returns the document.body object or null
        /// </summary>
        public HTMLBodyElement? GetDocumentBody() => Get<HTMLBodyElement?>("document.body");
        /// <summary>
        /// Calls document.head.appendChild(element)
        /// </summary>
        public void DocumentHeadAppendChild(Element element) => CallVoid("document.head.appendChild", element);
        /// <summary>
        /// Calls document.body.appendChild(element)
        /// </summary>
        public void DocumentBodyAppendChild(Element element) => CallVoid("document.body.appendChild", element);
        /// <summary>
        /// document.createElement shortcut method
        /// </summary>
        /// <param name="elementType"></param>
        /// <returns></returns>
        public IJSInProcessObjectReference DocumentCreateElement(string elementType) => Call<IJSInProcessObjectReference>("document.createElement", elementType);
        /// <summary>
        /// document.createElement shortcut method
        /// </summary>
        public T DocumentCreateElement<T>(string elementType) where T : Element => Call<T>("document.createElement", elementType);
        /// <summary>
        /// (re-)imports the object from Javascript as the specified type
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <param name="obj">the object to re-import from Javascript</param>
        /// <returns>The object as type T</returns>
        public T ReturnMe<T>(object? obj) => obj == null ? default! : BlazorJSInterop.ObjectGet<T>(obj);
        /// <summary>
        /// (re-)imports the object from Javascript as the specified type
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <param name="obj">the object to re-import from Javascript</param>
        /// <returns>The object as type T</returns>
        public T ReturnMe<T>(T obj) => obj == null ? default! : BlazorJSInterop.ObjectGet<T>(obj);
        /// <summary>
        /// (re-)imports the object from Javascript as the specified type
        /// </summary>
        /// <param name="returnType"></param>
        /// <param name="obj">the object to re-import from Javascript</param>
        /// <returns>The object as type returnType</returns>
        public object? ReturnMe(Type returnType, object? obj) => BlazorJSInterop.ObjectGet(returnType, obj);
        /// <summary>
        /// Returns the ElementReference as an IJSInProcessObjectReference
        /// </summary>
        public IJSInProcessObjectReference ToJSRef(ElementReference elementRef) => ReturnMe<IJSInProcessObjectReference>(elementRef);
        #region New generic
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public T NewApply<T>(string className, object?[]? args = null) => BlazorJSInterop.GlobalPropertyNew<T>(className, args);
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public T New<T>(string className) => NewApply<T>(className);
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public T New<T>(string className, object? arg0) => NewApply<T>(className, new object?[] { arg0 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public T New<T>(string className, object? arg0, object? arg1) => NewApply<T>(className, new object?[] { arg0, arg1 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public T New<T>(string className, object? arg0, object? arg1, object? arg2) => NewApply<T>(className, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public T New<T>(string className, object? arg0, object? arg1, object? arg2, object? arg3) => NewApply<T>(className, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public T New<T>(string className, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => NewApply<T>(className, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public T New<T>(string className, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => NewApply<T>(className, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public T New<T>(string className, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => NewApply<T>(className, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public T New<T>(string className, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => NewApply<T>(className, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public T New<T>(string className, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => NewApply<T>(className, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public T New<T>(string className, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => NewApply<T>(className, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        #endregion
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public IJSInProcessObjectReference NewApply(string className, object?[]? args = null) => BlazorJSInterop.GlobalPropertyNew<IJSInProcessObjectReference>(className, args);
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public IJSInProcessObjectReference New(string className) => NewApply(className);
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public IJSInProcessObjectReference New(string className, object? arg0) => NewApply(className, new object?[] { arg0 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public IJSInProcessObjectReference New(string className, object? arg0, object? arg1) => NewApply(className, new object?[] { arg0, arg1 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public IJSInProcessObjectReference New(string className, object? arg0, object? arg1, object? arg2) => NewApply(className, new object?[] { arg0, arg1, arg2 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public IJSInProcessObjectReference New(string className, object? arg0, object? arg1, object? arg2, object? arg3) => NewApply(className, new object?[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public IJSInProcessObjectReference New(string className, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => NewApply(className, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public IJSInProcessObjectReference New(string className, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => NewApply(className, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public IJSInProcessObjectReference New(string className, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => NewApply(className, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public IJSInProcessObjectReference New(string className, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => NewApply(className, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public IJSInProcessObjectReference New(string className, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => NewApply(className, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Creates a new instance of the specified class
        /// </summary>
        public IJSInProcessObjectReference New(string className, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => NewApply(className, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        /// <summary>
        /// Writes the data to the console using console.log
        /// </summary>
        public void Log(params object?[] args) => CallApplyVoid("console.log", args);
        /// <summary>
        /// Writes the data to the console using console.error
        /// </summary>
        public void LogError(params object?[] args) => CallApplyVoid("console.error", args);
        /// <summary>
        /// Writes the data to the console using console.warn
        /// </summary>
        public void LogWarn(params object?[] args) => CallApplyVoid("console.warn", args);
        /// <summary>
        /// Calls fetch
        /// </summary>
        public Task<Response> Fetch(Request resource) => JS.CallAsync<Response>("fetch", resource);
        /// <summary>
        /// Calls fetch
        /// </summary>
        public Task<Response> Fetch(string resource) => JS.CallAsync<Response>("fetch", resource);
        /// <summary>
        /// Calls fetch
        /// </summary>
        public Task<Response> Fetch(string resource, FetchOptions options) => JS.CallAsync<Response>("fetch", resource, options);
        /// <summary>
        /// Calls setTimeout
        /// </summary>
        public void SetTimeout(Action callback, int msDelay) => JS.CallVoid("setTimeout", Callback.CreateOne(callback), msDelay);
        /// <summary>
        /// Calls setTimeout
        /// </summary>
        public void SetTimeout(Callback callback, int msDelay) => JS.CallVoid("setTimeout", callback, msDelay);
    }
}
