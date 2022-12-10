using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Function>))]
    public class Function : JSObject
    {
        public Function(IJSInProcessObjectReference _ref) : base(_ref) { }
        // syntax
        // new Function ([arg1, arg2, ...argN], functionBody)
        public Function(params string[] args) : base(JS.CreateNewArgs("Function", args)) { }

        public T Apply<T>(object? thisObj, object[] args) => JSRef.Call<T>("applyFn", thisObj, args);
        public ValueTask<T> ApplyAsync<T>(object? thisObj, object[] args) => JSRef.CallAsync<T>("applyFn", thisObj, args);
        public void ApplyVoid<T>(object? thisObj, object[] args) => JSRef.CallVoid("applyFn", thisObj, args);

        public T Call<T>(object? thisObj, params object[] args) => JSRef.Call<T>("applyFn", thisObj, args);
        public ValueTask<T> CallAsync<T>(object? thisObj, params object[] args) => JSRef.CallAsync<T>("applyFn", thisObj, args);
        public void CallVoid<T>(object? thisObj, params object[] args) => JSRef.CallVoid("applyFn", thisObj, args);
    }
}