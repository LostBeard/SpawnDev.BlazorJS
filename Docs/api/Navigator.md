# Navigator

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Navigator.cs`  
**MDN Reference:** [Navigator on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Navigator)

> The Navigator interface represents the state and the identity of the user agent. It allows scripts to query it and to register themselves to carry on some activities. https://developer.mozilla.org/en-US/docs/Web/API/Navigator

## Constructors

| Signature | Description |
|---|---|
| `Navigator()` | Gets the global Navigator instance |
| `Navigator(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Bluetooth` | `Bluetooth?` | get | Returns a Bluetooth object for the current document, providing access to Web Bluetooth API functionality. |
| `Clipboard` | `Clipboard` | get | Returns a Clipboard object that provides read and write access to the system clipboard. |
| `Connection` | `NetworkInformation?` | get | Returns a NetworkInformation object containing information about the network connection of a device. |
| `CookieEnabled` | `bool` | get | Returns false if setting a cookie will be ignored and true otherwise. |
| `Credentials` | `CredentialsContainer?` | get | Returns the CredentialsContainer interface which exposes methods to request credentials and notify the user agent when interesting events occur such as successful sign in or sign out. |
| `DeviceMemory` | `float` | get | Returns the amount of device memory in gigabytes. This value is an approximation given by rounding to the nearest power of 2 and dividing that number by 1024. |
| `Geolocation` | `Geolocation?` | get | Returns a Geolocation object allowing accessing the location of the device. |
| `Gpu` | `GPU?` | get | Returns the GPU object for the current browsing context. The entry point for the WebGPU API. |
| `HardwareConcurrency` | `int?` | get | Returns the number of logical processor cores available, or null if the browser does not support this property |
| `Hid` | `HID?` | get | Returns an HID object providing methods for connecting to HID devices, listing attached HID devices, and event handlers for connected HID devices. |
| `Ink` | `Ink?` | get | Returns an Ink object for the current document, providing access to Ink API functionality. |
| `Language` | `string` | get | Returns a string representing the preferred language of the user, usually the language of the browser UI. The null value is returned when this is unknown. |
| `Languages` | `string[]` | get | Returns an array of strings representing the languages known to the user, by order of preference. |
| `Locks` | `LockManager` | get | Returns a LockManager object that provides methods for requesting a new Lock object and querying for an existing Lock object. |
| `MaxTouchPoints` | `int` | get | Returns the maximum number of simultaneous touch contact points are supported by the current device. |
| `MediaCapabilities` | `MediaCapabilities` | get | Returns a MediaCapabilities object that can expose information about the decoding and encoding capabilities for a given format and output capabilities. |
| `MediaDevices` | `MediaDevices` | get | Returns a reference to a MediaDevices object which can then be used to get information about available media devices (MediaDevices.enumerateDevices()), find out what constrainable properties are supported for media on the user's computer and user agent (MediaDevices.getSupportedConstraints()), and to request access to media using MediaDevices.getUserMedia(). |
| `MediaSession` | `MediaSession` | get | Returns MediaSession object which can be used to provide metadata that can be used by the browser to present information about the currently-playing media to the user, such as in a global media controls UI. |
| `OnLine` | `bool` | get | Returns a boolean value indicating whether the browser is working online. |
| `PdfViewerEnabled` | `bool` | get | Returns true if the browser can display PDF files inline when navigating to them, and false otherwise. |
| `Permissions` | `Permissions` | get | Returns a Permissions object that can be used to query and update permission status of APIs covered by the Permissions API. |
| `Presentation` | `Presentation` | get | Returns a reference to the Presentation API. |
| `Serial` | `Serial?` | get | Returns a Serial object, which represents the entry point into the Web Serial API to enable the control of serial ports. |
| `ServiceWorker` | `ServiceWorkerContainer` | get | Returns a ServiceWorkerContainer object, which provides access to registration, removal, upgrade, and communication with the ServiceWorker objects for the associated document. |
| `Storage` | `StorageManager` | get | Returns the singleton StorageManager object used for managing persistence permissions and estimating available storage on a site-by-site/app-by-app basis. |
| `Usb` | `USB?` | get | Returns a USB object for the current document, providing access to WebUSB API functionality. |
| `UserActivation` | `UserActivation` | get | Returns a UserActivation object containing information about the current window's user activation state. |
| `UserAgent` | `string` | get | Returns the user agent string for the current browser. |
| `UserAgentData` | `NavigatorUAData` | get |  |
| `VirtualKeyboard` | `VirtualKeyboard` | get |  |
| `WakeLock` | `WakeLock?` | get | Returns a WakeLock interface you can use to request screen wake locks and prevent screen from dimming, turning off, or showing a screen saver. |
| `WebDriver` | `bool` | get | Indicates whether the user agent is controlled by automation. |
| `WindowControlsOverlay` | `WindowControlsOverlay?` | get | Returns the WindowControlsOverlay interface which exposes information about the geometry of the title bar in desktop Progressive Web Apps, and an event to know whenever it changes. |
| `XR` | `XRSystem?` | get | Returns XRSystem object, which represents the entry point into the WebXR API. |
| `AppCodeName` | `string` | get | Always returns 'Mozilla', in any browser. This property is kept only for compatibility purposes. Deprecated |
| `AppName` | `string` | get | Returns the official name of the browser. Do not rely on this property to return the correct value. Deprecated |
| `AppVersion` | `string` | get | Returns the version of the browser as a string. Do not rely on this property to return the correct value. Deprecated |
| `DoNotTrack` | `bool?` | get | Reports the value of the user's do-not-track preference. When this value is "1", your website or application should not track the user. Deprecated |
| `Platform` | `string?` | get | Returns a string representing the platform of the browser. Do not rely on this property to return the correct value. Deprecated |
| `Product` | `string?` | get | Always returns 'Gecko', on any browser. This property is kept only for compatibility purposes. Deprecated |
| `ProductSub` | `string?` | get | Returns either the string '20030107', or '"20100101'. Deprecated |
| `Vendor` | `string?` | get | Returns either the empty string, 'Apple Computer Inc.', or 'Google Inc.'. Deprecated |
| `VendorSub` | `string?` | get | Always returns the empty string. Deprecated |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetGamepads()` | `Gamepad[]` | returns an array of Gamepad objects, one for each gamepad connected to the device. |
| `CanShare()` | `bool` | The Navigator.canShare() method of the Web Share API returns true if the equivalent call to navigator.share() would succeed. |
| `CanShare(ShareOptions options)` | `bool` | The Navigator.canShare() method of the Web Share API returns true if the equivalent call to navigator.share() would succeed. |
| `ClearAppBadge()` | `Task` | The clearAppBadge() method of the Navigator interface clears a badge on the current app's icon by setting it to nothing. The value nothing indicates that no badge is currently set, and the status of the badge is cleared. |
| `GetBattery()` | `Task<BatteryManager?>` | Returns a promise that resolves with a BatteryManager object that returns information about the battery charging status. |
| `GetInstalledRelatedApps()` | `Task<InstalledAppInfo[]>` | Returns a promise that resolves with an array of objects representing any related native or Progressive Web Applications that the user has installed. |
| `RegisterProtocolHandler(string scheme, string url)` | `void` | Allows websites to register themselves as a possible handler for a given protocol. A string containing the permitted scheme for the protocol that the site wishes to handle. For example, you can register to handle SMS text message links by passing the "sms" scheme. A string containing the URL of the handler. This URL must include %s, as a placeholder that will be replaced with the escaped URL to be handled. |
| `RequestMediaKeySystemAccess(string keySystem, Array supportedConfigurations)` | `Task<MediaKeySystemAccess>` | Returns a Promise for a MediaKeySystemAccess object. https://developer.mozilla.org/en-US/docs/Web/API/Navigator/requestMediaKeySystemAccess A string identifying the key system. For example com.example.somesystem or org.w3.clearkey. A non-empty Array of objects conforming to the object returned by MediaKeySystemAccess.getConfiguration. The first element with a satisfiable configuration will be used. |
| `RequestMIDIAccess()` | `Task<MIDIAccess>` | The requestMIDIAccess() method of the Navigator interface returns a Promise representing a request for access to MIDI devices on a user's system. This method is part of the Web MIDI API, which provides a means for accessing, enumerating, and manipulating MIDI devices. |
| `RequestMIDIAccess(MIDIAccessOptions options)` | `Task<MIDIAccess>` | The requestMIDIAccess() method of the Navigator interface returns a Promise representing a request for access to MIDI devices on a user's system. This method is part of the Web MIDI API, which provides a means for accessing, enumerating, and manipulating MIDI devices. |
| `SendBeacon(string url)` | `bool` | The navigator.sendBeacon() method asynchronously sends an HTTP POST request containing a small amount of data to a web server. |
| `SendBeacon(string url, Union<ArrayBuffer, TypedArray, DataView, Blob, string, FormData, URLSearchParams, byte[]> data)` | `bool` | The navigator.sendBeacon() method asynchronously sends an HTTP POST request containing a small amount of data to a web server. |
| `SetAppBadge()` | `Task` | The setAppBadge() method of the Navigator interface sets a badge on the icon associated with this app. If a value is passed to the method, this will be set as the value of the badge. Otherwise the badge will display as a dot, or other indicator as defined by the platform. |
| `SetAppBadge(float contents)` | `Task` | The setAppBadge() method of the Navigator interface sets a badge on the icon associated with this app. If a value is passed to the method, this will be set as the value of the badge. Otherwise the badge will display as a dot, or other indicator as defined by the platform. |
| `Share(ShareOptions options)` | `Task` | The navigator.share() method of the Web Share API invokes the native sharing mechanism of the device to share data such as text, URLs, or files. The available share targets depend on the device, but might include the clipboard, contacts and email applications, websites, Bluetooth, etc. |
| `UnregisterProtocolHandler(string scheme, string url)` | `void` | The Navigator method unregisterProtocolHandler() removes a protocol handler for a given URL scheme. |
| `Vibrate(Union<float, float[]> pattern)` | `bool` | The Navigator.vibrate() method pulses the vibration hardware on the device, if such hardware exists. If the device doesn't support vibration, this method has no effect. If a vibration pattern is already in progress when this method is called, the previous pattern is halted and the new one begins instead. |

## Example

```csharp
// Get the Navigator instance
using var navigator = new Navigator();

// Common properties
Console.WriteLine($"User Agent: {navigator.UserAgent}");
Console.WriteLine($"Online: {navigator.OnLine}");
Console.WriteLine($"Language: {navigator.Language}");
Console.WriteLine($"Languages: {string.Join(", ", navigator.Languages)}");
Console.WriteLine($"Cores: {navigator.HardwareConcurrency}");
Console.WriteLine($"Device Memory: {navigator.DeviceMemory} GB");
Console.WriteLine($"PDF Viewer: {navigator.PdfViewerEnabled}");
Console.WriteLine($"Cookies Enabled: {navigator.CookieEnabled}");
Console.WriteLine($"Platform: {navigator.Platform}");

// Access sub-objects (each returns a typed wrapper)
using var clipboard = navigator.Clipboard;
using var mediaDevices = navigator.MediaDevices;
using var serviceWorker = navigator.ServiceWorker;
using var locks = navigator.Locks;

// Check for optional API support
var gpu = navigator.Gpu;
if (gpu != null)
{
    Console.WriteLine("WebGPU is available");
    gpu.Dispose();
}

var geolocation = navigator.Geolocation;
if (geolocation != null)
{
    Console.WriteLine("Geolocation is available");
    geolocation.Dispose();
}

// Share API
if (navigator.CanShare())
{
    await navigator.Share(new ShareOptions
    {
        Title = "Check this out",
        Url = "https://example.com"
    });
}

// Vibrate the device (mobile)
navigator.Vibrate(200f); // vibrate for 200ms

// Send analytics beacon
navigator.SendBeacon("/api/analytics", "page_view");
```

