using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ReadableStream/getReader#options
    /// </summary>
    public class ReadableStreamGetReaderOptions
    {
        /// <summary>
        /// A property that specifies the type of reader to create. Values can be: "byob", which results in a ReadableStreamBYOBReader being created that can read readable byte streams(streams that support zero-copy transfer from an underlying byte source to the reader when internal stream buffers are empty). undefined(or not specified at all — this is the default), which results in a ReadableStreamDefaultReader being created that can read individual chunks from a stream.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Mode { get; set; }
    }
}
