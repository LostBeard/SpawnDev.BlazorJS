using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ScreenOrientation interface of the Screen Orientation API provides information about the current orientation of the document.<br/>
    /// A ScreenOrientation instance object can be retrieved using the screen.orientation property.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ScreenOrientation
    /// </summary>
    public class ScreenOrientation : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ScreenOrientation(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the document's current orientation type, one of:<br/>
        /// portrait-primary<br/>
        /// portrait-secondary<br/>
        /// landscape-primary<br/>
        /// landscape-secondary
        /// </summary>
        public string Type => JSRef!.Get<string>("type");
        /// <summary>
        /// Returns the document's current orientation angle.
        /// </summary>
        public double Angle => JSRef!.Get<double>("angle");
        /// <summary>
        /// Locks the orientation of the containing document to its default orientation and returns a Promise.
        /// </summary>
        /// <param name="orientation">
        /// An orientation lock type. One of the following:<br/>
        /// "any" - Any of portrait-primary, portrait-secondary, landscape-primary or landscape-secondary.<br/>
        /// "natural" - The natural orientation of the screen from the underlying operating system: either portrait-primary or landscape-primary.<br/>
        /// "landscape" - An orientation where screen width is greater than the screen height. Depending on the platform convention, this may be landscape-primary, landscape-secondary, or both.<br/>
        /// "portrait" - An orientation where screen height is greater than the screen width. Depending on the platform convention, this may be portrait-primary, portrait-secondary, or both.<br/>
        /// "portrait-primary" - The "primary" portrait mode. If the natural orientation is a portrait mode (screen height is greater than width), this will be the same as the natural orientation, and correspond to an angle of 0 degrees. If the natural orientation is a landscape mode, then the user agent can choose either portrait orientation as the portrait-primary and portrait-secondary; one of those will be assigned the angle of 90 degrees and the other will have an angle of 270 degrees.<br/>
        /// "portrait-secondary" - The secondary portrait orientation. If the natural orientation is a portrait mode, this will have an angle of 180 degrees (in other words, the device is upside down relative to its natural orientation). If the natural orientation is a landscape mode, this can be either orientation as selected by the user agent: whichever was not selected for portrait-primary.<br/>
        /// "landscape-primary" - The "primary" landscape mode. If the natural orientation is a landscape mode (screen width is greater than height), this will be the same as the natural orientation, and correspond to an angle of 0 degrees. If the natural orientation is a portrait mode, then the user agent can choose either landscape orientation as the landscape-primary with an angle of either 90 or 270 degrees (landscape-secondary will be the other orientation and angle).<br/>
        /// "landscape-secondary" - The secondary landscape mode. If the natural orientation is a landscape mode, this orientation is upside down relative to the natural orientation, and will have an angle of 180 degrees. If the natural orientation is a portrait mode, this can be either orientation as selected by the user agent: whichever was not selected for landscape-primary.<br/>
        /// </param>
        /// <returns>A Promise that resolves after locking succeeds.</returns>
        public Task Lock(string orientation) => JSRef!.CallVoidAsync("lock", orientation);
        /// <summary>
        /// Unlocks the orientation of the containing document from its default orientation.
        /// </summary>
        public void Unlock() => JSRef!.CallVoid("unlock");
        /// <summary>
        /// Fired whenever the screen changes orientation.
        /// </summary>
        public ActionEvent<Event> OnChange { get => new ActionEvent<Event>("change", AddEventListener, RemoveEventListener); set { } }
    }
}
