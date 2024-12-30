using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for requesting a credential via navigator.credentials.get()
    /// https://w3c.github.io/webappsec-credential-management/#dictdef-credentialrequestoptions
    /// </summary>
    public class CredentialRequestOptions
    {
        /// <summary>
        /// The mediation requirements for the request.
        /// Can be one of: "silent", "optional", "required", or "conditional"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Mediation { get; set; }

        /// <summary>
        /// A boolean value that specifies whether the user agent should request password credentials.
        /// This can be specified along with other credential types.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Password { get; set; }

        /// <summary>
        /// An AbortSignal to abort the credential request operation.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AbortSignal? Signal { get; set; }

        /// <summary>
        /// Represents options for federated credential requests.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FederatedCredentialRequestOptions? Federated { get; set; }

        /// <summary>
        /// Options for Public Key Credential requests (WebAuthn).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PublicKeyCredentialRequestOptions? PublicKey { get; set; }

        /// <summary>
        /// When true, indicates that the Credential should not be stored.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Unmediated { get; set; }
    }

    /// <summary>
    /// Options for requesting federated credentials
    /// </summary>
    public class FederatedCredentialRequestOptions
    {
        /// <summary>
        /// The list of providers that can be used to sign in.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? Providers { get; set; }

        /// <summary>
        /// The list of identity protocols that can be used.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? Protocols { get; set; }
    }

    /// <summary>
    /// Constants for valid mediation requirement values in CredentialRequestOptions
    /// </summary>
    public static class CredentialMediationRequirement
    {
        /// <summary>
        /// The user agent will not show any user interface.
        /// If a credential cannot be returned without user interface, the operation will fail.
        /// </summary>
        public const string Silent = "silent";

        /// <summary>
        /// The user agent may show user interface if it would be helpful.
        /// </summary>
        public const string Optional = "optional";

        /// <summary>
        /// The user agent will always show some user interface.
        /// </summary>
        public const string Required = "required";

        /// <summary>
        /// The user agent will only show user interface if certain requirements are met.
        /// </summary>
        public const string Conditional = "conditional";
    }

    /// <summary>
    /// Extension methods for CredentialRequestOptions
    /// </summary>
    public static class CredentialRequestOptionsExtensions
    {
        /// <summary>
        /// Creates a new CredentialRequestOptions with silent mediation
        /// </summary>
        public static CredentialRequestOptions WithSilentMediation(this CredentialRequestOptions options)
        {
            options.Mediation = CredentialMediationRequirement.Silent;
            return options;
        }

        /// <summary>
        /// Creates a new CredentialRequestOptions configured for password credentials
        /// </summary>
        public static CredentialRequestOptions WithPasswordCredentials(this CredentialRequestOptions options)
        {
            options.Password = true;
            return options;
        }

        /// <summary>
        /// Adds federated credential providers to the options
        /// </summary>
        public static CredentialRequestOptions WithProviders(this CredentialRequestOptions options, params string[] providers)
        {
            options.Federated ??= new FederatedCredentialRequestOptions();
            options.Federated.Providers = providers;
            return options;
        }

        /// <summary>
        /// Adds federated credential protocols to the options
        /// </summary>
        public static CredentialRequestOptions WithProtocols(this CredentialRequestOptions options, params string[] protocols)
        {
            options.Federated ??= new FederatedCredentialRequestOptions();
            options.Federated.Protocols = protocols;
            return options;
        }
    }
    /// <summary>
    /// The PublicKeyCredentialRequestOptions dictionary supplies get() with the data it needs to generate an assertion.
    /// https://www.w3.org/TR/webauthn-2/#dictdef-publickeycredentialrequestoptions
    /// </summary>
    public class PublicKeyCredentialRequestOptions
    {
        /// <summary>
        /// A challenge that the authenticator signs, along with other data, when producing an authentication assertion.
        /// Must be a cryptographically random buffer of at least 16 bytes.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public byte[]? Challenge { get; set; }

        /// <summary>
        /// Specifies a time, in milliseconds, that the caller is willing to wait for the call to complete.
        /// This is treated as a hint, and may be overridden by the platform.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ulong? Timeout { get; set; }

        /// <summary>
        /// Identifier for the Relying Party responsible for the request.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RpId { get; set; }

        /// <summary>
        /// List of credentials acceptable to the caller, in order of the caller's preference.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PublicKeyCredentialDescriptor[]? AllowCredentials { get; set; }

        /// <summary>
        /// The caller's requirements regarding user verification.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? UserVerification { get; set; }

        /// <summary>
        /// Additional extensions the caller wishes to process or generate.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AuthenticationExtensionsClientInputs? Extensions { get; set; }
    }

    /// <summary>
    /// Contains the attributes that are specified by a caller when referring to a public key credential.
    /// </summary>
    public class PublicKeyCredentialDescriptor
    {
        /// <summary>
        /// The type of credential. Must be "public-key".
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = "public-key";

        /// <summary>
        /// The credential ID of the public key credential the caller is referring to.
        /// </summary>
        [JsonPropertyName("id")]
        public byte[] Id { get; set; } = System.Array.Empty<byte>();

        /// <summary>
        /// The transports that the caller is willing to use.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("transports")]
        public string[]? Transports { get; set; }
    }

    /// <summary>
    /// Contains the client extension input values for authentication extensions.
    /// </summary>
    public class AuthenticationExtensionsClientInputs
    {
        /// <summary>
        /// Example extension property. Real implementation would include specific extension properties.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? AppId { get; set; }
    }

    /// <summary>
    /// Constants for user verification requirement values
    /// </summary>
    public static class UserVerificationRequirement
    {
        /// <summary>
        /// The authenticator should not require user verification.
        /// </summary>
        public const string Discouraged = "discouraged";

        /// <summary>
        /// The authenticator should require user verification.
        /// </summary>
        public const string Required = "required";

        /// <summary>
        /// The authenticator is free to decide if user verification is necessary.
        /// </summary>
        public const string Preferred = "preferred";
    }

    /// <summary>
    /// Constants for authenticator transport values
    /// </summary>
    public static class AuthenticatorTransport
    {
        /// <summary>
        /// USB transport.
        /// </summary>
        public const string Usb = "usb";

        /// <summary>
        /// NFC transport.
        /// </summary>
        public const string Nfc = "nfc";

        /// <summary>
        /// Bluetooth Low Energy transport.
        /// </summary>
        public const string Ble = "ble";

        /// <summary>
        /// Internal transport.
        /// </summary>
        public const string Internal = "internal";
    }
}
