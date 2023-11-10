using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WorkerNavigator interface represents a subset of the Navigator interface allowed to be accessed from a Worker<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/WorkerNavigator
    /// </summary>
    public class WorkerNavigator : JSObject
    {
        /// <summary>
        /// Returns the global navigator instance
        /// </summary>
        public WorkerNavigator() : base(JS.Get<IJSInProcessObjectReference>("navigator")) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WorkerNavigator(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Always returns 'Mozilla', in any browser. This property is kept only for compatibility purposes.
        /// </summary>
        public string AppCodeName => JSRef.Get<string>("appCodeName");
        /// <summary>
        /// Returns the official name of the browser. Do not rely on this property to return the correct value.
        /// </summary>
        public string AppName => JSRef.Get<string>("appName");
        /// <summary>
        /// Returns the version of the browser as a string. Do not rely on this property to return the correct value.
        /// </summary>
        public string AppVersion => JSRef.Get<string>("appVersion");
        /// <summary>
        /// Provides a NetworkInformation object containing information about the network connection of a device.
        /// </summary>
        public NetworkInformation? Connection => JSRef.Get<NetworkInformation?>("connection");
        /// <summary>
        /// Returns the GPU object for the current worker context. The entry point for the WebGPU API.
        /// </summary>
        public GPU? Gpu => JSRef.Get<GPU?>("gpu");
        /// <summary>
        /// Returns the number of logical processor cores available
        /// </summary>
        public int HardwareConcurrency => JSRef.Get<int>("hardwareConcurrency");
        /// <summary>
        /// Returns a string representing the preferred language of the user, usually the language of the browser UI. The null value is returned when this is unknown.
        /// </summary>
        public string? Language => JSRef.Get<string?>("language");
        /// <summary>
        /// Returns an array of strings representing the languages known to the user, by order of preference.
        /// </summary>
        public string[]? Languages => JSRef.Get<string[]?>("languages");
        /// <summary>
        /// Returns a LockManager object which provides methods for requesting a new Lock object and querying for an existing Lock object.
        /// </summary>
        public LockManager? Locks => JSRef.Get<LockManager?>("locks");
        /// <summary>
        /// Returns a MediaCapabilities object that can expose information about the decoding and encoding capabilities for a given format and output capabilities.
        /// </summary>
        public MediaCapabilities? MediaCapabilities => JSRef.Get<MediaCapabilities?>("mediaCapabilities");
        /// <summary>
        /// Returns a boolean value indicating whether the browser is online.
        /// </summary>
        public bool OnLine => JSRef.Get<bool>("onLine");
        /// <summary>
        /// Returns a Permissions object that can be used to query and update permission status of APIs covered by the Permissions API.
        /// </summary>
        public Permissions? Permissions => JSRef.Get<Permissions?>("permissions");
        /// <summary>
        /// Returns a string representing the platform of the browser. Do not rely on this property to return the correct value.<br />
        /// Deprecated
        /// </summary>
        public string? Platform => JSRef.Get<string?>("platform");
        /// <summary>
        /// Always returns 'Gecko', on any browser. This property is kept only for compatibility purposes.<br />
        /// Deprecated
        /// </summary>
        public string Product => JSRef.Get<string>("product");
        /// <summary>
        /// Returns a Serial object, which represents the entry point into the Web Serial API to enable the control of serial ports.
        /// </summary>
        public Serial? Serial => JSRef.Get<Serial?>("serial");
        /// <summary>
        /// Returns a StorageManager interface for managing persistence permissions and estimating available storage.
        /// </summary>
        public StorageManager? Storage => JSRef.Get<StorageManager?>("storage");
        /// <summary>
        /// Returns a USB object for the current document, providing access to WebUSB API functionality.
        /// </summary>
        public USB? Usb => JSRef.Get<USB?>("usb");
        /// <summary>
        /// Returns the user agent string for the current browser.
        /// </summary>
        public string UserAgent => JSRef.Get<string>("userAgent");
    }
}
