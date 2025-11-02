using SpawnDev.BlazorJS.JSObjects;
using System.IO;
using System.Text.Json;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Adds methods to FileSystemDirectoryHandle
    /// </summary>
    public static class FileSystemDirectoryHandleExtensions
    {
        /// <summary>
        /// Returns the FileSystemDirectoryHandles at the given relative path
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<List<FileSystemDirectoryHandle>> GetPathDirectoryHandles(this FileSystemDirectoryHandle _this, string path)
        {
            using var dir = await _this.GetPathDirectoryHandle(path, false);
            var values = await dir!.ValuesList();
            var files = values.Where(o => o is FileSystemFileHandle).Select(o => (FileSystemFileHandle)o).ToArray();
            files.DisposeAll();
            var dirs = values.Where(o => o is FileSystemDirectoryHandle).Select(o => (FileSystemDirectoryHandle)o).ToList();
            return dirs;
        }
        /// <summary>
        /// Returns the FileSystemDirectoryHandles in this directory
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task<List<FileSystemDirectoryHandle>> GetPathDirectoryHandles(this FileSystemDirectoryHandle _this)
        {
            var values = await _this!.ValuesList();
            var files = values.Where(o => o is FileSystemFileHandle).Select(o => (FileSystemFileHandle)o).ToArray();
            files.DisposeAll();
            var dirs = values.Where(o => o is FileSystemDirectoryHandle).Select(o => (FileSystemDirectoryHandle)o).ToList();
            return dirs;
        }
        /// <summary>
        /// Returns the FileSystemFileHandles at the given relative path
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<List<FileSystemFileHandle>> GetPathFileHandles(this FileSystemDirectoryHandle _this, string path)
        {
            using var dir = await _this.GetPathDirectoryHandle(path, false);
            var values = await dir!.ValuesList();
            var files = values.Where(o => o is FileSystemFileHandle).Select(o => (FileSystemFileHandle)o).ToList();
            var dirs = values.Where(o => o is FileSystemDirectoryHandle).Select(o => (FileSystemDirectoryHandle)o).ToArray();
            dirs.DisposeAll();
            return files;
        }
        /// <summary>
        /// Returns the FileSystemFileHandles in this directory
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task<List<FileSystemFileHandle>> GetPathFileHandles(this FileSystemDirectoryHandle _this)
        {
            var values = await _this!.ValuesList();
            var files = values.Where(o => o is FileSystemFileHandle).Select(o => (FileSystemFileHandle)o).ToList();
            var dirs = values.Where(o => o is FileSystemDirectoryHandle).Select(o => (FileSystemDirectoryHandle)o).ToArray();
            dirs.DisposeAll();
            return files;
        }
        /// <summary>
        /// Returns the FileSystemDirectoryHandle names in the given relative path
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<List<string>> GetPathDirectories(this FileSystemDirectoryHandle _this, string path)
        {
            using var dir = await _this.GetPathDirectoryHandle(path, false);
            var values = await dir!.ValuesList();
            var dirs = values.Where(o => o is FileSystemDirectoryHandle).Select(o => (FileSystemDirectoryHandle)o);
            var ret = dirs.Select(o => o.Name).ToList();
            values.ToArray().DisposeAll();
            return ret;
        }
        /// <summary>
        /// Returns the FileSystemDirectoryHandle names in this directory
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task<List<string>> GetPathDirectories(this FileSystemDirectoryHandle _this)
        {
            var values = await _this!.ValuesList();
            var dirs = values.Where(o => o is FileSystemDirectoryHandle).Select(o => (FileSystemDirectoryHandle)o);
            var ret = dirs.Select(o => o.Name).ToList();
            values.ToArray().DisposeAll();
            return ret;
        }
        /// <summary>
        /// Returns the FileSystemFileHandle names in the given relative path
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<List<string>> GetPathFiles(this FileSystemDirectoryHandle _this, string path)
        {
            using var dir = await _this.GetPathDirectoryHandle(path, false);
            var values = await dir!.ValuesList();
            var files = values.Where(o => o is FileSystemFileHandle).Select(o => (FileSystemFileHandle)o);
            var ret = files.Select(o => o.Name).ToList();
            values.ToArray().DisposeAll();
            return ret;
        }
        /// <summary>
        /// Returns the FileSystemFileHandle names in this directory
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task<List<string>> GetPathFiles(this FileSystemDirectoryHandle _this)
        {
            var values = await _this!.ValuesList();
            var files = values.Where(o => o is FileSystemFileHandle).Select(o => (FileSystemFileHandle)o);
            var ret = files.Select(o => o.Name).ToList();
            values.ToArray().DisposeAll();
            return ret;
        }
        /// <summary>
        /// Returns reu if the path exists
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<bool> PathExists(this FileSystemDirectoryHandle _this, string path)
        {
            using var dir = await _this.GetPathHandle(path);
            return dir != null;
        }
        /// <summary>
        /// Returns true if a directory exists at the given path
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<bool> DirectoryPathExists(this FileSystemDirectoryHandle _this, string path)
        {
            using var dir = await _this.GetPathDirectoryHandle(path, false);
            return dir != null;
        }
        /// <summary>
        /// Returns true if a file exists at the given path
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<bool> FilePathExists(this FileSystemDirectoryHandle _this, string path)
        {
            using var file = await _this.GetPathFileHandle(path, false);
            return file != null;
        }
        /// <summary>
        /// Returns a FileSystemDirectoryHandle for the given path or returns null<br />
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path">/ delimited path</param>
        /// <param name="create">if true the path will be created if it does not exist</param>
        /// <returns>FileSystemFileHandle</returns>
        public static async Task<FileSystemDirectoryHandle?> GetPathDirectoryHandle(this FileSystemDirectoryHandle _this, string path, bool create = false)
        {
            var pathParts = path.Split("/", StringSplitOptions.RemoveEmptyEntries).ToList();
            if (pathParts.Count == 0) return null;
            var curDir = _this;
            FileSystemDirectoryHandle? nextDir;
            for (var i = 0; i < pathParts.Count - 1; i++)
            {
                var pathPart = pathParts[i];
                try
                {
                    nextDir = await curDir.GetDirectoryHandle(pathPart, create);
                }
                catch
                {
                    return null;
                }
                if (_this != curDir) curDir.Dispose();
                if (nextDir == null) return null;
                curDir = nextDir;
            }
            var fileName = pathParts.Last();
            try
            {
                var ret = await curDir.GetDirectoryHandle(fileName, create);
                if (_this != curDir) curDir.Dispose();
                return ret;
            }
            catch { }
            return null;
        }
        /// <summary>
        /// Creates the given path or throws an exception
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task CreatePathDirectory(this FileSystemDirectoryHandle _this, string path)
        {
            var pathParts = path.Split("/", StringSplitOptions.RemoveEmptyEntries).ToList();
            if (pathParts.Count == 0) throw new Exception("CreateDirectory failed: invalid path");
            var curDir = _this;
            FileSystemDirectoryHandle? nextDir;
            for (var i = 0; i < pathParts.Count - 1; i++)
            {
                var pathPart = pathParts[i];
                nextDir = await curDir.GetDirectoryHandle(pathPart, true);
                if (_this != curDir) curDir.Dispose();
                if (nextDir == null) throw new Exception("CreateDirectory failed: failed to create path");
                curDir = nextDir;
            }
            var fileName = pathParts.Last();
            var ret = await curDir.GetDirectoryHandle(fileName, true);
            if (_this != curDir) curDir.Dispose();
        }
        /// <summary>
        /// Returns a FileSystemFileHandle for the given path or returns null<br />
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path">/ delimited path</param>
        /// <param name="create">if true the path will be created if it does not exist</param>
        /// <returns>FileSystemFileHandle</returns>
        public static async Task<FileSystemFileHandle?> GetPathFileHandle(this FileSystemDirectoryHandle _this, string path, bool create = false)
        {
            var pathParts = path.Split("/", StringSplitOptions.RemoveEmptyEntries).ToList();
            if (pathParts.Count == 0) return null;
            var curDir = _this;
            FileSystemDirectoryHandle? nextDir;
            for (var i = 0; i < pathParts.Count - 1; i++)
            {
                var pathPart = pathParts[i];
                try
                {
                    nextDir = await curDir.GetDirectoryHandle(pathPart, create);
                }
                catch
                {
                    return null;
                }
                if (_this != curDir) curDir.Dispose();
                if (nextDir == null) return null;
                curDir = nextDir;
            }
            var fileName = pathParts.Last();
            try
            {
                var ret = await curDir.GetFileHandle(fileName, create);
                if (_this != curDir) curDir.Dispose();
                return ret;
            }
            catch { }
            return null;
        }
        /// <summary>
        /// Returns the FileSystemFileHandle or FileSystemDirectoryHandle at the given path or null
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<FileSystemHandle?> GetPathHandle(this FileSystemDirectoryHandle _this, string path)
        {
            var pathParts = path.Split("/", StringSplitOptions.RemoveEmptyEntries).ToList();
            if (pathParts.Count == 0) return null;
            var curDir = _this;
            FileSystemDirectoryHandle? nextDir;
            for (var i = 0; i < pathParts.Count - 1; i++)
            {
                var pathPart = pathParts[i];
                try
                {
                    nextDir = await curDir.GetDirectoryHandle(pathPart, false);
                }
                catch
                {
                    return null;
                }
                if (_this != curDir) curDir.Dispose();
                if (nextDir == null) return null;
                curDir = nextDir;
            }
            var fileName = pathParts.Last();
            try
            {
                var ret = await curDir.GetFileHandle(fileName, false);
                if (_this != curDir) curDir.Dispose();
                return ret;
            }
            catch { }
            try
            {
                var ret = await curDir.GetDirectoryHandle(fileName, false);
                if (_this != curDir) curDir.Dispose();
                return ret;
            }
            catch { }
            return null;
        }
        /// <summary>
        /// Removes the entry at the given relative path
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public static async Task RemovePath(this FileSystemDirectoryHandle _this, string path, bool recursive = false)
        {
            var pathParts = path.Split("/", StringSplitOptions.RemoveEmptyEntries).ToList();
            if (pathParts.Count == 0) return;
            var curDir = _this;
            FileSystemDirectoryHandle? nextDir;
            for (var i = 0; i < pathParts.Count - 1; i++)
            {
                var pathPart = pathParts[i];
                try
                {
                    nextDir = await curDir.GetDirectoryHandle(pathPart, false);
                }
                catch
                {
                    return;
                }
                if (_this != curDir) curDir.Dispose();
                if (nextDir == null) return;
                curDir = nextDir;
            }
            var fileName = pathParts.Last();
            try
            {
                await curDir.RemoveEntry(fileName, recursive);
            }
            catch { }
        }
        /// <summary>
        /// Returns the path's parent directory or null
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<FileSystemDirectoryHandle?> GetPathParentHandle(this FileSystemDirectoryHandle _this, string path)
        {
            var pathParts = path.Split("/", StringSplitOptions.RemoveEmptyEntries).ToList();
            if (pathParts.Count == 0) return null;
            var curDir = _this;
            FileSystemDirectoryHandle? nextDir;
            for (var i = 0; i < pathParts.Count - 1; i++)
            {
                var pathPart = pathParts[i];
                try
                {
                    nextDir = await curDir.GetDirectoryHandle(pathPart, false);
                }
                catch
                {
                    return null;
                }
                if (_this != curDir) curDir.Dispose();
                if (nextDir == null) return null;
                curDir = nextDir;
            }
            return curDir;
        }
        #region Write
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemDirectoryHandle _this, string path, ArrayBuffer data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Write(data);
            await stream.Close();
        }
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemDirectoryHandle _this, string path, Blob data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Write(data);
            await stream.Close();
        }
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemDirectoryHandle _this, string path, Stream data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            await fileHandle!.Write(data);
        }
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemDirectoryHandle _this, string path, TypedArray data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Write(data);
            await stream.Close();
        }
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemDirectoryHandle _this, string path, byte[] data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Write(data);
            await stream.Close();
        }
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemDirectoryHandle _this, string path, DataView data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Write(data);
            await stream.Close();
        }
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemDirectoryHandle _this, string path, string data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            using var stream = await fileHandle!.CreateWritable();
            await stream.Write(data);
            await stream.Close();
        }
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        public static async Task WriteJSON(this FileSystemDirectoryHandle _this, string path, object data, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            var json = JsonSerializer.Serialize(data, jsonSerializerOptions);
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Write(json);
            await stream.Close();
        }
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemDirectoryHandle _this, string path, FileSystemWriteOptions data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Write(data);
            await stream.Close();
        }
        #endregion
        #region Append
        /// <summary>
        /// Append data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemDirectoryHandle _this, string path, ArrayBuffer data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.SeekToEnd(fileHandle);
            await stream.Write(data);
            await stream.Close();
        }
        /// <summary>
        /// Append data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemDirectoryHandle _this, string path, Blob data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.SeekToEnd(fileHandle);
            await stream.Write(data);
            await stream.Close();
        }
        /// <summary>
        /// Append data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemDirectoryHandle _this, string path, TypedArray data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.SeekToEnd(fileHandle);
            await stream.Write(data);
            await stream.Close();
        }
        /// <summary>
        /// Append data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemDirectoryHandle _this, string path, byte[] data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.SeekToEnd(fileHandle);
            await stream.Write(data);
            await stream.Close();
        }
        public static async Task Append(this FileSystemDirectoryHandle _this, string path, Stream data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            await fileHandle.Append(data);
        }
        /// <summary>
        /// Append data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemDirectoryHandle _this, string path, DataView data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.SeekToEnd(fileHandle);
            await stream.Write(data);
            await stream.Close();
        }
        /// <summary>
        /// Append data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemDirectoryHandle _this, string path, string data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.SeekToEnd(fileHandle);
            await stream.Write(data);
            await stream.Close();
        }
        /// <summary>
        /// Append data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemDirectoryHandle _this, string path, FileSystemWriteOptions data)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.SeekToEnd(fileHandle);
            await stream.Write(data);
            await stream.Close();
        }
        #endregion
        #region Read
        /// <summary>
        /// Read the data from the file as T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        public static async Task<T> ReadJSON<T>(this FileSystemDirectoryHandle _this, string path, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, false);
            if (fileHandle == null) throw new FileNotFoundException();
            using var file = await fileHandle.GetFile();
            var ret = await file.Text();
            var obj = JsonSerializer.Deserialize<T>(ret, jsonSerializerOptions);
            return obj;
        }
        /// <summary>
        /// Read the data from the file as a string
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<string> ReadText(this FileSystemDirectoryHandle _this, string path)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, false);
            if (fileHandle == null) throw new FileNotFoundException();
            using var file = await fileHandle.GetFile();
            var ret = await file.Text();
            return ret;
        }
        /// <summary>
        /// Read the data from the file as a Stream
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<ArrayBufferStream> ReadStream(this FileSystemDirectoryHandle _this, string path)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, false);
            if (fileHandle == null) throw new FileNotFoundException();
            var arrayBuffer = await fileHandle.ReadArrayBuffer();
            var stream = new ArrayBufferStream(arrayBuffer);
            return stream;
        }
        /// <summary>
        /// Read the data from the file as a byte array
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<byte[]> ReadBytes(this FileSystemDirectoryHandle _this, string path)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, false);
            if (fileHandle == null) throw new FileNotFoundException();
            using var file = await fileHandle.GetFile();
            using var ret = await file.ArrayBuffer();
            return ret.ReadBytes();
        }
        /// <summary>
        /// Read the data from the file as an ArrayBuffer
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<ArrayBuffer> ReadArrayBuffer(this FileSystemDirectoryHandle _this, string path)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, false);
            if (fileHandle == null) throw new FileNotFoundException();
            using var file = await fileHandle.GetFile();
            var ret = await file.ArrayBuffer();
            return ret;
        }
        /// <summary>
        /// Returns the file as a Uint8Array
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static async Task<Uint8Array> ReadUint8Array(this FileSystemDirectoryHandle _this, string path)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, false);
            if (fileHandle == null) throw new FileNotFoundException();
            using var file = await fileHandle.GetFile();
            using var arrayBuffer = await file.ArrayBuffer();
            return new Uint8Array(arrayBuffer);
        }
        /// <summary>
        /// Returns the file as a TypedArray
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static async Task<T> ReadTypedArray<T>(this FileSystemDirectoryHandle _this, string path) where T : TypedArray
        {
            using var fileHandle = await _this.GetPathFileHandle(path, false);
            if (fileHandle == null) throw new FileNotFoundException();
            using var file = await fileHandle.GetFile();
            using var arrayBuffer = await file.ArrayBuffer();
            var ret = Activator.CreateInstance(typeof(T), arrayBuffer)!;
            return (T)ret;
        }
        /// <summary>
        /// Read the data from the file as File
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static async Task<JSObjects.File> ReadFile(this FileSystemDirectoryHandle _this, string path)
        {
            using var fileHandle = await _this.GetPathFileHandle(path, false);
            if (fileHandle == null) throw new FileNotFoundException();
            var file = await fileHandle.GetFile();
            return file;
        }
        #endregion
    }
}
