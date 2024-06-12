using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The RsaHashedKeyGenParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.generateKey(), when generating any RSA-based key pair: that is, when the algorithm is identified as any of RSASSA-PKCS1-v1_5, RSA-PSS, or RSA-OAEP.
    /// </summary>
    public class RsaHashedKeyGenParams : KeyGenParams
    {
        /// <summary>
        /// A string. This should be set to RSASSA-PKCS1-v1_5, RSA-PSS, or RSA-OAEP, depending on the algorithm you want to use.
        /// </summary>
        public override string Name { get; set; }
        /// <summary>
        /// A Number. The length in bits of the RSA modulus. This should be at least 2048: see for example see SP 800-131A Rev. 2. Some organizations are now recommending that it should be 4096.
        /// </summary>
        public int ModulusLength { get; set; }
        /// <summary>
        /// A Uint8Array. The public exponent. Unless you have a good reason to use something else, specify 65537 here ([0x01, 0x00, 0x01]).
        /// </summary>
        public byte[] PublicExponent { get; set; }
        /// <summary>
        /// A string representing the name of the digest function to use. You can pass any of SHA-256, SHA-384, or SHA-512 here.<br/>
        /// MDN Docs state this is a string, which works when generating a key, but<br/>
        /// when read from the CryptoKey.Algorithm property, Hash is an object with one property, Name.<br/>
        /// That is why RsaHash is also allowed here.
        /// </summary>
        public Union<string, RsaHash> Hash { get; set; }
        /// <summary>
        /// Returns the hash name from the Hash property, which can be an object or a string<br/>
        /// non-standard property to simplify reading the Hash from Union.Value
        /// </summary>
        [JsonIgnore]
        public string? HashName
        {
            get
            {
                if (Hash.Value is string hashStr) return hashStr;
                else if (Hash.Value is RsaHash hashObj) return hashObj.Name;
                return null;
            }
        }
    }
}
