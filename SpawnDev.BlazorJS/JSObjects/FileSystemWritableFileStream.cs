using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class FileSystemWritableFileStream : WritableStream
    {
        public FileSystemWritableFileStream(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Task Write(ArrayBuffer data) => JSRef.CallVoidAsync("write", data);
        public Task Write(Blob data) => JSRef.CallVoidAsync("write", data);
        public Task Write(TypedArray data) => JSRef.CallVoidAsync("write", data);
        public Task Write(byte[] data) => JSRef.CallVoidAsync("write", data);
        public Task Write(DataView data) => JSRef.CallVoidAsync("write", data);
        public Task Write(string data) => JSRef.CallVoidAsync("write", data);
        public Task Write(FileSystemWriteOptions data) => JSRef.CallVoidAsync("write", data);
        public Task Truncate(ulong size) => JSRef.CallVoidAsync("truncate", size);
        public Task Seek(ulong position) => JSRef.CallVoidAsync("seek", position);
    }
}
