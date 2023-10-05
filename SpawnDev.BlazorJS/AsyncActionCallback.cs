using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS
{
    // Async Actions
    public class AsyncActionCallback : Callback
    {
        public static implicit operator AsyncActionCallback(Func<Task> callback) => new AsyncActionCallback(callback);
        Func<Task> __callback;
        public AsyncActionCallback(Func<Task> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public Promise Invoke()
        {
            if (once) Dispose();
            return new Promise(__callback());
        }
    }

    public class AsyncActionCallback<T1> : Callback
    {
        public static implicit operator AsyncActionCallback<T1>(Func<T1, Task> callback) => new AsyncActionCallback<T1>(callback);
        Func<T1, Task> __callback;
        public AsyncActionCallback(Func<T1, Task> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public Promise Invoke(T1 arg0)
        {
            if (once) Dispose();
            return new Promise(__callback(arg0));
        }
    }

    public class AsyncActionCallback<T1, T2> : Callback
    {
        public static implicit operator AsyncActionCallback<T1, T2>(Func<T1, T2, Task> callback) => new AsyncActionCallback<T1, T2>(callback);
        Func<T1, T2, Task> __callback;
        public AsyncActionCallback(Func<T1, T2, Task> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public Promise Invoke(T1 arg0, T2 arg1)
        {
            if (once) Dispose();
            return new Promise(__callback(arg0, arg1));
        }
    }

    public class AsyncActionCallback<T1, T2, T3> : Callback
    {
        public static implicit operator AsyncActionCallback<T1, T2, T3>(Func<T1, T2, T3, Task> callback) => new AsyncActionCallback<T1, T2, T3>(callback);
        Func<T1, T2, T3, Task> __callback;
        public AsyncActionCallback(Func<T1, T2, T3, Task> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public Promise Invoke(T1 arg0, T2 arg1, T3 arg2)
        {
            if (once) Dispose();
            return new Promise(__callback(arg0, arg1, arg2));
        }
    }

    public class AsyncActionCallback<T1, T2, T3, T4> : Callback
    {
        public static implicit operator AsyncActionCallback<T1, T2, T3, T4>(Func<T1, T2, T3, T4, Task> callback) => new AsyncActionCallback<T1, T2, T3, T4>(callback);
        Func<T1, T2, T3, T4, Task> __callback;
        public AsyncActionCallback(Func<T1, T2, T3, T4, Task> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public Promise Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3)
        {
            if (once) Dispose();
            return new Promise(__callback(arg0, arg1, arg2, arg3));
        }
    }
}
