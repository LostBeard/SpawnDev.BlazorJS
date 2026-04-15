# HIDConnectionEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/HIDConnectionEvent.cs`  

> The HIDConnectionEvent interface of the WebHID API represents HID connection events, and is the event type passed to connect and disconnect event handlers when an input report is received.

## Constructors

| Signature | Description |
|---|---|
| `HIDConnectionEvent(IJSInProcessObjectReference _ref)` | Creates a new instance of `HIDConnectionEvent`. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Device` | `HIDDevice` | get | Returns the HIDDevice instance representing the device associated with the connection event. |

