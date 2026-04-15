# CrashReportBody

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ReportBody`  
**Source:** `JSObjects/Reporting/CrashReportBody.cs`  
**MDN Reference:** [CrashReportBody on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CrashReportBody)

> The CrashReportBody interface of the Reporting API represents the body of a crash report. A crash report is generated when a document (or a worker) crashes. https://developer.mozilla.org/en-US/docs/Web/API/CrashReportBody

## Constructors

| Signature | Description |
|---|---|
| `CrashReportBody(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Reason` | `string` | get | A string representing the reason for the crash. The possible values are: "oom" (Out of Memory) or "unresponsive". |

