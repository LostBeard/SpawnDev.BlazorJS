using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class WorkerLocation : JSObject
    {
        public WorkerLocation(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a string containing the serialized URL for the worker's location.
        /// </summary>
        public string Href => JSRef.Get<string>("href");
        /// <summary>
        /// Returns the protocol part of the worker's location.
        /// </summary>
        public string Protocol => JSRef.Get<string>("protocol");
        /// <summary>
        /// A string containing the host, that is the hostname, a ':', and the port of the URL.
        /// </summary>
        public string Host => JSRef.Get<string>("host");
        /// <summary>
        /// A string containing the domain of the URL.
        /// </summary>
        public string HostName => JSRef.Get<string>("hostname");
        /// <summary>
        /// Returns a string containing the canonical form of the origin of the specific location.
        /// </summary>
        public string Origin => JSRef.Get<string>("origin");
        /// <summary>
        /// A string containing the port number of the URL.
        /// </summary>
        public string Port => JSRef.Get<string>("port");
        /// <summary>
        /// A string containing an initial '/' followed by the path of the URL, not including the query string or fragment.
        /// </summary>
        public string PathName => JSRef.Get<string>("pathname");
        /// <summary>
        /// A string containing a '?' followed by the parameters or "querystring" of the URL. Modern browsers provide URLSearchParams and URL.searchParams to make it easy to parse out the parameters from the querystring.
        /// </summary>
        public string Search => JSRef.Get<string>("search");
        /// <summary>
        /// A string containing a '#' followed by the fragment identifier of the URL.
        /// </summary>
        public string Hash => JSRef.Get<string>("hash");
    }
}
