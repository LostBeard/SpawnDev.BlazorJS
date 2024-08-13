namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// An extension event
    /// </summary>
    public class CallbackEvent
    {
        /// <summary>
        /// Adds an event handler
        /// </summary>
        public static CallbackEvent operator +(CallbackEvent a, Callback callback)
        {
            a.On(callback);
            return a;
        }
        /// <summary>
        /// Removes an event handler
        /// </summary>
        public static CallbackEvent operator -(CallbackEvent a, Callback callback)
        {
            a.Off(callback);
            return a;
        }
        /// <summary>
        /// Contains Callback references that will be disposed when an equal number of add and remove listener calls are made
        /// </summary>
        protected static CallbackRef CallbackRef = new();
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public CallbackEvent(Action<Callback> on, Action<Callback>? off = null)
        {
            _On = on;
            _Off = off;
        }
        /// <summary>
        /// Set On Off methods
        /// </summary>
        public CallbackEvent(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null)
        {
            _On = (callback) => on(eventName, callback);
            _Off = off == null ? null : (callback) => off(eventName, callback);
        }
        private Action<Callback> _On { get; set; }
        private Action<Callback>? _Off { get; set; }
        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        public void On(Callback callback) => _On.Invoke(callback);
        /// <summary>
        /// Stop listening to this event. The listener argument is the listener to remove.
        /// </summary>
        public void Off(Callback callback) => _Off?.Invoke(callback);
    }
}
