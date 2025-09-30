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
        /// <param name="context"></param>
        /// <param name="options">TODO</param>
        public PannerNode(BaseAudioContext context, object options) : base(JS.New(nameof(PannerNode), context, options)) { }
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
    /// <summary>
    /// The AudioNode interface is a generic interface for representing an audio processing module.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioNode
    /// </summary>
    public class AudioNode : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AudioNode(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// The connect() method of the AudioNode interface lets you connect one of the node's outputs to a target, which may be either another AudioNode (thereby directing the sound data to the specified node) or an AudioParam, so that the node's output data is automatically used to change the value of that parameter over time.
        /// </summary>
        /// <returns></returns>
        public AudioNode Connect(AudioNode audioNode) => JSRef!.Call<AudioNode>("connect", audioNode);
        /// <summary>
        /// The connect() method of the AudioNode interface lets you connect one of the node's outputs to a target, which may be either another AudioNode (thereby directing the sound data to the specified node) or an AudioParam, so that the node's output data is automatically used to change the value of that parameter over time.
        /// </summary>
        /// <param name="audioParam"></param>
        public void Connect(AudioParam audioParam) => JSRef!.CallVoid("connect", audioParam);
        /// <summary>        
        /// Allows us to disconnect the current node from another one it is already connected to.
        /// </summary>
        public void Disconnect() => JSRef!.CallVoid("disconnect");
        /// <summary>
        /// Allows us to disconnect the current node from another one it is already connected to.
        /// </summary>
        /// <param name="audioNode"></param>
        /// <returns></returns>
        public void Disconnect(AudioNode audioNode) => JSRef!.CallVoid("disconnect", audioNode);
        /// <summary>
        /// Allows us to disconnect the current node from another one it is already connected to.
        /// </summary>
        /// <param name="audioParam"></param>
        public void Disconnect(AudioParam audioParam) => JSRef!.CallVoid("disconnect", audioParam);
    }
}
