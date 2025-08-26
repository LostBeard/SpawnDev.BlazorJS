using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for GPU.RequestAdapter
    /// https://www.w3.org/TR/webgpu/#dictdef-gpurequestadapteroptions
    /// </summary>
    public class GPURequestAdapterOptions
    {
        /// <summary>
        /// "Feature level" for the adapter request. The allowed feature level string values are: "core" and "compatibility"
        /// Defaults to "core".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FeatureLevel { get; init; }

        /// <summary>
        /// An enumerated value that can be used to provide a hint to the user agent indicating what class of adapter should be chosen from the system's available adapters. Available values are:<br/>
        /// undefined (or not specified), which provides no hint.<br/>
        /// "low-power", which provides a hint to prioritize power savings over performance. 
        /// If your app runs OK with this setting, it is recommended to use it, as it can significantly improve battery life on portable devices. 
        /// This is usually the default if no options are provided.<br/>
        /// "high-performance", which provides a hint to prioritize performance over power consumption. 
        /// You are encouraged to only specify this value if absolutely necessary, since it may significantly decrease battery life on portable devices. 
        /// It may also result in increased GPUDevice loss — the system will sometimes elect to switch to a lower-power adapter to save power.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PowerPreference { get; init; }

        /// <summary>
        /// When set to true indicates that only a fallback adapter may be returned. If the user agent does not support a fallback adapter, will cause requestAdapter() to resolve to null.
        /// Defaults to false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ForceFallbackAdapter { get; init; }

        /// <summary>
        /// When set to true indicates that the best adapter for rendering to a WebXR session must be returned. If the user agent or system does not support WebXR sessions then adapter selection may ignore this value.
        /// Defaults to false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? XrCompatible { get; init; }
    }
}
