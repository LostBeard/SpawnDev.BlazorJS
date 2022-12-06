using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<WebStorage>))]
    public class WebStorage : JSObject
    {
        public JsonSerializerOptions DefaultJsonSerializerOptions { get; } = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        public WebStorage(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int Length => _ref.Get<int>("length");
        public void SetItem(string key, string value) => _ref.CallVoid("setItem", key, value);
        public List<string> GetItemKeys() => _ref.GetPropertyNames(true);
        public string? GetItem(string key) => _ref.Call<string?>("getItem", key);
        public T GetJSON<T>(string key) => JsonSerializer.Deserialize<T>(_ref.Call<string>("getItem", key), DefaultJsonSerializerOptions);
        public void SetJSON<T>(string key, T value) => _ref.CallVoid("setItem", key, JsonSerializer.Serialize(value));
        public bool ItemExists(string key) => _ref.Call<bool>("hasOwnProperty", key);
        public void RemoveItem(string key) => _ref.CallVoid("removeItem", key);
    }
}