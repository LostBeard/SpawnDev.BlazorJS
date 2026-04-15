# InterventionReportBody

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ReportBody`  
**Source:** `JSObjects/Reporting/InterventionReportBody.cs`  
**MDN Reference:** [InterventionReportBody on MDN](https://developer.mozilla.org/en-US/docs/Web/API/InterventionReportBody)

> The InterventionReportBody interface of the Reporting API represents the body of an intervention report. https://developer.mozilla.org/en-US/docs/Web/API/InterventionReportBody

## Constructors

| Signature | Description |
|---|---|
| `InterventionReportBody(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Id` | `string` | get | A string representing the intervention that occurred, for example "audio-output-device-permission". |
| `Message` | `string` | get | A string containing a human-readable description of the intervention, including information such as how to fix the issue. |
| `SourceFile` | `string?` | get | A string containing the path to the source file where the intervention occurred, if known, or null otherwise. |
| `LineNumber` | `int?` | get | A number representing the line in the source file in which the intervention occurred, if known, or null otherwise. |
| `ColumnNumber` | `int?` | get | A number representing the column in the source file in which the intervention occurred, if known, or null otherwise. |

