using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The EventTarget interface is implemented by objects that can receive events and may have listeners for them. In other words, any target of events implements the three methods associated with this interface.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/EventTarget
    /// </summary>
    public class EventTarget : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public EventTarget(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The EventTarget() constructor creates a new EventTarget object instance.
        /// </summary>
        public EventTarget() : base(JS.New(nameof(EventTarget))) { }
        /// <summary>
        /// The dispatchEvent() method of the EventTarget sends an Event to the object, (synchronously) invoking the affected event listeners in the appropriate order. The normal event processing rules (including the capturing and optional bubbling phase) also apply to events dispatched manually with dispatchEvent().
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public bool DispatchEvent(Event @event) => JSRef!.Call<bool>("dispatchEvent", @event);
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        public void AddEventListener(string type, Callback listener) => JSRef!.CallVoid("addEventListener", type, listener);
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <param name="type">A case-sensitive string representing the event type to listen for.</param>
        /// <param name="listener">The object that receives a notification (an object that implements the Event interface) when an event of the specified type occurs. This must be null, an object with a handleEvent() method, or a JavaScript function. See The event listener callback for details on the callback itself.</param>
        /// <param name="useCapture">A boolean value indicating whether events of this type will be dispatched to the registered listener before being dispatched to any EventTarget beneath it in the DOM tree. Events that are bubbling upward through the tree will not trigger a listener designated to use capture. Event bubbling and capturing are two ways of propagating events that occur in an element that is nested within another element, when both elements have registered a handle for that event. The event propagation mode determines the order in which elements receive the event. See DOM Level 3 Events and JavaScript Event order for a detailed explanation. If not specified, useCapture defaults to false.</param>
        public void AddEventListener(string type, Callback listener, bool useCapture) => JSRef!.CallVoid("addEventListener", type, listener, useCapture);
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <param name="type">A case-sensitive string representing the event type to listen for.</param>
        /// <param name="listener">The object that receives a notification (an object that implements the Event interface) when an event of the specified type occurs. This must be null, an object with a handleEvent() method, or a JavaScript function. See The event listener callback for details on the callback itself.</param>
        /// <param name="options">An object that specifies characteristics about the event listener</param>
        public void AddEventListener(string type, Callback listener, AddEventListenerOptions options) => JSRef!.CallVoid("addEventListener", type, listener, options);
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        public void RemoveEventListener(string type, Callback listener) => JSRef!.CallVoid("removeEventListener", type, listener);
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void RemoveEventListener(string type, Callback listener, bool useCapture) => JSRef!.CallVoid("removeEventListener", type, listener, useCapture);
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void RemoveEventListener(string type, Callback listener, AddEventListenerOptions options) => JSRef!.CallVoid("removeEventListener", type, listener, options);

        
        // AddEventListener and RemoveEventListener that support using actions with auto reference handling
        static Dictionary<object, CallBackInfo> CallBackInfos { get; } = new Dictionary<object, CallBackInfo>();
        #region Func EventHandlers
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void AddEventListener<TResult>(string type, Func<TResult> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo { Callback = new FuncCallback<TResult>(listener) };
                CallBackInfos[listener] = info;
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, useCapture);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void RemoveEventListener<TResult>(string type, Func<TResult> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, useCapture);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void AddEventListener<T1, TResult>(string type, Func<T1, TResult> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo { Callback = new FuncCallback<T1, TResult>(listener) };
                CallBackInfos[listener] = info;
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, useCapture);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void RemoveEventListener<T1, TResult>(string type, Func<T1, TResult> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, useCapture);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void AddEventListener<T1, T2, TResult>(string type, Func<T1, T2, TResult> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo { Callback = new FuncCallback<T1, T2, TResult>(listener) };
                CallBackInfos[listener] = info;
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, useCapture);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void RemoveEventListener<T1, T2, TResult>(string type, Func<T1, T2, TResult> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, useCapture);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void AddEventListener<T1, T2, T3, TResult>(string type, Func<T1, T2, T3, TResult> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo { Callback = new FuncCallback<T1, T2, T3, TResult>(listener) };
                CallBackInfos[listener] = info;
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, useCapture);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void RemoveEventListener<T1, T2, T3, TResult>(string type, Func<T1, T2, T3, TResult> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, useCapture);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void AddEventListener<T1, T2, T3, T4, TResult>(string type, Func<T1, T2, T3, T4, TResult> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo { Callback = new FuncCallback<T1, T2, T3, T4, TResult>(listener) };
                CallBackInfos[listener] = info;
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, useCapture);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void RemoveEventListener<T1, T2, T3, T4, TResult>(string type, Func<T1, T2, T3, T4, TResult> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, useCapture);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        // **************************************************************************************************************************************
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void AddEventListener<TResult>(string type, Func<TResult> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo();
                CallBackInfos[listener] = info;
                if (options.Once.HasValue && options.Once.Value)
                {
                    info.Callback = new FuncCallback<TResult>(() => {
                        var ret = listener();
                        info.RefCount--;
                        if (info.RefCount <= 0)
                        {
                            CallBackInfos.Remove(listener);
                            info.Callback.Dispose();
                        }
                        return ret;
                    });
                }
                else
                {
                    info.Callback = new FuncCallback<TResult>(listener);
                }
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, options);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void RemoveEventListener<TResult>(string type, Func<TResult> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, options);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void AddEventListener<T1, TResult>(string type, Func<T1, TResult> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo();
                CallBackInfos[listener] = info;
                if (options.Once.HasValue && options.Once.Value)
                {
                    info.Callback = new FuncCallback<T1, TResult>((t1) => {
                        var ret = listener(t1);
                        info.RefCount--;
                        if (info.RefCount <= 0)
                        {
                            CallBackInfos.Remove(listener);
                            info.Callback.Dispose();
                        }
                        return ret;
                    });
                }
                else
                {
                    info.Callback = new FuncCallback<T1, TResult>(listener);
                }
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, options);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void RemoveEventListener<T1, TResult>(string type, Func<T1, TResult> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, options);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void AddEventListener<T1, T2, TResult>(string type, Func<T1, T2, TResult> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo();
                CallBackInfos[listener] = info;
                if (options.Once.HasValue && options.Once.Value)
                {
                    info.Callback = new FuncCallback<T1, T2, TResult>((t1, t2) => {
                        var ret = listener(t1, t2);
                        info.RefCount--;
                        if (info.RefCount <= 0)
                        {
                            CallBackInfos.Remove(listener);
                            info.Callback.Dispose();
                        }
                        return ret;
                    });
                }
                else
                {
                    info.Callback = new FuncCallback<T1, T2, TResult>(listener);
                }
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, options);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void RemoveEventListener<T1, T2, TResult>(string type, Func<T1, T2, TResult> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, options);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void AddEventListener<T1, T2, T3, TResult>(string type, Func<T1, T2, T3, TResult> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo();
                CallBackInfos[listener] = info;
                if (options.Once.HasValue && options.Once.Value)
                {
                    info.Callback = new FuncCallback<T1, T2, T3, TResult>((t1, t2, t3) => {
                        var ret = listener(t1, t2, t3);
                        info.RefCount--;
                        if (info.RefCount <= 0)
                        {
                            CallBackInfos.Remove(listener);
                            info.Callback.Dispose();
                        }
                        return ret;
                    });
                }
                else
                {
                    info.Callback = new FuncCallback<T1, T2, T3, TResult>(listener);
                }
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, options);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void RemoveEventListener<T1, T2, T3, TResult>(string type, Func<T1, T2, T3, TResult> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, options);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void AddEventListener<T1, T2, T3, T4, TResult>(string type, Func<T1, T2, T3, T4, TResult> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo();
                CallBackInfos[listener] = info;
                if (options.Once.HasValue && options.Once.Value)
                {
                    info.Callback = new FuncCallback<T1, T2, T3, T4, TResult>((t1, t2, t3, t4) => {
                        var ret = listener(t1, t2, t3, t4);
                        info.RefCount--;
                        if (info.RefCount <= 0)
                        {
                            CallBackInfos.Remove(listener);
                            info.Callback.Dispose();
                        }
                        return ret;
                    });
                }
                else
                {
                    info.Callback = new FuncCallback<T1, T2, T3, T4, TResult>(listener);
                }
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, options);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void RemoveEventListener<T1, T2, T3, T4, TResult>(string type, Func<T1, T2, T3, T4, TResult> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, options);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        #endregion
        #region Action EventHandlers
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void AddEventListener(string type, Action listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo { Callback = new ActionCallback(listener) };
                CallBackInfos[listener] = info;
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, useCapture);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void RemoveEventListener(string type, Action listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, useCapture);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void AddEventListener<T1>(string type, Action<T1> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo { Callback = new ActionCallback<T1>(listener) };
                CallBackInfos[listener] = info;
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, useCapture);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void RemoveEventListener<T1>(string type, Action<T1> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, useCapture);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void AddEventListener<T1, T2>(string type, Action<T1, T2> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo { Callback = new ActionCallback<T1, T2>(listener) };
                CallBackInfos[listener] = info;
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, useCapture);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void RemoveEventListener<T1, T2>(string type, Action<T1, T2> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, useCapture);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void AddEventListener<T1, T2, T3>(string type, Action<T1, T2, T3> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo { Callback = new ActionCallback<T1, T2, T3>(listener) };
                CallBackInfos[listener] = info;
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, useCapture);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void RemoveEventListener<T1, T2, T3>(string type, Action<T1, T2, T3> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, useCapture);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void AddEventListener<T1, T2, T3, T4>(string type, Action<T1, T2, T3, T4> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo { Callback = new ActionCallback<T1, T2, T3, T4>(listener) };
                CallBackInfos[listener] = info;
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, useCapture);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void RemoveEventListener<T1, T2, T3, T4>(string type, Action<T1, T2, T3, T4> listener, bool useCapture = false)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, useCapture);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        // **************************************************************************************************************************************
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void AddEventListener(string type, Action listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo();
                CallBackInfos[listener] = info;
                if (options.Once.HasValue && options.Once.Value)
                {
                    info.Callback = new ActionCallback(() => {
                        listener();
                        info.RefCount--;
                        if (info.RefCount <= 0)
                        {
                            CallBackInfos.Remove(listener);
                            info.Callback.Dispose();
                        }
                    });
                }
                else
                {
                    info.Callback = new ActionCallback(listener);
                }
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, options);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void RemoveEventListener(string type, Action listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, options);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void AddEventListener<T1>(string type, Action<T1> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo();
                CallBackInfos[listener] = info;
                if (options.Once.HasValue && options.Once.Value)
                {
                    info.Callback = new ActionCallback<T1>((t1) => {
                        listener(t1);
                        info.RefCount--;
                        if (info.RefCount <= 0)
                        {
                            CallBackInfos.Remove(listener);
                            info.Callback.Dispose();
                        }
                    });
                }
                else
                {
                    info.Callback = new ActionCallback<T1>(listener);
                }
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, options);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void RemoveEventListener<T1>(string type, Action<T1> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, options);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void AddEventListener<T1, T2>(string type, Action<T1, T2> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo();
                CallBackInfos[listener] = info;
                if (options.Once.HasValue && options.Once.Value)
                {
                    info.Callback = new ActionCallback<T1, T2>((t1, t2) => {
                        listener(t1, t2);
                        info.RefCount--;
                        if (info.RefCount <= 0)
                        {
                            CallBackInfos.Remove(listener);
                            info.Callback.Dispose();
                        }
                    });
                }
                else
                {
                    info.Callback = new ActionCallback<T1, T2>(listener);
                }
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, options);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void RemoveEventListener<T1, T2>(string type, Action<T1, T2> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, options);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void AddEventListener<T1, T2, T3>(string type, Action<T1, T2, T3> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo();
                CallBackInfos[listener] = info;
                if (options.Once.HasValue && options.Once.Value)
                {
                    info.Callback = new ActionCallback<T1, T2, T3>((t1, t2, t3) => {
                        listener(t1, t2, t3);
                        info.RefCount--;
                        if (info.RefCount <= 0)
                        {
                            CallBackInfos.Remove(listener);
                            info.Callback.Dispose();
                        }
                    });
                }
                else
                {
                    info.Callback = new ActionCallback<T1, T2, T3>(listener);
                }
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, options);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void RemoveEventListener<T1, T2, T3>(string type, Action<T1, T2, T3> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, options);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void AddEventListener<T1, T2, T3, T4>(string type, Action<T1, T2, T3, T4> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                info = new CallBackInfo();
                CallBackInfos[listener] = info;
                if (options.Once.HasValue && options.Once.Value)
                {
                    info.Callback = new ActionCallback<T1, T2, T3, T4>((t1, t2, t3, t4) => {
                        listener(t1, t2, t3, t4);
                        info.RefCount--;
                        if (info.RefCount <= 0)
                        {
                            CallBackInfos.Remove(listener);
                            info.Callback.Dispose();
                        }
                    });
                }
                else
                {
                    info.Callback = new ActionCallback<T1, T2, T3, T4>(listener);
                }
            }
            info.RefCount++;
            AddEventListener(type, info.Callback, options);
        }
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void RemoveEventListener<T1, T2, T3, T4>(string type, Action<T1, T2, T3, T4> listener, AddEventListenerOptions options)
        {
            if (!CallBackInfos.TryGetValue(listener, out CallBackInfo? info))
            {
                return;
            }
            info.RefCount--;
            RemoveEventListener(type, info.Callback, options);
            if (info.RefCount <= 0)
            {
                CallBackInfos.Remove(listener);
                info.Callback.Dispose();
            }
        }
        #endregion

        /// <summary>
        /// Used internally to track the number of calls 
        /// </summary>
        class CallBackInfo
        {
            /// <summary>
            /// AddEventListener call count - RemoveEventListener call count<br/>
            /// Callback will be disposed when RefCount == 0
            /// </summary>
            public int RefCount { get; set; }
            /// <summary>
            /// Holds a reference to the callback fo disposing when done using
            /// </summary>
            public Callback Callback { get; set; }
        }
    }
}