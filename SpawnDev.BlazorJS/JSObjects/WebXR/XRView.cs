using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRView
    /// </summary>
    public class XRView : JSObject
    {
        /// <inheritdoc/>
        public XRView(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Which of the two eyes (left) or (right) for which this XRView represents the perspective. This value is used to ensure that any content which is pre-rendered for presenting to a specific eye is distributed or positioned correctly. The value can also be none if the XRView is presenting monoscopic data (such as a 2D image, a fullscreen view of text, or a close-up view of something that doesn't need to appear in 3D).
        /// </summary>
        public string Eye => JSRef!.Get<string>("eye");
        /// <summary>
        /// An XRRigidTransform which describes the current position and orientation of the viewpoint in relation to the XRReferenceSpace specified when getViewerPose() was called on the XRFrame being rendered.
        /// </summary>
        public XRRigidTransform Transform => JSRef!.Get<XRRigidTransform>("transform");
        /// <summary>
        /// The projection matrix that will transform the scene to appear correctly given the point-of-view indicated by eye. This matrix should be used directly in order to avoid presentation distortions that may lead to potentially serious user discomfort.
        /// </summary>
        public Float32Array ProjectionMatrix => JSRef!.Get<Float32Array>("projectionMatrix");

        // TODO
    }
}
