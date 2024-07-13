using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An AsyncIterator object is an object that conforms to the async iterator protocol by providing a next() method that returns a promise fulfilling to an iterator result object. The AsyncIterator.prototype object is a hidden global object that all built-in async iterators inherit from. It provides an @@asyncIterator method that returns the async iterator object itself, making the async iterator also async iterable.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/AsyncIterator
    /// </summary>
    public class AsyncIterator : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AsyncIterator(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// request the next iterator result
        /// </summary>
        /// <returns></returns>
        public Task<IteratorResult> Next() => JSRef!.CallAsync<IteratorResult>("next");
        /// <summary>
        /// Returns an IAsyncEnumerable
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public async IAsyncEnumerable<TValue> ToAsyncEnumerable<TValue>()
        {
            while (true)
            {
                using (var next = await Next())
                {
                    if (next.Done) break;
                    yield return next.GetValue<TValue>();
                }
            }
        }
        /// <summary>
        /// Iterates all values and returns them as a List
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public async Task<List<TValue>> ToList<TValue>()
        {
            var ret = new List<TValue>();
            while (true)
            {
                using (var next = await Next())
                {
                    if (next.Done) break;
                    ret.Add(next.GetValue<TValue>());
                }
            }
            return ret;
        }
    }
    /// <summary>
    /// An AsyncIterator object is an object that conforms to the async iterator protocol by providing a next() method that returns a promise fulfilling to an iterator result object. The AsyncIterator.prototype object is a hidden global object that all built-in async iterators inherit from. It provides an @@asyncIterator method that returns the async iterator object itself, making the async iterator also async iterable.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/AsyncIterator
    /// </summary>
    public class AsyncIterator<TValue> : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AsyncIterator(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// request the next iterator result
        /// </summary>
        /// <returns></returns>
        public Task<IteratorResult<TValue>> Next() => JSRef!.CallAsync<IteratorResult<TValue>>("next");
        /// <summary>
        /// Returns an IAsyncEnumerable
        /// </summary>
        /// <returns></returns>
        public async IAsyncEnumerable<TValue> ToAsyncEnumerable()
        {
            while (true)
            {
                using (var next = await Next())
                {
                    if (next.Done) break;
                    yield return next.Value;
                }
            }
        }
        /// <summary>
        /// Iterates all values and returns them as a List
        /// </summary>
        /// <returns></returns>
        public async Task<List<TValue>> ToList()
        {
            var ret = new List<TValue>();
            while (true)
            {
                using (var next = await Next())
                {
                    if (next.Done) break;
                    ret.Add(next.Value);
                }
            }
            return ret;
        }
    }
}
