using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DOMTokenList interface represents a set of space-separated tokens. Such a set is returned by Element.classList or HTMLLinkElement.relList, and many others.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/DOMTokenList
    /// </summary>
    public class DOMTokenList : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DOMTokenList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An integer representing the number of objects stored in the object.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// A stringifier property that returns the value of the list as a string.
        /// </summary>
        public string Value => JSRef!.Get<string>("value");
        /// <summary>
        /// Returns the item in the list by its index, or null if the index is greater than or equal to the list's length.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string? Item(int index) => JSRef!.Call<string?>("item", index);
        /// <summary>
        /// Returns true if the list contains the given token, otherwise false.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool Contains(string token) => JSRef!.Call<bool>("contains", token);
        /// <summary>
        /// Adds the specified tokens to the list.
        /// </summary>
        /// <param name="tokens"></param>
        public void Add(params string[] tokens) => JSRef!.CallApplyVoid("add", tokens);
        /// <summary>
        /// Removes the specified tokens from the list.
        /// </summary>
        /// <param name="tokens"></param>
        public void Remove(params string[] tokens) => JSRef!.CallApplyVoid("remove", tokens);
        /// <summary>
        /// The replace() method of the DOMTokenList interface replaces an existing token with a new token. If the first token doesn't exist, replace() returns false immediately, without adding the new token to the token list.
        /// </summary>
        /// <param name="oldToken">A string representing the token you want to replace.</param>
        /// <param name="newToken">A string representing the token you want to replace oldToken with.</param>
        /// <returns>A boolean value, which is true if oldToken was successfully replaced, or false if not.</returns>
        public bool Replace(string oldToken, string newToken) => JSRef!.Call<bool>("replace", oldToken, newToken);
        /// <summary>
        /// Returns true if the given token is in the associated attribute's supported tokens.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool Supports(string token) => JSRef!.Call<bool>("supports", token);
        /// <summary>
        /// The toggle() method of the DOMTokenList interface removes an existing token from the list and returns false. If the token doesn't exist it's added and the function returns true.
        /// </summary>
        /// <param name="token">A string representing the token you want to toggle.</param>
        /// <param name="force">If included, turns the toggle into a one way-only operation. If set to false, then token will only be removed, but not added. If set to true, then token will only be added, but not removed.</param>
        /// <returns></returns>
        public bool Toggle(string token, bool force) => JSRef!.Call<bool>("toggle", token, force);
        /// <summary>
        /// The toggle() method of the DOMTokenList interface removes an existing token from the list and returns false. If the token doesn't exist it's added and the function returns true.
        /// </summary>
        /// <param name="token">A string representing the token you want to toggle.</param>
        /// <returns></returns>
        public bool Toggle(string token) => JSRef!.Call<bool>("toggle", token);
        /// <summary>
        /// Returns an iterator, allowing you to go through all key/value pairs contained in this object.
        /// </summary>
        /// <returns></returns>
        public List<(int, string)> Entries() => JSRef!.Call<Iterator<(int, string)>>("entries")!;
        /// <summary>
        /// Returns an iterator, allowing you to go through all keys of the key/value pairs contained in this object.
        /// </summary>
        /// <returns></returns>
        public List<int> Keys() => JSRef!.Call<Iterator<int>>("keys")!;
        /// <summary>
        /// Returns an iterator, allowing you to go through all values of the key/value pairs contained in this object.
        /// </summary>
        /// <returns></returns>
        public List<string> Values() => JSRef!.Call<Iterator<string>>("values")!;
    }
}
