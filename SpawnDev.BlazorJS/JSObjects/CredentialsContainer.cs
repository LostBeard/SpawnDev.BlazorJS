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
    /// <summary>
    /// The CredentialsContainer interface of the Credential Management API exposes methods to request credentials and notify the user agent when events such as successful sign in or sign out happen. This interface is accessible from Navigator.credentials.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer
    /// </summary>
    public class CredentialsContainer : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public CredentialsContainer(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns navigator.credentials
        /// </summary>
        /// <returns></returns>
        public static CredentialsContainer GetDefaultCredentialsContainer() => JS.Get<CredentialsContainer>("navigator.credentials");
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
        /// <summary>
        /// Returns a Promise that resolves with the Credential instance that matches the provided parameters.
        /// </summary>
        /// <returns></returns>
        public Task<Credential?> Get() => JSRef.CallAsync<Credential?>("get");
        /// <summary>
        /// Returns a Promise that resolves with the Credential instance that matches the provided parameters.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<PublicKeyCredential<AuthenticatorAssertionResponse>?> Get(CredentialGetPublicKeyOptions options) => JSRef.CallAsync<PublicKeyCredential<AuthenticatorAssertionResponse>?>("get", options);

    }
    /// <summary>
    /// Options used for CredentialsContainer.Get()
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/get#options
    /// </summary>
    public class CredentialGetPublicKeyOptions
    {
        /// <summary>
        /// An object containing requirements for a requested credential from a federated identify provider. Bear in mind that the Federated Credential Management API (the identity credential type) supersedes this credential type. See the Credential Management API section below for more details.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Federated { get; set; }
        /// <summary>
        /// A boolean value indicating that a password credential is being requested. See the Credential Management API section below for more details.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Password { get; set; }
        /// <summary>
        /// An object containing details of federated identity providers (IdPs) that a relying party (RP) website can use for purposes such as signing in or signing up on a website. It causes the get() call to initiate a request for a user to sign in to an RP with an IdP. See the Federated Credential Management API section below for more details.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Identity { get; set; }
        /// <summary>
        /// An object containing transport type hints. Causes the get() call to initiate a request for the retrieval of an OTP. See the WebOTP API section below for more details.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Otp { get; set; }
        /// <summary>
        /// An object containing requirements for returned public key credentials. Causes the get() call to use an existing set of public key credentials to authenticate to a relying party. See the Web Authentication API section below for more details.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CredentialGetPublicKey? PublicKey { get; set; }
    }

}
