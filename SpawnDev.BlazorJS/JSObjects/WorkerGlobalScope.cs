using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WorkerGlobalScope interface of the Web Workers API is an interface representing the scope of any worker. Workers have no browsing context; this scope contains the information usually conveyed by Window objects — in this case event handlers, the console or the associated WorkerNavigator object. Each WorkerGlobalScope has its own event loop.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WorkerGlobalScope
    /// </summary>
    public abstract class WorkerGlobalScope : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WorkerGlobalScope(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scripts"></param>
        public void ImportScripts(params string[] scripts) => JSRef!.CallApplyVoid("importScripts", scripts);
        /// <summary>
        /// Returns the CacheStorage object associated with the current context. This object enables functionality such as storing assets for offline use, and generating custom responses to requests
        /// </summary>
        public CacheStorage Caches => JSRef!.Get<CacheStorage>("caches");
        /// <summary>
        /// Provides a mechanism for applications to asynchronously access capabilities of indexed databases; returns an IDBFactory object.
        /// </summary>
        public IDBFactory IndexedDB => JSRef!.Get<IDBFactory>("indexedDB");
        /// <summary>
        /// Returns a boolean indicating whether the current context is secure (true) or not (false)
        /// </summary>
        public bool IsSecureContext => JSRef!.Get<bool>("IsSecureContext");
        /// <summary>
        /// Returns the WorkerLocation associated with the worker. It is a specific location object, mostly a subset of the Location for browsing scopes, but adapted to workers
        /// </summary>
        public WorkerLocation Location => JSRef!.Get<WorkerLocation>("location");
        /// <summary>
        /// Returns the WorkerNavigator associated with the worker. It is a specific navigator object, mostly a subset of the Navigator for browsing scopes, but adapted to workers.
        /// </summary>
        public WorkerNavigator Navigator => JSRef!.Get<WorkerNavigator>("navigator");
        /// <summary>
        /// Returns the global object's origin, serialized as a string.
        /// </summary>
        public string Origin => JSRef!.Get<string>("origin");
        /// <summary>
        /// Returns a boolean value that indicates whether the website is in a cross-origin isolation state.
        /// </summary>
        public bool CrossOriginIsolated => JSRef!.Get<bool>("crossOriginIsolated");
        /// <summary>
        /// Returns the browser crypto object.
        /// </summary>
        public Crypto Crypto => JSRef!.Get<Crypto>("crypto");
        /// <summary>
        /// The global performance property returns a Performance object, which can be used to gather performance information about the context it is called in (window or worker).
        /// </summary>
        public Performance Performance => JSRef!.Get<Performance>("performance");
        public virtual WorkerGlobalScope Self => JSRef!.Get<WorkerGlobalScope>("self");
    }
}
