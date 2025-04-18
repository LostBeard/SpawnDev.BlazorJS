using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GATTServerDisconnectedEvent interface of the Web Bluetooth API represents a GATT server disconnection event.<br/>
    /// </summary>
    public class GATTServerDisconnectedEvent : Event
    {
        /// <inheritdoc/>
        public GATTServerDisconnectedEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Property used to describe state; value is "disconnected" string
        /// </summary>
        public string State => JSRef!.Get<string>("state");
    }
}
