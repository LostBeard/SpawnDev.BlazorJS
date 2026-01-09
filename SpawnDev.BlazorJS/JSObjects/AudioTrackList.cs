using Microsoft.JSInterop;
using System.Collections;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AudioTrackList interface is used to represent a list of the audio tracks contained within a given HTML media element, with each track represented by a separate AudioTrack object in the list.<br/>
    /// Retrieve an instance of this object with HTMLMediaElement.audioTracks. The individual tracks can be accessed using array syntax.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioTrackList
    /// </summary>
    public class AudioTrackList : EventTarget, IEnumerable<AudioTrack>
    {
        #region IEnumerable
        /// <inheritdoc/>
        public IEnumerator<AudioTrack> GetEnumerator() => new SimpleEnumerator<AudioTrack>((i) => this[i], () => Length);
        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
        /// <inheritdoc/>
        public AudioTrackList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the number of track objects in the list.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// Returns the track found within the list whose id matches the specified string. If no match is found, null is returned.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AudioTrack? GetTrackById(string id) => JSRef!.Call<AudioTrack>("getTrackById", id);
        /// <summary>
        /// The individual tracks can be accessed using the bracket notation [].
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public AudioTrack this[int i] => JSRef!.Get<AudioTrack>(i);
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