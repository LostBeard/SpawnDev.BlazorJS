# Performance

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Performance.cs`  
**MDN Reference:** [Performance on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Performance)

> The Performance interface provides access to performance-related information for the current page. https://developer.mozilla.org/en-US/docs/Web/API/Performance

## Constructors

| Signature | Description |
|---|---|
| `Performance(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `EventCounts` | `EventCounts` | get |  |
| `Memory` | `JSObject` | get |  |
| `Navigation` | `PerformanceNavigation` | get |  |
| `TimeOrigin` | `Number` | get |  |
| `Timing` | `PerformanceTiming` | get |  |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ClearMarks()` | `void` |  |
| `ClearMeasures()` | `void` |  |
| `ClearResourceTimings()` | `void` |  |
| `GetEntries()` | `void` |  |
| `GetEntriesByName()` | `void` |  |
| `GetEntriesByType()` | `void` |  |
| `Mark()` | `void` |  |
| `Measure()` | `void` |  |
| `Now()` | `double` | Returns a DOMHighResTimeStamp representing the number of milliseconds elapsed since a reference instant. |
| `SetResourceTimingBufferSize()` | `void` |  |
| `ToJSON()` | `void` |  |

## Events

| Event | Type | Description |
|---|---|---|
| `OnResourceTimingBufferFull` | `ActionEvent<Event>` | The resourcetimingbufferfull event is fired when the browser's resource timing buffer is full. |

## Example

```csharp
// Get the Performance object from the global scope
using var performance = JS.Get<Performance>("performance");

// Get a high-resolution timestamp (milliseconds since page load)
double now = performance.Now();
Console.WriteLine($"Time since page load: {now}ms");

// Measure execution time of an operation
double start = performance.Now();
// ... perform some work ...
double end = performance.Now();
Console.WriteLine($"Operation took {end - start:F2}ms");
```

