namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Used for property CredentialCreatePublicKey.PubKeyCredParams<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#pubkeycredparams
    /// </summary>
    public class PublicKeyCredentialParameter
    {
        /// <summary>
        /// A string defining the type of public key credential to create. This can currently take a single value, "public-key", but more values may be added in the future.
        /// </summary>
        public string Type { get; set; } = "public-key";
        /// <summary>
        /// A number that is equal to a COSE Algorithm Identifier, representing the cryptographic algorithm to use for this credential type. It is recommended that relying parties that wish to support a wide range of authenticators should include at least the following values in the provided choices:<br/>
        /// -8: Ed25519<br/>
        /// -7: ES256<br/>
        /// -257: RS256
        /// </summary>
        public int Alg { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        public PublicKeyCredentialParameter() { }
        /// <summary>
        /// Creates a new instance with the specified algorithm
        /// </summary>
        /// <param name="alg"></param>
        public PublicKeyCredentialParameter(int alg) => (Alg) = (alg);
        /// <summary>
        /// Creates a new instance with the specified algorithm and type
        /// </summary>
        /// <param name="alg"></param>
        /// <param name="type"></param>
        public PublicKeyCredentialParameter(int alg, string type) => (Alg, Type) = (alg, type);
        /// <summary>
        /// Implicit operator to create a PublicKeyCredentialParameter from an int
        /// </summary>
        /// <param name="alg"></param>
        public static implicit operator PublicKeyCredentialParameter(int alg) => new PublicKeyCredentialParameter(alg);
        /// <summary>
        /// Implicit operator to get the algorithm from a PublicKeyCredentialParameter
        /// </summary>
        /// <param name="obj"></param>
        public static implicit operator int(PublicKeyCredentialParameter obj) => obj.Alg;
    }
}
