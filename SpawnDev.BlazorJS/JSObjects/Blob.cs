using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class BlobOptions
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; } = null;
    }

    // https://developer.mozilla.org/en-US/docs/Web/API/Blob
    [JsonConverter(typeof(JSObjectConverter<Blob>))]
    public class Blob : JSObject
    {
        public Blob(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Blob(ArrayBuffer[] buffers, BlobOptions options) : base(JS.New(nameof(Blob), buffers, options)) { }
        public Blob(IEnumerable<string> buffers, BlobOptions options) : base(JS.New(nameof(Blob), buffers, options)) { }
        public long Size => JSRef.Get<long>("size");
        public string Type => JSRef.Get<string>("type");
        public async Task<string> Text() => await JSRef.CallAsync<string>("text");
        public async Task<ArrayBuffer> ArrayBuffer() => await JSRef.CallAsync<ArrayBuffer>("arrayBuffer");
        public Blob Slice(long startPos, long endPos, string contentType) => JSRef.Call<Blob>("slice", startPos, endPos, contentType);
        public ReadableStream Stream() => JSRef.Call<ReadableStream>("stream");
        static string atob(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var b64 = Convert.ToBase64String(bytes);
            int mod4 = b64.Length % 4;
            if (mod4 > 0) b64 += new string('=', 4 - mod4);
            return b64;
        }
        public static Blob FromDataURL(string dataUrl)
        {
            var base64Data = dataUrl.Split(",")[1];
            //#if DEBUG
            //            IJSObject.GetWindow()._ref.Set("__base64Data", base64Data);
            //#endif
            var byteString = atob(base64Data);// Invoke<string>("atob", base64Data);
            var mimeString = dataUrl.Split(",")[0].Split(":")[1].Split(";")[0];
            var bytes = Convert.FromBase64String(byteString);
            using var ia = new Uint8Array(bytes);
//#if DEBUG
//            JSObject.GetWindow()._ref.Set("__ia", ia);
//#endif
            var blob = new Blob(new ArrayBuffer[] { ia.Buffer }, new BlobOptions { Type = mimeString });
//#if DEBUG
//            JSObject.GetWindow()._ref.Set("__blob", blob);
//#endif
            return blob;
        }
    }
}
