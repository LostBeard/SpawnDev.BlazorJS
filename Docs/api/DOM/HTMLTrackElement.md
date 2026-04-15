# HTMLTrackElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `HTMLElement`  
**Source:** `JSObjects/DOM/HTMLTrackElement.cs`  
**MDN Reference:** [HTMLTrackElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLTrackElement)

> The HTMLTrackElement interface represents an HTML track element within the DOM. https://developer.mozilla.org/en-US/docs/Web/API/HTMLTrackElement

## Constructors

| Signature | Description |
|---|---|
| `HTMLTrackElement(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `HTMLTrackElement(ElementReference elementReference)` | Get an instance from an ElementReference |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Kind` | `string` | get | A string that reflects the kind HTML attribute, indicating how the text track is meant to be used. |
| `Src` | `string` | get | A string that reflects the src HTML attribute, indicating the address of the text track data. |
| `Srclang` | `string` | get | A string that reflects the srclang HTML attribute, indicating the language of the text track data. |
| `Label` | `string` | get | A string that reflects the label HTML attribute, listing a user-readable title for the track. |
| `Default` | `bool` | get | A boolean that reflects the default HTML attribute, indicating that the track is to be enabled if the user's preferences do not indicate that another track would be more appropriate. |
| `ReadyState` | `int` | get | Returns an unsigned short that reflects the Readiness state of the track. |
| `Track` | `TextTrack` | get | Returns the TextTrack object corresponding to the track element. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnCueChange` | `ActionEvent<Event>` | Fires when a TextTrack has changed the currently displaying cues. |

