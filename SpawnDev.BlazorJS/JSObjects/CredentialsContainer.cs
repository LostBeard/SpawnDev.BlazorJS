using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CredentialsContainer interface of the Credential Management API exposes methods to request credentials and notify the user agent when events such as successful sign in or sign out happen. This interface is accessible from Navigator.credentials.<br/>
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
        public Task<Credential> Create() => JSRef!.CallAsync<Credential>("create");
        /// <summary>
        /// Returns a Promise that resolves with a new Credential instance based on the provided options, or null if no Credential object can be created. In exceptional circumstances, the Promise may reject.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<T> Create<T>(CredentialCreateOptions options) where T : Credential => JSRef!.CallAsync<T>("create", options);
        /// <summary>
        /// Returns a Promise that resolves with a new Credential instance based on the provided options, or null if no Credential object can be created. In exceptional circumstances, the Promise may reject.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<PublicKeyCredential<AuthenticatorAttestationResponse>> Create(CredentialCreatePublicKeyOptions options) => JSRef!.CallAsync<PublicKeyCredential<AuthenticatorAttestationResponse>>("create", options);
        /// <summary>
        /// Returns a Promise that resolves with the Credential instance that matches the provided parameters.
        /// </summary>
        /// <returns></returns>
        public Task<Credential?> Get() => JSRef!.CallAsync<Credential?>("get");
        /// <summary>
        /// Returns a Promise that resolves with the Credential instance that matches the provided parameters.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<T> Get<T>(CredentialGetOptions options) where T : Credential => JSRef!.CallAsync<T>("get", options);
        /// <summary>
        /// Returns a Promise that resolves with the PublicKeyCredential or null
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<PublicKeyCredential<AuthenticatorAssertionResponse>?> Get(CredentialGetPublicKeyOptions options) => JSRef!.CallAsync<PublicKeyCredential<AuthenticatorAssertionResponse>?>("get", options);
        /// <summary>
        /// Sets a flag that specifies whether automatic log in is allowed for future visits to the current origin, then returns an empty Promise. For example, you might call this, after a user signs out of a website to ensure that they aren't automatically signed in on the next site visit. Earlier versions of the spec called this method requireUserMediation(). See Browser compatibility for support details.
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// Creates a public key credential from options made by <see cref="PublicKeyCredential.ParseCreationOptionsFromJSON(string)"/>
        /// (the relying party server's JSON). Send <see cref="PublicKeyCredential.ToJSONString"/> of the result back to the server.
        /// </summary>
        /// <param name="publicKey">The parsed creation options</param>
        /// <param name="signal">An optional AbortSignal</param>
        public Task<PublicKeyCredential<AuthenticatorAttestationResponse>> Create(ParsedPublicKeyCredentialCreationOptions publicKey, AbortSignal? signal = null) => Create(new CredentialCreateParsedPublicKeyOptions { PublicKey = publicKey, Signal = signal });
        /// <summary>
        /// Creates a public key credential from options whose publicKey was made by <see cref="PublicKeyCredential.ParseCreationOptionsFromJSON(string)"/>.
        /// </summary>
        public Task<PublicKeyCredential<AuthenticatorAttestationResponse>> Create(CredentialCreateParsedPublicKeyOptions options) => JSRef!.CallAsync<PublicKeyCredential<AuthenticatorAttestationResponse>>("create", options);
        /// <summary>
        /// Gets a public key credential (an assertion) with options made by <see cref="PublicKeyCredential.ParseRequestOptionsFromJSON(string)"/>
        /// (the relying party server's JSON). Send <see cref="PublicKeyCredential.ToJSONString"/> of the result back to the server.
        /// </summary>
        /// <param name="publicKey">The parsed request options</param>
        /// <param name="mediation">Optional mediation: "conditional", "optional", "required" or "silent"</param>
        /// <param name="signal">An optional AbortSignal</param>
        public Task<PublicKeyCredential<AuthenticatorAssertionResponse>?> Get(ParsedPublicKeyCredentialRequestOptions publicKey, string? mediation = null, AbortSignal? signal = null) => Get(new CredentialGetParsedPublicKeyOptions { PublicKey = publicKey, Mediation = mediation, Signal = signal });
        /// <summary>
        /// Gets a public key credential with options whose publicKey was made by <see cref="PublicKeyCredential.ParseRequestOptionsFromJSON(string)"/>.
        /// </summary>
        public Task<PublicKeyCredential<AuthenticatorAssertionResponse>?> Get(CredentialGetParsedPublicKeyOptions options) => JSRef!.CallAsync<PublicKeyCredential<AuthenticatorAssertionResponse>?>("get", options);
        public Task PreventSilentAccess() => JSRef!.CallVoidAsync("preventSilentAccess");
        /// <summary>
        /// Stores a set of credentials for a user, inside a provided Credential instance and returns that instance in a Promise.
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public Task Store(Credential credentials) => JSRef!.CallVoidAsync("store", credentials);
    }
}
