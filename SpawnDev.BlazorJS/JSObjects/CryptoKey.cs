using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CryptoKey interface of the Web Crypto API represents a cryptographic key obtained from one of the SubtleCrypto methods generateKey(), deriveKey(), importKey(), or unwrapKey().
    /// </summary>
    public class CryptoKey : CryptoKeyBase
    {
        public CryptoKey(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The type of key the object represents. It may take one of the following values: "secret", "private" or "public".
        /// </summary>
        public string Type => JSRef.Get<string>("type");
        /// <summary>
        /// A boolean value indicating whether or not the key may be extracted using SubtleCrypto.exportKey() or SubtleCrypto.wrapKey().
        /// </summary>
        public bool Extractable => JSRef.Get<bool>("extractable");
        /// <summary>
        /// An object describing the algorithm for which this key can be used and any associated extra parameters.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T AlgorithmAs<T>() where T : KeyGenParams => JSRef.Get<T>("algorithm");
        /// <summary>
        /// An Array of strings, indicating what can be done with the key. Possible values for array elements are "encrypt", "decrypt", "sign", "verify", "deriveKey", "deriveBits", "wrapKey", and "unwrapKey".
        /// </summary>
        public string[] Usages => JSRef.Get<string[]>("usages");
    }
}
