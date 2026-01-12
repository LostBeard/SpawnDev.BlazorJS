using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for the FaceDetector constructor.
    /// </summary>
    public class FaceDetectorOptions
    {
        /// <summary>
        /// A boolean value indicating whether the face detector should prioritize performance over accuracy.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? FastMode { get; set; }

        /// <summary>
        /// An integer value indicating the maximum number of faces to be detected.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxDetectedFaces { get; set; }
    }
}
