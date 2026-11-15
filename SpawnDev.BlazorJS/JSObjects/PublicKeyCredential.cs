using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PublicKeyCredential interface provides information about a public key / private key pair, which is a credential for logging in to a service using an un-phishable and data-breach resistant asymmetric key pair instead of a password. It inherits from Credential, and is part of the Web Authentication API extension to the Credential Management API.<br/>
    /// This non-generic class holds the members that do not depend on the response type, including the static WebAuthn JSON
    /// converters (<see cref="ParseCreationOptionsFromJSON(string)"/>, <see cref="ParseRequestOptionsFromJSON(string)"/>) and
    /// <see cref="ToJSON"/> / <see cref="ToJSONString"/>, which exchange options and responses with a server as the standard
    /// base64url JSON (Fido2NetLib, SimpleWebAuthn, py_webauthn ...) without any ArrayBuffer crossing into .NET.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PublicKeyCredential
    /// </summary>
    public class PublicKeyCredential : Credential
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PublicKeyCredential(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An ArrayBuffer that holds the globally unique identifier for this PublicKeyCredential. This identifier can be used to look up credentials for future calls to navigator.credentials.get().
        /// </summary>
        public ArrayBuffer RawId => JSRef!.Get<ArrayBuffer>("rawId");
        /// <summary>
        /// A string that indicates the mechanism by which the WebAuthn implementation is attached to the authenticator at the time the associated navigator.credentials.create() or navigator.credentials.get() call completes.
        /// </summary>
        public string AuthenticatorAttachment => JSRef!.Get<string>("authenticatorAttachment");
        /// <summary>
        /// Returns the JSON-type representation of this credential (RegistrationResponseJSON after create(),
        /// AuthenticationResponseJSON after get()): the binary members encoded as base64url strings, ready to send to a
        /// relying party server.<br/>
        /// https://developer.mozilla.org/en-US/docs/Web/API/PublicKeyCredential/toJSON
        /// </summary>
        public JSObject ToJSON() => JSRef!.Call<JSObject>("toJSON");
        /// <summary>
        /// <see cref="ToJSON"/> as a JSON string (JSON.stringify of the credential), the body to POST to a relying party server.
        /// </summary>
        public string ToJSONString()
        {
            using var json = ToJSON();
            return JS.Call<string>("JSON.stringify", json);
        }
        /// <summary>
        /// Returns a Promise which resolves to true if an authenticator bound to the platform is capable of verifying the user.
        /// </summary>
        /// <returns></returns>
        public static Task<bool> IsUserVerifyingPlatformAuthenticatorAvailable() => JS.CallAsync<bool>("PublicKeyCredential.isUserVerifyingPlatformAuthenticatorAvailable");
        /// <summary>
        /// Returns a Promise which resolves to true if conditional mediation is available.
        /// </summary>
        /// <returns></returns>
        public static Task<bool> IsConditionalMediationAvailable() => JS.CallAsync<bool>("PublicKeyCredential.isConditionalMediationAvailable");
        /// <summary>
        /// True when the browser has the WebAuthn JSON converters: PublicKeyCredential.parseCreationOptionsFromJSON(),
        /// parseRequestOptionsFromJSON() and PublicKeyCredential.prototype.toJSON() (Chrome / Edge 129+, Firefox 119+, Safari 18.4+).
        /// </summary>
        public static bool IsJSONSupported =>
            JS.TypeOf("PublicKeyCredential.parseCreationOptionsFromJSON") == "function"
            && JS.TypeOf("PublicKeyCredential.parseRequestOptionsFromJSON") == "function"
            && JS.TypeOf("PublicKeyCredential.prototype.toJSON") == "function";
        /// <summary>
        /// Converts the JSON form of PublicKeyCredentialCreationOptions (base64url strings for challenge, user.id and
        /// excludeCredentials[].id, as a relying party server sends them) into the options object
        /// navigator.credentials.create() takes, with those members as ArrayBuffers. Pass the result to
        /// <see cref="CredentialsContainer.Create(ParsedPublicKeyCredentialCreationOptions, AbortSignal?)"/>.<br/>
        /// https://developer.mozilla.org/en-US/docs/Web/API/PublicKeyCredential/parseCreationOptionsFromJSON_static
        /// </summary>
        /// <param name="optionsJSON">The options object (an already parsed JSON value)</param>
        public static ParsedPublicKeyCredentialCreationOptions ParseCreationOptionsFromJSON(JSObject optionsJSON) => JS.Call<ParsedPublicKeyCredentialCreationOptions>("PublicKeyCredential.parseCreationOptionsFromJSON", optionsJSON);
        /// <summary>
        /// Converts the JSON string of PublicKeyCredentialCreationOptions (as a relying party server sends it) into the options
        /// object navigator.credentials.create() takes. See <see cref="ParseCreationOptionsFromJSON(JSObject)"/>.
        /// </summary>
        /// <param name="json">The options as a JSON string</param>
        public static ParsedPublicKeyCredentialCreationOptions ParseCreationOptionsFromJSON(string json)
        {
            using var optionsJSON = JS.Call<JSObject>("JSON.parse", json);
            return ParseCreationOptionsFromJSON(optionsJSON);
        }
        /// <summary>
        /// Converts the JSON form of PublicKeyCredentialRequestOptions (base64url strings for challenge and
        /// allowCredentials[].id, as a relying party server sends them) into the options object navigator.credentials.get()
        /// takes. Pass the result to <see cref="CredentialsContainer.Get(ParsedPublicKeyCredentialRequestOptions, string?, AbortSignal?)"/>.<br/>
        /// https://developer.mozilla.org/en-US/docs/Web/API/PublicKeyCredential/parseRequestOptionsFromJSON_static
        /// </summary>
        /// <param name="optionsJSON">The options object (an already parsed JSON value)</param>
        public static ParsedPublicKeyCredentialRequestOptions ParseRequestOptionsFromJSON(JSObject optionsJSON) => JS.Call<ParsedPublicKeyCredentialRequestOptions>("PublicKeyCredential.parseRequestOptionsFromJSON", optionsJSON);
        /// <summary>
        /// Converts the JSON string of PublicKeyCredentialRequestOptions (as a relying party server sends it) into the options
        /// object navigator.credentials.get() takes. See <see cref="ParseRequestOptionsFromJSON(JSObject)"/>.
        /// </summary>
        /// <param name="json">The options as a JSON string</param>
        public static ParsedPublicKeyCredentialRequestOptions ParseRequestOptionsFromJSON(string json)
        {
            using var optionsJSON = JS.Call<JSObject>("JSON.parse", json);
            return ParseRequestOptionsFromJSON(optionsJSON);
        }
    }
    /// <summary>
    /// The PublicKeyCredential interface provides information about a public key / private key pair, which is a credential for logging in to a service using an un-phishable and data-breach resistant asymmetric key pair instead of a password. It inherits from Credential, and is part of the Web Authentication API extension to the Credential Management API.<br/>
    ///
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public class PublicKeyCredential<TResponse> : PublicKeyCredential where TResponse : AuthenticatorResponse
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PublicKeyCredential(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An instance of an AuthenticatorResponse object. It is either of type AuthenticatorAttestationResponse if the PublicKeyCredential was the results of a navigator.credentials.create() call, or of type AuthenticatorAssertionResponse if the PublicKeyCredential was the result of a navigator.credentials.get() call.
        /// </summary>
        public TResponse Response => JSRef!.Get<TResponse>("response");
    }
}
