using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class EcdhKeyDeriveParamsAsync : KeyDeriveParams
    {
        /// <summary>
        /// Creates a new instance. The algorithm name is fixed by this type, so a caller does
        /// not supply it even though the base declares it required.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public EcdhKeyDeriveParamsAsync()
        {
            Name = "ECDH";
        }
        // Name is inherited from the base and set in the constructor above. It is deliberately NOT
        // overridden here: an override auto-property would reintroduce CS8618, because nullable
        // analysis does not count assigning a VIRTUAL property in a constructor as definite
        // assignment. The base declares it required, which is what makes the base warning free.
        /// <summary>
        /// A CryptoKey object representing the public key of the other entity.
        /// </summary>
        public CryptoKeyAsync Public { get; set; }
    }
}
