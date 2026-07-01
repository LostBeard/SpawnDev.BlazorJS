using System.Threading;
using System.Threading.Tasks;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// The write-side sibling of <see cref="IJSReadStream"/>. Implemented by a <see cref="System.IO.Stream"/>
    /// whose data is written while it stays in JS - accepting a <see cref="Uint8Array"/> directly instead of
    /// copying the bytes through the .NET heap. This lets a consumer that already holds the data JS-side
    /// (a GPU readback, a fetched buffer, a decoded frame) write it straight out (to OPFS, disk, or an
    /// in-memory buffer) with zero JS&lt;-&gt;.NET copy.
    /// <para>
    /// The motivating case is the mirror of <see cref="IJSReadStream"/>: streaming a multi-hundred-MB GPU
    /// buffer straight to an OPFS file chunk-by-chunk, where each chunk is read back from the GPU as a
    /// <see cref="Uint8Array"/> and handed to <see cref="WriteUint8ArrayAsync"/> without ever materializing
    /// the full payload - or entering the .NET/WASM managed heap - along the way.
    /// </para>
    /// <para>
    /// Backed by <see cref="FileSystemHandleWritableStream"/> (async OPFS/disk), <see cref="ArrayBufferStream"/>
    /// (synchronous in-memory JS buffer), and other JS-backed writable streams.
    /// </para>
    /// </summary>
    public interface IJSWriteStream
    {
        /// <summary>
        /// True if the synchronous <see cref="WriteUint8Array(Uint8Array)"/> works on this stream. Many
        /// JS-backed writable streams in Blazor WASM are async-only - their write is a Promise (e.g. an OPFS
        /// <c>FileSystemWritableFileStream.write()</c>) so a synchronous write throws. Check this before doing
        /// a synchronous write. An <see cref="ArrayBufferStream"/> (data written directly into a JS
        /// <c>ArrayBuffer</c> already resident in memory) returns true; a
        /// <see cref="FileSystemHandleWritableStream"/> returns false.
        /// </summary>
        bool CanWriteSync { get; }

        /// <summary>
        /// Writes the bytes in <paramref name="data"/> to the stream at the current
        /// <see cref="System.IO.Stream.Position"/> - the data stays in JS, never copied into .NET. Advances
        /// <see cref="System.IO.Stream.Position"/> by <c>data.Length</c>. The caller retains ownership of
        /// <paramref name="data"/> (this method does not dispose it).
        /// </summary>
        Task WriteUint8ArrayAsync(Uint8Array data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Synchronously writes the bytes in <paramref name="data"/> to the stream at the current
        /// <see cref="System.IO.Stream.Position"/>. Only valid when <see cref="CanWriteSync"/> is true;
        /// otherwise throws (the underlying JS write is async-only). Advances
        /// <see cref="System.IO.Stream.Position"/> by <c>data.Length</c>. The caller retains ownership of
        /// <paramref name="data"/> (this method does not dispose it).
        /// </summary>
        void WriteUint8Array(Uint8Array data);
    }
}
