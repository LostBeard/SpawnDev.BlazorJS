using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The NetworkInformation interface of the Network Information API provides information about the connection a device is using to communicate with the network and provides a means for scripts to be notified if the connection type changes. The NetworkInformation interface cannot be instantiated. It is instead accessed through the connection property of the Navigator interface.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/NetworkInformation
    /// </summary>
    public class NetworkInformation : EventTarget
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public NetworkInformation(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the effective bandwidth estimate in megabits per second, rounded to the nearest multiple of 25 kilobits per seconds.
        /// </summary>
        public float Downlink => JSRef.Get<float>("downlink");
        /// <summary>
        /// Returns the effective type of the connection meaning one of 'slow-2g', '2g', '3g', or '4g'. This value is determined using a combination of recently observed round-trip time and downlink values.
        /// </summary>
        public string EffectiveType => JSRef.Get<string>("effectiveType");
        /// <summary>
        /// Returns the estimated effective round-trip time of the current connection, rounded to the nearest multiple of 25 milliseconds.
        /// </summary>
        public float Rtt => JSRef.Get<float>("rtt");
        /// <summary>
        /// Returns true if the user has set a reduced data usage option on the user agent.
        /// </summary>
        public bool SaveData => JSRef.Get<bool>("saveData");
        #endregion

        #region Events
        /// <summary>
        /// The change event fires when connection information changes, and the event is received by the NetworkInformation object.
        /// </summary>
        public JSEventCallback<Event> OnChange { get => new JSEventCallback<Event>("change", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}
