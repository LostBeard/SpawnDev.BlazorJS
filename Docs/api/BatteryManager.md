# BatteryManager

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/BatteryManager.cs`  
**MDN Reference:** [BatteryManager on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BatteryManager)

> The BatteryManager interface of the Battery Status API provides information about the system's battery charge level. The navigator.getBattery() method returns a promise that resolves with a BatteryManager interface. https://developer.mozilla.org/en-US/docs/Web/API/BatteryManager

## Constructors

| Signature | Description |
|---|---|
| `BatteryManager(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Charging` | `bool` | get | The charging read-only property of the BatteryManager interface is a Boolean value indicating whether or not the device's battery is currently being charged. When its value changes, the chargingchange event is fired. |
| `ChargingTime` | `float?` | get | The chargingTime read-only property of the BatteryManager interface indicates the amount of time, in seconds, that remain until the battery is fully charged, or 0 if the battery is already fully charged or the user agent is unable to report the battery status information. If the battery is currently discharging, its value is Infinity. When its value changes, the chargingtimechange event is fired. |
| `DischargingTime` | `float?` | get | The dischargingTime read-only property of the BatteryManager interface indicates the amount of time, in seconds, that remains until the battery is fully discharged, or Infinity if the battery is currently charging rather than discharging or the user agent is unable to report the battery status information. When its value changes, the dischargingtimechange event is fired. |
| `Level` | `float` | get | The level read-only property of the BatteryManager interface indicates the current battery charge level as a value between 0.0 and 1.0. A value of 0.0 means the battery is empty and the system is about to be suspended. A value of 1.0 means the battery is full or the user agent is unable to report the battery status information. When its value changes, the levelchange event is fired. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnChargingChange` | `ActionEvent<Event>` | Fired when the battery charging state (the charging property) is updated. |
| `OnChargingTimeChange` | `ActionEvent<Event>` | Fired when the battery charging time (the chargingTime property) is updated. |
| `OnDischargingTimeChange` | `ActionEvent<Event>` | Fired when the battery discharging time (the dischargingTime property) is updated. |
| `OnLevelChange` | `ActionEvent<Event>` | Fired when the battery level (the level property) is updated. |

