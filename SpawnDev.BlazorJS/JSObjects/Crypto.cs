using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Crypto interface represents basic cryptography features available in the current context. It allows access to a cryptographically strong random number generator and to cryptographic primitives.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Crypto
    /// </summary>
    public class Crypto : JSObject
    {
        /// <summary>
        /// Returns true is the the global variable 'crypto' is defined
        /// </summary>
        public static bool IsSupported => !JS.IsUndefined("crypto");
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Crypto(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Gets the global instance of Crypto
        /// </summary>
        public Crypto() : base(JS.Get<IJSInProcessObjectReference>("crypto")) { }
        #endregion

        #region Properties
        /// <summary>
        /// Returns a SubtleCrypto object providing access to common cryptographic primitives, like hashing, signing, encryption, or decryption.
        /// </summary>
        public SubtleCrypto Subtle => JSRef!.Get<SubtleCrypto>("subtle");
        #endregion

        #region Methods
        /// <summary>
        /// The Crypto.getRandomValues() method lets you get cryptographically strong random values. The array given as the parameter is filled with random numbers (random in its cryptographic meaning).
        /// </summary>
        /// <typeparam name="TTypedArray">TypedArray</typeparam>
        /// <param name="typedArray">An integer-based TypedArray, that is one of: Int8Array, Uint8Array, Uint8ClampedArray, Int16Array, Uint16Array, Int32Array, Uint32Array, BigInt64Array, BigUint64Array (but not Float32Array nor Float64Array). All elements in the array will be overwritten with random numbers.</param>
        /// <returns>The same TypedArray passed in</returns>
        public TTypedArray GetRandomValues<TTypedArray>(TTypedArray typedArray) where TTypedArray : TypedArray => JSRef!.Call<TTypedArray>("getRandomValues", typedArray);
        /// <summary>
        /// The Crypto.getRandomValues() method lets you get cryptographically strong random values. The array given as the parameter is filled with random numbers (random in its cryptographic meaning).<br/>
        /// non-standard implementation to accommodate byte[]
        /// </summary>
        /// <param name="size">The number of random bytes to return</param>
        /// <returns></returns>
        public byte[] GetRandomValues(long size) => new Uint8Array(size).Using(o => JSRef!.Call<byte[]>("getRandomValues", o));
        /// <summary>
        /// A string containing a randomly generated, 36 character long v4 UUID.
        /// </summary>
        /// <returns></returns>
        public string RandomUUID() => JSRef!.Call<string>("randomUUID");
        #endregion
    }
}
