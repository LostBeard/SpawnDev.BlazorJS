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
        /// <param name="url">A string representing the URL of the script the worker will execute. It must obey the same-origin policy.</param>
        public SharedWorker(string url) : base(JS.New(nameof(SharedWorker), url)) { }
        /// <summary>
        /// The SharedWorker() constructor creates a SharedWorker object that executes the script at the specified URL. This script must obey the same-origin policy.
        /// </summary>
        /// <param name="url">A string representing the URL of the script the worker will execute. It must obey the same-origin policy.</param>
        /// <param name="name">A string specifying an identifying name for the SharedWorkerGlobalScope representing the scope of the worker, which is useful for creating new instances of the same SharedWorker and debugging.</param>
        public SharedWorker(string url, string name) : base(JS.New(nameof(SharedWorker), url, name)) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">A string representing the URL of the script the worker will execute. It must obey the same-origin policy.</param>
        /// <param name="options"></param>
        public SharedWorker(string url, SharedWorkerOptions options) : base(JS.New(nameof(SharedWorker), url, options)) { }
        /// <summary>
        /// Fires when an error occurs in the shared worker.
        /// </summary>
        public ActionEvent<Event> OnError { get => new ActionEvent<Event>("error", AddEventListener, RemoveEventListener); set { } }
    }
}
