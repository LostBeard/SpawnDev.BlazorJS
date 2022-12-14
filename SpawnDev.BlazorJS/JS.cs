using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System.Reflection;

namespace SpawnDev.BlazorJS
{
    // Facilitates the JSInterop javascript code
    public static partial class JS
    {
        public static Window? WindowThis { get; private set; } = null;
        public static DedicatedWorkerGlobalScope? DedicateWorkerThis { get; private set; } = null;
        public static SharedWorkerGlobalScope? SharedWorkerThis { get; private set; } = null;
        public static string GlobalThisTypeName { get; private set; }
        public static JSObject GlobalThis { get; private set; }
        private static IJSInProcessRuntime? _js { get; set; } = null;
        public static bool IsWindow => GlobalThis is Window;
        public static bool IsWorker => IsDedicatedWorkerGlobalScope || IsSharedWorkerGlobalScope || IsServiceWorkerGlobalScope;
        public static bool IsDedicatedWorkerGlobalScope => GlobalThis is DedicatedWorkerGlobalScope;
        public static bool IsSharedWorkerGlobalScope => GlobalThis is SharedWorkerGlobalScope;
        public static bool IsServiceWorkerGlobalScope => GlobalThis is ServiceWorkerGlobalScope;

        static JS()
        {
            // the javascript module for JS is loaded before Program.cs is started so it available here to continue initializing
            // _content/SpawnDev.BlazorJS/SpawnDev.BlazorJS.lib.module.js
            var jsRuntimeType = typeof(WebAssemblyHost).Assembly.GetType("Microsoft.AspNetCore.Components.WebAssembly.Services.DefaultWebAssemblyJSRuntime");
            var instanceField = jsRuntimeType.GetField("Instance", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            object? jsRuntimeObj = instanceField.GetValue(null);
            _js = (IJSInProcessRuntime)jsRuntimeObj;    // (WebAssemblyJSRuntime)
            GlobalThisTypeName = GetConstructorName("globalThis");
            switch (GlobalThisTypeName)
            {
                case nameof(Window):
                    WindowThis = JS.Get<Window>("globalThis");
                    GlobalThis = WindowThis;
                    break;
                case nameof(DedicatedWorkerGlobalScope):
                    DedicateWorkerThis = JS.Get<DedicatedWorkerGlobalScope>("globalThis");
                    GlobalThis = DedicateWorkerThis;
                    break;
                case nameof(SharedWorkerGlobalScope):
                    SharedWorkerThis = JS.Get<SharedWorkerGlobalScope>("globalThis");
                    GlobalThis = SharedWorkerThis;
                    break;
                default:
                    GlobalThis = JS.Get<JSObject>("globalThis");
                    break;
            }

#if false
            // JsonSerializerOptions JsonSerializerOptions
            var jsonSerializerOptionsProperty = typeof(JSRuntime).GetProperty("JsonSerializerOptions", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            _runtimeSerializerOptions = (JsonSerializerOptions)jsonSerializerOptionsProperty.GetValue(jsRuntimeObj);

            // get ArrayBuilder<T> type
            var arrayBuilderType = typeof(JSRuntime).Assembly.GetType("Microsoft.JSInterop.Infrastructure.ArrayBuilder`1");
            var arrayBuilerTypedByteArray = arrayBuilderType.MakeGenericType(new Type[] { typeof(byte[]) });
            arrayBuilderClearMethod = arrayBuilerTypedByteArray.GetMethod("Clear", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var byteArraysToBeRevivedProperty = typeof(JSRuntime).GetField("ByteArraysToBeRevived", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            arrayBuilderInstance = byteArraysToBeRevivedProperty.GetValue(jsRuntimeObj);

            // WebAssembly.JSInterop.InternalCalls
            var internalCallsType = GetType("WebAssembly.JSInterop.InternalCalls");
            internalCallsInvoekJSMethod = internalCallsType.GetMethod("InvokeJS", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
#endif
#if DEBUG
            Log("JS.GlobalThisTypeName", GlobalThisTypeName);
#endif
        }

        private static void AssertInit()
        {
            if (_js == null) throw new Exception("JS must be initialized before use via SpawnDev.BlazorJS.JS.InitAsync(IJSInProcessRuntime) usually in Program.cs");
        }
        public static void DisposeCallback(string callbackerID) => _JSInteropCallVoid("DisposeCallbacker", callbackerID);

        public static AsyncIterator? GetAsyncIterator(IJSInProcessObjectReference targetObject) => Get<AsyncIterator?>(targetObject, "Symbol.asyncIterator");

        public static Task<bool> LoadScript(string src, string? ifThisGlobalVarIsUndefined = null)
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
        public static void LoadScript(string src, Action<bool> callback)
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
        public static async Task LoadScripts(string[] sources)
        {
            var tasks = new List<Task>();
            foreach (var src in sources) tasks.Add(LoadScript(src));
            await Task.WhenAll(tasks);
        }
        // window
        public static IJSInProcessObjectReference GetWindow() => Get<IJSInProcessObjectReference>("window");
        public static T GetWindow<T>() where T : JSObject => Get<T>("window");
        // document
        public static IJSInProcessObjectReference GetDocument() => Get<IJSInProcessObjectReference>("document");
        public static T GetDocument<T>() where T : JSObject => Get<T>("document");
        // document.head
        public static IJSInProcessObjectReference GetDocumentHead() => Get<IJSInProcessObjectReference>("document.head");
        public static T GetDocumentHead<T>() where T : JSObject => Get<T>("document.head");
        // document.body
        public static IJSInProcessObjectReference GetDocumentBody() => Get<IJSInProcessObjectReference>("document.body");
        public static T GetDocumentBody<T>() where T : JSObject => Get<T>("document.body");
        public static void DocumentHeadAppendChild(IJSInProcessObjectReference element) => CallVoid("document.head.appendChild", element);
        public static void DocumentBodyAppendChild(IJSInProcessObjectReference element) => CallVoid("document.body.appendChild", element);
        // document.CreateElement
        public static IJSInProcessObjectReference DocumentCreateElement(string elementType) => Call<IJSInProcessObjectReference>("document.createElement", elementType);
        public static T DocumentCreateElement<T>(string elementType) where T : JSObject => Call<T>("document.createElement", elementType);

        public static bool JSEquals(object obj1, object obj2) => _JSInteropCall<bool>("__equals", obj1, obj2);

        //public static T CopyReference<T>(JSObject obj) where T : JSObject => ReturnMe<T>(obj);
        //public static IJSInProcessObjectReference CopyReference(IJSInProcessObjectReference obj) => ReturnMe<IJSInProcessObjectReference>(obj);
        //public static T MoveReference<T>(JSObject orig, bool sourceDisposeExceptRef = true) where T : JSObject
        //{
        //    var ret = (T)Activator.CreateInstance(typeof(T), orig.JSRef);
        //    if (sourceDisposeExceptRef) orig.DisposeExceptRef();
        //    return ret;
        //}
        public static T ReturnMe<T>(object obj) => _JSInteropCall<T>("_returnMe", obj);
        public static JSObject FromElementReference(ElementReference elementRef) => ReturnMe<JSObject>(elementRef);
        public static IJSInProcessObjectReference ToJSRef(ElementReference elementRef) => ReturnMe<IJSInProcessObjectReference>(elementRef);
        public static T FromElementReference<T>(ElementReference elementRef) where T : JSObject => (T)Activator.CreateInstance(typeof(T), ReturnMe<IJSInProcessObjectReference>(elementRef));
        public static IJSInProcessObjectReference NewApply(string className, object?[]? args = null) => _JSInteropCall<IJSInProcessObjectReference>("_returnNew", className, args);
        public static IJSInProcessObjectReference New(string className) => NewApply(className);
        public static IJSInProcessObjectReference New(string className, object arg0) => NewApply(className, new object[] { arg0 });
        public static IJSInProcessObjectReference New(string className, object arg0, object arg1) => NewApply(className, new object[] { arg0, arg1 });
        public static IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2) => NewApply(className, new object[] { arg0, arg1, arg2 });
        public static IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3) => NewApply(className, new object[] { arg0, arg1, arg2, arg3 });
        public static IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4) => NewApply(className, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public static IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5) => NewApply(className, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6) => NewApply(className, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7) => NewApply(className, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8) => NewApply(className, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static IJSInProcessObjectReference New(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8, object arg9) => NewApply(className, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        public static bool IsUndefined(JSObject obj, string identifier = "") => _JSInteropCall<string>("_typeof", obj, identifier) == "undefined";
        public static bool IsUndefined(string identifier) => _JSInteropCall<string>("_typeof", null, identifier) == "undefined";
        public static string TypeOf(JSObject obj, string identifier = "") => _JSInteropCall<string>("_typeof", obj, identifier);
        public static string TypeOf(string identifier) => _JSInteropCall<string>("_typeof", null, identifier);
        public static void Log(params object[] args) => CallApplyVoid("console.log", args);
        public static string GetConstructorName(string identifier) => JS.Get<string>($"{identifier}.constructor.name");

        static Dictionary<string, Type?> typeCache { get; } = new Dictionary<string, Type?>();
        /// <summary>
        /// For whatever reason Type.GetType was failing when trying to find a Type in the same assembly as this class... no idea why. Below code worked when it failed
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Type? GetType(string typeName)
        {
            Type? t = null;
            lock (typeCache)
            {
                if (!typeCache.TryGetValue(typeName, out t))
                {
                    foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        t = a.GetType(typeName);
                        if (t != null) break;
                    }
                    typeCache[typeName] = t;
                }
            }
            return t;
        }
    }
}
