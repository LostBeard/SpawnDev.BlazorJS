# Report

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Reporting/Report.cs`  
**MDN Reference:** [Report on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Report)

> The Report interface of the Reporting API represents a single report. Reports can be accessed via the ReportingObserver interface, or via the Report-To HTTP header. https://developer.mozilla.org/en-US/docs/Web/API/Report

## Constructors

| Signature | Description |
|---|---|
| `Report(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Type` | `string` | get | A string representing the type of report generated, e.g. "deprecation" or "intervention". |
| `Url` | `string` | get | A string representing the URL of the document that generated the report. |
| `Body` | `ReportBody?` | get | A ReportBody object containing the body of the report. The interface of the body depends on the type of report. |

