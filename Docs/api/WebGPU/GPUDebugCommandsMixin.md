# GPUDebugCommandsMixin

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUDebugCommandsMixin.cs`  

> https://www.w3.org/TR/webgpu/#gpudebugcommandsmixin

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPUDebugCommandsMixin` | `interface` | get | https://www.w3.org/TR/webgpu/#gpudebugcommandsmixin |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `PushDebugGroup(string groupLabel)` | `void` | Begins a labeled debug group containing subsequent commands. |
| `PopDebugGroup()` | `void` | Ends the labeled debug group most recently started by pushDebugGroup(). |
| `InsertDebugMarker(string markerLabel)` | `void` | Marks a point in a stream of commands with a label. |

