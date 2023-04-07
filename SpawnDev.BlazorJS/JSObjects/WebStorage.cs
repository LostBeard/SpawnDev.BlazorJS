using Microsoft.JSInterop;
using System.Text.Json;

namespace SpawnDev.BlazorJS.JSObjects {
    public class WebStorage : JSObject {
        public JsonSerializerOptions DefaultJsonSerializerOptions { get; } = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, AllowTrailingCommas = true, ReadCommentHandling = JsonCommentHandling.Skip };
        public WebStorage(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int Length => JSRef.Get<int>("length");
        public void SetItem(string key, string value) => JSRef.CallVoid("setItem", key, value);
        public List<string> GetItemKeys() => JSRef.GetPropertyNames(true);
        public string? GetItem(string key) => JSRef.Call<string?>("getItem", key);
        public T GetJSON<T>(string key) {
            var str = JSRef.Call<string?>("getItem", key);
            if (string.IsNullOrEmpty(str)) return default(T);
            return JsonSerializer.Deserialize<T>(str, DefaultJsonSerializerOptions);
        }
        public void SetJSON<T>(string key, T value) => JSRef.CallVoid("setItem", key, JsonSerializer.Serialize(value));
        public bool ItemExists(string key) => JSRef.Call<bool>("hasOwnProperty", key);
        public void RemoveItem(string key) => JSRef.CallVoid("removeItem", key);
    }
}