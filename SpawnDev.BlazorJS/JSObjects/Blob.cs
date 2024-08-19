using Microsoft.JSInterop;
using System.Text;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Blob object represents a blob, which is a file-like object of immutable, raw data; they can be read as text or binary data, or converted into a ReadableStream so its methods can be used for processing the data.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Blob
    /// </summary>
    public class Blob : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Blob(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a newly created Blob object which contains a concatenation of all of the data in the array passed into the constructor.
        /// </summary>
        /// <param name="buffers"></param>
        /// <param name="options"></param>
        public Blob(IEnumerable<ArrayBuffer> buffers, BlobOptions? options = null) : base(options == null ? JS.New(nameof(Blob), buffers) :JS.New(nameof(Blob), buffers, options)) { }
        /// <summary>
        /// Returns a newly created Blob object which contains a concatenation of all of the data in the array passed into the constructor.
        /// </summary>
        /// <param name="buffers"></param>
        /// <param name="options"></param>
        public Blob(IEnumerable<string> buffers, BlobOptions? options = null) : base(options == null ? JS.New(nameof(Blob), buffers) : JS.New(nameof(Blob), buffers, options)) { }
        /// <summary>
        /// Returns a newly created Blob object which contains a concatenation of all of the data in the array passed into the constructor.
        /// </summary>
        /// <param name="blobs"></param>
        /// <param name="options"></param>
        public Blob(IEnumerable<Blob> blobs, BlobOptions? options = null) : base(options == null ? JS.New(nameof(Blob), blobs) : JS.New(nameof(Blob), blobs, options)) { }
        /// <summary>
        /// Returns a newly created Blob object which contains a concatenation of all of the data in the array passed into the constructor.
        /// </summary>
        /// <param name="blobs"></param>
        /// <param name="options"></param>
        public Blob(IEnumerable<byte[]> blobs, BlobOptions? options = null) : base(options == null ? JS.New(nameof(Blob), blobs) : JS.New(nameof(Blob), blobs, options)) { }
        /// <summary>
        /// Returns a newly created Blob object which contains a concatenation of all of the data in the array passed into the constructor.
        /// </summary>
        /// <param name="typedArrays"></param>
        /// <param name="options"></param>
        public Blob(IEnumerable<TypedArray> typedArrays, BlobOptions? options = null) : base(options == null ? JS.New(nameof(Blob), typedArrays) : JS.New(nameof(Blob), typedArrays, options)) { }
        /// <summary>
        /// Returns a newly created Blob object which contains a concatenation of all of the data in the array passed into the constructor.
        /// </summary>
        /// <param name="dataViews"></param>
        /// <param name="options"></param>
        public Blob(IEnumerable<DataView> dataViews, BlobOptions? options = null) : base(options == null ? JS.New(nameof(Blob), dataViews) : JS.New(nameof(Blob), dataViews, options)) { }
        /// <summary>
        /// Returns a newly created Blob object which contains a concatenation of all of the data in the array passed into the constructor.
        /// </summary>
        /// <param name="dataViews"></param>
        /// <param name="options"></param>
        public Blob(IEnumerable<Union<ArrayBuffer, TypedArray, DataView, Blob, string>> data, BlobOptions? options = null) : base(options == null ? JS.New(nameof(Blob), data) : JS.New(nameof(Blob), data, options)) { }
        /// <summary>
        /// The size, in bytes, of the data contained in the Blob object.
        /// </summary>
        public long Size => JSRef!.Get<long>("size");
        /// <summary>
        /// A string indicating the MIME type of the data contained in the Blob. If the type is unknown, this string is empty.
        /// </summary>
        public string Type => JSRef!.Get<string>("type");
        /// <summary>
        /// Returns a promise that resolves with a string containing the entire contents of the Blob interpreted as UTF-8 text.
        /// </summary>
        /// <returns></returns>
        public Task<string> Text() => JSRef!.CallAsync<string>("text");
        /// <summary>
        /// Returns a promise that resolves with an ArrayBuffer containing the entire contents of the Blob as binary data.
        /// </summary>
        /// <returns></returns>
        public Task<ArrayBuffer> ArrayBuffer() => JSRef!.CallAsync<ArrayBuffer>("arrayBuffer");
        /// <summary>
        /// The Blob interface's slice() method creates and returns a new Blob object which contains data from a subset of the blob on which it's called.
        /// </summary>
        /// <param name="startPos">An index into the Blob indicating the first byte to include in the new Blob. If you specify a negative value, it's treated as an offset from the end of the Blob toward the beginning. For example, -10 would be the 10th from last byte in the Blob. The default value is 0. If you specify a value for start that is larger than the size of the source Blob, the returned Blob has size 0 and contains no data.</param>
        /// <param name="endPos">An index into the Blob indicating the first byte that will *not* be included in the new Blob (i.e. the byte exactly at this index is not included). If you specify a negative value, it's treated as an offset from the end of the Blob toward the beginning. For example, -10 would be the 10th from last byte in the Blob. The default value is size.</param>
        /// <param name="contentType">The content type to assign to the new Blob; this will be the value of its type property. The default value is an empty string.</param>
        /// <returns></returns>
        public Blob Slice(long startPos, long endPos, string contentType) => JSRef!.Call<Blob>("slice", startPos, endPos, contentType);
        /// <summary>
        /// Returns a ReadableStream that can be used to read the contents of the Blob.
        /// </summary>
        /// <returns></returns>
        public ReadableStream Stream() => JSRef!.Call<ReadableStream>("stream");
        static string atob(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var b64 = Convert.ToBase64String(bytes);
            int mod4 = b64.Length % 4;
            if (mod4 > 0) b64 += new string('=', 4 - mod4);
            return b64;
        }
        /// <summary>
        /// Creates a new Blob from a data url
        /// </summary>
        /// <param name="dataUrl"></param>
        /// <returns></returns>
        public static Blob FromDataURL(string dataUrl)
        {
            var base64Data = dataUrl.Split(",")[1];
            var byteString = atob(base64Data);
            var mimeString = dataUrl.Split(",")[0].Split(":")[1].Split(";")[0];
            var bytes = Convert.FromBase64String(byteString);
            using var ia = new Uint8Array(bytes);
            var blob = new Blob(new ArrayBuffer[] { ia.Buffer }, new BlobOptions { Type = mimeString });
            return blob;
        }
        /// <summary>
        /// Returns an ObjectURL created using URL.CreateObjectURL
        /// </summary>
        /// <returns></returns>
        public string ToObjectURL()
        {
            return URL.CreateObjectURL(this);
        }
        /// <summary>
        /// Returns the blob as a data url string
        /// </summary>
        /// <returns></returns>
        public Task<string> ToDataURLAsync()
        {
            var fr = new FileReader();
            var tcs = new TaskCompletionSource<string>();
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
                fr.OnLoad -= load!;
                fr.OnLoadEnd -= load!;
                evt.Dispose();
                fr.Dispose();
            });
            fr.OnLoad += load;
            fr.OnLoadEnd += load;
            fr.ReadAsDataURL(this);
            return tcs.Task;
        }
        /// <summary>
        /// Start download of the blob
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task StartDownload(string fileName)
        {
            var url = URL.CreateObjectURL(this);
            using var document = JS.Get<Document>("document");
            using var body = document.Body!;
            var a = document.CreateElement<HTMLAnchorElement>("a");
            a.Href = url;
            a.Download = fileName;
            body.AppendChild(a);
            using var style = a.Style;
            style.SetProperty("display", "none");
            a.Click();
            a.Remove();
            URL.RevokeObjectURL(url);
        }
    }
}
