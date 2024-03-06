using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DedicatedWorkerGlobalScope object (the Worker global scope) is accessible through the self keyword. Some additional global functions, namespaces objects, and constructors, not typically associated with the worker global scope, but available on it, are listed in the JavaScript Reference. See also: Functions available to workers.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/DedicatedWorkerGlobalScope
    /// </summary>
    public class DedicatedWorkerGlobalScope : WorkerGlobalScope, IMessagePort
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DedicatedWorkerGlobalScope(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Discards any tasks queued in the WorkerGlobalScope's event loop, effectively closing this particular scope.
        /// </summary>
        public void Close() => JSRef.CallVoid("close");
        /// <summary>
        /// The name that the SharedWorker was (optionally) given when it was created using the SharedWorker() constructor. This is mainly useful for debugging purposes.
        /// </summary>
        public string Name => JSRef.Get<string>("name");
        /// <summary>
        /// Sends a message from the port, and optionally, transfers ownership of objects to other browsing contexts.
        /// </summary>
        /// <param name="message"></param>
        public void PostMessage(object message) => JSRef.CallVoid("postMessage", message);
        /// <summary>
        /// Sends a message from the port, and optionally, transfers ownership of objects to other browsing contexts.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="transfer"></param>
        public void PostMessage(object message, object[] transfer) => JSRef.CallVoid("postMessage", message, transfer);
        /// <summary>
        /// Fired when the worker receives a message from its parent.
        /// </summary>
        public JSEventCallback<MessageEvent> OnMessage { get => new JSEventCallback<MessageEvent>(o => AddEventListener("message", o), o => RemoveEventListener("message", o)); set { } }
        /// <summary>
        /// Fired when a worker receives a message that can't be deserialized.
        /// </summary>
        public JSEventCallback<MessageEvent> OnMessageError { get => new JSEventCallback<MessageEvent>(o => AddEventListener("messageerror", o), o => RemoveEventListener("messageerror", o)); set { } }
    }
}
