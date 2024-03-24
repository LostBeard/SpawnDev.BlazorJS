using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The URL interface is used to parse, construct, normalize, and encode URLs. It works by providing properties which allow you to easily read and modify the components of a URL.<br />
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
        public URL(string url, string baseHref) : base(JS.New(nameof(URL), url , baseHref)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public URL(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string containing a '#' followed by the fragment identifier of the URL.
        /// </summary>
        public string Hash => JSRef.Get<string>("hash");
        /// <summary>
        /// A string containing the domain (that is the hostname) followed by (if a port was specified) a ':' and the port of the URL.
        /// </summary>
        public string Host => JSRef.Get<string>("host");
        /// <summary>
        /// A string containing the domain of the URL.
        /// </summary>
        public string Hostname => JSRef.Get<string>("hostname");
        /// <summary>
        /// A stringifier that returns a string containing the whole URL.
        /// </summary>
        public string Href => JSRef.Get<string>("href");
        /// <summary>
        /// Returns a string containing the origin of the URL, that is its scheme, its domain and its port.
        /// </summary>
        public string Origin => JSRef.Get<string>("origin");
        /// <summary>
        /// A string containing the password specified before the domain name.
        /// </summary>
        public string Password => JSRef.Get<string>("password");
        /// <summary>
        /// A string containing an initial '/' followed by the path of the URL, not including the query string or fragment.
        /// </summary>
        public string Pathname => JSRef.Get<string>("pathname");
        /// <summary>
        /// A string containing the port number of the URL.
        /// </summary>
        public string Port => JSRef.Get<string>("port");
        /// <summary>
        /// A string containing the protocol scheme of the URL, including the final ':'.
        /// </summary>
        public string Protocol => JSRef.Get<string>("protocol");
        /// <summary>
        /// A string indicating the URL's parameter string; if any parameters are provided, this string includes all of them, beginning with the leading ? character.
        /// </summary>
        public string Search => JSRef.Get<string>("search");
        /// <summary>
        /// A string containing the username specified before the domain name.
        /// </summary>
        public string Username => JSRef.Get<string>("username");
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
        public override string ToString() => JSRef.Call<string>("toString");
        /// <summary>
        /// Returns a string containing the whole URL. It is a synonym for URL.href, though it can't be used to modify the value
        /// </summary>
        /// <param name="url"></param>
        public static implicit operator string(URL url) => url.ToString();
    }
}
