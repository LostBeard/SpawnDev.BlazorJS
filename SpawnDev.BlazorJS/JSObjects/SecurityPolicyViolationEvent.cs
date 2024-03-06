using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SecurityPolicyViolationEvent interface inherits from Event, and represents the event object of an event sent on a document or worker when its content security policy is violated.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/SecurityPolicyViolationEvent< br />
    /// TODO - finish
    /// </summary>
    public class SecurityPolicyViolationEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public SecurityPolicyViolationEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
