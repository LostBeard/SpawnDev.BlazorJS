namespace SpawnDev.BlazorJS.WebWorkers
{
    public class WebWorkerPool : IDisposable
    {
        WebWorkerService _webWorkerService = null;
        List<WebWorker> _workers = new List<WebWorker>();
        public int MaxWorkerCount => _webWorkerService.MaxWorkerCount;

        public WebWorkerPool(WebWorkerService webWorkerService)
        {
            _webWorkerService = webWorkerService;
        }

        public WebWorker? GetFreeWorker()
        {
            foreach (var w in _workers)
            {
                if (!w.WaitingForResponse) return w;
            }
            return null;
        }

        public bool IsReady => GetFreeWorker() != null;

        public async Task WhenWorkerReady(CancellationToken cancellationToken) => await GetFreeWorkerAsync(cancellationToken);
        public async Task WhenWorkerReady() => await GetFreeWorkerAsync(CancellationToken.None);

        public async Task<WebWorker?> GetFreeWorkerAsync() => await GetFreeWorkerAsync(CancellationToken.None);
        public async Task<WebWorker?> GetFreeWorkerAsync(CancellationToken cancellationToken)
        {
            WebWorker? ret = null;
            while (ret == null && !cancellationToken.IsCancellationRequested)
            {
                ret = GetFreeWorker();
                if (ret == null) await Task.Delay(5);
            }
            return ret;
        }

        public bool WorkerAvailable()
        {
            foreach (var w in _workers)
            {
                if (!w.WaitingForResponse) return true;
            }
            return false;
        }

        public int WorkersIdle => _workers.Sum(o => !o.WaitingForResponse ? 1 : 0);

        public bool AreWorkersRunning => WorkersRunning > 0;
        public int WorkersRunning { get; private set; }
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

        SemaphoreSlim _SetWorkerCountLock = new SemaphoreSlim(1);
        public async Task<bool> SetWorkerCount(int count)
        {
            _WorkerCountRequest = count;
            if (!WebWorker.Supported) return false;
            if (_webWorkerService == null) return false;
            try
            {
                await _SetWorkerCountLock.WaitAsync();
                while (_workers.Count < count)
                {
                    var webWorker = await _webWorkerService.GetWebWorker();
                    if (webWorker == null) return false;
                    if (webWorker != null)
                    {
                        _workers.Add(webWorker);
                        WorkersRunning++;
                    }
                }
                WorkersRunning = count;
                while (_workers.Count > WorkersRunning)
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
                WorkersRunning = 0;
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
