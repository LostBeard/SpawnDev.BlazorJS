# TransferableAttribute

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Attribute`  
**Source:** `JSObjects/TransferableAttribute.cs`  

> Indicates the class type is a transferable object. Transferable objects are objects that own resources that can be transferred from one context to another, ensuring that the resources are only available in one context at a time. Following a transfer, the original object is no longer usable; it no longer points to the transferred resource, and any attempt to read or write the object will throw an exception. https://developer.mozilla.org/en-US/docs/Web/API/Web_Workers_API/Transferable_objects

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `TransferRequired` | `bool` | get/set | If true, an object of this type must be transferred when used with PostMessage (Ex. OffscreenCanvas) |

## Static Methods

| Method | Return Type | Description |
|---|---|---|
| `GetTransferable(Type type)` | `TransferableAttribute?` | Retrieves the first TransferableAttribute applied to the specified type, if present. |
| `GetTransferable<T>()` | `TransferableAttribute?` | Retrieves the first TransferableAttribute applied to the specified type, if present. |
| `IsTransferable(Type type)` | `bool` | Determines whether the specified type is marked as transferable. |
| `IsTransferable<T>()` | `bool` | Determines whether the specified type is marked as transferable. |
