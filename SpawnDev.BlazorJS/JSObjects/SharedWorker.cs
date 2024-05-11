using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SharedWorker interface represents a specific kind of worker that can be accessed from several browsing contexts, such as several windows, iframes or even workers. They implement an interface different than dedicated workers and have a different global scope, SharedWorkerGlobalScope.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/SharedWorker
    /// </summary>
    public class SharedWorker : EventTarget
    {
        /// <summary>
        /// Returns a MessagePort object used to communicate with and control the shared worker.
        /// </summary>
        public MessagePort Port => JSRef!.Get<MessagePort>("port");
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public SharedWorker(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The SharedWorker() constructor creates a SharedWorker object that executes the script at the specified URL. This script must obey the same-origin policy.
        /// </summary>
        /// <param name="url"></param>
        public SharedWorker(string url) : base(JS.New(nameof(SharedWorker), url)) { }
        /// <summary>
        /// The SharedWorker() constructor creates a SharedWorker object that executes the script at the specified URL. This script must obey the same-origin policy.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="name"></param>
        public SharedWorker(string url, string name) : base(JS.New(nameof(SharedWorker), url, name)) { }
        /// <summary>
        /// Fires when an error occurs in the shared worker.
        /// </summary>
        public JSEventCallback<Event> OnError { get => new JSEventCallback<Event>("error", AddEventListener, RemoveEventListener); set { } }
    }
}
