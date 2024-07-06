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
        /// The charging read-only property of the BatteryManager interface is a Boolean value indicating whether or not the device's battery is currently being charged. When its value changes, the chargingchange event is fired.
        /// </summary>
        public bool Charging => JSRef!.Get<bool>("charging");
        /// <summary>
        /// The chargingTime read-only property of the BatteryManager interface indicates the amount of time, in seconds, that remain until the battery is fully charged, or 0 if the battery is already fully charged or the user agent is unable to report the battery status information. If the battery is currently discharging, its value is Infinity. When its value changes, the chargingtimechange event is fired.
        /// </summary>
        public float? ChargingTime => JSRef!.Get<float?>("chargingTime");
        /// <summary>
        /// The dischargingTime read-only property of the BatteryManager interface indicates the amount of time, in seconds, that remains until the battery is fully discharged, or Infinity if the battery is currently charging rather than discharging or the user agent is unable to report the battery status information. When its value changes, the dischargingtimechange event is fired.
        /// </summary>
        public float? DischargingTime => JSRef!.Get<float?>("dischargingTime");
        /// <summary>
        /// The level read-only property of the BatteryManager interface indicates the current battery charge level as a value between 0.0 and 1.0. A value of 0.0 means the battery is empty and the system is about to be suspended. A value of 1.0 means the battery is full or the user agent is unable to report the battery status information. When its value changes, the levelchange event is fired.
        /// </summary>
        public float Level => JSRef!.Get<float>("level");
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
