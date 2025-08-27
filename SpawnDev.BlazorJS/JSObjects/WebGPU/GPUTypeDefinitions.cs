// https://www.w3.org/TR/webgpu/#type-definitions

global using GPUBufferDynamicOffset = System.UInt32;
global using GPUStencilValue = System.UInt32;
global using GPUSampleMask = System.UInt32;
global using GPUDepthBias = System.Int32;
global using GPUSize64 = System.UInt64;
global using GPUIntegerCoordinate = System.UInt32;
global using GPUIndex32 = System.UInt32;
global using GPUSize32 = System.UInt32;
global using GPUSignedOffset32 = System.Int32;
global using GPUSize64Out = System.UInt64;
global using GPUIntegerCoordinateOut = System.UInt32;
global using GPUSize32Out = System.UInt32;
global using GPUFlagsConstant = System.UInt32;

// typedef (sequence<GPUIntegerCoordinate> or GPUExtent3DDict) GPUExtent3D;
global using GPUExtent3D = SpawnDev.BlazorJS.Union<System.Collections.Generic.IEnumerable<System.UInt32>, SpawnDev.BlazorJS.JSObjects.GPUExtent3DDict>;

// https://www.w3.org/TR/webgpu/#typedefdef-gpuorigin3d
global using GPUOrigin3D = SpawnDev.BlazorJS.Union<System.Collections.Generic.IEnumerable<System.UInt32>, SpawnDev.BlazorJS.JSObjects.GPUOrigin3DDict>;

// typedef (sequence<GPUIntegerCoordinate> or GPUOrigin2DDict) GPUOrigin2D;
global using GPUOrigin2D = SpawnDev.BlazorJS.Union<System.Collections.Generic.IEnumerable<System.UInt32>, SpawnDev.BlazorJS.JSObjects.GPUOrigin2DDict>;

// https://www.w3.org/TR/webgpu/#typedefdef-gpucopyexternalimagesource
// typedef (ImageBitmap or ImageData or HTMLImageElement or HTMLVideoElement or VideoFrame or HTMLCanvasElement or OffscreenCanvas) GPUCopyExternalImageSource;
global using GPUCopyExternalImageSource = SpawnDev.BlazorJS.Union
    <
        SpawnDev.BlazorJS.JSObjects.ImageBitmap,
        SpawnDev.BlazorJS.JSObjects.ImageData,
        SpawnDev.BlazorJS.JSObjects.HTMLImageElement,
        SpawnDev.BlazorJS.JSObjects.HTMLVideoElement,
        SpawnDev.BlazorJS.JSObjects.VideoFrame,
        SpawnDev.BlazorJS.JSObjects.HTMLCanvasElement,
        SpawnDev.BlazorJS.JSObjects.OffscreenCanvas
    >;
