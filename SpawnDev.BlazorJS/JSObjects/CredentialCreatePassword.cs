using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for CredentialsContainer.Create()<br/> 
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#password_object_structure
    /// </summary>
    public class CredentialCreatePassword
    {
        /// <summary>
        /// A string representing the URL of an icon or avatar to be associated with the credential.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? IconURL { get; set; }
        /// <summary>
        /// A string representing a unique ID for the credential.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// A string representing the credential username.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }
        /// <summary>
        /// A string representing the credential's origin. PasswordCredential objects are origin-bound, which means that they will only be usable on the specified origin they were intended to be used on.
        /// </summary>
        public string Origin { get; set; }
        /// <summary>
        /// A string representing the credential password.
        /// </summary>
        public string Password { get; set; }
    }
}
