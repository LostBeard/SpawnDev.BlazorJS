# MIDIPort

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/MIDIPort.cs`  
**MDN Reference:** [MIDIPort on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MIDIPort)

> The MIDIPort interface of the Web MIDI API represents a MIDI input or output port. https://developer.mozilla.org/en-US/docs/Web/API/MIDIPort

## Constructors

| Signature | Description |
|---|---|
| `MIDIPort(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Id` | `string` | get | Returns a string containing the unique ID of the port. |
| `Manufacturer` | `string` | get | Returns a string containing the manufacturer of the port. |
| `Name` | `string` | get | Returns a string containing the system name of the port. |
| `Type` | `string` | get | Returns a string containing the type of the port |
| `Version` | `string` | get | Returns a string containing the version of the port. |
| `State` | `string` | get | Returns a string containing the state of the port |
| `Connection` | `string` | get | Returns a string containing the connection state of the port |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Open()` | `Task` | Makes the MIDI device connected to this MIDIPort explicitly available, and returns a Promise which resolves once access to the port has been successful. |
| `Close()` | `Task` | Makes the MIDI device connected to this MIDIPort unavailable, changing the state from "open" to "closed". This returns a Promise which resolves once the port has been closed. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnStateChange` | `ActionEvent<MIDIConnectionEvent>` | Called when an existing port changes its state or connection. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MIDIPort>(...)` or constructor `new MIDIPort(...)`

### List ports and their information

```js
function listInputsAndOutputs(midiAccess) {
  for (const entry of midiAccess.inputs) {
    const input = entry[1];
    console.log(
      `Input port [type:'${input.type}'] id:'${input.id}' manufacturer: '${input.manufacturer}' name: '${input.name}' version: '${input.version}'`,
    );
  }

  for (const entry of midiAccess.outputs) {
    const output = entry[1];
    console.log(
      `Output port [type:'${output.type}'] id: '${output.id}' manufacturer: '${output.manufacturer}' name: '${output.name}' version: '${output.version}'`,
    );
  }
}
```

### Add available ports to a select list

```js
inputs.forEach((port, key) => {
  const opt = document.createElement("option");
  opt.text = port.name;
  document.getElementById("port-selector").add(opt);
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MIDIPort)*

