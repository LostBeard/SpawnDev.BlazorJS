using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The URLSearchParams interface defines utility methods to work with the query string of a URL.
    /// </summary>
    public class URLSearchParams : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public URLSearchParams(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a URLSearchParams object instance
        /// </summary>
        public URLSearchParams() : base(JS.New(nameof(URLSearchParams))) { }
        /// <summary>
        /// Indicates the total number of search parameter entries.
        /// </summary>
        public int Size => JSRef!.Get<int>("size");
        /// <summary>
        /// Appends a specified key/value pair as a new search parameter.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Append(string name, string value) => JSRef!.CallVoid("append", name, value);
        /// <summary>
        /// Deletes search parameters that match a name, and optional value, from the list of all search parameters
        /// </summary>
        /// <param name="name"></param>
        public void Delete(string name) => JSRef!.CallVoid("delete", name);
        /// <summary>
        /// Deletes search parameters that match a name, and optional value, from the list of all search parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Delete(string name, string value) => JSRef!.CallVoid("delete", name, value);
        /// <summary>
        /// Returns an iterator allowing iteration through all key/value pairs contained in this object in the same order as they appear in the query string.
        /// </summary>
        /// <returns></returns>
        public Iterator<string[]> Entries() => JSRef!.Call<Iterator<string[]>>("entries");
        /// <summary>
        /// Allows iteration through all values contained in this object via a callback function.
        /// </summary>
        /// <param name="callback"></param>
        public void ForEach(Action<string, string, URLSearchParams> callback)
        {
            using var cb = Callback.Create(callback);
            JSRef.CallVoid("forEach", cb);
        }
        /// <summary>
        /// Allows iteration through all values contained in this object via a callback function.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="thisArg"></param>
        public void ForEach(Action<string, string, URLSearchParams> callback, object thisArg)
        {
            using var cb = Callback.Create(callback);
            JSRef.CallVoid("forEach", cb, thisArg);
        }
        /// <summary>
        /// Returns the first value associated with the given search parameter.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string? Get(string name) => JSRef!.Call<string?>("get", name);
        /// <summary>
        /// Returns all the values associated with a given search parameter.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<string> GetAll(string name) => JSRef!.Call<List<string>>("getAll", name);
        /// <summary>
        /// Returns a boolean value indicating if a given parameter, or parameter and value pair, exists.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Has(string name) => JSRef!.Call<bool>("has", name);
        /// <summary>
        /// Returns a boolean value indicating if a given parameter, or parameter and value pair, exists.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Has(string name, string value) => JSRef!.Call<bool>("has", name, value);
        /// <summary>
        /// Returns an iterator allowing iteration through all keys of the key/value pairs contained in this object
        /// </summary>
        /// <returns></returns>
        public Iterator<string> Keys() => JSRef!.Call<Iterator<string>>("keys");
        /// <summary>
        /// Sets the value associated with a given search parameter to the given value. If there are several values, the others are deleted.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Set(string name, string value) => JSRef!.Call<bool>("set", name, value);
        /// <summary>
        /// Sorts all key/value pairs, if any, by their keys.
        /// </summary>
        public void Sort() => JSRef!.Call<bool>("sort");
        /// <summary>
        /// Returns a string containing a query string suitable for use in a URL.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JSRef!.Call<string>("toString");
        /// <summary>
        /// Returns an iterator allowing iteration through all values of the key/value pairs contained in this object.
        /// </summary>
        /// <returns></returns>
        public Iterator<string> Values() => JSRef!.Call<Iterator<string>>("values");
    }
}
