using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SharedWorkerGlobalScope object (the SharedWorker global scope) is accessible through the self keyword. Some additional global functions, namespaces objects, and constructors, not typically associated with the worker global scope, but available on it, are listed in the JavaScript Reference. See the complete list of functions available to workers.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/SharedWorkerGlobalScope
    /// </summary>
    public class SharedWorkerGlobalScope : WorkerGlobalScope
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public SharedWorkerGlobalScope(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Discards any tasks queued in the WorkerGlobalScope's event loop, effectively closing this particular scope.
        /// </summary>
        public void Close() => JSRef!.CallVoid("close");
        /// <summary>
        /// The name that the SharedWorker was (optionally) given when it was created using the SharedWorker() constructor. This is mainly useful for debugging purposes.
        /// </summary>
        public string Name => JSRef!.Get<string>("name");
        /// <summary>
        /// Fired on shared workers when a new client connects.
        /// </summary>
        public JSEventCallback<MessageEvent> OnConnect { get => new JSEventCallback<MessageEvent>("connect", AddEventListener, RemoveEventListener); set { } }
    }
}
