using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An immutable, policy-approved HTML string. Produced by <see cref="TrustedTypePolicy.CreateHTML"/> and
    /// accepted by HTML injection sinks (Element.innerHTML/outerHTML, DOMParser.parseFromString, ...) on a
    /// page whose CSP enforces <c>require-trusted-types-for 'script'</c>, where a plain string is refused.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TrustedHTML
    /// </summary>
    public class TrustedHTML : JSObject
    {
        /// <summary>
        /// Deserialization constructor. Instances are produced by a policy, never constructed directly.
        /// </summary>
        /// <param name="_ref">JavaScript object reference</param>
        public TrustedHTML(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>Returns the underlying sanitized HTML string.</summary>
        public override string ToString() => JSRef!.Call<string>("toString");
    }
}
