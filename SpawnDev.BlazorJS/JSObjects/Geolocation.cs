using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Geolocation interface represents an object able to obtain the position of the device programmatically. It gives Web content access to the location of the device. This allows a website or app to offer customized results based on the user's location.
    /// </summary>
    public class Geolocation : JSObject
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Geolocation(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        #endregion

        #region Methods
        /// <summary>
        /// Removes the particular handler previously installed using watchPosition().
        /// </summary>
        public void ClearWatch(int id) => JSRef.CallVoid("clearWatch");
        /// <summary>
        /// Determines the device's current location and gives back a GeolocationPosition object with the data.
        /// </summary>
        /// <param name="success"></param>
        public void GetCurrentPosition(ActionCallback<GeolocationPosition> success) => JSRef.CallVoid("getCurrentPosition", success);
        /// <summary>
        /// Determines the device's current location and gives back a GeolocationPosition object with the data.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="error"></param>
        public void GetCurrentPosition(ActionCallback<GeolocationPosition> success, ActionCallback<GeolocationPositionError> error) => JSRef.CallVoid("getCurrentPosition", success, error);
        /// <summary>
        /// Determines the device's current location and gives back a GeolocationPosition object with the data.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="error"></param>
        /// <param name="options"></param>
        public void GetCurrentPosition(ActionCallback<GeolocationPosition> success, ActionCallback<GeolocationPositionError> error, GetCurrentPositionOptions options) => JSRef.CallVoid("getCurrentPosition", success, error, options);
        /// <summary>
        /// The Geolocation method watchPosition() method is used to register a handler function that will be called automatically each time the position of the device changes. You can also, optionally, specify an error handling callback function.
        /// </summary>
        /// <param name="success"></param>
        /// <returns></returns>
        public int WatchPosition(ActionCallback<GeolocationPosition> success) => JSRef.Call<int>("watchPosition", success);
        /// <summary>
        /// The Geolocation method watchPosition() method is used to register a handler function that will be called automatically each time the position of the device changes. You can also, optionally, specify an error handling callback function.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public int WatchPosition(ActionCallback<GeolocationPosition> success, ActionCallback<GeolocationPositionError> error) => JSRef.Call<int>("watchPosition", success, error);
        /// <summary>
        /// The Geolocation method watchPosition() method is used to register a handler function that will be called automatically each time the position of the device changes. You can also, optionally, specify an error handling callback function.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="error"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public int WatchPosition(ActionCallback<GeolocationPosition> success, ActionCallback<GeolocationPositionError> error, GetCurrentPositionOptions options) => JSRef.Call<int>("watchPosition", success, error, options);
        #endregion

        #region Events
        #endregion
    }
}
