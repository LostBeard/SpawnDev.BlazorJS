using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects {
    public class ResponseOptions {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Status { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? StatusText { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, string>? Headers { get; set; }
    }

    // unfinished implementation
    // TODO - finish
    // https://developer.mozilla.org/en-US/docs/Web/API/Response

    public class Response : JSObject {
        public bool Ok => JSRef.Get<bool>("ok");
        public Response(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Response() : base(JS.New(nameof(Response))) { }
        public Response(string body, ResponseOptions? options = null) : base(JS.New(nameof(Response), body, options)) { }
        public Response(Blob body, ResponseOptions? options = null) : base(JS.New(nameof(Response), body, options)) { }
        public Response(ArrayBuffer body, ResponseOptions? options = null) : base(JS.New(nameof(Response), body, options)) { }
        public Response(ReadableStream body, ResponseOptions? options = null) : base(JS.New(nameof(Response), body, options)) { }
        public Headers Headers => JSRef.Get<Headers>("headers");
        //public Response(TypedArray body) : base(JS.New(nameof(Response), body)) { }
        //public Response(DataView body) : base(JS.New(nameof(Response), body)) { }
        //public Response(FormData body) : base(JS.New(nameof(Response), body)) { }
        //public Response(URLSearchParams body) : base(JS.New(nameof(Response), body)) { }

        //public Response(string data, string contentType = "text/plain;charset=UTF-8") : base(NullRef)
        //{
        //    FromReference(JS.New("Response", data));
        //    if (!string.IsNullOrEmpty(contentType))
        //    {
        //        using var headers = JSRef.Get<JSObject>("headers");
        //        headers.JSRef.CallVoid("set", "Content-Type", contentType);
        //        headers.JSRef.CallVoid("set", "Content-Length", Encoding.UTF8.GetByteCount(data));
        //    }
        //}

        //public static Response FromUint8Array(Uint8Array uint8array, string contentType = "application/octet-stream")
        //{
        //    var ret = new Response();
        //    using var headers = JSRef.Get<JSObject>("headers");
        //    headers.JSRef.CallVoid("set", "Content-Type", contentType);
        //    headers.JSRef.CallVoid("set", "Content-Length", uint8array.ByteLength);
        //}

        //public Response(byte[] data, string contentType = "application/octet-stream") : base(NullRef)
        //{
        //    using var uint8array = new Uint8Array(data);
        //    FromReference(JS.New("Response", uint8array));
        //    using var headers = JSRef.Get<JSObject>("headers");
        //    headers.JSRef.CallVoid("set", "Content-Type", contentType);
        //    headers.JSRef.CallVoid("set", "Content-Length", data.Length);
        //}

        public Task<Blob> Blob() => JSRef.CallAsync<Blob>("blob");
        public Task<string> Text() => JSRef.CallAsync<string>("text");
        public Task<ArrayBuffer> ArrayBuffer() => JSRef.CallAsync<ArrayBuffer>("arrayBuffer");

        public void HeaderSet(string key, string value) {
            using var headers = JSRef.Get<IJSInProcessObjectReference>("headers");
            headers.CallVoid("set", key, value);
        }
        public void HeaderSet(string key, double value) {
            using var headers = JSRef.Get<IJSInProcessObjectReference>("headers");
            headers.CallVoid("set", key, value);
        }
        public void HeaderSet(string key, long value) {
            using var headers = JSRef.Get<IJSInProcessObjectReference>("headers");
            headers.CallVoid("set", key, value);
        }

        public async Task<byte[]> ReadBytes() {
            using var arrayBuffer = await ArrayBuffer();
            return arrayBuffer.ReadBytes();
        }
    }
}
