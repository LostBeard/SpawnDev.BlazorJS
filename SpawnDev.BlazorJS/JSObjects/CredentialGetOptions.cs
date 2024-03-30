using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options used for CredentialsContainer.Get()
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/get#options
    /// </summary>
    public abstract class CredentialGetOptions
    {
        /// <summary>
        /// An AbortSignal object instance that allows an ongoing get() operation to be aborted. An aborted operation may complete normally (generally if the abort was received after the operation finished) or reject with an "AbortError" DOMException.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AbortSignal? Signal { get; set; }
        /// <summary>
        /// A string indicating whether the user will be required to login for every visit to a client app. The value can be one of the following:<br />
        /// "conditional" - Discovered credentials are presented to the user in a non-modal dialog box along with an indication of the origin requesting credentials. In practice, this means autofilling available credentials; see Sign in with a passkey through form autofill for more details of how this is used; PublicKeyCredential.isConditionalMediationAvailable() also provides some useful information.<br />
        /// "optional" - If credentials can be handed over for a given operation without user mediation, they will be, enabling automatic reauthentication without user mediation. If user mediation is required, then the user agent will ask the user to authenticate. This value is intended for situations where you have reasonable confidence that a user won't be surprised or confused at seeing a login dialog box — for example on a site that doesn't automatically log users in, when a user has just clicked a "Login/Signup" button.<br />
        /// "required" - The user will always be asked to authenticate, even if prevent silent access (see CredentialsContainer.preventSilentAccess()) is set to false. This value is intended for situations where you want to force user authentication — for example if you want a user to reauthenticate when a sensitive operation is being performed (like confirming a credit card payment), or when switching users.<br />
        /// "silent" - The user will not be asked to authenticate. The user agent will automatically reauthenticate the user and log them in if possible. If consent is required, the promise will fulfill with null. This value is intended for situations where you would want to automatically sign a user in upon visiting a web app if possible, but if not, you don't want to present them with a confusing login dialog box. Instead, you'd want to wait for them to explicitly click a "Login/Signup" button.<br />
        /// If mediation is omitted, it will default to "optional".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Mediation { get; set; }
    }
}
