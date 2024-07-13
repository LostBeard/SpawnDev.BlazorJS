using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Headers interface of the Fetch API allows you to perform various actions on HTTP request and response headers. These actions include retrieving, setting, adding to, and removing headers from the list of the request's headers.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Headers
    /// </summary>
    public class Headers : JSObject
    {
        /// <summary>
        /// The Request() constructor creates a new Request object.
        /// </summary>
        /// <param name="_ref"></param>
        public Headers(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new Headers object.
        /// </summary>
        public Headers() : base(JS.New(nameof(Headers))) { }
        /// <summary>
        /// Appends a new value onto an existing header inside a Headers object, or adds the header if it does not already exist.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Append(string name, string value) => JSRef!.CallVoid("append", name, value);
        /// <summary>
        /// Deletes a header from a Headers object.
        /// </summary>
        /// <param name="name"></param>
        public void Delete(string name) => JSRef!.CallVoid("delete", name);
        /// <summary>
        /// Returns an iterator allowing to go through all key/value pairs contained in this object.
        /// </summary>
        /// <returns></returns>
        public List<(string, string)> Entries() => JSRef!.Call<Iterator<(string, string)>>("entries")!;
        /// <summary>
        /// Returns a String sequence of all the values of a header within a Headers object with a given name.<br/>
        /// Values are separated by a command and a space (", ")
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string Get(string name) => JSRef!.Call<string>("get", name);
        /// <summary>
        /// Returns a boolean stating whether a Headers object contains a certain header.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Has(string name) => JSRef!.Call<bool>("has", name);
        /// <summary>
        /// Returns an iterator allowing you to go through all keys of the key/value pairs contained in this object.
        /// </summary>
        /// <returns></returns>
        public List<string> Keys() => JSRef!.Call<Iterator<string>>("keys")!;
        /// <summary>
        /// Sets a new value for an existing header inside a Headers object, or adds the header if it does not already exist.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Set(string name, string value) => JSRef!.CallVoid("set", name, value);
        /// <summary>
        /// Returns an iterator allowing you to go through all values of the key/value pairs contained in this object.
        /// </summary>
        /// <returns></returns>
        public List<string> Values() => JSRef!.Call<Iterator<string>>("values")!;

    }
}
