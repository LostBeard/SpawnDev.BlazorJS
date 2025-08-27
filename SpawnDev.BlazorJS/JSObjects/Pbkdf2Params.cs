namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Pbkdf2Params dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.deriveKey(), when using the PBKDF2 algorithm.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Pbkdf2Params
    /// </summary>
    public class Pbkdf2Params : KeyDeriveParams
    {
        /// <summary>
        /// A string. This should be set to HKDF.
        /// </summary>
        public override string Name { get; set; } = "PBKDF2";
        /// <summary>
        /// A string representing the digest algorithm to use. This may be one of:<br/>
        /// SHA-1<br/>
        /// SHA-256<br/>
        /// SHA-384<br/>
        /// SHA-512
        /// </summary>
        public string Hash { get; set; }
        /// <summary>
        /// An ArrayBuffer, a TypedArray, or a DataView. This should be a random or pseudo-random value of at least 16 bytes. Unlike the input key material passed into deriveKey(), salt does not need to be kept secret.
        /// </summary>
        public BufferSource Salt { get; set; }
        /// <summary>
        /// A Number representing the number of times the hash function will be executed in deriveKey(). This determines how computationally expensive (that is, slow) the deriveKey() operation will be. In this context, slow is good, since it makes it more expensive for an attacker to run a dictionary attack against the keys. The general guidance here is to use as many iterations as possible, subject to keeping an acceptable level of performance for your application.
        /// </summary>
        public int Iterations { get; set; }
    }
}
