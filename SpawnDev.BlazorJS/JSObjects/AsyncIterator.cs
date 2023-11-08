using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Symbol/asyncIterator
    /// </summary>
    public class AsyncIterator : JSObject
    {
        public AsyncIterator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Task<IteratorResult> Next() => JSRef.CallAsync<IteratorResult>("next");
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
    public class AsyncIterator<TValue> : JSObject
    {
        public AsyncIterator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Task<IteratorResult<TValue>> Next() => JSRef.CallAsync<IteratorResult<TValue>>("next");
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
