using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    internal class Date : JSObject {
        public Date() : base(JS.New(nameof(Date))) { }
        public Date(IJSInProcessObjectReference _ref) : base(_ref) { }
        public long GetTime() => JSRef.Call<long>("getTime");
        public int GetTimezoneOffset() => JSRef.Call<int>("getTimezoneOffset");
        public string ToISOString() => JSRef.Call<string>("toISOString");
        public DateTimeOffset GetDateTimeOffset() => DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromMinutes(-GetTimezoneOffset()));

    }
}
