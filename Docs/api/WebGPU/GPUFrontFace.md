# GPUFrontFace

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUFrontFace.cs`  

> GPUFrontFace defines which polygons are considered front-facing by a GPURenderPipeline. See § 23.2.5.4 Polygon Rasterization for additional details: https://www.w3.org/TR/webgpu/#enumdef-gpufrontface

## Values

| Name | JSON Value | Description |
|---|---|---|
| `CCW` | `"ccw"` | Polygons with vertices whose framebuffer coordinates are given in counter-clockwise order are considered front-facing. |
| `CW` | `"cw"` | Polygons with vertices whose framebuffer coordinates are given in clockwise order are considered front-facing. |
