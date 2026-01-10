using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PannerNode interface defines an audio-processing object that represents the location, direction, and behavior of an audio source signal in a simulated physical space. This AudioNode uses right-hand Cartesian coordinates to describe the source's position as a vector and its orientation as a 3D directional cone.<br/>
    /// A PannerNode always has exactly one input and one output: the input can be mono or stereo but the output is always stereo (2 channels); you can't have panning effects without at least two audio channels!<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PannerNode
    /// </summary>
    public class PannerNode : AudioNode
    {
        /// <inheritdoc/>
        public PannerNode(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The PannerNode() constructor of the Web Audio API creates a new PannerNode object instance.
        /// </summary>
        /// <param name="context"></param>
        public PannerNode(BaseAudioContext context) : base(JS.New(nameof(PannerNode), context)) { }
        /// <summary>
        /// The PannerNode() constructor of the Web Audio API creates a new PannerNode object instance.
        /// </summary>
        /// <param name="context">A BaseAudioContext representing the audio context you want the node to be associated with.</param>
        /// <param name="options">PannerOptions</param>
        public PannerNode(BaseAudioContext context, PannerOptions options) : base(JS.New(nameof(PannerNode), context, options)) { }
        /// <summary>
        /// A double value describing the angle, in degrees, of a cone inside of which there will be no volume reduction.
        /// </summary>
        public double ConeInnerAngle { get => JSRef!.Get<double>("coneInnerAngle"); set => JSRef!.Set("coneInnerAngle", value); }
        /// <summary>
        /// A double value describing the angle, in degrees, of a cone outside of which the volume will be reduced by a constant value, defined by the coneOuterGain property.
        /// </summary>
        public double ConeOuterAngle { get => JSRef!.Get<double>("coneInnerAngle"); set => JSRef!.Set("coneOuterAngle", value); }
        /// <summary>
        /// A double value describing the amount of volume reduction outside the cone defined by the coneOuterAngle attribute. Its default value is 0, meaning that no sound can be heard.
        /// </summary>
        public double ConeOuterGain { get => JSRef!.Get<double>("coneOuterGain"); set => JSRef!.Set("coneOuterGain", value); }
        /// <summary>
        /// An enumerated value determining which algorithm to use to reduce the volume of the audio source as it moves away from the listener. Possible values are "linear", "inverse" and "exponential". The default value is "inverse".
        /// </summary>
        public string DistanceModel { get => JSRef!.Get<string>("distanceModel"); set => JSRef!.Set("distanceModel", value); }
        /// <summary>
        /// A double value representing the maximum distance between the audio source and the listener, after which the volume is not reduced any further.
        /// </summary>
        public double MaxDistance { get => JSRef!.Get<double>("maxDistance"); set => JSRef!.Set("maxDistance", value); }
        /// <summary>
        /// Represents the horizontal position of the audio source's vector in a right-hand Cartesian coordinate system. While this AudioParam cannot be directly changed, its value can be altered using its value property. The default is value is 1.
        /// </summary>
        public AudioParam OrientationX => JSRef!.Get<AudioParam>("orientationX");
        /// <summary>
        /// Represents the vertical position of the audio source's vector in a right-hand Cartesian coordinate system. The default is 0. While this AudioParam cannot be directly changed, its value can be altered using its value property. The default is value is 0.
        /// </summary>
        public AudioParam OrientationY => JSRef!.Get<AudioParam>("orientationY");
        /// <summary>
        /// Represents the longitudinal (back and forth) position of the audio source's vector in a right-hand Cartesian coordinate system. The default is 0. While this AudioParam cannot be directly changed, its value can be altered using its value property. The default is value is 0.
        /// </summary>
        public AudioParam OrientationZ => JSRef!.Get<AudioParam>("orientationZ");
        /// <summary>
        /// An enumerated value determining which spatialization algorithm to use to position the audio in 3D space.
        /// </summary>
        public string PanningModel { get => JSRef!.Get<string>("panningModel"); set => JSRef!.Set("panningModel", value); }
        /// <summary>
        /// Represents the horizontal position of the audio in a right-hand Cartesian coordinate system. The default is 0. While this AudioParam cannot be directly changed, its value can be altered using its value property. The default is value is 0.
        /// </summary>
        public AudioParam PositionX => JSRef!.Get<AudioParam>("positionX");
        /// <summary>
        /// Represents the vertical position of the audio in a right-hand Cartesian coordinate system. The default is 0. While this AudioParam cannot be directly changed, its value can be altered using its value property. The default is value is 0.
        /// </summary>
        public AudioParam PositionY => JSRef!.Get<AudioParam>("positionY");
        /// <summary>
        /// Represents the longitudinal (back and forth) position of the audio in a right-hand Cartesian coordinate system. The default is 0. While this AudioParam cannot be directly changed, its value can be altered using its value property. The default is value is 0.
        /// </summary>
        public AudioParam PositionZ => JSRef!.Get<AudioParam>("positionZ");
        /// <summary>
        /// A double value representing the reference distance for reducing volume as the audio source moves further from the listener. For distances greater than this the volume will be reduced based on rolloffFactor and distanceModel.
        /// </summary>
        public double RefDistance { get => JSRef!.Get<double>("refDistance"); set => JSRef!.Set("refDistance", value); }
        /// <summary>
        /// A double value describing how quickly the volume is reduced as the source moves away from the listener. This value is used by all distance models.
        /// </summary>
        public double RolloffFactor { get => JSRef!.Get<double>("rolloffFactor"); set => JSRef!.Set("rolloffFactor", value); }
    }
}
