using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A Trusted Type policy created via <see cref="TrustedTypePolicyFactory.CreatePolicy"/>. Its
    /// <c>Create*</c> methods turn an input string into the matching Trusted Type by running it through the
    /// policy's callback, which the browser then accepts at an injection sink (innerHTML,
    /// DOMParser.parseFromString, script src, ...) where a plain string is refused under a
    /// <c>require-trusted-types-for 'script'</c> CSP.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TrustedTypePolicy
    /// </summary>
    public class TrustedTypePolicy : JSObject
    {
        /// <summary>
        /// Deserialization constructor. Instances are produced by the factory, never constructed directly.
        /// </summary>
        /// <param name="_ref">JavaScript object reference</param>
        public TrustedTypePolicy(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>The name this policy was created with.</summary>
        public string Name => JSRef!.Get<string>("name");
        /// <summary>
        /// Runs <paramref name="input"/> through this policy's <c>createHTML</c> callback and returns the
        /// resulting <see cref="TrustedHTML"/>. Throws if the policy was created without a <c>createHTML</c>
        /// callback.
        /// </summary>
        public TrustedHTML CreateHTML(string input) => JSRef!.Call<TrustedHTML>("createHTML", input);
        /// <summary>
        /// Runs <paramref name="input"/> through this policy's <c>createScript</c> callback and returns the
        /// resulting <see cref="TrustedScript"/>.
        /// </summary>
        public TrustedScript CreateScript(string input) => JSRef!.Call<TrustedScript>("createScript", input);
        /// <summary>
        /// Runs <paramref name="input"/> through this policy's <c>createScriptURL</c> callback and returns the
        /// resulting <see cref="TrustedScriptURL"/>.
        /// </summary>
        public TrustedScriptURL CreateScriptURL(string input) => JSRef!.Call<TrustedScriptURL>("createScriptURL", input);
    }
}
