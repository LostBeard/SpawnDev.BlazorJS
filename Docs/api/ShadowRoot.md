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
