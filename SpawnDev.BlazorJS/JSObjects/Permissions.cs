using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{

    // https://developer.mozilla.org/en-US/docs/Web/API/Permissions/query
    public class Permissions : JSObject
    {
        public Permissions(IJSInProcessObjectReference _ref) : base(_ref) { }

        public Task<PermissionStatus> Query(PermissionDescriptor permissionDescriptor) => JSRef.CallAsync<PermissionStatus>("query", permissionDescriptor);
    }
}
