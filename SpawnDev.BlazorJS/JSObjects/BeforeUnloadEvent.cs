using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BeforeUnloadEvent
    /// NOTE: WebKit-derived browsers don't follow the spec for the dialog box. (quoted from MDN page.)
    /// </summary>
    public class BeforeUnloadEvent : Event
    {
        public BeforeUnloadEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string ReturnValue { get => JSRef.Get<string?>("returnValue"); set => JSRef.Set("returnValue", value); }
    }
}
