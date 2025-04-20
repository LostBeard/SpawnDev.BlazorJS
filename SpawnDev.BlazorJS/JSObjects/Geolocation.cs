using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Geolocation interface represents an object able to obtain the position of the device programmatically. It gives Web content access to the location of the device. This allows a website or app to offer customized results based on the user's location.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Geolocation
    /// </summary>
    public class Geolocation : JSObject
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public Geolocation(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        #endregion

        #region Methods
        /// <summary>
        /// Removes the particular handler previously installed using watchPosition().
        /// </summary>
        public void ClearWatch(int id) => JSRef!.CallVoid("clearWatch", id);
        /// <summary>
        /// Determines the device's current location and gives back a GeolocationPosition object with the data.
        /// </summary>
        /// <param name="success"></param>
        public void GetCurrentPosition(ActionCallback<GeolocationPosition> success) => JSRef!.CallVoid("getCurrentPosition", success);
        /// <summary>
        /// Determines the device's current location and gives back a GeolocationPosition object with the data.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="error"></param>
        public void GetCurrentPosition(ActionCallback<GeolocationPosition> success, ActionCallback<GeolocationPositionError> error) => JSRef!.CallVoid("getCurrentPosition", success, error);
        /// <summary>
        /// Determines the device's current location and gives back a GeolocationPosition object with the data.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="error"></param>
        /// <param name="options"></param>
        public void GetCurrentPosition(ActionCallback<GeolocationPosition> success, ActionCallback<GeolocationPositionError> error, GeolocationOptions options) => JSRef!.CallVoid("getCurrentPosition", success, error, options);
        /// <summary>
        /// Determines the device's current location and gives back a GeolocationPosition object with the data.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="error"></param>
        /// <param name="options"></param>
        public void GetCurrentPosition(Action<GeolocationPosition> success, Action<GeolocationPositionError>? error = null, GeolocationOptions? options = null)
        {
            ActionCallback<GeolocationPositionError>? onError = null;
            ActionCallback<GeolocationPosition>? onSuccess = null;
            onError = new ActionCallback<GeolocationPositionError>((err) =>
            {
                if (onSuccess != null && onError != null)
                {
                    onSuccess.Dispose();
                    onError.Dispose();
                    onSuccess = null;
                    onError = null;
                    error?.Invoke(err);
                }
            });
            onSuccess = new ActionCallback<GeolocationPosition>((pos) =>
            {
                if (onSuccess != null && onError != null)
                {
                    onSuccess.Dispose();
                    onError.Dispose();
                    onSuccess = null;
                    onError = null;
                    success?.Invoke(pos);
                }
            });
            if (options == null)
                GetCurrentPosition(onSuccess, onError);
            else
                GetCurrentPosition(onSuccess, onError, options);
        }
        /// <summary>
        /// Determines the device's current location and gives back a GeolocationPosition object with the data.<br/>
        /// Throws an exception if the request fails.<br/>
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<GeolocationPosition> GetCurrentPositionAsync(GeolocationOptions? options = null)
        {
            var tcs = new TaskCompletionSource<GeolocationPosition>();
            ActionCallback<GeolocationPositionError>? onError = null;
            ActionCallback<GeolocationPosition>? onSuccess = null;
            onError = new ActionCallback<GeolocationPositionError>((err) =>
            {
                if (onSuccess != null && onError != null)
                {
                    onSuccess.Dispose();
                    onError.Dispose();
                    onSuccess = null;
                    onError = null;
                    tcs.TrySetException(new Exception($"{err.Code} {err.Message}"));
                }
            });
            onSuccess = new ActionCallback<GeolocationPosition>((pos) =>
            {
                if (onSuccess != null && onError != null)
                {
                    onSuccess.Dispose();
                    onError.Dispose();
                    onSuccess = null;
                    onError = null;
                    tcs.TrySetResult(pos);
                }
            });
            if (options == null)
                GetCurrentPosition(onSuccess, onError);
            else
                GetCurrentPosition(onSuccess, onError, options);
            return await tcs.Task;
        }
        /// <summary>
        /// The Geolocation method watchPosition() method is used to register a handler function that will be called automatically each time the position of the device changes. You can also, optionally, specify an error handling callback function.
        /// </summary>
        /// <param name="success"></param>
        /// <returns></returns>
        public int WatchPosition(ActionCallback<GeolocationPosition> success) => JSRef!.Call<int>("watchPosition", success);
        /// <summary>
        /// The Geolocation method watchPosition() method is used to register a handler function that will be called automatically each time the position of the device changes. You can also, optionally, specify an error handling callback function.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public int WatchPosition(ActionCallback<GeolocationPosition> success, ActionCallback<GeolocationPositionError> error) => JSRef!.Call<int>("watchPosition", success, error);
        /// <summary>
        /// The Geolocation method watchPosition() method is used to register a handler function that will be called automatically each time the position of the device changes. You can also, optionally, specify an error handling callback function.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="error"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public int WatchPosition(ActionCallback<GeolocationPosition> success, ActionCallback<GeolocationPositionError> error, GeolocationOptions options) => JSRef!.Call<int>("watchPosition", success, error, options);
        /// <summary>
        /// Start watching the device position
        /// </summary>
        /// <param name="success"></param>
        /// <param name="error"></param>
        /// <param name="options"></param>
        /// <returns>A GeolocationWatchHandle that can be used to start and stop the watch.</returns>
        public GeolocationWatchHandle WatchPosition(Action<GeolocationPosition> success, Action<GeolocationPositionError>? error = null, GeolocationOptions? options = null)
        {
            var ret = new GeolocationWatchHandle(this.JSRefAs<Geolocation>(), success, error, options);
            try
            {
                ret.Start();
            }
            catch
            {
                ret.Dispose();
                throw;
            }
            return ret;
        }
        #endregion
    }
}
