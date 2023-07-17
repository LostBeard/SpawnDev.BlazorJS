using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Window : EventTarget
    {
        public Window() : base(JS.Get<IJSInProcessObjectReference>("window")) { }
        public Window(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string? Name { get => JSRef.Get<string>("name"); set => JSRef.Set("name", value); }
        public Storage SessionStorage => JSRef.Get<Storage>("sessionStorage");
        public Storage LocalStorage => JSRef.Get<Storage>("localStorage");
        public Navigator Navigator => JSRef.Get<Navigator>("navigator");
        public Document Document => JSRef.Get<Document>("document");
        public Screen Screen => JSRef.Get<Screen>("screen");
        public CacheStorage Caches => JSRef.Get<CacheStorage>("caches");
        public void Alert(string msg = "") => JSRef.CallVoid("alert", msg);
        public long SetTimeout(Callback callback, double delay) => JSRef.Call<long>("setTimeout", callback, delay);
        public void ClearTimeout(long requestId) => JSRef.CallVoid("clearTimeout", requestId);
        public long RequestAnimationFrame(Callback callback) => JSRef.Call<long>("requestAnimationFrame", callback);
        public void CancelAnimationFrame(long requestId) => JSRef.CallVoid("cancelAnimationFrame", requestId);
        public double DevicePixelRatio { get { var tmp = JSRef.Get<double>("devicePixelRatio"); return tmp > 0d ? tmp : 1d; } }
        public int InnerWidth => JSRef.Get<int>("innerWidth");
        public int InnerHeight => JSRef.Get<int>("innerHeight");
        ///// <summary>
        ///// Experimental state. Not supported in most browsers. (Works in Chrome)
        ///// </summary>
        ///// <returns>ScreenDetails</returns>
        public Task<ScreenDetails> GetScreenDetails() => JSRef.CallAsync<ScreenDetails>("getScreenDetails");

        public MediaQueryList MatchMedia(string mode) => JSRef.Call<MediaQueryList>("matchMedia", mode);

        public JSEventCallback<StorageEvent> OnStorage { get => new JSEventCallback<StorageEvent>(o => AddEventListener("storage", o), o => RemoveEventListener("storage", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<UIEvent> OnResize { get => new JSEventCallback<UIEvent>(o => AddEventListener("resize", o), o => RemoveEventListener("resize", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback OnOffline { get => new JSEventCallback(o => AddEventListener("offline", o), o => RemoveEventListener("offline", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback OnOnline { get => new JSEventCallback(o => AddEventListener("online", o), o => RemoveEventListener("online", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }

        // non-standard .Net extension
        CallbackGroup _callbacks = new CallbackGroup();
        public delegate void AnimationFrameDelegate(double timestamp);
        private Callback _OnAnimationFrameCallback;
        private long _OnAnimationFrameCallbackHandle = 0;
        private int _OnAnimationFrameCount = 0;
        private event AnimationFrameDelegate _OnAnimationFrame;
        public event AnimationFrameDelegate OnAnimationFrame
        {
            add
            {
                _OnAnimationFrame += value;
                _OnAnimationFrameCount = _OnAnimationFrame == null ? 0 : _OnAnimationFrame.GetInvocationList().Length;
                if (_OnAnimationFrameCount == 1)
                {
                    if (_OnAnimationFrameCallback == null) _OnAnimationFrameCallback = Callback.Create<double>(AnimationFrame, _callbacks);
                    _OnAnimationFrameCallbackHandle = RequestAnimationFrame(_OnAnimationFrameCallback);
                }
            }
            remove
            {
                _OnAnimationFrame -= value;
                _OnAnimationFrameCount = _OnAnimationFrame == null ? 0 : _OnAnimationFrame.GetInvocationList().Length;
                if (_OnAnimationFrameCount == 0)
                {
                    if (_OnAnimationFrameCallbackHandle != 0)
                    {
                        CancelAnimationFrame(_OnAnimationFrameCallbackHandle);
                        _OnAnimationFrameCallbackHandle = 0;
                    }
                }
            }
        }
        void AnimationFrame(double timestamp)
        {
            if (_OnAnimationFrameCount > 0)
                _OnAnimationFrameCallbackHandle = RequestAnimationFrame(_OnAnimationFrameCallback);
            _OnAnimationFrame?.Invoke(timestamp);
        }

        public bool ShowDirectoryPickerSupported() => !JS.IsUndefined("showDirectoryPicker");

        public Task<FileSystemDirectoryHandle> ShowDirectoryPicker(ShowDirectoryPickerOptions? options = null) => options == null ?
            JSRef.CallAsync<FileSystemDirectoryHandle>("showDirectoryPicker") :
            JSRef.CallAsync<FileSystemDirectoryHandle>("showDirectoryPicker", options);

        public Task<FileSystemFileHandle> ShowOpenFilePicker(ShowOpenFilePickerOptions? options = null) => options == null ?
            JSRef.CallAsync<FileSystemFileHandle>("showOpenFilePicker") :
            JSRef.CallAsync<FileSystemFileHandle>("showOpenFilePicker", options);

        public Task<Array<FileSystemFileHandle>> ShowSaveFilePicker(ShowSaveFilePickerOptions? options = null) => options == null ?
            JSRef.CallAsync<Array<FileSystemFileHandle>>("showSaveFilePicker") :
            JSRef.CallAsync<Array<FileSystemFileHandle>>("showSaveFilePicker", options);

        public IDBFactory IndexedDB => JSRef.Get<IDBFactory>("indexedDB");
    }

    public class ShowOpenFilePickerType
    {
        public string Description { get; set; } = "";
        public Dictionary<string, List<string>> Accept { get; set; } = new Dictionary<string, List<string>>();
    }

    public class ShowSaveFilePickerOptions
    {
        /// <summary>
        /// A String. The suggested file name.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SuggestedName { get; set; }

        /// <summary>
        /// A boolean value that defaults to false. By default, the picker should include an option to not apply any file type filters (instigated with the type option below). Setting this option to true means that option is not available.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ExcludeAcceptAllOption { get; set; }

        /// <summary>
        /// An Array of allowed file types to save. Each item is an object with the following options:
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ShowOpenFilePickerType>? Types { get; set; }
    }

    public class ShowOpenFilePickerOptions
    {
        /// <summary>
        /// A boolean value that defaults to false. When set to true multiple files may be selected.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Multiple { get; set; }

        /// <summary>
        /// A boolean value that defaults to false. By default the picker should include an option to not apply any file type filters (instigated with the type option below). Setting this option to true means that option is not available.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ExcludeAcceptAllOption { get; set; }

        /// <summary>
        /// An Array of allowed file types to pick. Each item is an object with the following options:
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ShowOpenFilePickerType>? Types { get; set; }
    }

    public class ShowDirectoryPickerOptions
    {
        /// <summary>
        /// By specifying an ID, the browser can remember different directories for different IDs. If the same ID is used for another picker, the picker opens in the same directory.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }
        /// <summary>
        /// A string that defaults to "read" for read-only access or "readwrite" for read and write access to the directory.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Mode { get; set; }
        /// <summary>
        /// A FileSystemHandle or a well known directory ("desktop", "documents", "downloads", "music", "pictures", or "videos") to open the dialog in.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? StartIn { get; set; }
    }
}
