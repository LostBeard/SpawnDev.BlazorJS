using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    //public class ProgressEvent : Event
    //{
    //    public ProgressEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
    //}
    /// <summary>
    /// The FileReader object lets web applications asynchronously read the contents of files (or raw data buffers) stored on the user's computer, using File or Blob objects to specify the file or data to read.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileReader
    /// </summary>
    public class FileReader : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public FileReader(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The FileReader() constructor creates a new FileReader.
        /// </summary>
        public FileReader() : base(JS.New(nameof(FileReader))) { }
        /// <summary>
        /// The file's contents. This property is only valid after the read operation is complete, and the format of the data depends on which of the methods was used to initiate the read operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ResultAs<T>() => JSRef!.Get<T>("result");
        /// <summary>
        /// The file's contents. This property is only valid after the read operation is complete, and the format of the data depends on which of the methods was used to initiate the read operation.
        /// </summary>
        public JSObject? Result => JSRef!.Get<JSObject?>("result");
        /// <summary>
        /// Starts reading the contents of the specified Blob, once finished, the result attribute contains a data: URL representing the file's data.
        /// </summary>
        /// <param name="blob"></param>
        public void ReadAsDataURL(Blob blob) => JSRef!.CallVoid("readAsDataURL", blob);
        /// <summary>
        /// Starts reading the contents of the specified Blob, once finished, the result attribute contains an ArrayBuffer representing the file's data.
        /// </summary>
        /// <param name="blob"></param>
        public void ReadAsArrayBuffer(Blob blob) => JSRef!.CallVoid("readAsArrayBuffer", blob);
        /// <summary>
        /// Starts reading the contents of the specified Blob, once finished, the result attribute contains the contents of the file as a text string. An optional encoding name can be specified.
        /// </summary>
        /// <param name="blob"></param>
        public void ReadAsText(Blob blob) => JSRef!.CallVoid("readAsText", blob);
        /// <summary>
        /// Fired when a read has been aborted, for example because the program called FileReader.abort().
        /// </summary>
        public JSEventCallback<ProgressEvent> OnAbort { get => new JSEventCallback<ProgressEvent>("abort", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the read failed due to an error.
        /// </summary>
        public JSEventCallback<ProgressEvent> OnError { get => new JSEventCallback<ProgressEvent>("error", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a read has completed successfully.
        /// </summary>
        public JSEventCallback<ProgressEvent> OnLoad { get => new JSEventCallback<ProgressEvent>("load", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a read has started.
        /// </summary>
        public JSEventCallback<ProgressEvent> OnLoadStart { get => new JSEventCallback<ProgressEvent>("loadstart", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a read has completed, successfully or not.
        /// </summary>
        public JSEventCallback<ProgressEvent> OnLoadEnd { get => new JSEventCallback<ProgressEvent>("loadend", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired periodically as data is read.
        /// </summary>
        public JSEventCallback<ProgressEvent> OnProgress { get => new JSEventCallback<ProgressEvent>("progress", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Starts reading the contents of the specified Blob, once finished, the result attribute contains a data: URL representing the file's data.
        /// </summary>
        /// <param name="blob"></param>
        /// <returns></returns>
        public static async Task<string?> ReadAsDataURLAsync(Blob blob)
        {
            using var fr = new FileReader();
            var tcs = new TaskCompletionSource<string?>();
            Action<ProgressEvent>? load = null;
            load = new Action<ProgressEvent>((evt) =>
            {
                fr.OnLoad -= load;
                fr.OnLoadEnd -= load;
                if (evt.Type == "load")
                {
                    var result = fr.ResultAs<string>();
                    tcs.TrySetResult(result);
                }
                else
                {
                    tcs.TrySetException(new Exception("Failed"));
                }
                evt.Dispose();
            });
            fr.OnLoad += load;
            fr.OnLoadEnd += load;
            fr.ReadAsDataURL(blob);
            return await tcs.Task;
        }
        /// <summary>
        /// Starts reading the contents of the specified Blob, once finished, the result attribute contains the contents of the file as a text string. An optional encoding name can be specified.
        /// </summary>
        /// <param name="blob"></param>
        /// <returns></returns>
        public static async Task<string?> ReadAsTextAsync(Blob blob)
        {
            using var fr = new FileReader();
            var tcs = new TaskCompletionSource<string?>();
            Action<ProgressEvent>? load = null;
            load = new Action<ProgressEvent>((evt) =>
            {
                fr.OnLoad -= load;
                fr.OnLoadEnd -= load;
                if (evt.Type == "load")
                {
                    var result = fr.ResultAs<string>();
                    tcs.TrySetResult(result);
                }
                else
                {
                    tcs.TrySetException(new Exception("Failed"));
                }
                evt.Dispose();
            });
            fr.OnLoad += load;
            fr.OnLoadEnd += load;
            fr.ReadAsText(blob);
            return await tcs.Task;
        }
        /// <summary>
        /// Starts reading the contents of the specified Blob, once finished, the result attribute contains an ArrayBuffer representing the file's data.
        /// </summary>
        /// <param name="blob"></param>
        /// <returns></returns>
        public static async Task<ArrayBuffer?> ReadAsArrayBufferAsync(Blob blob)
        {
            using var fr = new FileReader();
            var tcs = new TaskCompletionSource<ArrayBuffer?>();
            Action<ProgressEvent>? load = null;
            load = new Action<ProgressEvent>((evt) =>
            {
                fr.OnLoad -= load;
                fr.OnLoadEnd -= load;
                if (evt.Type == "load")
                {
                    var result = fr.ResultAs<ArrayBuffer>();
                    tcs.TrySetResult(result);
                }
                else
                {
                    tcs.TrySetException(new Exception("Failed"));
                }
                evt.Dispose();
            });
            fr.OnLoad += load;
            fr.OnLoadEnd += load;
            fr.ReadAsArrayBuffer(blob);
            return await tcs.Task;
        }
    }
}
