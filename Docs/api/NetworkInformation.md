# NetworkInformation

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/NetworkInformation.cs`  
**MDN Reference:** [NetworkInformation on MDN](https://developer.mozilla.org/en-US/docs/Web/API/NetworkInformation)

> The NetworkInformation interface of the Network Information API provides information about the connection a device is using to communicate with the network and provides a means for scripts to be notified if the connection type changes. The NetworkInformation interface cannot be instantiated. It is instead accessed through the connection property of the Navigator interface. https://developer.mozilla.org/en-US/docs/Web/API/NetworkInformation

## Constructors

| Signature | Description |
|---|---|
| `NetworkInformation(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Downlink` | `float` | get | Returns the effective bandwidth estimate in megabits per second, rounded to the nearest multiple of 25 kilobits per seconds. |
| `EffectiveType` | `string` | get | Returns the effective type of the connection meaning one of 'slow-2g', '2g', '3g', or '4g'. This value is determined using a combination of recently observed round-trip time and downlink values. |
| `Rtt` | `float` | get/set | Returns the estimated effective round-trip time of the current connection, rounded to the nearest multiple of 25 milliseconds. |
| `SaveData` | `bool` | get | Returns true if the user has set a reduced data usage option on the user agent. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnChange` | `ActionEvent<Event>` | The change event fires when connection information changes, and the event is received by the NetworkInformation object. |

