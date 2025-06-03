namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ByteLengthQueuingStrategy/ByteLengthQueuingStrategy#options
    /// </summary>
    public class ByteLengthQueuingStrategyOptions
    {
        /// <summary>
        /// The total number of bytes that can be contained in the internal queue before backpressure is applied.
        /// Unlike CountQueuingStrategy() where highWaterMark specifies a simple count of the number of chunks, with ByteLengthQueuingStrategy(), highWaterMark specifies a number of bytes — specifically, given a stream of chunks, how many bytes worth of those chunks(rather than a count of how many of those chunks) can be contained in the internal queue before backpressure is applied.
        /// </summary>
        public int HighWaterMark { get; set; }
    }
}
