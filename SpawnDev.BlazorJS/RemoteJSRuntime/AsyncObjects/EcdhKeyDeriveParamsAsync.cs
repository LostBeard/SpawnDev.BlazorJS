using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    public class EcdhKeyDeriveParamsAsync : KeyDeriveParams
    {
        /// <summary>
        /// A string. This should be set to ECDH.
        /// </summary>
        public override string Name { get; set; } = "ECDH";
        /// <summary>
        /// A CryptoKey object representing the public key of the other entity.
        /// </summary>
        public CryptoKeyAsync Public { get; set; }
    }
}
