using Microsoft.JSInterop;
using System.Text;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects {
    public class BlobOptions {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; } = null;
    }

    // https://developer.mozilla.org/en-US/docs/Web/API/Blob
    public class Blob : JSObject {
        public Blob(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Blob(ArrayBuffer[] buffers, BlobOptions options) : base(JS.New(nameof(Blob), buffers, options)) { }
        public Blob(IEnumerable<string> buffers, BlobOptions options) : base(JS.New(nameof(Blob), buffers, options)) { }
        public long Size => JSRef.Get<long>("size");
        public string Type => JSRef.Get<string>("type");
        public Task<string> Text() => JSRef.CallAsync<string>("text");
        public Task<ArrayBuffer> ArrayBuffer() => JSRef.CallAsync<ArrayBuffer>("arrayBuffer");
        public Blob Slice(long startPos, long endPos, string contentType) => JSRef.Call<Blob>("slice", startPos, endPos, contentType);
        public ReadableStream Stream() => JSRef.Call<ReadableStream>("stream");
        static string atob(string str) {
            var bytes = Encoding.UTF8.GetBytes(str);
            var b64 = Convert.ToBase64String(bytes);
            int mod4 = b64.Length % 4;
            if (mod4 > 0) b64 += new string('=', 4 - mod4);
            return b64;
        }
        public static Blob FromDataURL(string dataUrl) {
            var base64Data = dataUrl.Split(",")[1];
            var byteString = atob(base64Data);// Invoke<string>("atob", base64Data);
            var mimeString = dataUrl.Split(",")[0].Split(":")[1].Split(";")[0];
            var bytes = Convert.FromBase64String(byteString);
            using var ia = new Uint8Array(bytes);
            var blob = new Blob(new ArrayBuffer[] { ia.Buffer }, new BlobOptions { Type = mimeString });
            return blob;
        }
    }
}
