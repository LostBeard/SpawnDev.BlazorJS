using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    //public class ProgressEvent : Event
    //{
    //    public ProgressEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
    //}
    public class FileReader : EventTarget
    {
        public T ResultAs<T>() => JSRef.Get<T>("result");
        public FileReader(IJSInProcessObjectReference _ref) : base(_ref) { }
        public FileReader() : base(JS.New(nameof(FileReader))) { }
        public void ReadAsDataURL(Blob blob) => JSRef.CallVoid("readAsDataURL", blob);
        public JSEventCallback<ProgressEvent> OnLoad { get => new JSEventCallback<ProgressEvent>(o => AddEventListener("load", o), o => RemoveEventListener("load", o)); set { } }
        public JSEventCallback<ProgressEvent> OnAbort { get => new JSEventCallback<ProgressEvent>(o => AddEventListener("abort", o), o => RemoveEventListener("abort", o)); set { } }
        public JSEventCallback<ProgressEvent> OnError { get => new JSEventCallback<ProgressEvent>(o => AddEventListener("error", o), o => RemoveEventListener("error", o)); set { } }
        public JSEventCallback<ProgressEvent> OnLoadStart { get => new JSEventCallback<ProgressEvent>(o => AddEventListener("loadstart", o), o => RemoveEventListener("loadstart", o)); set { } }
        public JSEventCallback<ProgressEvent> OnLoadEnd { get => new JSEventCallback<ProgressEvent>(o => AddEventListener("loadend", o), o => RemoveEventListener("loadend", o)); set { } }
        public JSEventCallback<ProgressEvent> OnProgress { get => new JSEventCallback<ProgressEvent>(o => AddEventListener("progress", o), o => RemoveEventListener("progress", o)); set { } }
        public static Task<string?> ReadAsDataURLAsync(Blob blob)
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
            fr.ReadAsDataURL(blob);
            return tcs.Task;
        }
    }
}
