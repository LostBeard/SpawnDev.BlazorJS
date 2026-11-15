using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A PublicKeyCredentialCreationOptions object made by the browser from its JSON form
    /// (<see cref="PublicKeyCredential.ParseCreationOptionsFromJSON(string)"/>): challenge, user.id and excludeCredentials[].id
    /// are ArrayBuffers that stay in Javascript. Pass it to
    /// <see cref="CredentialsContainer.Create(ParsedPublicKeyCredentialCreationOptions, AbortSignal?)"/>.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PublicKeyCredentialCreationOptions
    /// </summary>
    public class ParsedPublicKeyCredentialCreationOptions : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ParsedPublicKeyCredentialCreationOptions(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The challenge (decoded from base64url).
        /// </summary>
        public ArrayBuffer Challenge => JSRef!.Get<ArrayBuffer>("challenge");
    }
    /// <summary>
    /// A PublicKeyCredentialRequestOptions object made by the browser from its JSON form
    /// (<see cref="PublicKeyCredential.ParseRequestOptionsFromJSON(string)"/>): challenge and allowCredentials[].id are
    /// ArrayBuffers that stay in Javascript. Pass it to
    /// <see cref="CredentialsContainer.Get(ParsedPublicKeyCredentialRequestOptions, string?, AbortSignal?)"/>.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PublicKeyCredentialRequestOptions
    /// </summary>
    public class ParsedPublicKeyCredentialRequestOptions : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ParsedPublicKeyCredentialRequestOptions(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The challenge (decoded from base64url).
        /// </summary>
        public ArrayBuffer Challenge => JSRef!.Get<ArrayBuffer>("challenge");
    }
    /// <summary>
    /// Options for CredentialsContainer.Create() with a publicKey made by
    /// <see cref="PublicKeyCredential.ParseCreationOptionsFromJSON(string)"/>.
    /// </summary>
    public class CredentialCreateParsedPublicKeyOptions : CredentialCreateOptions
    {
        /// <summary>
        /// The public key creation options, as parsed by the browser
        /// </summary>
        public ParsedPublicKeyCredentialCreationOptions? PublicKey { get; set; }
    }
    /// <summary>
    /// Options for CredentialsContainer.Get() with a publicKey made by
    /// <see cref="PublicKeyCredential.ParseRequestOptionsFromJSON(string)"/>.
    /// </summary>
    public class CredentialGetParsedPublicKeyOptions : CredentialGetOptions
    {
        /// <summary>
        /// The public key request options, as parsed by the browser
        /// </summary>
        public ParsedPublicKeyCredentialRequestOptions? PublicKey { get; set; }
    }
}
