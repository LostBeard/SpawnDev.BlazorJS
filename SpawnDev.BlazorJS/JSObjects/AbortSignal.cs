using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AbortSignal interface represents a signal object that allows you to communicate with a DOM request (such as a fetch request) and abort it if required via an AbortController object.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/AbortSignal
    /// </summary>
    public class AbortSignal : EventTarget
    {
        public AbortSignal(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A Boolean that indicates whether the request(s) the signal is communicating with is/are aborted (true) or not (false).
        /// </summary>
        public bool Aborted => JSRef.Get<bool>("aborted");
        /// <summary>
        /// The reason read-only property returns a JavaScript value that indicates the abort reason.<br />
        /// </summary>
        /// <typeparam name="T">Type to read the property reason as</typeparam>
        /// <returns></returns>
        public T GetReason<T>() => JSRef.Get<T>("reason");

        #region Methods
        public void ThrowIfAborted() => JSRef.CallVoid("throwIfAborted");
        #endregion

        #region Events
        /// <summary>
        /// Invoked when the asynchronous operations the signal is communicating with is/are aborted. Also available via the onabort property.
        /// </summary>
        public JSEventCallback<Event> OnAbort { get => new JSEventCallback<Event>("abort", AddEventListener, RemoveEventListener); set { } }
        #endregion

        #region Static Methods
        /// <summary>
        /// The AbortSignal.abort() static method returns an AbortSignal that is already set as aborted (and which does not trigger an abort event).
        /// </summary>
        /// <returns></returns>
        public static AbortSignal Abort() => JS.Call<AbortSignal>($"{nameof(AbortSignal)}.abort");
        /// <summary>
        /// The AbortSignal.abort() static method returns an AbortSignal that is already set as aborted (and which does not trigger an abort event).
        /// </summary>
        /// <param name="reason">The reason why the operation was aborted, which can be any JavaScript value. If not specified, the reason is set to "AbortError" DOMException.</param>
        /// <returns></returns>
        public static AbortSignal Abort(object reason) => JS.Call<AbortSignal>($"{nameof(AbortSignal)}.abort", reason);
        /// <summary>
        /// The AbortSignal.timeout() static method returns an AbortSignal that will automatically abort after a specified time.
        /// </summary>
        /// <param name="time">The "active" time in milliseconds before the returned AbortSignal will abort.</param>
        /// <returns>An AbortSignal.</returns>
        public static AbortSignal Timeout(float time) => JS.Call<AbortSignal>($"{nameof(AbortSignal)}.abort", time);
        #endregion
    }
}
