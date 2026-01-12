using Microsoft.JSInterop;
using SpawnDev.BlazorJS.Internal;

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

        /// <summary>
        /// Creates a new instance of the function object.
        /// </summary>
        /// <typeparam name="T">The type of the new instance.</typeparam>
        /// <param name="args">Arguments to pass to the constructor.</param>
        /// <returns>The new instance.</returns>
        public T NewApply<T>(object?[]? args = null) => BlazorJSInterop.ObjectNew<T>(JSRef!, args);

        /// <summary>
        /// Creates a new instance of the function object.
        /// </summary>
        /// <typeparam name="T">The type of the new instance.</typeparam>
        /// <returns>The new instance.</returns>
        public T New<T>() => NewApply<T>();
        /// <summary>
        /// Creates a new instance of the function object.
        /// </summary>
        public T New<T>(object arg0) => NewApply<T>(new object[] { arg0 });
        /// <summary>
        /// Creates a new instance of the function object.
        /// </summary>
        public T New<T>(object arg0, object arg1) => NewApply<T>(new object[] { arg0, arg1 });
        /// <summary>
        /// Creates a new instance of the function object.
        /// </summary>
        public T New<T>(object arg0, object arg1, object arg2) => NewApply<T>(new object[] { arg0, arg1, arg2 });
        /// <summary>
        /// Creates a new instance of the function object.
        /// </summary>
        public T New<T>(object arg0, object arg1, object arg2, object arg3) => NewApply<T>(new object[] { arg0, arg1, arg2, arg3 });
        /// <summary>
        /// Creates a new instance of the function object.
        /// </summary>
        public T New<T>(object arg0, object arg1, object arg2, object arg3, object arg4) => NewApply<T>(new object[] { arg0, arg1, arg2, arg3, arg4 });
        /// <summary>
        /// Creates a new instance of the function object.
        /// </summary>
        public T New<T>(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5) => NewApply<T>(new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        /// <summary>
        /// Creates a new instance of the function object.
        /// </summary>
        public T New<T>(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6) => NewApply<T>(new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        /// <summary>
        /// Creates a new instance of the function object.
        /// </summary>
        public T New<T>(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7) => NewApply<T>(new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        /// <summary>
        /// Creates a new instance of the function object.
        /// </summary>
        public T New<T>(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8) => NewApply<T>(new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        /// <summary>
        /// Creates a new instance of the function object.
        /// </summary>
        public T New<T>(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8, object arg9) => NewApply<T>(new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });


        /// <summary>
        /// Syntax: new Function (arg1, arg2, ...argN, functionBody)
        /// where arg1 - argN are the parameter names used in the function body
        /// and functionBody is the function body 
        /// </summary>
        /// <param name="args"></param>
        public Function(params string[] args) : base(JS.NewApply("Function", args)) { }

        /// <summary>
        /// Calls the function with a given this value and arguments provided as an array (or an array-like object).
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="thisObj">The value of this provided for the call to the function. Note that this may not be the actual value seen by the method: if the method is a function in non-strict mode code, null and undefined will be replaced with the global object, and primitive values will be boxed. This argument is required.</param>
        /// <param name="args">An array-like object, specifying the arguments with which func should be called, or null or undefined if no arguments should be provided to the function.</param>
        /// <returns>The result of calling the function with the specified this value and arguments.</returns>
        public T Apply<T>(object? thisObj = null, object?[]? args = null) => JSRef!.Call<T>("apply", thisObj, args);
        /// <summary>
        /// Calls the function with a given this value and arguments provided as an array (or an array-like object).
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="thisObj">The value of this provided for the call to the function.</param>
        /// <param name="args">An array-like object, specifying the arguments with which func should be called.</param>
        /// <returns>A Task that resolves to the result of calling the function.</returns>
        public Task<T> ApplyAsync<T>(object? thisObj = null, object?[]? args = null) => JSRef!.CallAsync<T>("apply", thisObj, args);
        /// <summary>
        /// Calls the function with a given this value and arguments provided as an array (or an array-like object).
        /// </summary>
        /// <param name="thisObj">The value of this provided for the call to the function.</param>
        /// <param name="args">An array-like object, specifying the arguments with which func should be called.</param>
        public void ApplyVoid(object? thisObj = null, object?[]? args = null) => JSRef!.CallVoid("apply", thisObj, args);

        /// <summary>
        /// Calls the function with a given this value and arguments provided individually.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="thisObj">The value of this provided for the call to the function.</param>
        /// <param name="args">Arguments for the function.</param>
        /// <returns>The result of calling the function.</returns>
        public T Call<T>(object? thisObj = null, params object?[] args) => JSRef!.Call<T>("apply", thisObj, args);
        /// <summary>
        /// Calls the function with a given this value and arguments provided individually.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="thisObj">The value of this provided for the call to the function.</param>
        /// <param name="args">Arguments for the function.</param>
        /// <returns>A Task that resolves to the result of calling the function.</returns>
        public Task<T> CallAsync<T>(object? thisObj = null, params object?[] args) => JSRef!.CallAsync<T>("apply", thisObj, args);
        /// <summary>
        /// Calls the function with a given this value and arguments provided individually.
        /// </summary>
        /// <param name="thisObj">The value of this provided for the call to the function.</param>
        /// <param name="args">Arguments for the function.</param>
        public void CallVoid(object? thisObj = null, params object?[] args) => JSRef!.CallVoid("apply", thisObj, args);

        /// <summary>
        /// Converts the Function to an Action.
        /// </summary>
        /// <returns>An Action that calls the function.</returns>
        public Action ToAction()
        {
            var ret = new Action(() => ApplyVoid());
            ret.FunctionSet(this);
            return ret;
        }
        /// <summary>
        /// Converts the Function to an Action.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <returns></returns>
        public Action<T0> ToAction<T0>()
        {
            var ret = new Action<T0>((arg0) => ApplyVoid(null, new object[] { arg0 }));
            ret.FunctionSet(this);
            return ret;
        }
        /// <summary>
        /// Converts the Function to an Action.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        public Action<T0, T1> ToAction<T0, T1>()
        {
            var ret = new Action<T0, T1>((arg0, arg1) => ApplyVoid(null, new object[] { arg0, arg1 }));
            ret.FunctionSet(this);
            return ret;
        }
        /// <summary>
        /// Converts the Function to an Action.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public Action<T0, T1, T2> ToAction<T0, T1, T2>()
        {
            var ret = new Action<T0, T1, T2>((arg0, arg1, arg2) => ApplyVoid(null, new object[] { arg0, arg1, arg2 }));
            ret.FunctionSet(this);
            return ret;
        }
        /// <summary>
        /// Converts the Function to an Action.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        public Action<T0, T1, T2, T3> ToAction<T0, T1, T2, T3>()
        {
            var ret = new Action<T0, T1, T2, T3>((arg0, arg1, arg2, arg3) => ApplyVoid(null, new object[] { arg0, arg1, arg2, arg3 }));
            ret.FunctionSet(this);
            return ret;
        }
        /// <summary>
        /// Converts the Function to an Action.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        public Action<T0, T1, T2, T3, T4> ToAction<T0, T1, T2, T3, T4>()
        {
            var ret = new Action<T0, T1, T2, T3, T4>((arg0, arg1, arg2, arg3, arg4) => ApplyVoid(null, new object[] { arg0, arg1, arg2, arg3, arg4 }));
            ret.FunctionSet(this);
            return ret;
        }
        /// <summary>
        /// Converts the Function to an Action.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        public Action<T0, T1, T2, T3, T4, T5> ToAction<T0, T1, T2, T3, T4, T5>()
        {
            var ret = new Action<T0, T1, T2, T3, T4, T5>((arg0, arg1, arg2, arg3, arg4, arg5) => ApplyVoid(null, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 }));
            ret.FunctionSet(this);
            return ret;
        }
        /// <summary>
        /// Converts the Function to an Action.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        public Action<T0, T1, T2, T3, T4, T5, T6> ToAction<T0, T1, T2, T3, T4, T5, T6>()
        {
            var ret = new Action<T0, T1, T2, T3, T4, T5, T6>((arg0, arg1, arg2, arg3, arg4, arg5, arg6) => ApplyVoid(null, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 }));
            ret.FunctionSet(this);
            return ret;
        }
        /// <summary>
        /// Converts the Function to a Func&lt;TResult&gt;.
        /// </summary>
        /// <typeparam name="TResult">The return type of the function.</typeparam>
        /// <returns>A Func&lt;TResult&gt; that calls the function.</returns>
        public Func<TResult> ToFunc<TResult>()
        {
            var ret = new Func<TResult>(() => Apply<TResult>());
            ret.FunctionSet(this);
            return ret;
        }
        /// <summary>
        /// Converts the Function to a Func&lt;TResult&gt;.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public Func<T0, TResult> ToFunc<T0, TResult>()
        {
            var ret = new Func<T0, TResult>((arg0) => Apply<TResult>(null, new object[] { arg0 }));
            ret.FunctionSet(this);
            return ret;
        }
        /// <summary>
        /// Converts the Function to a Func&lt;TResult&gt;.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public Func<T0, T1, TResult> ToFunc<T0, T1, TResult>()
        {
            var ret = new Func<T0, T1, TResult>((arg0, arg1) => Apply<TResult>(null, new object?[] { arg0, arg1 }));
            ret.FunctionSet(this);
            return ret;
        }
        /// <summary>
        /// Converts the Function to a Func&lt;TResult&gt;.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public Func<T0, T1, T2, TResult> ToFunc<T0, T1, T2, TResult>()
        {
            var ret = new Func<T0, T1, T2, TResult>((arg0, arg1, arg2) => Apply<TResult>(new object[] { arg0, arg1, arg2 }));
            ret.FunctionSet(this);
            return ret;
        }
        /// <summary>
        /// Converts the Function to a Func&lt;TResult&gt;.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public Func<T0, T1, T2, T3, TResult> ToFunc<T0, T1, T2, T3, TResult>()
        {
            var ret = new Func<T0, T1, T2, T3, TResult>((arg0, arg1, arg2, arg3) => Apply<TResult>(null, new object[] { arg0, arg1, arg2, arg3 }));
            ret.FunctionSet(this);
            return ret;
        }
        /// <summary>
        /// Converts the Function to a Func&lt;TResult&gt;.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public Func<T0, T1, T2, T3, T4, TResult> ToFunc<T0, T1, T2, T3, T4, TResult>()
        {
            var ret = new Func<T0, T1, T2, T3, T4, TResult>((arg0, arg1, arg2, arg3, arg4) => Apply<TResult>(null, new object[] { arg0, arg1, arg2, arg3, arg4 }));
            ret.FunctionSet(this);
            return ret;
        }
        /// <summary>
        /// Converts the Function to a Func&lt;TResult&gt;.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public Func<T0, T1, T2, T3, T4, T5, TResult> ToFunc<T0, T1, T2, T3, T4, T5, TResult>()
        {
            var ret = new Func<T0, T1, T2, T3, T4, T5, TResult>((arg0, arg1, arg2, arg3, arg4, arg5) => Apply<TResult>(null, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 }));
            ret.FunctionSet(this);
            return ret;
        }
        /// <summary>
        /// Converts the Function to a Func&lt;TResult&gt;.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public Func<T0, T1, T2, T3, T4, T5, T6, TResult> ToFunc<T0, T1, T2, T3, T4, T5, T6, TResult>()
        {
            var ret = new Func<T0, T1, T2, T3, T4, T5, T6, TResult>((arg0, arg1, arg2, arg3, arg4, arg5, arg6) => Apply<TResult>(null, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 }));
            ret.FunctionSet(this);
            return ret;
        }
    }
}