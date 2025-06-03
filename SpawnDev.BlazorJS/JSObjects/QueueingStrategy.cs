using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A generic queueing strategy
    /// </summary>
    public class QueueingStrategy : JSObject
    {
        ///<inheritdoc/>
        public QueueingStrategy(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A non-negative integer. This defines the total number of chunks that can be contained in the internal queue before backpressure is applied.
        /// </summary>
        public virtual int HighWaterMark => JSRef!.Get<int>("highWaterMark");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chunk"></param>
        /// <returns></returns>
        public virtual int Size(object chunk) => JSRef!.Call<int>("size", chunk);
    }
}
