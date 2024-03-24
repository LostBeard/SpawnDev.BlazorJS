using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DragEvent interface is a DOM event that represents a drag and drop interaction. The user initiates a drag by placing a pointer device (such as a mouse) on the touch surface and then dragging the pointer to a new location (such as another DOM element). Applications are free to interpret a drag and drop interaction in an application-specific way.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/DragEvent
    /// </summary>
    public class DragEvent : MouseEvent
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DragEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The data that is transferred during a drag and drop interaction.
        /// </summary>
        public DataTransfer DataTransfer => JSRef.Get<DataTransfer>("dataTransfer");
    }
}
