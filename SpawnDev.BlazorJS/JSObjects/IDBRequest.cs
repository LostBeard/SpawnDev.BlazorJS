using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    // TODO verify working
    public class IDBRequest : EventTarget {
        public CallbackGroup callbackGroup { get; private set; } = new CallbackGroup();
        public IDBRequest(IJSInProcessObjectReference _ref) : base(_ref) { }

        public string ReadyState => JSRef.Get<string>("readyState");

        public T GetResult<T>() => JSRef.Get<T>("result");   // Function used for this proerpty to allow T return type

        public void OnError(Action<IJSInProcessObjectReference> handler) {
            On("onerror", handler, true);
        }
        public void OnSuccess(Action<IJSInProcessObjectReference> handler) {
            On("onsuccess", handler, true);
        }
        public void OnSuccess<T>(Action<T> resultHandler) {
            On("onsuccess", (IJSInProcessObjectReference arg0) => {
                using (var target = arg0.Get<IJSInProcessObjectReference>("target")) {
                    var result = target.Get<T>("result");
                    resultHandler.Invoke(result);
                }
                arg0.Dispose();
            }, true);
        }
        public void On(string eventName, Action<IJSInProcessObjectReference> handler, bool disposeAfterCalled = false) {
            JSRef.Set(eventName, Callback.Create((IJSInProcessObjectReference arg0) => {
                handler?.Invoke(arg0);
                arg0.Dispose();
                if (disposeAfterCalled) Dispose();
            }, callbackGroup));
        }

        protected override void LosingReference()
        {
            callbackGroup.Dispose();
        }

        public static Task<T> ToAsync<T>(IDBRequest request) {
            var t = new TaskCompletionSource<T>();
            request.OnError((arg0) => { t.SetException(new Exception("IDBRequest failed. Exception info TODO")); });
            request.OnSuccess<T>((result) => t.TrySetResult(result));
            return t.Task;
        }

        public static Task ToAsync(IDBRequest request) {
            var t = new TaskCompletionSource();
            request.OnError((arg0) => { t.SetException(new Exception("IDBRequest failed. Exception info TODO")); });
            request.OnSuccess((result) => t.TrySetResult());
            return t.Task;
        }
    }
}
