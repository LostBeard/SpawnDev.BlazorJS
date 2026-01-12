using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The StorageEvent interface is implemented by the storage event, which is sent to a window when a storage area it has access to is changed within the context of another document.
    /// </summary>
    public class StorageEvent
        : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public StorageEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a string representing the key of the storage item which was changed. The key property is null when the change is caused by the storage clear() method.
        /// </summary>
        public string Key => JSRef!.Get<string>("key");
        /// <summary>
        /// Returns a string representing the old value of the key which was changed. This is null when a new item is added.
        /// </summary>
        public string OldValue => JSRef!.Get<string>("oldValue");
        /// <summary>
        /// Returns a string representing the new value of the key which was changed. This value is null when an item is removed.
        /// </summary>
        public string NewValue => JSRef!.Get<string>("newValue");
        /// <summary>
        /// Returns a string representing the URL of the document whose key was changed.
        /// </summary>
        public string Url => JSRef!.Get<string>("url");
        /// <summary>
        /// Returns a Storage object representing the storage area that was affected.
        /// </summary>
        public Storage StorageArea => JSRef!.Get<Storage>("storageArea");
    }
}
