using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRHand interface is pair iterator (an ordered map) with the key being the hand joints and the value being an XRJointSpace.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRHand
    /// </summary>
    public class XRHand : Map<string, XRJointSpace>
    {
        /// <inheritdoc/>
        public XRHand(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
