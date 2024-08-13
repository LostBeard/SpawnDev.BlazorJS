using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Worker interface of the Web Workers API represents a background task that can be created via script, which can send messages back to its creator.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Worker
    /// </summary>
    public class Worker : EventTarget, IMessagePort
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Worker(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a dedicated web worker that executes the script at the specified URL. This also works for Blob URLs.
        /// </summary>
        /// <param name="url"></param>
        public Worker(string url) : base(JS.New(nameof(Worker), url)) { }
        #endregion
        #region Methods
        /// <summary>
        /// Immediately terminates the worker. This does not let worker finish its operations; it is halted at once. ServiceWorker instances do not support this method.
        /// </summary>
        public void Terminate() => JSRef!.CallVoid("terminate");
        /// <summary>
        /// Sends a message — consisting of any JavaScript object — to the worker's inner scope.
        /// </summary>
        /// <param name="message"></param>
        public void PostMessage(object message) => JSRef!.CallVoid("postMessage", message);
        /// <summary>
        /// Sends a message — consisting of any JavaScript object — to the worker's inner scope.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="transfer"></param>
        public void PostMessage(object message, object[] transfer) => JSRef!.CallVoid("postMessage", message, transfer);
        #endregion
        #region Events
        /// <summary>
        /// Fires when an error occurs in the worker.
        /// </summary>
        public ActionEvent<Event> OnError { get => new ActionEvent<Event>("error", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fires when the worker's parent receives a message from that worker.
        /// </summary>
        public ActionEvent<MessageEvent> OnMessage { get => new ActionEvent<MessageEvent>("message", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fires when a Worker object receives a message that can't be deserialized.
        /// </summary>
        public ActionEvent<MessageEvent> OnMessageError { get => new ActionEvent<MessageEvent>("messageerror", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}
