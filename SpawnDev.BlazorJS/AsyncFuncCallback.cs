using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS
{
    // Async Func
    public class AsyncFuncCallback<TResult> : Callback
    {
        Func<Task<TResult>> __callback;
        public AsyncFuncCallback(Func<Task<TResult>> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public Promise<TResult> Invoke()
        {
            if (once) Dispose();
            return new Promise<TResult>(__callback());
        }
    }

    public class AsyncFuncCallback<T1, TResult> : Callback
    {
        Func<T1, Task<TResult>> __callback;
        public AsyncFuncCallback(Func<T1, Task<TResult>> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public Promise<TResult> Invoke(T1 arg0)
        {
            if (once) Dispose();
            return new Promise<TResult>(__callback(arg0));
        }
    }

    public class AsyncFuncCallback<T1, T2, TResult> : Callback
    {
        Func<T1, T2, Task<TResult>> __callback;
        public AsyncFuncCallback(Func<T1, T2, Task<TResult>> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public Promise<TResult> Invoke(T1 arg0, T2 arg1)
        {
            if (once) Dispose();
            return new Promise<TResult>(__callback(arg0, arg1));
        }
    }

    public class AsyncFuncCallback<T1, T2, T3, TResult> : Callback
    {
        Func<T1, T2, T3, Task<TResult>> __callback;
        public AsyncFuncCallback(Func<T1, T2, T3, Task<TResult>> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public Promise<TResult> Invoke(T1 arg0, T2 arg1, T3 arg2)
        {
            if (once) Dispose();
            return new Promise<TResult>(__callback(arg0, arg1, arg2));
        }
    }

    public class AsyncFuncCallback<T1, T2, T3, T4, TResult> : Callback
    {
        Func<T1, T2, T3, T4, Task<TResult>> __callback;
        public AsyncFuncCallback(Func<T1, T2, T3, T4, Task<TResult>> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public Promise<TResult> Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3)
        {
            if (once) Dispose();
            return new Promise<TResult>(__callback(arg0, arg1, arg2, arg3));
        }
    }
}
