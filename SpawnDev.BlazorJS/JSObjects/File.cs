using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The File interface provides information about files and allows JavaScript in a web page to access their content.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/File
    /// </summary>
    public class File : Blob
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public File(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The File() constructor creates a new File object instance.
        /// </summary>
        /// <param name="bits">An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings.</param>
        /// <param name="name">A string representing the file name or the path to the file.</param>
        public File(IEnumerable<Union<ArrayBuffer, TypedArray, DataView, Blob, string>> bits, string name) : base(JS.New(nameof(File), bits, name)) { }
        /// <summary>
        /// The File() constructor creates a new File object instance.
        /// </summary>
        /// <param name="bits">An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings.</param>
        /// <param name="name">A string representing the file name or the path to the file.</param>
        /// <param name="options">An options object containing optional attributes for the file</param>
        public File(IEnumerable<Union<ArrayBuffer, TypedArray, DataView, Blob, string>> bits, string name, FileOptions options) : base(JS.New(nameof(File), bits, name, options)) { }
        /// <summary>
        /// The File() constructor creates a new File object instance.
        /// </summary>
        /// <param name="bits">An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings.</param>
        /// <param name="name">A string representing the file name or the path to the file.</param>
        public File(IEnumerable<ArrayBuffer> bits, string name) : base(JS.New(nameof(File), bits, name)) { }
        /// <summary>
        /// The File() constructor creates a new File object instance.
        /// </summary>
        /// <param name="bits">An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings.</param>
        /// <param name="name">A string representing the file name or the path to the file.</param>
        /// <param name="options">An options object containing optional attributes for the file</param>
        public File(IEnumerable<ArrayBuffer> bits, string name, FileOptions options) : base(JS.New(nameof(File), bits, name, options)) { }
        /// <summary>
        /// The File() constructor creates a new File object instance.
        /// </summary>
        /// <param name="bits">An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings.</param>
        /// <param name="name">A string representing the file name or the path to the file.</param>
        public File(IEnumerable<TypedArray> bits, string name) : base(JS.New(nameof(File), bits, name)) { }
        /// <summary>
        /// The File() constructor creates a new File object instance.
        /// </summary>
        /// <param name="bits">An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings.</param>
        /// <param name="name">A string representing the file name or the path to the file.</param>
        /// <param name="options">An options object containing optional attributes for the file</param>
        public File(IEnumerable<TypedArray> bits, string name, FileOptions options) : base(JS.New(nameof(File), bits, name, options)) { }
        /// <summary>
        /// The File() constructor creates a new File object instance.
        /// </summary>
        /// <param name="bits">An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings.</param>
        /// <param name="name">A string representing the file name or the path to the file.</param>
        public File(IEnumerable<DataView> bits, string name) : base(JS.New(nameof(File), bits, name)) { }
        /// <summary>
        /// The File() constructor creates a new File object instance.
        /// </summary>
        /// <param name="bits">An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings.</param>
        /// <param name="name">A string representing the file name or the path to the file.</param>
        /// <param name="options">An options object containing optional attributes for the file</param>
        public File(IEnumerable<DataView> bits, string name, FileOptions options) : base(JS.New(nameof(File), bits, name, options)) { }
        /// <summary>
        /// The File() constructor creates a new File object instance.
        /// </summary>
        /// <param name="bits">An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings.</param>
        /// <param name="name">A string representing the file name or the path to the file.</param>
        public File(IEnumerable<Blob> bits, string name) : base(JS.New(nameof(File), bits, name)) { }
        /// <summary>
        /// The File() constructor creates a new File object instance.
        /// </summary>
        /// <param name="bits">An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings.</param>
        /// <param name="name">A string representing the file name or the path to the file.</param>
        /// <param name="options">An options object containing optional attributes for the file</param>
        public File(IEnumerable<Blob> bits, string name, FileOptions options) : base(JS.New(nameof(File), bits, name, options)) { }
        /// <summary>
        /// The File() constructor creates a new File object instance.
        /// </summary>
        /// <param name="bits">An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings.</param>
        /// <param name="name">A string representing the file name or the path to the file.</param>
        public File(IEnumerable<string> bits, string name) : base(JS.New(nameof(File), bits, name)) { }
        /// <summary>
        /// The File() constructor creates a new File object instance.
        /// </summary>
        /// <param name="bits">An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings.</param>
        /// <param name="name">A string representing the file name or the path to the file.</param>
        /// <param name="options">An options object containing optional attributes for the file</param>
        public File(IEnumerable<string> bits, string name, FileOptions options) : base(JS.New(nameof(File), bits, name, options)) { }
        /// <summary>
        /// The File() constructor creates a new File object instance.
        /// </summary>
        /// <param name="bits">An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings.</param>
        /// <param name="name">A string representing the file name or the path to the file.</param>
        public File(IEnumerable<byte[]> bits, string name) : base(JS.New(nameof(File), bits, name)) { }
        /// <summary>
        /// The File() constructor creates a new File object instance.
        /// </summary>
        /// <param name="bits">An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings.</param>
        /// <param name="name">A string representing the file name or the path to the file.</param>
        /// <param name="options">An options object containing optional attributes for the file</param>
        public File(IEnumerable<byte[]> bits, string name, FileOptions options) : base(JS.New(nameof(File), bits, name, options)) { }


        /// <summary>
        /// Returns the name of the file referenced by the File object.
        /// </summary>
        public string Name => JSRef!.Get<string>("name");
        /// <summary>
        /// Returns the last modified time of the file, in millisecond since the UNIX epoch (January 1st, 1970 at Midnight).
        /// </summary>
        public long LastModified => JSRef!.Get<long>("lastModified");
        /// <summary>
        /// Returns the path the URL of the File is relative to.
        /// </summary>
        public string? WebkitRelativePath => JSRef!.Get<string?>("webkitRelativePath");
        /// <summary>
        /// Start downloading the File using the File.Name
        /// </summary>
        /// <returns></returns>
        public Task StartDownload() => StartDownload(Name);
    }
}
