using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaSession interface of the Media Session API allows a web page to provide custom behaviors for standard media playback interactions, and to report metadata that can be sent by the user agent to the device or operating system for display in standardized user interface elements.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaSession
    /// </summary>
    public class MediaSession : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MediaSession(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an instance of MediaMetadata, which contains rich media metadata for display in a platform UI.
        /// </summary>
        public MediaMetadata? Metadata { get => JSRef!.Get<MediaMetadata?>("metadata"); set => JSRef!.Set("metadata", value); }
        /// <summary>
        /// Returns the current playback state of the media session, which can be one of "none", "paused", or "playing".
        /// </summary>
        public string PlaybackState { get => JSRef!.Get<string>("playbackState"); set => JSRef!.Set("playbackState", value); }
        /// <summary>
        /// Sets the action handler for a specified action type.
        /// </summary>
        /// <param name="action">A string representing the action type to listen for.</param>
        /// <param name="handler">A function to call when the specified action is triggered. Return null to clear the handler.</param>
        public void SetActionHandler(string action, ActionCallback? handler) => JSRef!.CallVoid("setActionHandler", action, handler);
        /// <summary>
        /// Sets the action handler for a specified action type.
        /// </summary>
        /// <param name="action">A string representing the action type to listen for.</param>
        /// <param name="handler">A function to call when the specified action is triggered. Return null to clear the handler.</param>
        public void SetActionHandler(string action, ActionCallback<MediaSessionActionDetails>? handler) => JSRef!.CallVoid("setActionHandler", action, handler);
        /// <summary>
        /// Sets the playback position and speed of the media session.
        /// </summary>
        /// <param name="state"></param>
        public void SetPositionState(MediaPositionState state) => JSRef!.CallVoid("setPositionState", state);
    }
}
