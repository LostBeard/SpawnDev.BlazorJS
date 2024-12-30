namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// If used for CredentialsContainer.Get()<br/>
    /// an IdentityCredential will be returned
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/get#options
    /// </summary>
    public class CredentialGetIdentityOptions : CredentialGetOptions
    {
        /// <summary>
        /// An object containing details of federated identity providers (IdPs) that a relying party (RP) website can use for purposes such as signing in or signing up on a website. It causes the get() call to initiate a request for a user to sign in to an RP with an IdP. See the Federated Credential Management API section below for more details.
        /// </summary>
        public CredentialRequestOptions? Identity { get; set; }
    }
}
