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
        /// 
        /// </summary>
        /// <param name="audioParam"></param>
        public void Disconnect(AudioParam audioParam) => JSRef!.CallVoid("disconnect", audioParam);
    }
}
