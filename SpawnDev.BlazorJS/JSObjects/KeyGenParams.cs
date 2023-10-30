namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Base class for parameter types used when calling SubtleCrypto.generateKey
    /// </summary>
    public class KeyGenParams
    {
        /// <summary>
        /// A string.
        /// </summary>
        public virtual string Name { get; set; }
    }
}
