using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebXR Device API interface XRSystem provides methods which let you get access to an XRSession object representing a WebXR session. With that XRSession in hand, you can use it to interact with the Augmented Reality (AR) or Virtual Reality (VR) device.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRSystem<br/>
    /// https://www.w3.org/TR/webxr/#xrsystem-interface
    /// </summary>
    public class XRSystem : EventTarget
    {
        /// <inheritdoc/>
        public XRSystem(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The isSessionSupported(mode) method queries if a given mode may be supported by the user agent and device capabilities.
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public Task<bool> IsSessionSupported(EnumString<XRSessionMode> mode) => JSRef!.CallAsync<bool>("isSessionSupported", mode);
        /// <summary>
        /// The requestSession(mode, options) method attempts to initialize an XRSession for the given mode if possible, entering immersive mode if necessary.
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<XRSession> RequestSession(EnumString<XRSessionMode> mode, XRSessionInit? options = null)
            => options == null ? JSRef!.CallAsync<XRSession>("requestSession", mode) : JSRef!.CallAsync<XRSession>("requestSession", mode, options);
        /// <summary>
        /// A devicechange event is fired on an XRSystem object whenever the availability of immersive XR devices has changed; for example, a VR headset or AR goggles have been connected or disconnected. It's a generic Event with no added properties.
        /// </summary>
        public ActionEvent<Event> OnDeviceChange { get => new ActionEvent<Event>("devicechange", AddEventListener, RemoveEventListener); set { } }
    }
}
