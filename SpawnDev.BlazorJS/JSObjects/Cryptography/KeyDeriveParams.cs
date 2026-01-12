namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Base class for options used in SubtleCrypto.DeriveKey()
    /// </summary>
    public class KeyDeriveParams
    {
        /// <summary>
        /// A string indicating the derive key parameters the inheriting class holds
        /// </summary>
        public virtual string Name { get; set; }
    }
}
