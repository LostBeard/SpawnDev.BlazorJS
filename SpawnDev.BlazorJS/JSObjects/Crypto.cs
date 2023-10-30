﻿using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Crypto interface represents basic cryptography features available in the current context. It allows access to a cryptographically strong random number generator and to cryptographic primitives.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Crypto
    /// </summary>
    public class Crypto : JSObject
    {
        #region Constructors
        public Crypto(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        public SubtleCrypto Subtle => JSRef.Get<SubtleCrypto>("subtle");
        #endregion

        #region Methods
        /// <summary>
        /// The Crypto.getRandomValues() method lets you get cryptographically strong random values. The array given as the parameter is filled with random numbers (random in its cryptographic meaning).
        /// </summary>
        /// <param name="typedArray">An integer-based TypedArray, that is one of: Int8Array, Uint8Array, Uint8ClampedArray, Int16Array, Uint16Array, Int32Array, Uint32Array, BigInt64Array, BigUint64Array (but not Float32Array nor Float64Array). All elements in the array will be overwritten with random numbers.</param>
        /// <returns></returns>
        public TypedArray GetRandomValues(TypedArray typedArray) => JSRef.Call<TypedArray>("getRandomValues", typedArray);
        /// <summary>
        /// A string containing a randomly generated, 36 character long v4 UUID.
        /// </summary>
        /// <returns></returns>
        public string RandomUUID() => JSRef.Call<string>("randomUUID");
        #endregion
    }
}