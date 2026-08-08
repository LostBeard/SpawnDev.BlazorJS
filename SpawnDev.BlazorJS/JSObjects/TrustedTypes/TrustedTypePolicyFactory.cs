using Microsoft.JSInterop;
using System.Collections.Generic;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// <c>window.trustedTypes</c> - creates Trusted Type policies and inspects Trusted Type values.<br/>
    /// <para>
    /// The global exists only when the browser supports Trusted Types; on other browsers it is
    /// <c>undefined</c>, so read it as a nullable and treat null as "Trusted Types not present / not
    /// enforced":
    /// <code>var tt = JS.Get&lt;TrustedTypePolicyFactory?&gt;("trustedTypes");</code>
    /// </para>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TrustedTypePolicyFactory
    /// </summary>
    public class TrustedTypePolicyFactory : JSObject
    {
        /// <summary>
        /// Deserialization constructor. Obtain the factory from <c>globalThis.trustedTypes</c> rather than
        /// constructing it.
        /// </summary>
        /// <param name="_ref">JavaScript object reference</param>
        public TrustedTypePolicyFactory(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Creates a <see cref="TrustedTypePolicy"/> with the given name and callbacks.<br/>
        /// If the page's CSP restricts the <c>trusted-types</c> directive to an allowlist, creating a policy
        /// whose name is not on that allowlist throws a <c>TypeError</c>; a name of <c>"default"</c> installs
        /// the special default policy that the platform calls for every otherwise-unsafe assignment, so avoid
        /// it unless that is intended.
        /// </summary>
        /// <param name="policyName">The policy name (must be allowed by any <c>trusted-types</c> CSP directive).</param>
        /// <param name="options">The create* callbacks; null creates a policy with no callbacks.</param>
        public TrustedTypePolicy CreatePolicy(string policyName, TrustedTypePolicyOptions? options = null)
        {
            // Build the policyOptions record explicitly so the JS keys are exactly createHTML/createScript/
            // createScriptURL and each Callback marshals out as its JS function.
            var record = new Dictionary<string, object?>();
            if (options?.CreateHTML != null) record["createHTML"] = options.CreateHTML;
            if (options?.CreateScript != null) record["createScript"] = options.CreateScript;
            if (options?.CreateScriptURL != null) record["createScriptURL"] = options.CreateScriptURL;
            return JSRef!.Call<TrustedTypePolicy>("createPolicy", policyName, record);
        }

        /// <summary>The default policy, or null if none has been created.</summary>
        public TrustedTypePolicy? DefaultPolicy => JSRef!.Get<TrustedTypePolicy?>("defaultPolicy");
        /// <summary>A zero-length <see cref="TrustedHTML"/> - a convenient way to safely clear HTML.</summary>
        public TrustedHTML EmptyHTML => JSRef!.Get<TrustedHTML>("emptyHTML");
        /// <summary>A zero-length <see cref="TrustedScript"/>.</summary>
        public TrustedScript EmptyScript => JSRef!.Get<TrustedScript>("emptyScript");
        /// <summary>Returns true if <paramref name="value"/> is a <see cref="TrustedHTML"/> from any policy in this document.</summary>
        public bool IsHTML(object? value) => JSRef!.Call<bool>("isHTML", value);
        /// <summary>Returns true if <paramref name="value"/> is a <see cref="TrustedScript"/>.</summary>
        public bool IsScript(object? value) => JSRef!.Call<bool>("isScript", value);
        /// <summary>Returns true if <paramref name="value"/> is a <see cref="TrustedScriptURL"/>.</summary>
        public bool IsScriptURL(object? value) => JSRef!.Call<bool>("isScriptURL", value);
    }
}
