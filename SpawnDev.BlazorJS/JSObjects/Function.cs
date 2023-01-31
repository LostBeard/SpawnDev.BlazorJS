using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Function>))]
    public class Function : JSObject
    {
        public Function(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Syntax: new Function (arg1, arg2, ...argN, functionBody)
        /// where arg1 - argN are the parameter names used in the function body
        /// and functionBody is the function body 
        /// </summary>
        /// <param name="args"></param>
        public Function(params string[] args) : base(JS.NewApply("Function", args)) { }

        public T Apply<T>(object? thisObj = null, object?[]? args = null) => JSRef.Call<T>("applyFn", thisObj, args);
        public ValueTask<T> ApplyAsync<T>(object? thisObj = null, object?[]? args = null) => JSRef.CallAsync<T>("applyFn", thisObj, args);
        public void ApplyVoid(object? thisObj = null, object?[]? args = null) => JSRef.CallVoid("applyFn", thisObj, args);

        public T Call<T>(object? thisObj = null, params object?[] args) => JSRef.Call<T>("applyFn", thisObj, args);
        public ValueTask<T> CallAsync<T>(object? thisObj = null, params object?[] args) => JSRef.CallAsync<T>("applyFn", thisObj, args);
        public void CallVoid<T>(object? thisObj = null, params object?[] args) => JSRef.CallVoid("applyFn", thisObj, args);
    }
}