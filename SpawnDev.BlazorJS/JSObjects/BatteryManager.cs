using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BatteryManager interface of the Battery Status API provides information about the system's battery charge level. The navigator.getBattery() method returns a promise that resolves with a BatteryManager interface.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/BatteryManager
    /// </summary>
    public class BatteryManager : EventTarget
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public BatteryManager(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// A Boolean value indicating whether the battery is currently being charged
        /// </summary>
        public bool Charging => JSRef.Get<bool>("charging");
        /// <summary>
        /// A number representing the remaining time in seconds until the battery is fully charged, or 0 if the battery is already fully charged.
        /// </summary>
        public float ChargingTime => JSRef.Get<float>("chargingTime");
        /// <summary>
        /// A number representing the remaining time in seconds until the battery is completely discharged and the system suspends.
        /// </summary>
        public float DischargingTime => JSRef.Get<float>("dischargingTime");
        /// <summary>
        /// A number representing the system's battery charge level scaled to a value between 0.0 and 1.0.
        /// </summary>
        public float Level => JSRef.Get<float>("level");
        #endregion

        #region Methods
        #endregion

        #region Events
        /// <summary>
        /// Fired when the battery charging state (the charging property) is updated.
        /// </summary>
        public JSEventCallback<Event> OnChargingChange { get => new JSEventCallback<Event>("chargingchange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the battery charging time (the chargingTime property) is updated.
        /// </summary>
        public JSEventCallback<Event> OnChargingTimeChange { get => new JSEventCallback<Event>("chargingtimechange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the battery discharging time (the dischargingTime property) is updated.
        /// </summary>
        public JSEventCallback<Event> OnDischargingTimeChange { get => new JSEventCallback<Event>("dischargingtimechange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the battery level (the level property) is updated.
        /// </summary>
        public JSEventCallback<Event> OnLevelChange { get => new JSEventCallback<Event>("levelchange", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}
