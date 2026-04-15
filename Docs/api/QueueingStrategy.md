# QueueingStrategy

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/QueueingStrategy.cs`  

> A generic queueing strategy

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `HighWaterMark` | `virtual int` | get | A non-negative integer. This defines the total number of chunks that can be contained in the internal queue before backpressure is applied. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Size(object chunk)` | `int` |  |

