namespace SpawnDev.BlazorJS.WebWorkers
{
    public class WebWorkerPool : IDisposable, IBackgroundService
    {
        internal WebWorkerService WebWorkerService { get; }
        protected List<WebWorker> _workers = new List<WebWorker>();
        public int MaxWorkerCount => WebWorkerService.MaxWorkerCount;
        protected Queue<WebWorker> IdleWebWorkers { get; set; } = new Queue<WebWorker>();
        public int WorkersIdle => IdleWebWorkers.Count;
        public bool IsReady => IdleWebWorkers.Count > 0; // GetFreeWorker() != null;

        public WebWorkerPool(WebWorkerService webWorkerService, int autoStartCount = 0)
        {
            WebWorkerService = webWorkerService;
            WorkerCountRequest = autoStartCount;
        }

        public async Task<WebWorker?> GetFreeWorkerAsync() => await GetFreeWorkerAsync(CancellationToken.None);
        
        public async Task<WebWorker?> GetFreeWorkerAsync(CancellationToken cancellationToken)
        {
            if (!WebWorkerService.WebWorkerSupported) return null;
            while (!cancellationToken.IsCancellationRequested)
            {
                if (WorkerCountRequest == 0) return null;
                if (IdleWebWorkers.TryDequeue(out var worker))
                {
                    //FireOnBusyStateChanged();
                    return worker;
                }
                await Task.Delay(5);
            }
            return null;
        }

        public bool AreWorkersRunning => _workers.Any();
        public int WorkersRunning => _workers.Count;
        int _WorkerCountRequest;
        public int WorkerCountRequest
        {
            get => _WorkerCountRequest;
            set
            {
                if (_WorkerCountRequest == value) return;
                _WorkerCountRequest = value;
                _ = SetWorkerCount(_WorkerCountRequest);
            }
        }

        public bool TryGetIdleWorker(out WebWorker? worker) => IdleWebWorkers.TryDequeue(out worker);

        async Task FireOnBusyStateChanged()
        {
            OnBusyStateChanged?.Invoke();
        }

        public void ReleaseIdleWorker(WebWorker? worker)
        {
            if (worker != null && !IdleWebWorkers.Contains(worker) && !worker.IsDisposed)
            {
                IdleWebWorkers.Enqueue(worker);
                _ = FireOnBusyStateChanged();
            }
        }

        public delegate void BusyStateChangedDelegate();
        public event BusyStateChangedDelegate OnBusyStateChanged;

        SemaphoreSlim _SetWorkerCountLock = new SemaphoreSlim(1);
        public async Task<bool> SetWorkerCount(int count)
        {
            if (!WebWorker.Supported) return false;
            count = Math.Max(0, count);
            _WorkerCountRequest = count;
            try
            {
                await _SetWorkerCountLock.WaitAsync();
                var countToAdd = _WorkerCountRequest - _workers.Count;
                if (countToAdd > 0)
                {
                    var tasks = new List<Task<WebWorker>>();
                    for (var i = 0; i < countToAdd; i++)
                    {
                        tasks.Add(WebWorkerService.GetWebWorker()!);
                    }
                    var workers = await Task.WhenAll(tasks);
                    foreach(var webWorker in workers)
                    {
                        _workers.Add(webWorker);
                        IdleWebWorkers.Enqueue(webWorker);
                    }
                    _ = FireOnBusyStateChanged();
                }
                while (_workers.Count > _WorkerCountRequest)
                {
                    var w = await GetFreeWorkerAsync();
                    if (w != null)
                    {
                        _workers.Remove(w);
                        w.Dispose();
                    }
                }
            }
            finally
            {
                _SetWorkerCountLock.Release();
            }
            return true;
        }

        public bool IsDisposed { get; private set; }
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
