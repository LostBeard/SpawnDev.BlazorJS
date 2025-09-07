using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webxr/#xrsession
    /// </summary>
    public class XRSession : EventTarget
    {
        /// <inheritdoc/>
        public XRSession(IJSInProcessObjectReference _ref) : base(_ref) { }

        public void End() => JSRef!.CallVoid("end");


        public Task<XRReferenceSpace> RequestReferenceSpace(EnumString<XRReferenceSpaceType> type) => JSRef!.CallAsync<XRReferenceSpace>("requestReferenceSpace", type);
    }
}
