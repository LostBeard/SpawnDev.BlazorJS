using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An immutable, policy-approved script string. Produced by <see cref="TrustedTypePolicy.CreateScript"/>
    /// and accepted by script injection sinks (e.g. an inline event handler property, <c>eval</c>) on a page
    /// whose CSP enforces <c>require-trusted-types-for 'script'</c>.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TrustedScript
    /// </summary>
    public class TrustedScript : JSObject
    {
        /// <summary>
        /// Deserialization constructor. Instances are produced by a policy, never constructed directly.
        /// </summary>
        /// <param name="_ref">JavaScript object reference</param>
        public TrustedScript(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>Returns the underlying sanitized script string.</summary>
        public override string ToString() => JSRef!.Call<string>("toString");
    }
}
