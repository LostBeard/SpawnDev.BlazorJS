namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A string representing the action type.
    /// </summary>
    public static class MediaSessionAction
    {
        /// <summary>
        /// Moves the playback to a later time in the media.
        /// </summary>
        public const string Play = "play";
        /// <summary>
        /// Pauses playback of the media.
        /// </summary>
        public const string Pause = "pause";
        /// <summary>
        /// Moves the playback to the beginning of the media.
        /// </summary>
        public const string SeekBackward = "seekbackward";
        /// <summary>
        /// Moves the playback to a specified time in the media.
        /// </summary>
        public const string SeekForward = "seekforward";
        /// <summary>
        /// Moves the playback to a specified time in the media.
        /// </summary>
        public const string SeekTo = "seekto";
        /// <summary>
        /// Moves the playback to the previous track.
        /// </summary>
        public const string PreviousTrack = "previoustrack";
        /// <summary>
        /// Moves the playback to the next track.
        /// </summary>
        public const string NextTrack = "nexttrack";
        /// <summary>
        /// Skips the advertisement that is currently playing.
        /// </summary>
        public const string SkipAd = "skipad";
        /// <summary>
        /// Stops the playback of the media.
        /// </summary>
        public const string Stop = "stop";
    }
}
