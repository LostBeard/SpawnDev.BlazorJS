using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Result type returned from Atomics.WaitAsync()<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Atomics/waitAsync#return_value
    /// </summary>
    public class AtomicsWaitAsyncResult : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AtomicsWaitAsyncResult(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A boolean indicating whether the value property is a Promise or not.
        /// </summary>
        public bool Async => JSRef!.Get<bool>("async");
        /// <summary>
        /// If async is false, it will be a string which is either "not-equal" or "timed-out" (only when the timeout parameter is 0). If async is true, it will be null.
        /// </summary>
        public string? ValueString => Async ? null : JSRef!.Get<string>("value");
        /// <summary>
        /// If async is true, it will be a Task which is fulfilled with a string value, either "ok" or "timed-out". The promise is never rejected. If async is false, it will be null.
        /// </summary>
        public Task<string>? ValueTask => !Async ? null : JSRef!.GetAsync<string>("value");
    }
}
