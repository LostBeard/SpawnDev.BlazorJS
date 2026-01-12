// Common and custom (Blazor specific) definitions
// https://webidl.spec.whatwg.org/#common

// https://webidl.spec.whatwg.org/#ArrayBufferView
// typedef (TypedArray or DataView) ArrayBufferView;

// https://html.spec.whatwg.org/multipage/imagebitmap-and-animations.html#imagedataarray

// https://webidl.spec.whatwg.org/#AllowSharedBufferSource
global using AllowSharedBufferSource = SpawnDev.BlazorJS.Union
    <
    SpawnDev.BlazorJS.JSObjects.ArrayBuffer,
    SpawnDev.BlazorJS.JSObjects.SharedArrayBuffer,
    SpawnDev.BlazorJS.JSObjects.TypedArray,
    SpawnDev.BlazorJS.JSObjects.DataView,
    byte[]
    >;
// https://webidl.spec.whatwg.org/#BufferSource
// typedef (ArrayBufferView or ArrayBuffer) BufferSource;
global using BufferSource = SpawnDev.BlazorJS.Union
    <
    SpawnDev.BlazorJS.JSObjects.ArrayBuffer,
    SpawnDev.BlazorJS.JSObjects.TypedArray,
    SpawnDev.BlazorJS.JSObjects.DataView,
    byte[]
    >;
global using CanvasImageSource = SpawnDev.BlazorJS.Union<
    SpawnDev.BlazorJS.JSObjects.HTMLImageElement,
    SpawnDev.BlazorJS.JSObjects.SVGImageElement,
    SpawnDev.BlazorJS.JSObjects.HTMLVideoElement,
    SpawnDev.BlazorJS.JSObjects.HTMLCanvasElement,
    SpawnDev.BlazorJS.JSObjects.ImageBitmap,
    SpawnDev.BlazorJS.JSObjects.OffscreenCanvas,
    SpawnDev.BlazorJS.JSObjects.VideoFrame
>;
global using ConstrainBoolean = SpawnDev.BlazorJS.Union<bool, SpawnDev.BlazorJS.JSObjects.ConstrainBooleanParameters>;
global using ConstrainDOMString = SpawnDev.BlazorJS.Union<string, string[], SpawnDev.BlazorJS.JSObjects.ConstrainDOMStringParameters>;
global using ConstrainDouble = SpawnDev.BlazorJS.Union<double, SpawnDev.BlazorJS.JSObjects.ConstrainDoubleRange>;
global using ConstrainULong = SpawnDev.BlazorJS.Union<ulong, SpawnDev.BlazorJS.JSObjects.ConstrainULongRange>;
global using ImageBitmapSource = SpawnDev.BlazorJS.Union<
    SpawnDev.BlazorJS.JSObjects.HTMLImageElement,
    SpawnDev.BlazorJS.JSObjects.SVGImageElement,
    SpawnDev.BlazorJS.JSObjects.HTMLVideoElement,
    SpawnDev.BlazorJS.JSObjects.HTMLCanvasElement,
    SpawnDev.BlazorJS.JSObjects.ImageBitmap,
    SpawnDev.BlazorJS.JSObjects.OffscreenCanvas,
    SpawnDev.BlazorJS.JSObjects.VideoFrame,
    SpawnDev.BlazorJS.JSObjects.Blob,
    SpawnDev.BlazorJS.JSObjects.ImageData
>;
