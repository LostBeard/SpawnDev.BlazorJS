using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaKeySystemAccess interface of the Encrypted Media Extensions API provides access to a Key System for decryption and/or a content protection provider. You can request an instance of this object using the Navigator.requestMediaKeySystemAccess() method.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaKeySystemAccess
    /// </summary>
    public class MediaKeySystemAccess : JSObject
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MediaKeySystemAccess(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// Returns a string identifying the key system being used.
        /// </summary>
        public string KeySystem => JSRef.Get<string>("keySystem");
        #endregion

        #region Methods
        /// <summary>
        /// Returns a Promise that resolves to a new MediaKeys object.
        /// </summary>
        /// <returns></returns>
        public Task<MediaKeys> CreateMediaKeys() => JSRef.CallAsync<MediaKeys>("createMediaKeys");
        /// <summary>
        /// Returns an object with the supported combination of configuration options.
        /// </summary>
        /// <returns></returns>
        public Task<MediaKeySystemAccessConfig> GetConfiguration() => JSRef.CallAsync<MediaKeySystemAccessConfig>("getConfiguration");
        #endregion

        #region Events
        #endregion
    }
}
