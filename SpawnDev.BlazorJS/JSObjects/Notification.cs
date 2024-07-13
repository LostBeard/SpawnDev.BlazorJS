using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Notification interface of the Notifications API is used to configure and display desktop notifications to the user.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Notification
    /// </summary>
    public class Notification : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Notification(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The Notification() constructor creates a new Notification object instance, which represents a user notification.
        /// </summary>
        /// <param name="title"></param>
        public Notification(string title) : base(JS.New(nameof(Notification), title)) { }
        /// <summary>
        /// The Notification() constructor creates a new Notification object instance, which represents a user notification.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="options"></param>
        public Notification(string title, NotificationOptions options) : base(JS.New(nameof(Notification), title, options)) { }
        /// <summary>
        /// A string representing the current permission to display notifications. Possible values are:
        /// <b>denied</b>: the user refuses to have notifications displayed.
        /// <b>granted</b>: the user accepts having notifications displayed.
        /// <b>default</b>: the user choice is unknown and therefore the browser will act as if the value were denied.
        /// </summary>
        public static string Permission => JS.Get<string>("Notification.permission");
        /// <summary>
        /// returns true is Notification is defined
        /// </summary>
        public static bool IsSupported => !JS.IsUndefined("Notification");
        /// <summary>
        /// Requests permission from the user to display notifications.
        /// </summary>
        /// <returns></returns>
        public static Task<string> RequestPermission() => JS.CallAsync<string>("Notification.requestPermission");
    }
}
