using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// Parameters for a single codec that could be used to encode the track's media.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCRtpSender/setParameters#encodings
    /// </summary>
    public class RTCMediaEncoding
    {
        /// <summary>
        /// Setting this value true (the default) causes this encoding to be sent, while false stops it from being sent and used (but does not cause the SSRC to be removed).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Active { get;set; }
        /// <summary>
        /// A positive integer indicating the maximum number of bits per second that the user agent is allowed to grant to tracks encoded with this encoding. Other parameters may further constrain the bit rate, such as the value of maxFramerate, or the bandwidth available for the transport or physical network.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxBitrate{ get; set; }
        /// <summary>
        /// A value specifying the maximum number of frames per second to allow for this encoding.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxFramerate { get; set; }
        /// <summary>
        /// A string indicating the priority of the RTCRtpSender, which may determine how the user agent allocates bandwidth between senders. Allowed values are very-low, low (default), medium, high.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Priority { get; set; }
        /// <summary>
        /// A string which, if set, specifies an RTP stream ID (RID) to be sent using the RID header extension. This parameter cannot be modified using setParameters(). Its value can only be set when the transceiver is first created.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Rid{ get; set; }
        /// <summary>
        /// Only used for senders whose track's kind is video, this is a floating-point value specifying a factor by which to scale down the video during encoding. The default value, 1.0, means that the video will be encoded at its original size. A value of 2.0 scales the video frames down by a factor of 2 in each dimension, resulting in a video 1/4 the size of the original. The value must not be less than 1.0 (attempting to scale the video to a larger size will throw a RangeError).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? ScaleResolutionDownBy { get; set; }
    }
}
