using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class PermissionStatus : EventTarget
    {
        public PermissionStatus(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns the name of a requested permission, identical to the name passed to Permissions.query
        /// </summary>
        public string Name => JSRef.Get<string>("name");
        /// <summary>
        /// Returns the state of a requested permission; one of 'granted', 'denied', or 'prompt'.
        /// </summary>
        public string State => JSRef.Get<string>("state");
        /// <summary>
        /// Returns the state of a requested permission; one of 'granted', 'denied', or 'prompt'. Later versions of the specification replace this with PermissionStatus.state.
        /// </summary>
        public string Status => JSRef.Get<string>("status");
        /// <summary>
        /// The change event of the PermissionStatus interface fires whenever the PermissionStatus.state property changes.
        /// </summary>
        public JSEventCallback OnChange { get => new JSEventCallback(o => AddEventListener("change", o), o => RemoveEventListener("change", o)); set { } }
    }
}
