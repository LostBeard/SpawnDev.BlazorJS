namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    ///  Defines the layout of the vertex attributes within each structure. 
    ///  https://www.w3.org/TR/webgpu/#dictdef-gpuvertexattribute
    /// </summary>
    public class GPUVertexAttribute
    {
        /// <summary>
        /// The data format for this attribute. 
        /// </summary>
        public EnumString<GPUVertexFormat> Format { get; init; }

        /// <summary>
        /// The byte offset of this attribute within the vertex structure. 
        /// </summary>
        
        public GPUSize64 Offset { get; init; }

        /// <summary>
        /// The shader location that this attribute will be bound to. 
        /// </summary>
        public GPUIndex32 ShaderLocation { get; init; }
    }
}