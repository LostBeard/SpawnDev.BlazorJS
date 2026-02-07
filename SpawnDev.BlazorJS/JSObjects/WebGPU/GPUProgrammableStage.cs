using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A GPUProgrammableStage describes the entry point in the user-provided GPUShaderModule that controls 
    /// one of the programmable stages of a pipeline. Entry point names follow the rules defined in WGSL identifier comparison.
    /// https://www.w3.org/TR/webgpu/#gpuprogrammablestage
    /// </summary>
    public class GPUProgrammableStage
    {
        /// <summary>
        /// A GPUShaderModule object containing the WGSL code that this programmable stage will execute.
        /// </summary>
        [JsonPropertyName("module")]
        public GPUShaderModule Module { get; init; }

        /// <summary>
        /// The name of the function in the module that this stage will use to perform its work.The corresponding shader 
        /// function must have the @vertex attribute to be identified as this entry point. See Entry Point Declaration 
        /// for more information. You can omit the entryPoint property if your shader code contains a single function 
        /// with the @vertex attribute set — the browser will use this as the default entry point. If entryPoint is 
        /// omitted and the browser cannot determine a default entry point, a GPUValidationError is 
        /// generated and the resulting GPURenderPipeline will be invalid.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("entryPoint")]
        public string? EntryPoint { get; init; }

        /// <summary>
        /// A sequence of record types, with the structure (id, value), representing override values for WGSL constants 
        /// that can be overridden in the pipeline. These behave like ordered maps. In each case, the id is a key
        /// used to identify or select the record, and the constant is an enumerated value representing a WGSL. 
        /// Depending on which constant you want to override, the id may take the form of the numeric ID of 
        /// the constant, if one is specified, or otherwise the constant's identifier name. 
        /// A code snippet providing override values for several overridable constants might look like this:
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("constants")]
        public Dictionary<string, object>? Constants { get; init; }
    }
}
