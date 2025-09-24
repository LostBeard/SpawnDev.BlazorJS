using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Provides access to an ArrayBuffer as a Stream
    /// </summary>
    public class ArrayBufferStream : Stream
    {
        /// <summary>
        /// True if the underlying ArrayBuffer is a SharedArrayBuffer
        /// </summary>
        public bool IsSharedArrayBuffer { get; private set; }
        /// <summary>
        /// True if the underlying ArrayBuffer is Resizable
        /// </summary>
        public bool CanShrink { get; private set; }
        /// <summary>
        /// True if the underlying ArrayBuffer is Growable. SharedArrayBuffers can be grown, but not shrunk.
        /// </summary>
        public bool CanGrow { get; private set; }
        /// <summary>
        /// If true, writes and calls to SetLength will throw an exception<br/> 
        /// </summary>
        public bool ReadOnly { get; set; } = false;
        /// <inheritdoc/>
        public override bool CanRead => Source != null;
        /// <inheritdoc/>
        public override bool CanSeek => Source != null;
        /// <inheritdoc/>
        public override bool CanWrite => Source != null && !ReadOnly;
        /// <inheritdoc/>
        public override bool CanTimeout => false;
        /// <inheritdoc/>
        public override long Length => Source == null ? 0 : Source.ByteLength;
        /// <summary>
        /// Internal position
        /// </summary>
        protected long _Position = 0;
        /// <summary>
        /// If true and SetLength is used with a value that is not compatible with ArrayBuffer.resize() or SharedArrayBuffer.grow(), a new underlying buffer will be created<br/>
        /// and the contents of the current buffer will be copied over.<br/>
        /// If false, and an incompatible value is used for SetLength an exception will be thrown.
        /// </summary>
        public bool AllowRecreateBuffer { get; set; }
        /// <inheritdoc/>
        public override long Position { get => _Position; set => _Position = value; }
        /// <summary>
        /// The source viewed as a Uint8Array. The referenced Uint8Array may change if the ArrayBuffer (or SharedArrayBuffer) is resized and AllowRecreateBuffer == true.
        /// </summary>
        public Uint8Array Source { get; private set; }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="length">Initial ArrayBuffer/SharedArrayBuffer length. SetLength can be used to resize (or recreate) the ArrayBuffer/SharedArrayBuffer.</param>
        /// <param name="maxLength">If set to a long value, a resizable ArrayBuffer or a growable SharedArrayBuffer will be created with the given maxLength</param>
        /// <param name="shared">If true, a SharedArrayBuffer will be created instead of an ArrayBuffer</param>
        public ArrayBufferStream(long length = 0, long? maxLength = null, bool shared = false)
        {
            if (shared)
            {
                IsSharedArrayBuffer = true;
                using var arrayBuffer = maxLength == null ? new SharedArrayBuffer(length) : new SharedArrayBuffer(length, new SharedArrayBufferOptions { MaxByteLength = maxLength });
                Source = new Uint8Array(arrayBuffer);
                CanShrink = false;
                CanGrow = arrayBuffer.Growable;
            }
            else
            {
                IsSharedArrayBuffer = false;
                using var arrayBuffer = maxLength == null ? new ArrayBuffer(length) : new ArrayBuffer(length, new ArrayBufferOptions { MaxByteLength = maxLength });
                Source = new Uint8Array(arrayBuffer);
                CanShrink = arrayBuffer.Resizable;
                CanGrow = CanShrink;
            }
        }
        /// <summary>
        /// Creates a new instance from a Uint8Array
        /// </summary>
        /// <param name="uint8Array"></param>
        public ArrayBufferStream(Uint8Array uint8Array)
        {
            using var arrayBuffer = uint8Array.Buffer;
            var shared = arrayBuffer.JSRef!.ConstructorName() == nameof(SharedArrayBuffer);
            Source = new Uint8Array(arrayBuffer);
            if (shared)
            {
                IsSharedArrayBuffer = true;
                CanShrink = false;
                using var sharedArrayBuffer = arrayBuffer.JSRefMove<SharedArrayBuffer>();
                CanGrow = sharedArrayBuffer.Growable;
            }
            else
            {
                IsSharedArrayBuffer = false;
                CanShrink = arrayBuffer.Resizable;
                CanGrow = CanShrink;
            }
        }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public ArrayBufferStream(ArrayBuffer arrayBuffer)
        {
            IsSharedArrayBuffer = false;
            Source = new Uint8Array(arrayBuffer);
            CanShrink = arrayBuffer.Resizable;
            CanGrow = CanShrink;
        }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public ArrayBufferStream(SharedArrayBuffer arrayBuffer)
        {
            IsSharedArrayBuffer = true;
            Source = new Uint8Array(arrayBuffer);
            CanShrink = false;
            CanGrow = arrayBuffer.Growable;
        }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="length"></param>
        /// <param name="options"></param>
        public ArrayBufferStream(long length, ArrayBufferOptions? options)
        {
            IsSharedArrayBuffer = false;
            using var arrayBuffer = options == null ? new ArrayBuffer(length) : new ArrayBuffer(length, options);
            Source = new Uint8Array(arrayBuffer);
            CanShrink = arrayBuffer.Resizable;
            CanGrow = CanShrink;
        }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="length"></param>
        /// <param name="options"></param>
        public ArrayBufferStream(long length, SharedArrayBufferOptions? options)
        {
            IsSharedArrayBuffer = true;
            using var arrayBuffer = options == null ? new SharedArrayBuffer(length) : new SharedArrayBuffer(length, options);
            Source = new Uint8Array(arrayBuffer);
            CanShrink = false;
            CanGrow = arrayBuffer.Growable;
        }
        /// <summary>
        /// Set the stream to ReadOnly mode
        /// </summary>
        public void SetReadOnly()
        {
            ReadOnly = true;
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
        /// No-op with ArrayBufferStream
        /// </summary>
        public override void Flush() { }
        /// <inheritdoc/>
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (Source == null) throw new ObjectDisposedException(nameof(Source));
            var byteCount = (int)Math.Max(0, Math.Min(count, Source.Length - _Position));
            if (byteCount == 0) return 0;
            var end = _Position + byteCount;
            // get a source subarray view to copy from
            using var sourceSub = Source.SubArray(_Position, end);
            // get a heap view of the destination in buffer using the offset and count
            using var heapView = HeapView.Create(buffer);
            using var typedArray = heapView.As<Uint8Array>();
            // write the source subarray view to the destination
            typedArray.Set(sourceSub, offset);
            _Position = end;
            return byteCount;
        }
        /// <summary>
        /// Read from the stream
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        /// <exception cref="ObjectDisposedException"></exception>
        public int Read(Uint8Array buffer, int offset, int count)
        {
            if (Source == null) throw new ObjectDisposedException(nameof(Source));
            var byteCount = (int)Math.Max(0, Math.Min(count, Source.Length - _Position));
            if (byteCount == 0) return 0;
            var end = _Position + byteCount;
            // get a source subarray view to copy from
            using var sourceSub = Source.SubArray(_Position, end);
            // write the source subarray view to the destination
            buffer.Set(sourceSub, offset);
            _Position = end;
            return byteCount;
        }
        /// <summary>
        /// Read from the stream
        /// </summary>
        /// <param name="count"></param>
        /// <param name="subArray">If true, subArray() will be used instead of slice() to return a view of the same ArrayBuffer instead of copying to a new ArrayBuffer.</param>
        /// <returns></returns>
        /// <exception cref="ObjectDisposedException"></exception>
        public Uint8Array? ReadUint8Array(int count, bool subArray = false)
        {
            if (Source == null) throw new ObjectDisposedException(nameof(Source));
            var byteCount = (int)Math.Max(0, Math.Min(count, Source.Length - _Position));
            if (byteCount == 0) return null;
            var end = _Position + byteCount;
            var ret = subArray ? Source.SubArray(_Position, end) : Source.Slice(_Position, end);
            _Position = end;
            return ret;
        }
        /// <inheritdoc/>
        public override void CopyTo(Stream destination, int bufferSize)
        {
            base.CopyTo(destination, bufferSize);
        }
        /// <inheritdoc/>
        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            return base.CopyToAsync(destination, bufferSize, cancellationToken);
        }
        /// <inheritdoc/>
        public override void Write(byte[] buffer, int offset, int count)
        {
            if (Source == null) throw new ObjectDisposedException(nameof(Source));
            if (ReadOnly) throw new NotSupportedException("Stream is in read-only mode");
            using var heapView = HeapView.Create(buffer, offset, count);
            using var typedArray = heapView.As<Uint8Array>();
            Source.Set(typedArray, _Position);
            _Position += heapView.ByteLength;
        }
        /// <summary>
        /// Write to the stream
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public void Write(Uint8Array buffer, int offset, long count)
        {
            if (Source == null) throw new ObjectDisposedException(nameof(Source));
            if (ReadOnly) throw new NotSupportedException("Stream is in read-only mode");
            if (offset != 0 || count != buffer.Length)
            {
                using var tmp = buffer.SubArray(offset, count + offset);
                Source.Set(tmp, _Position);
                _Position += count;
            }
            else
            {
                Source.Set(buffer, _Position);
                _Position += count;
            }
        }
        /// <inheritdoc/>
        public override void SetLength(long value)
        {
            SetLength(value, AllowRecreateBuffer);
        }
        /// <summary>
        /// Resizes the stream.
        /// </summary>
        /// <param name="value">The new size</param>
        /// <param name="allowRecreateBuffer">
        /// If true, the underlying ArrayBuffer or SharedArrayBuffer may be recreated if the new size is not compatible with their growable/resizable value.<br/>
        /// This will override the instance's AllowRecreateBuffer property.
        /// </param>
        public void SetLength(long value, bool allowRecreateBuffer)
        {
            if (Source == null) throw new ObjectDisposedException(nameof(Source));
            if (ReadOnly) throw new NotSupportedException("Stream is in read-only mode");
            if (Length == value) return;
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
            if (IsSharedArrayBuffer)
            {
                using var sharedArrayBuffer = Source.Buffer.JSRefMove<SharedArrayBuffer>();
                // try to use the SharedArrayBuffer grow() method if possible
                if (sharedArrayBuffer.Growable && value > Length && value <= sharedArrayBuffer.MaxByteLength)
                {
                    sharedArrayBuffer.Grow(value);
                }
                else if (allowRecreateBuffer)
                {
                    // create a new source and copy the current one to it
                    var prevSource = Source;
                    using var newArrayBuffer = new SharedArrayBuffer(value);
                    Source = new Uint8Array(newArrayBuffer);
                    Source.Set(prevSource);
                    prevSource.Dispose();
                }
                else
                {
                    throw new Exception("ArrayBufferStream cannot resize SharedArrayBuffer.");
                }
            }
            else
            {
                using var arrayBuffer = Source.Buffer;
                // try to use the ArrayBuffer resize() method if possible
                if (arrayBuffer.Resizable && value <= arrayBuffer.MaxByteLength)
                {
                    arrayBuffer.Resize(value);
                }
                else if (allowRecreateBuffer)
                {
                    // create a new source and copy the current one to it
                    var prevSource = Source;
                    using var newArrayBuffer = new ArrayBuffer(value);
                    Source = new Uint8Array(newArrayBuffer);
                    Source.Set(prevSource);
                    prevSource.Dispose();
                }
                else
                {
                    throw new Exception("ArrayBufferStream cannot resize ArrayBuffer.");
                }
            }
        }
    }
}
