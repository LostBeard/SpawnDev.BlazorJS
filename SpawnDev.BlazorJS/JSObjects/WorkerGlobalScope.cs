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
        /// The importScripts() method of the WorkerGlobalScope interface synchronously imports one or more scripts into the worker's scope.
        /// </summary>
        /// <param name="scripts"></param>
        public void ImportScripts(params string[] scripts) => JSRef!.CallApplyVoid("importScripts", scripts);
        /// <summary>
        /// Calls fetch
        /// </summary>
        public Task<Response> Fetch(Request resource) => JS.CallAsync<Response>("fetch", resource);
        /// <summary>
        /// Calls fetch
        /// </summary>
        public Task<Response> Fetch(string resource) => JS.CallAsync<Response>("fetch", resource);
        /// <summary>
        /// Calls fetch
        /// </summary>
        public Task<Response> Fetch(string resource, FetchOptions options) => JS.CallAsync<Response>("fetch", resource, options);
        /// <summary>
        /// The structuredClone() method of the Window interface creates a deep clone of a given value using the structured clone algorithm.<br/>
        /// The method also allows transferable objects in the original value to be transferred rather than cloned to the new object. Transferred objects are detached from the original object and attached to the new object; they are no longer accessible in the original object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The object to be cloned. This can be any structured-cloneable type.</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public T StructuredClone<T>(object value, StructuredCloneOptions options) => JSRef!.Call<T>("structuredClone", value, options);
        /// <summary>
        /// The structuredClone() method of the Window interface creates a deep clone of a given value using the structured clone algorithm.<br/>
        /// The method also allows transferable objects in the original value to be transferred rather than cloned to the new object. Transferred objects are detached from the original object and attached to the new object; they are no longer accessible in the original object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The object to be cloned. This can be any structured-cloneable type.</param>
        /// <returns></returns>
        public T StructuredClone<T>(object value) => JSRef!.Call<T>("structuredClone", value);
        /// <summary>
        /// Schedules a function to execute in a given amount of time.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public long SetTimeout(Callback callback, double delay) => JSRef!.Call<long>("setTimeout", callback, delay);
        /// <summary>
        /// Schedules a function to execute in a given amount of time.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public long SetTimeout(Action callback, double delay) => JSRef!.Call<long>("setTimeout", ActionCallback.CreateOne(callback), delay);
        /// <summary>
        /// Schedules a function to execute in a given amount of time.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public long SetTimeout(Func<Task> callback, double delay) => JSRef!.Call<long>("setTimeout", Callback.CreateOne(callback), delay);
        /// <summary>
        /// The setInterval() method of the Window interface repeatedly calls a function or executes a code snippet, with a fixed time delay between each call.<br/>
        /// This method returns an interval ID which uniquely identifies the interval, so you can remove it later by calling clearInterval().
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public long SetInterval(Callback callback, double delay) => JSRef!.Call<long>("setInterval", callback, delay);
        /// <summary>
        /// Cancels the delayed execution set using setInterval().
        /// </summary>
        /// <param name="requestId"></param>
        public void ClearInterval(long requestId) => JSRef!.CallVoid("clearInterval", requestId);
        /// <summary>
        /// Cancels the delayed execution set using setTimeout().
        /// </summary>
        /// <param name="requestId"></param>
        public void ClearTimeout(long requestId) => JSRef!.CallVoid("clearTimeout", requestId);
        /// <summary>
        /// The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap.
        /// </summary>
        /// <param name="image">An image source</param>
        /// <param name="sx">The x coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted.</param>
        /// <param name="sy">The y coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted.</param>
        /// <param name="sw">The width of the rectangle from which the ImageBitmap will be extracted. This value can be negative.</param>
        /// <param name="sh">The height of the rectangle from which the ImageBitmap will be extracted. This value can be negative.</param>
        /// <param name="options">An object that sets options for the image's extraction.</param>
        /// <returns>A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle.</returns>
        public Task<ImageBitmap> CreateImageBitmap(ImageBitmapSource image, int sx, int sy, int sw, int sh, ImageBitmapOptions options) => JSRef!.CallAsync<ImageBitmap>("createImageBitmap", image, sx, sy, sw, sh, options);
        /// <summary>
        /// The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap.
        /// </summary>
        /// <param name="image">An image source</param>
        /// <param name="options">An object that sets options for the image's extraction.</param>
        /// <returns>A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle.</returns>
        public Task<ImageBitmap> CreateImageBitmap(ImageBitmapSource image, ImageBitmapOptions options) => JSRef!.CallAsync<ImageBitmap>("createImageBitmap", image, options);
        /// <summary>
        /// The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap.
        /// </summary>
        /// <param name="image">An image source</param>
        /// <returns>A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle.</returns>
        public Task<ImageBitmap> CreateImageBitmap(ImageBitmapSource image) => JSRef!.CallAsync<ImageBitmap>("createImageBitmap", image);
        /// <summary>
        /// The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap.
        /// </summary>
        /// <param name="image">An image source</param>
        /// <param name="sx">The x coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted.</param>
        /// <param name="sy">The y coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted.</param>
        /// <param name="sw">The width of the rectangle from which the ImageBitmap will be extracted. This value can be negative.</param>
        /// <param name="sh">The height of the rectangle from which the ImageBitmap will be extracted. This value can be negative.</param>
        /// <returns>A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle.</returns>
        public Task<ImageBitmap> CreateImageBitmap(ImageBitmapSource image, int sx, int sy, int sw, int sh) => JSRef!.CallAsync<ImageBitmap>("createImageBitmap", image, sx, sy, sw, sh);
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
        /// Returns true if the website is in a cross-origin isolation state.<br/>
        /// Returns null if the browser does not support cross-origin isolation detection.
        /// </summary>
        public bool? CrossOriginIsolated => JSRef!.Get<bool?>("crossOriginIsolated");
        /// <summary>
        /// Returns the browser crypto object.
        /// </summary>
        public Crypto Crypto => JSRef!.Get<Crypto>("crypto");
        /// <summary>
        /// The global performance property returns a Performance object, which can be used to gather performance information about the context it is called in (window or worker).
        /// </summary>
        public Performance Performance => JSRef!.Get<Performance>("performance");
        /// <summary>
        /// Returns a reference to the WorkerGlobalScope itself. Most of the time it is a specific scope like DedicatedWorkerGlobalScope, SharedWorkerGlobalScope or ServiceWorkerGlobalScope.
        /// </summary>
        public virtual WorkerGlobalScope Self => JSRef!.Get<WorkerGlobalScope>("self");
        /// <summary>
        /// Fired when an error occurred.
        /// </summary>
        public ActionEvent<ErrorEvent> OnError { get => new ActionEvent<ErrorEvent>("error", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired at the global/worker scope object when the user's preferred languages change.
        /// </summary>
        public ActionEvent<Event> OnLanguageChange { get => new ActionEvent<Event>("languagechange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the browser has lost access to the network and the value of navigator.onLine switched to false.
        /// </summary>
        public ActionEvent<Event> OnOffline { get => new ActionEvent<Event>("offline", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the browser has gained access to the network and the value of navigator.onLine switched to true.
        /// </summary>
        public ActionEvent<Event> OnOnline { get => new ActionEvent<Event>("online", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired on handled Promise rejection events.
        /// </summary>
        public ActionEvent<PromiseRejectionEvent> OnRejectionHandled { get => new ActionEvent<PromiseRejectionEvent>("rejectionhandled", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a Content Security Policy is violated.
        /// </summary>
        public ActionEvent<SecurityPolicyViolationEvent> OnSecurityPolicyViolation { get => new ActionEvent<SecurityPolicyViolationEvent>("securitypolicyviolation", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired on unhandled Promise rejection events.
        /// </summary>
        public ActionEvent<PromiseRejectionEvent> OnUnhandledRejection { get => new ActionEvent<PromiseRejectionEvent>("unhandledrejection", AddEventListener, RemoveEventListener); set { } }
    }
}
