using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The InputDeviceInfo interface of the Media Capture and Streams API gives access to the capabilities of the input device that it represents.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/InputDeviceInfo
    /// </summary>
    public class InputDeviceInfo : MediaDeviceInfo
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public InputDeviceInfo(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a MediaTrackCapabilities object describing the primary audio or video track of a device's MediaStream.
        /// </summary>
        public MediaTrackCapabilities GetCapabilities() => JSRef!.Call<MediaTrackCapabilities>("getCapabilities");
    }
}
