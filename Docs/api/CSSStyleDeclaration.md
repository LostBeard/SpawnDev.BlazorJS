# CSSStyleDeclaration

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/CSSStyleDeclaration.cs`  
**MDN Reference:** [CSSStyleDeclaration on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CSSStyleDeclaration)

> The CSSStyleDeclaration interface represents an object that is a CSS declaration block, and exposes style information and various style-related methods and properties. https://developer.mozilla.org/en-US/docs/Web/API/CSSStyleDeclaration

## Constructors

| Signature | Description |
|---|---|
| `CSSStyleDeclaration(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `CSSText` | `string` | get | Textual representation of the declaration block, if and only if it is exposed via HTMLElement.style. Setting this attribute changes the inline style. If you want a text representation of a computed declaration block, you can get it with JSON.stringify(). |
| `Length` | `int` | get | The number of properties. See the item() method below. |
| `ParentRule` | `CSSRule?` | get | The containing CSSRule. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RemoveProperty(string property)` | `string` | Removes a property from the CSS declaration block. |
| `SetProperty(string property, string value, string priority)` | `void` | Modifies an existing CSS property or creates a new CSS property in the declaration block. A string representing the CSS property name (hyphen case) to be modified. A string allowing the "important" CSS priority to be set. If not specified, treated as the empty string. The following values are accepted: "", "!important" A string containing the new property value. If not specified, treated as the empty string. |
| `GetPropertyValue(string property)` | `string` | Returns the property value given a property name. |
| `Item(int index)` | `string` | Returns a CSS property name by its index, or the empty string if the index is out-of-bounds. |
| `GetPropertyPriority(string property)` | `string` | Returns the optional priority, "important". |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<CSSStyleDeclaration>(...)` or constructor `new CSSStyleDeclaration(...)`

```js
const styleObj = document.styleSheets[0].cssRules[0].style;
console.log(styleObj.cssText);

for (let i = styleObj.length; i--; ) {
  const nameString = styleObj[i];
  styleObj.removeProperty(nameString);
}

console.log(styleObj.cssText);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CSSStyleDeclaration)*

## Examples

**JavaScript (MDN):**

```js
const styleObj = document.styleSheets[0].cssRules[0].style;
console.log(styleObj.cssText);

for (let i = styleObj.length; i--; ) {
  const nameString = styleObj[i];
  styleObj.removeProperty(nameString);
}

console.log(styleObj.cssText);
```

**C# (SpawnDev.BlazorJS):**

```csharp
// Requires: builder.Services.AddBlazorJSRuntime();
// Inject BlazorJSRuntime in your component or service:
// [Inject] BlazorJSRuntime JS { get; set; }

var styleObj = document.styleSheets[0].cssRules[0].style;
Console.WriteLine(styleObj.cssText);

for (let i = styleObj.Length; i--; ) {
var nameString = styleObj[i];
styleObj.RemoveProperty(nameString);
}

Console.WriteLine(styleObj.cssText);
```

