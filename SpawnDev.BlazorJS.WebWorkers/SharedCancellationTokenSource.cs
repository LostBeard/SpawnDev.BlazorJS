using SpawnDev.BlazorJS.JSObjects;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.WebWorkers
{
    /// <summary>
    /// SharedCancellationTokenSource works similarly to CancellationTokenSource allowing the creation and controlling of SharedCancellationTokens<br/>
    /// which can be passed to WekWorkers to allow workers a synchronous method of checking for a cancellation flag set in another thread<br/>
    /// Requires globalThis.crossOriginIsolated == true due to using SharedArrayBuffer for cancellation signaling
    /// </summary>
    public class SharedCancellationTokenSource : IDisposable
    {
        private static BlazorJSRuntime JS => BlazorJSRuntime.JS;
        private static bool CrossOriginIsolated => JS.CrossOriginIsolated;
        /// <summary>
        /// Returns true if the cancelled flag is set to true
        /// </summary>
        [JsonIgnore]
        public bool IsCancellationRequested
        {
            get
            {
                if (_cancelled) return true;
                if (SharedArrayBuffer != null)
                {
                    SharedArrayBufferView ??= new Uint8Array(SharedArrayBuffer);
                    var cancelledFlag = Atomics.Load(SharedArrayBufferView, 0);
                    if (cancelledFlag != 0)
                    {
                        _cancelled = true;
                    }
                }
                return _cancelled;
            }
        }
        const int BUFFER_SIZE = 1;

        private Uint8Array? SharedArrayBufferView = null;

        [JsonInclude]
        [JsonPropertyName("sharedArrayBuffer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        private SharedArrayBuffer? SharedArrayBuffer { get; set; }

        [JsonInclude]
        [JsonPropertyName("cancelled")]
        private bool _cancelled = false;

        private SharedCancellationToken? _token;
        /// <summary>
        /// Returns the cancellation token
        /// </summary>
        [JsonIgnore]
        public SharedCancellationToken Token
        {
            get
            {
                ThrowIfDisposed();
                if (_token == null)
                {
                    if (!_cancelled && SharedArrayBuffer != null)
                    {
                        _token = new SharedCancellationToken(new SharedCancellationTokenSource() { SharedArrayBuffer = SharedArrayBuffer });
                    }
                    else
                    {
                        _token = new SharedCancellationToken(_cancelled);
                    }
                }
                return _token;
            }
        }
        // json constructor
        [JsonConstructor]
        internal SharedCancellationTokenSource() { }
        /// <summary>
        /// Creates a new instance with a pre-set cancelled state
        /// </summary>
        /// <param name="cancelled"></param>
        public SharedCancellationTokenSource(bool cancelled = false)
        {
            if (!cancelled)
            {
                if (!CrossOriginIsolated)
                {
                    throw new NotSupportedException("Failed to create SharedCancellationTokenSource. CrossOriginIsolated is required due to SharedArrayBuffer restrictions");
                }
                SharedArrayBuffer = new SharedArrayBuffer(BUFFER_SIZE);
                SharedArrayBufferView = new Uint8Array(SharedArrayBuffer);
            }
            else
            {
                _cancelled = true;
            }
        }
        /// <summary>
        /// Creates a new instance that cancels after the given number of milliseconds
        /// </summary>
        /// <param name="cancelAfterMillisecondDelay"></param>
        public SharedCancellationTokenSource(int cancelAfterMillisecondDelay)
        {
            if (!CrossOriginIsolated)
            {
                throw new NotSupportedException("Failed to create SharedCancellationTokenSource. CrossOriginIsolated is required due to SharedArrayBuffer restrictions");
            }
            SharedArrayBuffer = new SharedArrayBuffer(BUFFER_SIZE);
            SharedArrayBufferView = new Uint8Array(SharedArrayBuffer);
            CancelAfter(cancelAfterMillisecondDelay);
        }
        /// <summary>
        /// Sets the cancelled flag to true
        /// </summary>
        public void Cancel()
        {
            ThrowIfDisposed();
            SetCancelled();
        }
        private void SetCancelled()
        {
            if (IsDisposed) return;
            if (IsCancellationRequested) return;
            if (SharedArrayBuffer == null) return;
            _cancelled = true;
            SharedArrayBufferView ??= new Uint8Array(SharedArrayBuffer);
            Atomics.Store<byte>(SharedArrayBufferView, 0, 1);
        }
        /// <summary>
        /// Cancels the token after a set amount of time
        /// </summary>
        /// <param name="millisecondDelay"></param>
        public void CancelAfter(int millisecondDelay)
        {
            ThrowIfDisposed();
            if (IsCancellationRequested) return;
            var cts = new CancellationTokenSource(millisecondDelay);
            cts.Token.Register(() =>
            {
                cts.Dispose();
                SetCancelled();
            });
        }
        /// <summary>Throws an exception if the source has been disposed.</summary>
        private void ThrowIfDisposed()
        {
            if (IsDisposed) throw new ObjectDisposedException(nameof(SharedCancellationTokenSource));
        }
        // Throws an OCE; separated out to enable better inlining of ThrowIfCancellationRequested
        [DoesNotReturn]
        private void ThrowOperationCanceledException() => throw new OperationCanceledException();
        /// <summary>
        /// Returns true if this instance has been disposed
        /// </summary>
        public bool IsDisposed { get; private set; } = false;
        /// <summary>
        /// Releases disposable resources
        /// </summary>
        public void Dispose()
        {
            if (IsDisposed) return;
            IsDisposed = true;
            if (SharedArrayBufferView != null)
            {
                SharedArrayBufferView.Dispose();
                SharedArrayBufferView = null;
            }
            if (SharedArrayBuffer != null)
            {
                SharedArrayBuffer.Dispose();
                SharedArrayBuffer = null;
            }
            if (_token != null)
            {
                _token.Dispose();
                _token = null;
            }
        }
    }
}
