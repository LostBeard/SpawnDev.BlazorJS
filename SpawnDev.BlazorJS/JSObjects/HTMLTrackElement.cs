using Microsoft.AspNetCore.Components;
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
        /// Explicit conversion from ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLTrackElement?(ElementReference elementReference) => elementReference.Context == null || string.IsNullOrEmpty(elementReference.Id) ? null : new HTMLTrackElement(elementReference);
        /// <summary>
        /// Explicit conversion from ElementReference?
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLTrackElement?(ElementReference? elementReference) => elementReference == null || elementReference.Value.Context == null || string.IsNullOrEmpty(elementReference.Value.Id) ? null : new HTMLTrackElement(elementReference.Value);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLTrackElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLTrackElement(ElementReference elementReference) : base(elementReference) { }

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
        public JSEventCallback<Event> OnCueChange { get => new JSEventCallback<Event>("cuechange", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}