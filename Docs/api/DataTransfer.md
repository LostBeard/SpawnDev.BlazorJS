# DataTransfer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DataTransfer.cs`  
**MDN Reference:** [DataTransfer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DataTransfer)

> The DataTransfer object is used to hold the data that is being dragged during a drag and drop operation. It may hold one or more data items, each of one or more data types. For more information about drag and drop, see HTML Drag and Drop API. https://developer.mozilla.org/en-US/docs/Web/API/DataTransfer

## Constructors

| Signature | Description |
|---|---|
| `DataTransfer(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Items` | `DataTransferItemList` | get | Gives a DataTransferItemList object which is a list of all of the drag data. |
| `Files` | `FileList?` | get | Contains a list of all the local files available on the data transfer. If the drag operation doesn't involve dragging files, this property is an empty list. |
| `DropEffect` | `string` | get | Gets the type of drag-and-drop operation currently selected or sets the operation to a new type. The value must be none, copy, link or move |
| `EffectAllowed` | `string` | get | Provides all of the types of operations that are possible. Must be one of none, copy, copyLink, copyMove, link, linkMove, move, all or uninitialized. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `SetDragImage(Element imgElement, long xOffset, long yOffset)` | `void` | Set the image to be used for dragging if a custom one is desired. |
| `SetData(string format, string data)` | `void` | Set the data for a given type. If data for the type does not exist, it is added at the end, such that the last item in the types list will be the new format. If data for the type already exists, the existing data is replaced in the same position. |
| `ClearData()` | `void` | Remove the data associated with a given type. The type argument is optional. If the type is empty or not specified, the data associated with all types is removed. If data for the specified type does not exist, or the data transfer contains no data, this method will have no effect. |
| `ClearData(string format)` | `void` | Remove the data associated with a given type. The type argument is optional. If the type is empty or not specified, the data associated with all types is removed. If data for the specified type does not exist, or the data transfer contains no data, this method will have no effect. |
| `GetData(string format)` | `string` | Retrieves the data for a given type, or an empty string if data for that type does not exist or the data transfer contains no data. |
| `AddElement(Element element)` | `void` | The DataTransfer.addElement() method sets the drag source to the given element. This element will be the element to which drag and dragend events are fired, and not the default target (the node that was dragged). |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<DataTransfer>(...)` or constructor `new DataTransfer(...)`

### Reading the data in a paste or drop event

```js
const form = document.querySelector("form");

function displayData(event) {
  if (event.type === "drop") event.preventDefault();

  const cells = event.target.nextElementSibling.querySelectorAll("td");
  cells[0].textContent = event.type;
  const transfer = event.clipboardData || event.dataTransfer;
  const ol = document.createElement("ol");
  cells[1].textContent = "";
  cells[1].appendChild(ol);
  for (const item of transfer.items) {
    const li = document.createElement("li");
    li.textContent = `${item.kind} ${item.type}`;
    ol.appendChild(li);
  }
}

form.addEventListener("paste", displayData);
form.addEventListener("drop", displayData);
form.addEventListener("reset", () => {
  for (const cell of form.querySelectorAll("[contenteditable], td")) {
    cell.textContent = "";
  }
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DataTransfer)*

