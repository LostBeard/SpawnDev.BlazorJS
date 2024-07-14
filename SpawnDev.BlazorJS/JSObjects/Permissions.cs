using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Permissions interface of the Permissions API provides the core Permission API functionality, such as methods for querying and revoking permissions<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Permissions
    /// </summary>
    public class Permissions : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Permissions(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the user permission status for a given API.
        /// </summary>
        /// <param name="permissionDescriptor"></param>
        /// <returns></returns>
        public Task<PermissionStatus> Query(PermissionDescriptor permissionDescriptor) => JSRef!.CallAsync<PermissionStatus>("query", permissionDescriptor);
    }
}
