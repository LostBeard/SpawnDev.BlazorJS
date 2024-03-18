using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    public static class FileSystemFileHandleExtensions
    {
        #region Write
        public static async Task Write(this FileSystemFileHandle _this, ArrayBuffer data)
        {
            using var stream = await _this!.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemFileHandle _this, Blob data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemFileHandle _this, TypedArray data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemFileHandle _this, byte[] data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemFileHandle _this, DataView data)
        {
            
            using var stream = await _this.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemFileHandle _this, string data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemFileHandle _this, FileSystemWriteOptions data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        #endregion
        #region Append
        public static async Task Append(this FileSystemFileHandle _this, ArrayBuffer data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemFileHandle _this, Blob data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemFileHandle _this, TypedArray data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemFileHandle _this, byte[] data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemFileHandle _this, DataView data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemFileHandle _this, string data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemFileHandle _this, FileSystemWriteOptions data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        #endregion
    }
}
