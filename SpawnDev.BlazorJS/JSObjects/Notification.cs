using Microsoft.JSInterop;
using SpawnDev.BlazorJS.IJSInProcessObjectReferenceAnyKey;

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
        #region Static Methods
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
        #endregion
        /// <summary>
        /// The actions array of the notification as specified in the constructor's options parameter.
        /// </summary>
        public NotificationAction[] Actions => JSRef!.Get<NotificationAction[]>("actions");
        /// <summary>
        /// A string containing the URL of an image to represent the notification when there is not enough space to display the notification itself such as for example, the Android Notification Bar. On Android devices, the badge should accommodate devices up to 4x resolution, about 96 by 96 px, and the image will be automatically masked.
        /// </summary>
        public string? Badge => JSRef!.Get<string?>("badge");
        /// <summary>
        /// The body string of the notification as specified in the constructor's options parameter.
        /// </summary>
        public string? Body => JSRef!.Get<string?>("body");
        /// <summary>
        /// The text direction of the notification as specified in the constructor's options parameter.
        /// </summary>
        public EnumString<NotificationDirection> Dir => JSRef!.Get<EnumString<NotificationDirection>>("dir");
        /// <summary>
        /// The URL of the image used as an icon of the notification as specified in the constructor's options parameter.
        /// </summary>
        public string? Icon => JSRef!.Get<string?>("icon");
        /// <summary>
        /// The URL of an image to be displayed as part of the notification, as specified in the constructor's options parameter.
        /// </summary>
        public string? Image => JSRef!.Get<string?>("image");
        /// <summary>
        /// The language code of the notification as specified in the constructor's options parameter.
        /// </summary>
        public string? Lang => JSRef!.Get<string?>("lang");
        /// <summary>
        /// Specifies whether the user should be notified after a new notification replaces an old one.
        /// </summary>
        public bool Remotify => JSRef!.Get<bool>("remotify");
        /// <summary>
        /// A boolean value indicating that a notification should remain active until the user clicks or dismisses it, rather than closing automatically.
        /// </summary>
        public bool RequireInteraction => JSRef!.Get<bool>("requireInteraction");
        /// <summary>
        /// Specifies whether the notification should be silent — i.e., no sounds or vibrations should be issued regardless of the device settings.
        /// </summary>
        public bool Silent => JSRef!.Get<bool>("silent");
        /// <summary>
        /// The ID of the notification (if any) as specified in the constructor's options parameter.
        /// </summary>
        public string? Tag => JSRef!.Get<string?>("tag");
        /// <summary>
        /// Specifies the time at which a notification is created or applicable (past, present, or future).
        /// </summary>
        public EpochDateTime? Timestamp => JSRef!.Get<EpochDateTime?>("timestamp");
        /// <summary>
        /// The title of the notification as specified in the first parameter of the constructor.
        /// </summary>
        public string? Title => JSRef!.Get<string?>("title");
        /// <summary>
        /// Specifies a vibration pattern for devices with vibration hardware to emit.
        /// </summary>
        public bool Vibrate => JSRef!.Get<bool>("vibrate");
        /// <summary>
        /// Programmatically closes a notification instance.
        /// </summary>
        public void CLose() => JSRef!.CallVoid("close");
        /// <summary>
        /// Fires when the user clicks the notification.
        /// </summary>
        public ActionEvent<Event> OnClick { get => new ActionEvent<Event>("click", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fires when the user closes the notification.
        /// </summary>
        public ActionEvent<Event> OnClose { get => new ActionEvent<Event>("close", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fires when the notification encounters an error.
        /// </summary>
        public ActionEvent<Event> OnError { get => new ActionEvent<Event>("error", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fires when the notification is displayed.
        /// </summary>
        public ActionEvent<Event> OnShow { get => new ActionEvent<Event>("show", AddEventListener, RemoveEventListener); set { } }
    }
}
