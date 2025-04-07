using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// TextDecoderStream options<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TextDecoderStream/TextDecoderStream#options
    /// </summary>
    public class TextDecoderStreamOptions
    {
        /// <summary>
        /// A boolean value indicating if the TextDecoder.decode() method must throw a TypeError when decoding invalid data. It defaults to false, which means that the decoder will substitute malformed data with a replacement character.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Fatal { get; set; }
        /// <summary>
        /// A boolean value indicating whether the byte order mark will be included in the output or skipped over. It defaults to false, which means that the byte order mark will be skipped over when decoding and will not be included in the decoded text.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IgnoreBOM { get; set; }
    }
}
