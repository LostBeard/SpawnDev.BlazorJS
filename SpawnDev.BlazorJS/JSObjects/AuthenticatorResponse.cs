using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AuthenticatorResponse interface of the Web Authentication API is the base interface for interfaces that provide a cryptographic root of trust for a key pair. The child interfaces include information from the browser such as the challenge origin and either may be returned from PublicKeyCredential.response.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AuthenticatorResponse
    /// </summary>
    public class AuthenticatorResponse : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AuthenticatorResponse(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A JSON string in an ArrayBuffer, representing the client data that was passed to CredentialsContainer.create() or CredentialsContainer.get().
        /// </summary>
        public ArrayBuffer ClientDataJSON => JSRef!.Get<ArrayBuffer>("clientDataJSON");
    }
}
