using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// FileSystemHandleWritableStream extensions
    /// </summary>
    public static partial class FileSystemHandleWritableStreamExtensions
    {
        /// <summary>
        /// Returns a async-only writable Stream
        /// </summary>
        /// <param name="fileHandle"></param>
        /// <param name="appendMode"></param>
        /// <returns></returns>
        public static Task<FileSystemHandleWritableStream> GetWritableStream(this FileSystemFileHandle fileHandle, bool appendMode = false)
        {
            return FileSystemHandleWritableStream.Create(fileHandle, appendMode);
        }
    }
    /// <summary>
    /// Creates an asynchronously writable Stream from a writable FileSystemHandle<br/>
    /// IMPORTANT: Only asynchronous writes will work, synchronous writes will throw an exception<br/>
    /// </summary>
    public class FileSystemHandleWritableStream : JSWriteStreamBase
    {
        /// <summary>
        /// False - an OPFS/disk <c>FileSystemWritableFileStream.write()</c> is async, so synchronous
        /// <see cref="WriteUint8Array(Uint8Array)"/> is not supported (it throws). Use
        /// <see cref="WriteUint8ArrayAsync(Uint8Array, CancellationToken)"/>.
        /// </summary>
        public override bool CanWriteSync => false;
        /// <summary>
        /// Returns true when the Writer is ready and no longer applying back pressure
        /// </summary>
        public Task Ready => Writer?.Ready ?? Task.FromException(new Exception("Invalid state"));
        /// <summary>
        /// Returns a new instance of FileSystemHandleWritableStream
        /// </summary>
        /// <param name="fileHandle"></param>
        /// <param name="appendMode"></param>
        /// <returns></returns>
        public static async Task<FileSystemHandleWritableStream> Create(FileSystemFileHandle fileHandle, bool appendMode = false)
        {
            var startSize = appendMode ? await fileHandle.GetSize() : 0;
            var fsStream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = appendMode });
            var ret = new FileSystemHandleWritableStream(fileHandle, fsStream, startSize);
            return ret;
        }
        /// <summary>
        /// Private constructor. Used by the static Create method
        /// </summary>
        private FileSystemHandleWritableStream(FileSystemFileHandle fileHandle, FileSystemWritableFileStream fsStream, long startSize)
        {
            FileHandle = fileHandle;
            FSStream = fsStream;
            StartSize = startSize;
            _Length = startSize;
            // if appendMode, set the position to the end of the file
            // the actual seek will be done during the next write
            _Position = startSize;
        }
        /// <summary>
        /// The FileSystemFileHandle that this stream is writing to
        /// </summary>
        public FileSystemFileHandle FileHandle { get; private set; }
        /// <summary>
        /// The FileSystemWritableFileStream that this stream is writing to
        /// </summary>
        FileSystemWritableFileStream? FSStream { get; set; }
        /// <summary>
        /// The WritableStreamDefaultWriter that this stream is writing to
        /// </summary>
        WritableStreamDefaultWriter? Writer { get; set; }
        ///<inheritdoc/>
        public override bool CanRead => false;
        ///<inheritdoc/>
        public override bool CanSeek => true;
        ///<inheritdoc/>
        public override bool CanWrite => true;
        /// <summary>
        /// This size of the stream when this instance was created. Will be 0 if not in append mode.
        /// </summary>
        public long StartSize { get; private set; } = -1;
        long _Length = 0;
        ///<inheritdoc/>
        public override long Length
        {
            get
            {
                return _Length;
            }
        }
        long _Position = 0;
        ///<inheritdoc/>
        public override long Position
        {
            get => _Position;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "Position cannot be less than 0");
                if (value > Length) throw new ArgumentOutOfRangeException(nameof(value), "Position cannot be greater than Length");
                _Position = value;
            }
        }
        /// <summary>
        /// Not Implemented
        /// </summary>
        public override void Flush() { }
        /// <summary>
        /// Not Implemented
        /// </summary>
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
        ///<inheritdoc/>
        public override long Seek(long offset, SeekOrigin origin)
        {
            if (origin == SeekOrigin.Begin)
            {
                Position = offset;
            }
            else if (origin == SeekOrigin.End)
            {
                Position = Length + offset;
            }
            else if (origin == SeekOrigin.Current)
            {
                Position = Position + offset;
            }
            return Position;
        }
        /// <summary>
        /// Not Implemented
        /// </summary>
        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Not Implemented
        /// </summary>
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
        long _PositionReal = 0;
        /// <inheritdoc/>
        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            if (FSStream == null) throw new Exception("Invalid state");
            // seek if needed
            if (_PositionReal != Position)
            {
                if (Writer != null)
                {
                    Writer.ReleaseLock();
                    Writer.Dispose();
                    Writer = null;
                }
                await FSStream.Seek((ulong)Position);
                _PositionReal = Position;
            }
            Writer ??= FSStream.GetWriter();
            // use HeapView to create fast copy of the buffer source region to a new Uint8Array
            using var bufferView = new HeapView<byte>(buffer, offset, count);
            using var tmpUint8Array = bufferView.To<Uint8Array>();
            await Writer.Write(tmpUint8Array);
            _Position += count;
            _PositionReal = _Position;
            if (Position > Length)
            {
                _Length = Position;
            }
        }
        /// <summary>
        /// Write a Uint8Array to the stream
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task WriteAsync(Uint8Array buffer, CancellationToken cancellationToken)
        {
            if (FSStream == null) throw new Exception("Invalid state");
            // seek if needed
            if (_PositionReal != Position)
            {
                if (Writer != null)
                {
                    Writer.ReleaseLock();
                    Writer.Dispose();
                    Writer = null;
                }
                await FSStream.Seek((ulong)Position);
                _PositionReal = Position;
            }
            Writer ??= FSStream.GetWriter();
            await Writer.Write(buffer);
            _Position += buffer.Length;
            _PositionReal = _Position;
            if (Position > Length)
            {
                _Length = Position;
            }
        }
        /// <inheritdoc/>
        public override Task WriteUint8ArrayAsync(Uint8Array data, CancellationToken cancellationToken = default)
            => WriteAsync(data, cancellationToken);
        /// <summary>
        /// Not supported - an OPFS/disk write is async (<see cref="CanWriteSync"/> is false). Use
        /// <see cref="WriteUint8ArrayAsync(Uint8Array, CancellationToken)"/>.
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        public override void WriteUint8Array(Uint8Array data)
            => throw new NotSupportedException($"{nameof(FileSystemHandleWritableStream)}.WriteUint8Array not supported (the OPFS/disk write is async). Use WriteUint8ArrayAsync.");
        bool _committed = false;
        /// <summary>
        /// Flushes and commits the file to disk, AWAITING the underlying OPFS/disk <c>close()</c> Promise -
        /// which is what actually writes the buffered bytes. Prefer this (or <c>await using</c>) over a plain
        /// <c>using</c>: the synchronous <see cref="Dispose(bool)"/> cannot await the async commit, so a plain
        /// <c>using</c> can return before the file is written (browser-timing dependent - a subsequent read can
        /// see an empty/short file, notably on Firefox). Idempotent.
        /// </summary>
        public async Task CloseAsync()
        {
            if (_committed) return;
            _committed = true;
            if (Writer != null)
            {
                // Writer.Close() flushes queued writes, closes the underlying stream (the commit), and
                // releases the lock - all awaited.
                await Writer.Close().ConfigureAwait(false);
                Writer.Dispose();
                Writer = null;
            }
            else if (FSStream != null)
            {
                await FSStream.Close().ConfigureAwait(false);
            }
            FSStream?.Dispose();
            FSStream = null;
        }
        /// <summary>
        /// Commits the file (awaiting the OPFS <c>close()</c>) and then releases resources. Use
        /// <c>await using</c> or call <see cref="CloseAsync"/> explicitly when the written bytes must be
        /// readable afterward - the synchronous <see cref="Dispose(bool)"/> does NOT await the commit.
        /// </summary>
        public override async ValueTask DisposeAsync()
        {
            await CloseAsync().ConfigureAwait(false);
            Dispose();
        }
        ///<inheritdoc/>
        /// <remarks>
        /// WARNING: synchronous disposal CANNOT await the OPFS/disk <c>close()</c> commit - it fires it and
        /// returns, so the written bytes are not guaranteed on disk when this returns. Prefer
        /// <see cref="DisposeAsync"/> (<c>await using</c>) or <see cref="CloseAsync"/> whenever the file is
        /// read back afterward. This sync path exists only as a best-effort fallback.
        /// </remarks>
        protected override void Dispose(bool disposing)
        {
            if (_committed)
            {
                base.Dispose(disposing);
                return;
            }
            if (Writer != null)
            {
                Writer.ReleaseLock();
                Writer.Dispose();
                Writer = null!;
            }
            FSStream?.Close();   // fire-and-forget: commit NOT awaited - see the remarks / use DisposeAsync
            FSStream?.Dispose();
            FSStream = null!;
            base.Dispose(disposing);
        }
    }
}

