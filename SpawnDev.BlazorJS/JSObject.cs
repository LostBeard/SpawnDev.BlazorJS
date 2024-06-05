using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// JSObject's wrap a IJSInProcessObjectReference
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JSObject<T> : JSObject where T : JSObject
    {
        private static Lazy<T> _Undefined = new Lazy<T>(() => (T)Activator.CreateInstance(typeof(T), JSObject.UndefinedRef));
        public static T Undefined => _Undefined.Value;
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public JSObject(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
    /// <summary>
    /// JSObject's wrap a IJSInProcessObjectReference
    /// </summary>
    public class JSObject : IDisposable
    {
        /// <summary>
        /// This event is for diagnostics purposes and will liekly be removed in future releases
        /// </summary>
        public static Action<JSObject>? OnJSObjectCreated { get; set; }
        public static bool UndisposedHandleVerboseMode { get; set; } = false;
        protected static BlazorJSRuntime JS => BlazorJSRuntime.JS;
        public static IJSInProcessObjectReference? NullRef { get; } = null;
        public static JSInProcessObjectReferenceUndefined? UndefinedRef { get; } = new JSInProcessObjectReferenceUndefined();
        [JsonIgnore]
        public bool IsJSRefUndefined { get; private set; } = false;
        /// <summary>
        /// JSRef is the underlying IJSInProcessObjectReference
        /// </summary>
        [JsonIgnore]
        public IJSInProcessObjectReference? JSRef { get; private set; }
        /// <summary>
        /// Returns true if the underlying JSRef IJSInProcessObjectReference object has been disposed
        /// </summary>
        [JsonIgnore]
        public bool IsWrapperDisposed { get; private set; } = false;
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public JSObject(IJSInProcessObjectReference _ref) => FromReference(_ref);
        // some constructors of types that inherit from JSObject will pass NullRef to the base constructor and then create the JSRef instance in their constructor and then set it with FromReference
        /// <summary>
        /// This virtual method is called when JSRef is going to be set. base.FromReference(_ref) must be called. 
        /// This can be used to allow custom post deserialization initialization such as attaching to events.
        /// </summary>
        /// <param name="_ref"></param>
        /// <exception cref="Exception"></exception>
        protected virtual void FromReference(IJSInProcessObjectReference _ref)
        {
            if (IsWrapperDisposed) throw new Exception("IJSObject.FromReference error: IJSObject object already disposed.");
            if (JSRef != null) throw new Exception("IJSObject.FromReference error: _ref object already set.");
            IsJSRefUndefined = _ref != null && typeof(JSInProcessObjectReferenceUndefined).IsAssignableFrom(_ref.GetType());
            JSRef = _ref;
            if (JSRef != null) OnJSObjectCreated?.Invoke(this);
        }
        /// <summary>
        /// Returns a new JSObject of type T using this JSObject's IJSInProcessObjectReference, and setting this JSObject's JSRef value to null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public T JSRefMove<T>() where T : JSObject
        {
            if (JSRef == null) throw new Exception("JSRefMove failed. Reference not set.");
            var _ref = JSRef;
            JSRef = null;
            Dispose();
            return (T)Activator.CreateInstance(typeof(T), _ref)!;
        }
        /// <summary>
        /// Returns the JSRef IJSInProcessObjectReference and unsets the JSRef for this JSObject
        /// </summary>
        /// <returns></returns>
        public IJSInProcessObjectReference? JSRefMove()
        {
            var _ref = JSRef;
            JSRef = null;
            return _ref;
        }
        /// <summary>
        /// Returns this JSObject as type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T</returns>
        public T JSRefAs<T>() => JSInterop.ReturnMe<T>(this);
        /// <summary>
        /// Returns a new JSObject of type T using a copy of this JSObject's IJSInProcessObjectReference
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T</returns>
        public T JSRefCopy<T>() where T : JSObject => JSInterop.ReturnMe<T>(this);
        /// <summary>
        /// Returns a copy of this JSObject's JSRef, a IJSInProcessObjectReference
        /// </summary>
        /// <returns>IJSInProcessObjectReference</returns>
        public IJSInProcessObjectReference JSRefCopy() => JSInterop.ReturnMe<IJSInProcessObjectReference>(this);
        /// <summary>
        /// Dispose resources
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (IsWrapperDisposed) return;
            IsWrapperDisposed = true;
            JSRef?.Dispose();
            JSRef = null;
            IsJSRefUndefined = false;
        }   
        /// <summary>
        /// Release the IJSInProcessObjectReference, and other resources
        /// </summary>
        public void Dispose()
        {
            if (IsWrapperDisposed) return;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Finalizer
        /// </summary>
        ~JSObject()
        {
            if (UndisposedHandleVerboseMode)
            {
                if (JSRef != null)
                {
                    var thisType = this.GetType();
                    Console.WriteLine($"DEBUG WARNING: JSObject JSDebugName was not Disposed properly: {JS.GlobalThisTypeName} {thisType.Name} - {thisType.FullName}");
                }
            }
            Dispose(false);
        }
    }
}