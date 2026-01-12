using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLActiveInfo interface is part of the WebGL API and represents the information returned by calling the WebGLRenderingContext.getActiveAttrib() and WebGLRenderingContext.getActiveUniform() methods.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLActiveInfo
    /// </summary>
    public class WebGLActiveInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("size")]
        public int Size { get; set; }
        [JsonPropertyName("type")]
        public int Type { get; set; }
    }
}
