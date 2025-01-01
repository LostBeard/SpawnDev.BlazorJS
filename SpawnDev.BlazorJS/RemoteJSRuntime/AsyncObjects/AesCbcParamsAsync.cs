using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class AesCbcParamsAsync : EncryptParams
    {
        /// <summary>
        /// A string. This should be set to AES-CBC.
        /// </summary>
        public override string Name { get; set; } = "AES-CBC";
        /// <summary>
        /// An ArrayBuffer, a TypedArray, or a DataView. The initialization vector. Must be 16 bytes, unpredictable, and preferably cryptographically random. However, it need not be secret (for example, it may be transmitted unencrypted along with the ciphertext).
        /// </summary>
        public Union<ArrayBufferAsync, TypedArrayAsync, byte[]> Iv { get; set; } = default!;
    }
}
