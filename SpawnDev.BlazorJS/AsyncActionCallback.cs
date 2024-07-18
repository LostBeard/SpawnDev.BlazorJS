using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class AsyncActionCallback : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator AsyncActionCallback?(Func<Task>? callback) => callback == null ? null : new AsyncActionCallback(callback);
        Func<Task> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public AsyncActionCallback(Func<Task> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public Promise Invoke()
        {
            if (once) Dispose();
            return new Promise(__callback());
        }
    }
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class AsyncActionCallback<T1> : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator AsyncActionCallback<T1>?(Func<T1, Task>? callback) => callback == null ? null : new AsyncActionCallback<T1>(callback);
        Func<T1, Task> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public AsyncActionCallback(Func<T1, Task> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public Promise Invoke(T1 arg0)
        {
            if (once) Dispose();
            return new Promise(__callback(arg0));
        }
    }
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class AsyncActionCallback<T1, T2> : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator AsyncActionCallback<T1, T2>?(Func<T1, T2, Task>? callback) => callback == null ? null : new AsyncActionCallback<T1, T2>(callback);
        Func<T1, T2, Task> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public AsyncActionCallback(Func<T1, T2, Task> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public Promise Invoke(T1 arg0, T2 arg1)
        {
            if (once) Dispose();
            return new Promise(__callback(arg0, arg1));
        }
    }
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class AsyncActionCallback<T1, T2, T3> : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator AsyncActionCallback<T1, T2, T3>?(Func<T1, T2, T3, Task>? callback) => callback == null ? null : new AsyncActionCallback<T1, T2, T3>(callback);
        Func<T1, T2, T3, Task> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public AsyncActionCallback(Func<T1, T2, T3, Task> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public Promise Invoke(T1 arg0, T2 arg1, T3 arg2)
        {
            if (once) Dispose();
            return new Promise(__callback(arg0, arg1, arg2));
        }
    }
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class AsyncActionCallback<T1, T2, T3, T4> : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator AsyncActionCallback<T1, T2, T3, T4>?(Func<T1, T2, T3, T4, Task>? callback) => callback == null ? null : new AsyncActionCallback<T1, T2, T3, T4>(callback);
        Func<T1, T2, T3, T4, Task> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public AsyncActionCallback(Func<T1, T2, T3, T4, Task> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public Promise Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3)
        {
            if (once) Dispose();
            return new Promise(__callback(arg0, arg1, arg2, arg3));
        }
    }
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class AsyncActionCallback<T1, T2, T3, T4, T5> : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator AsyncActionCallback<T1, T2, T3, T4, T5>?(Func<T1, T2, T3, T4, T5, Task>? callback) => callback == null ? null : new AsyncActionCallback<T1, T2, T3, T4, T5>(callback);
        Func<T1, T2, T3, T4, T5, Task> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public AsyncActionCallback(Func<T1, T2, T3, T4, T5, Task> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public Promise Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4)
        {
            if (once) Dispose();
            return new Promise(__callback(arg0, arg1, arg2, arg3, arg4));
        }
    }
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class AsyncActionCallback<T1, T2, T3, T4, T5, T6> : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator AsyncActionCallback<T1, T2, T3, T4, T5, T6>?(Func<T1, T2, T3, T4, T5, T6, Task>? callback) => callback == null ? null : new AsyncActionCallback<T1, T2, T3, T4, T5, T6>(callback);
        Func<T1, T2, T3, T4, T5, T6, Task> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public AsyncActionCallback(Func<T1, T2, T3, T4, T5, T6, Task> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public Promise Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5)
        {
            if (once) Dispose();
            return new Promise(__callback(arg0, arg1, arg2, arg3, arg4, arg5));
        }
    }
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class AsyncActionCallback<T1, T2, T3, T4, T5, T6, T7> : Callback
    {
        /// <summary>
        /// Implicitly converts a .Net method into a Callback
        /// </summary>
        /// <param name="callback">.Net target method</param>
        public static implicit operator AsyncActionCallback<T1, T2, T3, T4, T5, T6, T7>?(Func<T1, T2, T3, T4, T5, T6, T7, Task>? callback) => callback == null ? null : new AsyncActionCallback<T1, T2, T3, T4, T5, T6, T7>(callback);
        Func<T1, T2, T3, T4, T5, T6, T7, Task> __callback;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="callback">.Net target method</param>
        /// <param name="once">If true, the Callback will be disposed after the first call</param>
        public AsyncActionCallback(Func<T1, T2, T3, T4, T5, T6, T7, Task> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        /// <summary>
        /// Javascript callable method
        /// </summary>
        [JSInvokable]
        public Promise Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6)
        {
            if (once) Dispose();
            return new Promise(__callback(arg0, arg1, arg2, arg3, arg4, arg5, arg6));
        }
    }
}
