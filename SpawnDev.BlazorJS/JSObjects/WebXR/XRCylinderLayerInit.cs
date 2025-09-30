using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createCylinderLayer#init
    /// </summary>
    public class XRCylinderLayerInit
    {
        /// <summary>
        /// A number indicating the ratio of the visible cylinder section. It is the ratio of the width of the visible section of the cylinder divided by its height. The width is calculated by multiplying the radius with the centralAngle. The default value is 2.0.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? AspectRatio { get; set; }
        /// <summary>
        /// A number indicating the angle in radians of the visible section of the cylinder. Default value: 0.78539 (π / 4).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? CentralAngle { get; set; }
        /// <summary>
        /// A number indicating the radius of the cylinder. Default value: 2.0.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Radius { get; set; }
        /// <summary>
        /// A string defining the type of texture the layer will have. 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TextureType { get; set; }
        /// <summary>
        /// An XRRigidTransform object defining the offset and orientation relative to space.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public XRRigidTransform? Transform { get; set; }
        /// <summary>
        /// An XRSpace object defining the layer's spatial relationship with the user's physical environment.
        /// </summary>
        public XRSpace Space { get; set; }
        /// <summary>
        /// A number specifying the pixel width of the layer view.
        /// </summary>
        public int ViewPixelWidth { get; set; }
        /// <summary>
        /// A number specifying the pixel height of the layer view.
        /// </summary>
        public int ViewPixelHeight { get; set; }
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
        /// A boolean that, if true, indicates you can only draw to this layer when needsRedraw is true. The default value is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsStatic { get; set; }
        /// <summary>
        /// A string indicating the layout of the layer. 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Layout { get; set; }
        /// <summary>
        /// A number specifying the desired number of mip levels. The default value is 1.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MipLevels { get; set; }
    }
}
