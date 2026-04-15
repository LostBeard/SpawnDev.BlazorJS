# HTMLIFrameElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `HTMLElement`  
**Source:** `JSObjects/DOM/HTMLIFrameElement.cs`  
**MDN Reference:** [HTMLIFrameElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLIFrameElement)

> The HTMLIFrameElement interface provides special properties and methods (beyond those of the HTMLElement interface it also has available to it by inheritance) for manipulating the layout and presentation of inline frame elements. https://developer.mozilla.org/en-US/docs/Web/API/HTMLIFrameElement

## Constructors

| Signature | Description |
|---|---|
| `HTMLIFrameElement(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `HTMLIFrameElement(ElementReference elementReference)` | Get an instance from an ElementReference |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Src` | `string` | get | A string that reflects the src HTML attribute, containing the address of the content to be embedded. Note that programmatically removing an iframe's src attribute (e.g. via Element.removeAttribute()) causes about:blank to be loaded in the frame in Firefox (from version 65), Chromium-based browsers, and Safari/iOS. |
| `AllowFullscreen` | `bool` | get | A boolean value indicating whether the inline frame is willing to be placed into full screen mode. See Using fullscreen mode for details. |
| `ContentDocument` | `Document` | get | Returns a Document, the active document in the inline frame's nested browsing context. |
| `ContentWindow` | `Window` | get | Returns a WindowProxy, the window proxy for the nested browsing context. |
| `Credentialless` | `bool` | get | A boolean value indicating whether the &lt;iframe&gt; is credentialless, meaning that its content is loaded in a new, ephemeral context. This context does not have access to the parent context's shared storage and credentials. In return, the Cross-Origin-Embedder-Policy (COEP) embedding rules can be lifted, so documents with COEP set can embed third-party documents that do not. See IFrame credentialless for a deeper explanation. |
| `Csp` | `string` | get | Specifies the Content Security Policy that an embedded document must agree to enforce upon itself. |
| `Height` | `string` | get | A string that reflects the height HTML attribute, indicating the height of the frame. |
| `Loading` | `string` | get | A string providing a hint to the browser that the iframe should be loaded immediately (eager) or on an as-needed basis (lazy). This reflects the loading HTML attribute. |
| `Name` | `string` | get | A string that reflects the name HTML attribute, containing a name by which to refer to the frame. |
| `ReferrerPolicy` | `string` | get/set | A string that reflects the referrerPolicy HTML attribute indicating which referrer to use when fetching the linked resource. |
| `SrcDoc` | `string` | get | A string that represents the content to display in the frame. |
| `Width` | `string` | get | A string that reflects the width HTML attribute, indicating the width of the frame. |

