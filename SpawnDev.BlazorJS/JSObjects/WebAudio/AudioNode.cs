using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
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
        /// Returns the associated BaseAudioContext.
        /// </summary>
        public BaseAudioContext Context => JSRef!.Get<BaseAudioContext>("context");
        /// <summary>
        /// Returns the number of inputs feeding the node.
        /// </summary>
        public int NumberOfInputs => JSRef!.Get<int>("numberOfInputs");
        /// <summary>
        /// Returns the number of outputs coming out of the node.
        /// </summary>
        public int NumberOfOutputs => JSRef!.Get<int>("numberOfOutputs");
        /// <summary>
        /// Represents an integer used to determine how many channels are used when up-mixing and down-mixing connections to any inputs to the node.
        /// </summary>
        public int ChannelCount { get => JSRef!.Get<int>("channelCount"); set => JSRef!.Set("channelCount", value); }
        /// <summary>
        /// Represents an enumerated value describing the way channels must be matched between the node's inputs and outputs. Possible values: "max", "clamped-max", "explicit".
        /// </summary>
        public string ChannelCountMode { get => JSRef!.Get<string>("channelCountMode"); set => JSRef!.Set("channelCountMode", value); }
        /// <summary>
        /// Represents an enumerated value describing the meaning of the channels. Possible values: "speakers", "discrete".
        /// </summary>
        public string ChannelInterpretation { get => JSRef!.Get<string>("channelInterpretation"); set => JSRef!.Set("channelInterpretation", value); }
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
