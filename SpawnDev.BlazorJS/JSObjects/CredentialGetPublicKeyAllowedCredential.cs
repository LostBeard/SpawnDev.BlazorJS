using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Used in CredentialGetPublicKey<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/get#allowcredentials
    /// </summary>
    public class CredentialGetPublicKeyAllowedCredential
    {
        /// <summary>
        /// An ArrayBuffer, TypedArray, or DataView representing the ID of the public key credential to retrieve. This value is mirrored by the rawId property of the PublicKeyCredential object returned by a successful get() call.
        /// </summary>
        public Union<ArrayBuffer, TypedArray, DataView, byte[]> Id { get; set; }
        /// <summary>
        /// An array of strings providing hints as to the methods the client could use to communicate with the relevant authenticator of the public key credential to retrieve. Possible transports are:<br />
        /// "ble", "hybrid", "internal", "nfc", and "usb".<br />
        /// Note: This value is mirrored by the return value of the PublicKeyCredential.response.getTransports() method of the PublicKeyCredential object returned by the create() call that originally created the credential. At that point, it should be stored by the app for later use.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Transports { get; set; } = new List<string> { "ble", "hybrid", "internal", "nfc", "usb" };
        /// <summary>
        /// A string defining the type of the public key credential to retrieve. This can currently take a single value, "public-key", but more values may be added in the future. This value is mirrored by the type property of the PublicKeyCredential object returned by a successful get() call.
        /// </summary>
        public string Type { get; set; } = "public-key";
    }
}
