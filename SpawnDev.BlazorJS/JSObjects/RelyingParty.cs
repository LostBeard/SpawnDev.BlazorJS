using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object describing the relying party that requested the credential creation.<br/>
    /// Used for property CredentialCreatePublicKey.Rp<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#rp
    /// </summary>
    public class RelyingParty
    {
        /// <summary>
        /// A string representing the name of the relying party (e.g. "Facebook"). This is the name the user will be presented with when creating or validating a WebAuthn operation.
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// A string representing the ID of the relying party. A public key credential can only be used for authentication with the same relying party (as identified by the publicKey.rpId in a navigator.credentials.get() call) it was registered with — the IDs need to match.<br/>
        /// The id cannot include a port or scheme like a standard origin, but the domain scheme must be https scheme. The id needs to equal the origin's effective domain, or a domain suffix thereof. So for example if the relying party's origin is https://login.example.com:1337, the following ids are valid:<br/>
        /// login.example.com<br/>
        /// example.com<br/>
        /// But not:<br/>
        /// m.login.example.com,br />
        /// com<br/>
        /// If omitted, id defaults to the document origin — which would be login.example.com in the above example.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }
    }
}
