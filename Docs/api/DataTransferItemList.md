# DataTransferItemList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DataTransferItemList.cs`  
**MDN Reference:** [DataTransferItemList on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DataTransferItemList)

> The DataTransferItemList object is a list of DataTransferItem objects representing items being dragged. During a drag operation, each DragEvent has a dataTransfer property and that property is a DataTransferItemList. https://developer.mozilla.org/en-US/docs/Web/API/DataTransferItemList

## Constructors

| Signature | Description |
|---|---|
| `DataTransferItemList(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | An unsigned long that is the number of drag items in the list. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Add(string data)` | `DataTransferItem` | Adds an item (either a File object or a string) to the drag item list and returns a DataTransferItem object for the new item. |
| `Add(File data)` | `DataTransferItem` | Adds an item (either a File object or a string) to the drag item list and returns a DataTransferItem object for the new item. |
| `Remove(int index)` | `void` | Removes the drag item from the list at the given index. |
| `Clear(int index)` | `void` | Removes all of the drag items from the list. |
| `Item(int index)` | `DataTransferItem` | Indexer property |
| `FirstOrDefault()` | `DataTransferItem?` | Returns first or default |
| `LastOrDefault()` | `DataTransferItem?` | Returns last or default |
| `ToArray()` | `DataTransferItem[]` | Returns the array as a .Net Array |
| `ToArray(int start, int count)` | `DataTransferItem[]` | Returns the array as a .Net Array |
| `ToList()` | `List<DataTransferItem>` | Returns the array as a .Net List |
| `ToList(int start, int count)` | `List<DataTransferItem>` | Returns the array as a .Net List |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<DataTransferItemList>(...)` or constructor `new DataTransferItemList(...)`

### JavaScript

```js
const source = document.getElementById("source");
const target = document.getElementById("target");

source.addEventListener("dragstart", (ev) => {
  console.log("dragStart");

  // Add this element's id to the drag payload so the drop handler will
  // know which element to add to its tree
  const dataList = ev.dataTransfer.items;
  dataList.add(ev.target.id, "text/plain");

  // Add some other items to the drag payload
  dataList.add("<p>Paragraph…</p>", "text/html");
  dataList.add("http://www.example.org", "text/uri-list");
});

source.addEventListener("dragend", (ev) => {
  console.log("dragEnd");
  const dataList = ev.dataTransfer.items;

  // Clear any remaining drag data
  dataList.clear();
});

target.addEventListener("drop", (ev) => {
  console.log("Drop");
  ev.preventDefault();

  // Loop through the dropped items and log their data
  for (const item of ev.dataTransfer.items) {
    if (item.kind === "string" && item.type.match(/^text\/plain/)) {
      // This item is the target node
      item.getAsString((s) => {
        ev.target.appendChild(document.getElementById(s));
      });
    } else if (item.kind === "string" && item.type.match(/^text\/html/)) {
      // Drag data item is HTML
      item.getAsString((s) => {
        console.log(`… Drop: HTML = ${s}`);
      });
    } else if (item.kind === "string" && item.type.match(/^text\/uri-list/)) {
      // Drag data item is URI
      item.getAsString((s) => {
        console.log(`… Drop: URI = ${s}`);
      });
    }
  }
});

target.addEventListener("dragover", (ev) => {
  console.log("dragOver");
  ev.preventDefault();

  // Set the dropEffect to move
  ev.dataTransfer.dropEffect = "move";
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DataTransferItemList)*

