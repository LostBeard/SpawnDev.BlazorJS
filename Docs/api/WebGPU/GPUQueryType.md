# GPUQueryType

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUQueryType.cs`  

> https://www.w3.org/TR/webgpu/#enumdef-gpuquerytype

## Values

| Name | JSON Value | Description |
|---|---|---|
| `Occlusion` | `"occlusion"` | Occlusion query is only available on render passes, to query the number of fragment samples that pass all the per-fragment tests for a set of drawing commands, including scissor, sample mask, alpha to coverage, stencil, and depth tests. Any non-zero result value for the query indicates that at least one sample passed the tests and reached the output merging stage of the render pipeline, 0 indicates that no samples passed the tests. When beginning a render pass, GPURenderPassDescriptor.occlusionQuerySet must be set to be able to use occlusion queries during the pass. An occlusion query is begun and ended by calling beginOcclusionQuery() and endOcclusionQuery() in pairs that cannot be nested, and resolved into a GPUBuffer as a 64-bit unsigned integer by GPUCommandEncoder.resolveQuerySet(). |
| `PipelineStatistics` | `"pipeline-statistics"` | Pipeline Statistics Query |
| `Timestamp` | `"timestamp"` | Timestamp queries allow applications to write timestamps to a GPUQuerySet, using: GPUComputePassDescriptor.timestampWrites GPURenderPassDescriptor.timestampWrites and then resolve timestamp values (in nanoseconds as a 64-bit unsigned integer) into a GPUBuffer, using GPUCommandEncoder.resolveQuerySet(). |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPUQueryType` | `enum` | get | https://www.w3.org/TR/webgpu/#enumdef-gpuquerytype |

