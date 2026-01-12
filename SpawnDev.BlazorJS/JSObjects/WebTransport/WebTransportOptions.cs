using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebTransportOptions dictionary includes options that can be passed to the WebTransport constructor.
    /// </summary>
    public class WebTransportOptions
    {
        /// <summary>
        /// A boolean indicating whether the connection can be pooled.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AllowPooling { get; set; }

        /// <summary>
        /// A boolean indicating whether the connection requires unreliable transport.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RequireUnreliable { get; set; }

        /// <summary>
        /// A list of server certificate hashes.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<object>? ServerCertificateHashes { get; set; }
    }
}
