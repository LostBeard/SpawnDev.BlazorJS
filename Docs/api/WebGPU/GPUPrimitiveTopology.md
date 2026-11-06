# GPUPrimitiveTopology

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUPrimitiveTopology.cs`  

> GPUPrimitiveTopology defines the primitive type draw calls made with a GPURenderPipeline will use. See § 23.2.5 Rasterization for additional details: https://www.w3.org/TR/webgpu/#enumdef-gpuprimitivetopology

## Values

| Name | JSON Value | Description |
|---|---|---|
| `PointList` | `"point-list"` | Each vertex defines a point primitive. |
| `LineList` | `"line-list"` | Each consecutive pair of two vertices defines a line primitive. |
| `LineStrip` | `"line-strip"` | Each vertex after the first defines a line primitive between it and the previous vertex. |
| `TriangleList` | `"triangle-list"` | Each consecutive triplet of three vertices defines a triangle primitive. |
| `TriangleStrip` | `"triangle-strip"` | Each vertex after the first two defines a triangle primitive between it and the previous two vertices. |
