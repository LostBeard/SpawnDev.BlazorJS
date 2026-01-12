using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRSession interface of the WebXR Device API represents an ongoing XR session, providing methods and properties used to interact with and control the session. To open a WebXR session, use the XRSystem interface's requestSession() method.<br/>
    /// https://www.w3.org/TR/webxr/#xrsession
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRSession
    /// </summary>
    public class XRSession : EventTarget
    {
        /// <inheritdoc/>
        public XRSession(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the depth-sensing data format with which the session was configured.
        /// </summary>
        public string DepthDataFormat => JSRef!.Get<string>("depthDataFormat");
        /// <summary>
        /// Returns the depth-sensing usage with which the session was configured
        /// </summary>
        public string DepthUsage => JSRef!.Get<string>("depthUsage");
        /// <summary>
        /// Provides information about the DOM overlay, if the feature is enabled.
        /// </summary>
        public XRDOMOverlayState? DomOverlayState => JSRef!.Get<XRDOMOverlayState?>("domOverlayState");
        /// <summary>
        /// Returns an array of granted session features.
        /// </summary>
        public string[] EnabledFeatures => JSRef!.Get<string[]>("enabledFeatures");
        /// <summary>
        /// Returns this session's blend mode which denotes how much of the real-world environment is visible through the XR device and how the device will blend the device imagery with it.
        /// </summary>
        public string EnvironmentBlendMode => JSRef!.Get<string>("environmentBlendMode");
        /// <summary>
        /// Returns this session's preferred reflection format used for lighting estimation texture data.
        /// </summary>
        public string PreferredReflectionFormat => JSRef!.Get<string>("preferredReflectionFormat");
        /// <summary>
        /// Returns a list of this session's XRInputSources, each representing an input device used to control the camera and/or scene.
        /// </summary>
        public Array<XRInputSource> InputSources => JSRef!.Get<Array<XRInputSource>>("inputSources");
        /// <summary>
        /// Returns this session's interaction mode, which describes the best space (according to the user agent) for the application to draw interactive UI for the current session.
        /// </summary>
        public string InteractionMode => JSRef!.Get<string>("interactionMode");
        /// <summary>
        /// An XRRenderState object which contains options affecting how the imagery is rendered. This includes things such as the near and far clipping planes (distances defining how close and how far away objects can be and still get rendered), as well as field of view information.
        /// </summary>
        public XRRenderState RenderState => JSRef!.Get<XRRenderState>("renderState");
        /// <summary>
        /// A string indicating whether or not the session's imagery is visible to the user, and if so, if it's being visible but not currently the target for user events.
        /// </summary>
        public string VisibilityState => JSRef!.Get<string>("visibilityState");
        /// <summary>
        /// Ends the WebXR session. Returns a promise which resolves when the session has been shut down.
        /// </summary>
        public Task End() => JSRef!.CallVoidAsync("end");
        /// <summary>
        /// The cancelAnimationFrame() method of the XRSession interface cancels an animation frame which was previously requested by calling requestAnimationFrame.
        /// </summary>
        /// <param name="handle"></param>
        public void CancelAnimationFrame(long handle) => JSRef!.CallVoid("cancelAnimationFrame", handle);
        /// <summary>
        /// Schedules the specified method to be called the next time the user agent is working on rendering an animation frame for the WebXR device. Returns an integer value which can be used to identify the request for the purposes of canceling the callback using cancelAnimationFrame(). This method is comparable to the Window.requestAnimationFrame() method.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public long RequestAnimationFrame(Action<double, XRFrame?> callback) => JSRef!.Call<long>("requestAnimationFrame", Callback.CreateOne(callback));
        /// <summary>
        /// Schedules the specified method to be called the next time the user agent is working on rendering an animation frame for the WebXR device. Returns an integer value which can be used to identify the request for the purposes of canceling the callback using cancelAnimationFrame(). This method is comparable to the Window.requestAnimationFrame() method.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public long RequestAnimationFrame(ActionCallback<double, XRFrame?> callback) => JSRef!.Call<long>("requestAnimationFrame", callback);
        /// <summary>
        /// Requests an XRHitTestSource object that handles hit test subscription.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<XRHitTestSource> RequestHitTestSource(XRHitTestOptionsInit options) => JSRef!.CallAsync<XRHitTestSource>("requestHitTestSource", options);
        /// <summary>
        /// The requestHitTestSourceForTransientInput() method of the XRSession interface returns a Promise that resolves with an XRTransientInputHitTestSource object that can be passed to XRFrame.getHitTestResultsForTransientInput().
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<XRTransientInputHitTestSource> RequestHitTestSourceForTransientInput(XRTransientInputHitTestOptionsInit options) => JSRef!.CallAsync<XRTransientInputHitTestSource>("requestHitTestSourceForTransientInput", options);
        /// <summary>
        /// The requestLightProbe() method of the XRSession interface returns a Promise that resolves with an XRLightProbe object that estimates lighting information at a given point in the user's environment.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<XRLightProbe> RequestLightProbe(XRLightProbeInit? options = null)
            => options == null ? JSRef!.CallAsync<XRLightProbe>("requestLightProbe") : JSRef!.CallAsync<XRLightProbe>("requestLightProbe", options);
        /// <summary>
        /// Requests that a new XRReferenceSpace of the specified type be created. Returns a promise which resolves with the XRReferenceSpace or XRBoundedReferenceSpace which was requested, or throws a NotSupportedError DOMException if the requested space type isn't supported by the device.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Task<XRReferenceSpace> RequestReferenceSpace(EnumString<XRReferenceSpaceType> type) => JSRef!.CallAsync<XRReferenceSpace>("requestReferenceSpace", type);
        /// <summary>
        /// Updates the properties of the session's render state.
        /// </summary>
        /// <param name="state"></param>
        public void UpdateRenderState(XRRenderStateInit? state = null)
        {
            if (state == null) JSRef!.CallVoid("updateRenderState");
            else JSRef!.CallVoid("updateRenderState", state);
        }
        /// <summary>
        /// An end event is fired at an XRSession object when the WebXR session has ended, either because the web application has chosen to stop the session, or because the user agent terminated the session.
        /// </summary>
        public ActionEvent<XRSessionEvent> OnEnd { get => new ActionEvent<XRSessionEvent>("end", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The inputsourceschange event is sent to an XRSession when the set of available WebXR input devices changes.
        /// </summary>
        public ActionEvent<XRInputSourcesChangeEvent> OnInputSourcesChange { get => new ActionEvent<XRInputSourcesChangeEvent>("inputsourceschange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// An event of type XRInputSourceEvent which is sent to the session when one of the session's input sources has successfully completed a primary action. This generally corresponds to the user pressing a trigger, touchpad, or button, speaks a command, or performs a recognizable gesture. The select event is sent after the selectstart event is sent and immediately before the selectend event is sent. If select is not sent, then the select action was aborted before being completed. Also available through the onselect event handler property.
        /// </summary>
        public ActionEvent<XRInputSourceEvent> OnSelect { get => new ActionEvent<XRInputSourceEvent>("select", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// An event of type XRInputSourceEvent which gets sent to the session object when one of its input devices finishes its primary action or gets disconnected while in the process of handling a primary action. For example: for button or trigger actions, this means the button has been released; for spoken commands, it means the user has finished speaking. This is the last of the three select* events to be sent. Also available through the onselectend event handler property.
        /// </summary>
        public ActionEvent<XRInputSourceEvent> OnSelectEnd { get => new ActionEvent<XRInputSourceEvent>("selectend", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// An event of type XRInputSourceEvent which is sent to the session object when one of its input devices is first engaged by the user in such a way as to cause the primary action to begin. This is the first of the session* event to be sent. Also available through the onselectstart event handler property.
        /// </summary>
        public ActionEvent<XRInputSourceEvent> OnSelectStart { get => new ActionEvent<XRInputSourceEvent>("selectstart", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// An XRInputSourceEvent sent to indicate that a primary squeeze action has successfully completed. This indicates that the device being squeezed has been released, and may represent dropping a grabbed object, for example. It is sent immediately before the squeezeend event is sent to indicate that the squeeze action is over. Also available through the onsqueeze event handler property.
        /// </summary>
        public ActionEvent<XRInputSourceEvent> OnSqueeze { get => new ActionEvent<XRInputSourceEvent>("squeeze", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// An XRInputSourceEvent sent to the XRSession when the primary squeeze action ends, whether or not the action was successful. Also available using the onsqueezeend event handler property.
        /// </summary>
        public ActionEvent<XRInputSourceEvent> OnSqueezeEnd { get => new ActionEvent<XRInputSourceEvent>("squeezeend", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// An event of type XRInputSourceEvent which is sent to the XRSession when the user initially squeezes a squeezable controller. This may be, for example, a trigger which is used to represent grabbing objects, or might represent actual squeezing when wearing a haptic glove. Also available through the onsqueezestart event handler property.
        /// </summary>
        public ActionEvent<XRInputSourceEvent> OnSqueezeStart { get => new ActionEvent<XRInputSourceEvent>("squeezestart", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// An XRSessionEvent which is sent to the session when its visibility state as indicated by the visibilityState changes. Also available through the onvisibilitychange event handler property.
        /// </summary>
        public ActionEvent<XRSessionEvent> OnVisibilityChange { get => new ActionEvent<XRSessionEvent>("visibilitychange", AddEventListener, RemoveEventListener); set { } }
    }
}
