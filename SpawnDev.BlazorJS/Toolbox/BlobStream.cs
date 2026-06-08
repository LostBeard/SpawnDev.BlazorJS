using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Provides access to a Blob as a read-only Stream
    /// </summary>
    public class BlobStream : Stream, IJSReadStream
    {
        /// <summary>
        /// False - a Blob's bytes are fetched via the async <c>Blob.arrayBuffer()</c> Promise, so synchronous
        /// <see cref="Read(byte[], int, int)"/> is not supported (it throws). Use <see cref="ReadAsync(byte[], int, int, System.Threading.CancellationToken)"/>
        /// or <see cref="ReadUint8ArrayAsync(int, System.Threading.CancellationToken)"/>.
        /// </summary>
        public bool CanReadSync => false;
        /// <inheritdoc/>
        public override bool CanRead => Source != null;
        /// <inheritdoc/>
        public override bool CanSeek => Source != null;
        /// <inheritdoc/>
        public override bool CanWrite => false;
        /// <inheritdoc/>
        public override bool CanTimeout => false;
        /// <inheritdoc/>
        public override long Length => Source?.Size ?? 0;
        /// <summary>
        /// Internal position
        /// </summary>
        protected long _Position = 0;
        /// <inheritdoc/>
        public override long Position { get => _Position; set => _Position = value; }
        /// <summary>
        /// The source.
        /// </summary>
        public Blob Source { get; private set; }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="source"></param>
        public BlobStream(Blob source)
        {
            Source = source;
        }
        /// <summary>
        /// True if this object has been disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }
        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            IsDisposed = true;
            Source?.Dispose();
            Source = null!;
            base.Dispose(disposing);
        }
        /// <inheritdoc/>
        public override void Close()
        {
            Source?.Dispose();
            Source = null!;
            base.Close();
        }
        /// <inheritdoc/>
        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    Position = offset;
                    break;
                case SeekOrigin.End:
                    Position = Length + offset;
                    break;
                case SeekOrigin.Current:
                    Position = Position + offset;
                    break;
            }
            return Position;
        }
        /// <summary>
        /// No-op
        /// </summary>
        public override void Flush() { }
        /// <inheritdoc/>
        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            using var subBlob = ReadBlob(count);
            var bytesRead = (int)(subBlob?.Size ?? 0);
            if (bytesRead > 0 && subBlob != null)
            {
                using var subArrayBuffer = await subBlob.ArrayBuffer();
                using var subUint8Array = new Uint8Array(subArrayBuffer);
                // get a heap view of the destination in buffer using the offset and count
                using var heapView = HeapView.Create(buffer);
                using var typedArray = heapView.As<Uint8Array>();
                // write the source subarray view to the destination
                typedArray.Set(subUint8Array, offset);
            }
            return bytesRead;
        }
        /// <summary>
        /// Not supported. Use ReadAsync methods
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException($"{nameof(BlobStream)}.Read not supported. Use ReadAsync.");
        }
        /// <summary>
        /// Read from the stream starting at the current position. Returns null if there is no data.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        /// <exception cref="ObjectDisposedException"></exception>
        public Blob? ReadBlob(int count)
        {
            if (Source == null || Source.IsWrapperDisposed) throw new ObjectDisposedException(nameof(Source));
            var byteCount = (int)Math.Max(0, Math.Min(count, Source.Size - _Position));
            if (byteCount == 0) return null;
            var end = _Position + byteCount;
            var ret = Source.Slice(_Position, end);
            _Position = end;
            return ret;
        }
        /// <inheritdoc/>
        public async Task<Uint8Array> ReadUint8ArrayAsync(int count, System.Threading.CancellationToken cancellationToken = default)
        {
            using var subBlob = ReadBlob(count);
            if (subBlob == null || subBlob.Size == 0) return new Uint8Array(0);
            // Blob.arrayBuffer() is async; the resulting Uint8Array references the ArrayBuffer in JS, so the
            // buffer stays alive via that JS reference after the .NET ArrayBuffer wrapper is disposed.
            using var arrayBuffer = await subBlob.ArrayBuffer();
            return new Uint8Array(arrayBuffer);
        }
        /// <summary>
        /// Not supported.
        /// </summary>
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// Not supported.
        /// </summary>
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }
    }
}
