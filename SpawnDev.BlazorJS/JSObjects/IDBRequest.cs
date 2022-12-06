using Microsoft.JSInterop;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    // TODO verify workign after itnerop changes
    // check proepr dispoal of jsobjcets
    [JsonConverter(typeof(JSObjectConverter<IDBRequest>))]
    public class IDBRequest : EventTarget
    {
        public CallbackGroup callbackGroup { get; private set; } = new CallbackGroup();
        public IDBRequest(IJSInProcessObjectReference _ref) : base(_ref) { }

        public string ReadyState => _ref.Get<string>("readyState");

        public T GetResult<T>() => _ref.Get<T>("result");   // Function used for this proerpty to allow T return type

        public void OnError(Action<JSObject> handler)
        {
            On("onerror", handler, true);
        }
        public void OnSuccess(Action<JSObject> handler)
        {
            On("onsuccess", handler, true);
        }
        public void OnSuccess<T>(Action<T> resultHandler)
        {
            On("onsuccess", (JSObject arg0) => {
                using (var target = arg0._ref.Get<JSObject>("target"))
                {
                    var result = target._ref.Get<T>("result");
                    resultHandler.Invoke(result);
                }
                arg0.Dispose();
            }, true);
        }
        public void On(string eventName, Action<JSObject> handler, bool disposeAfterCalled = false)
        {
            _ref.Set(eventName, Callback.Create((JSObject arg0) =>
            {
                handler?.Invoke(arg0);
                arg0.Dispose();
                if (disposeAfterCalled) Dispose();
            }, callbackGroup));
        }

        public override void Dispose()
        {
            if (IsWrapperDisposed) return;
            callbackGroup.Dispose();
            base.Dispose();
        }

        public static Task<T> ToAsync<T>(IDBRequest request)
        {
            var t = new TaskCompletionSource<T>();
            request.OnError((arg0) => { t.SetException(new Exception("IDBRequest failed. Exception info TODO")); });
            request.OnSuccess<T>((result) => t.TrySetResult(result));
            return t.Task;
        }

        public static Task ToAsync(IDBRequest request)
        {
            var t = new TaskCompletionSource();
            request.OnError((arg0) => { t.SetException(new Exception("IDBRequest failed. Exception info TODO")); });
            request.OnSuccess((result) => t.TrySetResult());
            return t.Task;
        }
    }
}
