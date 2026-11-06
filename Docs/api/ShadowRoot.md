# ShadowRoot

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** JSObject -> EventTarget -> Node -> DocumentFragment -> ShadowRoot  
**MDN Reference:** [ShadowRoot on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ShadowRoot)  
**Source:** `SpawnDev.BlazorJS/JSObjects/DOM/ShadowRoot.cs`

> The ShadowRoot interface of the Shadow DOM API is the root node of a DOM subtree that is rendered separately from a document's main DOM tree. Shadow DOM provides encapsulation for DOM and CSS.

## Constructor

```csharp
public ShadowRoot(IJSInProcessObjectReference _ref)
```

## Properties

| Property | Type | Description |
|---|---|---|
| `DelegatesFocus` | `bool` | Whether the shadow root delegates focus. |
| `Host` | `Element` | The host element this shadow root is attached to. |
| `InnerHTML` | `string` | Get/set the HTML content of the shadow root. |
| `Mode` | `string` | The mode of the shadow root ("open" or "closed"). |
| `ActiveElement` | `Element?` | The currently focused element within the shadow root. |
| `AdoptedStyleSheets` | `Array<CSSStyleSheet>` | Add an array of constructed stylesheets to be used by the shadow DOM subtree. These may be shared with other DOM subtrees that share the same parent Document node, and the document itself. |
| `Clonable` | `bool` | A boolean that indicates whether the shadow root is clonable. |
| `CustomElementRegistry` | `CustomElementRegistry?` | Returns the CustomElementRegistry object associated with this shadow root, or null if one has not been set. |
| `FullscreenElement` | `Element?` | The Document.fullscreenElement read-only property returns the Element that is currently being presented in fullscreen mode in this document, or null if fullscreen mode is not currently in use. |
| `PictureInPictureElement` | `Element?` | The Document.pictureInPictureElement read-only property returns the Element that is currently being presented in picture-in-picture mode in this document, or null if picture-in-picture mode is not currently in use. |
| `PointerLockElement` | `Element?` | The read-only pointerLockElement property of the Document interface provides the element set as the target for mouse events while the pointer is locked. It is null if lock is pending, pointer is unlocked, or the target is in another document. |
| `SlotAssignment` | `string` | Returns the slot assignment mode of the ShadowRoot, either "manual" or "named". |
| `Slots` | `NodeList<Element>` | Returns a NodeList of the slot elements in the ShadowRoot. |
| `IsActive` | `bool` | Returns a boolean indicating whether the ShadowRoot is in a state where it can be used. |
| `StyleSheets` | `StyleSheetList` | Returns the style sheets associated with the ShadowRoot. |
| `ShadowRootMode` | `string` | Returns the shadow root's mode, either "open" or "closed". |
| `ShadowHost` | `Element` | Returns the shadow root's host element. |

## Example

```csharp
using var element = doc.QuerySelector<Element>("#myComponent");

// Attach a shadow root
using var shadow = element!.AttachShadow(new AttachShadowRootOptions { Mode = "open" });

// Set content
shadow.InnerHTML = @"
    <style>
        :host { display: block; }
        p { color: blue; }
    </style>
    <p>Shadow DOM content</p>
";

// Access host
using var host = shadow.Host;
Console.WriteLine($"Host tag: {host.TagName}");
```
