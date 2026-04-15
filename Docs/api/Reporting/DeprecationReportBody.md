# DeprecationReportBody

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ReportBody`  
**Source:** `JSObjects/Reporting/DeprecationReportBody.cs`  
**MDN Reference:** [DeprecationReportBody on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DeprecationReportBody)

> The DeprecationReportBody interface of the Reporting API represents the body of a deprecation report. https://developer.mozilla.org/en-US/docs/Web/API/DeprecationReportBody

## Constructors

| Signature | Description |
|---|---|
| `DeprecationReportBody(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Id` | `string` | get | A string representing the feature or API that is deprecated, for example "insecure-origin" or "synchronous-xhr". |
| `Message` | `string` | get | A string containing a human-readable description of the deprecation, including information such as what to use instead. |
| `SourceFile` | `string?` | get | A string containing the path to the source file where the deprecated feature is used, if known, or null otherwise. |
| `LineNumber` | `int?` | get | A number representing the line in the source file in which the deprecated feature is used, if known, or null otherwise. |
| `ColumnNumber` | `int?` | get | A number representing the column in the source file in which the deprecated feature is used, if known, or null otherwise. |
| `AnticipatedRemoval` | `DateTime?` | get | A Date object (rendered as a string) representing the date when the feature is expected to be removed from the browser. If the date is not known, this property is null. |

