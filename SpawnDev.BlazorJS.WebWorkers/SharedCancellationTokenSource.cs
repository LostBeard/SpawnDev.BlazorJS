using SpawnDev.BlazorJS.JSObjects;
using System.Diagnostics.CodeAnalysis;

namespace SpawnDev.BlazorJS.WebWorkers
{
    /// <summary>
    /// 
    /// </summary>
    public class SharedCancellationTokenSource : IDisposable
    {
        private bool _cancelled = false;
        internal Uint8Array? SharedArrayBufferView { get; private set; }
        internal SharedArrayBuffer? SharedArrayBuffer { get; private set; }
        private Lazy<SharedCancellationToken> _token;
        public SharedCancellationToken Token => _token.Value;
        internal SharedCancellationTokenSource(SharedArrayBuffer sharedArrayBuffer)
        {
            SharedArrayBuffer = sharedArrayBuffer;
            SharedArrayBufferView = new Uint8Array(sharedArrayBuffer);
            _token = new Lazy<SharedCancellationToken>(() => new SharedCancellationToken(new SharedCancellationTokenSource(SharedArrayBuffer.JSRefCopy<SharedArrayBuffer>())));
        }
        public SharedCancellationTokenSource(bool cancelled = false) : this(new SharedArrayBuffer(1))
        {
            if (cancelled) Cancel();
        }
        public SharedCancellationTokenSource(int cancelAfterMillisecondDelay) : this(new SharedArrayBuffer(1))
        {
            CancelAfter(cancelAfterMillisecondDelay);
        }
        /// <summary>
        /// Sets the cancelled flag to true
        /// </summary>
        public void Cancel()
        {
            ThrowIfDisposed();
            if (IsCancellationRequested) return;
            if (SharedArrayBufferView == null) return;
            SharedArrayBufferView[0] = 1;
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
                if (IsCancellationRequested) return;
                if (SharedArrayBufferView == null) return;
                SharedArrayBufferView[0] = 1;
                cts.Dispose();
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
                    // reads the cancelled flag byte from the shared array buffer
                    _cancelled = SharedArrayBufferView[0] == 1;
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
                //SharedArrayBufferView = null;
            }
            if (SharedArrayBuffer != null)
            {
                SharedArrayBuffer.Dispose();
                //SharedArrayBuffer = null;
            }
        }
    }
}
