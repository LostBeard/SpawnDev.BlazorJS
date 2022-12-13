using Microsoft.JSInterop;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{

    // Non-Standard implementation
    // TODO
    [JsonConverter(typeof(JSObjectConverter<Response>))]
    public class Response : JSObject
    {
        public bool Ok => JSRef.Get<bool>("ok");

        public Response(IJSInProcessObjectReference _ref) : base(_ref) { }

        public Response(string data, string contentType = "text/plain;charset=UTF-8") : base(NullRef)
        {
            FromReference(JS.New("Response", data));
            if (!string.IsNullOrEmpty(contentType))
            {
                using var headers = JSRef.Get<JSObject>("headers");
                headers.JSRef.CallVoid("set", "Content-Type", contentType);
                headers.JSRef.CallVoid("set", "Content-Length", Encoding.UTF8.GetByteCount(data));
            }
        }

        public Response(Uint8Array uint8array, string contentType = "application/octet-stream") : base(NullRef)
        {
            FromReference(JS.New("Response", uint8array));
            using var headers = JSRef.Get<JSObject>("headers");
            headers.JSRef.CallVoid("set", "Content-Type", contentType);
            headers.JSRef.CallVoid("set", "Content-Length", uint8array.ByteLength);
        }

        public Response(byte[] data, string contentType = "application/octet-stream") : base(NullRef)
        {
            using var uint8array = new Uint8Array(data);
            FromReference(JS.New("Response", uint8array));
            using var headers = JSRef.Get<JSObject>("headers");
            headers.JSRef.CallVoid("set", "Content-Type", contentType);
            headers.JSRef.CallVoid("set", "Content-Length", data.Length);
        }

        public ValueTask<Blob> Blob() => JSRef.CallAsync<Blob>("blob");
        public ValueTask<string> Text() => JSRef.CallAsync<string>("text");
        public ValueTask<ArrayBuffer> ArrayBuffer() => JSRef.CallAsync<ArrayBuffer>("arrayBuffer");

        public void HeaderSet(string key, string value)
        {
            using var headers = JSRef.Get<JSObject>("headers");
            headers.JSRef.CallVoid("set", key, value);
        }

        public async Task<byte[]> ReadBytes()
        {
            using var tmp = await JSRef.CallAsync<ArrayBuffer>("arrayBuffer");
            return tmp.ReadBytes();
        }
    }
}
