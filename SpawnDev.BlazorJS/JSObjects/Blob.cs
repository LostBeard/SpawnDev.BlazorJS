using Microsoft.JSInterop;
using System.Text;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class BlobOptions
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; } = null;
    }

    // https://developer.mozilla.org/en-US/docs/Web/API/Blob
    public class Blob : JSObject
    {
        public Blob(IJSInProcessObjectReference _ref) : base(_ref) { }

        public Blob(ArrayBuffer[] buffers) : base(JS.New(nameof(Blob), buffers)) { }
        public Blob(ArrayBuffer[] buffers, BlobOptions options) : base(JS.New(nameof(Blob), buffers, options)) { }

        public Blob(IEnumerable<string> buffers, BlobOptions options) : base(JS.New(nameof(Blob), buffers, options)) { }
        public Blob(IEnumerable<string> buffers) : base(JS.New(nameof(Blob), buffers)) { }

        public Blob(Blob[] blobs) : base(JS.New(nameof(Blob), blobs)) { }
        public Blob(Blob[] blobs, BlobOptions options) : base(JS.New(nameof(Blob), blobs, options)) { }

        public Blob(byte[][] blobs) : base(JS.New(nameof(Blob), blobs)) { }
        public Blob(byte[][] blobs, BlobOptions options) : base(JS.New(nameof(Blob), blobs, options)) { }

        public Blob(TypedArray[] typedArrays) : base(JS.New(nameof(Blob), typedArrays)) { }
        public Blob(TypedArray[] typedArrays, BlobOptions options) : base(JS.New(nameof(Blob), typedArrays, options)) { }

        public Blob(DataView[] dataViews) : base(JS.New(nameof(Blob), dataViews)) { }
        public Blob(DataView[] dataViews, BlobOptions options) : base(JS.New(nameof(Blob), dataViews, options)) { }

        public Blob(Union<ArrayBuffer, TypedArray, DataView, Blob, string>[] dataViews) : base(JS.New(nameof(Blob), dataViews)) { }
        public Blob(Union<ArrayBuffer, TypedArray, DataView, Blob, string>[] dataViews, BlobOptions options) : base(JS.New(nameof(Blob), dataViews, options)) { }

        public long Size => JSRef.Get<long>("size");
        public string Type => JSRef.Get<string>("type");
        public Task<string> Text() => JSRef.CallAsync<string>("text");
        public Task<ArrayBuffer> ArrayBuffer() => JSRef.CallAsync<ArrayBuffer>("arrayBuffer");
        /// <summary>
        /// The Blob interface's slice() method creates and returns a new Blob object which contains data from a subset of the blob on which it's called.
        /// </summary>
        /// <param name="startPos">An index into the Blob indicating the first byte to include in the new Blob. If you specify a negative value, it's treated as an offset from the end of the Blob toward the beginning. For example, -10 would be the 10th from last byte in the Blob. The default value is 0. If you specify a value for start that is larger than the size of the source Blob, the returned Blob has size 0 and contains no data.</param>
        /// <param name="endPos">An index into the Blob indicating the first byte that will *not* be included in the new Blob (i.e. the byte exactly at this index is not included). If you specify a negative value, it's treated as an offset from the end of the Blob toward the beginning. For example, -10 would be the 10th from last byte in the Blob. The default value is size.</param>
        /// <param name="contentType">The content type to assign to the new Blob; this will be the value of its type property. The default value is an empty string.</param>
        /// <returns></returns>
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
            var byteString = atob(base64Data);// Invoke<string>("atob", base64Data);
            var mimeString = dataUrl.Split(",")[0].Split(":")[1].Split(";")[0];
            var bytes = Convert.FromBase64String(byteString);
            using var ia = new Uint8Array(bytes);
            var blob = new Blob(new ArrayBuffer[] { ia.Buffer }, new BlobOptions { Type = mimeString });
            return blob;
        }

        public string ToObjectURL()
        {
            return URL.CreateObjectURL(this);
        }

        public Task<string?> ToDataURLAsync()
        {
            var fr = new FileReader();
            var tcs = new TaskCompletionSource<string?>();
            Action<ProgressEvent>? load = null;
            load = new Action<ProgressEvent>((evt) =>
            {
                if (evt.Type == "load")
                {
                    var result = fr.ResultAs<string>();
                    tcs.TrySetResult(result);
                }
                else
                {
                    tcs.TrySetException(new Exception("Failed"));
                }
                fr.OnLoad -= load;
                fr.OnLoadEnd -= load;
                evt.Dispose();
                fr.Dispose();
            });
            fr.OnLoad += load;
            fr.OnLoadEnd += load;
            fr.ReadAsDataURL(this);
            return tcs.Task;
        }
    }
}
