namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#typedefdef-gpucolorwriteflags
    /// </summary>
    [Flags]
    public enum GPUColorWriteFlags : uint
    {
        /// <summary>
        /// Red
        /// </summary>
        RED = 0x1,
        /// <summary>
        /// Green
        /// </summary>
        GREEN = 0x2,
        /// <summary>
        /// Blue
        /// </summary>
        BLUE = 0x4,
        /// <summary>
        /// Alpha
        /// </summary>
        ALPHA = 0x8,
        /// <summary>
        /// All
        /// </summary>
        ALL = 0xF,
    }
}
