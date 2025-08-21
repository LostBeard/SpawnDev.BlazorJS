using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents a fragment of data or a computational unit intended for processing on a GPU.
    /// </summary>
    public class GPUFragment
    {
        /// <summary>
        /// A sequence of record types, with the structure (id, value), representing override values for WGSL constants 
        /// that can be overridden in the pipeline. These behave like ordered maps. In each case, the id is a key
        /// used to identify or select the record, and the constant is an enumerated value representing a WGSL. 
        /// Depending on which constant you want to override, the id may take the form of the numeric ID of 
        /// the constant, if one is specified, or otherwise the constant's identifier name. 
        /// A code snippet providing override values for several overridable constants might look like this:
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<object, double>? Constants { get; set; }

        /// <summary>
        /// The name of the function in the module that this stage will use to perform its work.The corresponding shader 
        /// function must have the @vertex attribute to be identified as this entry point. See Entry Point Declaration 
        /// for more information. You can omit the entryPoint property if your shader code contains a single function 
        /// with the @vertex attribute set — the browser will use this as the default entry point. If entryPoint is 
        /// omitted and the browser cannot determine a default entry point, a GPUValidationError is 
        /// generated and the resulting GPURenderPipeline will be invalid.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? EntryPoint { get; set; }

        /// <summary>
        /// A GPUShaderModule object containing the WGSL code that this programmable stage will execute.
        /// </summary>
        public GPUShaderModule Module { get; set; }

        /// <summary>
        /// An array of objects representing color states that represent configuration details for the 
        /// colors output by the fragment shader stage.
        /// </summary>
        public IEnumerable<GPUColorTargetState> Targets { get; set; }
    }
}
