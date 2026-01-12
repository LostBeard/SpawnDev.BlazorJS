using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLTrackElement interface represents an HTML track element within the DOM.<br/>
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
        /// A string that reflects the kind HTML attribute, indicating how the text track is meant to be used.
        /// </summary>
        public string Kind { get => JSRef!.Get<string>("kind"); set => JSRef!.Set("kind", value); }
        /// <summary>
        /// A string that reflects the src HTML attribute, indicating the address of the text track data.
        /// </summary>
        public string Src { get => JSRef!.Get<string>("src"); set => JSRef!.Set("src", value); }
        /// <summary>
        /// A string that reflects the srclang HTML attribute, indicating the language of the text track data.
        /// </summary>
        public string Srclang { get => JSRef!.Get<string>("srclang"); set => JSRef!.Set("srclang", value); }
        /// <summary>
        /// A string that reflects the label HTML attribute, listing a user-readable title for the track.
        /// </summary>
        public string Label { get => JSRef!.Get<string>("label"); set => JSRef!.Set("label", value); }
        /// <summary>
        /// A boolean that reflects the default HTML attribute, indicating that the track is to be enabled if the user's preferences do not indicate that another track would be more appropriate.
        /// </summary>
        public bool Default { get => JSRef!.Get<bool>("default"); set => JSRef!.Set("default", value); }
        /// <summary>
        /// Returns an unsigned short that reflects the Readiness state of the track.
        /// </summary>
        public int ReadyState => JSRef!.Get<int>("readyState");
        /// <summary>
        /// Returns the TextTrack object corresponding to the track element.
        /// </summary>
        public TextTrack Track => JSRef!.Get<TextTrack>("track");
        #endregion

        #region Events
        /// <summary>
        /// Fires when a TextTrack has changed the currently displaying cues. 
        /// </summary>
        public ActionEvent<Event> OnCueChange { get => new ActionEvent<Event>("cuechange", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}