using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object to configure the XRProjectionLayer.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createProjectionLayer#options
    /// </summary>
    public class XRProjectionLayerInit
    {
        /// <summary>
        /// A string defining the type of texture the layer will have. 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TextureType { get; set; }
        /// <summary>
        /// A GLenum defining the data type of the color texture data
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? ColorFormat { get; set; }
        /// <summary>
        /// A GLenum defining the data type of the depth texture data or 0 indicating that the layer should not provide a depth texture. (In that case XRProjectionLayer.ignoreDepthValues will be true.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? DepthFormat { get; set; }
        /// <summary>
        /// A floating-point value which is used to scale the layer during compositing. A value of 1.0 represents the default pixel size for the frame buffer. (See also XRWebGLLayer.getNativeFramebufferScaleFactor().) Unlike other layers, the XRProjectionLayer can't be created with an explicit pixel width and height, because the size is inferred by the hardware. (Projection layers fill the observer's entire view.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? ScaleFactor { get; set; }
    }
}
