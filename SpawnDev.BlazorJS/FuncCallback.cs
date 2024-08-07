﻿using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class FuncCallback<TResult> : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator FuncCallback<TResult>?(Func<TResult>? callback) => callback == null ? null : callback.CallbackGet(true);
        Func<TResult> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public FuncCallback(Func<TResult> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public object? Invoke()
        {
            if (once) Dispose();
            var ret = __callback();
            return ret is Task task ? new Promise(task) : ret;
        }
    }
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class FuncCallback<T1, TResult> : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator FuncCallback<T1, TResult>?(Func<T1, TResult>? callback) => callback == null ? null : callback.CallbackGet(true);
        Func<T1, TResult> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public FuncCallback(Func<T1, TResult> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public object? Invoke(T1 arg0)
        {
            if (once) Dispose();
            var ret = __callback(arg0);
            return ret is Task task ? new Promise(task) : ret;
        }
    }
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class FuncCallback<T1, T2, TResult> : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator FuncCallback<T1, T2, TResult>?(Func<T1, T2, TResult>? callback) => callback == null ? null : callback.CallbackGet(true);
        Func<T1, T2, TResult> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public FuncCallback(Func<T1, T2, TResult> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public object? Invoke(T1 arg0, T2 arg1)
        {
            if (once) Dispose();
            var ret = __callback(arg0, arg1);
            return ret is Task task ? new Promise(task) : ret;
        }
    }
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class FuncCallback<T1, T2, T3, TResult> : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator FuncCallback<T1, T2, T3, TResult>?(Func<T1, T2, T3, TResult>? callback) => callback == null ? null : callback.CallbackGet(true);
        Func<T1, T2, T3, TResult> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public FuncCallback(Func<T1, T2, T3, TResult> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public object? Invoke(T1 arg0, T2 arg1, T3 arg2)
        {
            if (once) Dispose();
            var ret = __callback(arg0, arg1, arg2);
            return ret is Task task ? new Promise(task) : ret;
        }
    }
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class FuncCallback<T1, T2, T3, T4, TResult> : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator FuncCallback<T1, T2, T3, T4, TResult>?(Func<T1, T2, T3, T4, TResult>? callback) => callback == null ? null : callback.CallbackGet(true);
        Func<T1, T2, T3, T4, TResult> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public FuncCallback(Func<T1, T2, T3, T4, TResult> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public object? Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3)
        {
            if (once) Dispose();
            var ret = __callback(arg0, arg1, arg2, arg3);
            return ret is Task task ? new Promise(task) : ret;
        }
    }
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class FuncCallback<T1, T2, T3, T4, T5, TResult> : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator FuncCallback<T1, T2, T3, T4, T5, TResult>?(Func<T1, T2, T3, T4, T5, TResult>? callback) => callback == null ? null : callback.CallbackGet(true);
        Func<T1, T2, T3, T4, T5, TResult> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public FuncCallback(Func<T1, T2, T3, T4, T5, TResult> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public object? Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4)
        {
            if (once) Dispose();
            var ret = __callback(arg0, arg1, arg2, arg3, arg4);
            return ret is Task task ? new Promise(task) : ret;
        }
    }
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class FuncCallback<T1, T2, T3, T4, T5, T6, TResult> : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator FuncCallback<T1, T2, T3, T4, T5, T6, TResult>?(Func<T1, T2, T3, T4, T5, T6, TResult>? callback) => callback == null ? null : callback.CallbackGet(true);
        Func<T1, T2, T3, T4, T5, T6, TResult> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public FuncCallback(Func<T1, T2, T3, T4, T5, T6, TResult> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public object? Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5)
        {
            if (once) Dispose();
            var ret = __callback(arg0, arg1, arg2, arg3, arg4, arg5);
            return ret is Task task ? new Promise(task) : ret;
        }
    }
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class FuncCallback<T1, T2, T3, T4, T5, T6, T7, TResult> : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator FuncCallback<T1, T2, T3, T4, T5, T6, T7, TResult>?(Func<T1, T2, T3, T4, T5, T6, T7, TResult>? callback) => callback == null ? null : callback.CallbackGet(true);
        Func<T1, T2, T3, T4, T5, T6, T7, TResult> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public FuncCallback(Func<T1, T2, T3, T4, T5, T6, T7, TResult> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public object? Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6)
        {
            if (once) Dispose();
            var ret = __callback(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            return ret is Task task ? new Promise(task) : ret;
        }
    }
}
