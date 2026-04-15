# Intl

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Intl.cs`  
**MDN Reference:** [Intl on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl)

> The Intl namespace object contains several constructors as well as functionality common to the internationalization constructors and other language sensitive functions. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl

## Constructors

| Signature | Description |
|---|---|
| `Intl()` | Gets the global Intl instance |
| `Intl(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetCanonicalLocales(Union<string, string[]> locales)` | `string[]` | Returns an array containing the canonical locale names. Duplicates will be omitted and elements will be validated as structurally valid language tags. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl/getCanonicalLocales A string or array of strings to get the canonical locale names for An array containing the canonical locale names |
| `SupportedValuesOf(string key)` | `string[]` | Returns an array containing the supported values for a given key. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl/supportedValuesOf A string key indicating the category of values to return. Possible values are: "calendar", "collation", "currency", "numberingSystem", "timeZone", "unit" A sorted array of unique string values |

