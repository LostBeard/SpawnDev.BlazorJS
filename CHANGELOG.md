# Changelog

## 3.5.24 — Fix HeapView.As&lt;TView&gt;() cross-type view sizing (regression from 3.5.23)

3.5.23 moved the `HeapView.As<TView>()` view build from a C#-side `new TView(heapBuffer, addr, elementCount)` (constructor takes an **element count**) to a JS-reviver build driven by a `HeapViewInit` descriptor that carries a **byteLength** (the reviver does `length = byteLength / targetView.BYTES_PER_ELEMENT`). The descriptor byteLength was computed as `elementCount * ElementSize`, where `ElementSize` is the **source** `HeapView`'s element size — but `elementCount` is already in **target-view** elements. When the two element sizes differ (a cross-type view), the descriptor was over-sized.

The most common cross-type view is `TypedArray.Write<T>`, which pins the source as `HeapView<T>` (e.g. `HeapView<double>`, element size 8) and views it `As<Uint8Array>` (element size 1). For a single `double`, `elementCount = 8` but the buggy byteLength was `8 * 8 = 64` for 8 real bytes → the reviver built `new Uint8Array(heap, addr, 64)`, reading 56 bytes past the pinned data and throwing `RangeError: offset is out of bounds` when the pinned region sat near the heap end. Surfaced through `(Number)someDouble` boxing (`Float64Array.Write([value])`).

**Fix:** size the descriptor byteLength by the **target** view's element size — `elementCount * TypedArray.GetTypedArrayElementSize<TView>()` (generic) / `GetTypedArrayElementSize(typedArrayType)` (non-generic). `AsDataView` was already correct (it passes a real byteLength; DataView element size is 1). Same-type views were unaffected (source == target size), which is why the 3.5.23 benchmark and byte→byte tests passed. Regression guard: `HeapViewTests.HeapViewCrossTypeAsTest` (Chromium + Firefox) — `HeapView<double>.As<Uint8Array>()` byte content vs `BitConverter`, plus the `(Number)double` round-trip.

## 3.5.23 — HeapView re-attach hardening

Hardens the 3.5.22 re-attach path: the reviver reuses a still-valid replacement view (`_overrideView`) instead of rebuilding on every revive, and validates a candidate view (matching byteLength + non-detached buffer) before deciding to recreate — so repeated heap growth keeps re-attaching correctly and a still-attached view is returned as-is. `HeapView.ForceHeapGrowth()` added (grows the WASM heap in steps until the backing `ArrayBuffer` swaps) to deterministically exercise the detach/re-attach path in tests.

## 3.5.22 — HeapView detach handled by tag + re-attach on revive (priming no longer needed)

Removes the need for heap **priming** to protect against detached heap views. Instead, a JS TypedArray/DataView that views the .NET heap `ArrayBuffer` (and the heap `ArrayBuffer` itself) is **tagged** with its view info (`viewType` / `address` / `byteLength`) on JS→.NET serialization; on .NET→JS revive (and on the return path) a **detached** tagged view is transparently replaced with a fresh view built against the current live `HEAPU8.buffer` at the same address. Because `memory.grow` preserves existing byte offsets and pinned arrays don't move, re-creating the view at the same address on the new buffer is always valid. A `memory.grow` (heap resize) is therefore no longer a hazard — the view re-attaches on next use rather than being pre-protected by a forced-GC prime. `HeapView.UsePrimer` now defaults to **false**.

## 3.5.21 — HeapView priming throttle (once per grow-epoch)

`HeapViewPtr`/`HeapView` prime the WASM heap (pre-allocate ~16 MB + a forced compacting GC) so a `memory.grow` can't detach a heap view mid-use. Priming ran whenever no view was outstanding — which for **sequential** views (the zero-copy `CopyFrom` upload path) meant a forced compacting GC on **every** call. A hot loop (e.g. 100 uploads) then paid 100 forced GCs and could time out.

Because `memory.grow` is one-way (the heap never shrinks), a single prime's headroom **persists** until something grows the heap. `HeapView` now records the heap byteLength right after each prime (`_lastPrimedHeapSize`) and **skips priming while the heap hasn't grown since** — re-priming only when a grow has consumed the reserved headroom. Net: priming happens ~once per grow-epoch instead of per view, hot `CopyFrom` loops no longer stall, and the detach protection is unchanged. `UsePrimer` (default true) and `DefaultHeapPrimeSize` (16 MB) still apply.

## 3.5.15 — OPFS writable abort-on-throw (swap-file leak fix)

**OPFS write hazard fixed at the source.** `FileSystemFileHandle.createWritable()` allocates a temporary swap file; a stream that is neither `Close()`d (commit) nor `Abort()`ed (discard) leaks that swap until JS garbage collection. Every `FileSystemFileHandle` / `FileSystemDirectoryHandle` `Write`/`Append`/`WriteJSON` overload used the `CreateWritable → Write → Close` pattern, so a mid-write throw — most importantly the browser's `QuotaExceededError` when the origin is out of space — skipped `Close()` and abandoned the writable, leaking its swap. Under a retry loop (a torrent re-saving a piece whose write keeps failing) that compounds one leaked swap per attempt into a runaway that exhausts origin storage, which then makes every subsequent write fail so it never recovers.

