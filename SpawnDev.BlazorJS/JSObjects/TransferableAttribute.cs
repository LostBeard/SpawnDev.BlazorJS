using System.Collections.Concurrent;
using System.Reflection;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Indicates the class type is a transferable object.<br/>
    /// Transferable objects are objects that own resources that can be transferred from one context to another,<br/>
    /// ensuring that the resources are only available in one context at a time. Following a transfer, the original <br/>
    /// object is no longer usable; it no longer points to the transferred resource, and any attempt to read or write<br/>
    /// the object will throw an exception.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Web_Workers_API/Transferable_objects
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class TransferableAttribute : Attribute
    {
        /// <summary>
        /// If true, an object of this type must be transferred when used with PostMessage (Ex. OffscreenCanvas)
        /// </summary>
        public bool TransferRequired { get; init; }
        /// <summary>
        /// Cache of TransferableAttribute instances by Type
        /// </summary>
        private static ConcurrentDictionary<Type, TransferableAttribute?> Cache = new();
        /// <summary>
        /// Retrieves the first TransferableAttribute applied to the specified type, if present.
        /// </summary>
        /// <remarks>This method uses a cache to improve performance on repeated calls for the same type.
        /// Only the first occurrence of the TransferableAttribute is returned if multiple are present.</remarks>
        /// <param name="type">The type to inspect for the TransferableAttribute.</param>
        /// <returns>A TransferableAttribute instance if the specified type is decorated with the attribute; otherwise, null.</returns>
        public static TransferableAttribute? GetTransferable(Type type)
        {
            if (type == null || !type.IsClass) return null;
            if (!Cache.TryGetValue(type, out var attr))
            {
                attr = type.GetCustomAttribute<TransferableAttribute>(true);
                Cache.TryAdd(type, attr);
            }
            return attr;
        }
        /// <summary>
        /// Retrieves the first TransferableAttribute applied to the specified type, if present.
        /// </summary>
        /// <remarks>This method uses a cache to improve performance on repeated calls for the same type.
        /// Only the first occurrence of the TransferableAttribute is returned if multiple are present.</remarks>
        /// <typeparam name="T">The type to inspect for the TransferableAttribute.</typeparam>
        /// <returns>A TransferableAttribute instance if the specified type is decorated with the attribute; otherwise, null.</returns>
        public static TransferableAttribute? GetTransferable<T>() => GetTransferable(typeof(T));
        /// <summary>
        /// Determines whether the specified type is marked as transferable.
        /// </summary>
        /// <param name="type">The type to check for transferability.</param>
        /// <returns>true if the specified type is considered transferable; otherwise, false.</returns>
        public static bool IsTransferable(Type type) => GetTransferable(type) != null;
        /// <summary>
        /// Determines whether the specified type is marked as transferable.
        /// </summary>
        /// <typeparam name="T">The type to check for transferability.</typeparam>
        /// <returns>true if the specified type is considered transferable; otherwise, false.</returns>
        public static bool IsTransferable<T>() => GetTransferable(typeof(T)) != null;
    }
}
