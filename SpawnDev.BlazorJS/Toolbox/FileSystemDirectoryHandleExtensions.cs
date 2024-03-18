using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    public static class FileSystemDirectoryHandleExtensions
    {
        #region Write
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, ArrayBuffer data)
        {
            using var fileHandle = await _this!.GetFileHandle(filename, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, Blob data)
        {
            using var fileHandle = await _this!.GetFileHandle(filename, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, TypedArray data)
        {
            using var fileHandle = await _this!.GetFileHandle(filename, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, byte[] data)
        {
            using var fileHandle = await _this!.GetFileHandle(filename, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, DataView data)
        {
            using var fileHandle = await _this!.GetFileHandle(filename, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, string data)
        {
            using var fileHandle = await _this!.GetFileHandle(filename, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, FileSystemWriteOptions data)
        {
            using var fileHandle = await _this!.GetFileHandle(filename, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        #endregion
        #region Append
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, ArrayBuffer data)
        {
            using var fileHandle = await _this!.GetFileHandle(filename, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, Blob data)
        {
            using var fileHandle = await _this!.GetFileHandle(filename, true);
            using var stream = await fileHandle!.CreateWritable();;
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, TypedArray data)
        {
            using var fileHandle = await _this!.GetFileHandle(filename, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, byte[] data)
        {
            using var fileHandle = await _this!.GetFileHandle(filename, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, DataView data)
        {
            using var fileHandle = await _this!.GetFileHandle(filename, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, string data)
        {
            using var fileHandle = await _this!.GetFileHandle(filename, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, FileSystemWriteOptions data)
        {
            using var fileHandle = await _this!.GetFileHandle(filename, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        #endregion
    }
}
