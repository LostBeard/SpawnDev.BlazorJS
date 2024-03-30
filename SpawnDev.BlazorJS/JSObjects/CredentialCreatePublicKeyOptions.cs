namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// If used for CredentialsContainer.Create()<br />
    /// a PublicKeyCredential will be returned
    /// </summary>
    public class CredentialCreatePublicKeyOptions : CredentialCreateOptions
    {
        /// <summary>
        /// An object containing requirements for creating a public key credential. Causes the create() call to request that the user agent creates new credentials via an authenticator — either for registering a new account or for associating a new asymmetric key pair with an existing account. See the Web Authentication API section below for more details.
        /// </summary>
        public CredentialCreatePublicKey PublicKey { get; set; }
    }
}
