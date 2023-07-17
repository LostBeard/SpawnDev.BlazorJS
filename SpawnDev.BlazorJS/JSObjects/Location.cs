using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Location : JSObject
    {
        public Location(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string containing a '#' followed by the fragment identifier of the URL.
        /// </summary>
        public string Hash => JSRef.Get<string>("hash");
        /// <summary>
        /// A string containing the host, that is the hostname, a ':', and the port of the URL.
        /// </summary>
        public string Host => JSRef.Get<string>("host");
        /// <summary>
        /// A string containing the domain of the URL.
        /// </summary>
        public string HostName => JSRef.Get<string>("hostname");
        /// <summary>
        /// A stringifier that returns a string containing the entire URL. If changed, the associated document navigates to the new page. It can be set from a different origin than the associated document
        /// </summary>
        public string Href => JSRef.Get<string>("href");
        /// <summary>
        /// Returns a string containing the canonical form of the origin of the specific location.
        /// </summary>
        public string Origin => JSRef.Get<string>("origin");
        /// <summary>
        /// A string containing an initial '/' followed by the path of the URL, not including the query string or fragment.
        /// </summary>
        public string PathName => JSRef.Get<string>("pathname");
        /// <summary>
        /// A string containing the port number of the URL.
        /// </summary>
        public string Port => JSRef.Get<string>("port");
        /// <summary>
        /// A string containing the protocol scheme of the URL, including the final ':'
        /// </summary>
        public string Protocol => JSRef.Get<string>("protocol");
        /// <summary>
        /// A string containing a '?' followed by the parameters or "querystring" of the URL. Modern browsers provide URLSearchParams and URL.searchParams to make it easy to parse out the parameters from the querystring.
        /// </summary>
        public string Search => JSRef.Get<string>("search");
        /// <summary>
        /// Loads the resource at the URL provided in parameter.
        /// </summary>
        /// <param name="url"></param>
        public void Assign(string url) => JSRef.CallVoid("assign", url);
        /// <summary>
        /// Reloads the current URL, like the Refresh button.
        /// </summary>
        public void Reload() => JSRef.CallVoid("reload");
        /// <summary>
        /// Replaces the current resource with the one at the provided URL (redirects to the provided URL). The difference from the assign() method and setting the href property is that after using replace() the current page will not be saved in session History, meaning the user won't be able to use the back button to navigate to it.
        /// </summary>
        /// <param name="url"></param>
        public void Replace(string url) => JSRef.CallVoid("replace", url);
        /// <summary>
        /// Returns a string containing the whole URL. It is a synonym for Location.href, though it can't be used to modify the value.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JSRef.Call<string>("toString");
    }
}
