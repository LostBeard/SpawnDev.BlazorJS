using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class URL : JSObject
    {
        /// <summary>
        /// The URL() constructor returns a newly created URL object representing the URL defined by the parameters.
        /// </summary>
        /// <param name="url">A string or any other object with a stringifier — including, for example, an <a> or <area> element — that represents an absolute or relative URL. If url is a relative URL, base is required, and will be used as the base URL. If url is an absolute URL, a given base will be ignored.</param>
        public URL(string url) : base(JS.New(nameof(URL), url)) { }
        /// <summary>
        /// The URL() constructor returns a newly created URL object representing the URL defined by the parameters.
        /// </summary>
        /// <param name="url">A string or any other object with a stringifier — including, for example, an <a> or <area> element — that represents an absolute or relative URL. If url is a relative URL, base is required, and will be used as the base URL. If url is an absolute URL, a given base will be ignored.</param>
        /// <param name="baseHref">A string representing the base URL to use in cases where url is a relative URL. If not specified, it defaults to undefined</param>
        public URL(string url, string baseHref) : base(JS.New(nameof(URL), url , baseHref)) { }
        public URL(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string Hash => JSRef.Get<string>("hash");
        public string Host => JSRef.Get<string>("host");
        public string Hostname => JSRef.Get<string>("hostname");
        public string Href => JSRef.Get<string>("href");
        public string Origin => JSRef.Get<string>("origin");
        public string Password => JSRef.Get<string>("password");
        public string Pathname => JSRef.Get<string>("pathname");
        public string Port => JSRef.Get<string>("port");
        public string Protocol => JSRef.Get<string>("protocol");
        public string Search => JSRef.Get<string>("search");
        public string Username => JSRef.Get<string>("username");
        public static string CreateObjectURL(Blob obj) => JS.Call<string>("URL.createObjectURL", obj);
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
