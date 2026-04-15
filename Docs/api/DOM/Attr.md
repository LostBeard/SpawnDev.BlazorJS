# Attr

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Node`  
**Source:** `JSObjects/DOM/Attr.cs`  
**MDN Reference:** [Attr on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Attr)

> The Attr interface represents one of an element's attributes as an object. In most situations, you will directly retrieve the attribute value as a string (e.g., Element.getAttribute()), but some cases may require interacting with Attr instances (e.g., Element.getAttributeNode()). https://developer.mozilla.org/en-US/docs/Web/API/Attr

## Constructors

| Signature | Description |
|---|---|
| `Attr(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `LocalName` | `string` | get | A string representing the local part of the qualified name of the attribute. |
| `Name` | `string` | get | The attribute's qualified name. If the attribute is not in a namespace, it will be the same as localName property. |
| `NamespaceURI` | `string` | get | A string representing the URI of the namespace of the attribute, or null if there is no namespace. |
| `OwnerElement` | `HTMLAnchorElement` | get | The Element the attribute belongs to. |
| `Prefix` | `string` | get/set | A string representing the namespace prefix of the attribute, or null if a namespace without prefix or no namespace are specified. |
| `Value` | `string` | get | The attribute's value, a string that can be set and get using this property. |

