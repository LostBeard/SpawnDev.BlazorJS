using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PublicKeyCredential interface provides information about a public key / private key pair, which is a credential for logging in to a service using an un-phishable and data-breach resistant asymmetric key pair instead of a password. It inherits from Credential, and is part of the Web Authentication API extension to the Credential Management API.<br />
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public class PublicKeyCredential<TResponse> : Credential where TResponse : AuthenticatorResponse
    {
        /// <summary>
        /// Default deserialize constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PublicKeyCredential(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An ArrayBuffer that holds the globally unique identifier for this PublicKeyCredential. This identifier can be used to look up credentials for future calls to navigator.credentials.get().
        /// </summary>
        public ArrayBuffer RawId => JSRef.Get<ArrayBuffer>("rawId");
        /// <summary>
        /// A string that indicates the mechanism by which the WebAuthn implementation is attached to the authenticator at the time the associated navigator.credentials.create() or navigator.credentials.get() call completes.
        /// </summary>
        public string AuthenticatorAttachment => JSRef.Get<string>("authenticatorAttachment");
        /// <summary>
        /// An instance of an AuthenticatorResponse object. It is either of type AuthenticatorAttestationResponse if the PublicKeyCredential was the results of a navigator.credentials.create() call, or of type AuthenticatorAssertionResponse if the PublicKeyCredential was the result of a navigator.credentials.get() call.
        /// </summary>
        public TResponse Response => JSRef.Get<TResponse>("response");
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
    }
}
