using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Base class for a <see cref="Stream"/> that is also an <see cref="IJSReadStream"/> (its data can be read
    /// while it stays in JS). Inherit from this instead of <see cref="Stream"/> + <see cref="IJSReadStream"/>
    /// directly to get the JS-side <see cref="CopyTo(Stream, int)"/> / <see cref="CopyToAsync(Stream, int, CancellationToken)"/>
    /// fast path for free: when the copy destination is an <see cref="IJSWriteStream"/>, the bytes are pumped
    /// as <see cref="Uint8Array"/> chunks (kept JS-side, never through the .NET/WASM managed heap) instead of
    /// the base managed byte[] path - so a new read-stream type is correct-by-default and cannot forget the
    /// fast path. Derive and implement the three abstract JS-read members plus the usual <see cref="Stream"/>
    /// members.
    /// </summary>
    public abstract class JSReadStreamBase : Stream, IJSReadStream
    {
        /// <inheritdoc/>
        public abstract bool CanReadSync { get; }
        /// <inheritdoc/>
        public abstract Task<Uint8Array> ReadUint8ArrayAsync(int count, CancellationToken cancellationToken = default);
        /// <inheritdoc/>
        public abstract Uint8Array ReadUint8Array(int count);

        /// <summary>
        /// Copies this stream into <paramref name="destination"/>. When the destination is an
        /// <see cref="IJSWriteStream"/>, the bytes are pumped as <see cref="Uint8Array"/> chunks (kept JS-side,
        /// never through the .NET heap) - the zero-copy fast path. Otherwise defers to the base managed copy.
        /// </summary>
        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            if (destination is IJSWriteStream jsWrite)
                return JSStreamCopy.CopyToAsync(this, jsWrite, bufferSize, cancellationToken);
            return base.CopyToAsync(destination, bufferSize, cancellationToken);
        }

        /// <summary>
        /// Copies this stream into <paramref name="destination"/>. When the destination is a synchronously
        /// writable <see cref="IJSWriteStream"/> and this stream can read synchronously, the bytes are copied
        /// as <see cref="Uint8Array"/> chunks (kept JS-side) - the zero-copy fast path. Otherwise defers to the
        /// base managed copy (which, for an async-only stream, throws - the correct fail-loud behavior).
        /// </summary>
        public override void CopyTo(Stream destination, int bufferSize)
        {
            if (destination is IJSWriteStream jsWrite && CanReadSync && jsWrite.CanWriteSync)
            {
                JSStreamCopy.CopyTo(this, jsWrite, bufferSize);
                return;
            }
            base.CopyTo(destination, bufferSize);
        }
    }
}
