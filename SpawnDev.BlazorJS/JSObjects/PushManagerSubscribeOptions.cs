using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for PushManager.Subscribe
    /// </summary>
    public class PushManagerSubscribeOptions
    {
        /// <summary>
        /// A boolean indicating that the returned push subscription will only be used for messages whose effect is made visible to the user
        /// </summary>
        public bool UserVisibleOnly { get; set; }

        /// <summary>
        /// A Base64-encoded string or ArrayBuffer containing an ECDSA P-256 public key that the push server will use to authenticate your application server. If specified, all messages from your application server must use the VAPID authentication scheme, and include a JWT signed with the corresponding private key. This key IS NOT the same ECDH key that you use to encrypt the data. For more information, see "Using VAPID with WebPush"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ApplicationServerKey { get; set; }
    }
}
