namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// If used for CredentialsContainer.Create()<br />
    /// a FederatedCredential will be returned
    /// </summary>
    public class CredentialCreateFederatedOptions : CredentialCreateOptions
    {
        /// <summary>
        /// An object containing requirements for creating a federated identify provider credential. Bear in mind that the Federated Credential Management API (FedCM) supersedes this credential type. See the Credential Management API section below for more details.
        /// </summary>
        public CredentialCreateFederated Federated { get; set; }
    }
}
