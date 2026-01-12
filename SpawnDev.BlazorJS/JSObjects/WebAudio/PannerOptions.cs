using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PannerNode/PannerNode#options
    /// https://webaudio.github.io/web-audio-api/#idl-def-PannerOptions
    /// </summary>
    public class PannerOptions
    {
        /// <summary>
        /// The PannerNode.panningModel you want the PannerNode to have (the default is equalpower.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PanningModel { get; set; }
        /// <summary>
        /// The PannerNode.distanceModel you want the PannerNode to have (the default is inverse.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DistanceModel { get; set; }
        /// <summary>
        /// The PannerNode.positionX you want the PannerNode to have (the default is 0.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? PositionX{ get; set; }
        /// <summary>
        /// The PannerNode.positionY you want the PannerNode to have (the default is 0.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? PositionY { get; set; }
        /// <summary>
        /// The PannerNode.positionZ you want the PannerNode to have (the default is 0.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? PositionZ { get; set; }
        /// <summary>
        /// The PannerNode.orientationX you want the PannerNode to have (the default is 1.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? OrientationX { get; set; }
        /// <summary>
        /// The PannerNode.orientationY you want the PannerNode to have (the default is 0.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? OrientationY { get; set; }
        /// <summary>
        /// The PannerNode.orientationZ you want the PannerNode to have (the default is 0.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? OrientationZ { get; set; }
        /// <summary>
        /// The PannerNode.refDistance you want the PannerNode to have. The default is 1, and negative values are not allowed.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? RefDistance { get; set; }
        /// <summary>
        /// The PannerNode.maxDistance you want the PannerNode to have. The default is 10000, and non-positive values are not allowed.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? MaxDistance { get; set; }
        /// <summary>
        /// The PannerNode.rolloffFactor you want the PannerNode to have. The default is 1, and negative values are not allowed.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? RolloffFactor { get; set; }
        /// <summary>
        /// The PannerNode.coneInnerAngle you want the PannerNode to have (the default is 360.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? ConeInnerAngle { get; set; }
        /// <summary>
        /// The PannerNode.coneOuterAngle you want the PannerNode to have (the default is 360.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? ConeOuterAngle { get; set; }
        /// <summary>
        /// The PannerNode.coneOuterGain you want the PannerNode to have. The default is 0, and its value can be in the range 0–1.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? ConeOuterGain { get; set; }
        /// <summary>
        /// Represents an integer used to determine how many channels are used when up-mixing and down-mixing connections to any inputs to the node. (See AudioNode.channelCount for more information.) Its usage and precise definition depend on the value of channelCountMode.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ChannelCount { get; set; }
        /// <summary>
        /// Represents an enumerated value describing the way channels must be matched between the node's inputs and outputs. (See AudioNode.channelCountMode for more information including default values.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ChannelCountMode { get; set; }
        /// <summary>
        /// Represents an enumerated value describing the meaning of the channels. This interpretation will define how audio up-mixing and down-mixing will happen. The possible values are "speakers" or "discrete". (See AudioNode.channelCountMode for more information including default values.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ChannelInterpretation { get; set; }
    }
}
