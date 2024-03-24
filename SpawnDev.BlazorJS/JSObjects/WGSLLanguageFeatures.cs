using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WGSLLanguageFeatures interface of the WebGPU API is a setlike object that reports the WGSL language extensions supported by the WebGPU implementation.
    /// </summary>
    public class WGSLLanguageFeatures : SetReadOnly<string>
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WGSLLanguageFeatures(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
    }
}
