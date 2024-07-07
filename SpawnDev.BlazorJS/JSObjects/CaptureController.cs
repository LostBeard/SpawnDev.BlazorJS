using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CaptureController interface provides methods that can be used to further manipulate a capture session separate from its initiation via MediaDevices.getDisplayMedia().<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CaptureController
    /// </summary>
    public class CaptureController : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public CaptureController(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The CaptureController constructor creates a new CaptureController object instance.
        /// </summary>
        public CaptureController() : base(JS.New(nameof(CaptureController))) { }
        /// <summary>
        /// The CaptureController interface's setFocusBehavior() method controls whether the captured tab or window will be focused when an associated MediaDevices.getDisplayMedia() Promise fulfills, or whether the focus will remain with the tab containing the capturing app.
        /// </summary>
        /// <param name="focusBehavior"></param>
        public void SetFocusBehavior(EnumString<CaptureStartFocusBehavior> focusBehavior) => JSRef!.CallVoid("setFocusBehavior", focusBehavior);
    }
}
