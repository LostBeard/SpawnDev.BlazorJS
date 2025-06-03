using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CountQueuingStrategy interface of the Streams API provides a built-in chunk counting queuing strategy that can be used when constructing streams.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CountQueuingStrategy
    /// </summary>
    public class CountQueuingStrategy : QueueingStrategy
    {
        ///<inheritdoc/>
        public CountQueuingStrategy(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The CountQueuingStrategy() constructor creates and returns a CountQueuingStrategy object instance.
        /// </summary>
        /// <param name="options"></param>
        public CountQueuingStrategy(CountQueuingStrategyOptions options) : base(JS.New(nameof(CountQueuingStrategy), options)) { }
        /// <summary>
        /// A non-negative integer. This defines the total number of chunks that can be contained in the internal queue before backpressure is applied.
        /// </summary>
        public override int HighWaterMark => JSRef!.Get<int>("highWaterMark");
        /// <summary>
        /// Always returns 1.
        /// </summary>
        /// <param name="chunk"></param>
        /// <returns></returns>
        public override int Size(object chunk) => JSRef!.Call<int>("size", chunk);
    }
}
