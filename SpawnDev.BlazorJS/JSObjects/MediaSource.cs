using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaSource interface of the Media Source Extensions API represents a source of media data for an HTMLMediaElement object. A MediaSource object can be attached to a HTMLMediaElement to be played in the user agent.
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaSource
    /// </summary>
    public class MediaSource : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MediaSource(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The MediaSource() constructor of the MediaSource interface constructs and returns a new MediaSource object with no associated source buffers.
        /// </summary>
        public MediaSource() : base(JS.New(nameof(MediaSource))) { }
        /// <summary>
        /// Returns a SourceBufferList object containing a subset of the SourceBuffer objects contained within MediaSource.sourceBuffers — the list of objects providing the selected video track, enabled audio tracks, and shown/hidden text tracks.
        /// </summary>
        public SourceBufferList ActiveSourceBuffers => JSRef!.Get<SourceBufferList>("activeSourceBuffers");
        /// <summary>
        /// Gets and sets the duration of the current media being presented.
        /// </summary>
        public double Duration { get => JSRef!.Get<double>("duration"); set => JSRef!.Set("duarion", value); }
        /// <summary>
        /// Inside a dedicated worker, returns a MediaSourceHandle object, a proxy for the MediaSource that can be transferred from the worker back to the main thread and attached to a media element via its HTMLMediaElement.srcObject property.
        /// </summary>
        public MediaSourceHandle? Handle => JSRef!.Get<MediaSourceHandle?>("handle");
        /// <summary>
        /// Returns an enum representing the state of the current MediaSource, whether it is not currently attached to a media element (closed), attached and ready to receive SourceBuffer objects (open), or attached but the stream has been ended via MediaSource.endOfStream() (ended.)
        /// </summary>
        public string ReadyState => JSRef!.Get<string>("readyState");
        /// <summary>
        /// Returns a SourceBufferList object containing the list of SourceBuffer objects associated with this MediaSource.
        /// </summary>
        public SourceBufferList SourceBuffers => JSRef!.Get<SourceBufferList>("sourceBuffers");
        /// <summary>
        /// A boolean; returns true if MediaSource worker support is implemented, providing a low-latency feature detection mechanism.
        /// </summary>
        public static bool CanConstructInDedicatedWorker => JS.Get<bool>($"MediaSource.canConstructInDedicatedWorker");
        /// <summary>
        /// Returns a boolean value indicating if the given MIME type is supported by the current user agent — this is, if it can successfully create SourceBuffer objects for that MIME type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsTypeSupported(string type) => JS.Call<bool>("MediaSource.isTypeSupported", type);
        /// <summary>
        /// The addSourceBuffer() method of the MediaSource interface creates a new SourceBuffer of the given MIME type and adds it to the MediaSource's sourceBuffers list. The new SourceBuffer is also returned.
        /// </summary>
        /// <param name="mimeType">A string specifying the MIME type of the SourceBuffer to create and add to the MediaSource.</param>
        /// <returns>A SourceBuffer object representing the new source buffer that has been created and added to the media source.</returns>
        public SourceBuffer AddSourceBuffer(string mimeType) => JSRef!.Call<SourceBuffer>("addSourceBuffer", mimeType);
        /// <summary>
        /// The clearLiveSeekableRange() method of the MediaSource interface clears a seekable range previously set with a call to setLiveSeekableRange().
        /// </summary>
        public void ClearLiveSeekableRange() => JSRef!.CallVoid("clearLiveSeekableRange");
        /// <summary>
        /// The endOfStream() method of the MediaSource interface signals the end of the stream.
        /// </summary>
        /// <param name="endOfStreamError">A string representing an error to throw when the end of the stream is reached. The possible values are:<br/>
        /// network  -  Terminates playback and signals that a network error has occurred.This can be used create a custom error handler related to media streams.For example, you might have a function that handles media chunk requests, separate from other network requests.When you make a fetch() request for a media chunk and receive a network error, you might want to call endOfStream('network'), display a descriptive message in the UI, and maybe retry the network request immediately or wait until the network is back up(via some kind of polling.) <br/>
        /// decode - Terminates playback and signals that a decoding error has occurred.This can be used to indicate that a parsing error has occurred while fetching media data; maybe the data is corrupt, or is encoded using a codec that the browser doesn't know how to decode.</param>
        public void EndOfStream(string endOfStreamError) => JSRef!.CallVoid("endOfStream", endOfStreamError);
        /// <summary>
        /// The endOfStream() method of the MediaSource interface signals the end of the stream.
        /// </summary>
        public void EndOfStream() => JSRef!.CallVoid("endOfStream");
        /// <summary>
        /// The removeSourceBuffer() method of the MediaSource interface removes the given SourceBuffer from the SourceBufferList associated with this MediaSource object.
        /// </summary>
        /// <param name="sourceBuffer"></param>
        public void RemoveSourceStream(SourceBuffer sourceBuffer) => JSRef!.CallVoid("removeSourceStream", sourceBuffer);
        /// <summary>
        /// The setLiveSeekableRange() method of the MediaSource interface sets the range that the user can seek to in the media element.
        /// </summary>
        /// <param name="start">The start of the seekable range to set in seconds measured from the beginning of the source. If the duration of the media source is positive infinity, then the TimeRanges object returned by the HTMLMediaElement.seekable property will have a start timestamp no greater than this value.</param>
        /// <param name="end">The end of the seekable range to set in seconds measured from the beginning of the source. If the duration of the media source is positive infinity, then the TimeRanges object returned by the HTMLMediaElement.seekable property will have an end timestamp no less than this value.</param>
        public void SetLiveSeekableRange(double start, double end) => JSRef!.CallVoid("setLiveSeekableRange", start, end);
        /// <summary>
        /// Fired when the MediaSource instance is not attached to a media element anymore.
        /// </summary>
        public ActionEvent<Event> OnSourceClose { get => new ActionEvent<Event>("sourceclose", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the MediaSource instance is still attached to a media element, but endOfStream() has been called.
        /// </summary>
        public ActionEvent<Event> OnSourceEnded { get => new ActionEvent<Event>("sourceended", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the MediaSource instance has been opened by a media element and is ready for data to be appended to the SourceBuffer objects in sourceBuffers.
        /// </summary>
        public ActionEvent<Event> OnSourceOpen { get => new ActionEvent<Event>("sourceopen", AddEventListener, RemoveEventListener); set { } }
    }
}