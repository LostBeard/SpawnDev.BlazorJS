﻿using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    public class JSObject<T> : JSObject where T : JSObject
    {
        private static Lazy<T> _Undefined = new Lazy<T>(() => (T)Activator.CreateInstance(typeof(T), JSObject.UndefinedRef));
        public static T Undefined => _Undefined.Value;
        public JSObject(IJSInProcessObjectReference _ref) : base(_ref) { }
    }

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
        [JsonIgnore]
        public IJSInProcessObjectReference? JSRef { get; private set; }
        [JsonIgnore]
        public bool IsWrapperDisposed { get; private set; } = false;
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
        public T JSRefMove<T>() where T : JSObject
        {
            if (JSRef == null) throw new Exception("JSRefMove failed. Reference not set.");
            var _ref = JSRef;
            JSRef = null;
            return (T)Activator.CreateInstance(typeof(T), _ref)!;
        }
        public IJSInProcessObjectReference? JSRefMove()
        {
            var _ref = JSRef;
            JSRef = null;
            return _ref;
        }
        public T JSRefCopy<T>() where T : JSObject => JSInterop.ReturnMe<T>(this);
        public IJSInProcessObjectReference JSRefCopy() => JSInterop.ReturnMe<IJSInProcessObjectReference>(this);
        protected virtual void Dispose(bool disposing)
        {
            if (IsWrapperDisposed) return;
            IsWrapperDisposed = true;
            JSRef?.Dispose();
            JSRef = null;
            IsJSRefUndefined = false;
        }   
        public void Dispose()
        {
            if (IsWrapperDisposed) return;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
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