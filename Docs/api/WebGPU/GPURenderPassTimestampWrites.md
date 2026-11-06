# GPURenderPassTimestampWrites

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPURenderPassDescriptor.cs`  

> Defines timestamp write operations for a render pass. https://www.w3.org/TR/webgpu/#dictdef-gpurenderpasstimestampwrites

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `QuerySet` | `GPUQuerySet` | get/set | The GPUQuerySet to write timestamp values to. |
| `BeginningOfPassWriteIndex` | `int?` | get/set | The index of the query in the query set at which to write the beginning timestamp. |
| `EndOfPassWriteIndex` | `int?` | get/set | The index of the query in the query set at which to write the ending timestamp. |
