using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Navigator interface represents the state and the identity of the user agent. It allows scripts to query it and to register themselves to carry on some activities.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Navigator
    /// </summary>
    public class Navigator : JSObject
    {
        /// <summary>
        /// Gets the global Navigator instance
        /// </summary>
        public Navigator() : base(JS.Get<IJSInProcessObjectReference>("navigator")) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Navigator(IJSInProcessObjectReference _ref) : base(_ref) { }
        #region Properties
        /// <summary>
        /// Returns a Bluetooth object for the current document, providing access to Web Bluetooth API functionality.
        /// </summary>
        public Bluetooth? Bluetooth => JSRef.Get<Bluetooth?>("bluetooth");
        /// <summary>
        /// Returns a Clipboard object that provides read and write access to the system clipboard.
        /// </summary>
        public Clipboard Clipboard => JSRef.Get<Clipboard>("clipboard");
        /// <summary>
        /// Returns a NetworkInformation object containing information about the network connection of a device.
        /// </summary>
        public NetworkInformation? Connection => JSRef.Get<NetworkInformation?>("connection");
        /// <summary>
        /// Returns false if setting a cookie will be ignored and true otherwise.
        /// </summary>
        public bool CookieEnabled => JSRef.Get<bool>("cookieEnabled");
        /// <summary>
        /// Returns the CredentialsContainer interface which exposes methods to request credentials and notify the user agent when interesting events occur such as successful sign in or sign out.
        /// </summary>
        public CredentialsContainer? Credentials => JSRef.Get<CredentialsContainer?>("credentials");
        /// <summary>
        /// Returns the amount of device memory in gigabytes. This value is an approximation given by rounding to the nearest power of 2 and dividing that number by 1024.
        /// </summary>
        public float DeviceMemory => JSRef.Get<float>("deviceMemory");
        /// <summary>
        /// Returns a Geolocation object allowing accessing the location of the device.
        /// </summary>
        public Geolocation? Geolocation => JSRef.Get<Geolocation?>("geolocation");
        /// <summary>
        /// Returns the GPU object for the current browsing context. The entry point for the WebGPU API.
        /// </summary>
        public GPU? Gpu => JSRef.Get<GPU?>("gpu");
        /// <summary>
        /// Returns the number of logical processor cores available.
        /// </summary>
        public int HardwareConcurrency => JSRef.Get<int>("hardwareConcurrency");
        /// <summary>
        /// Returns an HID object providing methods for connecting to HID devices, listing attached HID devices, and event handlers for connected HID devices.
        /// </summary>
        public HID? Hid => JSRef.Get<HID?>("hid");
        /// <summary>
        /// Returns an Ink object for the current document, providing access to Ink API functionality.
        /// </summary>
        public Ink? Ink => JSRef.Get<Ink?>("ink");
        /// <summary>
        /// Returns a string representing the preferred language of the user, usually the language of the browser UI. The null value is returned when this is unknown.
        /// </summary>
        public string Language => JSRef.Get<string>("language");
        /// <summary>
        /// Returns an array of strings representing the languages known to the user, by order of preference.
        /// </summary>
        public string[] Languages => JSRef.Get<string[]>("languages");
        /// <summary>
        /// Returns a LockManager object that provides methods for requesting a new Lock object and querying for an existing Lock object.
        /// </summary>
        public LockManager Locks => JSRef.Get<LockManager>("locks");
        /// <summary>
        /// Returns the maximum number of simultaneous touch contact points are supported by the current device.
        /// </summary>
        public int MaxTouchPoints => JSRef.Get<int>("maxTouchPoints");
        /// <summary>
        /// Returns a MediaCapabilities object that can expose information about the decoding and encoding capabilities for a given format and output capabilities.
        /// </summary>
        public MediaCapabilities MediaCapabilities => JSRef.Get<MediaCapabilities>("mediaCapabilities");
        /// <summary>
        /// Returns a reference to a MediaDevices object which can then be used to get information about available media devices (MediaDevices.enumerateDevices()), find out what constrainable properties are supported for media on the user's computer and user agent (MediaDevices.getSupportedConstraints()), and to request access to media using MediaDevices.getUserMedia().
        /// </summary>
        public MediaDevices MediaDevices => JSRef.Get<MediaDevices>("mediaDevices");
        //public MediaSession MediaSession => JSRef.Get<MediaSession>("mediaSession");
        /// <summary>
        /// Returns a boolean value indicating whether the browser is working online.
        /// </summary>
        public bool OnLine => JSRef.Get<bool>("onLine");
        /// <summary>
        /// Returns true if the browser can display PDF files inline when navigating to them, and false otherwise.
        /// </summary>
        public bool PdfViewerEnabled => JSRef.Get<bool>("pdfViewerEnabled");
        /// <summary>
        /// Returns a Permissions object that can be used to query and update permission status of APIs covered by the Permissions API.
        /// </summary>
        public Permissions Permissions => JSRef.Get<Permissions>("permissions");
        //public Presentation Presentation => JSRef.Get<Presentation>("presentation");
        //public Scheduling Scheduling => JSRef.Get<Scheduling>("scheduling");
        /// <summary>
        /// Returns a Serial object, which represents the entry point into the Web Serial API to enable the control of serial ports.
        /// </summary>
        public Serial? Serial => JSRef.Get<Serial?>("serial");
        /// <summary>
        /// Returns a ServiceWorkerContainer object, which provides access to registration, removal, upgrade, and communication with the ServiceWorker objects for the associated document.
        /// </summary>
        public ServiceWorkerContainer ServiceWorker => JSRef.Get<ServiceWorkerContainer>("serviceWorker");
        /// <summary>
        /// Returns the singleton StorageManager object used for managing persistence permissions and estimating available storage on a site-by-site/app-by-app basis.
        /// </summary>
        public StorageManager Storage => JSRef.Get<StorageManager>("storage");
        /// <summary>
        /// Returns a USB object for the current document, providing access to WebUSB API functionality.
        /// </summary>
        public USB? Usb => JSRef.Get<USB?>("usb");
        /// <summary>
        /// Returns a UserActivation object containing information about the current window's user activation state.
        /// </summary>
        public UserActivation UserActivation => JSRef.Get<UserActivation>("userActivation");
        /// <summary>
        /// Returns the user agent string for the current browser.
        /// </summary>
        public string UserAgent => JSRef.Get<string>("userAgent");
        //public NavigatorUAData UserAgentData => JSRef.Get<NavigatorUAData>("userAgentData");
        //public VirtualKeyboard VirtualKeyboard => JSRef.Get<VirtualKeyboard>("virtualKeyboard");
        /// <summary>
        /// Returns a WakeLock interface you can use to request screen wake locks and prevent screen from dimming, turning off, or showing a screen saver.
        /// </summary>
        public WakeLock? WakeLock => JSRef.Get<WakeLock?>("wakeLock");
        /// <summary>
        /// Indicates whether the user agent is controlled by automation.
        /// </summary>
        public bool WebDriver => JSRef.Get<bool>("webdriver");
        /// <summary>
        /// Returns the WindowControlsOverlay interface which exposes information about the geometry of the title bar in desktop Progressive Web Apps, and an event to know whenever it changes.
        /// </summary>
        public WindowControlsOverlay? WindowControlsOverlay => JSRef.Get<WindowControlsOverlay?>("windowControlsOverlay");
        //public XRSystem Xr => JSRef.Get<XRSystem>("xr");
        /// <summary>
        /// Always returns 'Mozilla', in any browser. This property is kept only for compatibility purposes.<br />
        /// Deprecated
        /// </summary>
        public string AppCodeName => JSRef.Get<string>("appCodeName");
        /// <summary>
        /// Returns the official name of the browser. Do not rely on this property to return the correct value.<br />
        /// Deprecated
        /// </summary>
        public string AppName => JSRef.Get<string>("appName");
        /// <summary>
        /// Returns the version of the browser as a string. Do not rely on this property to return the correct value.<br />
        /// Deprecated
        /// </summary>
        public string AppVersion => JSRef.Get<string>("appVersion");
        /// <summary>
        /// Reports the value of the user's do-not-track preference. When this value is "1", your website or application should not track the user.<br />
        /// Deprecated
        /// </summary>
        public bool? DoNotTrack => JSRef.Get<bool?>("doNotTrack");
        /// <summary>
        /// Returns a string representing the platform of the browser. Do not rely on this property to return the correct value.<br />
        /// Deprecated
        /// </summary>
        public string? Platform => JSRef.Get<string?>("platform");
        /// <summary>
        /// Always returns 'Gecko', on any browser. This property is kept only for compatibility purposes.<br />
        /// Deprecated
        /// </summary>
        public string? Product => JSRef.Get<string?>("product");
        /// <summary>
        /// Returns either the string '20030107', or '"20100101'.<br />
        /// Deprecated
        /// </summary>
        public string? ProductSub => JSRef.Get<string?>("productSub");
        /// <summary>
        /// Returns either the empty string, 'Apple Computer Inc.', or 'Google Inc.'.<br />
        /// Deprecated
        /// </summary>
        public string? Vendor => JSRef.Get<string?>("vendor");
        /// <summary>
        /// Always returns the empty string.<br />
        /// Deprecated
        /// </summary>
        public string? VendorSub => JSRef.Get<string?>("vendorSub");
        #endregion
        #region Methods
        public Gamepad[] GetGamepads() => JSRef.Call<Gamepad[]>("getGamepads");
        // New
        /// <summary>
        /// The Navigator.canShare() method of the Web Share API returns true if the equivalent call to navigator.share() would succeed.
        /// </summary>
        /// <returns></returns>
        public bool CanShare() => JSRef.Call<bool>("canShare");
        /// <summary>
        /// The Navigator.canShare() method of the Web Share API returns true if the equivalent call to navigator.share() would succeed.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool CanShare(ShareOptions options) => JSRef.Call<bool>("canShare", options);
        /// <summary>
        /// The clearAppBadge() method of the Navigator interface clears a badge on the current app's icon by setting it to nothing. The value nothing indicates that no badge is currently set, and the status of the badge is cleared.
        /// </summary>
        /// <returns></returns>
        public Task ClearAppBadge() => JSRef.CallVoidAsync("clearAppBadge");
        /// <summary>
        /// Returns a promise that resolves with a BatteryManager object that returns information about the battery charging status.
        /// </summary>
        /// <returns></returns>
        public Task<BatteryManager> GetBattery() => JSRef.CallAsync<BatteryManager>("getBattery");
        /// <summary>
        /// Returns a promise that resolves with an array of objects representing any related native or Progressive Web Applications that the user has installed.
        /// </summary>
        /// <returns></returns>
        public Task<InstalledAppInfo[]> GetInstalledRelatedApps() => JSRef.CallAsync<InstalledAppInfo[]>("getInstalledRelatedApps");
        /// <summary>
        /// Allows websites to register themselves as a possible handler for a given protocol.
        /// </summary>
        /// <param name="scheme">A string containing the permitted scheme for the protocol that the site wishes to handle. For example, you can register to handle SMS text message links by passing the "sms" scheme.</param>
        /// <param name="url">A string containing the URL of the handler. This URL must include %s, as a placeholder that will be replaced with the escaped URL to be handled.</param>
        public void RegisterProtocolHandler(string scheme, string url) => JSRef.CallVoid("registerProtocolHandler", scheme, url);
        /// <summary>
        /// Returns a Promise for a MediaKeySystemAccess object.<br />
        /// https://developer.mozilla.org/en-US/docs/Web/API/Navigator/requestMediaKeySystemAccess
        /// </summary>
        /// <param name="keySystem">A string identifying the key system. For example com.example.somesystem or org.w3.clearkey.</param>
        /// <param name="supportedConfigurations">A non-empty Array of objects conforming to the object returned by MediaKeySystemAccess.getConfiguration. The first element with a satisfiable configuration will be used.</param>
        public Task<MediaKeySystemAccess> RequestMediaKeySystemAccess(string keySystem, Array supportedConfigurations) => JSRef.CallAsync<MediaKeySystemAccess>("requestMediaKeySystemAccess", keySystem, supportedConfigurations);
        /// <summary>
        /// The requestMIDIAccess() method of the Navigator interface returns a Promise representing a request for access to MIDI devices on a user's system. This method is part of the Web MIDI API, which provides a means for accessing, enumerating, and manipulating MIDI devices.
        /// </summary>
        public Task<MIDIAccess> RequestMIDIAccess() => JSRef.CallAsync<MIDIAccess>("requestMIDIAccess");
        /// <summary>
        /// The requestMIDIAccess() method of the Navigator interface returns a Promise representing a request for access to MIDI devices on a user's system. This method is part of the Web MIDI API, which provides a means for accessing, enumerating, and manipulating MIDI devices.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<MIDIAccess> RequestMIDIAccess(MIDIAccessOptions options) => JSRef.CallAsync<MIDIAccess>("requestMIDIAccess", options);
        /// <summary>
        /// The navigator.sendBeacon() method asynchronously sends an HTTP POST request containing a small amount of data to a web server.
        /// </summary>
        public bool SendBeacon(string url) => JSRef.Call<bool>("sendBeacon", url);
        /// <summary>
        /// The navigator.sendBeacon() method asynchronously sends an HTTP POST request containing a small amount of data to a web server.
        /// </summary>
        public bool SendBeacon(string url, Union<ArrayBuffer, TypedArray, DataView, Blob, string, FormData, URLSearchParams, byte[]> data) => JSRef.Call<bool>("sendBeacon", url, data);
        /// <summary>
        /// The setAppBadge() method of the Navigator interface sets a badge on the icon associated with this app. If a value is passed to the method, this will be set as the value of the badge. Otherwise the badge will display as a dot, or other indicator as defined by the platform.
        /// </summary>
        public Task SetAppBadge() => JSRef.CallVoidAsync("setAppBadge");
        /// <summary>
        /// The setAppBadge() method of the Navigator interface sets a badge on the icon associated with this app. If a value is passed to the method, this will be set as the value of the badge. Otherwise the badge will display as a dot, or other indicator as defined by the platform.
        /// </summary>
        public Task SetAppBadge(float contents) => JSRef.CallVoidAsync("setAppBadge", contents);
        /// <summary>
        /// The navigator.share() method of the Web Share API invokes the native sharing mechanism of the device to share data such as text, URLs, or files. The available share targets depend on the device, but might include the clipboard, contacts and email applications, websites, Bluetooth, etc.
        /// </summary>
        public Task Share(ShareOptions options) => JSRef.CallVoidAsync("share", options);
        /// <summary>
        /// The Navigator method unregisterProtocolHandler() removes a protocol handler for a given URL scheme.
        /// </summary>
        public void UnregisterProtocolHandler(string scheme, string url) => JSRef.CallVoid("unregisterProtocolHandler", scheme, url);
        /// <summary>
        /// The Navigator.vibrate() method pulses the vibration hardware on the device, if such hardware exists. If the device doesn't support vibration, this method has no effect. If a vibration pattern is already in progress when this method is called, the previous pattern is halted and the new one begins instead.
        /// </summary>
        public bool Vibrate(Union<float, float[]> pattern) => JSRef.Call<bool>("vibrate", pattern);
        #endregion
    }
}
