using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AbortController interface represents a controller object that allows you to abort one or more Web requests as and when desired.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AbortController
    /// </summary>
    public class AbortController : JSObject
    {
        #region Constructors
        /// <summary>
        /// The AbortController() constructor creates a new AbortController object instance.
        /// </summary>
        public AbortController() : base(JS.New(nameof(AbortController))) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AbortController(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// Returns an AbortSignal object instance, which can be used to communicate with, or to abort, a DOM request.
        /// </summary>
        public AbortSignal Signal => JSRef!.Get<AbortSignal>("signal");
        #endregion

        #region Methods
        /// <summary>
        /// The abort() method of the AbortController interface aborts a DOM request before it has completed. This is able to abort fetch requests, the consumption of any response bodies, or streams.
        /// </summary>
        public void Abort() => JSRef!.CallVoid("abort");
        /// <summary>
        /// The abort() method of the AbortController interface aborts a DOM request before it has completed. This is able to abort fetch requests, the consumption of any response bodies, or streams.
        /// </summary>
        /// <param name="reason">The reason why the operation was aborted, which can be any JavaScript value. If not specified, the reason is set to "AbortError" DOMException.</param>
        public void Abort(object reason) => JSRef!.CallVoid("abort", reason);
        #endregion
    }
}
