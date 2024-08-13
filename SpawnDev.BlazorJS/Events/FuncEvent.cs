namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// With FuncEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// FuncEvent works just like ActionEvent but allows a return value.
    /// </summary>
    public class FuncEvent<TResult> : CallbackEvent
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<TResult> operator +(FuncEvent<TResult> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<TResult> operator -(FuncEvent<TResult> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<TResult> operator +(FuncEvent<TResult> a, Func<TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<TResult> operator -(FuncEvent<TResult> a, Func<TResult> listener)
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
        public FuncEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public FuncEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Func<TResult> listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Func<TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// With FuncEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// FuncEvent works just like ActionEvent but allows a return value.
    /// </summary>
    public class FuncEvent<T1, TResult> : FuncEvent<TResult>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, TResult> operator +(FuncEvent<T1, TResult> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, TResult> operator -(FuncEvent<T1, TResult> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, TResult> operator +(FuncEvent<T1, TResult> a, Func<TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, TResult> operator -(FuncEvent<T1, TResult> a, Func<TResult> listener)
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
        public static FuncEvent<T1, TResult> operator +(FuncEvent<T1, TResult> a, Func<T1, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, TResult> operator -(FuncEvent<T1, TResult> a, Func<T1, TResult> listener)
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
        public FuncEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public FuncEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Func<T1, TResult> listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Func<T1, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// With FuncEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// FuncEvent works just like ActionEvent but allows a return value.
    /// </summary>
    public class FuncEvent<T1, T2, TResult> : FuncEvent<T1, TResult>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, TResult> operator +(FuncEvent<T1, T2, TResult> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, TResult> operator -(FuncEvent<T1, T2, TResult> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, TResult> operator +(FuncEvent<T1, T2, TResult> a, Func<TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, TResult> operator -(FuncEvent<T1, T2, TResult> a, Func<TResult> listener)
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
        public static FuncEvent<T1, T2, TResult> operator +(FuncEvent<T1, T2, TResult> a, Func<T1, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, TResult> operator -(FuncEvent<T1, T2, TResult> a, Func<T1, TResult> listener)
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
        public static FuncEvent<T1, T2, TResult> operator +(FuncEvent<T1, T2, TResult> a, Func<T1, T2, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, TResult> operator -(FuncEvent<T1, T2, TResult> a, Func<T1, T2, TResult> listener)
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
        public FuncEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public FuncEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Func<T1, T2, TResult> listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Func<T1, T2, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// With FuncEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// FuncEvent works just like ActionEvent but allows a return value.
    /// </summary>
    public class FuncEvent<T1, T2, T3, TResult> : FuncEvent<T1, T2, TResult>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator +(FuncEvent<T1, T2, T3, TResult> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator -(FuncEvent<T1, T2, T3, TResult> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator +(FuncEvent<T1, T2, T3, TResult> a, Func<TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator -(FuncEvent<T1, T2, T3, TResult> a, Func<TResult> listener)
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
        public static FuncEvent<T1, T2, T3, TResult> operator +(FuncEvent<T1, T2, T3, TResult> a, Func<T1, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator -(FuncEvent<T1, T2, T3, TResult> a, Func<T1, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, TResult> operator +(FuncEvent<T1, T2, T3, TResult> a, Func<T1, T2, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator -(FuncEvent<T1, T2, T3, TResult> a, Func<T1, T2, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, TResult> operator +(FuncEvent<T1, T2, T3, TResult> a, Func<T1, T2, T3, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, TResult> operator -(FuncEvent<T1, T2, T3, TResult> a, Func<T1, T2, T3, TResult> listener)
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
        public FuncEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public FuncEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Func<T1, T2, T3, TResult> listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Func<T1, T2, T3, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// With FuncEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// FuncEvent works just like ActionEvent but allows a return value.
    /// </summary>
    public class FuncEvent<T1, T2, T3, T4, TResult> : FuncEvent<T1, T2, T3, TResult>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator +(FuncEvent<T1, T2, T3, T4, TResult> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator -(FuncEvent<T1, T2, T3, T4, TResult> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator +(FuncEvent<T1, T2, T3, T4, TResult> a, Func<TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator -(FuncEvent<T1, T2, T3, T4, TResult> a, Func<TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, TResult> operator +(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator -(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, TResult> operator +(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, T2, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator -(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, T2, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, TResult> operator +(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, T2, T3, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator -(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, T2, T3, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, TResult> operator +(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, T2, T3, T4, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, TResult> operator -(FuncEvent<T1, T2, T3, T4, TResult> a, Func<T1, T2, T3, T4, TResult> listener)
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
        public FuncEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public FuncEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Func<T1, T2, T3, T4, TResult> listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Func<T1, T2, T3, T4, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// With FuncEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// FuncEvent works just like ActionEvent but allows a return value.
    /// </summary>
    public class FuncEvent<T1, T2, T3, T4, T5, TResult> : FuncEvent<T1, T2, T3, T4, TResult>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, TResult> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, TResult> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, TResult> a, Func<TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, TResult> a, Func<TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, TResult> a, Func<T1, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, TResult> a, Func<T1, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, TResult> a, Func<T1, T2, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, TResult> a, Func<T1, T2, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, TResult> a, Func<T1, T2, T3, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, TResult> a, Func<T1, T2, T3, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, TResult> a, Func<T1, T2, T3, T4, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, TResult> a, Func<T1, T2, T3, T4, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, TResult> a, Func<T1, T2, T3, T4, T5, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, TResult> a, Func<T1, T2, T3, T4, T5, TResult> listener)
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
        public FuncEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public FuncEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Func<T1, T2, T3, T4, T5, TResult> listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Func<T1, T2, T3, T4, T5, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// With FuncEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// FuncEvent works just like ActionEvent but allows a return value.
    /// </summary>
    public class FuncEvent<T1, T2, T3, T4, T5, T6, TResult> : FuncEvent<T1, T2, T3, T4, T5, TResult>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Func<TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Func<TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Func<T1, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Func<T1, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Func<T1, T2, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Func<T1, T2, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Func<T1, T2, T3, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Func<T1, T2, T3, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Func<T1, T2, T3, T4, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Func<T1, T2, T3, T4, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Func<T1, T2, T3, T4, T5, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Func<T1, T2, T3, T4, T5, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Func<T1, T2, T3, T4, T5, T6, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, TResult> a, Func<T1, T2, T3, T4, T5, T6, TResult> listener)
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
        public FuncEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public FuncEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Func<T1, T2, T3, T4, T5, T6, TResult> listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Func<T1, T2, T3, T4, T5, T6, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
    /// <summary>
    /// With FuncEvent the operands += and -= can be used to attach and detach .Net callbacks to Javascript events.<br/>
    /// All reference handling is done automatically when events are added and removed.<br/>
    /// Parameters of event handlers may be omitted if not required.<br/>
    /// FuncEvent works just like ActionEvent but allows a return value.
    /// </summary>
    public class FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> : FuncEvent<T1, T2, T3, T4, T5, T6, TResult>
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<T1, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<T1, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<T1, T2, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<T1, T2, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<T1, T2, T3, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<T1, T2, T3, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<T1, T2, T3, T4, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<T1, T2, T3, T4, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<T1, T2, T3, T4, T5, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<T1, T2, T3, T4, T5, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<T1, T2, T3, T4, T5, T6, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<T1, T2, T3, T4, T5, T6, TResult> listener)
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
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator +(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<T1, T2, T3, T4, T5, T6, T7, TResult> listener)
        {
            a.On(CallbackRef.RefAdd(listener));
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> operator -(FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult> a, Func<T1, T2, T3, T4, T5, T6, T7, TResult> listener)
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
        public FuncEvent(Action<Callback> on, Action<Callback>? off = null) : base(on, off) { }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public FuncEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null) : base(eventName, on, off) { }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="listener"></param>
        public virtual void On(Func<T1, T2, T3, T4, T5, T6, T7, TResult> listener) => On(CallbackRef.RefAdd(listener));
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public virtual void Off(Func<T1, T2, T3, T4, T5, T6, T7, TResult> listener)
        {
            var callback = CallbackRef.RefGet(listener, false);
            if (callback == null) return;
            Off(callback);
            CallbackRef.RefDel(listener);
        }
    }
}
