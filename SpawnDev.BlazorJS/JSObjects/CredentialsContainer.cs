using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{

    // https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create
    public class CredentialCreationPublicKeyOptions
    {
        public CredentialCreationPublicKey PublicKey { get; set; }
    }
    public class CredentialCreationPublicKey
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
    public class PublicKeyCredentialParameters
    {
        public string Type { get; set; } = "public-key";
        public int Alg { get; set; }
        public PublicKeyCredentialParameters() { }
        public PublicKeyCredentialParameters(int alg) => (Alg) = (alg);
        public PublicKeyCredentialParameters(int alg, string type) => (Alg, Type) = (alg, type);
        public static implicit operator PublicKeyCredentialParameters(int alg) => new PublicKeyCredentialParameters(alg);
        public static implicit operator int(PublicKeyCredentialParameters obj) => obj.Alg;
    }
    public class RelyingParty
    {
        public string Name { get; set; } = "";
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }
    }
    public class CredentialUser
    {
        /// <summary>
        /// A user handle (ex: john34)
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// A unique user id of type BufferSource. This value cannot exceed 64 bytes.
        /// </summary>
        public byte[] Id { get; set; }
        /// <summary>
        /// A human-friendly user display name (example: John Doe).
        /// </summary>
        public string DisplayName { get; set; } = "";
    }
    public class Credential : JSObject
    {
        public Credential(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string Id => JSRef.Get<string>("id");
        public string Type => JSRef.Get<string>("type");
    }
    // https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer
    public class CredentialsContainer : JSObject
    {
        public static CredentialsContainer GetDefaultCredentialsContainer() => JS.Get<CredentialsContainer>("navigator.credentials");
        public CredentialsContainer(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a Promise that resolves with a new Credential instance based on the provided options, or null if no Credential object can be created. In exceptional circumstances, the Promise may reject.
        /// </summary>
        public Task<Credential> Create() => JSRef.CallAsync<Credential>("create");
        /// <summary>
        /// Returns a Promise that resolves with a new Credential instance based on the provided options, or null if no Credential object can be created. In exceptional circumstances, the Promise may reject.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<PublicKeyCredential<AuthenticatorAttestationResponse>> Create(CredentialCreationPublicKeyOptions options) => JSRef.CallAsync<PublicKeyCredential<AuthenticatorAttestationResponse>>("create", options);
        //public Task<PasswordCredential> Create(CredentialCreationPasswordOptions options) => JSRef.CallAsync<PasswordCredential>("create", options);
        public Task<Credential?> Get() => JSRef.CallAsync<Credential?>("get");
        public Task<PublicKeyCredential<AuthenticatorAssertionResponse>?> Get(CredentialGetPublicKeyOptions options) => JSRef.CallAsync<PublicKeyCredential<AuthenticatorAssertionResponse>?>("get", options);

    }
    public class CredentialGetPublicKeyOptions
    {
        public CredentialGetPublicKey PublicKey { get; set; }
    }
    public class CredentialGetPublicKey
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Timeout { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? UserVerification { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RpId { get; set; }
        public List<CredentialGetPublicKeyAllowedCredential> AllowCredentials { get; set; } = new List<CredentialGetPublicKeyAllowedCredential>();
        /// <summary>
        /// 16 byte challenge. Must be randomly generated on the server.
        /// </summary>
        public ArrayBuffer Challenge { get; set; }
    }
    public class CredentialGetPublicKeyAllowedCredential
    {
        public ArrayBuffer Id { get; set; }// = "";
        public string Type { get; set; } = "public-key";
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> Transports { get; set; } = new List<string> { "ble","internal","nfc","usb" };
    }

}
