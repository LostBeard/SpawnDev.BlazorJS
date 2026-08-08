namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Callbacks passed to <see cref="TrustedTypePolicyFactory.CreatePolicy"/>. Each receives the untrusted
    /// input string (and any extra arguments) and returns the approved string used to build the matching
    /// Trusted Type. A callback left null means the policy does not produce that type, and calling the
    /// corresponding <c>Create*</c> on the policy will throw.<br/>
    /// <para>
    /// Provide a <see cref="Callback"/> (e.g. <c>Callback.Create&lt;string, string&gt;(s =&gt; s)</c>) rather
    /// than building a JS function with <c>new Function(...)</c>: a page enforcing Trusted Types typically
    /// also blocks <c>unsafe-eval</c>, so an eval-built function would be refused, whereas a Callback is a
    /// pre-registered function and is not.
    /// </para>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TrustedTypePolicyFactory/createPolicy#policyoptions
    /// </summary>
    public class TrustedTypePolicyOptions
    {
        /// <summary>Callback that builds a <see cref="TrustedHTML"/>: takes the input string, returns a string.</summary>
        public Callback? CreateHTML { get; set; }
        /// <summary>Callback that builds a <see cref="TrustedScript"/>: takes the input string, returns a string.</summary>
        public Callback? CreateScript { get; set; }
        /// <summary>Callback that builds a <see cref="TrustedScriptURL"/>: takes the input string, returns a string.</summary>
        public Callback? CreateScriptURL { get; set; }
    }
}
