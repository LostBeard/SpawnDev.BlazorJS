namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Used with CredentialGetPublicKeyOptions
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/get#federated_object_structure
    /// </summary>
    public class CredentialGetFederated
    {
        /// <summary>
        /// An array of strings representing the protocols of the requested credentials' federated identity providers (for example, "openidconnect").
        /// </summary>
        public IEnumerable<string> Protocols { get; set; }
        /// <summary>
        /// An array of strings representing the credentials' federated identity providers (for example "https://www.facebook.com" or "https://accounts.google.com").
        /// </summary>
        public IEnumerable<string> Providers { get; set; }
    }
}
