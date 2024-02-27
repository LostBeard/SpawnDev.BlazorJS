using Microsoft.JSInterop;
using System.Text.Json;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Storage interface of the Web Storage API provides access to a particular domain's session or local storage. It allows, for example, the addition, modification, or deletion of stored data items.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Storage
    /// </summary>
    public class Storage : JSObject
    {
        private JsonSerializerOptions DefaultJsonSerializerOptions { get; } = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, AllowTrailingCommas = true, ReadCommentHandling = JsonCommentHandling.Skip };

        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Storage(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        public int Length => JSRef.Get<int>("length");
        #endregion

        #region Methods
        /// <summary>
        /// When passed a number n, this method will return the name of the nth key in the storage.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string? Key(int index) => JSRef.Call<string?>("key", index);
        /// <summary>
        /// When passed a key name and value, will add that key to the storage, or update that key's value if it already exists.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetItem(string key, string value) => JSRef.CallVoid("setItem", key, value);
        /// <summary>
        /// Returns keys using Object.keys
        /// </summary>
        /// <returns></returns>
        public List<string> GetItemKeys() => JS.Call<List<string>>("Object.keys", JSRef);
        /// <summary>
        /// When passed a key name, will return that key's value.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string? GetItem(string key) => JSRef.Call<string?>("getItem", key);
        /// <summary>
        /// Tests for a key's existence using hasOwnProperty
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ItemExists(string key) => JSRef.Call<bool>("hasOwnProperty", key);
        /// <summary>
        /// When passed a key name, will remove that key from the storage.
        /// </summary>
        /// <param name="key"></param>
        public void RemoveItem(string key) => JSRef.CallVoid("removeItem", key);
        /// <summary>
        /// When invoked, will empty all keys out of the storage.
        /// </summary>
        public void Clear() => JSRef.CallVoid("clear");
        /// <summary>
        /// JSON getter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetJSON<T>(string key)
        {
            var str = GetItem(key);
            if (string.IsNullOrEmpty(str)) return default(T)!;
            return JsonSerializer.Deserialize<T>(str, DefaultJsonSerializerOptions)!;
        }
        /// <summary>
        /// JSON setter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetJSON<T>(string key, T value) => JSRef.CallVoid("setItem", key, JsonSerializer.Serialize(value, DefaultJsonSerializerOptions));
        #endregion
    }
}