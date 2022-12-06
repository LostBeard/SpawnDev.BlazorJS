using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/File
    [JsonConverter(typeof(JSObjectConverter<File>))]
    public class File : Blob
    {
        public File(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string Name => _ref.Get<string>("name");
        public long LastModified => _ref.Get<long>("lastModified");
    }
}
