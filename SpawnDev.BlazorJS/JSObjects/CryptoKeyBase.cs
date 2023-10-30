using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Base class for CryptoKeyPair and CryptoKey
    /// </summary>
    public class CryptoKeyBase : JSObject
    {
        public CryptoKeyBase(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
