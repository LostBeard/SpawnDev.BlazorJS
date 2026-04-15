# HTMLFormElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `HTMLElement`  
**Source:** `JSObjects/DOM/HTMLFormElement.cs`  
**MDN Reference:** [HTMLFormElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLFormElement)

> The HTMLFormElement interface represents a form element in the DOM. It allows access to-and, in some cases, modification of-aspects of the form, as well as access to its component elements. https://developer.mozilla.org/en-US/docs/Web/API/HTMLFormElement

## Constructors

| Signature | Description |
|---|---|
| `HTMLFormElement(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `HTMLFormElement(ElementReference elementReference)` | Get an instance from an ElementReference |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<HTMLFormElement>(...)` or constructor `new HTMLFormElement(...)`

```js
const f = document.createElement("form"); // Create a form
document.body.appendChild(f); // Add it to the document body
f.action = "/cgi-bin/some.cgi"; // Add action and method attributes
f.method = "POST";
f.submit(); // Call the form's submit() method
```

```js
document.getElementById("info").addEventListener("click", () => {
  // Get a reference to the form via its name
  const f = document.forms["formA"];
  // The form properties we're interested in
  const properties = [
    "elements",
    "length",
    "name",
    "charset",
    "action",
    "acceptCharset",
    "action",
    "enctype",
    "method",
    "target",
  ];
  // Iterate over the properties, turning them into a string that we can display to the user
  const info = properties
    .map((property) => `${property}: ${f[property]}`)
    .join("\n");

  // Set the form's <textarea> to display the form's properties
  document.forms["formA"].elements["form-info"].value = info; // document.forms["formA"]['form-info'].value would also work
});

document.getElementById("set-info").addEventListener("click", (e) => {
  // Get a reference to the form via the event target
  // e.target is the button, and .form is the form it belongs to
  const f = e.target.form;
  // Argument should be a form element reference.
  f.action = "a-different-url.cgi";
  f.name = "a-different-name";
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLFormElement)*

