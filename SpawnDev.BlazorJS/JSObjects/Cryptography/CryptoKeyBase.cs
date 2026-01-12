using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Base class for CryptoKeyPair and CryptoKey
    /// </summary>
    public class CryptoKeyBase : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public CryptoKeyBase(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
