using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AuthenticatorAssertionResponse interface of the Web Authentication API contains a digital signature from the private key of a particular WebAuthn credential. The relying party's server can verify this signature to authenticate a user, for example when they sign in.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/AuthenticatorAssertionResponse
    /// </summary>
    public class AuthenticatorAssertionResponse : AuthenticatorResponse
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AuthenticatorAssertionResponse(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An assertion signature over AuthenticatorAssertionResponse.authenticatorData and AuthenticatorResponse.clientDataJSON. The assertion signature is created with the private key of the key pair that was created during the originating navigator.credentials.create() call and verified using the public key of that same key pair.
        /// </summary>
        public ArrayBuffer Signature => JSRef!.Get<ArrayBuffer>("signature");
        /// <summary>
        /// An ArrayBuffer containing information from the authenticator such as the Relying Party ID Hash (rpIdHash), a signature counter, test of user presence and user verification flags, and any extensions processed by the authenticator.
        /// </summary>
        public ArrayBuffer AuthenticatorData => JSRef!.Get<ArrayBuffer>("authenticatorData");
        /// <summary>
        /// An ArrayBuffer containing an opaque user identifier, specified as user.id in the options passed to the originating navigator.credentials.create() call.
        /// </summary>
        public ArrayBuffer UserHandle => JSRef!.Get<ArrayBuffer>("userHandle");

    }
}
