namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// With ActionEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// For example, many JSObjects have ActionEvent properties like the one below:<br/>
    /// <br/>
    /// public ActionEvent&lt;Event> OnChange { get => new ActionEvent&lt;Event>("change", AddEventListener, RemoveEventListener); set { } }<br/>
    /// <br/>
    /// Which is equivalent to:<br/>
    /// <br/>
    /// public ActionEvent&lt;Event> OnChange { get => new ActionEvent&lt;Event>((callback) => JSRef!.CallVoid("addEventListener", "change", callback), (callback) => JSRef!.CallVoid("removeEventListener", "change", callback)); set { } }<br/>
    /// <br/>
    /// Which allows attaching and detaching event handlers like this:<br/>
    /// element.OnChange += Element_OnChange;<br/>
    /// element.OnChange -= Element_OnChange;<br/>
    /// void Element_OnChange(Event e)<br/>
    /// {<br/>
    /// ...<br/>
    /// }<br/>
    /// </summary>
    public class ActionEvent : CallbackEvent
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent operator +(ActionEvent a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent operator -(ActionEvent a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent operator +(ActionEvent a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent operator -(ActionEvent a, Action listener)
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
        public ActionEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public ActionEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
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
    /// With ActionEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// </summary>
    public class ActionEvent<T1> : ActionEvent
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1> operator +(ActionEvent<T1> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1> operator -(ActionEvent<T1> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1> operator +(ActionEvent<T1> a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1> operator -(ActionEvent<T1> a, Action listener)
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
        public static ActionEvent<T1> operator +(ActionEvent<T1> a, Action<T1> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1> operator -(ActionEvent<T1> a, Action<T1> listener)
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
        public ActionEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public ActionEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
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
    /// With ActionEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// </summary>
    public class ActionEvent<T1, T2> : ActionEvent<T1>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2> operator +(ActionEvent<T1, T2> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2> operator -(ActionEvent<T1, T2> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2> operator +(ActionEvent<T1, T2> a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2> operator -(ActionEvent<T1, T2> a, Action listener)
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
        public static ActionEvent<T1, T2> operator +(ActionEvent<T1, T2> a, Action<T1> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2> operator -(ActionEvent<T1, T2> a, Action<T1> listener)
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
        public static ActionEvent<T1, T2> operator +(ActionEvent<T1, T2> a, Action<T1, T2> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2> operator -(ActionEvent<T1, T2> a, Action<T1, T2> listener)
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
        public ActionEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public ActionEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
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
    /// With ActionEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// </summary>
    public class ActionEvent<T1, T2, T3> : ActionEvent<T1, T2>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3> operator +(ActionEvent<T1, T2, T3> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3> operator -(ActionEvent<T1, T2, T3> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3> operator +(ActionEvent<T1, T2, T3> a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3> operator -(ActionEvent<T1, T2, T3> a, Action listener)
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
        public static ActionEvent<T1, T2, T3> operator +(ActionEvent<T1, T2, T3> a, Action<T1> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3> operator -(ActionEvent<T1, T2, T3> a, Action<T1> listener)
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
        public static ActionEvent<T1, T2, T3> operator +(ActionEvent<T1, T2, T3> a, Action<T1, T2> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3> operator -(ActionEvent<T1, T2, T3> a, Action<T1, T2> listener)
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
        public static ActionEvent<T1, T2, T3> operator +(ActionEvent<T1, T2, T3> a, Action<T1, T2, T3> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3> operator -(ActionEvent<T1, T2, T3> a, Action<T1, T2, T3> listener)
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
        public ActionEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public ActionEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
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
    /// With ActionEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// </summary>
    public class ActionEvent<T1, T2, T3, T4> : ActionEvent<T1, T2, T3>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator +(ActionEvent<T1, T2, T3, T4> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator -(ActionEvent<T1, T2, T3, T4> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator +(ActionEvent<T1, T2, T3, T4> a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator -(ActionEvent<T1, T2, T3, T4> a, Action listener)
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
        public static ActionEvent<T1, T2, T3, T4> operator +(ActionEvent<T1, T2, T3, T4> a, Action<T1> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator -(ActionEvent<T1, T2, T3, T4> a, Action<T1> listener)
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
        public static ActionEvent<T1, T2, T3, T4> operator +(ActionEvent<T1, T2, T3, T4> a, Action<T1, T2> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator -(ActionEvent<T1, T2, T3, T4> a, Action<T1, T2> listener)
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
        public static ActionEvent<T1, T2, T3, T4> operator +(ActionEvent<T1, T2, T3, T4> a, Action<T1, T2, T3> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator -(ActionEvent<T1, T2, T3, T4> a, Action<T1, T2, T3> listener)
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
        public static ActionEvent<T1, T2, T3, T4> operator +(ActionEvent<T1, T2, T3, T4> a, Action<T1, T2, T3, T4> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4> operator -(ActionEvent<T1, T2, T3, T4> a, Action<T1, T2, T3, T4> listener)
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
        public ActionEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public ActionEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
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
    /// With ActionEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// </summary>
    public class ActionEvent<T1, T2, T3, T4, T5> : ActionEvent<T1, T2, T3, T4>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator +(ActionEvent<T1, T2, T3, T4, T5> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator -(ActionEvent<T1, T2, T3, T4, T5> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator +(ActionEvent<T1, T2, T3, T4, T5> a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator -(ActionEvent<T1, T2, T3, T4, T5> a, Action listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5> operator +(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator -(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5> operator +(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator -(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5> operator +(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2, T3> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator -(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2, T3> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5> operator +(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2, T3, T4> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator -(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2, T3, T4> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5> operator +(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2, T3, T4, T5> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5> operator -(ActionEvent<T1, T2, T3, T4, T5> a, Action<T1, T2, T3, T4, T5> listener)
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
        public ActionEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public ActionEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
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
    /// With ActionEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// </summary>
    public class ActionEvent<T1, T2, T3, T4, T5, T6> : ActionEvent<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator +(ActionEvent<T1, T2, T3, T4, T5, T6> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator -(ActionEvent<T1, T2, T3, T4, T5, T6> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator +(ActionEvent<T1, T2, T3, T4, T5, T6> a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator -(ActionEvent<T1, T2, T3, T4, T5, T6> a, Action listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator +(ActionEvent<T1, T2, T3, T4, T5, T6> a, Action<T1> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator -(ActionEvent<T1, T2, T3, T4, T5, T6> a, Action<T1> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator +(ActionEvent<T1, T2, T3, T4, T5, T6> a, Action<T1, T2> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator -(ActionEvent<T1, T2, T3, T4, T5, T6> a, Action<T1, T2> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator +(ActionEvent<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator -(ActionEvent<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator +(ActionEvent<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3, T4> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator -(ActionEvent<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3, T4> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator +(ActionEvent<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3, T4, T5> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator -(ActionEvent<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3, T4, T5> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator +(ActionEvent<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3, T4, T5, T6> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6> operator -(ActionEvent<T1, T2, T3, T4, T5, T6> a, Action<T1, T2, T3, T4, T5, T6> listener)
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
        public ActionEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public ActionEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
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
    /// With ActionEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// </summary>
    public class ActionEvent<T1, T2, T3, T4, T5, T6, T7> : ActionEvent<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator +(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator -(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator +(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator -(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator +(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action<T1> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator -(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action<T1> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator +(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator -(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator +(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator -(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator +(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator -(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator +(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4, T5> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator -(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4, T5> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator +(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4, T5, T6> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator -(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4, T5, T6> listener)
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
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator +(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4, T5, T6, T7> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static ActionEvent<T1, T2, T3, T4, T5, T6, T7> operator -(ActionEvent<T1, T2, T3, T4, T5, T6, T7> a, Action<T1, T2, T3, T4, T5, T6, T7> listener)
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
        public ActionEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public ActionEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
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
