using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ByteLengthQueuingStrategy
    /// </summary>
    public class ByteLengthQueuingStrategy : QueueingStrategy
    {
        ///<inheritdoc/>
        public ByteLengthQueuingStrategy(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The ByteLengthQueuingStrategy() constructor creates and returns a ByteLengthQueuingStrategy object instance.
        /// </summary>
        /// <param name="options"></param>
        public ByteLengthQueuingStrategy(ByteLengthQueuingStrategyOptions options) : base(JS.New(nameof(ByteLengthQueuingStrategy), options)) { }
        /// <summary>
        /// A non-negative integer. This defines the total number of chunks that can be contained in the internal queue before backpressure is applied.
        /// </summary>
        public override int HighWaterMark => JSRef!.Get<int>("highWaterMark");
        /// <summary>
        /// The size() method of the ByteLengthQueuingStrategy interface returns the given chunk's byteLength property.
        /// </summary>
        /// <param name="chunk"></param>
        /// <returns></returns>
        public override int Size(object chunk) => JSRef!.Call<int>("size", chunk);
    }
}
