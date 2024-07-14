namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// If used for CredentialsContainer.Get()<br/>
    /// a PasswordCredential will be returned
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/get#options
    /// </summary>
    public class CredentialGetPasswordOptions : CredentialGetOptions
    {
        /// <summary>
        /// A boolean value indicating that a password credential is being requested. See the Credential Management API section below for more details.
        /// </summary>
        public bool Password { get; set; }
    }
}
