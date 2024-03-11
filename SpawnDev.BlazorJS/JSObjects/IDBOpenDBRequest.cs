using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The IDBOpenDBRequest interface of the IndexedDB API provides access to the results of requests to open or delete databases (performed using IDBFactory.open and IDBFactory.deleteDatabase), using specific event handler attributes.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBOpenDBRequest
    /// </summary>
    public class IDBOpenDBRequest : IDBRequest<IDBDatabase>
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBOpenDBRequest(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The IDBVersionChangeEvent interface of the IndexedDB API indicates that the version of the database has changed, as the result of an onupgradeneeded event handler function.
        /// </summary>
        public JSEventCallback<IDBVersionChangeEvent> OnBlocked { get => new JSEventCallback<IDBVersionChangeEvent>("blocked", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The upgradeneeded event is fired when an attempt was made to open a database with a version number higher than its current version.
        /// </summary>
        public JSEventCallback<IDBVersionChangeEvent> OnUpgradeNeeded { get => new JSEventCallback<IDBVersionChangeEvent>("upgradeneeded", AddEventListener, RemoveEventListener); set { } }
    }
}
