using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The URL interface is used to parse, construct, normalize, and encode URLs. It works by providing properties which allow you to easily read and modify the components of a URL.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/URL
    /// </summary>
    public class URL : JSObject
    {
        /// <summary>
        /// The URL() constructor returns a newly created URL object representing the URL defined by the parameters.
        /// </summary>
        /// <param name="url">A string or any other object with a stringifier — including, for example, an a or area element — that represents an absolute or relative URL. If url is a relative URL, base is required, and will be used as the base URL. If url is an absolute URL, a given base will be ignored.</param>
        public URL(string url) : base(JS.New(nameof(URL), url)) { }
        /// <summary>
        /// The URL() constructor returns a newly created URL object representing the URL defined by the parameters.
        /// </summary>
        /// <param name="url">A string or any other object with a stringifier — including, for example, an a or area element — that represents an absolute or relative URL. If url is a relative URL, base is required, and will be used as the base URL. If url is an absolute URL, a given base will be ignored.</param>
        /// <param name="baseHref">A string representing the base URL to use in cases where url is a relative URL. If not specified, it defaults to undefined</param>
        public URL(string url, string baseHref) : base(JS.New(nameof(URL), url, baseHref)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public URL(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string containing a '#' followed by the fragment identifier of the URL.
        /// </summary>
        public string Hash { get => JSRef!.Get<string>("hash"); set => JSRef!.Set("hash", value); }
        /// <summary>
        /// A string containing the domain (that is the hostname) followed by (if a port was specified) a ':' and the port of the URL.
        /// </summary>
        public string Host { get => JSRef!.Get<string>("host"); set => JSRef!.Set("host", value); }
        /// <summary>
        /// A string containing the domain of the URL.
        /// </summary>
        public string Hostname { get => JSRef!.Get<string>("hostname"); set => JSRef!.Set("hostname", value); }
        /// <summary>
        /// A stringifier that returns a string containing the whole URL.
        /// </summary>
        public string Href { get => JSRef!.Get<string>("href"); set => JSRef!.Set("href", value); }
        /// <summary>
        /// Returns a string containing the origin of the URL, that is its scheme, its domain and its port.
        /// </summary>
        public string Origin => JSRef!.Get<string>("origin");
        /// <summary>
        /// A string containing the password specified before the domain name.
        /// </summary>
        public string Password { get => JSRef!.Get<string>("password"); set => JSRef!.Set("password", value); }
        /// <summary>
        /// A string containing an initial '/' followed by the path of the URL, not including the query string or fragment.
        /// </summary>
        public string Pathname { get => JSRef!.Get<string>("pathname"); set => JSRef!.Set("pathname", value); }
        /// <summary>
        /// A string containing the port number of the URL.
        /// </summary>
        public string Port { get => JSRef!.Get<string>("port"); set => JSRef!.Set("port", value); }
        /// <summary>
        /// A string containing the protocol scheme of the URL, including the final ':'.
        /// </summary>
        public string Protocol { get => JSRef!.Get<string>("protocol"); set => JSRef!.Set("protocol", value); }
        /// <summary>
        /// A string indicating the URL's parameter string; if any parameters are provided, this string includes all of them, beginning with the leading ? character.
        /// </summary>
        public string Search { get => JSRef!.Get<string>("search"); set => JSRef!.Set("search", value); }
        /// <summary>
        /// A URLSearchParams object which can be used to access the individual query parameters found in search.
        /// </summary>
        public URLSearchParams SearchParams => JSRef!.Get<URLSearchParams>("searchParams");
        /// <summary>
        /// A string containing the username specified before the domain name.
        /// </summary>
        public string Username { get => JSRef!.Get<string>("username"); set => JSRef!.Set("username", value); }
        /// <summary>
        /// Returns a string containing a unique blob URL, that is a URL with blob: as its scheme, followed by an opaque string uniquely identifying the object in the browser.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string CreateObjectURL(Blob obj) => JS.Call<string>("URL.createObjectURL", obj);
        /// <summary>
        /// Revokes an object URL previously created using URL.createObjectURL().
        /// </summary>
        /// <param name="objectUrl"></param>
        public static void RevokeObjectURL(string objectUrl) => JS.Call<string>("URL.revokeObjectURL", objectUrl);
        /// <summary>
        /// Returns a string containing the whole URL. It is a synonym for URL.href, though it can't be used to modify the value
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JSRef!.Call<string>("toString");
        /// <summary>
        /// Returns a string containing the whole URL. It is a synonym for URL.href, though it can't be used to modify the value
        /// </summary>
        /// <param name="url"></param>
        public static implicit operator string(URL url) => url.ToString();
    }
}
