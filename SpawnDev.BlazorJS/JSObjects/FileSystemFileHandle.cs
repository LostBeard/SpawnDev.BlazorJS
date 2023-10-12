using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{

    // https://developer.mozilla.org/en-US/docs/Web/API/FileSystemFileHandle
    public class FileSystemFileHandle : FileSystemHandle
    {
        public FileSystemFileHandle(IJSInProcessObjectReference _ref) : base(_ref) { }

        public Task<File> GetFile() => JSRef.CallAsync<File>("getFile");
        public Task<FileSystemWritableFileStream> CreateWritable() => JSRef.CallAsync<FileSystemWritableFileStream>("createWritable");
        public Task<FileSystemWritableFileStream> CreateWritable(FileSystemCreateWritableOptions options) => JSRef.CallAsync<FileSystemWritableFileStream>("createWritable", options);
        public async Task<long> GetSize()
        {
            using var file = await GetFile();
            return file.Size;
        }
        public async Task<long> GetLastModified()
        {
            using var file = await GetFile();
            return file.LastModified;
        }
    }
}
