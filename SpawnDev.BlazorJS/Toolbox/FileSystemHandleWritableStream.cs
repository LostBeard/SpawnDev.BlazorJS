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
    public class FileSystemHandleWritableStream : Stream, IDisposable
    {
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
        ///<inheritdoc/>
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
            if (offset != 0 || count != buffer.Length)
            {
                var tmp = new byte[count];
                System.Array.Copy(buffer, offset, tmp, 0, count);
                await Writer.Write(tmp);
            }
            else
            {
                await Writer.Write(buffer);
            }
            _Position += count;
            _PositionReal = _Position;
            if (Position > Length)
            {
                _Length = Position;
            }
        }
        ///<inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (Writer != null)
            {
                Writer.ReleaseLock();
                Writer.Dispose();
                Writer = null!;
            }
            FSStream?.Close();
            FSStream?.Dispose();
            FSStream = null!;
            base.Dispose(disposing);
        }
    }
}

