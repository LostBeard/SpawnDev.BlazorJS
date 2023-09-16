using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class DataTransferItem : JSObject
    {
        public DataTransferItem(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string Kind => JSRef.Get<string>("kind");
        public string Type => JSRef.Get<string>("type");
        public File? GetAsFile() => JSRef.Call<File?>("getAsFile");
        public FileSystemHandle? GetAsFileSystemHandle() => JSRef.Call<FileSystemHandle?>("getAsFileSystemHandle");
        public string? GetAsString() => JSRef.Call<string?>("getAsString");
    }
}
