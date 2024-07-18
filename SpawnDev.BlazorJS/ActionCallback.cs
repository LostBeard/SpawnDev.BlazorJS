using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS
{ 
    /// <summary>
    /// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
    /// </summary>
    public class ActionCallback : Callback
{
    /// <summary>
    /// Implicitly converts a .Net method into a Callback
    /// </summary>
    /// <param name="callback">.Net target method</param>
    public static implicit operator ActionCallback?(Action? callback) => callback == null ? null : new ActionCallback(callback);
    Action __callback;
    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <param name="callback"></param>
    /// <param name="once">If true, the Callback will be disposed after the first call</param>
    public ActionCallback(Action callback, bool once = false) : base(once)
    {
        __callback = callback;
    }
    /// <summary>
    /// Javascript callable method
    /// </summary>
    [JSInvokable]
    public void Invoke()
    {
        if (once) Dispose();
        __callback();
    }
}
/// <summary>
/// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
/// </summary>
public class ActionCallback<T1> : Callback
{
    /// <summary>
    /// Implicitly converts a .Net method into a Callback
    /// </summary>
    /// <param name="callback">.Net target method</param>
    public static implicit operator ActionCallback<T1>?(Action<T1>? callback) => callback == null ? null : new ActionCallback<T1>(callback);
    Action<T1> __callback;
    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <param name="callback">.Net target method</param>
    /// <param name="once">If true, the Callback will be disposed after the first call</param>
    public ActionCallback(Action<T1> callback, bool once = false) : base(once)
    {
        __callback = callback;
    }
    /// <summary>
    /// Javascript callable method
    /// </summary>
    [JSInvokable]
    public void Invoke(T1 arg0)
    {
        if (once) Dispose();
        __callback(arg0);
    }
}
/// <summary>
/// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
/// </summary>
public class ActionCallback<T1, T2> : Callback
{
    /// <summary>
    /// Implicitly converts a .Net method into a Callback
    /// </summary>
    /// <param name="callback">.Net target method</param>
    public static implicit operator ActionCallback<T1, T2>?(Action<T1, T2>? callback) => callback == null ? null : new ActionCallback<T1, T2>(callback);
    Action<T1, T2> __callback;
    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <param name="callback"></param>
    /// <param name="once">If true, the Callback will be disposed after the first call</param>
    public ActionCallback(Action<T1, T2> callback, bool once = false) : base(once)
    {
        __callback = callback;
    }
    /// <summary>
    /// Javascript callable method
    /// </summary>
    [JSInvokable]
    public void Invoke(T1 arg0, T2 arg1)
    {
        if (once) Dispose();
        __callback(arg0, arg1);
    }
}
/// <summary>
/// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
/// </summary>
public class ActionCallback<T1, T2, T3> : Callback
{
    /// <summary>
    /// Implicitly converts a .Net method into a Callback
    /// </summary>
    /// <param name="callback">.Net target method</param>
    public static implicit operator ActionCallback<T1, T2, T3>?(Action<T1, T2, T3>? callback) => callback == null ? null : new ActionCallback<T1, T2, T3>(callback);
    Action<T1, T2, T3> __callback;
    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <param name="callback"></param>
    /// <param name="once">If true, the Callback will be disposed after the first call</param>
    public ActionCallback(Action<T1, T2, T3> callback, bool once = false) : base(once)
    {
        __callback = callback;
    }
    /// <summary>
    /// Javascript callable method
    /// </summary>
    [JSInvokable]
    public void Invoke(T1 arg0, T2 arg1, T3 arg2)
    {
        if (once) Dispose();
        __callback(arg0, arg1, arg2);
    }
}
/// <summary>
/// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
/// </summary>
public class ActionCallback<T1, T2, T3, T4> : Callback
{
    /// <summary>
    /// Implicitly converts a .Net method into a Callback
    /// </summary>
    /// <param name="callback">.Net target method</param>
    public static implicit operator ActionCallback<T1, T2, T3, T4>?(Action<T1, T2, T3, T4>? callback) => callback == null ? null : new ActionCallback<T1, T2, T3, T4>(callback);
    Action<T1, T2, T3, T4> __callback;
    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <param name="callback"></param>
    /// <param name="once">If true, the Callback will be disposed after the first call</param>
    public ActionCallback(Action<T1, T2, T3, T4> callback, bool once = false) : base(once)
    {
        __callback = callback;
    }
    /// <summary>
    /// Javascript callable method
    /// </summary>
    [JSInvokable]
    public void Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3)
    {
        if (once) Dispose();
        __callback(arg0, arg1, arg2, arg3);
    }
}
/// <summary>
/// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
/// </summary>
public class ActionCallback<T1, T2, T3, T4, T5> : Callback
{
    /// <summary>
    /// Implicitly converts a .Net method into a Callback
    /// </summary>
    /// <param name="callback">.Net target method</param>
    public static implicit operator ActionCallback<T1, T2, T3, T4, T5>?(Action<T1, T2, T3, T4, T5>? callback) => callback == null ? null : new ActionCallback<T1, T2, T3, T4, T5>(callback);
    Action<T1, T2, T3, T4, T5> __callback;
    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <param name="callback"></param>
    /// <param name="once">If true, the Callback will be disposed after the first call</param>
    public ActionCallback(Action<T1, T2, T3, T4, T5> callback, bool once = false) : base(once)
    {
        __callback = callback;
    }
    /// <summary>
    /// Javascript callable method
    /// </summary>
    [JSInvokable]
    public void Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4)
    {
        if (once) Dispose();
        __callback(arg0, arg1, arg2, arg3, arg4);
    }
}
/// <summary>
/// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
/// </summary>
public class ActionCallback<T1, T2, T3, T4, T5, T6> : Callback
{
    /// <summary>
    /// Implicitly converts a .Net method into a Callback
    /// </summary>
    /// <param name="callback">.Net target method</param>
    public static implicit operator ActionCallback<T1, T2, T3, T4, T5, T6>?(Action<T1, T2, T3, T4, T5, T6>? callback) => callback == null ? null : new ActionCallback<T1, T2, T3, T4, T5, T6>(callback);
    Action<T1, T2, T3, T4, T5, T6> __callback;
    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <param name="callback"></param>
    /// <param name="once">If true, the Callback will be disposed after the first call</param>
    public ActionCallback(Action<T1, T2, T3, T4, T5, T6> callback, bool once = false) : base(once)
    {
        __callback = callback;
    }
    /// <summary>
    /// Javascript callable method
    /// </summary>
    [JSInvokable]
    public void Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5)
    {
        if (once) Dispose();
        __callback(arg0, arg1, arg2, arg3, arg4, arg5);
    }
}
/// <summary>
/// A Callback object wraps a .Net method and can be passed to Javascript and called directly.
/// </summary>
public class ActionCallback<T1, T2, T3, T4, T5, T6, T7> : Callback
{
    /// <summary>
    /// Implicitly converts a .Net method into a Callback
    /// </summary>
    /// <param name="callback">.Net target method</param>
    public static implicit operator ActionCallback<T1, T2, T3, T4, T5, T6, T7>?(Action<T1, T2, T3, T4, T5, T6, T7>? callback) => callback == null ? null : new ActionCallback<T1, T2, T3, T4, T5, T6, T7>(callback);
    Action<T1, T2, T3, T4, T5, T6, T7> __callback;
    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <param name="callback"></param>
    /// <param name="once">If true, the Callback will be disposed after the first call</param>
    public ActionCallback(Action<T1, T2, T3, T4, T5, T6, T7> callback, bool once = false) : base(once)
    {
        __callback = callback;
    }
    /// <summary>
    /// Javascript callable method
    /// </summary>
    [JSInvokable]
    public void Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6)
    {
        if (once) Dispose();
        __callback(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
    }
}
}
