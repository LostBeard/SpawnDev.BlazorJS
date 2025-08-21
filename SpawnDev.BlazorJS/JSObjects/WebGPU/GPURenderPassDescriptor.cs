namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents a descriptor for configuring a GPU render pass.
    /// </summary>
    public class GPURenderPassDescriptor
    {
        /// <summary>
        /// An array of objects (see Color attachment object structure) defining the color attachments 
        /// that will be output to when executing this render pass.
        /// </summary>
        public IEnumerable<GPUColorAttachment> ColorAttachments { get; set; }
    }
}
