using System.Diagnostics.CodeAnalysis;

namespace SpawnDev.BlazorJS.WebWorkers
{
    /// <summary>
    /// SharedCancellationToken is a class that uses a SharedArrayBuffer to allow checking if a task has been cancelled by another browser thread<br/>
    /// synchronously and without relying on message event handling.<br/>
    /// </summary>
    public class SharedCancellationToken : IDisposable
    {
        private bool _cancelled = false;
        internal SharedCancellationTokenSource? _source = null;
        internal SharedCancellationToken(SharedCancellationTokenSource source)
        {
            _source = source;
        }
        /// <summary>
        /// Creates an instance of SharedCancellationToken and setting the cancelled state that cannot be cancelled in the future
        /// </summary>
        public SharedCancellationToken(bool cancelled = false)
        {
            _cancelled = cancelled;
        }
        /// <summary>
        /// Returns an instance of SharedCancellationToken that is not cancelled and will never be in the cancelled state
        /// </summary>
        public static SharedCancellationToken None => new SharedCancellationToken(false);
        /// <summary>
        /// Returns an instance of SharedCancellationToken that is cancelled.
        /// </summary>
        public static SharedCancellationToken Cancelled => new SharedCancellationToken(true);
        /// <summary>
        /// Throws an OperationCanceledException if the cancelled flag is set to true
        /// </summary>
        /// <exception cref="OperationCanceledException"></exception>
        public void ThrowIfCancellationRequested()
        {
            if (IsCancellationRequested) ThrowOperationCanceledException();
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
                if (_source != null)
                {
                    // update local _cancelled flag from _source
                    _cancelled = _source.IsCancellationRequested;
                }
                return _cancelled;
            }
        }
        /// <summary>
        /// Returns true of this SharedCancellationToken can be cancelled
        /// </summary>
        public bool CanBeCanceled => _source != null;
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
            if (_source != null)
            {
                _source.Dispose();
                _source = null;
            }
        }
    }
}
