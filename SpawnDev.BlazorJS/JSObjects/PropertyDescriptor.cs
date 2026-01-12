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
        /// <summary>
        /// A function which serves as a getter for the property, or undefined if there is no getter. When the property is accessed, this function is called without arguments and with this set to the object through which the property is accessed (this may not be the object on which the property is defined due to inheritance). The return value will be used as the value of the property.
        /// </summary>
        public Function? Get => JSRef!.Get<Function?>("get");
        /// <summary>
        /// A function which serves as a setter for the property, or undefined if there is no setter. When the property is assigned, this function is called with one argument (the value being assigned to the property) and with this set to the object through which the property is assigned.
        /// </summary>
        public Function? Set => JSRef!.Get<Function?>("set");
        /// <summary>
        /// Returns true if the property has a getter.
        /// </summary>
        public bool HasGetter => !JSRef!.IsUndefined("get");
        /// <summary>
        /// Returns true if the property has a setter.
        /// </summary>
        public bool HasSetter => !JSRef!.IsUndefined("set");
        /// <summary>
        /// Returns true if the property has a value property.
        /// </summary>
        public bool HasValueProperty => !JSRef!.IsUndefined("value");
        /// <summary>
        /// Returns true if the property can be read.
        /// </summary>
        public bool CanBeRead => HasGetter || HasValueProperty;
        /// <summary>
        /// Returns true if the property can be written.
        /// </summary>
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
