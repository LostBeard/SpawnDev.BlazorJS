using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// "GPUTexelCopyBufferLayout" describes the "layout" of texels in a "buffer" of bytes (GPUBuffer or AllowSharedBufferSource) in a "texel copy" operation.<br/>
    /// https://www.w3.org/TR/webgpu/#gputexelcopybufferlayout
    /// </summary>
    public class GPUTexelCopyBufferLayout
    {
        /// <summary>
        /// The offset, in bytes, from the beginning of the texel data source (such as a GPUTexelCopyBufferInfo.buffer) to the start of the texel data within that source.
        /// </summary>
        public GPUSize64 Offset { get; set; } = 0;
        /// <summary>
        /// The stride, in bytes, between the beginning of each texel block row and the subsequent texel block row.<br/>
        /// Required if there are multiple texel block rows (i.e. the copy height or depth is more than one block).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUSize32? BytesPerRow { get; set; }
        /// <summary>
        /// Number of texel block rows per single texel image of the texture. rowsPerImage × bytesPerRow is the stride, in bytes, between the beginning of each texel image of data and the subsequent texel image.<br/>
        /// Required if there are multiple texel images (i.e. the copy depth is more than one).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUSize32? RowsPerImage { get; set; }
    }
}
