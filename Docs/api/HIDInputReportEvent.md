# HIDInputReportEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/HIDInputReportEvent.cs`  

> Represents a HIDInputReportEvent fired by a HID device. This event contains the report data received from a HID device. Corresponds to the WebHID 'HIDInputReportEvent' interface. https://wicg.github.io/webhid/#hidinputreportevent-interface

## Constructors

| Signature | Description |
|---|---|
| `HIDInputReportEvent(IJSInProcessObjectReference _ref)` | Creates a new instance of `HIDInputReportEvent`. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Device` | `HIDDevice` | get | The HIDDevice object associated with this event, representing the device that sent the input report. |
| `ReportId` | `byte` | get | An 8-bit value indicating the report ID of the input report. A value of 0 means the device does not use report IDs. |
| `Data` | `DataView` | get | A DataView object containing the raw input report data. |

