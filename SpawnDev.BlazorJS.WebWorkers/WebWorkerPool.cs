using Microsoft.AspNetCore.Components.Web.Virtualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool WorkersRunning => WorkerCount > 0;
        public int WorkerCount { get; private set; }

        SemaphoreSlim _SetWorkerCountLock = new SemaphoreSlim(1);
        public async Task<bool> SetWorkerCount(int count)
        {
            if (!WebWorker.Supported) return false;
            if (_webWorkerService == null) return false;
            var hasLock = await _SetWorkerCountLock.WaitAsync(0);
            if (!hasLock) return false;
            try
            {
                while (_workers.Count < count)
                {
                    var webWorker = await _webWorkerService.GetWebWorker();
                    if (webWorker == null) return false;
                    if (webWorker != null)
                    {
                        _workers.Add(webWorker);
                    }
                }
                WorkerCount = count;
                while (_workers.Count > WorkerCount)
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
                WorkerCount = 0;
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
