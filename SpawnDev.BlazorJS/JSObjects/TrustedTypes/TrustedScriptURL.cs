using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An immutable, policy-approved URL string for loading a script. Produced by
    /// <see cref="TrustedTypePolicy.CreateScriptURL"/> and accepted by script-URL injection sinks
    /// (e.g. <c>HTMLScriptElement.src</c>, <c>Worker</c> URL) on a page whose CSP enforces
    /// <c>require-trusted-types-for 'script'</c>.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TrustedScriptURL
    /// </summary>
    public class TrustedScriptURL : JSObject
    {
        /// <summary>
        /// Deserialization constructor. Instances are produced by a policy, never constructed directly.
        /// </summary>
        /// <param name="_ref">JavaScript object reference</param>
        public TrustedScriptURL(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>Returns the underlying sanitized URL string.</summary>
        public override string ToString() => JSRef!.Call<string>("toString");
    }
}
