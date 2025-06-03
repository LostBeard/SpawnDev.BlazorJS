using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for the TransformStream constructor.<br/>
    /// </summary>
    public class TransformerSync
    {
        /// <summary>
        /// Called when the TransformStream is constructed. It is typically used to enqueue chunks using TransformStreamDefaultController.enqueue().
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ActionCallback<TransformStreamDefaultController>? Start { get; set; }
        /// <summary>
        /// Called when a chunk written to the writable side is ready to be transformed, and performs the work of the transformation stream. It can return a promise to signal success or failure of the write operation. If no transform() method is supplied, the identity transform is used, and the chunk will be enqueued with no changes.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ActionCallback<JSObject, TransformStreamDefaultController>? Transform { get; set; }
        /// <summary>
        /// Called after all chunks written to the writable side have been successfully transformed, and the writable side is about to be closed.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ActionCallback<TransformStreamDefaultController>? Flush { get; set; }
    }
}
