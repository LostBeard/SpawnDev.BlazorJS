using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public abstract class WorkerGlobalScope : EventTarget {
        public WorkerGlobalScope(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void ImportScripts(params string[] scripts) => JSRef.CallApplyVoid("importScripts", scripts);
        /// <summary>
        /// Returns the CacheStorage object associated with the current context. This object enables functionality such as storing assets for offline use, and generating custom responses to requests
        /// </summary>
        public CacheStorage Caches => JSRef.Get<CacheStorage>("caches");
        /// <summary>
        /// Provides a mechanism for applications to asynchronously access capabilities of indexed databases; returns an IDBFactory object.
        /// </summary>
        public IDBFactory IndexedDB => JSRef.Get<IDBFactory>("indexedDB");
        /// <summary>
        /// Returns a boolean indicating whether the current context is secure (true) or not (false)
        /// </summary>
        public bool IsSecureContext => JSRef.Get<bool>("IsSecureContext");
        /// <summary>
        /// Returns the WorkerLocation associated with the worker. It is a specific location object, mostly a subset of the Location for browsing scopes, but adapted to workers
        /// </summary>
        public WorkerLocation Location => JSRef.Get<WorkerLocation>("location");
        /// <summary>
        /// Returns the WorkerNavigator associated with the worker. It is a specific navigator object, mostly a subset of the Navigator for browsing scopes, but adapted to workers.
        /// </summary>
        public WorkerNavigator Navigator => JSRef.Get<WorkerNavigator>("navigator");
        /// <summary>
        /// Returns the global object's origin, serialized as a string.
        /// </summary>
        public string Origin => JSRef.Get<string>("origin");
        // TODO 
        // public Performance Performance => JSRef.Get<Performance>("performance");
        // public Scheduler Scheduler => JSRef.Get<Scheduler>("scheduler");
        public virtual WorkerGlobalScope Self => JSRef.Get<WorkerGlobalScope>("self");
    }
}
