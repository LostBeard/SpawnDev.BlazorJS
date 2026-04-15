# Date

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Date.cs`  
**MDN Reference:** [Date on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Date)

> JavaScript Date objects represent a single moment in time in a platform-independent format. Date objects encapsulate an integral number that represents milliseconds since the midnight at the beginning of January 1, 1970, UTC (the epoch). https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Date

## Constructors

| Signature | Description |
|---|---|
| `Date()` | Creates a new Date object. |
| `Date(DateTime dateTime)` | Create a new instance of Date from .Net DateTime |
| `Date(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `DateTime` | `DateTime` | get | Returns a .Net DateTime |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `DateTime(Date dateTime)` | `implicit operator` | Returns the Date.ateTime property |
| `GetTime()` | `long` | Returns the numeric value of the specified date as the number of milliseconds since January 1, 1970, 00:00:00 UTC. (Negative values are returned for prior times.) |
| `GetTimezoneOffset()` | `int` | Returns the time-zone offset in minutes for the current locale. |
| `ToISOString()` | `string` | Converts a date to a string following the ISO 8601 Extended Format. |
| `GetDateTimeOffset()` | `DateTimeOffset` | Returns the DateTimeOffset |

