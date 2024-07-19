//using Microsoft.JSInterop;
//using SpawnDev.BlazorJS.JSObjects;

//namespace SpawnDev.BlazorJS
//{
//    /// <summary>
//    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
//    /// </summary>
//    public class AsyncFuncCallback<TResult> : Callback
//    {
//        /// <summary>
//        /// Implicitly converts a .Net method into a Callback
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        public static implicit operator AsyncFuncCallback<TResult>?(Func<Task<TResult>>? callback) => callback == null ? null : callback.CallbackGet(true);
//        Func<Task<TResult>> __callback;
//        /// <summary>
//        /// Creates a new instance
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        /// <param name="once">If true, the Callback will be disposed after the first call</param>
//        public AsyncFuncCallback(Func<Task<TResult>> callback, bool once = false) : base(once)
//        {
//            __callback = callback;
//        }
//        /// <summary>
//        /// Javascript callable method
//        /// </summary>
//        [JSInvokable]
//        public Promise<TResult> Invoke()
//        {
//            if (once) Dispose();
//            return new Promise<TResult>(__callback());
//        }
//    }
//    /// <summary>
//    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
//    /// </summary>
//    public class AsyncFuncCallback<T1, TResult> : Callback
//    {
//        /// <summary>
//        /// Implicitly converts a .Net method into a Callback
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        public static implicit operator AsyncFuncCallback<T1, TResult>?(Func<T1, Task<TResult>>? callback) => callback == null ? null : callback.CallbackGet(true);
//        Func<T1, Task<TResult>> __callback;
//        /// <summary>
//        /// Creates a new instance
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        /// <param name="once">If true, the Callback will be disposed after the first call</param>
//        public AsyncFuncCallback(Func<T1, Task<TResult>> callback, bool once = false) : base(once)
//        {
//            __callback = callback;
//        }
//        /// <summary>
//        /// Javascript callable method
//        /// </summary>
//        [JSInvokable]
//        public Promise<TResult> Invoke(T1 arg0)
//        {
//            if (once) Dispose();
//            return new Promise<TResult>(__callback(arg0));
//        }
//    }
//    /// <summary>
//    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
//    /// </summary>
//    public class AsyncFuncCallback<T1, T2, TResult> : Callback
//    {
//        /// <summary>
//        /// Implicitly converts a .Net method into a Callback
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        public static implicit operator AsyncFuncCallback<T1, T2, TResult>?(Func<T1, T2, Task<TResult>>? callback) => callback == null ? null : callback.CallbackGet(true);
//        Func<T1, T2, Task<TResult>> __callback;
//        /// <summary>
//        /// Creates a new instance
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        /// <param name="once">If true, the Callback will be disposed after the first call</param>
//        public AsyncFuncCallback(Func<T1, T2, Task<TResult>> callback, bool once = false) : base(once)
//        {
//            __callback = callback;
//        }
//        /// <summary>
//        /// Javascript callable method
//        /// </summary>
//        [JSInvokable]
//        public Promise<TResult> Invoke(T1 arg0, T2 arg1)
//        {
//            if (once) Dispose();
//            return new Promise<TResult>(__callback(arg0, arg1));
//        }
//    }
//    /// <summary>
//    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
//    /// </summary>
//    public class AsyncFuncCallback<T1, T2, T3, TResult> : Callback
//    {
//        /// <summary>
//        /// Implicitly converts a .Net method into a Callback
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        public static implicit operator AsyncFuncCallback<T1, T2, T3, TResult>?(Func<T1, T2, T3, Task<TResult>>? callback) => callback == null ? null : callback.CallbackGet(true);
//        Func<T1, T2, T3, Task<TResult>> __callback;
//        /// <summary>
//        /// Creates a new instance
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        /// <param name="once">If true, the Callback will be disposed after the first call</param>
//        public AsyncFuncCallback(Func<T1, T2, T3, Task<TResult>> callback, bool once = false) : base(once)
//        {
//            __callback = callback;
//        }
//        /// <summary>
//        /// Javascript callable method
//        /// </summary>
//        [JSInvokable]
//        public Promise<TResult> Invoke(T1 arg0, T2 arg1, T3 arg2)
//        {
//            if (once) Dispose();
//            return new Promise<TResult>(__callback(arg0, arg1, arg2));
//        }
//    }
//    /// <summary>
//    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
//    /// </summary>
//    public class AsyncFuncCallback<T1, T2, T3, T4, TResult> : Callback
//    {
//        /// <summary>
//        /// Implicitly converts a .Net method into a Callback
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        public static implicit operator AsyncFuncCallback<T1, T2, T3, T4, TResult>?(Func<T1, T2, T3, T4, Task<TResult>>? callback) => callback == null ? null : callback.CallbackGet(true);
//        Func<T1, T2, T3, T4, Task<TResult>> __callback;
//        /// <summary>
//        /// Creates a new instance
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        /// <param name="once">If true, the Callback will be disposed after the first call</param>
//        public AsyncFuncCallback(Func<T1, T2, T3, T4, Task<TResult>> callback, bool once = false) : base(once)
//        {
//            __callback = callback;
//        }
//        /// <summary>
//        /// Javascript callable method
//        /// </summary>
//        [JSInvokable]
//        public Promise<TResult> Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3)
//        {
//            if (once) Dispose();
//            return new Promise<TResult>(__callback(arg0, arg1, arg2, arg3));
//        }
//    }
//    /// <summary>
//    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
//    /// </summary>
//    public class AsyncFuncCallback<T1, T2, T3, T4, T5, TResult> : Callback
//    {
//        /// <summary>
//        /// Implicitly converts a .Net method into a Callback
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        public static implicit operator AsyncFuncCallback<T1, T2, T3, T4, T5, TResult>?(Func<T1, T2, T3, T4, T5, Task<TResult>>? callback) => callback == null ? null : callback.CallbackGet(true);
//        Func<T1, T2, T3, T4, T5, Task<TResult>> __callback;
//        /// <summary>
//        /// Creates a new instance
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        /// <param name="once">If true, the Callback will be disposed after the first call</param>
//        public AsyncFuncCallback(Func<T1, T2, T3, T4, T5, Task<TResult>> callback, bool once = false) : base(once)
//        {
//            __callback = callback;
//        }
//        /// <summary>
//        /// Javascript callable method
//        /// </summary>
//        [JSInvokable]
//        public Promise<TResult> Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4)
//        {
//            if (once) Dispose();
//            return new Promise<TResult>(__callback(arg0, arg1, arg2, arg3, arg4));
//        }
//    }
//    /// <summary>
//    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
//    /// </summary>
//    public class AsyncFuncCallback<T1, T2, T3, T4, T5, T6, TResult> : Callback
//    {
//        /// <summary>
//        /// Implicitly converts a .Net method into a Callback
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        public static implicit operator AsyncFuncCallback<T1, T2, T3, T4, T5, T6, TResult>?(Func<T1, T2, T3, T4, T5, T6, Task<TResult>>? callback) => callback == null ? null : callback.CallbackGet(true);
//        Func<T1, T2, T3, T4, T5, T6, Task<TResult>> __callback;
//        /// <summary>
//        /// Creates a new instance
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        /// <param name="once">If true, the Callback will be disposed after the first call</param>
//        public AsyncFuncCallback(Func<T1, T2, T3, T4, T5, T6, Task<TResult>> callback, bool once = false) : base(once)
//        {
//            __callback = callback;
//        }
//        /// <summary>
//        /// Javascript callable method
//        /// </summary>
//        [JSInvokable]
//        public Promise<TResult> Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5)
//        {
//            if (once) Dispose();
//            return new Promise<TResult>(__callback(arg0, arg1, arg2, arg3, arg4, arg5));
//        }
//    }
//    /// <summary>
//    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
//    /// </summary>
//    public class AsyncFuncCallback<T1, T2, T3, T4, T5, T6, T7, TResult> : Callback
//    {
//        /// <summary>
//        /// Implicitly converts a .Net method into a Callback
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        public static implicit operator AsyncFuncCallback<T1, T2, T3, T4, T5, T6, T7, TResult>?(Func<T1, T2, T3, T4, T5, T6, T7, Task<TResult>>? callback) => callback == null ? null : callback.CallbackGet(true);
//        Func<T1, T2, T3, T4, T5, T6, T7, Task<TResult>> __callback;
//        /// <summary>
//        /// Creates a new instance
//        /// </summary>
//        /// <param name="callback">.Net target method</param>
//        /// <param name="once">If true, the Callback will be disposed after the first call</param>
//        public AsyncFuncCallback(Func<T1, T2, T3, T4, T5, T6, T7, Task<TResult>> callback, bool once = false) : base(once)
//        {
//            __callback = callback;
//        }
//        /// <summary>
//        /// Javascript callable method
//        /// </summary>
//        [JSInvokable]
//        public Promise<TResult> Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6)
//        {
//            if (once) Dispose();
//            return new Promise<TResult>(__callback(arg0, arg1, arg2, arg3, arg4, arg5, arg6));
//        }
//    }
//}
