using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The VideoResizeModeEnum enum of the Media Statistics API is used to describe the resize mode of a video source.
    /// </summary>
    public enum VideoResizeModeEnum
    {
        /// <summary>
        /// This resolution and frame rate is offered by the camera, its driver, or the OS.
        /// </summary>
        [JsonPropertyName("none")]
        None,
        /// <summary>
        /// This resolution is downscaled and/or cropped from a higher camera resolution by the User Agent, or its frame rate is decimated by the User Agent. The media MUST NOT be upscaled, stretched or have fake data created that did not occur in the input source, except as noted below.
        /// </summary>
        [JsonPropertyName("crop-and-scale")]
        CropAndScale,
    }
}
