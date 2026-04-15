# IntlDateTimeFormat

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/IntlDateTimeFormat.cs`  
**MDN Reference:** [IntlDateTimeFormat on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl/DateTimeFormat)

> The Intl.DateTimeFormat object enables language-sensitive date and time formatting. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl/DateTimeFormat

## Constructors

| Signature | Description |
|---|---|
| `IntlDateTimeFormat()` | Creates a new Intl.DateTimeFormat object with default locale |
| `IntlDateTimeFormat(string locales)` | Creates a new Intl.DateTimeFormat object with the specified locale A string with a BCP 47 language tag, or an array of such strings |
| `IntlDateTimeFormat(string[] locales)` | Creates a new Intl.DateTimeFormat object with the specified locales An array of strings with BCP 47 language tags |
| `IntlDateTimeFormat(string locales, IntlDateTimeFormatOptions options)` | Creates a new Intl.DateTimeFormat object with the specified locale and options A string with a BCP 47 language tag, or an array of such strings An object with some or all options |
| `IntlDateTimeFormat(string[] locales, IntlDateTimeFormatOptions options)` | Creates a new Intl.DateTimeFormat object with the specified locales and options An array of strings with BCP 47 language tags An object with some or all options |
| `IntlDateTimeFormat(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Format(DateTime date)` | `string` | Formats a date according to the locale and formatting options of this Intl.DateTimeFormat object. The date to format A string representing the given date formatted according to the locale and formatting options |
| `Format(long date)` | `string` | Formats a date according to the locale and formatting options of this Intl.DateTimeFormat object. The date to format (as milliseconds since epoch) A string representing the given date formatted according to the locale and formatting options |
| `FormatToParts(DateTime date)` | `IntlDateTimeFormatPart[]` | Returns an Array of objects representing the date string in parts that can be used for custom locale-aware formatting. The date to format An Array of objects containing the formatted date in parts |
| `FormatToParts(long date)` | `IntlDateTimeFormatPart[]` | Returns an Array of objects representing the date string in parts that can be used for custom locale-aware formatting. The date to format (as milliseconds since epoch) An Array of objects containing the formatted date in parts |
| `FormatRange(DateTime startDate, DateTime endDate)` | `string` | Formats a date range in the most concise way based on the locale and options provided when instantiating Intl.DateTimeFormat object. The start date The end date A string representing the given date range formatted according to the locale and formatting options |
| `FormatRange(long startDate, long endDate)` | `string` | Formats a date range in the most concise way based on the locale and options provided when instantiating Intl.DateTimeFormat object. The start date (as milliseconds since epoch) The end date (as milliseconds since epoch) A string representing the given date range formatted according to the locale and formatting options |
| `FormatRangeToParts(DateTime startDate, DateTime endDate)` | `IntlDateTimeFormatPart[]` | Returns an Array of objects representing the date range string in parts that can be used for custom locale-aware formatting. The start date The end date An Array of objects containing the formatted date range in parts |
| `FormatRangeToParts(long startDate, long endDate)` | `IntlDateTimeFormatPart[]` | Returns an Array of objects representing the date range string in parts that can be used for custom locale-aware formatting. The start date (as milliseconds since epoch) The end date (as milliseconds since epoch) An Array of objects containing the formatted date range in parts |
| `ResolvedOptions()` | `IntlResolvedDateTimeFormatOptions` | Returns a new object with properties reflecting the locale and date and time formatting options computed during initialization of this Intl.DateTimeFormat object. A new object with properties reflecting the locale and formatting options |
| `SupportedLocalesOf(Union<string, string[]> locales)` | `string[]` | Returns an array containing those of the provided locales that are supported in date and time formatting without having to fall back to the runtime's default locale. A string with a BCP 47 language tag, or an array of such strings An array of strings representing a subset of the given locale tags that are supported in date and time formatting |
| `SupportedLocalesOf(Union<string, string[]> locales, IntlDateTimeFormatOptions options)` | `string[]` | Returns an array containing those of the provided locales that are supported in date and time formatting without having to fall back to the runtime's default locale. A string with a BCP 47 language tag, or an array of such strings An object with a localeMatcher property An array of strings representing a subset of the given locale tags that are supported in date and time formatting |

