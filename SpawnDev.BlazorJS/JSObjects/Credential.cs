using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Credential interface of the Credential Management API provides information about an entity (usually a user) normally as a prerequisite to a trust decision.<br/>
    /// Credential objects may be of the following types:<br/>
    /// FederatedCredential<br/>
    /// IdentityCredential<br/>
    /// PasswordCredential<br/>
    /// PublicKeyCredential<br/>
    /// OTPCredential
    /// https://developer.mozilla.org/en-US/docs/Web/API/Credential
    /// </summary>
    public class Credential : JSObject
    {
        /// <inheritdoc/>
        public Credential(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a string containing the credential's identifier. This might be any one of a GUID, username, or email address.
        /// </summary>
        public string Id => JSRef!.Get<string>("id");
        /// <summary>
        /// Returns a string containing the credential's type. Valid values are password, federated, public-key, identity and otp. (For PasswordCredential, FederatedCredential, PublicKeyCredential, IdentityCredential and OTPCredential)
        /// </summary>
        public string Type => JSRef!.Get<string>("type");
    }
}
