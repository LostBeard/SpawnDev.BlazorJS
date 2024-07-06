using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaStreamConstraints dictionary is used to instruct the User Agent what sort of MediaStreamTracks to include in the MediaStream returned by getUserMedia().<br/>
    /// https://www.w3.org/TR/mediacapture-streams/#dom-mediastreamconstraints
    /// </summary>
    public class MediaStreamConstraints
    {
        /// <summary>
        /// video of type (boolean or MediaTrackConstraints), defaulting to false<br/>
        /// If true, it requests that the returned MediaStream contain a video track.If a Constraints structure is provided, it further specifies the nature and settings of the video Track.If false, the MediaStream MUST NOT contain a video Track.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<bool, MediaTrackConstraints>? Video { get; set; }
        /// <summary>
        /// audio of type (boolean or MediaTrackConstraints), defaulting to false<br/>
        /// If true, it requests that the returned MediaStream contain an audio track.If a Constraints structure is provided, it further specifies the nature and settings of the audio Track.If false, the MediaStream MUST NOT contain an audio Track.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<bool, MediaTrackConstraints>? Audio { get; set; }
    }
}
