# CustomElementRegistry

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DOM/CustomElementRegistry.cs`  

> The CustomElementRegistry interface provides methods for registering custom elements and querying registered elements. To get an instance of it, use the window.customElements property. To create a scoped registry, use the CustomElementRegistry() constructor. https://developer.mozilla.org/en-US/docs/Web/API/CustomElementRegistry

## Constructors

| Signature | Description |
|---|---|
| `CustomElementRegistry(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Define(string name, object constructor)` | `void` | The define() method of the CustomElementRegistry interface adds a definition for a custom element to the custom element registry, mapping its name to the constructor which will be used to create it. |
| `Define(string name, object constructor, CustomElementOptions options)` | `void` | The define() method of the CustomElementRegistry interface adds a definition for a custom element to the custom element registry, mapping its name to the constructor which will be used to create it. |
| `Get(string name)` | `JSObject?` | The get() method of the CustomElementRegistry interface returns the constructor for a previously-defined custom element. |
| `Get(object constructor)` | `string?` | The getName() method of the CustomElementRegistry interface returns the name for a previously-defined custom element. |
| `Upgrade(Node root)` | `void` | The upgrade() method of the CustomElementRegistry interface upgrades all shadow-containing custom elements in a Node subtree, even before they are connected to the main document. |
| `Initialize(Node root)` | `void` | The initialize() method of the CustomElementRegistry interface associates this registry with a DOM subtree, setting the customElementRegistry of each inclusive descendant that doesn't already have one, and attempting to upgrade any custom elements found. |
| `WhenDefined(string name)` | `Task<JSObject>` | The whenDefined() method of the CustomElementRegistry interface returns a Promise that resolves when the named element is defined. |
