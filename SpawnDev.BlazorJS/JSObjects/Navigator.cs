using Microsoft.JSInterop;

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
        // New
        public string AppCodeName => JSRef.Get<string>("appCodeName");
        public string AppName => JSRef.Get<string>("appName");
        public string AppVersion => JSRef.Get<string>("appVersion");
        public Bluetooth Bluetooth => JSRef.Get<Bluetooth>("bluetooth");
        public NetworkInformation Connection => JSRef.Get<NetworkInformation>("connection");
        public CredentialsContainer Credentials => JSRef.Get<CredentialsContainer>("credentials");
        public float DeviceMemory => JSRef.Get<float>("deviceMemory");
        public bool DoNotTrack => JSRef.Get<bool>("doNotTrack");
        public Geolocation Geolocation => JSRef.Get<Geolocation>("geolocation");
        //public GPU Gpu => JSRef.Get<GPU>("gpu");
        //public HID Hid => JSRef.Get<HID>("hid");
        //public Ink Ink => JSRef.Get<Ink>("ink");
        //public Keyboard Keyboard => JSRef.Get<Keyboard>("keyboard");
        //public string Language => JSRef.Get<string>("language");
        //public Array Languages => JSRef.Get<Array>("languages");
        //public NavigatorManagedData Managed => JSRef.Get<NavigatorManagedData>("managed");
        //public int MaxTouchPoints => JSRef.Get<int>("maxTouchPoints");
        //public MediaCapabilities MediaCapabilities => JSRef.Get<MediaCapabilities>("mediaCapabilities");
        //public MediaSession MediaSession => JSRef.Get<MediaSession>("mediaSession");
        //public MimeTypeArray MimeTypes => JSRef.Get<MimeTypeArray>("mimeTypes");
        //public bool PdfViewerEnabled => JSRef.Get<bool>("pdfViewerEnabled");
        //public Permissions Permissions => JSRef.Get<Permissions>("permissions");
        //public string Platform => JSRef.Get<string>("platform");
        //public PluginArray Plugins => JSRef.Get<PluginArray>("plugins");
        //public Presentation Presentation => JSRef.Get<Presentation>("presentation");
        //public string Product => JSRef.Get<string>("product");
        //public string ProductSub => JSRef.Get<string>("productSub");
        //public Scheduling Scheduling => JSRef.Get<Scheduling>("scheduling");
        //public Serial Serial => JSRef.Get<Serial>("serial");
        //public USB Usb => JSRef.Get<USB>("usb");
        //public string UserAgent => JSRef.Get<string>("userAgent");
        //public NavigatorUAData UserAgentData => JSRef.Get<NavigatorUAData>("userAgentData");
        //public string Vendor => JSRef.Get<string>("vendor");
        //public string VendorSub => JSRef.Get<string>("vendorSub");
        //public VirtualKeyboard VirtualKeyboard => JSRef.Get<VirtualKeyboard>("virtualKeyboard");
        //public JSObject WebkitPersistentStorage => JSRef.Get<JSObject>("webkitPersistentStorage");
        //public JSObject WebkitTemporaryStorage => JSRef.Get<JSObject>("webkitTemporaryStorage");
        //public WindowControlsOverlay WindowControlsOverlay => JSRef.Get<WindowControlsOverlay>("windowControlsOverlay");
        //public XRSystem Xr => JSRef.Get<XRSystem>("xr");

        #region Methods
        public Gamepad[] GetGamepads() => JSRef.Call<Gamepad[]>("getGamepads");
        //// New
        //public bool CanShare() => JSRef.Call<bool>("canShare");
        //public bool CanShare(ShareOptions options) => JSRef.Call<bool>("canShare", options);
        //public Task ClearAppBadge() => JSRef.CallVoidAsync("clearAppBadge");
        //public Task<BatteryManager> GetBattery() => JSRef.CallAsync<BatteryManager>("getBattery");
        //public Task<InstalledAppInfo[]> GetInstalledRelatedApps() => JSRef.CallAsync<InstalledAppInfo[]>("getInstalledRelatedApps");
        //public void GetUserMedia() => JSRef.CallVoid("getUserMedia");
        //public void JavaEnabled() => JSRef.CallVoid("javaEnabled");
        //public void RegisterProtocolHandler() => JSRef.CallVoid("registerProtocolHandler");
        //public void RequestMediaKeySystemAccess() => JSRef.CallVoid("requestMediaKeySystemAccess");
        //public void RequestMIDIAccess() => JSRef.CallVoid("requestMIDIAccess");
        //public void SendBeacon() => JSRef.CallVoid("sendBeacon");
        //public void SetAppBadge() => JSRef.CallVoid("setAppBadge");
        //public void Share() => JSRef.CallVoid("share");
        //public void UnregisterProtocolHandler() => JSRef.CallVoid("unregisterProtocolHandler");
        //public void Vibrate() => JSRef.CallVoid("vibrate");
        //public void WebkitGetUserMedia() => JSRef.CallVoid("webkitGetUserMedia");
        #endregion
    }
}
