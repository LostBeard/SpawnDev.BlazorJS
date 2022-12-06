using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamDefaultReader
    [JsonConverter(typeof(JSObjectConverter<ReadableStreamDefaultReader>))]
    public class ReadableStreamDefaultReader : JSObject
    {
        public ReadableStreamDefaultReader(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Closed => _ref.Get<bool>("closed");
        public async Task Cancel() => await _ref.CallVoidAsync("cancel");
        public async Task<ReadableStreamReaderReadResponse> Read() => await _ref.CallAsync<ReadableStreamReaderReadResponse>("read");
        public void ReleaseLock() => _ref.CallVoid("releaseLock");
    }
}
