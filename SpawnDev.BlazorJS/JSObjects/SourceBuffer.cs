using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SourceBuffer interface represents a chunk of media to be passed into an HTMLMediaElement and played, via a MediaSource object. This can be made up of one or several media segments.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/SourceBuffer
    /// </summary>
    public class SourceBuffer : EventTarget
    {
        /// <inheritdoc/>
        public SourceBuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Controls the timestamp for the end of the append window.
        /// </summary>
        public double AppendWindowEnd { get => JSRef!.Get<double>("appendWindowEnd"); set => JSRef!.Set("appendWindowEnd", value); }
        /// <summary>
        /// Controls the timestamp for the start of the append window. This is a timestamp range that can be used to filter what media data is appended to the SourceBuffer. Coded media frames with timestamps within this range will be appended, whereas those outside the range will be filtered out.
        /// </summary>
        public double AppendWindowStart { get => JSRef!.Get<double>("appendWindowStart"); set => JSRef!.Set("appendWindowStart", value); }
        /// <summary>
        /// A list of the audio tracks currently contained inside the SourceBuffer.
        /// </summary>
        public AudioTrackList AudioTracks => JSRef!.Get<AudioTrackList>("audioTracks");
        /// <summary>
        /// Returns the time ranges that are currently buffered in the SourceBuffer.
        /// </summary>
        public TimeRanges Buffered => JSRef!.Get<TimeRanges>("buffered");
        /// <summary>
        /// Controls how the order of media segments in the SourceBuffer is handled, in terms of whether they can be appended in any order, or they have to be kept in a strict sequence.<br/>
        /// The two available values are:<br/>
        /// segments - The media segment timestamps determine the order in which the segments are played.The segments can be appended to the SourceBuffer in any order.<br/>
        /// sequence - The order in which the segments are appended to the SourceBuffer determines the order in which they are played. Segment timestamps are generated automatically for the segments that observe this order.
        /// </summary>
        public string Mode { get => JSRef!.Get<string>("mode"); set => JSRef!.Set("mode", value); }
        /// <summary>
        /// A list of the text tracks currently contained inside the SourceBuffer.
        /// </summary>
        public TextTrackList TextTracks => JSRef!.Get<TextTrackList>("textTracks");
        /// <summary>
        /// Controls the offset applied to timestamps inside media segments that are subsequently appended to the SourceBuffer.
        /// </summary>
        public double TimestampOffset { get => JSRef!.Get<double>("timestampOffset"); set => JSRef!.Set("timestampOffset", value); }
        /// <summary>
        /// A boolean indicating whether the SourceBuffer is currently being updated — i.e., whether an appendBuffer() or remove() operation is currently in progress.
        /// </summary>
        public bool Updating => JSRef!.Get<bool>("updating");
        /// <summary>
        /// A list of the video tracks currently contained inside the SourceBuffer.
        /// </summary>
        public VideoTrackList VideoTracks => JSRef!.Get<VideoTrackList>("videoTracks");
        /// <summary>
        /// Aborts the current segment and resets the segment parser.
        /// </summary>
        public void Abort() => JSRef!.CallVoid("abort");
        /// <summary>
        /// Appends media segment data from an ArrayBuffer, a TypedArray or a DataView object to the SourceBuffer.
        /// </summary>
        /// <param name="source">Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer.</param>
        public void AppendBuffer(ArrayBuffer source) => JSRef!.CallVoid("appendBuffer", source);
        /// <summary>
        /// Appends media segment data from an ArrayBuffer, a TypedArray or a DataView object to the SourceBuffer.
        /// </summary>
        /// <param name="source">Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer.</param>
        public void AppendBuffer(TypedArray source) => JSRef!.CallVoid("appendBuffer", source);
        /// <summary>
        /// Appends media segment data from an ArrayBuffer, a TypedArray or a DataView object to the SourceBuffer.
        /// </summary>
        /// <param name="source">Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer.</param>
        public void AppendBuffer(byte[] source) => JSRef!.CallVoid("appendBuffer", source);
        /// <summary>
        /// Appends media segment data from an ArrayBuffer, a TypedArray or a DataView object to the SourceBuffer.
        /// </summary>
        /// <param name="source">Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer.</param>
        public void AppendBuffer(DataView source) => JSRef!.CallVoid("appendBuffer", source);
        /// <summary>
        /// Starts the process of asynchronously appending the specified buffer to the SourceBuffer. Returns a Promise which is fulfilled once the buffer has been appended.
        /// </summary>
        /// <param name="source">Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer.</param>
        /// <returns>A Promise which is fulfilled when the buffer has been added successfully to the SourceBuffer object, or null, if the request could not be initiated.</returns>
        public Task AppendBufferAsync(ArrayBuffer source) => JSRef!.CallVoidAsync("appendBufferAsync", source);
        /// <summary>
        /// Starts the process of asynchronously appending the specified buffer to the SourceBuffer. Returns a Promise which is fulfilled once the buffer has been appended.
        /// </summary>
        /// <param name="source">Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer.</param>
        /// <returns>A Promise which is fulfilled when the buffer has been added successfully to the SourceBuffer object, or null, if the request could not be initiated.</returns>
        public Task AppendBufferAsync(TypedArray source) => JSRef!.CallVoidAsync("appendBufferAsync", source);
        /// <summary>
        /// Starts the process of asynchronously appending the specified buffer to the SourceBuffer. Returns a Promise which is fulfilled once the buffer has been appended.
        /// </summary>
        /// <param name="source">Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer.</param>
        /// <returns>A Promise which is fulfilled when the buffer has been added successfully to the SourceBuffer object, or null, if the request could not be initiated.</returns>
        public Task AppendBufferAsync(byte[] source) => JSRef!.CallVoidAsync("appendBufferAsync", source);
        /// <summary>
        /// Starts the process of asynchronously appending the specified buffer to the SourceBuffer. Returns a Promise which is fulfilled once the buffer has been appended.
        /// </summary>
        /// <param name="source">Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer.</param>
        /// <returns>A Promise which is fulfilled when the buffer has been added successfully to the SourceBuffer object, or null, if the request could not be initiated.</returns>
        public Task AppendBufferAsync(DataView source) => JSRef!.CallVoidAsync("appendBufferAsync", source);
        /// <summary>
        /// Changes the MIME type that future calls to appendBuffer() will expect the new data to conform to.
        /// </summary>
        /// <param name="type">A string specifying the MIME type that future buffers will conform to.</param>
        public void ChangeType(string type) => JSRef!.CallVoid("changeType", type);
        /// <summary>
        /// Removes media segments within a specific time range from the SourceBuffer.
        /// </summary>
        /// <param name="start">A double representing the start of the time range, in seconds.</param>
        /// <param name="end">A double representing the end of the time range, in seconds.</param>
        public void Remove(double start, double end) => JSRef!.CallVoid("remove", start, end);
        /// <summary>
        /// Starts the process of asynchronously removing media segments in the specified range from the SourceBuffer. Returns a Promise which is fulfilled once all matching segments have been removed.
        /// </summary>
        /// <param name="start">A double representing the start of the time range, in seconds.</param>
        /// <param name="end">A double representing the end of the time range, in seconds.</param>
        /// <returns>A Promise whose fulfillment handler is executed once the buffers in the specified time range have been removed from the SourceBuffer.</returns>
        public Task RemoveAsync(double start, double end) => JSRef!.CallVoidAsync("removeAsync", start, end);
        /// <summary>
        /// Fired when the buffer appending is aborted, because the SourceBuffer.abort() or MediaSource.removeSourceBuffer() method is called while the SourceBuffer.appendBuffer() algorithm is still running. SourceBuffer.updating changes from true to false.
        /// </summary>
        public ActionEvent<Event> OnAbort { get => new ActionEvent<Event>("abort", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when an error occurs during the processing of an appendBuffer() operation. SourceBuffer.updating changes from true to false.
        /// </summary>
        public ActionEvent<Event> OnError { get => new ActionEvent<Event>("error", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired whenever SourceBuffer.appendBuffer() or SourceBuffer.remove() completes. SourceBuffer.updating changes from true to false.
        /// </summary>
        public ActionEvent<Event> OnUpdate { get => new ActionEvent<Event>("update", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired after the (not necessarily successful) completion of an appendBuffer() or remove() operation. This event is fired after the update, error, or abort events.
        /// </summary>
        public ActionEvent<Event> OnUpdateEnd { get => new ActionEvent<Event>("updateend", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when an appendBuffer() or remove() operation begins. updating changes from false to true.
        /// </summary>
        public ActionEvent<Event> OnUpdateStart { get => new ActionEvent<Event>("updatestart", AddEventListener, RemoveEventListener); set { } }

    }
}