using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JSObjects.WebRTC;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS {
    //
    public class JSObject : IDisposable {
        public static IJSInProcessObjectReference? NullRef { get; } = null;
        [JsonIgnore]
        public IJSInProcessObjectReference? JSRef { get; private set; }
        [JsonIgnore]
        public bool IsWrapperDisposed { get; private set; } = false;
        public JSObject(IJSInProcessObjectReference _ref) => FromReference(_ref);

        // TODO - deprecate?
        protected virtual void FromReference(IJSInProcessObjectReference _ref) {
            if (IsWrapperDisposed) throw new Exception("IJSObject.FromReference error: IJSObject object already disposed.");
            if (JSRef != null) throw new Exception("IJSObject.FromReference error: _ref object already set.");
            JSRef = _ref;
        }
        protected virtual void LosingReference() {

        }
        protected void ReplaceReference(IJSInProcessObjectReference _ref) {
            if (IsWrapperDisposed) throw new Exception("IJSObject.FromReference error: IJSObject object already disposed.");
            if (JSRef != null) LosingReference();
            JSRef?.Dispose();
            JSRef = null;
            FromReference(_ref);
        }

        public T JSRefMove<T>() where T : JSObject {
            if (JSRef == null) throw new Exception("JSRefMove failed. Reference not set.");
            var _ref = JSRef;
            DisposeExceptRef();
            return (T)Activator.CreateInstance(typeof(T), _ref);
        }
        public IJSInProcessObjectReference? JSRefMove() {
            var _ref = JSRef;
            DisposeExceptRef();
            return _ref;
        }
        public T JSRefCopy<T>() where T : JSObject => JS.ReturnMe<T>(this);
        public IJSInProcessObjectReference JSRefCopy() => JS.ReturnMe<IJSInProcessObjectReference>(this);

        public void DisposeExceptRef() {
            if (JSRef != null) LosingReference();
            JSRef = null;
            Dispose();
        }
        protected virtual void Dispose(bool disposing) {
            if (IsWrapperDisposed) return;
            IsWrapperDisposed = true;
            if (disposing) {
                // managed assets
                if (JSRef != null) LosingReference();
            }
            JSRef?.Dispose();
            JSRef = null;
        }
        public virtual void Dispose() {
            if (IsWrapperDisposed) return;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public static bool UndisposedHandleVerboseMode { get; set; } = true;
        ~JSObject() {
            if (UndisposedHandleVerboseMode) {
                var thisType = this.GetType();
                var refDispsoed = JSRef == null;
                if (!refDispsoed) {
                    Console.WriteLine($"DEBUG WARNING: JSObject JSDebugName[{JSDebugName}] was not Disposed properly: {JS.GlobalThisTypeName} {thisType.Name} - {thisType.FullName}");
                }
            }
            Dispose(false);
        }

        protected static void DisposeAndNull(ref IDisposable? disposable) {
            disposable?.Dispose();
            disposable = null;
        }
        [JsonIgnore]
        public string JSDebugName { get; set; } = "";
        public static IReadOnlyCollection<Type> TransferableTypes { get; } = new List<Type> {
            typeof(ArrayBuffer),
            typeof(MessagePort),
            typeof(ReadableStream),
            typeof(WritableStream),
            typeof(TransformStream),
            typeof(AudioData),
            typeof(ImageBitmap),
            typeof(VideoFrame),
            typeof(OffscreenCanvas),
            typeof(RTCDataChannel),
        }.AsReadOnly();
    }
}