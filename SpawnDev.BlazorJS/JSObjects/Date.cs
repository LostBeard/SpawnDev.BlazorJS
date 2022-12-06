using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Date>))]
    internal class Date : JSObject
    {
        public Date() : base("Date") { }
        public Date(IJSInProcessObjectReference _ref) : base(_ref) { }
        public long GetTime() => _ref.Call<long>("getTime");
        public int GetTimezoneOffset() => _ref.Call<int>("getTimezoneOffset");
        public string ToISOString() => _ref.Call<string>("toISOString");
        public DateTimeOffset GetDateTimeOffset() => DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromMinutes(-GetTimezoneOffset()));

    }
}
