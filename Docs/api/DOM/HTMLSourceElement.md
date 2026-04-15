# HTMLSourceElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `HTMLElement`  
**Source:** `JSObjects/DOM/HTMLSourceElement.cs`  
**MDN Reference:** [HTMLSourceElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLSourceElement)

> The HTMLSourceElement interface provides special properties (beyond the regular HTMLElement object interface it also has available to it by inheritance) for manipulating &lt;source> elements. https://developer.mozilla.org/en-US/docs/Web/API/HTMLSourceElement

## Constructors

| Signature | Description |
|---|---|
| `HTMLSourceElement(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `HTMLSourceElement(ElementReference elementReference)` | Constructor for ElementReference |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Src` | `string?` | get | A DOMString reflecting the src attribute, containing the URL for the media resource. |
| `Type` | `string?` | get | A DOMString reflecting the type attribute, containing the type of media resource. |
| `Media` | `string?` | get | A DOMString reflecting the media attribute, containing the intended media type of the media resource. |
| `Sizes` | `string?` | get/set | A DOMString reflecting the sizes attribute, containing the sizes of the icons for visual media. |
| `SrcSet` | `string?` | get | A DOMString reflecting the srcset attribute, containing a list of one or more strings separated by commas indicating a set of possible image sources for the user agent to use. |
| `Width` | `string?` | get | A DOMString reflecting the width attribute, containing the horizontal size of the image resource. |
| `Height` | `string?` | get | A DOMString reflecting the height attribute, containing the vertical size of the image resource. |

