using Microsoft.JSInterop;
using System.Text.Json;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The StorageManager interface of the Storage API provides an interface for managing persistence permissions and estimating available storage. You can get a reference to this interface using either navigator.storage or WorkerNavigator.storage.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/StorageManager
    /// </summary>
    public class StorageManager : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public StorageManager(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a Promise that resolves to true if persistence has already been granted for your site's storage.
        /// </summary>
        /// <returns></returns>
        public Task<bool> Persisted() => JSRef.CallAsync<bool>("persisted");
        /// <summary>
        /// Returns a Promise that resolves to true if the user agent is able to persist your site's storage.
        /// </summary>
        /// <returns></returns>
        public Task<bool> Persist() => JSRef.CallAsync<bool>("persist");
        /// <summary>
        /// Returns a Promise that resolves to an object containing usage and quota numbers for your origin.
        /// </summary>
        /// <returns></returns>
        public Task<StorageManagerEstimate> Estimate() => JSRef.CallAsync<StorageManagerEstimate>("estimate");
        /// <summary>
        /// The getDirectory() method of the StorageManager interface is used to obtain a reference to a FileSystemDirectoryHandle object allowing access to a directory and its contents, stored in the origin private file system (OPFS).
        /// </summary>
        /// <returns></returns>
        public Task<FileSystemDirectoryHandle> GetDirectory() => JSRef.CallAsync<FileSystemDirectoryHandle>("getDirectory");

        public async Task<FileSystemDirectoryHandle?> GetDirectory(string path, bool create = false)
        {
            path = path.Trim('/');
            if (string.IsNullOrEmpty(path)) throw new Exception("Invalid path");
            var curDir = await GetDirectory();
            var pathParts = path.Split("/").ToList();
            while (pathParts.Count > 0)
            {
                var pathPart = pathParts.First();
                pathParts.RemoveAt(0);
                var nextDir = await curDir.GetDirectoryHandle(pathPart, create);
                curDir.Dispose();
                if (nextDir == null) return null;
                curDir = nextDir;
            }
            return curDir;
        }

        public async Task<FileSystemFileHandle?> GetFile(string path, bool create = false)
        {
            path = path.Trim('/');
            if (string.IsNullOrEmpty(path)) throw new Exception("Invalid path");
            var pathParts = path.Split("/").ToList();
            var curDir = await GetDirectory();
            while (pathParts.Count > 1)
            {
                var pathPart = pathParts.First();
                pathParts.RemoveAt(0);
                var nextDir = await curDir.GetDirectoryHandle(pathPart, create);
                curDir.Dispose();
                if (nextDir == null) return null;
                curDir = nextDir;
            }
            var fileName = pathParts[0];
            var ret = await curDir.GetFileHandle(fileName, create);
            curDir.Dispose();
            return ret;
        }
        public async Task RemoveEntry(string path, bool recursive = false)
        {
            var curDir = await GetDirectory();
            var pathParts = path.Split("/", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
            if (pathParts.Count == 0)
            {
                curDir.Dispose();
                return;
            }
            while (pathParts.Count > 1)
            {
                var pathPart = pathParts.First();
                pathParts.RemoveAt(0);
                var nextDir = await curDir.GetDirectoryHandle(pathPart);
                curDir.Dispose();
                if (nextDir == null) return;
                curDir = nextDir;
            }
            var fileName = pathParts[0];
            await curDir.RemoveEntry(fileName, recursive);
            curDir.Dispose();
        }

        public async Task<List<FileSystemHandle>?> GetEntries(string path, bool create = false)
        {
            var curDir = await GetDirectory();
            var pathParts = path.Split("/", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
            while (pathParts.Count > 0)
            {
                var pathPart = pathParts.First();
                pathParts.RemoveAt(0);
                var nextDir = await curDir.GetDirectoryHandle(pathPart, create);
                curDir.Dispose();
                if (nextDir == null) return null;
                curDir = nextDir;
            }
            var entries = await curDir.Values();
            curDir.Dispose();
            return entries;
        }

        public async Task<bool> DirectoryExists(string path)
        {
            using var entry = await GetDirectory(path);
            return entry != null;
        }

        public async Task<bool> FileExists(string path)
        {
            using var entry = await GetFile(path);
            return entry != null;
        }

        public Task FileWriteJSON<T>(string path, T content)
        {
            var json = JsonSerializer.Serialize(content);
            return FileWriteString(path, json);
        }

        public async Task FileWriteString(string path, string content)
        {
            using var fileEntry = await GetFile(path, true);
            using var writableStream = await fileEntry.CreateWritable();
            using var defaultWriter = writableStream.GetWriter();
            await defaultWriter.Ready;
            await defaultWriter.Write(content);
            await defaultWriter.Ready;
            defaultWriter.Close();
        }

        public async Task FileWriteBytes(string path, byte[] content)
        {
            using var fileEntry = await GetFile(path, true);
            using var writableStream = await fileEntry.CreateWritable();
            using var defaultWriter = writableStream.GetWriter();
            await defaultWriter.Ready;
            await defaultWriter.Write(content);
            await defaultWriter.Ready;
            defaultWriter.Close();
        }

        static JsonSerializerOptions jsonSerializer = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, ReadCommentHandling = JsonCommentHandling.Skip, AllowTrailingCommas = true };

        public async Task<T> FileReadJSON<T>(string path)
        {
            var json = await FileReadString(path);
            var ret = JsonSerializer.Deserialize<T>(json, jsonSerializer);
            return ret;
        }

        public async Task<string> FileReadString(string path)
        {
            using var fileEntry = await GetFile(path);
            if (fileEntry == null) throw new Exception("File does not exist");
            using var file = await fileEntry.GetFile();
            return await file.Text();
        }

        public async Task<byte[]> FileReadBytes(string path)
        {
            using var fileEntry = await GetFile(path);
            if (fileEntry == null) throw new Exception("File does not exist");
            using var file = await fileEntry.GetFile();
            using var buffer = await file.ArrayBuffer();
            return buffer.ReadBytes();
        }
    }
}
