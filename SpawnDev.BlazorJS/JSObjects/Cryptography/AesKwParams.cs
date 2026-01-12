namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// AES-KW parameters
    /// </summary>
    public class AesKwParams : EncryptParams
    {
        /// <summary>
        /// A string. This should be set to AES-KW.
        /// </summary>
        public override string Name { get; set; } = "AES-KW";
    }
}
