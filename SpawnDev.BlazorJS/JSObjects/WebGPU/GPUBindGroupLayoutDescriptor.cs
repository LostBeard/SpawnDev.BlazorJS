using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object describing the layout of a bind group, which is a collection of resources that can be bound to a pipeline.<br/>
    /// </summary>
    public class GPUBindGroupLayoutDescriptor
    {
        /// <summary>
        /// An array of entry objects, each one of which describes a single shader resource binding to be included in the GPUBindGroupLayout. 
        /// Each entry will correspond to an entry defined in a GPUBindGroup (created via a GPUDevice.createBindGroup() call) that uses 
        /// this GPUBindGroupLayout object as a template.
        /// </summary>
        public IEnumerable<GPUEntryObject> Entries { get; set; }

        /// <summary>
        /// A string providing a label that can be used to identify the object, for example in GPUError messages or console warnings.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }
    }
}
