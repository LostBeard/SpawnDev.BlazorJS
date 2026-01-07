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
        private static Lazy<T> _Undefined = new Lazy<T>(() => (T)Activator.CreateInstance(typeof(T), JSObject.UndefinedRef)!);
        /// <summary>
        /// Static instance of Undefined JSObject of type T
        /// </summary>
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
        /// This event is for diagnostics purposes and will likely be removed in future releases
        /// </summary>
#if DEBUG
        public static Action<JSObject>? OnJSObjectCreated { get; set; }
        public static bool UndisposedHandleVerboseMode { get; set; } = false;
#endif
        protected static BlazorJSRuntime JS => BlazorJSRuntime.JS;
        /// <summary>
        /// Static instance of JSInProcessObjectReferenceUndefined
        /// </summary>
        public static JSInProcessObjectReferenceUndefined? UndefinedRef { get; } = new JSInProcessObjectReferenceUndefined();
        /// <summary>
        /// Returns true if the underlying JSRef is a JSInProcessObjectReferenceUndefined
        /// </summary>
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
#if DEBUG
            if (JSRef != null) OnJSObjectCreated?.Invoke(this);
#endif
        }
        /// <summary>
        /// Returns this object as type T and disposes this wrapper.<br/>
        /// If type T is a JSObject the JSRef is moved instead of copied.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public T JSRefMove<T>()
        {
            if (IsWrapperDisposed) throw new ObjectDisposedException(nameof(JSRef));
            var _ref = JSRef;
            JSRef = null;
            T ret;
            if (typeof(JSObject).IsAssignableFrom(typeof(T)))
            {
                ret = (T)Activator.CreateInstance(typeof(T), _ref)!;
            }
            else
            {
                ret = _ref!.As<T>();
            }
            Dispose();
            return ret;
        }
        /// <summary>
        /// Compare this JSObject to obj2 using JavaScript equality<br/>
        /// Returns full ? this === obj2 : this == obj2
        /// </summary>
        public bool JSEquals(object? obj2, bool full = false)
        {
            if (obj2 == null) return false;
            return JSRef!.JSEquals(obj2, full);
        }
        /// <summary>
        /// Returns this object's IJSInProcessObjectReference and disposes this wrapper.
        /// </summary>
        /// <returns></returns>
        public IJSInProcessObjectReference? JSRefMove()
        {
            if (IsWrapperDisposed) throw new ObjectDisposedException(nameof(JSRef));
            var _ref = JSRef;
            JSRef = null;
            Dispose();
            return _ref;
        }
        /// <summary>
        /// If this object's constructor.name == constructorName, sets value to the value of this object as type T and returns true, otherwise returns false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="constructorName">The constructor.name to test for</param>
        /// <param name="value">return value that will be set if the constructor.name matches</param>
        /// <param name="moveJSRef">If true, moves the JSRef (which disposes this wrapper) instead of copying it</param>
        /// <returns>true if the constructor.name matched</returns>
        /// <exception cref="ObjectDisposedException"></exception>
        public bool JSRefIs<T>(string constructorName, out T value, bool moveJSRef = false)
        {
            if (IsWrapperDisposed) throw new ObjectDisposedException(nameof(JSRef));
            if (JSRef?.ConstructorName() != constructorName)
            {
                value = default!;
                return false;
            }
            value = moveJSRef ? JSRefMove<T>() : JSRefCopy<T>();
            return true;
        }
        /// <summary>
        /// Returns true if the referenced JS object's constructor.name == constructorName
        /// </summary>
        /// <param name="constructorName"></param>
        /// <returns></returns>
        /// <exception cref="ObjectDisposedException"></exception>
        public bool JSRefIs(string constructorName)
        {
            if (IsWrapperDisposed) throw new ObjectDisposedException(nameof(JSRef));
            return JSRef?.ConstructorName() == constructorName;
        }
        /// <summary>
        /// Returns true if the referenced JS object's constructor.name == type(T).Name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool JSRefIs<T>() => JSRefIs(typeof(T).Name);
        /// <summary>
        /// If this object's constructor.name == constructorName, sets value to the value of this object as type T and returns true, otherwise returns false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">return value that will be set if the constructor.name matches</param>
        /// <param name="moveJSRef">If true, moves the JSRef (which disposes this wrapper) instead of copying it</param>
        /// <returns>true if the constructor.name matched</returns>
        public bool JSRefIs<T>(out T value, bool moveJSRef = false) => JSRefIs(typeof(T).Name, out value, moveJSRef);
        /// <summary>
        /// Returns this JSObject as type T<br/>
        /// - As of 2.3.8, this is a synonym for JSRefCopy&lt;T&gt;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T</returns>
        public T JSRefAs<T>()
        {
            if (IsWrapperDisposed) throw new ObjectDisposedException(nameof(JSRef));
            return JSRef!.As<T>();
        }
        /// <summary>
        /// Returns this JSObject as type T<br/>
        /// - As of 2.3.8, this is a synonym for JSRefAs&lt;T&gt;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T</returns>
        public T JSRefCopy<T>()
        {
            if (IsWrapperDisposed) throw new ObjectDisposedException(nameof(JSRef));
            return JSRef!.As<T>();
        }
        /// <summary>
        /// Returns a copy of this JSObject's JSRef, a IJSInProcessObjectReference
        /// </summary>
        /// <returns>IJSInProcessObjectReference</returns>
        public IJSInProcessObjectReference JSRefCopy()
        {
            if (IsWrapperDisposed) throw new ObjectDisposedException(nameof(JSRef));
            return JSRef!.As<IJSInProcessObjectReference>();
        }
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
#if DEBUG
            if (UndisposedHandleVerboseMode)
            {
                if (JSRef != null)
                {
                    var thisType = this.GetType();
                    Console.WriteLine($"DEBUG WARNING: JSObject JSDebugName was not Disposed properly: {JS.GlobalThisTypeName} {thisType.Name} - {thisType.FullName}");
                }
            }
#endif
            Dispose(false);
        }
    }
}