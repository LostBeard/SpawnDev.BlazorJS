using Microsoft.JSInterop;
using System.Collections;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The TextTrackList interface is used to represent a list of the text tracks defined for the associated video or audio element, with each track represented by a separate TextTrack object in the list.<br/>
    /// Text tracks can be added to a media element declaratively using the &lt;track> element or programmatically using the HTMLMediaElement.addTextTrack() method.<br/>
    /// An instance of this object can be retrieved using the textTracks property of an HTMLMediaElement object.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TextTrackList
    /// </summary>
    public class TextTrackList : EventTarget, IEnumerable<TextTrack>
    {
        #region IEnumerable
        /// <inheritdoc/>
        public IEnumerator<TextTrack> GetEnumerator() => new SimpleEnumerator<TextTrack>((i) => this[i], () => Length);
        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
        /// <inheritdoc/>
        public TextTrackList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the number of track objects in the list.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// Returns the track found within the list whose id matches the specified string. If no match is found, null is returned.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TextTrack? GetTrackById(string id) => JSRef!.Call<TextTrack>("getTrackById", id);
        /// <summary>
        /// The individual tracks can be accessed using the bracket notation [].
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public TextTrack this[int i] => JSRef!.Get<TextTrack>(i);
        /// <summary>
        /// Fired when a new track has been added to the media element.
        /// </summary>
        public ActionEvent<TrackEvent> OnAddTrack { get => new ActionEvent<TrackEvent>("addtrack", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a track has been enabled or disabled.
        /// </summary>
        public ActionEvent<Event> OnChange { get => new ActionEvent<Event>("change", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a track has been removed from the media element.
        /// </summary>
        public ActionEvent<TrackEvent> OnRemoveTrack { get => new ActionEvent<TrackEvent>("removetrack", AddEventListener, RemoveEventListener); set { } }
    }
}