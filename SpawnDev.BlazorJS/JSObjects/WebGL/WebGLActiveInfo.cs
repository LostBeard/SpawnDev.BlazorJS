namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLActiveInfo interface is part of the WebGL API and represents the information returned by calling the WebGLRenderingContext.getActiveAttrib() and WebGLRenderingContext.getActiveUniform() methods.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLActiveInfo
    /// </summary>
    public class WebGLActiveInfo
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public int Type { get; set; }
    }
}
