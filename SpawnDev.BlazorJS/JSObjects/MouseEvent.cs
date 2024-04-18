using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MouseEvent interface represents events that occur due to the user interacting with a pointing device (such as a mouse). Common events using this interface include click, dblclick, mouseup, mousedown.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent<br/>
    /// TODO - finish interface
    /// </summary>
    public class MouseEvent : UIEvent
    {
        public MouseEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
