using SpawnDev.BlazorJS.Reflection;
using System.Reflection;

namespace SpawnDev.BlazorJS.WebWorkers
{
    /// <summary>
    /// Manages a pool of web workers that can be acquired and released as needed
    /// </summary>
    public partial class WebWorkerPool : AsyncCallDispatcher, IDisposable
    {
        public WebWorkerService WebWorkerService { get; }
        protected List<WebWorker> _workers = new List<WebWorker>();
        private int _MaxPoolSize = 0;
        /// <summary>
        /// Maximum number of workers that can be started
        /// </summary>
        public int MaxPoolSize
        {
            get
            {
                return _MaxPoolSize;
            }
            set
            {
                var tmp = value < 0 ? WebWorkerService.MaxWorkerCount : value;
                _MaxPoolSize = Math.Max(0, Math.Min(WebWorkerService.MaxWorkerCount, tmp));
                if (PoolSize > _MaxPoolSize)
                {
                    PoolSize = _MaxPoolSize;
                }
            }
        }
        /// <summary>
        /// The number of workers that are running
        /// </summary>
        public int WorkersRunning => _workers.Count;
        int _PoolSize;
        /// <summary>
        /// The number of desired Workers in the pool
        /// </summary>
        public int PoolSize
        {
            get => _PoolSize;
            set
            {
                if (MaxPoolSize < value) MaxPoolSize = value;
                var tmp = Math.Max(0, value);
                if (_PoolSize == tmp) return;
                _PoolSize = tmp;
                _ = SetWorkerCount(_PoolSize);
            }
        }
        /// <summary>
        /// True if WebWorkers are supported
        /// </summary>
        public bool Supported { get; } = false;
        protected Queue<WebWorker> IdleWebWorkers { get; } = new Queue<WebWorker>();
        /// <summary>
        /// The number of WebWorkers that are currently idle
        /// </summary>
        public int WorkersIdle => IdleWebWorkers.Count;
        /// <summary>
        /// Fires when a new worker is created and added to the pool
        /// </summary>
        public event Action<WebWorker> OnWorkerCreated;
        /// <summary>
        /// Whether CalDispatcher class methods will fallback to using the local scope when GetWorkerAsync would fail
        /// </summary>
        public bool FallbackToLocalScope { get; set; } = true;
        /// <summary>
        /// Whether the pool will grow when a WenWorker is requested and PoolSize &lt; MaxPoolSize
        /// </summary>
        public bool AutoGrow { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="webWorkerService"></param>
        /// <param name="autoStartCount">-1 - Start all, 0 - Start none</param>
        /// <param name="poolSize">-1 - MaxConcurrency, 0 - Do not allow adding</param>
        /// <param name="autoGrow">Allow the number of running workers to grow automatically as long as belwo the max allowed</param>
        /// <param name="fallbackToLocalScope">If WebWorkers are not supported and fallbackToLocalScope == true, run on the local scope (default)</param>
        public WebWorkerPool(WebWorkerService webWorkerService, int autoStartCount = 0, int poolSize = -1, bool autoGrow = true, bool fallbackToLocalScope = true)
        {
            AutoGrow = autoGrow;
            WebWorkerService = webWorkerService;
            Supported = WebWorkerService.WebWorkerSupported;
            if (!Supported) return;
            MaxPoolSize = poolSize;
            FallbackToLocalScope = fallbackToLocalScope;
            if (autoStartCount < 0) autoStartCount = MaxPoolSize;
            PoolSize = Math.Max(Math.Min(MaxPoolSize, autoStartCount), 0);
        }

        /// <summary>
        /// override to handle CallDispatcher calls
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public override async Task<object?> Call(MethodInfo methodInfo, object?[]? args = null)
        {
            ServiceCallDispatcher? dispatcher = null;
            bool shouldRelease = false;
            try
            {
                if (Supported)
                {
                    dispatcher = await GetWorkerAsync();
                    shouldRelease = true;
                }
                else if (FallbackToLocalScope)
                {
                    // fallback to the local scope
                    dispatcher = WebWorkerService.Local;
                }
                if (dispatcher == null)
                {
                    throw new Exception($"Failed to run task.");
                }
                return await dispatcher.Call(methodInfo, args);
            }
            finally
            {
                if (shouldRelease)
                {
                    dispatcher?.ReleaseLock();
                }
            }
        }

        /// <summary>
        /// Releases a worker back into the pool for reuse
        /// </summary>
        /// <param name="worker"></param>
        public void ReleaseWorker(WebWorker? worker)
        {
            if (!IdleWebWorkers.Contains(worker) && _workers.Contains(worker))
            {
                if (_workers.Count > _PoolSize)
                {
                    _workers.Remove(worker);
                    worker.OnLocked -= Worker_OnLocked;
                    worker.OnUnlocked -= Worker_OnUnlocked;
                    worker.Dispose();
                    return;
                }
                while (JobQueue.TryDequeue(out var job))
                {
                    if (!job.Task.IsCompleted)
                    {
                        worker!.AcquireLock();
                        if (job.TrySetResult(worker)) return;
                        worker.ReleaseLock();
                    }
                }
                // no work to do
                IdleWebWorkers.Enqueue(worker);
                worker!.ReleaseLock();
                FireOnBusyStateChanged();
            }
        }

        /// <summary>
        /// Returns true If a worker is available right now
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public bool TryGetWorker(out WebWorker? worker)
        {
            if (!IdleWebWorkers.TryDequeue(out worker)) return false;
            worker.AcquireLock();
            return true;
        }

        /// <summary>
        /// Returns a WebWorker if one is available
        /// </summary>
        /// <returns></returns>
        public WebWorker? GetWorker() => TryGetWorker(out var worker) ? worker : null;

        /// <summary>
        /// Waits until a WebWorker is available and returns it<br />
        /// If one is not available right now, and the number of WebWorkers running is less than the max, another worker is started<br />
        /// An exception will be thrown if a WebWorker cannot be returned for any reason including:<br />
        /// cancellationToken is triggered<br />
        /// not supported<br />
        /// PoolSize == 0 and AutoGrow == false<br />
        /// </summary>
        /// <param name="msTimeout"></param>
        /// <returns></returns>
        public async Task<WebWorker> GetWorkerAsync(int msTimeout)
        {
            using var s_cts = new CancellationTokenSource(msTimeout);
            return await GetWorkerAsync(s_cts.Token);
        }
        /// <summary>
        /// Waits until a WebWorker is available and returns it<br />
        /// If one is not available right now, and the number of WebWorkers running is less than the max, another worker is started<br />
        /// An exception will be thrown if a WebWorker cannot be returned for any reason including:<br />
        /// cancellationToken is triggered<br />
        /// not supported<br />
        /// PoolSize == 0 and AutoGrow == false<br />
        /// </summary>
        /// <returns></returns>
        public Task<WebWorker> GetWorkerAsync() => GetWorkerAsync(CancellationToken.None);

        Queue<TaskCompletionSource<WebWorker>> JobQueue { get; } = new Queue<TaskCompletionSource<WebWorker>>();
        /// <summary>
        /// Waits until a WebWorker is available and returns it<br />
        /// If one is not available right now, and the number of WebWorkers running is less than the max, another worker is started<br />
        /// An exception will be thrown if a WebWorker cannot be returned for any reason including:<br />
        /// not supported<br />
        /// cancellationToken is triggered<br />
        /// PoolSize == 0 and (AutoGrow == false or MaxPoolSize == 0)<br />
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<WebWorker> GetWorkerAsync(CancellationToken cancellationToken)
        {
            if (!WebWorkerService.WebWorkerSupported) throw new Exception("WebWorkers not supported");
            if (IdleWebWorkers.TryDequeue(out var worker))
            {
                worker!.AcquireLock();
                return worker;
            }
            if ((!AutoGrow && PoolSize == 0) || MaxPoolSize == 0)
            {
                throw new Exception("No workers running and AutoAdd disabled");
            }
            var tcs = new TaskCompletionSource<WebWorker>(cancellationToken);
            JobQueue.Enqueue(tcs);
            if (AutoGrow && PoolSize < MaxPoolSize)
            {
                PoolSize += 1;
            }
            worker = await tcs.Task.WaitAsync(cancellationToken);
            return worker;
        }

        void FireOnBusyStateChanged()
        {
            OnBusyStateChanged?.Invoke();
        }

        public delegate void BusyStateChangedDelegate();
        public event BusyStateChangedDelegate OnBusyStateChanged;

        async Task AddWorker()
        {
            var worker = await WebWorkerService.GetWebWorker();
            if (worker != null)
            {
#if DEBUG
                Console.WriteLine("AddWorker");
#endif
                _workers.Add(worker);
                worker.OnLocked += Worker_OnLocked;
                worker.OnUnlocked += Worker_OnUnlocked;
                OnWorkerCreated?.Invoke(worker);
                ReleaseWorker(worker);
            }
        }

        private void Worker_OnUnlocked(Reflection.AsyncCallDispatcher obj)
        {
            ReleaseWorker((WebWorker)obj);
        }

        private void Worker_OnLocked(Reflection.AsyncCallDispatcher obj)
        {
            //throw new NotImplementedException();
        }

        SemaphoreSlim _SetWorkerCountLock = new SemaphoreSlim(1);
        public async Task<bool> SetWorkerCount(int count)
        {
            if (!WebWorker.Supported) return false;
            if (MaxPoolSize < count) MaxPoolSize = count;
            _PoolSize = Math.Max(0, count);
            try
            {
                if (_PoolSize == _workers.Count) return true;
                await _SetWorkerCountLock.WaitAsync();
                var countToAdd = _PoolSize - _workers.Count;
                if (countToAdd > 0)
                {
                    var tasks = new List<Task>();
                    for (var i = 0; i < countToAdd; i++)
                    {
                        tasks.Add(AddWorker());
                    }
                    await Task.WhenAll(tasks);
                }
                while (_workers.Count > _PoolSize)
                {
                    var w = GetWorker();
                    if (w == null) break;
                    w.OnLocked -= Worker_OnLocked;
                    w.OnUnlocked -= Worker_OnUnlocked;
                    _workers.Remove(w);
                    w.Dispose();
                }
            }
            finally
            {
                _SetWorkerCountLock.Release();
            }
            return true;
        }
        /// <summary>
        /// True if this object has been disposed
        /// </summary>
        public bool IsDisposed { get; private set; }
        /// <summary>
        ///  Disposes this object
        /// </summary>
        public void Dispose()
        {
            if (IsDisposed) return;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            IsDisposed = true;
            if (disposing)
            {
                _SetWorkerCountLock.Dispose();
                foreach (var w in _workers)
                {
                    w.Dispose();
                }
                _workers.Clear();
            }
        }
        ~WebWorkerPool()
        {
            Dispose(false);
        }
    }
}
