using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpucomputepasstimestampwrites
    /// </summary>
    public class GPUComputePassTimestampWrites
    {
        /// <summary>
        /// The GPUQuerySet, of type "timestamp", that the query results will be written to.
        /// </summary>
        [JsonPropertyName("querySet")]
        public GPUQuerySet QuerySet { get; set; }

        /// <summary>
        /// If defined, indicates the query index in querySet into which the timestamp at the beginning of the compute pass will be written.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("beginningOfPassWriteIndex")]
        public GPUSize32? BeginningOfPassWriteIndex { get; set; }

        /// <summary>
        /// If defined, indicates the query index in querySet into which the timestamp at the end of the compute pass will be written.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("endOfPassWriteIndex")]
        public GPUSize32? EndOfPassWriteIndex { get; set; }
    }
}
