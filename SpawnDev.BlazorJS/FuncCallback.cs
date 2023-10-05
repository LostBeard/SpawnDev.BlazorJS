using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS
{
    // Synch Func
    public class FuncCallback<TResult> : Callback
    {
        Func<TResult> __callback;
        public FuncCallback(Func<TResult> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public TResult Invoke()
        {
            if (once) Dispose();
            return __callback();
        }
    }
    public class FuncCallback<T1, TResult> : Callback
    {
        Func<T1, TResult> __callback;
        public FuncCallback(Func<T1, TResult> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public TResult Invoke(T1 arg0)
        {
            if (once) Dispose();
            return __callback(arg0);
        }
    }
    public class FuncCallback<T1, T2, TResult> : Callback
    {
        Func<T1, T2, TResult> __callback;
        public FuncCallback(Func<T1, T2, TResult> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public TResult Invoke(T1 arg0, T2 arg1)
        {
            if (once) Dispose();
            return __callback(arg0, arg1);
        }
    }
    public class FuncCallback<T1, T2, T3, TResult> : Callback
    {
        Func<T1, T2, T3, TResult> __callback;
        public FuncCallback(Func<T1, T2, T3, TResult> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public TResult Invoke(T1 arg0, T2 arg1, T3 arg2)
        {
            if (once) Dispose();
            return __callback(arg0, arg1, arg2);
        }
    }
    public class FuncCallback<T1, T2, T3, T4, TResult> : Callback
    {
        Func<T1, T2, T3, T4, TResult> __callback;
        public FuncCallback(Func<T1, T2, T3, T4, TResult> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public TResult Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3)
        {
            if (once) Dispose();
            return __callback(arg0, arg1, arg2, arg3);
        }
    }
}
