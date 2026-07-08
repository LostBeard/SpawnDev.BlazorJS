using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Implemented by a <see cref="System.IO.Stream"/> whose data can be read while it stays in JS - returned
    /// as a <see cref="Uint8Array"/> instead of being copied into the .NET heap. This lets a consumer that
    /// ultimately hands the data back to JS keep it JS-side end to end (zero JS&lt;-&gt;.NET copy).
    /// <para>
    /// The motivating case: streaming multi-hundred-MB model weights from a JS-backed source (an
    /// <c>ArrayBuffer</c>, a <c>Blob</c>/<c>File</c>, or a WebTorrent piece stream) straight into a GPU buffer
    /// via <c>IBrowserMemoryBuffer.CopyFromJS(...)</c>. Reading those bytes through a .NET <c>byte[]</c> only to
    /// upload them right back to the GPU is a pure waste - the weights are never used by .NET logic.
    /// </para>
    /// <para>
    /// Backed by <see cref="BlobStream"/>, <see cref="ArrayBufferStream"/>, and other JS-backed streams.
    /// </para>
    /// </summary>
    public interface IJSReadStream
    {
        /// <summary>
        /// True if the standard synchronous <see cref="System.IO.Stream.Read(byte[], int, int)"/> works on this
        /// stream. Many JS-backed streams in Blazor WASM are async-only - their data is fetched via a Promise
        /// (e.g. <c>Blob.arrayBuffer()</c> or a network piece) so synchronous <c>Read</c> throws. Check this
        /// before doing a synchronous read. An <see cref="ArrayBufferStream"/> (data already resident in JS
        /// memory) returns true; a <see cref="BlobStream"/> or a network-backed stream returns false.
        /// </summary>
        bool CanReadSync { get; }

        /// <summary>
        /// Reads up to <paramref name="count"/> bytes starting at the current <see cref="System.IO.Stream.Position"/>
        /// and returns them as a JS <see cref="Uint8Array"/> - the data stays in JS, never copied into .NET.
        /// Advances <see cref="System.IO.Stream.Position"/> by the number of bytes read. Returns an empty
        /// <see cref="Uint8Array"/> (length 0) at end of stream. The caller owns the returned
        /// <see cref="Uint8Array"/> and should dispose it.
        /// </summary>
        Task<Uint8Array> ReadUint8ArrayAsync(int count, CancellationToken cancellationToken = default);

        /// <summary>
        /// Synchronously reads up to <paramref name="count"/> bytes starting at the current
        /// <see cref="System.IO.Stream.Position"/> and returns them as a JS <see cref="Uint8Array"/> - the data
        /// stays in JS, never copied into .NET. Only valid when <see cref="CanReadSync"/> is true; otherwise
        /// throws (the underlying JS read is async-only). Advances <see cref="System.IO.Stream.Position"/> by the
        /// number of bytes read. Returns an empty <see cref="Uint8Array"/> (length 0) at end of stream. The
        /// caller owns the returned <see cref="Uint8Array"/> and should dispose it.
        /// </summary>
        Uint8Array ReadUint8Array(int count);
    }
}
