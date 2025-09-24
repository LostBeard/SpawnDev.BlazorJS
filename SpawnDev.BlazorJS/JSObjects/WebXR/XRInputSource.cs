using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebXR Device API's XRInputSource interface describes a single source of control input which is part of the user's WebXR-compatible virtual or augmented reality system. The device is specific to the platform being used, but provides the direction in which it is being aimed and optionally may generate events if the user triggers performs actions using the device.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRInputSource
    /// </summary>
    public class XRInputSource : JSObject
    {
        /// <inheritdoc/>
        public XRInputSource(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A Gamepad object describing the state of the buttons and axes on the XR input source, if it is a gamepad or comparable device. If the device isn't a gamepad-like device, this property's value is null.
        /// </summary>
        public Gamepad? Gamepad => JSRef!.Get<Gamepad?>("gamepad");
        /// <summary>
        /// An XRHand object providing access to the underlying hand-tracking device.
        /// </summary>
        public XRHand? Hand => JSRef!.Get<XRHand?>("hand");
        /// <summary>
        /// A string that indicates which hand the device represented by this XRInputSource is being used in, if any. The value will be left, right, or none.
        /// </summary>
        public string Handedness => JSRef!.Get<string>("handedness");
        /// <summary>
        /// An array of strings, each specifying the name of an input profile describing the preferred visual representation and behavior of this input source.
        /// </summary>
        public string[] Profiles => JSRef!.Get<string[]>("profiles");
        /// <summary>
        /// A string indicating the methodology used to produce the target ray: gaze, tracked-pointer, or screen.
        /// </summary>
        public string TargetRayMode => JSRef!.Get<string>("targetRayMode");
        /// <summary>
        /// An XRSpace object defining the origin of the target ray and the direction in which it extends. This space is established using the method defined by targetRayMode.
        /// </summary>
        public XRSpace? TargetRaySpace => JSRef!.Get<XRSpace?>("targetRaySpace");
    }
}
