namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Used for property CredentialCreatePublicKey.PubKeyCredParams<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#pubkeycredparams
    /// </summary>
    public class PublicKeyCredentialParameter
    {
        /// <summary>
        /// A string defining the type of public key credential to create. This can currently take a single value, "public-key", but more values may be added in the future.
        /// </summary>
        public string Type { get; set; } = "public-key";
        /// <summary>
        /// A number that is equal to a COSE Algorithm Identifier, representing the cryptographic algorithm to use for this credential type. It is recommended that relying parties that wish to support a wide range of authenticators should include at least the following values in the provided choices:<br />
        /// -8: Ed25519<br />
        /// -7: ES256<br />
        /// -257: RS256
        /// </summary>
        public int Alg { get; set; }
        public PublicKeyCredentialParameter() { }
        public PublicKeyCredentialParameter(int alg) => (Alg) = (alg);
        public PublicKeyCredentialParameter(int alg, string type) => (Alg, Type) = (alg, type);
        public static implicit operator PublicKeyCredentialParameter(int alg) => new PublicKeyCredentialParameter(alg);
        public static implicit operator int(PublicKeyCredentialParameter obj) => obj.Alg;
    }
}
