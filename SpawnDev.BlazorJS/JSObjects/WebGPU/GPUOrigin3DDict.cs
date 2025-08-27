namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpuorigin3ddict
    /// </summary>
    public class GPUOrigin3DDict
    {
        /// <summary>
        /// origin.x refers to either GPUOrigin3DDict.x or the first item of the sequence (0 if not present).
        /// </summary>
        public GPUIntegerCoordinate X { get; set; } = 0;
        /// <summary>
        /// origin.y refers to either GPUOrigin3DDict.y or the second item of the sequence (0 if not present).
        /// </summary>
        public GPUIntegerCoordinate Y { get; set; } = 0;
        /// <summary>
        /// origin.z refers to either GPUOrigin3DDict.z or the third item of the sequence (0 if not present).
        /// </summary>
        public GPUIntegerCoordinate Z { get; set; } = 0;
    }
}
