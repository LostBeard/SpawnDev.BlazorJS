using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Defines the color attachments that will be output to when executing a render pass.
    /// https://www.w3.org/TR/webgpu/#dictdef-gpurenderpasscolorattachment
    /// </summary>
    public class GPURenderPassColorAttachment
    {
        /// <summary>
        /// An enumerated value indicating the load operation to perform on view prior to executing the render pass. 
        /// Possible values are: "clear": Loads the clearValue for this attachment into the render pass.
        /// "load": Loads the existing value for this attachment into the render pass.
        /// </summary>
        public EnumString<GPULoadOp> LoadOp { get; init; }

        /// <summary>
        ///An enumerated value indicating the store operation to perform on view after executing the render pass.
        ///Possible values are: "discard": Discards the resulting value of the render pass for this attachment. 
        ///"store": Stores the resulting value of the render pass for this attachment.
        /// </summary>
        public EnumString<GPUStoreOp> StoreOp { get; init; }

        /// <summary>
        /// A GPUTextureView object representing the texture subresource that will be output to for this color attachment.
        /// </summary>
        public Union<GPUTexture, GPUTextureView> View { get; set; }

        /// <summary>
        /// Describes the texture subresource that will receive the resolved output for this color attachment if view is multisampled. 
        /// The subresource is determined by calling get as texture view(resolveTarget).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<GPUTexture, GPUTextureView> ResolveTarget { get; set; }

        /// <summary>
        /// Indicates the depth slice index of "3d" view that will be output to for this color attachment.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUIntegerCoordinate? DepthSlice { get; set; }

        /// <summary>
        /// A color value to clear the view texture to, prior to executing the render pass.
        /// This value is ignored if loadOp is not set to "clear". clearValue takes an array or 
        /// object representing the four color components r, g, b, and a as decimals.
        /// For example, you can pass an array like [0.0, 0.5, 1.0, 1.0], or its equivalent object 
        /// { r: 0.0, g: 0.5, b: 1.0, a: 1.0 }.
        /// If clearValue is omitted, it defaults to { r: 0, g: 0, b: 0, a: 0 }.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUColor? ClearValue { get; init; }
    }
}
