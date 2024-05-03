using SpawnDev.BlazorJS.JSObjects;
using System.Diagnostics.CodeAnalysis;

namespace SpawnDev.BlazorJS.WebWorkers
{
    internal abstract class WorkerCancellationTokenSource : IDisposable
    {
        private bool _cancelled = false;
        Lazy<WorkerCancellationToken> _token;
        public WorkerCancellationToken Token => OnTokenGet();
        internal WorkerCancellationTokenSource()
        {
            _token = new Lazy<WorkerCancellationToken>(OnTokenGet);
        }

        protected abstract void OnCancel();

        protected abstract bool OnCancelCheck();

        protected abstract WorkerCancellationToken OnTokenGet();

        protected abstract void OnRelease();
        /// <summary>
        /// Sets the cancelled flag to true
        /// </summary>
        public void Cancel()
        {
            ThrowIfDisposed();
            if (IsCancellationRequested) return;
            OnCancel();
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
                if (IsCancellationRequested) return;
                OnCancel();
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
                _cancelled = OnCancelCheck();
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
            OnRelease();
        }
    }
}
