using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class URL : JSObject
    {
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
        //public static string CreateObjectURL(object obj) => JS.Call<string>("createObjectURL", obj);
        public static string CreateObjectURL(Blob obj) => JS.Call<string>("URL.createObjectURL", obj);
        public static void RevokeObjectURL(string objectUrl) => JS.Call<string>("URL.revokeObjectURL", objectUrl);
    }
}
