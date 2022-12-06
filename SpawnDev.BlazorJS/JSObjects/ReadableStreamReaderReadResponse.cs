using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<ReadableStreamReaderReadResponse>))]
    public class ReadableStreamReaderReadResponse : JSObject
    {
        public ReadableStreamReaderReadResponse(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Done => _ref.Get<bool>("done");
        public Uint8Array Value => _ref.Get<Uint8Array>("value");
    }
}
