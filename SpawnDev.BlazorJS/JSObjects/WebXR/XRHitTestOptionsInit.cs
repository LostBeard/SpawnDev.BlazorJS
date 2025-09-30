using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An XRHitTestOptionsInit dictionary represents a set of configurable values that affect the behavior of the hit test being performed.<br/>
    /// https://www.w3.org/TR/webxr-hit-test-1/#dictdef-xrhittestoptionsinit
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRSession/requestHitTestSource#options
    /// </summary>
    public class XRHitTestOptionsInit
    {
        /// <summary>
        /// The XRSpace that will be tracked by the hit test source.
        /// </summary>
        public XRSpace Space { get; set; }
        /// <summary>
        /// point - A hit test trackable of type "point" indicates that the hit test results will be computed based on the feature points detected by the underlying Augmented Reality system.<br/>
        /// plane - A hit test trackable of type "plane" indicates that the hit test results will be computed based on the planes detected by the underlying Augmented Reality system.<br/>
        /// mesh - A hit test trackable of type "mesh" indicates that the hit test results will be computed based on the meshes detected by the underlying Augmented Reality system.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string>? EntityTypes { get; set; }
        /// <summary>
        /// The XRRay object that will be used to perform hit test. If no XRRay object has been provided, a new XRRay object is constructed without any parameters.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public XRRay? OffsetRay { get; set; }
    }
}
