# MIDIMessageEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/MIDIMessageEvent.cs`  
**MDN Reference:** [MIDIMessageEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MIDIMessageEvent)

> The MIDIMessageEvent interface of the Web MIDI API represents the event passed to the midimessage event of the MIDIInput interface. A midimessage event is fired every time a MIDI message is sent from a device represented by a MIDIInput, for example when a MIDI keyboard key is pressed, a knob is tweaked, or a slider is moved. https://developer.mozilla.org/en-US/docs/Web/API/MIDIMessageEvent

## Constructors

| Signature | Description |
|---|---|
| `MIDIMessageEvent(IJSInProcessObjectReference _ref)` | Creates a new instance of `MIDIMessageEvent`. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Data` | `Uint8Array` | get | A Uint8Array containing the data bytes of a single MIDI message. See the MIDI specification for more information on its form. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MIDIMessageEvent>(...)` or constructor `new MIDIMessageEvent(...)`

```js
navigator.requestMIDIAccess().then((midiAccess) => {
  Array.from(midiAccess.inputs).forEach((input) => {
    input[1].onmidimessage = (msg) => {
      console.log(msg);
    };
  });
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MIDIMessageEvent)*

