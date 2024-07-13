using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PromiseRejectionEvent interface represents events which are sent to the global script context when JavaScript Promises are rejected. These events are particularly useful for telemetry and debugging purposes.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/PromiseRejectionEvent
    /// </summary>
    public class PromiseRejectionEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PromiseRejectionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A value or Object indicating why the promise was rejected, as passed to Promise.reject().
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ReasonAs<T>() => JSRef!.Get<T>("reason");
        /// <summary>
        /// The JavaScript Promise that was rejected.
        /// </summary>
        public Promise Promise => JSRef!.Get<Promise>("promise");
    }
}
