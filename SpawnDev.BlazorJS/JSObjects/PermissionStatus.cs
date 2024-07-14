using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PermissionStatus interface of the Permissions API provides the state of an object and an event handler for monitoring changes to said state.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PermissionStatus
    /// </summary>
    public class PermissionStatus : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PermissionStatus(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns the name of a requested permission, identical to the name passed to Permissions.query
        /// </summary>
        public string Name => JSRef!.Get<string>("name");
        /// <summary>
        /// Returns the state of a requested permission; one of 'granted', 'denied', or 'prompt'.
        /// </summary>
        public string State => JSRef!.Get<string>("state");
        /// <summary>
        /// Returns the state of a requested permission; one of 'granted', 'denied', or 'prompt'. Later versions of the specification replace this with PermissionStatus.state.
        /// </summary>
        public string Status => JSRef!.Get<string>("status");
        /// <summary>
        /// The change event of the PermissionStatus interface fires whenever the PermissionStatus.state property changes.
        /// </summary>
        public JSEventCallback<Event> OnChange { get => new JSEventCallback<Event>("change", AddEventListener, RemoveEventListener); set { } }
    }
}
