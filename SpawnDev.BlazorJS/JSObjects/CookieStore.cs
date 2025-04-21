using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CookieStore interface of the Cookie Store API provides methods for getting and setting cookies asynchronously from either a page or a service worker.<br/>
    /// The CookieStore is accessed via attributes in the global scope in a Window or ServiceWorkerGlobalScope context. Therefore there is no constructor.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CookieStore
    /// </summary>
    public class CookieStore : EventTarget
    {
        /// <inheritdoc/>
        public CookieStore(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The delete() method deletes a cookie with the given name or options object. It returns a Promise that resolves when the deletion completes or if no cookies are matched.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task Delete(string name) => JSRef!.CallVoidAsync("delete", name);
        /// <summary>
        /// The delete() method deletes a cookie with the given name or options object. It returns a Promise that resolves when the deletion completes or if no cookies are matched.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task Delete(CookieSelectOptions options) => JSRef!.CallVoidAsync("delete", options);
        /// <summary>
        /// The get() method gets a single cookie with the given name or options object. It returns a Promise that resolves with details of a single cookie.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<Cookie?> Get(string name) => JSRef!.CallAsync<Cookie?>("get", name);
        /// <summary>
        /// The get() method gets a single cookie with the given name or options object. It returns a Promise that resolves with details of a single cookie.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<Cookie?> Get(CookieSelectOptions options) => JSRef!.CallAsync<Cookie?>("get", options);
        /// <summary>
        /// The getAll() method gets all matching cookies. It returns a Promise that resolves with a list of cookies.
        /// </summary>
        /// <returns></returns>
        public Task<Cookie[]> GetAll() => JSRef!.CallAsync<Cookie[]>("getAll");
        /// <summary>
        /// The getAll() method gets all matching cookies. It returns a Promise that resolves with a list of cookies.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<Cookie[]> GetAll(string name) => JSRef!.CallAsync<Cookie[]>("getAll", name);
        /// <summary>
        /// The getAll() method gets all matching cookies. It returns a Promise that resolves with a list of cookies.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<Cookie[]> GetAll(CookieSelectOptions options) => JSRef!.CallAsync<Cookie[]>("getAll", options);
        /// <summary>
        /// The set() method sets a cookie with the given name and value or options object. It returns a Promise that resolves when the cookie is set.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task Set(string name, string value) => JSRef!.CallVoidAsync("set", name, value);
        /// <summary>
        /// The set() method sets a cookie with the given name and value or options object. It returns a Promise that resolves when the cookie is set.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task Set(Cookie options) => JSRef!.CallVoidAsync("set", options);
        /// <summary>
        /// The change event fires when a change is made to any cookie.
        /// </summary>
        public ActionEvent<CookieChangeEvent> OnChange { get => new ActionEvent<CookieChangeEvent>("change", AddEventListener, RemoveEventListener); set { } }
    }
}
