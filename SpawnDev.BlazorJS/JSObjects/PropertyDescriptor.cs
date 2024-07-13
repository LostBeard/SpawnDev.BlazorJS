using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://javascript.info/property-descriptors
    /// </summary>
    public class PropertyDescriptor : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PropertyDescriptor(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Function? Get => JSRef!.Get<Function?>("get");
        public Function? Set => JSRef!.Get<Function?>("set");
        public bool HasGetter => !JSRef.PropertyIsUndefined("get");
        public bool HasSetter => !JSRef.PropertyIsUndefined("set");
        public bool HasValueProperty => !JSRef.PropertyIsUndefined("value");
        public bool CanBeRead => HasGetter || HasValueProperty;
        public bool CanBeWritten => Writable == true && (HasSetter || HasValueProperty);
        /// <summary>
        /// if true, the value can be changed, otherwise it’s read-only.
        /// </summary>
        public bool? Writable => JSRef!.Get<bool?>("writable");
        /// <summary>
        /// if true, then listed in loops, otherwise not listed.
        /// </summary>
        public bool? Enumerable => JSRef!.Get<bool?>("enumerable");
        /// <summary>
        ///  if true, the property can be deleted and these attributes can be modified, otherwise not.
        /// </summary>
        public bool? Configurable => JSRef!.Get<bool?>("configurable");
    }
}
