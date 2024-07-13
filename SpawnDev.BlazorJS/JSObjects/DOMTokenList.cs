using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class DOMTokenListEntry
    {
        public int Key { get; set; }
        public string Token { get; set; } = "";
    }
    public class DOMTokenList : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DOMTokenList(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string Value => JSRef!.Get<string>("value");
        public int Length => JSRef!.Get<int>("length");
        public string Item(int index) => JSRef!.Call<string>("item", index);
        public bool Contains(string token) => JSRef!.Call<bool>("contains", token);
        public void Add(params string[] tokens) => JSRef!.CallApplyVoid("add", tokens);
        public void Remove(params string[] tokens) => JSRef!.CallApplyVoid("remove", tokens);
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
        /// The replace() method of the DOMTokenList interface replaces an existing token with a new token. If the first token doesn't exist, replace() returns false immediately, without adding the new token to the token list.
        /// </summary>
        /// <param name="oldToken">A string representing the token you want to replace.</param>
        /// <param name="newToken">A string representing the token you want to replace oldToken with.</param>
        /// <returns>A boolean value, which is true if oldToken was successfully replaced, or false if not.</returns>
        public bool Replace(string oldToken, string newToken) => JSRef!.Call<bool>("replace", oldToken, newToken);
        public Dictionary<int, string> Entries()
        {
            var ret = new Dictionary<int, string>();
            using var iterator = JSRef.Call<Iterator<JSObject>>("entries");
            while(true)
            {
                using var result = iterator.Next();
                if (result.Done) break;
                using var value = result.Value;
                var index = value.JSRef.Get<int>(0);
                var token = value.JSRef.Get<string>(1);
                ret[index] = token;
            }
            return ret;
        }
    }
}
