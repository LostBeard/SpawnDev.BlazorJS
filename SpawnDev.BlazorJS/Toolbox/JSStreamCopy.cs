using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Shared copy loops used by the <see cref="System.IO.Stream.CopyTo(System.IO.Stream, int)"/> /
    /// <see cref="System.IO.Stream.CopyToAsync(System.IO.Stream, int, CancellationToken)"/> overrides on the
    /// JS-backed read streams (<see cref="BlobStream"/>, <see cref="ArrayBufferStream"/>). When the copy
    /// destination is an <see cref="IJSWriteStream"/>, the override routes here to pump the data as
    /// <see cref="SpawnDev.BlazorJS.JSObjects.Uint8Array"/> chunks - read JS-side, written JS-side - so the
    /// payload never enters the .NET/WASM managed heap. Otherwise the override defers to the base
    /// <see cref="System.IO.Stream"/> implementation (the standard managed byte[] path).
    /// </summary>
    internal static class JSStreamCopy
    {
        public static async Task CopyToAsync(IJSReadStream source, IJSWriteStream destination, int bufferSize, CancellationToken cancellationToken)
        {
            if (bufferSize <= 0) throw new ArgumentOutOfRangeException(nameof(bufferSize));
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var chunk = await source.ReadUint8ArrayAsync(bufferSize, cancellationToken).ConfigureAwait(false);
                try
                {
                    if (chunk is null || chunk.Length == 0) break;
                    await destination.WriteUint8ArrayAsync(chunk, cancellationToken).ConfigureAwait(false);
                }
                finally
                {
                    chunk?.Dispose();
                }
            }
        }

        public static void CopyTo(IJSReadStream source, IJSWriteStream destination, int bufferSize)
        {
            if (bufferSize <= 0) throw new ArgumentOutOfRangeException(nameof(bufferSize));
            while (true)
            {
                var chunk = source.ReadUint8Array(bufferSize);
                try
                {
                    if (chunk is null || chunk.Length == 0) break;
                    destination.WriteUint8Array(chunk);
                }
                finally
                {
                    chunk?.Dispose();
                }
            }
        }
    }
}
