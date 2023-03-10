using System.Reflection;

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

        //public int WorkersIdle => _workers.Sum(o => !o.WaitingForResponse ? 1 : 0);




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

        Queue<WebWorker> IdleWebWorkers { get; set; } = new Queue<WebWorker>();
        public int WorkersIdle => IdleWebWorkers.Count;

        public bool TryGetIdleWorker(out WebWorker? worker) {
            return IdleWebWorkers.TryDequeue(out worker);
        }

        public void ReleaseIdleWorker(WebWorker? worker) {
            if (worker != null && !IdleWebWorkers.Contains(worker)) IdleWebWorkers.Enqueue(worker);
        }

        async Task<bool> TryStartWorker()
        {
            var webWorker = await _webWorkerService.GetWebWorker();
            if (webWorker == null) return false;
            lock (_workers)
            {
                webWorker.OnBusyStateChanged += WebWorker_OnBusyStateChanged;
                _workers.Add(webWorker);
                if (!IdleWebWorkers.Contains(webWorker)) IdleWebWorkers.Enqueue(webWorker);
                WorkersRunning++;
            }
            return true;
        }

        public delegate void BusyStateChangedDelegate(WebWorker sender, bool busy);
        public event BusyStateChangedDelegate OnBusyStateChanged;

        private void WebWorker_OnBusyStateChanged(ServiceCallDispatcher sender, bool busy) {
            var webWorker = sender as WebWorker;    
            if (!busy & !IdleWebWorkers.Contains(webWorker)) {
                IdleWebWorkers.Enqueue(sender as WebWorker);
            } else if (busy && !IdleWebWorkers.Contains(webWorker)) {
                var checkThis = true;   
            }
            OnBusyStateChanged?.Invoke(webWorker, busy);
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
                var countToAdd = count - _workers.Count;
                if (countToAdd > 0)
                {
                    var tasks = new List<Task<bool>>();
                    for (var i = 0; i < countToAdd; i++)
                    {
                        var task = TryStartWorker();
                        tasks.Add(task);
                    }
                    await Task.WhenAll(tasks);
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
        //public async Task<bool> SetWorkerCount(int count)
        //{
        //    _WorkerCountRequest = count;
        //    if (!WebWorker.Supported) return false;
        //    if (_webWorkerService == null) return false;
        //    try
        //    {
        //        await _SetWorkerCountLock.WaitAsync();
        //        while (_workers.Count < count)
        //        {
        //            var webWorker = await _webWorkerService.GetWebWorker();
        //            if (webWorker == null) return false;
        //            if (webWorker != null)
        //            {
        //                _workers.Add(webWorker);
        //                WorkersRunning++;
        //            }
        //        }
        //        WorkersRunning = count;
        //        while (_workers.Count > WorkersRunning)
        //        {
        //            var w = await GetFreeWorkerAsync();
        //            if (w != null)
        //            {
        //                _workers.Remove(w);
        //                w.Dispose();
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        _SetWorkerCountLock.Release();
        //    }
        //    return true;
        //}

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
