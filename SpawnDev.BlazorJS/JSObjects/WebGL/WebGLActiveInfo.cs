using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLActiveInfo interface is part of the WebGL API and represents the information returned by calling the WebGLRenderingContext.getActiveAttrib() and WebGLRenderingContext.getActiveUniform() methods.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLActiveInfo
    /// </summary>
    public class WebGLActiveInfo
    {
        /// <summary>
        /// The name of the requested variable.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// The size of the requested variable.
        /// </summary>
        [JsonPropertyName("size")]
        public int Size { get; set; }
        /// <summary>
        /// The data type of the requested variable.
        /// </summary>
        [JsonPropertyName("type")]
        public int Type { get; set; }
    }
}
