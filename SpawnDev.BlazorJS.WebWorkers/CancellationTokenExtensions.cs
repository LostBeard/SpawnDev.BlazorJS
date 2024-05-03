using System.Diagnostics;

namespace SpawnDev.BlazorJS.WebWorkers
{
    public static class CancellationTokenExtensions
    {
        static Stopwatch? TokenTaskDelayStopSwatch { get; set; }
        /// <summary>
        /// Releases the thread to other async Tasks via a Task.Delay() call and then returns CancellationToken.IsCancellationRequested<br/>
        /// This can allow event handlers time to process events that may cancel the token
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="millisecondsDelay"></param>
        /// <returns></returns>
        public static async Task<bool> IsCancellationRequestedAsync(this CancellationToken _this, int millisecondsDelay = 1)
        {
            await Task.Delay(millisecondsDelay);
            return _this.IsCancellationRequested;
        }
        /// <summary>
        /// Releases the thread to other async Tasks via a Task.Delay() call and then calls CancellationToken.ThrowIfCancellationRequested()<br/>
        /// This can allow event handlers time to process events that may cancel the token
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="millisecondsDelay"></param>
        /// <returns></returns>
        public static async Task ThrowIfCancellationRequestedAsync(this CancellationToken _this, int millisecondsDelay = 1)
        {
            await Task.Delay(millisecondsDelay);
            _this.ThrowIfCancellationRequested();
        }
        /// <summary>
        /// Releases the thread to other async Tasks via a Task.Delay() call and then returns CancellationToken.IsCancellationRequested<br/>
        /// This can allow event handlers time to process events that may cancel the token
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="minIntervalMilliseconds">Minimum time that needs to have passed before calling Task.Delay again</param>
        /// <param name="millisecondsDelay">
        /// Value passed to Task.Delay(), which allows other async Tasks time to run.<br/>
        /// Too small a value will not allow time for waiting Tasks and events a chance to start. ~1 millisecond is recommended.<br/>
        /// </param>
        /// <returns></returns>
        public static async Task<bool> IsCancellationRequestedAsync(this CancellationToken _this, double minIntervalMilliseconds, int millisecondsDelay = 1)
        {
            if (TokenTaskDelayStopSwatch == null)
            {
                TokenTaskDelayStopSwatch = Stopwatch.StartNew();
                await Task.Delay(millisecondsDelay);
            }
            else if (TokenTaskDelayStopSwatch.Elapsed.TotalMilliseconds > minIntervalMilliseconds)
            {
                TokenTaskDelayStopSwatch.Restart();
                await Task.Delay(millisecondsDelay);
            }
            return _this.IsCancellationRequested;
        }
        /// <summary>
        /// Releases the thread to other async Tasks via a Task.Delay() call and then calls CancellationToken.ThrowIfCancellationRequested()<br/>
        /// This can allow event handlers time to process events that may cancel the token
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="minIntervalMilliseconds">Minimum time that needs to have passed before calling Task.Delay again</param>
        /// <param name="millisecondsDelay">
        /// Value passed to Task.Delay(), which allows other async Tasks time to run.<br/>
        /// Too small a value will not allow time for waiting Tasks and events a chance to start. ~1 millisecond is recommended.<br/>
        /// </param>
        /// <returns></returns>
        public static async Task ThrowIfCancellationRequestedAsync(this CancellationToken _this, double minIntervalMilliseconds, int millisecondsDelay = 1)
        {
            if (TokenTaskDelayStopSwatch == null)
            {
                TokenTaskDelayStopSwatch = Stopwatch.StartNew();
                await Task.Delay(millisecondsDelay);
            }
            else if (TokenTaskDelayStopSwatch.Elapsed.TotalMilliseconds > minIntervalMilliseconds)
            {
                TokenTaskDelayStopSwatch.Restart();
                await Task.Delay(millisecondsDelay);
            }
            _this.ThrowIfCancellationRequested();
        }
    }
}
