using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects {
    
    public class Function : JSObject {
        public Function(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Syntax: new Function (arg1, arg2, ...argN, functionBody)
        /// where arg1 - argN are the parameter names used in the function body
        /// and functionBody is the function body 
        /// </summary>
        /// <param name="args"></param>
        public Function(params string[] args) : base(JS.NewApply("Function", args)) { }



        public T Apply<T>(object? thisObj = null, object?[]? args = null) => JSRef.Call<T>("apply", thisObj, args);
        public Task<T> ApplyAsync<T>(object? thisObj = null, object?[]? args = null) => JSRef.CallAsync<T>("apply", thisObj, args);
        public void ApplyVoid(object? thisObj = null, object?[]? args = null) => JSRef.CallVoid("apply", thisObj, args);

        public T Call<T>(object? thisObj = null, params object?[] args) => JSRef.Call<T>("apply", thisObj, args);
        public Task<T> CallAsync<T>(object? thisObj = null, params object?[] args) => JSRef.CallAsync<T>("apply", thisObj, args);
        public void CallVoid(object? thisObj = null, params object?[] args) => JSRef.CallVoid("apply", thisObj, args);



        //public T Apply<T>(object? thisObj = null, object?[]? args = null) => JSRef.Call<T>("applyFn", thisObj, args);
        //public Task<T> ApplyAsync<T>(object? thisObj = null, object?[]? args = null) => JSRef.CallAsync<T>("applyFn", thisObj, args);
        //public void ApplyVoid(object? thisObj = null, object?[]? args = null) => JSRef.CallVoid("applyFn", thisObj, args);

        //public T Call<T>(object? thisObj = null, params object?[] args) => JSRef.Call<T>("applyFn", thisObj, args);
        //public Task<T> CallAsync<T>(object? thisObj = null, params object?[] args) => JSRef.CallAsync<T>("applyFn", thisObj, args);
        //public void CallVoid(object? thisObj = null, params object?[] args) => JSRef.CallVoid("applyFn", thisObj, args);

        public Action ToAction() {
            var ret = new Action(() => CallVoid());
            ret.FunctionSet(this);
            return ret;
        }
        public Action<T0> ToAction<T0>() {
            var ret = new Action<T0>((arg0) => CallVoid(arg0));
            ret.FunctionSet(this);
            return ret;
        }

        public Action<T0, T1> ToAction<T0, T1>() {
            var ret = new Action<T0, T1>((arg0, arg1) => CallVoid(arg0, arg1));
            ret.FunctionSet(this);
            return ret;
        }

        public Action<T0, T1, T2> ToAction<T0, T1, T2>() {
            var ret = new Action<T0, T1, T2>((arg0, arg1, arg2) => CallVoid(arg0, arg1, arg2));
            ret.FunctionSet(this);
            return ret;
        }
        public Action<T0, T1, T2, T3> ToAction<T0, T1, T2, T3>() {
            var ret = new Action<T0, T1, T2, T3>((arg0, arg1, arg2, arg3) => CallVoid(arg0, arg1, arg2, arg3));
            ret.FunctionSet(this);
            return ret;
        }

        public Func<TResult> ToFunc<TResult>() {
            var ret = new Func<TResult>(() => Call<TResult>());
            ret.FunctionSet(this);
            return ret;
        }
        public Func<T0, TResult> ToFunc<T0, TResult>() {
            var ret = new Func<T0, TResult>((arg0) => Call<TResult>(arg0));
            ret.FunctionSet(this);
            return ret;
        }
        public Func<T0, T1, TResult> ToFunc<T0, T1, TResult>() {
            var ret = new Func<T0, T1, TResult>((arg0, arg1) => Call<TResult>(arg0, arg1));
            ret.FunctionSet(this);
            return ret;
        }
        public Func<T0, T1, T2, TResult> ToFunc<T0, T1, T2, TResult>() {
            var ret = new Func<T0, T1, T2, TResult>((arg0, arg1, arg2) => Call<TResult>(arg0, arg1, arg2));
            ret.FunctionSet(this);
            return ret;
        }
        public Func<T0, T1, T2, T3, TResult> ToFunc<T0, T1, T2, T3, TResult>() {
            var ret = new Func<T0, T1, T2, T3, TResult>((arg0, arg1, arg2, arg3) => Call<TResult>(arg0, arg1, arg2, arg3));
            ret.FunctionSet(this);
            return ret;
        }
    }

}