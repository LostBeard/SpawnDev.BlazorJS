using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Custom queueing strategy
    /// </summary>
    public class CustomQueuingStrategy : QueueingStrategy
    {
        FuncCallback<JSObject, int>? _sizeCallback = null;
        ///<inheritdoc/>
        public CustomQueuingStrategy(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The ByteLengthQueuingStrategy() constructor creates and returns a ByteLengthQueuingStrategy object instance.
        /// </summary>
        public CustomQueuingStrategy(int highWaterMark, Func<JSObject, int> size) : base(JS.New("Object"))
        {
            JSRef!.Set("highWaterMark", highWaterMark);
            _sizeCallback = new FuncCallback<JSObject, int>(size);
            JSRef!.Set("size", _sizeCallback);
        }
        /// <summary>
        /// A non-negative integer. This defines the total number of chunks that can be contained in the internal queue before backpressure is applied.
        /// </summary>
        public override int HighWaterMark => JSRef!.Get<int>("highWaterMark");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chunk"></param>
        /// <returns></returns>
        public override int Size(object chunk) => JSRef!.Call<int>("size", chunk);
        ///<inheritdoc/>
        override protected void Dispose(bool disposing)
        {
            _sizeCallback?.Dispose();
            _sizeCallback = null;
            base.Dispose(disposing);
        }
    }
}
