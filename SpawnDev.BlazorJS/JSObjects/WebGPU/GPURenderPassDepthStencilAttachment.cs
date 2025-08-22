using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpurenderpassdepthstencilattachment
    /// </summary>
    public class GPURenderPassDepthStencilAttachment
    {
        /// <summary>
        /// A GPUTextureView that will be used as the depth-stencil attachment for a render pass.
        /// </summary>
        public object View 
        {
            get => _view;
            init 
            {
                if(value is IGPUTextureOrTextureView)
                    _view = value;
                else
                    throw new ArgumentException("View must be a GPUTexture or GPUTextureView");
            } 
        }
        private object _view;
        /// <summary>
        /// An object (see Depth stencil attachment depth clear value object structure) defining the clear value 
        /// to use for the depth aspect of the attachment if the depth load operation is set to "clear".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? DepthClearValue { get; set; }
        /// <summary>
        /// A string indicating how the depth aspect of the attachment is treated at the start of the render pass. 
        /// Must be one of "load", "clear", or "undefined". If set to "load", the existing contents of the 
        /// attachment are preserved. If set to "clear", the contents are cleared to the value specified by 
        /// depthClearValue. If set to "undefined", the contents are undefined. The default value is "load".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DepthLoadOp { get; set; }
        /// <summary>
        /// A string indicating how the depth aspect of the attachment is treated at the end of the render pass. 
        /// Must be one of "store" or "undefined". If set to "store", the results of rendering to the attachment 
        /// are written to memory. If set to "undefined", they are discarded. The default value is "store".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DepthStoreOp { get; set; }
        /// <summary>
        /// An object (see Depth stencil attachment stencil clear value object structure) defining the clear value 
        /// to use for the stencil aspect of the attachment if the stencil load operation is set to "clear".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUStencilValue? StencilClearValue { get; set; }
        /// <summary>
        /// A string indicating how the stencil aspect of the attachment is treated at the start of the render pass. 
        /// Must be one of "load", "clear", or "undefined". If set to "load", the existing contents of the 
        /// attachment are preserved. If set to "clear", the contents are cleared to the value specified by 
        /// stencilClearValue. If set to "undefined", the contents are undefined. The default value is "load".
    }
}
