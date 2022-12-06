using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<FunctionHandle>))]
    public class FunctionHandle : JSObject
    {
        public FunctionHandle(IJSInProcessObjectReference _ref) : base(_ref) { }
        public FunctionHandle(string js) : base("Function", js) { }
        public T CallFn<T>() => _ref.Call<T>("applyFn", null, new object[] { });
        public T CallFn<T>(object arg0) => _ref.Call<T>("applyFn", null, new object[] { arg0 });
        public T CallFn<T>(object arg0, object arg1) => _ref.Call<T>("applyFn", null, new object[] { arg0, arg1 });
        public T CallFn<T>(object arg0, object arg1, object arg2) => _ref.Call<T>("applyFn", null, new object[] { arg0, arg1, arg2 });
        public T CallFn<T>(object arg0, object arg1, object arg2, object arg3) => _ref.Call<T>("applyFn", null, new object[] { arg0, arg1, arg2, arg3 });
        public T CallFn<T>(object arg0, object arg1, object arg2, object arg3, object arg4) => _ref.Call<T>("applyFn", null, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public T CallFn<T>(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5) => _ref.Call<T>("applyFn", null, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });

        public void CallFnVoid() => _ref.CallVoid("applyFn", null, new object[] { });
        public void CallFnVoid(object arg0) => _ref.CallVoid("applyFn", null, new object[] { arg0 });
        public void CallFnVoid(object arg0, object arg1) => _ref.CallVoid("applyFn", null, new object[] { arg0, arg1 });
        public void CallFnVoid(object arg0, object arg1, object arg2) => _ref.CallVoid("applyFn", null, new object[] { arg0, arg1, arg2 });
        public void CallFnVoid(object arg0, object arg1, object arg2, object arg3) => _ref.CallVoid("applyFn", null, new object[] { arg0, arg1, arg2, arg3 });
        public void CallFnVoid(object arg0, object arg1, object arg2, object arg3, object arg4) => _ref.CallVoid("applyFn", null, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public void CallFnVoid(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5) => _ref.CallVoid("applyFn", null, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });



        public ValueTask<T> CallFnAsync<T>() => _ref.CallAsync<T>("applyFn", null, new object[] { });
        public ValueTask<T> CallFnAsync<T>(object arg0) => _ref.CallAsync<T>("applyFn", null, new object[] { arg0 });
        public ValueTask<T> CallFnAsync<T>(object arg0, object arg1) => _ref.CallAsync<T>("applyFn", null, new object[] { arg0, arg1 });
        public ValueTask<T> CallFnAsync<T>(object arg0, object arg1, object arg2) => _ref.CallAsync<T>("applyFn", null, new object[] { arg0, arg1, arg2 });
        public ValueTask<T> CallFnAsync<T>(object arg0, object arg1, object arg2, object arg3) => _ref.CallAsync<T>("applyFn", null, new object[] { arg0, arg1, arg2, arg3 });
        public ValueTask<T> CallFnAsync<T>(object arg0, object arg1, object arg2, object arg3, object arg4) => _ref.CallAsync<T>("applyFn", null, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public ValueTask<T> CallFnAsync<T>(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5) => _ref.CallAsync<T>("applyFn", null, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });

    }
}