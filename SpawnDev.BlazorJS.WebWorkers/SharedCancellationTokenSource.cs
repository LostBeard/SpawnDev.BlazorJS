using SpawnDev.BlazorJS.JSObjects;
using System.Diagnostics.CodeAnalysis;

namespace SpawnDev.BlazorJS.WebWorkers
{
    /// <summary>
    /// SharedCancellationTokenSource works similarly to CancellationTokenSource allowing the creation and controlling of SharedCancellationTokens<br/>
    /// which can be passed to WekWorkers to allow workers a synchronous method of checking for a cancellation flag set in another thread<br/>
    /// Requires globalThis.crossOriginIsolated == true due to using SharedArrayBuffer for cancellation signaling
    /// </summary>
    public class SharedCancellationTokenSource : IDisposable
    {
        const int BUFFER_SIZE = 1;
        private bool _cancelled = false;
        internal Uint8Array? SharedArrayBufferView { get; private set; }
        internal SharedArrayBuffer? SharedArrayBuffer { get; private set; }
        private Lazy<SharedCancellationToken> _token;
        /// <summary>
        /// Returns the cancellation token
        /// </summary>
        public SharedCancellationToken Token => _token.Value;
        internal SharedCancellationTokenSource(SharedArrayBuffer sharedArrayBuffer)
        {
            SharedArrayBuffer = sharedArrayBuffer;
            SharedArrayBufferView = new Uint8Array(sharedArrayBuffer);
            _token = new Lazy<SharedCancellationToken>(() => new SharedCancellationToken(new SharedCancellationTokenSource(SharedArrayBuffer.JSRefCopy<SharedArrayBuffer>())));
        }
        /// <summary>
        /// Creates a new instance with a pre-set cancelled state
        /// </summary>
        /// <param name="cancelled"></param>
        public SharedCancellationTokenSource(bool cancelled = false) : this(new SharedArrayBuffer(BUFFER_SIZE))
        {
            if (cancelled) Cancel();
        }
        /// <summary>
        /// Creates a new instance that cancels after the given number of milliseconds
        /// </summary>
        /// <param name="cancelAfterMillisecondDelay"></param>
        public SharedCancellationTokenSource(int cancelAfterMillisecondDelay) : this(new SharedArrayBuffer(BUFFER_SIZE))
        {
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
            if (SharedArrayBufferView == null) return;
            _cancelled = true;
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
        /// Returns true if the cancelled flag is set to true
        /// </summary>
        public bool IsCancellationRequested
        {
            get
            {
                if (_cancelled) return true;
                if (SharedArrayBufferView != null)
                {
                    var cancelledFlag = Atomics.Load(SharedArrayBufferView, 0);
                    if (cancelledFlag != 0)
                    {
                        _cancelled = true;
                    }
                }
                return _cancelled;
            }
        }
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
        }
    }
}
