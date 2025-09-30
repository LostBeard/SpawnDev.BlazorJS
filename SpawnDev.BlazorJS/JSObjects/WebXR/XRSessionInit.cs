using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// 
    /// https://www.w3.org/TR/webxr/#dictdef-xrsessioninit
    /// </summary>
    public class XRSessionInit
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string>? RequiredFeatures { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string>? OptionalFeatures { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public XRDOMOverlayInit? DomOverlay { get; set; }
    }
}
