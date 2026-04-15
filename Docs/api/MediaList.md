# MediaList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/MediaList.cs`  
**MDN Reference:** [MediaList on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaList)

> The MediaList interface represents the media queries of a stylesheet, e.g. those set using a @media rule, or when using the media attribute in a link element or an HTMLStyleElement. https://developer.mozilla.org/en-US/docs/Web/API/MediaList

## Constructors

| Signature | Description |
|---|---|
| `MediaList(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get/set | Returns the number of media queries in the MediaList. |
| `MediaText` | `string` | get | A stringifier that returns a string representing the MediaList as text, and also allows you to set a new MediaList. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Item(int index)` | `string?` | A getter that returns a string representing a media query as text, given the media query's index value inside the MediaList. This method can also be called using the bracket ([]) syntax. |
| `AppendMedium(string medium)` | `void` | Adds a media query to the MediaList. A string containing the media query to add. |
| `DeleteMedium(string medium)` | `void` | Removes a media query from the MediaList. A string containing the media query to remove from the list. |
| `ToString()` | `string` | Returns a string representation of this media list in the same format as the object's MediaList.mediaText property. |
| `ToList()` | `List<string>` | Returns as a list |
| `ToArray()` | `string[]` | Returns as an array |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MediaList>(...)` or constructor `new MediaList(...)`

```js
const stylesheets = document.styleSheets;
let stylesheet = stylesheets[0];
console.log(stylesheet.media.mediaText);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaList)*

