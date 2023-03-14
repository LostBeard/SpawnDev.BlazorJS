using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/File
    
    public class FileSystemFileHandle : FileSystemHandle
    {
        public FileSystemFileHandle(IJSInProcessObjectReference _ref) : base(_ref) { }

        public async Task<File> GetFile()
        {
            return await JSRef.CallAsync<File>("getFile");
        }
    }
}
