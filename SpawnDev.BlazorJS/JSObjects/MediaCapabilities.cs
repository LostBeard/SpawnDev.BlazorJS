using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaCapabilities interface of the Media Capabilities API provides information about the decoding abilities of the device, system and browser. The API can be used to query the browser about the decoding abilities of the device based on codecs, profile, resolution, and bitrates. The information can be used to serve optimal media streams to the user and determine if playback should be smooth and power efficient.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaCapabilities
    /// </summary>
    public class MediaCapabilities : JSObject
    {
        #region Constructors
        public MediaCapabilities(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
        #region Methods
        /// <summary>
        /// When passed a valid media configuration, it returns a promise with information as to whether the media type is supported, and whether decoding such media would be smooth and power efficient.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public Task<MediaCapabilitiesInfo> DecodingInfo(DecodingConfiguration configuration) => JSRef!.CallAsync<MediaCapabilitiesInfo>("decodingInfo", configuration);
        /// <summary>
        /// When passed a valid media configuration, it returns a promise with information as to whether the media type is supported, and whether encoding such media would be smooth and power efficient.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public Task<MediaCapabilitiesInfo> EncodingInfo(EncodingConfiguration configuration) => JSRef!.CallAsync<MediaCapabilitiesInfo>("encodingInfo", configuration);
        #endregion
    }
}
