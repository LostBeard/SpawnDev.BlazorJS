namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// If used for CredentialsContainer.Create()<br />
    /// a PasswordCredential will be returned
    /// </summary>
    public class CredentialCreatePasswordOptions : CredentialCreateOptions
    {
        /// <summary>
        /// An object containing requirements for creating a password credential. See the Credential Management API section below for more details.
        /// </summary>
        public CredentialCreatePassword Password { get; set; }
    }
}
