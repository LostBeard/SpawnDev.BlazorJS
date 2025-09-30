using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRSession/requestLightProbe#options
    /// </summary>
    public class XRLightProbeInit
    {
        /// <summary>
        /// The internal reflection format indicating how the texture data is represented, either srgba8 (default value) or rgba16f. See also XRSession.preferredReflectionFormat.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ReflectionFormat { get; set; }
    }
}
