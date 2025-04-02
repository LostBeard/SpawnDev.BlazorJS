using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The NotificationEvent interface of the Notifications API represents a notification event dispatched on the ServiceWorkerGlobalScope of a ServiceWorker.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/NotificationEvent
    /// </summary>
    public class NotificationEvent : ExtendableEvent
    {
        ///<inheritdoc/>
        public NotificationEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a Notification object representing the notification that was clicked to fire the event.
        /// </summary>
        public Notification Notification => JSRef!.Get<Notification>("notification");
        /// <summary>
        /// Returns the string ID of the notification button the user clicked. This value returns an empty string if the user clicked the notification somewhere other than an action button, or the notification does not have a button.
        /// </summary>
        public string? Action => JSRef!.Get<string?>("action");
    }
}
