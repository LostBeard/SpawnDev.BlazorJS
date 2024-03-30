using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for CredentialsContainer.Create()<br /> 
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#publickey_object_structure
    /// </summary>
    public class CredentialCreatePublicKey
    {
        /// <summary>
        /// 32 byte challenge. Must be randomly generated on the server.
        /// </summary>
        public byte[] Challenge { get; set; }
        public RelyingParty Rp { get; set; }
        /// <summary>
        /// An object describing the user account for which the credential is generated
        /// </summary>
        public CredentialUser User { get; set; }
        public List<PublicKeyCredentialParameters> PubKeyCredParams { get; set; } = new List<PublicKeyCredentialParameters>();
        /// <summary>
        /// A String which indicates how the attestation (for the authenticator's origin) should be transported. Should be one of none, indirect, direct, or enterprise. The default value is none
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Attestation { get; set; }
        /// <summary>
        /// A numerical hint, in milliseconds, which indicates the time the caller is willing to wait for the creation operation to complete. This hint may be overridden by the browser.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Timeout { get; set; }


        // TODO - finish adding below 3 properties (part of Fido2 Asp.Net
        ///// <summary>
        ///// This member is intended for use by Relying Parties that wish to select the appropriate authenticators to participate in the create() operation.
        ///// </summary>
        //[JsonPropertyName("authenticatorSelection")]
        //public AuthenticatorSelection AuthenticatorSelection { get; set; }

        ///// <summary>
        ///// This member is intended for use by Relying Parties that wish to limit the creation of multiple credentials for the same account on a single authenticator.The client is requested to return an error if the new credential would be created on an authenticator that also contains one of the credentials enumerated in this parameter.
        ///// </summary>
        //[JsonPropertyName("excludeCredentials")]
        //public List<PublicKeyCredentialDescriptor> ExcludeCredentials { get; set; }

        ///// <summary>
        ///// This OPTIONAL member contains additional parameters requesting additional processing by the client and authenticator. For example, if transaction confirmation is sought from the user, then the prompt string might be included as an extension.
        ///// </summary>
        //[JsonPropertyName("extensions")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public AuthenticationExtensionsClientInputs Extensions { get; set; }
    }
}
