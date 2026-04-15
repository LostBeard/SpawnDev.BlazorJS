# XRMesh

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRMesh.cs`  

> The XRMesh interface of the WebXR Device API provides real-world geometry data such as meshes detected by the XR system. https://immersive-web.github.io/real-world-geometry/mesh-detection.html

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MeshSpace` | `XRSpace` | get | Returns an XRSpace whose native origin tracks the mesh's position and orientation. |
| `Vertices` | `Float32Array` | get | Returns a Float32Array containing the mesh vertex positions. Each vertex is 3 floats (x, y, z) in the coordinate system of meshSpace. |
| `Indices` | `Uint32Array` | get | Returns a Uint32Array containing the mesh triangle indices. Each triangle is 3 indices into the vertices array. |
| `LastChangedTime` | `double` | get | Returns a DOMHighResTimeStamp indicating the last time the mesh data was updated. |
| `SemanticLabel` | `string?` | get | Returns a string indicating the semantic label of the mesh, or null if not available. |

