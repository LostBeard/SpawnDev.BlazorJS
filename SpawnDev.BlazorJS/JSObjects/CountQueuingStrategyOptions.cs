namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CountQueuingStrategy/CountQueuingStrategy#options
    /// </summary>
    public class CountQueuingStrategyOptions
    {
        /// <summary>
        /// The total number of chunks that can be contained in the internal queue before backpressure is applied.
        /// </summary>
        public int HighWaterMark { get; set; }
    }
}
