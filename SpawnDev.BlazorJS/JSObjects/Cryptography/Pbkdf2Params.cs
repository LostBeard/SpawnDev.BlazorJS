using System.Diagnostics.CodeAnalysis;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Pbkdf2Params dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.deriveKey(), when using the PBKDF2 algorithm.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Pbkdf2Params
    /// </summary>
    public class Pbkdf2Params : KeyDeriveParams
    {
        /// <summary>
        /// Creates a new instance.<br/>
        /// Salt is a constructor parameter rather than a required initializer because this type also
        /// fixes Name, and a [SetsRequiredMembers] constructor switches off the compiler's required
        /// checking for EVERY required member of the type - so a parameterless one would silently stop
        /// enforcing salt while claiming to set it.
        /// </summary>
        /// <param name="salt">Salt value. See <see cref="Salt"/>.</param>
        [SetsRequiredMembers]
        public Pbkdf2Params(BufferSource salt)
        {
            Salt = salt;
            Name = "PBKDF2";
        }
        // Name is inherited from the base and set in the constructor above. It is deliberately NOT
        // overridden here: an override auto-property would reintroduce CS8618, because nullable
        // analysis does not count assigning a VIRTUAL property in a constructor as definite
        // assignment. The base declares it required, which is what makes the base warning free.
        /// <summary>
        /// A string representing the digest algorithm to use. This may be one of:<br/>
        /// SHA-1<br/>
        /// SHA-256<br/>
        /// SHA-384<br/>
        /// SHA-512
        /// </summary>
        public string? Hash { get; set; }
        /// <summary>
        /// An ArrayBuffer, a TypedArray, or a DataView. This should be a random or pseudo-random value of at least 16 bytes. Unlike the input key material passed into deriveKey(), salt does not need to be kept secret.
        /// </summary>
        public required BufferSource Salt { get; set; }
        /// <summary>
        /// A Number representing the number of times the hash function will be executed in deriveKey(). This determines how computationally expensive (that is, slow) the deriveKey() operation will be. In this context, slow is good, since it makes it more expensive for an attacker to run a dictionary attack against the keys. The general guidance here is to use as many iterations as possible, subject to keeping an acceptable level of performance for your application.
        /// </summary>
        public int Iterations { get; set; }
    }
}
