namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Container for a typed Callback Action pair
    /// </summary>
    internal class JEventCallbackInfo : JSEventCallbackInfoBase
    {
        /// <summary>
        /// The Callback
        /// </summary>
        public ActionCallback Callback { get; }
        /// <summary>
        /// The Action
        /// </summary>
        public Action Action { get; }
        public JEventCallbackInfo(Action action, ActionCallback callback) => (Action, Callback) = (action, callback);
    }/// <summary>
     /// Container for a typed Callback Action pair
     /// </summary>
     /// <typeparam name="T1"></typeparam>
    internal class JEventCallbackInfo<T1> : JSEventCallbackInfoBase
    {
        /// <summary>
        /// The Callback
        /// </summary>
        public ActionCallback<T1> Callback { get; }
        /// <summary>
        /// The Action
        /// </summary>
        public Action<T1> Action { get; }
        public JEventCallbackInfo(Action<T1> action, ActionCallback<T1> callback) => (Action, Callback) = (action, callback);
    }
    /// <summary>
    /// Container for a typed Callback Action pair
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    internal class JEventCallbackInfo<T1, T2> : JSEventCallbackInfoBase
    {
        /// <summary>
        /// The Callback
        /// </summary>
        public ActionCallback<T1, T2> Callback { get; }
        /// <summary>
        /// The Action
        /// </summary>
        public Action<T1, T2> Action { get; }
        public JEventCallbackInfo(Action<T1, T2> action, ActionCallback<T1, T2> callback) => (Action, Callback) = (action, callback);
    }
    /// <summary>
    /// Container for a typed Callback Action pair
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    internal class JEventCallbackInfo<T1, T2, T3> : JSEventCallbackInfoBase
    {
        /// <summary>
        /// The Callback
        /// </summary>
        public ActionCallback<T1, T2, T3> Callback { get; }
        /// <summary>
        /// The Action
        /// </summary>
        public Action<T1, T2, T3> Action { get; }
        public JEventCallbackInfo(Action<T1, T2, T3> action, ActionCallback<T1, T2, T3> callback) => (Action, Callback) = (action, callback);
    }
    /// <summary>
    /// Container for a typed Callback Action pair
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    internal class JEventCallbackInfo<T1, T2, T3, T4> : JSEventCallbackInfoBase
    {
        /// <summary>
        /// The Callback
        /// </summary>
        public ActionCallback<T1, T2, T3, T4> Callback { get; }
        /// <summary>
        /// The Action
        /// </summary>
        public Action<T1, T2, T3, T4> Action { get; }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="action"></param>
        /// <param name="callback"></param>
        public JEventCallbackInfo(Action<T1, T2, T3, T4> action, ActionCallback<T1, T2, T3, T4> callback) => (Action, Callback) = (action, callback);
    }
    /// <summary>
    /// Container for a typed Callback Action pair
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    internal class JEventCallbackInfo<T1, T2, T3, T4, T5> : JSEventCallbackInfoBase
    {
        /// <summary>
        /// The Callback
        /// </summary>
        public ActionCallback<T1, T2, T3, T4, T5> Callback { get; }
        /// <summary>
        /// The Action
        /// </summary>
        public Action<T1, T2, T3, T4, T5> Action { get; }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="action"></param>
        /// <param name="callback"></param>
        public JEventCallbackInfo(Action<T1, T2, T3, T4, T5> action, ActionCallback<T1, T2, T3, T4, T5> callback) => (Action, Callback) = (action, callback);
    }
    /// <summary>
    /// Container for a typed Callback Action pair
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    internal class JEventCallbackInfo<T1, T2, T3, T4, T5, T6> : JSEventCallbackInfoBase
    {
        /// <summary>
        /// The Callback
        /// </summary>
        public ActionCallback<T1, T2, T3, T4, T5, T6> Callback { get; }
        /// <summary>
        /// The Action
        /// </summary>
        public Action<T1, T2, T3, T4, T5, T6> Action { get; }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="action"></param>
        /// <param name="callback"></param>
        public JEventCallbackInfo(Action<T1, T2, T3, T4, T5, T6> action, ActionCallback<T1, T2, T3, T4, T5, T6> callback) => (Action, Callback) = (action, callback);
    }
    /// <summary>
    /// Container for a typed Callback Action pair
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    internal class JEventCallbackInfo<T1, T2, T3, T4, T5, T6, T7> : JSEventCallbackInfoBase
    {
        /// <summary>
        /// The Callback
        /// </summary>
        public ActionCallback<T1, T2, T3, T4, T5, T6, T7> Callback { get; }
        /// <summary>
        /// The Action
        /// </summary>
        public Action<T1, T2, T3, T4, T5, T6, T7> Action { get; }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="action"></param>
        /// <param name="callback"></param>
        public JEventCallbackInfo(Action<T1, T2, T3, T4, T5, T6, T7> action, ActionCallback<T1, T2, T3, T4, T5, T6, T7> callback) => (Action, Callback) = (action, callback);
    }
}
