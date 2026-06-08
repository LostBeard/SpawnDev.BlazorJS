# Changelog

## 3.5.12 (2026-06-08) — IJSReadStream

`IJSReadStream` (namespace `SpawnDev.BlazorJS.Toolbox`) — a `Stream` whose data can be read **while it stays in JS**: `ReadUint8ArrayAsync(int count, CancellationToken)` returns a `Uint8Array` (advancing Position) instead of copying bytes into the .NET/WASM managed heap, plus a `CanReadSync` flag (false on async-only JS-backed streams like Blob in Blazor WASM, true on sync-capable ones).

Implemented on `BlobStream` (`CanReadSync` = false) and `ArrayBufferStream` (`CanReadSync` = true).

Why: lets a consumer that ultimately hands data back to JS — e.g. uploading model weights to a GPU buffer via `IBrowserMemoryBuffer.CopyFromJS` — keep the bytes JS-side end to end (zero JS→.NET→GPU copy). Consumed by **SpawnDev.WebTorrent** (`TorrentReadStream`, stream torrent pieces straight to the GPU) and **SpawnDev.ILGPU** (`ArrayView<T>.CopyFromStreamAsync`, the chunked accelerator upload).

## 3.5.11 — HeapView ReadOnlyMemory / ArraySegment support

`HeapView<T>` accepts `ReadOnlyMemory<T>` and `ArraySegment<T>` sources (one async-safe pinned memcpy instead of `ToArray()` + a `byte[]`→JS interop serialize).
