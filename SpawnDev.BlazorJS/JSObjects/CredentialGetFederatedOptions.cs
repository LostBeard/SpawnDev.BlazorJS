namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// If used for CredentialsContainer.Get()<br/>
    /// a FederatedCredential will be returned
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/get#options
    /// </summary>
    public class CredentialGetFederatedOptions : CredentialGetOptions
    {
        /// <summary>
        /// An object containing requirements for a requested credential from a federated identify provider. Bear in mind that the Federated Credential Management API (the identity credential type) supersedes this credential type. See the Credential Management API section below for more details.
        /// </summary>
        public CredentialGetFederated Federated { get; set; }
    }
}
