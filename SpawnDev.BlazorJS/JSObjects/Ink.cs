using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Ink interface of the Ink API provides access to InkPresenter objects for the application to use to render ink strokes.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Ink
    /// </summary>
    public class Ink : JSObject
    {
        public Ink(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Task<InkPresenter> RequestPresenter(InkPresenterParam param) => JSRef!.CallAsync<InkPresenter>("requestPresenter", param);
    }
}
