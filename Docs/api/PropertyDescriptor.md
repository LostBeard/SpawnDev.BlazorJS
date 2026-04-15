# PropertyDescriptor

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/PropertyDescriptor.cs`  

> https://javascript.info/property-descriptors

## Constructors

| Signature | Description |
|---|---|
| `PropertyDescriptor(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Get` | `Function?` | get | A function which serves as a getter for the property, or undefined if there is no getter. When the property is accessed, this function is called without arguments and with this set to the object through which the property is accessed (this may not be the object on which the property is defined due to inheritance). The return value will be used as the value of the property. |
| `Set` | `Function?` | get/set | A function which serves as a setter for the property, or undefined if there is no setter. When the property is assigned, this function is called with one argument (the value being assigned to the property) and with this set to the object through which the property is assigned. |
| `HasGetter` | `bool` | get/set | Returns true if the property has a getter. |
| `HasSetter` | `bool` | get/set | Returns true if the property has a setter. |
| `HasValueProperty` | `bool` | get | Returns true if the property has a value property. |
| `CanBeRead` | `bool` | get | Returns true if the property can be read. |
| `CanBeWritten` | `bool` | get | Returns true if the property can be written. |
| `Writable` | `bool?` | get | if true, the value can be changed, otherwise it’s read-only. |
| `Enumerable` | `bool?` | get | if true, then listed in loops, otherwise not listed. |
| `Configurable` | `bool?` | get | if true, the property can be deleted and these attributes can be modified, otherwise not. |

