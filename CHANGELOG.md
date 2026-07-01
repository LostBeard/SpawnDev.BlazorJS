# Changelog

## 3.5.14 — HeapView disposal fixes + IJSWriteStream

**HeapView disposal.** `TypedArray.Set(T[])`, `TextDecoder.Decode(byte[])`/`DecodeToPrimitive(byte[])`, and `CanvasRenderingContext2D.PutImageBytes` now dispose the pinned `HeapView` / intermediate TypedArray views deterministically instead of leaking them to the finalizer (reduces GC pressure under heavy workloads). Fixed a `HeapViewConverter.Write` use-after-free where the intermediate view was disposed before the interop revive stage resolved it (serialized `Uint8Array` came back null); regression guard `HeapViewTests.HeapViewSerializationTest`.

**`IJSWriteStream`** (namespace `SpawnDev.BlazorJS.Toolbox`) — the write-side sibling of `IJSReadStream`: `WriteUint8ArrayAsync(Uint8Array, CancellationToken)` (and sync `WriteUint8Array`) write a `Uint8Array` **while it stays in JS**, advancing Position, instead of copying bytes through the .NET/WASM managed heap, plus a `CanWriteSync` flag. Implemented on `FileSystemHandleWritableStream` (`CanWriteSync` = false, async OPFS/disk) and `ArrayBufferStream` (`CanWriteSync` = true, in-memory JS buffer — now a full duplex `IJSReadStream` + `IJSWriteStream`). `BlobStream` stays read-only. `IJSReadStream` gains a sync `ReadUint8Array(int)` counterpart.

**JS-side `Stream.CopyTo`/`CopyToAsync` fast path.** `BlobStream` and `ArrayBufferStream` override the standard `Stream.CopyTo(Stream, int)` / `CopyToAsync(Stream, int, CancellationToken)`: when the destination is an `IJSWriteStream`, the copy pumps `Uint8Array` chunks JS-side (never through the .NET heap); otherwise it defers to the base managed copy. Standard `source.CopyToAsync(dest)` transparently gets the zero-copy path — no new API to learn.

Why: the mirror of `IJSReadStream` — lets a consumer holding data JS-side (a GPU readback, a fetched buffer) write it straight to OPFS/disk/an in-memory buffer with zero JS↔.NET copy. Consumed by **SpawnDev.ILGPU** (`ArrayView<T>.CopyToStreamAsync`, the chunked accelerator save — mirror of `CopyFromStreamAsync`).

## 3.5.12 (2026-06-08) — IJSReadStream

`IJSReadStream` (namespace `SpawnDev.BlazorJS.Toolbox`) — a `Stream` whose data can be read **while it stays in JS**: `ReadUint8ArrayAsync(int count, CancellationToken)` returns a `Uint8Array` (advancing Position) instead of copying bytes into the .NET/WASM managed heap, plus a `CanReadSync` flag (false on async-only JS-backed streams like Blob in Blazor WASM, true on sync-capable ones).

Implemented on `BlobStream` (`CanReadSync` = false) and `ArrayBufferStream` (`CanReadSync` = true).

Why: lets a consumer that ultimately hands data back to JS — e.g. uploading model weights to a GPU buffer via `IBrowserMemoryBuffer.CopyFromJS` — keep the bytes JS-side end to end (zero JS→.NET→GPU copy). Consumed by **SpawnDev.WebTorrent** (`TorrentReadStream`, stream torrent pieces straight to the GPU) and **SpawnDev.ILGPU** (`ArrayView<T>.CopyFromStreamAsync`, the chunked accelerator upload).

## 3.5.11 — HeapView ReadOnlyMemory / ArraySegment support

`HeapView<T>` accepts `ReadOnlyMemory<T>` and `ArraySegment<T>` sources (one async-safe pinned memcpy instead of `ToArray()` + a `byte[]`→JS interop serialize).
