using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The History interface allows manipulation of the browser session history, that is the pages visited in the tab or frame that the current page is loaded in.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/History
    /// </summary>
    public class History : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public History(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an Integer representing the number of elements in the session history, including the currently loaded page. For example, for a page loaded in a new tab this property returns 1
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// Allows web applications to explicitly set default scroll restoration behavior on history navigation. This property can be either auto or manual
        /// </summary>
        public string ScrollRestoration => JSRef!.Get<string>("scrollRestoration");
        /// <summary>
        /// Returns an any value representing the state at the top of the history stack. This is a way to look at the state without having to wait for a popstate event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T StateAs<T>() => JSRef!.Get<T>("state");
        /// <summary>
        /// Causes the browser to move back one page in the session history.
        /// It has the same effect as calling history.go(-1). If there is no previous page, this method call does nothing.
        /// </summary>
        public void Back() => JSRef!.CallVoid("back");
        /// <summary>
        /// Causes the browser to move forward one page in the session history.
        /// It has the same effect as calling history.go(1).
        /// </summary>
        public void Forward() => JSRef!.CallVoid("forward");
        /// <summary>
        /// Loads a page from the session history, identified by its relative location to the current page, for example -1 for the previous page or 1 for the next page.
        /// </summary>
        /// <param name="delta"></param>
        public void Go(int delta = 0) => JSRef!.CallVoid("go", delta);
        /// <summary>
        /// Pushes the given data onto the session history stack with the specified title (and, if provided, URL).
        /// </summary>
        /// <param name="state"></param>
        /// <param name="unused"></param>
        public void PushState(object state, string unused) => JSRef!.CallVoid("pushState", state, unused);
        /// <summary>
        /// Pushes the given data onto the session history stack with the specified title (and, if provided, URL).
        /// </summary>
        /// <param name="state"></param>
        /// <param name="unused"></param>
        /// <param name="url"></param>
        public void PushState(object state, string unused, string url) => JSRef!.CallVoid("pushState", state, unused, url);
        /// <summary>
        /// Updates the most recent entry on the history stack to have the specified data, title, and, if provided, URL.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="unused"></param>
        public void ReplaceState(object state, string unused) => JSRef!.CallVoid("replaceState", state, unused);
        /// <summary>
        /// Updates the most recent entry on the history stack to have the specified data, title, and, if provided, URL.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="unused"></param>
        /// <param name="url"></param>
        public void ReplaceState(object state, string unused, string url) => JSRef!.CallVoid("replaceState", state, unused, url);
    }
}
