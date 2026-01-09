using Microsoft.JSInterop;
using System.Collections;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The TextTrackCueList interface of the WebVTT API is an array-like object that represents a dynamically updating list of TextTrackCue objects.<br/>
    /// An instance of this type is obtained from TextTrack.cues in order to get all the cues in the TextTrack object. This interface has no constructor.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TextTrackCueList
    /// </summary>
    public class TextTrackCueList : JSObject, IEnumerable<TextTrackCue>
    {
        /// <inheritdoc/>
        public TextTrackCueList(IJSInProcessObjectReference _ref) : base(_ref) { }
        #region IEnumerable
        /// <inheritdoc/>
        public IEnumerator<TextTrackCue> GetEnumerator() => new SimpleEnumerator<TextTrackCue>((i) => this[i], () => Length);
        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
        /// <summary>
        /// An unsigned long that is the number of cues in the list.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public TextTrackCue this[int i] => JSRef!.Get<TextTrackCue>(i);
        /// <summary>
        /// Returns the first TextTrackCue object with the identifier passed to it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TextTrackCue? GetCueById(string id) =>JSRef!.Call<TextTrackCue>("getCueById", id);
    }
}