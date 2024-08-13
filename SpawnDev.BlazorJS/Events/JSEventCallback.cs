namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// DEPRECATED: Use ActionEvent instead.<br/>
    /// With JSEventCallback the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// Example use inside a JSObject:<br/>
    /// <br/>
    /// public JSEventCallback&lt;Event> OnChange { get => new JSEventCallback&lt;Event>("change", AddEventListener, RemoveEventListener); set { } }<br/>
    /// <br/>
    /// Which is equivalent to:<br/>
    /// <br/>
    /// public JSEventCallback&lt;Event> OnChange { get => new JSEventCallback&lt;Event>((callback) => JSRef!.CallVoid("addEventListener", "change", callback), (callback) => JSRef!.CallVoid("removeEventListener", "change", callback)); set { } }<br/>
    /// <br/>
    /// Which allows attaching and detaching event handlers like this:<br/>
    /// element.OnChange += Element_OnChange;<br/>
    /// element.OnChange -= Element_OnChange;<br/>
    /// void Element_OnChange(Event e)<br/>
    /// {<br/>
    /// ...<br/>
    /// }<br/>
    /// </summary>
    [Obsolete("This class is deprecated in favor of ActionEvent, which provides identical functionality.")]
    public class JSEventCallback : CallbackEvent
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback operator +(JSEventCallback a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback operator -(JSEventCallback a, Callback callback)
        {
            a.Off(callback);
            return a;
        }

        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback operator +(JSEventCallback a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback operator -(JSEventCallback a, Action listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Action listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Action listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// DEPRECATED: Use ActionEvent instead.<br/>
    /// With JSEventCallback the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// </summary>
    [Obsolete("This class is deprecated in favor of ActionEvent, which provides identical functionality.")]
    public class JSEventCallback<T1> : JSEventCallback
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1> operator +(JSEventCallback<T1> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1> operator -(JSEventCallback<T1> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1> operator +(JSEventCallback<T1> a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1> operator -(JSEventCallback<T1> a, Action listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1> operator +(JSEventCallback<T1> a, Action<T1> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1> operator -(JSEventCallback<T1> a, Action<T1> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Action<T1> listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Action<T1> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// DEPRECATED: Use ActionEvent instead.<br/>
    /// With JSEventCallback the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// </summary>
    [Obsolete("This class is deprecated in favor of ActionEvent, which provides identical functionality.")]
    public class JSEventCallback<T1, T2> : JSEventCallback<T1>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2> operator +(JSEventCallback<T1, T2> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2> operator -(JSEventCallback<T1, T2> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2> operator +(JSEventCallback<T1, T2> a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2> operator -(JSEventCallback<T1, T2> a, Action listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2> operator +(JSEventCallback<T1, T2> a, Action<T1> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2> operator -(JSEventCallback<T1, T2> a, Action<T1> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2> operator +(JSEventCallback<T1, T2> a, Action<T1, T2> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2> operator -(JSEventCallback<T1, T2> a, Action<T1, T2> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Action<T1, T2> listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Action<T1, T2> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// DEPRECATED: Use ActionEvent instead.<br/>
    /// With JSEventCallback the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// </summary>
    [Obsolete("This class is deprecated in favor of ActionEvent, which provides identical functionality.")]
    public class JSEventCallback<T1, T2, T3> : JSEventCallback<T1, T2>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3> operator +(JSEventCallback<T1, T2, T3> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3> operator -(JSEventCallback<T1, T2, T3> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3> operator +(JSEventCallback<T1, T2, T3> a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3> operator -(JSEventCallback<T1, T2, T3> a, Action listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3> operator +(JSEventCallback<T1, T2, T3> a, Action<T1> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3> operator -(JSEventCallback<T1, T2, T3> a, Action<T1> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3> operator +(JSEventCallback<T1, T2, T3> a, Action<T1, T2> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3> operator -(JSEventCallback<T1, T2, T3> a, Action<T1, T2> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3> operator +(JSEventCallback<T1, T2, T3> a, Action<T1, T2, T3> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3> operator -(JSEventCallback<T1, T2, T3> a, Action<T1, T2, T3> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Action<T1, T2, T3> listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Action<T1, T2, T3> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// DEPRECATED: Use ActionEvent instead.<br/>
    /// With JSEventCallback the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// </summary>
    [Obsolete("This class is deprecated in favor of ActionEvent, which provides identical functionality.")]
    public class JSEventCallback<T1, T2, T3, T4> : JSEventCallback<T1, T2, T3>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator -(JSEventCallback<T1, T2, T3, T4> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator -(JSEventCallback<T1, T2, T3, T4> a, Action listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Action<T1> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator -(JSEventCallback<T1, T2, T3, T4> a, Action<T1> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Action<T1, T2> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator -(JSEventCallback<T1, T2, T3, T4> a, Action<T1, T2> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Action<T1, T2, T3> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator -(JSEventCallback<T1, T2, T3, T4> a, Action<T1, T2, T3> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator +(JSEventCallback<T1, T2, T3, T4> a, Action<T1, T2, T3, T4> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4> operator -(JSEventCallback<T1, T2, T3, T4> a, Action<T1, T2, T3, T4> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Action<T1, T2, T3, T4> listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Action<T1, T2, T3, T4> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// DEPRECATED: Use ActionEvent instead.<br/>
    /// With JSEventCallback the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// </summary>
    [Obsolete("This class is deprecated in favor of ActionEvent, which provides identical functionality.")]
    public class JSEventCallback<T1, T2, T3, T4, T5> : JSEventCallback<T1, T2, T3, T4>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5> operator +(JSEventCallback<T1, T2, T3, T4, T5> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5> operator -(JSEventCallback<T1, T2, T3, T4, T5> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5> operator +(JSEventCallback<T1, T2, T3, T4, T5> a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5> operator -(JSEventCallback<T1, T2, T3, T4, T5> a, Action listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5> operator +(JSEventCallback<T1, T2, T3, T4, T5> a, Action<T1> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5> operator -(JSEventCallback<T1, T2, T3, T4, T5> a, Action<T1> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5> operator +(JSEventCallback<T1, T2, T3, T4, T5> a, Action<T1, T2> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5> operator -(JSEventCallback<T1, T2, T3, T4, T5> a, Action<T1, T2> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5> operator +(JSEventCallback<T1, T2, T3, T4, T5> a, Action<T1, T2, T3> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5> operator -(JSEventCallback<T1, T2, T3, T4, T5> a, Action<T1, T2, T3> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5> operator +(JSEventCallback<T1, T2, T3, T4, T5> a, Action<T1, T2, T3, T4> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5> operator -(JSEventCallback<T1, T2, T3, T4, T5> a, Action<T1, T2, T3, T4> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5> operator +(JSEventCallback<T1, T2, T3, T4, T5> a, Action<T1, T2, T3, T4, T5> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5> operator -(JSEventCallback<T1, T2, T3, T4, T5> a, Action<T1, T2, T3, T4, T5> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Action<T1, T2, T3, T4, T5> listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Action<T1, T2, T3, T4, T5> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// DEPRECATED: Use ActionEvent instead.<br/>
    /// With JSEventCallback the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// </summary>
    [Obsolete("This class is deprecated in favor of ActionEvent, which provides identical functionality.")]
    public class JSEventCallback<T1, T2, T3, T4, T5, T6> : JSEventCallback<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Action listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Action<T1> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Action<T1> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Action<T1, T2> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Action<T1, T2> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3, T4> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3, T4> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3, T4, T5> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3, T4, T5> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3, T4, T5, T6> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3, T4, T5, T6> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Action<T1, T2, T3, T4, T5, T6> listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Action<T1, T2, T3, T4, T5, T6> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// DEPRECATED: Use ActionEvent instead.<br/>
    /// With JSEventCallback the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// </summary>
    [Obsolete("This class is deprecated in favor of ActionEvent, which provides identical functionality.")]
    public class JSEventCallback<T1, T2, T3, T4, T5, T6, T7> : JSEventCallback<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action<T1> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action<T1> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4, T5> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4, T5> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4, T5, T6> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4, T5, T6> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator +(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4, T5, T6, T7> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static JSEventCallback<T1, T2, T3, T4, T5, T6, T7> operator -(JSEventCallback<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4, T5, T6, T7> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return a;
            a.Off(callback);
            CallbackRef.RefDel(listener);
            return a;
        }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public JSEventCallback(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Action<T1, T2, T3, T4, T5, T6, T7> listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Action<T1, T2, T3, T4, T5, T6, T7> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
}
