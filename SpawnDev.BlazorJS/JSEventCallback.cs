using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    // JSEventCallback
    // Example use: (inside a JSObject class)
    // public JSEventCallback<MediaRecorderErrorEvent> OnError { get => new JSEventCallback<MediaRecorderErrorEvent>(o => AddEventListener("error", o), o => RemoveEventListener("error", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
    //
    // public JSEventCallback<Event> OnDeviceChange { get => new JSEventCallback<Event>(o => AddEventListener("devicechange", o), o => RemoveEventListener("devicechange", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
    // public JSEventCallback<Event> OnChange { get => new JSEventCallback<Event>("change", AddEventListener, RemoveEventListener); set { } }
    //
    // See SpawnDev.BlazorJS.JSObjects for example usage. JSEventCallback is now used extensively throughout JSObjects.
    //
    /// <summary>
    /// With JSEventCallback the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// For example, many JSObjects have JSEventCallback properties like the one below:<br/>
    /// <br/>
    /// public JSEventCallback&lt;Event> OnChange { get => new JSEventCallback&lt;Event>("change", AddEventListener, RemoveEventListener); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }<br/>
    /// <br/>
    /// Which allows attaching and detaching event handlers like this:<br/>
    /// element.OnChange += Element_OnChange;<br/>
    /// element.OnChange -= Element_OnChange;<br/>
    /// <br/>
    /// void Element_OnChange(Event e)<br/>
    /// {<br/>
    /// ...<br/>
    /// }
    /// </summary>
    public class JSEventCallback : JSEventCallbackBase
    {
        #region 0 Arguments
        static Dictionary<Action, JEventCallbackInfo> attachedEvents0 = new Dictionary<Action, JEventCallbackInfo>();
        /// <summary>
        /// Attaches an event handler
        /// </summary>
        public static JSEventCallback operator +(JSEventCallback a, Action b)
        {
            if (!attachedEvents0.TryGetValue(b, out var info))
            {
                info = new JEventCallbackInfo(b, new ActionCallback(b));
                attachedEvents0[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        /// <summary>
        /// Detaches an event handler
        /// </summary>
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
        /// <param name="on">add callback method - that takes (string eventName, Callback callback)</param>
        /// <param name="off">remove callback method - that takes (string eventName, Callback callback)</param>
        public JSEventCallback(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to on(callback)<br />
        /// JSEventCallback -= callback - to off(callback)<br />
        /// </summary>
        /// <param name="on">add callback method - that takes (Callback callback)</param>
        /// <param name="off">remove callback method - that takes (Callback callback)</param>
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to JSRef!.Set(propertyName, callback)<br />
        /// JSEventCallback -= callback - to JSRef!.Set(propertyName, null)<br />
        /// </summary>
        /// <param name="jsRef">Target JSObject's JSRef property (IJSInProcessObjectReference)</param>
        /// <param name="propertyName">Property name to set</param>
        public JSEventCallback(IJSInProcessObjectReference jsRef, string propertyName) : base(jsRef, propertyName) { }
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to JSRef!.CallVoid(onFn, callback)<br />
        /// JSEventCallback -= callback - to JSRef!.CallVoid(OffFn, null)<br />
        /// </summary>
        /// <param name="jsRef">Target JSObject's JSRef property (IJSInProcessObjectReference)</param>
        /// <param name="name">Event name to passed as the first argument to the onFn function</param>
        /// <param name="onFn">The name of the function to call when adding a callback</param>
        /// <param name="offFn">The name of the function to call when removing a callback</param>
        public JSEventCallback(IJSInProcessObjectReference jsRef, string name, string onFn, string offFn = "") : base(jsRef, name, onFn, offFn) { }
        #endregion
    }
    /// <summary>
    /// With JSEventCallback the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// For example, many JSObjects have JSEventCallback properties like the one below:<br/>
    /// <br/>
    /// public JSEventCallback&lt;Event> OnChange { get => new JSEventCallback&lt;Event>("change", AddEventListener, RemoveEventListener); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }<br/>
    /// <br/>
    /// Which allows attaching and detaching event handlers like this:<br/>
    /// element.OnChange += Element_OnChange;<br/>
    /// element.OnChange -= Element_OnChange;<br/>
    /// <br/>
    /// void Element_OnChange(Event e)<br/>
    /// {<br/>
    /// ...<br/>
    /// }
    /// </summary>
    public class JSEventCallback<T1> : JSEventCallbackBase
    {
        #region 0 Arguments
        static Dictionary<Action, JEventCallbackInfo> attachedEvents0 = new Dictionary<Action, JEventCallbackInfo>();
        /// <summary>
        /// Attaches an event handler
        /// </summary>
        public static JSEventCallback<T1> operator +(JSEventCallback<T1> a, Action b)
        {
            if (!attachedEvents0.TryGetValue(b, out var info))
            {
                info = new JEventCallbackInfo(b, new ActionCallback(b));
                attachedEvents0[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        /// <summary>
        /// Detaches an event handler
        /// </summary>
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
        static Dictionary<Action<T1>, JEventCallbackInfo<T1>> attachedEvents1 = new Dictionary<Action<T1>, JEventCallbackInfo<T1>>();
        /// <summary>
        /// Attaches an event handler
        /// </summary>
        public static JSEventCallback<T1> operator +(JSEventCallback<T1> a, Action<T1> b)
        {
            if (!attachedEvents1.TryGetValue(b, out var info))
            {
                info = new JEventCallbackInfo<T1>(b, new ActionCallback<T1>(b));
                attachedEvents1[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        /// <summary>
        /// Detaches an event handler
        /// </summary>
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
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to on(callback)<br />
        /// JSEventCallback -= callback - to off(callback)<br />
        /// </summary>
        /// <param name="on">add callback method - that takes (Callback callback)</param>
        /// <param name="off">remove callback method - that takes (Callback callback)</param>
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to JSRef!.Set(propertyName, callback)<br />
        /// JSEventCallback -= callback - to JSRef!.Set(propertyName, null)<br />
        /// </summary>
        /// <param name="jsRef">Target JSObject's JSRef property (IJSInProcessObjectReference)</param>
        /// <param name="propertyName">Property name to set</param>
        public JSEventCallback(IJSInProcessObjectReference jsRef, string propertyName) : base(jsRef, propertyName) { }
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to JSRef!.CallVoid(onFn, callback)<br />
        /// JSEventCallback -= callback - to JSRef!.CallVoid(OffFn, null)<br />
        /// </summary>
        /// <param name="jsRef">Target JSObject's JSRef property (IJSInProcessObjectReference)</param>
        /// <param name="name">Event name to passed as the first argument to the onFn function</param>
        /// <param name="onFn">The name of the function to call when adding a callback</param>
        /// <param name="offFn">The name of the function to call when removing a callback</param>
        public JSEventCallback(IJSInProcessObjectReference jsRef, string name, string onFn, string offFn = "") : base(jsRef, name, onFn, offFn) { }
        #endregion
    }
    /// <summary>
    /// With JSEventCallback the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// For example, many JSObjects have JSEventCallback properties like the one below:<br/>
    /// <br/>
    /// public JSEventCallback&lt;Event> OnChange { get => new JSEventCallback&lt;Event>("change", AddEventListener, RemoveEventListener); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }<br/>
    /// <br/>
    /// Which allows attaching and detaching event handlers like this:<br/>
    /// element.OnChange += Element_OnChange;<br/>
    /// element.OnChange -= Element_OnChange;<br/>
    /// <br/>
    /// void Element_OnChange(Event e)<br/>
    /// {<br/>
    /// ...<br/>
    /// }
    /// </summary>
    public class JSEventCallback<T1, T2> : JSEventCallbackBase
    {
        #region 0 Arguments
        static Dictionary<Action, JEventCallbackInfo> attachedEvents0 = new Dictionary<Action, JEventCallbackInfo>();
        /// <summary>
        /// Attaches an event handler
        /// </summary>
        public static JSEventCallback<T1, T2> operator +(JSEventCallback<T1, T2> a, Action b)
        {
            if (!attachedEvents0.TryGetValue(b, out var info))
            {
                info = new JEventCallbackInfo(b, new ActionCallback(b));
                attachedEvents0[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        /// <summary>
        /// Detaches an event handler
        /// </summary>
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
        static Dictionary<Action<T1>, JEventCallbackInfo<T1>> attachedEvents1 = new Dictionary<Action<T1>, JEventCallbackInfo<T1>>();
        /// <summary>
        /// Attaches an event handler
        /// </summary>
        public static JSEventCallback<T1, T2> operator +(JSEventCallback<T1, T2> a, Action<T1> b)
        {
            if (!attachedEvents1.TryGetValue(b, out var info))
            {
                info = new JEventCallbackInfo<T1>(b, new ActionCallback<T1>(b));
                attachedEvents1[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        /// <summary>
        /// Detaches an event handler
        /// </summary>
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
        static Dictionary<Action<T1, T2>, JEventCallbackInfo<T1, T2>> attachedEvents2 = new Dictionary<Action<T1, T2>, JEventCallbackInfo<T1, T2>>();
        /// <summary>
        /// Attaches an event handler
        /// </summary>
        public static JSEventCallback<T1, T2> operator +(JSEventCallback<T1, T2> a, Action<T1, T2> b)
        {
            if (!attachedEvents2.TryGetValue(b, out var info))
            {
                info = new JEventCallbackInfo<T1, T2>(b, new ActionCallback<T1, T2>(b));
                attachedEvents2[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        /// <summary>
        /// Detaches an event handler
        /// </summary>
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
        /// <param name="on">add callback method - that takes (string eventName, Callback callback)</param>
        /// <param name="off">remove callback method - that takes (string eventName, Callback callback)</param>
        public JSEventCallback(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to on(callback)<br />
        /// JSEventCallback -= callback - to off(callback)<br />
        /// </summary>
        /// <param name="on">add callback method - that takes (Callback callback)</param>
        /// <param name="off">remove callback method - that takes (Callback callback)</param>
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to JSRef!.Set(propertyName, callback)<br />
        /// JSEventCallback -= callback - to JSRef!.Set(propertyName, null)<br />
        /// </summary>
        /// <param name="jsRef">Target JSObject's JSRef property (IJSInProcessObjectReference)</param>
        /// <param name="propertyName">Property name to set</param>
        public JSEventCallback(IJSInProcessObjectReference jsRef, string propertyName) : base(jsRef, propertyName) { }
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to JSRef!.CallVoid(onFn, callback)<br />
        /// JSEventCallback -= callback - to JSRef!.CallVoid(OffFn, null)<br />
        /// </summary>
        /// <param name="jsRef">Target JSObject's JSRef property (IJSInProcessObjectReference)</param>
        /// <param name="name">Event name to passed as the first argument to the onFn function</param>
        /// <param name="onFn">The name of the function to call when adding a callback</param>
        /// <param name="offFn">The name of the function to call when removing a callback</param>
        public JSEventCallback(IJSInProcessObjectReference jsRef, string name, string onFn, string offFn = "") : base(jsRef, name, onFn, offFn) { }
        #endregion
    }
    /// <summary>
    /// With JSEventCallback the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// For example, many JSObjects have JSEventCallback properties like the one below:<br/>
    /// <br/>
    /// public JSEventCallback&lt;Event> OnChange { get => new JSEventCallback&lt;Event>("change", AddEventListener, RemoveEventListener); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }<br/>
    /// <br/>
    /// Which allows attaching and detaching event handlers like this:<br/>
    /// element.OnChange += Element_OnChange;<br/>
    /// element.OnChange -= Element_OnChange;<br/>
    /// <br/>
    /// void Element_OnChange(Event e)<br/>
    /// {<br/>
    /// ...<br/>
    /// }
    /// </summary>
    public class JSEventCallback<T1, T2, T3> : JSEventCallbackBase
    {
        #region 0 Arguments
        static Dictionary<Action, JEventCallbackInfo> attachedEvents0 = new Dictionary<Action, JEventCallbackInfo>();
        /// <summary>
        /// Attaches an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3> operator +(JSEventCallback<T1, T2, T3> a, Action b)
        {
            if (!attachedEvents0.TryGetValue(b, out var info))
            {
                info = new JEventCallbackInfo(b, new ActionCallback(b));
                attachedEvents0[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        /// <summary>
        /// Detaches an event handler
        /// </summary>
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
        static Dictionary<Action<T1>, JEventCallbackInfo<T1>> attachedEvents1 = new Dictionary<Action<T1>, JEventCallbackInfo<T1>>();
        /// <summary>
        /// Attaches an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3> operator +(JSEventCallback<T1, T2, T3> a, Action<T1> b)
        {
            if (!attachedEvents1.TryGetValue(b, out var info))
            {
                info = new JEventCallbackInfo<T1>(b, new ActionCallback<T1>(b));
                attachedEvents1[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        /// <summary>
        /// Detaches an event handler
        /// </summary>
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
        static Dictionary<Action<T1, T2>, JEventCallbackInfo<T1, T2>> attachedEvents2 = new Dictionary<Action<T1, T2>, JEventCallbackInfo<T1, T2>>();
        /// <summary>
        /// Attaches an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3> operator +(JSEventCallback<T1, T2, T3> a, Action<T1, T2> b)
        {
            if (!attachedEvents2.TryGetValue(b, out var info))
            {
                info = new JEventCallbackInfo<T1, T2>(b, new ActionCallback<T1, T2>(b));
                attachedEvents2[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        /// <summary>
        /// Detaches an event handler
        /// </summary>
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
        static Dictionary<Action<T1, T2, T3>, JEventCallbackInfo<T1, T2, T3>> attachedEvents3 = new Dictionary<Action<T1, T2, T3>, JEventCallbackInfo<T1, T2, T3>>();
        /// <summary>
        /// Attaches an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3> operator +(JSEventCallback<T1, T2, T3> a, Action<T1, T2, T3> b)
        {
            if (!attachedEvents3.TryGetValue(b, out var info))
            {
                info = new JEventCallbackInfo<T1, T2, T3>(b, new ActionCallback<T1, T2, T3>(b));
                attachedEvents3[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        /// <summary>
        /// Detaches an event handler
        /// </summary>
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
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to on(callback)<br />
        /// JSEventCallback -= callback - to off(callback)<br />
        /// </summary>
        /// <param name="on">add callback method - that takes (Callback callback)</param>
        /// <param name="off">remove callback method - that takes (Callback callback)</param>
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to JSRef!.Set(propertyName, callback)<br />
        /// JSEventCallback -= callback - to JSRef!.Set(propertyName, null)<br />
        /// </summary>
        /// <param name="jsRef">Target JSObject's JSRef property (IJSInProcessObjectReference)</param>
        /// <param name="propertyName">Property name to set</param>
        public JSEventCallback(IJSInProcessObjectReference jsRef, string propertyName) : base(jsRef, propertyName) { }
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to JSRef!.CallVoid(onFn, callback)<br />
        /// JSEventCallback -= callback - to JSRef!.CallVoid(OffFn, null)<br />
        /// </summary>
        /// <param name="jsRef">Target JSObject's JSRef property (IJSInProcessObjectReference)</param>
        /// <param name="name">Event name to passed as the first argument to the onFn function</param>
        /// <param name="onFn">The name of the function to call when adding a callback</param>
        /// <param name="offFn">The name of the function to call when removing a callback</param>
        public JSEventCallback(IJSInProcessObjectReference jsRef, string name, string onFn, string offFn = "") : base(jsRef, name, onFn, offFn) { }
        #endregion
    }
    /// <summary>
    /// With JSEventCallback the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// For example, many JSObjects have JSEventCallback properties like the one below:<br/>
    /// <br/>
    /// public JSEventCallback&lt;Event> OnChange { get => new JSEventCallback&lt;Event>("change", AddEventListener, RemoveEventListener); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }<br/>
    /// <br/>
    /// Which allows attaching and detaching event handlers like this:<br/>
    /// element.OnChange += Element_OnChange;<br/>
    /// element.OnChange -= Element_OnChange;<br/>
    /// <br/>
    /// void Element_OnChange(Event e)<br/>
    /// {<br/>
    /// ...<br/>
    /// }
    /// </summary>
    public class JSEventCallback<T1, T2, T3, T4> : JSEventCallbackBase
    {
        #region 0 Arguments
        static Dictionary<Action, JEventCallbackInfo> attachedEvents0 = new Dictionary<Action, JEventCallbackInfo>();
        /// <summary>
        /// Attaches an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Action b)
        {
            if (!attachedEvents0.TryGetValue(b, out var info))
            {
                info = new JEventCallbackInfo(b, new ActionCallback(b));
                attachedEvents0[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        /// <summary>
        /// Detaches an event handler
        /// </summary>
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
        static Dictionary<Action<T1>, JEventCallbackInfo<T1>> attachedEvents1 = new Dictionary<Action<T1>, JEventCallbackInfo<T1>>();
        /// <summary>
        /// Attaches an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Action<T1> b)
        {
            if (!attachedEvents1.TryGetValue(b, out var info))
            {
                info = new JEventCallbackInfo<T1>(b, new ActionCallback<T1>(b));
                attachedEvents1[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        /// <summary>
        /// Detaches an event handler
        /// </summary>
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
        static Dictionary<Action<T1, T2>, JEventCallbackInfo<T1, T2>> attachedEvents2 = new Dictionary<Action<T1, T2>, JEventCallbackInfo<T1, T2>>();
        /// <summary>
        /// Attaches an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Action<T1, T2> b)
        {
            if (!attachedEvents2.TryGetValue(b, out var info))
            {
                info = new JEventCallbackInfo<T1, T2>(b, new ActionCallback<T1, T2>(b));
                attachedEvents2[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        /// <summary>
        /// Detaches an event handler
        /// </summary>
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
        static Dictionary<Action<T1, T2, T3>, JEventCallbackInfo<T1, T2, T3>> attachedEvents3 = new Dictionary<Action<T1, T2, T3>, JEventCallbackInfo<T1, T2, T3>>();
        /// <summary>
        /// Attaches an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Action<T1, T2, T3> b)
        {
            if (!attachedEvents3.TryGetValue(b, out var info))
            {
                info = new JEventCallbackInfo<T1, T2, T3>(b, new ActionCallback<T1, T2, T3>(b));
                attachedEvents3[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        /// <summary>
        /// Detaches an event handler
        /// </summary>
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
        static Dictionary<Action<T1, T2, T3, T4>, JEventCallbackInfo<T1, T2, T3, T4>> attachedEvents4 = new Dictionary<Action<T1, T2, T3, T4>, JEventCallbackInfo<T1, T2, T3, T4>>();
        /// <summary>
        /// Attaches an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Action<T1, T2, T3, T4> b)
        {
            if (!attachedEvents4.TryGetValue(b, out var info))
            {
                info = new JEventCallbackInfo<T1, T2, T3, T4>(b, new ActionCallback<T1, T2, T3, T4>(b));
                attachedEvents4[b] = info;
            }
            info.RefCount += 1;
            a.On(info.Callback);
            return a;
        }
        /// <summary>
        /// Detaches an event handler
        /// </summary>
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
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to on(callback)<br />
        /// JSEventCallback -= callback - to off(callback)<br />
        /// </summary>
        /// <param name="on">add callback method - that takes (Callback callback)</param>
        /// <param name="off">remove callback method - that takes (Callback callback)</param>
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to JSRef!.Set(propertyName, callback)<br />
        /// JSEventCallback -= callback - to JSRef!.Set(propertyName, null)<br />
        /// </summary>
        /// <param name="jsRef">Target JSObject's JSRef property (IJSInProcessObjectReference)</param>
        /// <param name="propertyName">Property name to set</param>
        public JSEventCallback(IJSInProcessObjectReference jsRef, string propertyName) : base(jsRef, propertyName) { }
        /// <summary>
        /// Maps:<br />
        /// JSEventCallback += callback - to JSRef!.CallVoid(onFn, callback)<br />
        /// JSEventCallback -= callback - to JSRef!.CallVoid(OffFn, null)<br />
        /// </summary>
        /// <param name="jsRef">Target JSObject's JSRef property (IJSInProcessObjectReference)</param>
        /// <param name="name">Event name to passed as the first argument to the onFn function</param>
        /// <param name="onFn">The name of the function to call when adding a callback</param>
        /// <param name="offFn">The name of the function to call when removing a callback</param>
        public JSEventCallback(IJSInProcessObjectReference jsRef, string name, string onFn, string offFn = "") : base(jsRef, name, onFn, offFn) { }
        #endregion
    }
}
