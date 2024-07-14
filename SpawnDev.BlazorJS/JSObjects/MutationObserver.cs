using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MutationObserver interface provides the ability to watch for changes being made to the DOM tree. It is designed as a replacement for the older Mutation Events feature, which was part of the DOM3 Events specification.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MutationObserver
    /// </summary>
    public class MutationObserver : JSObject
    {
        #region Constructors
        /// <summary>
        /// Creates a new instance of MutationObserver
        /// </summary>
        /// <param name="callback"></param>
        public MutationObserver(ActionCallback<Array<MutationRecord>, MutationObserver> callback) : base(JS.New(nameof(MutationObserver), callback)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MutationObserver(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Methods
        /// <summary>
        /// Stops the MutationObserver instance from receiving further notifications until and unless observe() is called again.
        /// </summary>
        public void Disconnect() => JSRef!.CallVoid("disconnect");
        /// <summary>
        /// Configures the MutationObserver to begin receiving notifications through its callback function when DOM changes matching the given options occur.
        /// </summary>
        /// <param name="target">A DOM Node (which may be an Element) within the DOM tree to watch for changes, or to be the root of a subtree of nodes to be watched.</param>
        /// <param name="options">An object providing options that describe which DOM mutations should be reported to mutationObserver's callback. At a minimum, one of childList, attributes, and/or characterData must be true when you call observe(). Otherwise, a TypeError exception will be thrown.</param>
        public void Observe(Node target, MutationObserveOptions options) => JSRef!.CallVoid("observe", target, options);
        /// <summary>
        /// Removes all pending notifications from the MutationObserver's notification queue and returns them in a new Array of MutationRecord objects.
        /// </summary>
        /// <returns></returns>
        public MutationRecord[] TakeRecords() => JSRef!.Call<MutationRecord[]>("takeRecords");
        #endregion
    }
}
