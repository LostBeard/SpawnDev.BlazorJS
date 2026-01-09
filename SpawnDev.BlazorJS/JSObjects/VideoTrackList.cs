using Microsoft.JSInterop;
using System.Collections;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The VideoTrackList interface is used to represent a list of the video tracks contained within a &lt;video> element, with each track represented by a separate VideoTrack object in the list.<br/>
    /// Retrieve an instance of this object with HTMLMediaElement.videoTracks. The individual tracks can be accessed using array syntax or functions such as forEach() for example.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/VideoTrackList
    /// </summary>
    public class VideoTrackList : EventTarget, IEnumerable<VideoTrack>
    {
        #region IEnumerable
        /// <inheritdoc/>
        public IEnumerator<VideoTrack> GetEnumerator() => new SimpleEnumerator<VideoTrack>((i) => this[i], () => Length);
        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
        /// <inheritdoc/>
        public VideoTrackList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the number of track objects in the list.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// The index of the currently selected track, if any, or −1 otherwise.
        /// </summary>
        public int SelectedIndex => JSRef!.Get<int>("selectedIndex");
        /// <summary>
        /// Returns the track found within the list whose id matches the specified string. If no match is found, null is returned.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VideoTrack? GetTrackById(string id) => JSRef!.Call<VideoTrack>("getTrackById", id);
        /// <summary>
        /// The individual tracks can be accessed using the bracket notation [].
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public VideoTrack this[int i] => JSRef!.Get<VideoTrack>(i);
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