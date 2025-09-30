using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRLightEstimate interface of the WebXR Device API provides the estimated lighting values for an XRLightProbe at the time represented by an XRFrame.<br/>
    /// To get an XRLightEstimate object, call the XRFrame.getLightEstimate() method.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRLightEstimate
    /// </summary>
    public class XRLightEstimate : JSObject
    {
        /// <inheritdoc/>
        public XRLightEstimate(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A DOMPointReadOnly (with the x, y, z values mapped to RGB) representing the intensity of the primary light source from the probeSpace of an XRLightProbe.
        /// </summary>
        public DOMPointReadOnly PrimaryLightIntensity => JSRef!.Get<DOMPointReadOnly>("primaryLightIntensity");
        /// <summary>
        /// A DOMPointReadOnly representing the direction to the primary light source from the probeSpace of an XRLightProbe.
        /// </summary>
        public DOMPointReadOnly PrimaryLightDirection => JSRef!.Get<DOMPointReadOnly>("primaryLightDirection");
        /// <summary>
        /// A Float32Array containing 9 spherical harmonics coefficients.
        /// </summary>
        public Float32Array SphericalHarmonicsCoefficients => JSRef!.Get<Float32Array>("sphericalHarmonicsCoefficients");
    }
}
