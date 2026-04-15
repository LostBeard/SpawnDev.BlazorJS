# CustomQueuingStrategy

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `QueueingStrategy`  
**Source:** `JSObjects/CustomQueuingStrategy.cs`  

> Custom queueing strategy

## Constructors

| Signature | Description |
|---|---|
| `CustomQueuingStrategy(int highWaterMark, Func<JSObject, int> size)` | The ByteLengthQueuingStrategy() constructor creates and returns a ByteLengthQueuingStrategy object instance. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `HighWaterMark` | `override int` | get | A non-negative integer. This defines the total number of chunks that can be contained in the internal queue before backpressure is applied. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Size(object chunk)` | `int` |  |

