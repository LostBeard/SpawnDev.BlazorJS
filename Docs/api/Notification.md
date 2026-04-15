# Notification

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Notification.cs`  
**MDN Reference:** [Notification on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Notification)

> The Notification interface of the Notifications API is used to configure and display desktop notifications to the user. https://developer.mozilla.org/en-US/docs/Web/API/Notification

## Constructors

| Signature | Description |
|---|---|
| `Notification(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Notification(string title)` | The Notification() constructor creates a new Notification object instance, which represents a user notification. |
| `Notification(string title, NotificationOptions options)` | The Notification() constructor creates a new Notification object instance, which represents a user notification. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Permission` | `string?` | get | A string representing the current permission to display notifications. Possible values are: denied: the user refuses to have notifications displayed. granted: the user accepts having notifications displayed. default: the user choice is unknown and therefore the browser will act as if the value were denied. null: unsupported (non-spec) |
| `MaxActions` | `int?` | get | The maximum number of actions supported by the device and the User Agent or null if Notification is unsupported. (non-spec) |
| `IsSupported` | `bool` | get | returns true is Notification is defined |
| `Actions` | `NotificationAction[]` | get | The actions array of the notification as specified in the constructor's options parameter. |
| `Badge` | `string?` | get | A string containing the URL of an image to represent the notification when there is not enough space to display the notification itself such as for example, the Android Notification Bar. On Android devices, the badge should accommodate devices up to 4x resolution, about 96 by 96 px, and the image will be automatically masked. |
| `Body` | `string?` | get | The body string of the notification as specified in the constructor's options parameter. |
| `Data` | `JSObject?` | get | Returns a structured clone of the notification's data. |
| `Dir` | `EnumString<NotificationDirection>` | get | The text direction of the notification as specified in the constructor's options parameter. |
| `Icon` | `string?` | get | The URL of the image used as an icon of the notification as specified in the constructor's options parameter. |
| `Image` | `string?` | get | The URL of an image to be displayed as part of the notification, as specified in the constructor's options parameter. |
| `Lang` | `string?` | get | The language code of the notification as specified in the constructor's options parameter. |
| `Remotify` | `bool` | get | Specifies whether the user should be notified after a new notification replaces an old one. |
| `RequireInteraction` | `bool` | get | A boolean value indicating that a notification should remain active until the user clicks or dismisses it, rather than closing automatically. |
| `Silent` | `bool` | get | Specifies whether the notification should be silent - i.e., no sounds or vibrations should be issued regardless of the device settings. |
| `Tag` | `string?` | get | The ID of the notification (if any) as specified in the constructor's options parameter. |
| `Timestamp` | `EpochDateTime?` | get | Specifies the time at which a notification is created or applicable (past, present, or future). |
| `Title` | `string?` | get | The title of the notification as specified in the first parameter of the constructor. |
| `Vibrate` | `bool` | get | Specifies a vibration pattern for devices with vibration hardware to emit. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RequestPermission()` | `Task<string?>` | Requests permission from the user to display notifications. Returns null if Notification is unsupported. (non-spec) |
| `DataAs()` | `T` | Returns a structured clone of the notification's data as type T |
| `Close()` | `void` | Programmatically closes a notification instance. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnClick` | `ActionEvent<Event>` | Fires when the user clicks the notification. |
| `OnClose` | `ActionEvent<Event>` | Fires when the user closes the notification. |
| `OnError` | `ActionEvent<Event>` | Fires when the notification encounters an error. |
| `OnShow` | `ActionEvent<Event>` | Fires when the notification is displayed. |

## Example

```csharp
// Check if Notifications are supported
if (!Notification.IsSupported)
{
    Console.WriteLine("Notifications not supported in this browser");
    return;
}

// Check current permission status
var permission = Notification.Permission;
Console.WriteLine($"Current permission: {permission}");

// Request permission if needed
if (permission != "granted")
{
    permission = await Notification.RequestPermission();
}

if (permission == "granted")
{
    // Create a simple notification
    using var notification = new Notification("Hello from Blazor!");

    // Create a notification with options
    using var richNotification = new Notification("New Message", new NotificationOptions
    {
        Body = "You have a new message from the team.",
        Icon = "/icons/message.png",
        Tag = "message-1",
        RequireInteraction = true,
        Silent = false
    });

    // Handle click event
    Action<Event> onClick = (Event e) =>
    {
        Console.WriteLine("Notification clicked!");
        richNotification.Close();
        e.Dispose();
    };
    richNotification.OnClick += onClick;

    // Handle show event
    Action<Event> onShow = (Event e) =>
    {
        Console.WriteLine($"Notification displayed: {richNotification.Title}");
        e.Dispose();
    };
    richNotification.OnShow += onShow;

    // Read notification properties
    Console.WriteLine($"Title: {richNotification.Title}");
    Console.WriteLine($"Body: {richNotification.Body}");
    Console.WriteLine($"Tag: {richNotification.Tag}");

    // Clean up event handlers before disposal
    richNotification.OnClick -= onClick;
    richNotification.OnShow -= onShow;
}
```

