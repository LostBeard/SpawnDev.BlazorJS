using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Base class for a <see cref="Stream"/> that is also an <see cref="IJSWriteStream"/> (its data is written
    /// while it stays in JS). Inherit from this instead of <see cref="Stream"/> + <see cref="IJSWriteStream"/>
    /// directly to make a write-only JS stream type; derive and implement the three abstract JS-write members
    /// plus the usual <see cref="Stream"/> members. A JS-side copy is source-driven (see
    /// <see cref="JSReadStreamBase"/>), so this base carries no shared copy override - it is the write-side
    /// scaffold for symmetry and discoverability. A duplex stream that is both readable and writable should
    /// inherit <see cref="JSReadStreamBase"/> (to get the copy fast path as a source) and implement
    /// <see cref="IJSWriteStream"/> directly.
    /// </summary>
    public abstract class JSWriteStreamBase : Stream, IJSWriteStream
    {
        /// <inheritdoc/>
        public abstract bool CanWriteSync { get; }
        /// <inheritdoc/>
        public abstract Task WriteUint8ArrayAsync(Uint8Array data, CancellationToken cancellationToken = default);
        /// <inheritdoc/>
        public abstract void WriteUint8Array(Uint8Array data);
    }
}