- New `FileSystemWritableFileStream.WriteAndCommit(this stream, Func<Task> writeAction)` (namespace `SpawnDev.BlazorJS.Toolbox`): runs the write, `Close()`s on success, and on any throw `Abort()`s the stream (releasing the swap) then rethrows the original exception. Every `Write`/`Append`/`WriteJSON` overload on `FileSystemFileHandle` now routes through it; the `FileSystemDirectoryHandle` overloads delegate to the fixed file-handle primitives (duplication removed).
- New `FileSystemHandleWritableStream.AbortAsync()`; the `Write(Stream)` / `Append(Stream)` copy paths now `CloseAsync()` (awaiting the commit) on success and `AbortAsync()` (releasing the swap, discarding the partial) on failure.

Fixes a storage-exhaustion runaway observed on browser model downloads (the WebTorrent OPFS piece store). Applies to every OPFS consumer, not just WebTorrent. Regression guards (Chromium + Firefox): `JSWriteStreamTests.WriteAndCommit_ThrowingWrite_AbortsWithoutCommitting_AndRethrows`, `FileSystemFileHandle_Write_RoundTrips_ViaWriteAndCommit`, `FileSystemHandleWritableStream_AbortAsync_DiscardsUncommittedWrite`.

## 3.5.14 — HeapView disposal fixes + IJSWriteStream

**HeapView disposal.** `TypedArray.Set(T[])`, `TextDecoder.Decode(byte[])`/`DecodeToPrimitive(byte[])`, and `CanvasRenderingContext2D.PutImageBytes` now dispose the pinned `HeapView` / intermediate TypedArray views deterministically instead of leaking them to the finalizer (reduces GC pressure under heavy workloads). Fixed a `HeapViewConverter.Write` use-after-free where the intermediate view was disposed before the interop revive stage resolved it (serialized `Uint8Array` came back null); regression guard `HeapViewTests.HeapViewSerializationTest`.

**`IJSWriteStream`** (namespace `SpawnDev.BlazorJS.Toolbox`) — the write-side sibling of `IJSReadStream`: `WriteUint8ArrayAsync(Uint8Array, CancellationToken)` (and sync `WriteUint8Array`) write a `Uint8Array` **while it stays in JS**, advancing Position, instead of copying bytes through the .NET/WASM managed heap, plus a `CanWriteSync` flag. Implemented on `FileSystemHandleWritableStream` (`CanWriteSync` = false, async OPFS/disk) and `ArrayBufferStream` (`CanWriteSync` = true, in-memory JS buffer — now a full duplex `IJSReadStream` + `IJSWriteStream`). `BlobStream` stays read-only. `IJSReadStream` gains a sync `ReadUint8Array(int)` counterpart.

**JS-side `Stream.CopyTo`/`CopyToAsync` fast path.** `BlobStream` and `ArrayBufferStream` override the standard `Stream.CopyTo(Stream, int)` / `CopyToAsync(Stream, int, CancellationToken)`: when the destination is an `IJSWriteStream`, the copy pumps `Uint8Array` chunks JS-side (never through the .NET heap); otherwise it defers to the base managed copy. Standard `source.CopyToAsync(dest)` transparently gets the zero-copy path — no new API to learn.

**`FileSystemHandleWritableStream` async commit.** The OPFS/disk `close()` — which flushes the buffered bytes to disk — is async, but `Stream.Dispose` is synchronous and fire-and-forgot it, so a plain `using` could return before the file was actually written (a read-back saw an empty/short file, browser-timing dependent; a hard failure on Firefox, masked by faster timing on Chromium). Added `DisposeAsync()` (override) + `CloseAsync()` that **await** the commit; `await using` / `await CloseAsync()` now guarantees the bytes are on disk. The synchronous `Dispose` remains a best-effort fallback (documented). **Consumers that save to OPFS/disk and read back (e.g. via `ArrayView<T>.CopyToStreamAsync`) must `await using` the writable stream or call `CloseAsync()`.**

Why: the mirror of `IJSReadStream` — lets a consumer holding data JS-side (a GPU readback, a fetched buffer) write it straight to OPFS/disk/an in-memory buffer with zero JS↔.NET copy. Consumed by **SpawnDev.ILGPU** (`ArrayView<T>.CopyToStreamAsync`, the chunked accelerator save — mirror of `CopyFromStreamAsync`).

## 3.5.12 (2026-06-08) — IJSReadStream

`IJSReadStream` (namespace `SpawnDev.BlazorJS.Toolbox`) — a `Stream` whose data can be read **while it stays in JS**: `ReadUint8ArrayAsync(int count, CancellationToken)` returns a `Uint8Array` (advancing Position) instead of copying bytes into the .NET/WASM managed heap, plus a `CanReadSync` flag (false on async-only JS-backed streams like Blob in Blazor WASM, true on sync-capable ones).

Implemented on `BlobStream` (`CanReadSync` = false) and `ArrayBufferStream` (`CanReadSync` = true).

Why: lets a consumer that ultimately hands data back to JS — e.g. uploading model weights to a GPU buffer via `IBrowserMemoryBuffer.CopyFromJS` — keep the bytes JS-side end to end (zero JS→.NET→GPU copy). Consumed by **SpawnDev.WebTorrent** (`TorrentReadStream`, stream torrent pieces straight to the GPU) and **SpawnDev.ILGPU** (`ArrayView<T>.CopyFromStreamAsync`, the chunked accelerator upload).

## 3.5.11 — HeapView ReadOnlyMemory / ArraySegment support

`HeapView<T>` accepts `ReadOnlyMemory<T>` and `ArraySegment<T>` sources (one async-safe pinned memcpy instead of `ToArray()` + a `byte[]`→JS interop serialize).
