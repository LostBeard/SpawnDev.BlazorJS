# HTMLScriptElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `HTMLElement`  
**Source:** `JSObjects/DOM/HTMLScriptElement.cs`  
**MDN Reference:** [HTMLScriptElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLScriptElement)

> HTML script elements expose the HTMLScriptElement interface, which provides special properties and methods for manipulating the behavior and execution of script elements (beyond the inherited HTMLElement interface). https://developer.mozilla.org/en-US/docs/Web/API/HTMLScriptElement

## Constructors

| Signature | Description |
|---|---|
| `HTMLScriptElement(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `HTMLScriptElement(ElementReference elementReference)` | Get an instance from an ElementReference |
| `HTMLScriptElement()` | Shortcut method for document.createElement('script') Non-standard implementation |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Defer` | `bool` | get | If the async attribute is present, then the script will be executed asynchronously as soon as it downloads. If the async attribute is absent but the defer attribute is present, then the script is executed when the page has finished parsing. If neither attribute is present, then the script is fetched and executed immediately, blocking further parsing of the page. The defer attribute may be specified with the async attribute, so legacy browsers that only support defer (and not async) fall back to the defer behavior instead of the default blocking behavior. |
| `Async` | `bool` | get | If the async attribute is present, then the script will be executed asynchronously as soon as it downloads. If the async attribute is absent but the defer attribute is present, then the script is executed when the page has finished parsing. If neither attribute is present, then the script is fetched and executed immediately, blocking further parsing of the page. The defer attribute may be specified with the async attribute, so legacy browsers that only support defer (and not async) fall back to the defer behavior instead of the default blocking behavior. |
| `CrossOrigin` | `string` | get | A string reflecting the CORS setting for the script element. For classic scripts from other origins, this controls if error information will be exposed. |
| `Text` | `string` | get | A string that joins and returns the contents of all Text nodes inside the script element (ignoring other nodes like comments) in tree order. On setting, it acts the same way as the textContent IDL attribute. |
| `Type` | `string` | get | A string representing the MIME type of the script. It reflects the type attribute. |
| `Src` | `string` | get | A string representing the URL of an external script. It reflects the src attribute. |
| `NoModule` | `bool` | get | A boolean value that if true, stops the script's execution in browsers that support ES modules - used to run fallback scripts in older browsers that do not support JavaScript modules. |
| `ReferrerPolicy` | `string` | get | A string that reflects the referrerPolicy HTML attribute indicating which referrer to use when fetching the script, and fetches done by that script. |
| `FetchPriority` | `string` | get | An optional string representing a hint given to the browser on how it should prioritize fetching of an external script relative to other external scripts. If this value is provided, it must be one of the possible permitted values: high to fetch at a high priority, low to fetch at a low priority, or auto to indicate no preference (which is the default). |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `OnLoadAsync()` | `Task` | Returns a task that will fulfill when the script load, or error event ar called Non-standard implementation |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<HTMLScriptElement>(...)` or constructor `new HTMLScriptElement(...)`

### Dynamically importing scripts

```js
function loadError(oError) {
  throw new URIError(`The script ${oError.target.src} didn't load correctly.`);
}

function prefixScript(url, onloadFunction) {
  const newScript = document.createElement("script");
  newScript.onerror = loadError;
  if (onloadFunction) {
    newScript.onload = onloadFunction;
  }
  document.currentScript.parentNode.insertBefore(
    newScript,
    document.currentScript,
  );
  newScript.src = url;
}
```

### Dynamically importing scripts

```js
function loadError(oError) {
  throw new URIError(`The script ${oError.target.src} didn't load correctly.`);
}

function affixScriptToHead(url, onloadFunction) {
  const newScript = document.createElement("script");
  newScript.onerror = loadError;
  if (onloadFunction) {
    newScript.onload = onloadFunction;
  }
  document.head.appendChild(newScript);
  newScript.src = url;
}
```

### Dynamically importing scripts

```js
affixScriptToHead("myScript1.js");
affixScriptToHead("myScript2.js", () => {
  alert('The script "myScript2.js" has been correctly loaded.');
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLScriptElement)*

