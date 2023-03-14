using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    
    internal class Date : JSObject
    {
        public Date() : base(JS.New(nameof(Date))) { }
        public Date(IJSInProcessObjectReference _ref) : base(_ref) { }
        public long GetTime() => JSRef.Call<long>("getTime");
        public int GetTimezoneOffset() => JSRef.Call<int>("getTimezoneOffset");
        public string ToISOString() => JSRef.Call<string>("toISOString");
        public DateTimeOffset GetDateTimeOffset() => DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromMinutes(-GetTimezoneOffset()));

    }
}
