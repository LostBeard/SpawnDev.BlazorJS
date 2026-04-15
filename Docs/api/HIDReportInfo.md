# HIDReportInfo

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/HIDReportInfo.cs`  

> A HIDReportInfo represents one input, output, or feature report within the report descriptor. https://wicg.github.io/webhid/#dom-hidreportinfo

## Constructors

| Signature | Description |
|---|---|
| `HIDReportInfo(IJSInProcessObjectReference _ref)` | Creates a new instance of `HIDReportInfo`. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ReportId` | `byte` | get | A HID interface uses report IDs if it prepends a one-byte identification prefix to each report transfer. The reportId member is the prefix for this report if the interface uses report IDs, or 0 otherwise. |
| `Items` | `IEnumerable<HIDReportItem>` | get | A sequence of HIDReportItem representing the fields of this report. |

