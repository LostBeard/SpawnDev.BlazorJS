namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// If used for CredentialsContainer.Get()<br/>
    /// a PublicKeyCredential will be returned
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/get#options
    /// </summary>
    public class CredentialGetPublicKeyOptions : CredentialGetOptions
    {
        /// <summary>
        /// An object containing requirements for returned public key credentials. Causes the get() call to use an existing set of public key credentials to authenticate to a relying party. See the Web Authentication API section below for more details.
        /// </summary>
        public CredentialGetPublicKey PublicKey { get; set; }
    }
}
