using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/File
    public class File : Blob
    {
        public File(IJSInProcessObjectReference _ref) : base(_ref) { }
        public File(IEnumerable<Union<ArrayBuffer, TypedArray, DataView, Blob, string>> bits, string name) : base(JS.New(nameof(File), bits, name)) { }
        public File(IEnumerable<Union<ArrayBuffer, TypedArray, DataView, Blob, string>> bits, string name, FileOptions options) : base(JS.New(nameof(File), bits, name, options)) { }
        public string Name => JSRef.Get<string>("name");
        public long LastModified => JSRef.Get<long>("lastModified");
    }
}
