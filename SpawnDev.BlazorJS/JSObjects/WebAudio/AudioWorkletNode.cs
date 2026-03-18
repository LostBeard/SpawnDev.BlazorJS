using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AudioWorkletNode interface of the Web Audio API represents a base class for a user-defined AudioNode, which can be connected to an audio routing graph along with other nodes.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioWorkletNode
    /// </summary>
    public class AudioWorkletNode : AudioNode
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AudioWorkletNode(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new AudioWorkletNode object.
        /// </summary>
        /// <param name="context">The BaseAudioContext instance this node will be associated with.</param>
        /// <param name="name">A string that represents the name of the AudioWorkletProcessor this node will be based on.</param>
        public AudioWorkletNode(BaseAudioContext context, string name) : base(JS.New(nameof(AudioWorkletNode), context, name)) { }
        /// <summary>
        /// Creates a new AudioWorkletNode object.
        /// </summary>
        /// <param name="context">The BaseAudioContext instance this node will be associated with.</param>
        /// <param name="name">A string that represents the name of the AudioWorkletProcessor this node will be based on.</param>
        /// <param name="options">An object containing options for the AudioWorkletNode.</param>
        public AudioWorkletNode(BaseAudioContext context, string name, AudioWorkletNodeOptions options) : base(JS.New(nameof(AudioWorkletNode), context, name, options)) { }
        /// <summary>
        /// Returns a MessagePort used for bidirectional communication between the node and its associated AudioWorkletProcessor.
        /// </summary>
        public MessagePort Port => JSRef!.Get<MessagePort>("port");
        /// <summary>
        /// Returns an object containing AudioParam objects for each of the custom parameters defined in the processor.
        /// </summary>
        public JSObject Parameters => JSRef!.Get<JSObject>("parameters");
        /// <summary>
        /// Fired when the AudioWorkletProcessor behind the node throws an error.
        /// </summary>
        public ActionEvent<Event> OnProcessorError { get => new ActionEvent<Event>("processorerror", AddEventListener, RemoveEventListener); set { } }
    }

    /// <summary>
    /// Options for creating an AudioWorkletNode.
    /// </summary>
    public class AudioWorkletNodeOptions
    {
        /// <summary>
        /// The value to initialize the numberOfInputs property. Defaults to 1.
        /// </summary>
        public int? NumberOfInputs { get; set; }
        /// <summary>
        /// The value to initialize the numberOfOutputs property. Defaults to 1.
        /// </summary>
        public int? NumberOfOutputs { get; set; }
        /// <summary>
        /// An array defining the number of channels for each output.
        /// </summary>
        public int[]? OutputChannelCount { get; set; }
        /// <summary>
        /// An object containing the initial values of custom AudioParam objects on this node (as defined in the processor's parameterDescriptors static getter).
        /// </summary>
        public Dictionary<string, double>? ParameterData { get; set; }
        /// <summary>
        /// Any additional data that can be used for custom initialization of the underlying AudioWorkletProcessor.
        /// </summary>
        public object? ProcessorOptions { get; set; }
    }
}
