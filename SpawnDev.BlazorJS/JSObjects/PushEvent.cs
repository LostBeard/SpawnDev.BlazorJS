using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PushEvent interface of the Push API represents a push message that has been received. This event is sent to the global scope of a ServiceWorker. It contains the information sent from an application server to a PushSubscription.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PushEvent
    /// </summary>
    public class PushEvent : ExtendableEvent
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PushEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a reference to a PushMessageData object containing data sent to the PushSubscription.
        /// </summary>
        public PushMessageData Data => JSRef!.Get<PushMessageData>("data");
    }
}
