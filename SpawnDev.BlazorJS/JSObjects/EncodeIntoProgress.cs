namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Returned fro ma call to TextEncoder.EncodeInto
    /// </summary>
    public class EncodeIntoProgress
    {
        /// <summary>
        /// The number of UTF-16 units of code from the source that has been converted over to UTF-8. This may be less than string.length if uint8Array did not have enough space.
        /// </summary>
        public int Read { get; set; }
        /// <summary>
        /// The number of bytes modified in the destination Uint8Array. The bytes written are guaranteed to form complete UTF-8 byte sequences.
        /// </summary>
        public int Wrtitten { get; set; }
    }
}
