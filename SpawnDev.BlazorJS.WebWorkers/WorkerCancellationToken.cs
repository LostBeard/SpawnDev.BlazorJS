using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.WebWorkers
{
    public class WorkerCancellationToken
    {
        [JsonInclude]
        [JsonPropertyName("cancelled")]
        private bool _cancelled = false;
        [JsonInclude]
        [JsonPropertyName("cancellationId")]
        internal int CancellationId { get; private set; }
        internal Func<WorkerCancellationToken, bool>? _cancelledCheck { get; set; }
        internal Action<WorkerCancellationToken>? _releaseCallback { get; set; }
        internal string SourceInstanceId { get; set; }
        internal WorkerCancellationToken(Func<WorkerCancellationToken, bool> cancelledCheck, Action<WorkerCancellationToken> releaseCallback, int cancellationId)
        {
            _cancelledCheck = cancelledCheck;
            _releaseCallback = releaseCallback;
            CancellationId = cancellationId;
        }
        /// <summary>
        /// Creates a new instance and sets the cancelled state
        /// </summary>
        /// <param name="cancelled"></param>
        public WorkerCancellationToken(bool cancelled)
        {
            _cancelled = cancelled;
        }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public WorkerCancellationToken() { }
        /// <summary>
        /// Returns an instance of SharedCancellationToken that is not cancelled and will never be in the cancelled state
        /// </summary>
        public static WorkerCancellationToken None => new WorkerCancellationToken(false);
        /// <summary>
        /// Returns an instance of SharedCancellationToken that is cancelled.
        /// </summary>
        public static WorkerCancellationToken Cancelled => new WorkerCancellationToken(true);
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
        [JsonIgnore]
        public bool IsCancellationRequested
        {
            get
            {
                if (_cancelled) return true;
                if (_cancelledCheck != null)
                {
                    // update local _cancelled flag from _source
                    // the below call may 
                    _cancelled = _cancelledCheck(this);
                }
                return _cancelled;
            }
        }
        /// <summary>
        /// Returns true of this SharedCancellationToken can be cancelled
        /// </summary>
        [JsonIgnore]
        public bool CanBeCanceled => _cancelledCheck != null;
        /// <summary>
        /// Returns true if this instance has been disposed
        /// </summary>
        [JsonIgnore]
        public bool IsDisposed { get; private set; } = false;
        /// <summary>
        /// Releases disposable resources
        /// </summary>
        public void Dispose()
        {
            if (IsDisposed) return;
            IsDisposed = true;
            if (_releaseCallback != null)
            {
                _releaseCallback(this);
            }
        }
    }
}
