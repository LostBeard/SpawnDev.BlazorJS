using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AbortSignal interface represents a signal object that allows you to communicate with a DOM request (such as a fetch request) and abort it if required via an AbortController object.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AbortSignal
    /// </summary>
    public class AbortSignal : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AbortSignal(IJSInProcessObjectReference _ref) : base(_ref) { }

        #region Properties
        /// <summary>
        /// A Boolean that indicates whether the request(s) the signal is communicating with is/are aborted (true) or not (false).
        /// </summary>
        public bool Aborted => JSRef!.Get<bool>("aborted");
        /// <summary>
        /// A JavaScript value providing the abort reason, once the signal has aborted.<br/>
        /// </summary>
        /// <typeparam name="T">Type to read the property reason as</typeparam>
        /// <returns></returns>
        public T GetReason<T>() => JSRef!.Get<T>("reason");
        /// <summary>
        /// A JavaScript value providing the abort reason, once the signal has aborted.<br/>
        /// </summary>
        public JSObject? Reason => JSRef!.Get<JSObject?>("reason");
        #endregion

        #region Methods
        /// <summary>
        /// Throws the signal's abort reason if the signal has been aborted; otherwise it does nothing.
        /// </summary>
        public void ThrowIfAborted() => JSRef!.CallVoid("throwIfAborted");
        #endregion

        #region Events
        /// <summary>
        /// Invoked when the asynchronous operations the signal is communicating with is/are aborted. Also available via the onabort property.
        /// </summary>
        public ActionEvent<Event> OnAbort { get => new ActionEvent<Event>("abort", AddEventListener, RemoveEventListener); set { } }
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
        public static AbortSignal Timeout(float time) => JS.Call<AbortSignal>($"{nameof(AbortSignal)}.timeout", time);
        /// <summary>
        /// Returns an AbortSignal that aborts when any of the given abort signals abort.
        /// </summary>
        /// <param name="signals"></param>
        /// <returns>
        /// An AbortSignal that is:<br/>
        /// - Already aborted, if any of the abort signals given is already aborted. The returned AbortSignal's reason will be already set to the reason of the first abort signal that was already aborted.<br/>
        /// - Asynchronously aborted, when any abort signal in iterable aborts. The reason will be set to the reason of the first abort signal that is aborted.
        /// </returns>
        public static AbortSignal Any(Array<AbortSignal> signals) => JS.Call<AbortSignal>($"{nameof(AbortSignal)}.any", signals);
        #endregion
    }
}
