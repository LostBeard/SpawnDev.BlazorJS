using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS
{
    // Facilitates the JSInterop javascript code
    public static partial class JS
    {
        public static IJSInProcessRuntime? Runtime => _js;
        private static IJSInProcessRuntime? _js { get; set; } = null;
        public static async Task InitAsync(this IJSInProcessRuntime js)
        {
            if (_js != null) return;
            _js = js;
            using var _module = await js.InvokeAsync<IJSInProcessObjectReference>("import", "./_content/SpawnDev.BlazorJS/blazor-interop.js");
            _module.InvokeVoid("init");
        }
        private static void AssertInit()
        {
            if (_js == null) throw new Exception("JS must be initialized before use via SpawnDev.BlazorJS.JS.InitAsync(IJSInProcessRuntime) usually in Program.cs");
        }
        public static void DisposeCallback(string callbackerID) => _JSInteropCallVoid("DisposeCallbacker", callbackerID);
        
        public static AsyncIterator? GetAsyncIterator(IJSInProcessObjectReference targetObject) => Get<AsyncIterator?>(targetObject, "Symbol.asyncIterator");

        public static Task<bool> LoadScript(string src, string ifThisGlobalVarIsUndefined = null)
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
        public static IJSInProcessObjectReference GetDocument()
        {
            using var window = GetWindow();
            return window._ref.Get<IJSInProcessObjectReference>("document");
        }
        public static IJSInProcessObjectReference GetDocumentHead()
        {
            using var document = GetDocument();
            return document.Get<IJSInProcessObjectReference>("head");
        }
        public static IJSInProcessObjectReference GetDocumentBody()
        {
            using var document = GetDocument();
            return document.Get<IJSInProcessObjectReference>("body");
        }
        public static void DocumentHeadAppendChild(IJSInProcessObjectReference element)
        {
            using var head = GetDocumentHead();
            head.CallVoid("appendChild", element);
        }
        public static void DocumentBodyAppendChild(IJSInProcessObjectReference element)
        {
            using var body = GetDocumentBody();
            body.CallVoid("appendChild", element);
        }
        public static IJSInProcessObjectReference DocumentCreateElement(string elementType)
        {
            using var document = GetDocument();
            return document.Call<IJSInProcessObjectReference>("createElement", elementType);
        }
        public static T DocumentCreateElement<T>(string elementType)
        {
            using var document = GetDocument();
            return document.Call<T>("createElement", elementType);
        }
        //public static bool JSEquals(JSObject obj1, JSObject obj2) => _JSInteropCall<bool>("__equals", obj1, obj2);
        //public static bool JSEquals(IJSInProcessObjectReference obj1, IJSInProcessObjectReference obj2) => _JSInteropCall<bool>("__equals", obj1, obj2);
        //public static bool JSEquals(IJSInProcessObjectReference obj1, JSObject obj2) => _JSInteropCall<bool>("__equals", obj1, obj2);
        //public static bool JSEquals(JSObject obj1, IJSInProcessObjectReference obj2) => _JSInteropCall<bool>("__equals", obj1, obj2);
        public static bool JSEquals(object obj1, object obj2) => _JSInteropCall<bool>("__equals", obj1, obj2);

        public static void DisposeIt(object obj)
        {
            if (obj is IDisposable disposable) disposable.Dispose();
        }
        // below is removed becuase ReturnMe is the same thing
        //public static T DeserializeTo<T>(JSObject obj)
        //{
        //    return _js.Invoke<T>("JSInterop._returnMe", obj._ref);
        //}
        public static T CopyReference<T>(JSObject obj) where T : JSObject
        {
            var tmp = ReturnMe<IJSInProcessObjectReference>(obj._ref);
            return (T)Activator.CreateInstance(typeof(T), tmp);
        }
        public static IJSInProcessObjectReference CopyReference(IJSInProcessObjectReference obj) => ReturnMe<IJSInProcessObjectReference>(obj);
        public static T MoveReference<T>(JSObject orig, bool sourceDisposeExceptRef = true) where T : JSObject
        {
            var ret = (T)Activator.CreateInstance(typeof(T), orig._ref);
            if (sourceDisposeExceptRef) orig.DisposeExceptRef();
            return ret;
        }
        public static T ReturnMe<T>(object obj) => _JSInteropCall<T>("_returnMe", obj);
        public static JSObject FromElementReference(ElementReference elementRef) => ReturnMe<JSObject>(elementRef);
        public static T FromElementReference<T>(ElementReference elementRef) where T : JSObject => (T)Activator.CreateInstance(typeof(T), ReturnMe<IJSInProcessObjectReference>(elementRef));
        public static IJSInProcessObjectReference CreateNewArgs(string className, object[]? args = null) => _JSInteropCall<IJSInProcessObjectReference>("_returnNew", className, args);
        public static IJSInProcessObjectReference CreateNew(string className) => CreateNewArgs(className);
        public static IJSInProcessObjectReference CreateNew(string className, object arg0) => CreateNewArgs(className, new object[] { arg0 });
        public static IJSInProcessObjectReference CreateNew(string className, object arg0, object arg1) => CreateNewArgs(className, new object[] { arg0, arg1 });
        public static IJSInProcessObjectReference CreateNew(string className, object arg0, object arg1, object arg2) => CreateNewArgs(className, new object[] { arg0, arg1, arg2 });
        public static IJSInProcessObjectReference CreateNew(string className, object arg0, object arg1, object arg2, object arg3) => CreateNewArgs(className, new object[] { arg0, arg1, arg2, arg3 });
        public static IJSInProcessObjectReference CreateNew(string className, object arg0, object arg1, object arg2, object arg3, object arg4) => CreateNewArgs(className, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public static IJSInProcessObjectReference CreateNew(string className, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5) => CreateNewArgs(className, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static bool IsUndefined(JSObject obj, string identifier = "") => _JSInteropCall<string>("_typeof", obj, identifier) == "undefined";
        public static bool IsUndefined(string identifier = "") => _JSInteropCall<string>("_typeof", null, identifier) == "undefined";
        public static string TypeOf(JSObject obj, string identifier = "") => _JSInteropCall<string>("_typeof", obj, identifier);
        public static string TypeOf(string identifier = "") => _JSInteropCall<string>("_typeof", null, identifier);
        public static Window GetWindow() => Get<Window>("window");
    }
}
