# GPUBlendFactor

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUBlendFactor.cs`  

> GPUBlendFactor defines how either a source or destination blend factors is calculated: https://www.w3.org/TR/webgpu/#enumdef-gpublendfactor

## Values

| Name | JSON Value | Description |
|---|---|---|
| `Zero` | `"zero"` | (0, 0, 0, 0) |
| `One` | `"one"` | (1, 1, 1, 1) |
| `Src` | `"src"` | (Rsrc, Gsrc, Bsrc, Asrc) |
| `OneMinusSrc` | `"one-minus-src"` | (1 - Rsrc, 1 - Gsrc, 1 - Bsrc, 1 - Asrc) |
| `SrcAlpha` | `"src-alpha"` | (Asrc, Asrc, Asrc, Asrc) |
| `OneMinusSrcAlpha` | `"one-minus-src-alpha"` | (1 - Asrc, 1 - Asrc, 1 - Asrc, 1 - Asrc) |
| `Dst` | `"dst"` | (Rdst, Gdst, Bdst, Adst) |
| `OneMinusDst` | `"one-minus-dst"` | (1 - Rdst, 1 - Gdst, 1 - Bdst, 1 - Adst) |
| `DstAlpha` | `"dst-alpha"` | (Adst, Adst, Adst, Adst) |
| `OneMinusDstAlpha` | `"one-minus-dst-alpha"` | (1 - Adst, 1 - Adst, 1 - Adst, 1 - Adst) |
| `SrcAlphaSaturated` | `"src-alpha-saturated"` | (min(Asrc, 1 - Adst), min(Asrc, 1 - Adst), min(Asrc, 1 - Adst), 1) |
| `Constant` | `"constant"` | (Rconst, Gconst, Bconst, Aconst) |
| `OneMinusConstant` | `"one-minus-constant"` | (1 - Rconst, 1 - Gconst, 1 - Bconst, 1 - Aconst) |
| `Src1` | `"src1"` | (Rsrc1, Gsrc1, Bsrc1, Asrc1) |
| `OneMinusSrc1` | `"one-minus-src1"` | (1 - Rsrc1, 1 - Gsrc1, 1 - Bsrc1, 1 - Asrc1) |
| `Src1Alpha` | `"src1-alpha"` | (Asrc1, Asrc1, Asrc1, Asrc1) |
| `OneMinusSrc1Alpha` | `"one-minus-src1-alpha"` | (1 - Asrc1, 1 - Asrc1, 1 - Asrc1, 1 - Asrc1) |
