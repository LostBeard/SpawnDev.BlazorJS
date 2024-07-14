using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Used in CredentialCreatePublicKey
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#authenticatorselection
    /// </summary>
    public class AuthenticatorSelection
    {
        /// <summary>
        /// A string indicating which authenticator attachment type should be permitted for the chosen authenticator. Possible values are:<br/>
        /// "platform" - The authenticator is part of the device WebAuthn is running on (termed a platform authenticator), therefore WebAuthn will communicate with it using a transport available to that platform, such as a platform-specific API. A public key credential bound to a platform authenticator is called a platform credential.<br/>
        /// "cross-platform" - The authenticator is not a part of the device WebAuthn is running on (termed a roaming authenticator as it can roam between different devices), therefore WebAuthn will communicate with it using a cross-platform transport protocol such as Bluetooth or NFC. A public key credential bound to a roaming authenticator is called a roaming credential.<br/>
        /// If omitted, any type of authenticator, either platform or cross-platform, can be selected for the credential creation operation.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AuthenticatorAttachment { get; set; }
        /// <summary>
        /// A boolean. If set to true, it indicates that a resident key is required (see residentKey) This property is deprecated, but still available in some implementations for backwards compatibility with WebAuthn Level 1. The value should be set to true if residentKey is set to "required".<br/>
        /// If omitted, requireResidentKey defaults to false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RequireResidentKey { get; set; }
        /// <summary>
        /// A string that specifies the extent to which the relying party desires to create a client-side discoverable credential (i.e., one that is usable in authentication requests where the relying party does not provide credential IDs — navigator.credentials.get() is called with an empty allowCredentials value). The alternative is a server-side credential, where the relying party must provide credential IDs in the get() allowCredentials value. Possible values are:<br/>
        /// "discouraged" - The relying party prefers creation of a server-side credential, but will accept a client-side discoverable credential.<br/>
        /// "preferred" - The relying party strongly prefers creation of a client-side discoverable credential, but will accept a server-side credential. The user agent should guide the user through setting up user verification, if needed, to create a discoverable credential. This takes precedence over the userVerification setting.<br/>
        /// "required" - The relying party requires a client-side discoverable credential. If one cannot be created, an error is thrown.<br/>
        /// If omitted, residentKey defaults to "required" if requireResidentKey is true, otherwise the default value is "discouraged".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ResidentKey { get; set; }
        /// <summary>
        /// A string that specifies the relying party's requirements for user verification for the create() operation. Possible values are:<br/>
        /// "discouraged" - The relying party prefers no user verification for the create() operation, in the interests of minimizing disruption to the user experience.<br/>
        /// "preferred" - The relying party prefers user verification for the create() operation, but it will not fail if user verification cannot be performed.<br/>
        /// "required" - The relying party requires user verification for the create() operation — if user verification cannot be performed, an error is thrown.<br/>
        /// If omitted, userVerification defaults to "preferred".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? UserVerification { get; set; }
    }
}
