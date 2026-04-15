# TimeRanges

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/TimeRanges.cs`  
**MDN Reference:** [TimeRanges on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TimeRanges)

> When loading a media resource for use by an &lt;audio> or &lt;video> element, the TimeRanges interface is used for representing the time ranges of the media resource that have been buffered, the time ranges that have been played, and the time ranges that are seekable. A TimeRanges object includes one or more ranges of time, each specified by a starting time offset and an ending time offset. You reference each time range by using the start() and end() methods, passing the index number of the time range you want to retrieve. https://developer.mozilla.org/en-US/docs/Web/API/TimeRanges

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | Returns an unsigned long representing the number of time ranges represented by the time range object. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Start(int i)` | `double` | Returns the time for the start of the range with the specified index. The range number to return the starting time for. A number. |
| `End(int i)` | `double` | Returns the time for the end of the specified range. The range number to return the ending time for. A number. |

