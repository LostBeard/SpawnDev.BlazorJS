using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    // JSEventCallback
    // Example use: (inside a JSObject class)
    // public JSEventCallback<MediaRecorderErrorEvent> OnError { get => new JSEventCallback<MediaRecorderErrorEvent>(o => AddEventListener("error", o), o => RemoveEventListener("error", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
    //
    // public JSEventCallback<Event> OnDeviceChange { get => new JSEventCallback<Event>(o => AddEventListener("devicechange", o), o => RemoveEventListener("devicechange", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
    //
    // See SpawnDev.BlazorJS.JSObjects for example usage. JSEventCallback is now used extensively throughout JSObjects.
    //
    public class JSEventCallback : EventCallbackBase
    {
        #region 0 Arguments
        static Dictionary<Action, AttachedEventInfo> attachedEvents0 = new Dictionary<Action, AttachedEventInfo>();
        public static JSEventCallback operator +(JSEventCallback a, Action b)
        {
            if (!attachedEvents0.TryGetValue(b, out var info))
            {
                info = new AttachedEventInfo(b, new ActionCallback(b));
                attachedEvents0[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        public static JSEventCallback operator -(JSEventCallback a, Action b)
        {
            if (!attachedEvents0.TryGetValue(b, out var info)) return a;
            a.Off?.Invoke(info.Callback);
            info.RefCount -= 1;
            if (info.RefCount <= 0)
            {
                info.Callback.Dispose();
                attachedEvents0.Remove(b);
            }
            return a;
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to on(eventName, callback)<br />
        /// JSEventCallback -= callback - to off(eventName, callback)<br />
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="on">add callback method - that takes (eventName, callback)</param>
        /// <param name="off">remove callback method - that takes (eventName, callback)</param>
        public JSEventCallback(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        public JSEventCallback(IJSInProcessObjectReference jsRef, string propertyName) : base(jsRef, propertyName) { }
        public JSEventCallback(IJSInProcessObjectReference jsRef, string name, string onFn, string offFn = "") : base(jsRef, name, onFn, offFn) { }
        #endregion
    }
    public class JSEventCallback<T1> : EventCallbackBase
    {
        #region 0 Arguments
        static Dictionary<Action, AttachedEventInfo> attachedEvents0 = new Dictionary<Action, AttachedEventInfo>();
        public static JSEventCallback<T1> operator +(JSEventCallback<T1> a, Action b)
        {
            if (!attachedEvents0.TryGetValue(b, out var info))
            {
                info = new AttachedEventInfo(b, new ActionCallback(b));
                attachedEvents0[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        public static JSEventCallback<T1> operator -(JSEventCallback<T1> a, Action b)
        {
            if (!attachedEvents0.TryGetValue(b, out var info)) return a;
            a.Off?.Invoke(info.Callback);
            info.RefCount -= 1;
            if (info.RefCount <= 0)
            {
                info.Callback.Dispose();
                attachedEvents0.Remove(b);
            }
            return a;
        }
        #endregion
        #region 1 Argument
        static Dictionary<Action<T1>, AttachedEventInfo<T1>> attachedEvents1 = new Dictionary<Action<T1>, AttachedEventInfo<T1>>();
        public static JSEventCallback<T1> operator +(JSEventCallback<T1> a, Action<T1> b)
        {
            if (!attachedEvents1.TryGetValue(b, out var info))
            {
                info = new AttachedEventInfo<T1>(b, new ActionCallback<T1>(b));
                attachedEvents1[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        public static JSEventCallback<T1> operator -(JSEventCallback<T1> a, Action<T1> b)
        {
            if (!attachedEvents1.TryGetValue(b, out var info)) return a;
            a.Off?.Invoke(info.Callback);
            info.RefCount -= 1;
            if (info.RefCount <= 0)
            {
                info.Callback.Dispose();
                attachedEvents1.Remove(b);
            }
            return a;
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to on(eventName, callback)<br />
        /// JSEventCallback -= callback - to off(eventName, callback)<br />
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="on">add callback method - that takes (eventName, callback)</param>
        /// <param name="off">remove callback method - that takes (eventName, callback)</param>
        public JSEventCallback(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        public JSEventCallback(IJSInProcessObjectReference jsRef, string propertyName) : base(jsRef, propertyName) { }
        public JSEventCallback(IJSInProcessObjectReference jsRef, string name, string onFn, string offFn = "") : base(jsRef, name, onFn, offFn) { }
        #endregion
    }
    public class JSEventCallback<T1, T2> : EventCallbackBase
    {
        #region 0 Arguments
        static Dictionary<Action, AttachedEventInfo> attachedEvents0 = new Dictionary<Action, AttachedEventInfo>();
        public static JSEventCallback<T1, T2> operator +(JSEventCallback<T1, T2> a, Action b)
        {
            if (!attachedEvents0.TryGetValue(b, out var info))
            {
                info = new AttachedEventInfo(b, new ActionCallback(b));
                attachedEvents0[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        public static JSEventCallback<T1, T2> operator -(JSEventCallback<T1, T2> a, Action b)
        {
            if (!attachedEvents0.TryGetValue(b, out var info)) return a;
            a.Off?.Invoke(info.Callback);
            info.RefCount -= 1;
            if (info.RefCount <= 0)
            {
                info.Callback.Dispose();
                attachedEvents0.Remove(b);
            }
            return a;
        }
        #endregion
        #region 1 Argument
        static Dictionary<Action<T1>, AttachedEventInfo<T1>> attachedEvents1 = new Dictionary<Action<T1>, AttachedEventInfo<T1>>();
        public static JSEventCallback<T1, T2> operator +(JSEventCallback<T1, T2> a, Action<T1> b)
        {
            if (!attachedEvents1.TryGetValue(b, out var info))
            {
                info = new AttachedEventInfo<T1>(b, new ActionCallback<T1>(b));
                attachedEvents1[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        public static JSEventCallback<T1, T2> operator -(JSEventCallback<T1, T2> a, Action<T1> b)
        {
            if (!attachedEvents1.TryGetValue(b, out var info)) return a;
            a.Off?.Invoke(info.Callback);
            info.RefCount -= 1;
            if (info.RefCount <= 0)
            {
                info.Callback.Dispose();
                attachedEvents1.Remove(b);
            }
            return a;
        }
        #endregion
        #region 2 Arguments
        static Dictionary<Action<T1, T2>, AttachedEventInfo<T1, T2>> attachedEvents2 = new Dictionary<Action<T1, T2>, AttachedEventInfo<T1, T2>>();
        public static JSEventCallback<T1, T2> operator +(JSEventCallback<T1, T2> a, Action<T1, T2> b)
        {
            if (!attachedEvents2.TryGetValue(b, out var info))
            {
                info = new AttachedEventInfo<T1, T2>(b, new ActionCallback<T1, T2>(b));
                attachedEvents2[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        public static JSEventCallback<T1, T2> operator -(JSEventCallback<T1, T2> a, Action<T1, T2> b)
        {
            if (!attachedEvents2.TryGetValue(b, out var info)) return a;
            a.Off?.Invoke(info.Callback);
            info.RefCount -= 1;
            if (info.RefCount <= 0)
            {
                info.Callback.Dispose();
                attachedEvents2.Remove(b);
            }
            return a;
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to on(eventName, callback)<br />
        /// JSEventCallback -= callback - to off(eventName, callback)<br />
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="on">add callback method - that takes (eventName, callback)</param>
        /// <param name="off">remove callback method - that takes (eventName, callback)</param>
        public JSEventCallback(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        public JSEventCallback(IJSInProcessObjectReference jsRef, string propertyName) : base(jsRef, propertyName) { }
        public JSEventCallback(IJSInProcessObjectReference jsRef, string name, string onFn, string offFn = "") : base(jsRef, name, onFn, offFn) { }
        #endregion
    }
    public class JSEventCallback<T1, T2, T3> : EventCallbackBase
    {
        #region 0 Arguments
        static Dictionary<Action, AttachedEventInfo> attachedEvents0 = new Dictionary<Action, AttachedEventInfo>();
        public static JSEventCallback<T1, T2, T3> operator +(JSEventCallback<T1, T2, T3> a, Action b)
        {
            if (!attachedEvents0.TryGetValue(b, out var info))
            {
                info = new AttachedEventInfo(b, new ActionCallback(b));
                attachedEvents0[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        public static JSEventCallback<T1, T2, T3> operator -(JSEventCallback<T1, T2, T3> a, Action b)
        {
            if (!attachedEvents0.TryGetValue(b, out var info)) return a;
            a.Off?.Invoke(info.Callback);
            info.RefCount -= 1;
            if (info.RefCount <= 0)
            {
                info.Callback.Dispose();
                attachedEvents0.Remove(b);
            }
            return a;
        }
        #endregion
        #region 1 Argument
        static Dictionary<Action<T1>, AttachedEventInfo<T1>> attachedEvents1 = new Dictionary<Action<T1>, AttachedEventInfo<T1>>();
        public static JSEventCallback<T1, T2, T3> operator +(JSEventCallback<T1, T2, T3> a, Action<T1> b)
        {
            if (!attachedEvents1.TryGetValue(b, out var info))
            {
                info = new AttachedEventInfo<T1>(b, new ActionCallback<T1>(b));
                attachedEvents1[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        public static JSEventCallback<T1, T2, T3> operator -(JSEventCallback<T1, T2, T3> a, Action<T1> b)
        {
            if (!attachedEvents1.TryGetValue(b, out var info)) return a;
            a.Off?.Invoke(info.Callback);
            info.RefCount -= 1;
            if (info.RefCount <= 0)
            {
                info.Callback.Dispose();
                attachedEvents1.Remove(b);
            }
            return a;
        }
        #endregion
        #region 2 Arguments
        static Dictionary<Action<T1, T2>, AttachedEventInfo<T1, T2>> attachedEvents2 = new Dictionary<Action<T1, T2>, AttachedEventInfo<T1, T2>>();
        public static JSEventCallback<T1, T2, T3> operator +(JSEventCallback<T1, T2, T3> a, Action<T1, T2> b)
        {
            if (!attachedEvents2.TryGetValue(b, out var info))
            {
                info = new AttachedEventInfo<T1, T2>(b, new ActionCallback<T1, T2>(b));
                attachedEvents2[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        public static JSEventCallback<T1, T2, T3> operator -(JSEventCallback<T1, T2, T3> a, Action<T1, T2> b)
        {
            if (!attachedEvents2.TryGetValue(b, out var info)) return a;
            a.Off?.Invoke(info.Callback);
            info.RefCount -= 1;
            if (info.RefCount <= 0)
            {
                info.Callback.Dispose();
                attachedEvents2.Remove(b);
            }
            return a;
        }
        #endregion
        #region 3 Arguments
        static Dictionary<Action<T1, T2, T3>, AttachedEventInfo<T1, T2, T3>> attachedEvents3 = new Dictionary<Action<T1, T2, T3>, AttachedEventInfo<T1, T2, T3>>();
        public static JSEventCallback<T1, T2, T3> operator +(JSEventCallback<T1, T2, T3> a, Action<T1, T2, T3> b)
        {
            if (!attachedEvents3.TryGetValue(b, out var info))
            {
                info = new AttachedEventInfo<T1, T2, T3>(b, new ActionCallback<T1, T2, T3>(b));
                attachedEvents3[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        public static JSEventCallback<T1, T2, T3> operator -(JSEventCallback<T1, T2, T3> a, Action<T1, T2, T3> b)
        {
            if (!attachedEvents3.TryGetValue(b, out var info)) return a;
            a.Off?.Invoke(info.Callback);
            info.RefCount -= 1;
            if (info.RefCount <= 0)
            {
                info.Callback.Dispose();
                attachedEvents3.Remove(b);
            }
            return a;
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to on(eventName, callback)<br />
        /// JSEventCallback -= callback - to off(eventName, callback)<br />
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="on">add callback method - that takes (eventName, callback)</param>
        /// <param name="off">remove callback method - that takes (eventName, callback)</param>
        public JSEventCallback(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        public JSEventCallback(IJSInProcessObjectReference jsRef, string propertyName) : base(jsRef, propertyName) { }
        public JSEventCallback(IJSInProcessObjectReference jsRef, string name, string onFn, string offFn = "") : base(jsRef, name, onFn, offFn) { }
        #endregion
    }
    public class JSEventCallback<T1, T2, T3, T4> : EventCallbackBase
    {
        #region 0 Arguments
        static Dictionary<Action, AttachedEventInfo> attachedEvents0 = new Dictionary<Action, AttachedEventInfo>();
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Action b)
        {
            if (!attachedEvents0.TryGetValue(b, out var info))
            {
                info = new AttachedEventInfo(b, new ActionCallback(b));
                attachedEvents0[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        public static JSEventCallback<T1, T2, T3, T4> operator -(JSEventCallback<T1, T2, T3, T4> a, Action b)
        {
            if (!attachedEvents0.TryGetValue(b, out var info)) return a;
            a.Off?.Invoke(info.Callback);
            info.RefCount -= 1;
            if (info.RefCount <= 0)
            {
                info.Callback.Dispose();
                attachedEvents0.Remove(b);
            }
            return a;
        }
        #endregion
        #region 1 Argument
        static Dictionary<Action<T1>, AttachedEventInfo<T1>> attachedEvents1 = new Dictionary<Action<T1>, AttachedEventInfo<T1>>();
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Action<T1> b)
        {
            if (!attachedEvents1.TryGetValue(b, out var info))
            {
                info = new AttachedEventInfo<T1>(b, new ActionCallback<T1>(b));
                attachedEvents1[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        public static JSEventCallback<T1, T2, T3, T4> operator -(JSEventCallback<T1, T2, T3, T4> a, Action<T1> b)
        {
            if (!attachedEvents1.TryGetValue(b, out var info)) return a;
            a.Off?.Invoke(info.Callback);
            info.RefCount -= 1;
            if (info.RefCount <= 0)
            {
                info.Callback.Dispose();
                attachedEvents1.Remove(b);
            }
            return a;
        }
        #endregion
        #region 2 Arguments
        static Dictionary<Action<T1, T2>, AttachedEventInfo<T1, T2>> attachedEvents2 = new Dictionary<Action<T1, T2>, AttachedEventInfo<T1, T2>>();
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Action<T1, T2> b)
        {
            if (!attachedEvents2.TryGetValue(b, out var info))
            {
                info = new AttachedEventInfo<T1, T2>(b, new ActionCallback<T1, T2>(b));
                attachedEvents2[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        public static JSEventCallback<T1, T2, T3, T4> operator -(JSEventCallback<T1, T2, T3, T4> a, Action<T1, T2> b)
        {
            if (!attachedEvents2.TryGetValue(b, out var info)) return a;
            a.Off?.Invoke(info.Callback);
            info.RefCount -= 1;
            if (info.RefCount <= 0)
            {
                info.Callback.Dispose();
                attachedEvents2.Remove(b);
            }
            return a;
        }
        #endregion
        #region 3 Arguments
        static Dictionary<Action<T1, T2, T3>, AttachedEventInfo<T1, T2, T3>> attachedEvents3 = new Dictionary<Action<T1, T2, T3>, AttachedEventInfo<T1, T2, T3>>();
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Action<T1, T2, T3> b)
        {
            if (!attachedEvents3.TryGetValue(b, out var info))
            {
                info = new AttachedEventInfo<T1, T2, T3>(b, new ActionCallback<T1, T2, T3>(b));
                attachedEvents3[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        public static JSEventCallback<T1, T2, T3, T4> operator -(JSEventCallback<T1, T2, T3, T4> a, Action<T1, T2, T3> b)
        {
            if (!attachedEvents3.TryGetValue(b, out var info)) return a;
            a.Off?.Invoke(info.Callback);
            info.RefCount -= 1;
            if (info.RefCount <= 0)
            {
                info.Callback.Dispose();
                attachedEvents3.Remove(b);
            }
            return a;
        }
        #endregion
        #region 4 Arguments
        static Dictionary<Action<T1, T2, T3, T4>, AttachedEventInfo<T1, T2, T3, T4>> attachedEvents4 = new Dictionary<Action<T1, T2, T3, T4>, AttachedEventInfo<T1, T2, T3, T4>>();
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Action<T1, T2, T3, T4> b)
        {
            if (!attachedEvents4.TryGetValue(b, out var info))
            {
                info = new AttachedEventInfo<T1, T2, T3, T4>(b, new ActionCallback<T1, T2, T3, T4>(b));
                attachedEvents4[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        public static JSEventCallback<T1, T2, T3, T4> operator -(JSEventCallback<T1, T2, T3, T4> a, Action<T1, T2, T3, T4> b)
        {
            if (!attachedEvents4.TryGetValue(b, out var info)) return a;
            a.Off?.Invoke(info.Callback);
            info.RefCount -= 1;
            if (info.RefCount <= 0)
            {
                info.Callback.Dispose();
                attachedEvents4.Remove(b);
            }
            return a;
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to on(eventName, callback)<br />
        /// JSEventCallback -= callback - to off(eventName, callback)<br />
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="on">add callback method - that takes (eventName, callback)</param>
        /// <param name="off">remove callback method - that takes (eventName, callback)</param>
        public JSEventCallback(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        public JSEventCallback(IJSInProcessObjectReference jsRef, string propertyName) : base(jsRef, propertyName) { }
        public JSEventCallback(IJSInProcessObjectReference jsRef, string name, string onFn, string offFn = "") : base(jsRef, name, onFn, offFn) { }
        #endregion
    }
    // *******************************************************************

    public abstract class EventCallbackBase
    {
        public Action<Callback> On { get; private set; }
        public Action<Callback>? Off { get; private set; }
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to on(eventName, callback)<br />
        /// JSEventCallback -= callback - to off(eventName, callback)<br />
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="on">add callback method - that takes (eventName, callback)</param>
        /// <param name="off">remove callback method - that takes (eventName, callback)</param>
        public EventCallbackBase(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null)
        {
            On = (o) => on(eventName, o);
            Off = off == null ? null : (o) => off(eventName, o);
        }
        public EventCallbackBase(Action<Callback> on, Action<Callback>? off = null)
        {
            On = on;
            Off = off;
        }
        public EventCallbackBase(IJSInProcessObjectReference jsRef, string name, string onFn, string offFn = "")
        {
            On = (o) => jsRef.CallVoid(onFn, name, o);
            if (!string.IsNullOrEmpty(offFn)) Off = (o) => jsRef.CallVoid(offFn, name, o);
        }
        public EventCallbackBase(IJSInProcessObjectReference jsRef, string propertyName)
        {
            On = (o) => jsRef.Set(propertyName, o);
            Off = (o) => jsRef.Set(propertyName, null);
        }
    }

    public class AttachedEventInfoBase
    {
        public int RefCount { get; set; }
    }
    public class AttachedEventInfo : AttachedEventInfoBase
    {
        public ActionCallback Callback { get; }
        public Action Action { get; }
        public AttachedEventInfo(Action action, ActionCallback callback) => (Action, Callback) = (action, callback);
    }
    public class AttachedEventInfo<T1> : AttachedEventInfoBase
    {
        public ActionCallback<T1> Callback { get; }
        public Action<T1> Action { get; }
        public AttachedEventInfo(Action<T1> action, ActionCallback<T1> callback) => (Action, Callback) = (action, callback);
    }
    public class AttachedEventInfo<T1, T2> : AttachedEventInfoBase
    {
        public ActionCallback<T1, T2> Callback { get; }
        public Action<T1, T2> Action { get; }
        public AttachedEventInfo(Action<T1, T2> action, ActionCallback<T1, T2> callback) => (Action, Callback) = (action, callback);
    }
    public class AttachedEventInfo<T1, T2, T3> : AttachedEventInfoBase
    {
        public ActionCallback<T1, T2, T3> Callback { get; }
        public Action<T1, T2, T3> Action { get; }
        public AttachedEventInfo(Action<T1, T2, T3> action, ActionCallback<T1, T2, T3> callback) => (Action, Callback) = (action, callback);
    }
    public class AttachedEventInfo<T1, T2, T3, T4> : AttachedEventInfoBase
    {
        public ActionCallback<T1, T2, T3, T4> Callback { get; }
        public Action<T1, T2, T3, T4> Action { get; }
        public AttachedEventInfo(Action<T1, T2, T3, T4> action, ActionCallback<T1, T2, T3, T4> callback) => (Action, Callback) = (action, callback);
    }
}
