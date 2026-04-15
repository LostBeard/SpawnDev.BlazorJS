# IntlDateTimeFormatPart

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/IntlDateTimeFormatPart.cs`  
**MDN Reference:** [IntlDateTimeFormatPart on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl/DateTimeFormat/formatToParts)

> Represents a part of a formatted date/time string returned by Intl.DateTimeFormat.formatToParts() https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl/DateTimeFormat/formatToParts

## Constructors

| Signature | Description |
|---|---|
| `IntlDateTimeFormatPart(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Type` | `string` | get | The type of the token. Possible values are: "day", "dayPeriod", "era", "fractionalSecond", "hour", "literal", "minute", "month", "relatedYear", "second", "timeZoneName", "weekday", "year", "yearName" |
| `Value` | `string` | get | The string value of the token |
| `Source` | `string?` | get | The source of the token. Possible values are: "shared", "startRange", "endRange". Only present in formatRangeToParts() results. |

