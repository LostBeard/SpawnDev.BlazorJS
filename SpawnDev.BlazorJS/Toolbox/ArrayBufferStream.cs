using SpawnDev.BlazorJS.JSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.Toolbox
{
    public class ArrayBufferStream : Stream
    {
        public override bool CanRead => Source != null;
        public override bool CanSeek => Source != null;
        public override bool CanWrite => Source != null;
        public override bool CanTimeout => false;
        public override long Length => Source == null ? 0 : Source.ByteLength;
        protected long _Position = 0;
        public override long Position { get => _Position; set => _Position = value; }
        public Uint8Array? Source { get; private set; } = null;
        public ArrayBufferStream()
        {
            // SetLength must be called to set the array buffer length
        }
        public ArrayBufferStream(ArrayBuffer arrayBuffer)
        {
            Source = new Uint8Array(arrayBuffer);
        }
        public ArrayBufferStream(long length, ArrayBufferOptions? options = null)
        {
            using var arrayBuffer = options == null ? new ArrayBuffer(length) : new ArrayBuffer(length, options);
            Source = new Uint8Array(arrayBuffer);
        }
        public bool IsDisposed { get; private set; }
        protected override void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            IsDisposed = true;
            Source?.Dispose();
            Source = null;
            base.Dispose(disposing);
        }
        public override void Close()
        {
            base.Close();
        }
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
        public override void Flush() { }
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (Source == null) throw new ObjectDisposedException(nameof(Source));
            var byteCount = (int)Math.Max(0, Math.Min(count, Source.Length - _Position));
            if (byteCount == 0) return 0;
            var end = _Position + byteCount;
            var tmp = Source.SliceBytes(_Position, end);
            System.Array.Copy(tmp, 0, buffer, offset, count);
            _Position = end;
            return byteCount;
        }
        public int Read(Uint8Array buffer, int offset, int count)
        {
            if (Source == null) throw new ObjectDisposedException(nameof(Source));
            var byteCount = (int)Math.Max(0, Math.Min(count, Source.Length - _Position));
            if (byteCount == 0) return 0;
            var end = _Position + byteCount;
            using var tmp = Source.Slice(_Position, end);
            buffer.Set(tmp, offset);
            _Position = end;
            return byteCount;
        }
        public Uint8Array? ReadUint8Array(int count)
        {
            if (Source == null) throw new ObjectDisposedException(nameof(Source));
            var byteCount = (int)Math.Max(0, Math.Min(count, Source.Length - _Position));
            if (byteCount == 0) return null;
            var end = _Position + byteCount;
            var tmp = Source.Slice(_Position, end);
            _Position = end;
            return tmp;
        }
        public override void CopyTo(Stream destination, int bufferSize)
        {
            base.CopyTo(destination, bufferSize);
        }
        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            return base.CopyToAsync(destination, bufferSize, cancellationToken);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            if (Source == null) throw new ObjectDisposedException(nameof(Source));
            if (offset != 0 || count != buffer.Length)
            {
                var tmp = new byte[count];
                System.Array.Copy(buffer, offset, tmp, 0, count);
                Source.Set(tmp, _Position);
                _Position += count;
            }
            else
            {
                Source.Set(buffer, _Position);
                _Position += count;
            }
        }
        public void Write(Uint8Array buffer, int offset, long count)
        {
            if (Source == null) throw new ObjectDisposedException(nameof(Source));
            if (offset != 0 || count != buffer.Length)
            {
                using var tmp = buffer.Slice(offset, count + offset);
                Source.Set(tmp, _Position);
                _Position += count;
            }
            else
            {
                Source.Set(buffer, _Position);
                _Position += count;
            }
        }
        public override void SetLength(long value)
        {
            if (Length == value) return;
            if (Source == null)
            {
                using var arrayBuffer = new ArrayBuffer(value);
                Source = new Uint8Array(arrayBuffer);
            }
            else
            {
                using var arrayBuffer = Source.Buffer;
                // try to use the ArrayBuffer resize method if possible
                if (arrayBuffer.Resizable && arrayBuffer.MaxByteLength <= value)
                {
                    Source.Dispose();
                    arrayBuffer.Resize(value);
                    Source = new Uint8Array(arrayBuffer);
                }
                else
                {
                    // create a new source and copy the current one to it
                    var sourceOrig = Source;
                    using var newArrayBuffer = new ArrayBuffer(value);
                    Source = new Uint8Array(arrayBuffer);
                    Source.Set(sourceOrig);
                    sourceOrig.Dispose();
                }
            }
        }
    }
}
