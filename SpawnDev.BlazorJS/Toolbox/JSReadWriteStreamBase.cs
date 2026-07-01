using System.Threading;
using System.Threading.Tasks;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Base class for a duplex <see cref="System.IO.Stream"/> that is both an <see cref="IJSReadStream"/> and
    /// an <see cref="IJSWriteStream"/> (its data can be read and written while it stays in JS). Inherits
    /// <see cref="JSReadStreamBase"/> - so it gets the JS-side <c>CopyTo</c>/<c>CopyToAsync</c> fast path as a
    /// copy <em>source</em> with no duplicated logic - and adds the <see cref="IJSWriteStream"/> members so the
    /// same stream works as a copy <em>destination</em>. This is the single-inheritance-friendly way to build a
    /// read+write JS stream (C# can't inherit both <see cref="JSReadStreamBase"/> and
    /// <see cref="JSWriteStreamBase"/>). Derive and implement the three JS-read members (from
    /// <see cref="JSReadStreamBase"/>) and the three JS-write members below, plus the usual
    /// <see cref="System.IO.Stream"/> members.
    /// </summary>
    public abstract class JSReadWriteStreamBase : JSReadStreamBase, IJSWriteStream
    {
        /// <inheritdoc/>
        public abstract bool CanWriteSync { get; }
        /// <inheritdoc/>
        public abstract Task WriteUint8ArrayAsync(Uint8Array data, CancellationToken cancellationToken = default);
        /// <inheritdoc/>
        public abstract void WriteUint8Array(Uint8Array data);
    }
}
