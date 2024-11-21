# Changelog

## [2.5.21] - 2024-11-21

### Added
- Added Supported static property to OffscreenCanvas, BigInt64Array, and BigUintArray
- Added StorageManager.Supported property
- Added SharedArrayBuffer.Supported property

### Changed
- Changed Navigator.HardwareConcurrency return value from int to int?
- Changed BlazorJSRuntime.CrossOriginIsolated property from bool to boo…
- Changed Window.CrossOriginIsolated property from bool to bool?
- Simplified static property calls in AbortSignal

### Fixed
- Fixed BigInt equality check using Equals override


## [2.5.17] - 2024-11-15

### Fixed
- Fixed JsonConverterAttribute with HybridConverter and HybridConverterFactory not working (Ex: SharedCancellationTokenSource)


## [2.5.16] - 2024-11-15

### Changed
- Updated JSObjectConverterFactory and JSObjectAsync classes that use it.

### Fixed
- Changed HybridConverterFactory to not convert JSObjectAsync types or types with JsonConverterAttributes.


## [2.5.15] - 2024-11-15

### Changed
- Updated IJSRuntime extension methods
- Updated SubtleCryptoAsync, ArrayBufferAsync, Uint8ArrayAsync, TypedArrayAsync
- Added documentation to RemoteJSRuntime classes


## [2.5.14] - 2024-11-14

### Added
- RemoteJSRuntime support
- AsyncObjects
- IJSRuntime extension methods
- SubtleCryptoAsync


## [2.5.13] - 2024-11-12

### Changed
- Updated package icon
- Updated net9.0 Microsoft.AspNetCore.Components.WebAssembly dependency to 9.0.0


## [2.5.12] - 2024-11-10

### Added
- Added DeriveBits method to SubtleCrypto JSObject


## [2.5.11] - 2024-10-31

### Added
- Added support for auto-starting IBackgroundServices on server.

### Fixed
- BlazorJSRuntime startup issue when running on the server.

