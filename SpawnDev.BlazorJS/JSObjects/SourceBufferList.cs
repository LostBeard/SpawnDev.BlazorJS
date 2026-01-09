using Microsoft.JSInterop;
using System.Collections;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SourceBufferList interface represents a simple container list for multiple SourceBuffer objects.<br/>
    /// The source buffer list containing the SourceBuffers appended to a particular MediaSource can be retrieved using the MediaSource.sourceBuffers property.<br/>
    /// The individual source buffers can be accessed using the bracket notation [].
    /// https://developer.mozilla.org/en-US/docs/Web/API/SourceBufferList
    /// </summary>
    public class SourceBufferList : EventTarget, IEnumerable<SourceBuffer>
    {
        #region IEnumerable
        /// <inheritdoc/>
        public IEnumerator<SourceBuffer> GetEnumerator() => new SimpleEnumerator<SourceBuffer>((i) => this[i], () => Length);
        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
        /// <inheritdoc/>
        public SourceBufferList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the number of SourceBuffer objects in the list.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// The individual source buffers can be accessed using the bracket notation [].
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public SourceBuffer this[int i] => JSRef!.Get<SourceBuffer>(i);
        /// <summary>
        /// Fired when a SourceBuffer is added to the list.
        /// </summary>
        public ActionEvent<Event> OnAddSourceBuffer { get => new ActionEvent<Event>("addsourcebuffer", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a SourceBuffer is removed from the list.
        /// </summary>
        public ActionEvent<Event> OnRemoveSourceBuffer { get => new ActionEvent<Event>("removesourcebuffer", AddEventListener, RemoveEventListener); set { } }
    }
}