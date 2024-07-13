using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
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
        public void Back() => JSRef!.CallVoid("back");
        public void Forward() => JSRef!.CallVoid("forward");
        public void Go(int delta = 0) => JSRef!.CallVoid("back", delta);
        public void PushState(object state, string unused) => JSRef!.CallVoid("pushState", state, unused);
        public void PushState(object state, string unused, string url) => JSRef!.CallVoid("pushState", state, unused, url);
        public void ReplaceState(object state, string unused) => JSRef!.CallVoid("replaceState", state, unused);
        public void ReplaceState(object state, string unused, string url) => JSRef!.CallVoid("replaceState", state, unused, url);
    }
}
