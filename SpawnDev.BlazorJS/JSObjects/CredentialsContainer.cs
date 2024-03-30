using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
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
        public Task<T> Create<T>(CredentialCreateOptions options) where T : Credential => JSRef.CallAsync<T>("create", options);
        /// <summary>
        /// Returns a Promise that resolves with a new Credential instance based on the provided options, or null if no Credential object can be created. In exceptional circumstances, the Promise may reject.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<PublicKeyCredential<AuthenticatorAttestationResponse>> Create(CredentialCreatePublicKeyOptions options) => JSRef.CallAsync<PublicKeyCredential<AuthenticatorAttestationResponse>>("create", options);        
        /// <summary>
        /// Returns a Promise that resolves with the Credential instance that matches the provided parameters.
        /// </summary>
        /// <returns></returns>
        public Task<Credential?> Get() => JSRef.CallAsync<Credential?>("get");
        /// <summary>
        /// Returns a Promise that resolves with the Credential instance that matches the provided parameters.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<T> Get<T>(CredentialGetOptions options) where T : Credential => JSRef.CallAsync<T>("get", options);
        /// <summary>
        /// Returns a Promise that resolves with the PublicKeyCredential or null
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<PublicKeyCredential<AuthenticatorAssertionResponse>?> Get(CredentialGetPublicKeyOptions options) => JSRef.CallAsync<PublicKeyCredential<AuthenticatorAssertionResponse>?>("get", options);
        /// <summary>
        /// Sets a flag that specifies whether automatic log in is allowed for future visits to the current origin, then returns an empty Promise. For example, you might call this, after a user signs out of a website to ensure that they aren't automatically signed in on the next site visit. Earlier versions of the spec called this method requireUserMediation(). See Browser compatibility for support details.
        /// </summary>
        /// <returns></returns>
        public Task PreventSilentAccess() => JSRef.CallVoidAsync("preventSilentAccess");
        /// <summary>
        /// Stores a set of credentials for a user, inside a provided Credential instance and returns that instance in a Promise.
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public Task Store(Credential credentials) => JSRef.CallVoidAsync("store", credentials);
    }
}
