using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The IdleDeadline interface is used as the data type of the input parameter to idle callbacks established by calling Window.requestIdleCallback(). It offers a method, timeRemaining(), which lets you determine how much longer the user agent estimates it will remain idle and a property, didTimeout, which lets you determine if your callback is executing because its timeout duration expired.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IdleDeadline
    /// </summary>
    public class IdleDeadline : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IdleDeadline(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a DOMHighResTimeStamp, which is a floating-point value providing an estimate of the number of milliseconds remaining in the current idle period. If the idle period is over, the value is 0. Your callback can call this repeatedly to see if there's enough time left to do more work before returning.
        /// </summary>
        /// <returns></returns>
        public double TimeRemaining() => JSRef!.Invoke<double>("timeRemaining");
        /// <summary>
        /// A Boolean whose value is true if the callback is being executed because the timeout specified when the idle callback was installed has expired.
        /// </summary>
        public bool DidTimeout => JSRef!.Get<bool>("didTimeout");
    }
}
