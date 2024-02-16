using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLTrackElement interface represents an HTML track element within the DOM.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLTrackElement
    /// </summary>
    public class HTMLTrackElement : HTMLElement
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLTrackElement(IJSInProcessObjectReference _ref) : base(_ref) { }

        #region Properties
        /// <summary>
        /// A string that reflects the src HTML attribute, indicating the address of the text track data.
        /// </summary>
        public string Src { get => JSRef.Get<string>("src"); set => JSRef.Set("src", value); }
        #endregion

        #region Events
        /// <summary>
        /// Fires when a TextTrack has changed the currently displaying cues. 
        /// </summary>
        public JSEventCallback<Event> OnCueChange { get => new JSEventCallback<Event>(o => AddEventListener("cuechange", o), o => RemoveEventListener("cuechange", o)); set { /** required **/ } }
        #endregion
    }
}