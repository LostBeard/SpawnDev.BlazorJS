# GPUPrimitiveState

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUPrimitiveState.cs`  

> An object describing how a pipeline constructs and rasterizes primitives from its vertex inputs. https://www.w3.org/TR/webgpu/#primitive-state

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPUPrimitiveState` | `class` | get | An object describing how a pipeline constructs and rasterizes primitives from its vertex inputs. https://www.w3.org/TR/webgpu/#primitive-state |
| `StripIndexFormat` | `EnumString<GPUIndexFormat>?` | get |  |
| `FrontFace` | `EnumString<GPUFrontFace>?` | get |  |
| `CullMode` | `EnumString<GPUCullMode>?` | get |  |
| `UnclippedDepth` | `bool?` | get |  |
| `Topology` | `EnumString<GPUPrimitiveTopology>?` | get/set | An enumerated value that defines the type of primitive to be constructed from the specified vertex inputs.Possible values are: "line-list": Each consecutive pair of two vertices defines a line primitive. "line-strip": Each vertex after the first defines a line primitive between it and the previous vertex. "point-list": Each vertex defines a point primitive. "triangle-list": Each consecutive triplet of three vertices defines a triangle primitive. "triangle-strip": Each vertex after the first two defines a triangle primitive between it and the previous two vertices. If omitted, topology defaults to "triangle-list". |

