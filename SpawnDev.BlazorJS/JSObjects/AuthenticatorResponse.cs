using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class AuthenticatorAssertionResponse : AuthenticatorResponse
    {
        public AuthenticatorAssertionResponse(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ArrayBuffer Signature => JSRef.Get<ArrayBuffer>("signature");
        public ArrayBuffer AuthenticatorData => JSRef.Get<ArrayBuffer>("authenticatorData");
        public ArrayBuffer UserHandle => JSRef.Get<ArrayBuffer>("userHandle");

    }
    public class AuthenticatorAttestationResponse : AuthenticatorResponse
    {
        public AuthenticatorAttestationResponse(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ArrayBuffer AttestationObject => JSRef.Get<ArrayBuffer>("attestationObject");
        public ArrayBuffer GetAuthenticatorData() => JSRef.Call<ArrayBuffer>("getAuthenticatorData");
        public ArrayBuffer GetPublicKey() => JSRef.Call<ArrayBuffer>("getPublicKey");
        public int GetPublicKeyAlgorithm() => JSRef.Call<int>("getPublicKeyAlgorithm");
        public List<string> GetTransports() => JSRef.Call<List<string>>("getTransports");
    }
    public class AuthenticatorResponse : JSObject
    {
        public AuthenticatorResponse(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A JSON string in an ArrayBuffer, representing the client data that was passed to CredentialsContainer.create() or CredentialsContainer.get().
        /// </summary>
        public ArrayBuffer ClientDataJSON => JSRef.Get<ArrayBuffer>("clientDataJSON");
    }
}
