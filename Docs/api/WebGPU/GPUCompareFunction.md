# GPUCompareFunction

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUCompareFunction.cs`  

> GPUCompareFunction specifies the behavior of a comparison sampler. If a comparison sampler is used in a shader, the depth_ref is compared to the fetched texel value, and the result of this comparison test is generated (1.0f for pass, or 0.0f for fail). After comparison, if texture filtering is enabled, the filtering step occurs, so that comparison results are mixed together resulting in values in the range [0, 1]. Filtering should behave as usual, however it may be computed with lower precision or not mix results at all.

## Values

| Name | JSON Value | Description |
|---|---|---|
| `Never` | `"never"` | Comparison tests never pass. |
| `Less` | `"less"` | A provided value passes the comparison test if it is less than the sampled value. |
| `Equal` | `"equal"` | A provided value passes the comparison test if it is equal to the sampled value. |
| `LessEqual` | `"less-equal"` | A provided value passes the comparison test if it is less than or equal to the sampled value. |
| `Greater` | `"greater"` | A provided value passes the comparison test if it is greater than the sampled value. |
| `NotEqual` | `"not-equal"` | A provided value passes the comparison test if it is not equal to the sampled value. |
| `GreaterEqual` | `"greater-equal"` | A provided value passes the comparison test if it is greater than or equal to the sampled value. |
| `Always` | `"always"` | Comparison tests always pass. |
