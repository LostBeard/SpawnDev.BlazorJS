using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SyncEvent interface of the Background Synchronization API represents a sync action that is dispatched on the ServiceWorkerGlobalScope of a ServiceWorker.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/SyncEvent
    /// </summary>
    public class SyncEvent : ExtendableEvent
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public SyncEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns true if the user agent will not make further synchronization attempts after the current attempt.
        /// </summary>
        public bool LastChance => JSRef!.Get<bool>("lastChance");
        /// <summary>
        /// Returns the developer-defined identifier for this SyncEvent.
        /// </summary>
        public string Tag => JSRef!.Get<string>("tag");
    }
}
