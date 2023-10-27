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
        public MediaDevices MediaDevices => JSRef.Get<MediaDevices>("mediaDevices");
        public LockManager Locks => JSRef.Get<LockManager>("locks");
        public StorageManager Storage => JSRef.Get<StorageManager>("storage");
        public ServiceWorkerContainer ServiceWorker => JSRef.Get<ServiceWorkerContainer>("serviceWorker");
        public WakeLock WakeLock => JSRef.Get<WakeLock>("wakeLock");
        public Clipboard Clipboard => JSRef.Get<Clipboard>("clipboard");
        public bool CookieEnabled => JSRef.Get<bool>("cookieEnabled");
        public UserActivation UserActivation => JSRef.Get<UserActivation>("userActivation");
        public bool OnLine => JSRef.Get<bool>("onLine");
        public int HardwareConcurrency => JSRef.Get<int>("hardwareConcurrency");
        public string AppCodeName => JSRef.Get<string>("appCodeName");
        public string AppName => JSRef.Get<string>("appName");
        public string AppVersion => JSRef.Get<string>("appVersion");
        public Bluetooth? Bluetooth => JSRef.Get<Bluetooth?>("bluetooth");
        public NetworkInformation? Connection => JSRef.Get<NetworkInformation?>("connection");
        public CredentialsContainer? Credentials => JSRef.Get<CredentialsContainer?>("credentials");
        public float DeviceMemory => JSRef.Get<float>("deviceMemory");
        public bool DoNotTrack => JSRef.Get<bool>("doNotTrack");
        public Geolocation? Geolocation => JSRef.Get<Geolocation?>("geolocation");
        public GPU? Gpu => JSRef.Get<GPU?>("gpu");
        public HID? Hid => JSRef.Get<HID?>("hid");
        public Ink Ink => JSRef.Get<Ink>("ink");
        //public Keyboard Keyboard => JSRef.Get<Keyboard>("keyboard");
        public string Language => JSRef.Get<string>("language");
        public string[] Languages => JSRef.Get<string[]>("languages");
        //public NavigatorManagedData Managed => JSRef.Get<NavigatorManagedData>("managed");
        public int MaxTouchPoints => JSRef.Get<int>("maxTouchPoints");
        //public MediaCapabilities MediaCapabilities => JSRef.Get<MediaCapabilities>("mediaCapabilities");
        //public MediaSession MediaSession => JSRef.Get<MediaSession>("mediaSession");
        //public MimeTypeArray MimeTypes => JSRef.Get<MimeTypeArray>("mimeTypes");
        public bool PdfViewerEnabled => JSRef.Get<bool>("pdfViewerEnabled");
        public Permissions Permissions => JSRef.Get<Permissions>("permissions");
        public string Platform => JSRef.Get<string>("platform");
        //public PluginArray Plugins => JSRef.Get<PluginArray>("plugins");
        //public Presentation Presentation => JSRef.Get<Presentation>("presentation");
        public string Product => JSRef.Get<string>("product");
        public string ProductSub => JSRef.Get<string>("productSub");
        //public Scheduling Scheduling => JSRef.Get<Scheduling>("scheduling");
        //public Serial Serial => JSRef.Get<Serial>("serial");
        //public USB Usb => JSRef.Get<USB>("usb");
        public string UserAgent => JSRef.Get<string>("userAgent");
        //public NavigatorUAData UserAgentData => JSRef.Get<NavigatorUAData>("userAgentData");
        public string Vendor => JSRef.Get<string>("vendor");
        public string VendorSub => JSRef.Get<string>("vendorSub");
        //public VirtualKeyboard VirtualKeyboard => JSRef.Get<VirtualKeyboard>("virtualKeyboard");
        //public WindowControlsOverlay WindowControlsOverlay => JSRef.Get<WindowControlsOverlay>("windowControlsOverlay");
        //public XRSystem Xr => JSRef.Get<XRSystem>("xr");
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
