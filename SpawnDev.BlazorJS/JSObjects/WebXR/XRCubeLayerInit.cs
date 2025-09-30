using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://docs.w3cub.com/dom/xrwebglbinding/createcubelayer#init
    /// </summary>
    public class XRCubeLayerInit
    {
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
        /// <summary>
        /// A DOMPointReadOnly specifying the orientation relative to the space property.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DOMPointReadOnly? Orientation { get; set; }
    }
}
