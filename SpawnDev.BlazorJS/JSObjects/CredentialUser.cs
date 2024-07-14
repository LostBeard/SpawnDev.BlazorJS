namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object describing the user account for which the credential is generated.<br/>
    /// Used for property CredentialCreatePublicKey.User
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#user
    /// </summary>
    public class CredentialUser
    {
        /// <summary>
        /// A string providing a human-friendly user display name (example: "John Doe"), which will have been set by user during initial registration with the relying party.
        /// </summary>
        public string DisplayName { get; set; } = "";
        /// <summary>
        /// An ArrayBuffer, TypedArray, or DataView representing a unique ID for the user account. This value has a maximum length of 64 bytes, and is not intended to be displayed to the user.<br/>
        /// A unique user id of type BufferSource. This value cannot exceed 64 bytes.
        /// </summary>
        public Union<ArrayBuffer, Uint8Array, DataView, byte[]> Id { get; set; }
        /// <summary>
        /// A string providing a human-friendly identifier for the user's account, to help distinguish between different accounts with similar displayNames. This could be an email address (such as "john.doe@example.com"), phone number (for example "+12345678901"), or some other kind of user account identifier (for example "johndoe667").
        /// </summary>
        public string Name { get; set; } = "";
    }
}
