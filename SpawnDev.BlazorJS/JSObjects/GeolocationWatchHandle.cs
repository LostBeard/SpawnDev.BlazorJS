namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Handles callbacks for the Geolocation watchPosition method<br/>
    /// Disposing this object will stop the watch and dispose the callbacks<br/>
    /// </summary>
    public class GeolocationWatchHandle : IDisposable
    {
        ActionCallback<GeolocationPosition> _onSuccess;
        ActionCallback<GeolocationPositionError> _onError;
        Action<GeolocationPosition>? onSuccess;
        Action<GeolocationPositionError>? onError;
        /// <summary>
        /// Geolocation watch id
        /// </summary>
        public int Id { get; private set; }
        Geolocation geolocation;
        GeolocationOptions? options = null;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="geolocation"></param>
        /// <param name="onSuccess"></param>
        /// <param name="onError"></param>
        /// <param name="options"></param>
        internal GeolocationWatchHandle(Geolocation geolocation, Action<GeolocationPosition>? onSuccess, Action<GeolocationPositionError>? onError, GeolocationOptions? options)
        {
            this.geolocation = geolocation;
            this.onSuccess = onSuccess;
            this.onError = onError;
            this.options = options;
            _onSuccess = new ActionCallback<GeolocationPosition>(OnSuccess);
            _onError = new ActionCallback<GeolocationPositionError>(OnError);
        }
        /// <summary>
        /// True if the watch is running
        /// </summary>
        public bool Watching { get; private set; } = false;
        /// <summary>
        /// Start watching the device position
        /// </summary>
        public void Start()
        {
            if (Watching) return;
            Watching = true;
            try
            {
                if (options == null)
                {
                    Id = geolocation.WatchPosition(_onSuccess, _onError);
                }
                else
                {
                    Id = geolocation.WatchPosition(_onSuccess, _onError, options);
                }
            }
            catch
            {
                Watching = false;
                throw;
            }
        }
        /// <summary>
        /// Stop watching the device position
        /// </summary>
        public void Stop()
        {
            if (!Watching) return;
            Watching = false;
            try
            {
                geolocation.ClearWatch(Id);
                Id = 0;
            }
            catch { }
        }
        void OnSuccess(GeolocationPosition pos)
        {
            onSuccess?.Invoke(pos);
        }
        void OnError(GeolocationPositionError err)
        {
            onError?.Invoke(err);
        }
        ///<inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Dispose resources
        /// </summary>
        /// <param name="disposing"></param>
        protected void Dispose(bool disposing)
        {
            if (Watching) Stop();
            onSuccess = null;
            onError = null;
            if (_onSuccess != null)
            {
                _onSuccess.Dispose();
                _onSuccess = null!;
            }
            if (_onError != null)
            {
                _onError.Dispose();
                _onError = null!;
            }
        }
        ///<inheritdoc/>
        ~GeolocationWatchHandle()
        {
            Dispose(false);
        }
    }
}
