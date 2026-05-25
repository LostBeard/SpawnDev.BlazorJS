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
        public List<WebTransportHash>? ServerCertificateHashes { get; set; }

        /// <summary>
        /// A string indicating the application's preference that the congestion control algorithm used when sending data over this connection be tuned for either throughput or low-latency. This is a hint to the user agent. The allowed values are: default (default), throughput, and low-latency.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CongestionControl { get; set; }
    }
}
