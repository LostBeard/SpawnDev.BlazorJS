using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Function object provides methods for functions. In JavaScript, every function is actually a Function object.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Function
    /// </summary>
    public class Function : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Function(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// The name of the function.
        /// </summary>
        public string? Name => JSRef!.Get<string?>("name");
        /// <summary>
        /// Specifies the number of arguments expected by the function.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");

        public T NewApply<T>(object?[]? args = null) => BlazorJSInterop.ObjectNew<T>(JSRef!, args);
        public T New<T>() => NewApply<T>();
        public T New<T>(object arg0) => NewApply<T>(new object[] { arg0 });
        public T New<T>(object arg0, object arg1) => NewApply<T>(new object[] { arg0, arg1 });
        public T New<T>(object arg0, object arg1, object arg2) => NewApply<T>(new object[] { arg0, arg1, arg2 });
        public T New<T>(object arg0, object arg1, object arg2, object arg3) => NewApply<T>(new object[] { arg0, arg1, arg2, arg3 });
        public T New<T>(object arg0, object arg1, object arg2, object arg3, object arg4) => NewApply<T>(new object[] { arg0, arg1, arg2, arg3, arg4 });
        public T New<T>(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5) => NewApply<T>(new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public T New<T>(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6) => NewApply<T>(new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public T New<T>(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7) => NewApply<T>(new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public T New<T>(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8) => NewApply<T>(new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public T New<T>(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8, object arg9) => NewApply<T>(new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });


        /// <summary>
        /// Syntax: new Function (arg1, arg2, ...argN, functionBody)
        /// where arg1 - argN are the parameter names used in the function body
        /// and functionBody is the function body 
        /// </summary>
        /// <param name="args"></param>
        public Function(params string[] args) : base(JS.NewApply("Function", args)) { }

        public T Apply<T>(object? thisObj = null, object?[]? args = null) => JSRef!.Call<T>("apply", thisObj, args);
        public Task<T> ApplyAsync<T>(object? thisObj = null, object?[]? args = null) => JSRef!.CallAsync<T>("apply", thisObj, args);
        public void ApplyVoid(object? thisObj = null, object?[]? args = null) => JSRef!.CallVoid("apply", thisObj, args);

        public T Call<T>(object? thisObj = null, params object?[] args) => JSRef!.Call<T>("apply", thisObj, args);
        public Task<T> CallAsync<T>(object? thisObj = null, params object?[] args) => JSRef!.CallAsync<T>("apply", thisObj, args);
        public void CallVoid(object? thisObj = null, params object?[] args) => JSRef!.CallVoid("apply", thisObj, args);

        public Action ToAction()
        {
            var ret = new Action(() => ApplyVoid());
            ret.FunctionSet(this);
            return ret;
        }
        public Action<T0> ToAction<T0>()
        {
            var ret = new Action<T0>((arg0) => ApplyVoid(null, new object[] { arg0 }));
            ret.FunctionSet(this);
            return ret;
        }
        public Action<T0, T1> ToAction<T0, T1>()
        {
            var ret = new Action<T0, T1>((arg0, arg1) => ApplyVoid(null, new object[] { arg0, arg1 }));
            ret.FunctionSet(this);
            return ret;
        }
        public Action<T0, T1, T2> ToAction<T0, T1, T2>()
        {
            var ret = new Action<T0, T1, T2>((arg0, arg1, arg2) => ApplyVoid(null, new object[] { arg0, arg1, arg2 }));
            ret.FunctionSet(this);
            return ret;
        }
        public Action<T0, T1, T2, T3> ToAction<T0, T1, T2, T3>()
        {
            var ret = new Action<T0, T1, T2, T3>((arg0, arg1, arg2, arg3) => ApplyVoid(null, new object[] { arg0, arg1, arg2, arg3 }));
            ret.FunctionSet(this);
            return ret;
        }
        public Action<T0, T1, T2, T3, T4> ToAction<T0, T1, T2, T3, T4>()
        {
            var ret = new Action<T0, T1, T2, T3, T4>((arg0, arg1, arg2, arg3, arg4) => ApplyVoid(null, new object[] { arg0, arg1, arg2, arg3, arg4 }));
            ret.FunctionSet(this);
            return ret;
        }
        public Action<T0, T1, T2, T3, T4, T5> ToAction<T0, T1, T2, T3, T4, T5>()
        {
            var ret = new Action<T0, T1, T2, T3, T4, T5>((arg0, arg1, arg2, arg3, arg4, arg5) => ApplyVoid(null, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 }));
            ret.FunctionSet(this);
            return ret;
        }
        public Action<T0, T1, T2, T3, T4, T5, T6> ToAction<T0, T1, T2, T3, T4, T5, T6>()
        {
            var ret = new Action<T0, T1, T2, T3, T4, T5, T6>((arg0, arg1, arg2, arg3, arg4, arg5, arg6) => ApplyVoid(null, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 }));
            ret.FunctionSet(this);
            return ret;
        }
        public Func<TResult> ToFunc<TResult>()
        {
            var ret = new Func<TResult>(() => Apply<TResult>());
            ret.FunctionSet(this);
            return ret;
        }
        public Func<T0, TResult> ToFunc<T0, TResult>()
        {
            var ret = new Func<T0, TResult>((arg0) => Apply<TResult>(null, new object[] { arg0 }));
            ret.FunctionSet(this);
            return ret;
        }
        public Func<T0, T1, TResult> ToFunc<T0, T1, TResult>()
        {
            var ret = new Func<T0, T1, TResult>((arg0, arg1) => Apply<TResult>(null, new object[] { arg0, arg1 }));
            ret.FunctionSet(this);
            return ret;
        }
        public Func<T0, T1, T2, TResult> ToFunc<T0, T1, T2, TResult>()
        {
            var ret = new Func<T0, T1, T2, TResult>((arg0, arg1, arg2) => Apply<TResult>(new object[] { arg0, arg1, arg2 }));
            ret.FunctionSet(this);
            return ret;
        }
        public Func<T0, T1, T2, T3, TResult> ToFunc<T0, T1, T2, T3, TResult>()
        {
            var ret = new Func<T0, T1, T2, T3, TResult>((arg0, arg1, arg2, arg3) => Apply<TResult>(null, new object[] { arg0, arg1, arg2, arg3 }));
            ret.FunctionSet(this);
            return ret;
        }
        public Func<T0, T1, T2, T3, T4, TResult> ToFunc<T0, T1, T2, T3, T4, TResult>()
        {
            var ret = new Func<T0, T1, T2, T3, T4, TResult>((arg0, arg1, arg2, arg3, arg4) => Apply<TResult>(null, new object[] { arg0, arg1, arg2, arg3, arg4 }));
            ret.FunctionSet(this);
            return ret;
        }
        public Func<T0, T1, T2, T3, T4, T5, TResult> ToFunc<T0, T1, T2, T3, T4, T5, TResult>()
        {
            var ret = new Func<T0, T1, T2, T3, T4, T5, TResult>((arg0, arg1, arg2, arg3, arg4, arg5) => Apply<TResult>(null, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 }));
            ret.FunctionSet(this);
            return ret;
        }
        public Func<T0, T1, T2, T3, T4, T5, T6, TResult> ToFunc<T0, T1, T2, T3, T4, T5, T6, TResult>()
        {
            var ret = new Func<T0, T1, T2, T3, T4, T5, T6, TResult>((arg0, arg1, arg2, arg3, arg4, arg5, arg6) => Apply<TResult>(null, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 }));
            ret.FunctionSet(this);
            return ret;
        }
    }
}