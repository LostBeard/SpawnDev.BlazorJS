using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS
{
    // Synch Actions
    public class ActionCallback : Callback
    {
        public static implicit operator ActionCallback(Action callback) => new ActionCallback(callback);
        Action __callback;
        public ActionCallback(Action callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public void Invoke()
        {
            if (once) Dispose();
            __callback();
        }
    }
    public class ActionCallback<T1> : Callback
    {
        public static implicit operator ActionCallback<T1>(Action<T1> callback) => new ActionCallback<T1>(callback);
        Action<T1> __callback;
        public ActionCallback(Action<T1> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public void Invoke(T1 arg0)
        {
            if (once) Dispose();
            __callback(arg0);
        }
    }
    public class ActionCallback<T1, T2> : Callback
    {
        public static implicit operator ActionCallback<T1, T2>(Action<T1, T2> callback) => new ActionCallback<T1, T2>(callback);
        Action<T1, T2> __callback;
        public ActionCallback(Action<T1, T2> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public void Invoke(T1 arg0, T2 arg1)
        {
            if (once) Dispose();
            __callback(arg0, arg1);
        }
    }
    public class ActionCallback<T1, T2, T3> : Callback
    {
        public static implicit operator ActionCallback<T1, T2, T3>(Action<T1, T2, T3> callback) => new ActionCallback<T1, T2, T3>(callback);
        Action<T1, T2, T3> __callback;
        public ActionCallback(Action<T1, T2, T3> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public void Invoke(T1 arg0, T2 arg1, T3 arg2)
        {
            if (once) Dispose();
            __callback(arg0, arg1, arg2);
        }
    }
    public class ActionCallback<T1, T2, T3, T4> : Callback
    {
        public static implicit operator ActionCallback<T1, T2, T3, T4>(Action<T1, T2, T3, T4> callback) => new ActionCallback<T1, T2, T3, T4>(callback);
        Action<T1, T2, T3, T4> __callback;
        public ActionCallback(Action<T1, T2, T3, T4> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public void Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3)
        {
            if (once) Dispose();
            __callback(arg0, arg1, arg2, arg3);
        }
    }
    public class ActionCallback<T1, T2, T3, T4, T5> : Callback
    {
        public static implicit operator ActionCallback<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> callback) => new ActionCallback<T1, T2, T3, T4, T5>(callback);
        Action<T1, T2, T3, T4, T5> __callback;
        public ActionCallback(Action<T1, T2, T3, T4, T5> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public void Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4)
        {
            if (once) Dispose();
            __callback(arg0, arg1, arg2, arg3, arg4);
        }
    }
    public class ActionCallback<T1, T2, T3, T4, T5, T6> : Callback
    {
        public static implicit operator ActionCallback<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> callback) => new ActionCallback<T1, T2, T3, T4, T5, T6>(callback);
        Action<T1, T2, T3, T4, T5, T6> __callback;
        public ActionCallback(Action<T1, T2, T3, T4, T5, T6> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public void Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5)
        {
            if (once) Dispose();
            __callback(arg0, arg1, arg2, arg3, arg4, arg5);
        }
    }
    public class ActionCallback<T1, T2, T3, T4, T5, T6, T7> : Callback
    {
        public static implicit operator ActionCallback<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> callback) => new ActionCallback<T1, T2, T3, T4, T5, T6, T7>(callback);
        Action<T1, T2, T3, T4, T5, T6, T7> __callback;
        public ActionCallback(Action<T1, T2, T3, T4, T5, T6, T7> callback, bool once = false) : base(once)
        {
            __callback = callback;
        }
        [JSInvokable]
        public void Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6)
        {
            if (once) Dispose();
            __callback(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }
    }
}
