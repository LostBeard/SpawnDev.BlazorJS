using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Contains public key
    /// </summary>
    public class ECJWKPublic : JWK
    {
        /// <summary>
        /// Named curve
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("crv")]
        public string? Crv { get; set; }
        /// <summary>
        /// X value
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("x")]
        public string? X { get; set; }
        /// <summary>
        /// Y value
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("y")]
        public string? Y { get; set; }
    }
    /// <summary>
    /// Contains both private key and public key
    /// </summary>
    public class ECJWKFull : ECJWKPublic
    {
        /// <summary>
        /// Private key
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("d")]
        public string? D { get; set; }
    }
    /// <summary>
    /// Contains public key
    /// </summary>
    public class RSAPS256JWKPublic : JWK
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("e")]
        public string? E { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("n")]
        public string? N { get; set; }
    }
    /// <summary>
    /// Contains both private key and public key
    /// </summary>
    public class RSAPS256JWKFull : RSAPS256JWKPublic
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("d")]
        public string? D { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("dp")]
        public string? Dp { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("dq")]
        public string? Dq { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("p")]
        public string? P { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("q")]
        public string? Q { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("qi")]
        public string? Qi { get; set; }
    }
    /// <summary>
    /// JSON Web Key (JWK) Format<br/>
    /// https://datatracker.ietf.org/doc/html/rfc7517#section-4
    /// </summary>
    public class JWK
    {
        /// <summary>
        /// "kty" (Key Type) Parameter<br/>
        /// The "kty" (key type) parameter identifies the cryptographic algorithm family used with the key, such as "RSA" or "EC".<br/>
        /// "kty" values should either be registered in the IANA "JSON Web Key Types" registry established by [JWA] or be a value that contains a Collision- Resistant Name.<br/>
        /// The "kty" value is a case-sensitive string.<br/>
        /// This member MUST be present in a JWK.
        /// </summary>
        [JsonPropertyName("kty")]
        public string KeyType { get; set; }
        /// <summary>
        /// "use" (Public Key Use) Parameter<br/>
        /// The "use" (public key use) parameter identifies the intended use of the public key.<br/>
        /// The "use" parameter is employed to indicate whether a public key is used for encrypting data or verifying the signature on data.
        /// Values defined by this specification are:<br/>
        /// "sig" - signature<br/>
        /// "enc" - encryption<br/>
        /// Other values MAY be used. The "use" value is a case-sensitive string. Use of the "use" member is OPTIONAL, unless the application requires its presence.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("use")]
        public string? Use { get; set; }
        /// <summary>
        /// "key_ops" (Key Operations) Parameter<br/>
        /// The "key_ops" (key operations) parameter identifies the operation(s) for which the key is intended to be used.The "key_ops" parameter is intended for use cases in which public, private, or symmetric keys may be present.<br/>
        /// Its value is an array of key operation values.  Values defined by this specification are:<br/>
        /// "sign" (compute digital signature or MAC)<br/>
        /// "verify" (verify digital signature or MAC)<br/>
        /// "encrypt" (encrypt content)<br/>
        /// "decrypt" (decrypt content and validate decryption, if applicable)<br/>
        /// "wrapKey" (encrypt key)<br/>
        /// "unwrapKey" (decrypt key and validate decryption, if applicable)<br/>
        /// "deriveKey" (derive key)<br/>
        /// "deriveBits" (derive bits not to be used as a key)<br/>
        /// (Note that the "key_ops" values intentionally match the "KeyUsage" values defined in the Web Cryptography API [W3C.CR - WebCryptoAPI - 20141211] specification.)<br/>
        /// Other values MAY be used.  The key operation values are case-sensitive strings.Duplicate key operation values MUST NOT be present in the array.  Use of the "key_ops" member is OPTIONAL, unless the application requires its presence.<br/>
        /// Multiple unrelated key operations SHOULD NOT be specified for a key because of the potential vulnerabilities associated with using the same key with multiple algorithms.Thus, the combinations "sign" with "verify", "encrypt" with "decrypt", and "wrapKey" with "unwrapKey" are permitted, but other combinations SHOULD NOT be used.<br/>
        /// Additional "key_ops" (key operations) values can be registered in the IANA "JSON Web Key Operations" registry established by Section 8.3. The same considerations about registering extension values apply to the "key_ops" member as do for the "use" member.<br/>
        /// The "use" and "key_ops" JWK members SHOULD NOT be used together; however, if both are used, the information they convey MUST be consistent.Applications should specify which of these members they use, if either is to be used by the application.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("key_ops")]
        public string[]? KeyOps { get; set; }
        /// <summary>
        /// "alg" (Algorithm) Parameter<br/>
        /// The "alg" (algorithm) parameter identifies the algorithm intended for use with the key.The values used should either be registered in the IANA "JSON Web Signature and Encryption Algorithms" registry established by[JWA] or be a value that contains a Collision-Resistant Name.  The "alg" value is a case-sensitive ASCII string. Use of this member is OPTIONAL.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("alg")]
        public string? Alg { get; set; }
        /// <summary>
        /// "kid" (Key ID) Parameter<br/>
        /// The "kid" (key ID) parameter is used to match a specific key.  This is used, for instance, to choose among a set of keys within a JWK Set during key rollover.The structure of the "kid" value is unspecified.When "kid" values are used within a JWK Set, different keys within the JWK Set SHOULD use distinct "kid" values.  (One example in which different keys might use the same "kid" value is if they have different "kty" (key type) values but are considered to be equivalent alternatives by the application using them.)  The "kid" value is a case-sensitive string.  Use of this member is OPTIONAL. When used with JWS or JWE, the "kid" value is used to match a JWS or JWE "kid" Header Parameter value.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("kid")]
        public string? KId { get; set; }
        /// <summary>
        /// "x5u" (X.509 URL) Parameter<br/>
        /// The "x5u" (X.509 URL) parameter is a URI [RFC3986] that refers to a resource for an X.509 public key certificate or certificate chain [RFC5280].  The identified resource MUST provide a representation of the certificate or certificate chain that conforms to RFC 5280 [RFC5280] in PEM-encoded form, with each certificate delimited as specified in Section 6.1 of RFC 4945 [RFC4945].  The key in the first certificate MUST match the public key represented by other members of the JWK.The protocol used to acquire the resource MUST provide integrity protection; an HTTP GET request to retrieve the certificate MUST use TLS[RFC2818][RFC5246]; the identity of the server MUST be validated, as per Section 6 of RFC 6125 [RFC6125].  Use of this member is OPTIONAL.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("x5u")]
        public string? X5u { get; set; }
        /// <summary>
        /// "x5c" (X.509 Certificate Chain) Parameter<br/>
        /// The "x5c" (X.509 certificate chain) parameter contains a chain of one or more PKIX certificates[RFC5280].  The certificate chain is represented as a JSON array of certificate value strings.Each string in the array is a base64-encoded(Section 4 of[RFC4648] -- not base64url-encoded) DER[ITU.X690.1994] PKIX certificate value. The PKIX certificate containing the key value MUST be the first certificate.This MAY be followed by additional certificates, with each subsequent certificate being the one used to certify the previous one.The key in the first certificate MUST match the public key represented by other members of the JWK.Use of this member is OPTIONAL.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("x5c")]
        public string[]? X5c { get; set; }
        /// <summary>
        /// "x5t" (X.509 Certificate SHA-1 Thumbprint) Parameter<br/>
        /// The "x5t" (X.509 certificate SHA-1 thumbprint) parameter is a base64url-encoded SHA-1 thumbprint(a.k.a.digest) of the DER encoding of an X.509 certificate[RFC5280].  Note that certificate thumbprints are also sometimes known as certificate fingerprints. The key in the certificate MUST match the public key represented by other members of the JWK.Use of this member is OPTIONAL.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("x5t")]
        public string[]? X5t { get; set; }
    }
}
