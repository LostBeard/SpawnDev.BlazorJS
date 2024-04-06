using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The IDBVersionChangeEvent interface of the IndexedDB API indicates that the version of the database has changed, as the result of an onupgradeneeded event handler function.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBVersionChangeEvent
    /// </summary>
    public class IDBVersionChangeEvent : Event<IDBOpenDBRequest>
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBVersionChangeEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The oldVersion read-only property of the IDBVersionChangeEvent interface returns the old version number of the database.<br />
        /// A number containing a 64-bit integer.
        /// </summary>
        public long OldVersion => JSRef.Get<long>("oldVersion");
        /// <summary>
        /// The newVersion read-only property of the IDBVersionChangeEvent interface returns the new version number of the database.<br />
        /// A number that is a 64-bit integer or null if the database is being deleted.
        /// </summary>
        public long? NewVersion => JSRef.Get<long?>("newVersion");
    }
}
