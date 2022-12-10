using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.WebWorkers
{
    public class WebWorker : ServiceCallDispatcher, IDisposable
    {
        Worker _worker;
        public WebWorker(Worker worker, IServiceProvider serviceProvider) : base(serviceProvider, worker)
        {
            _worker = worker;
        }
        public bool IsDisposed { get; private set; } = false;
        public void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            IsDisposed = true;
            if (disposing)
            {

            }
            _worker.Terminate();
            _worker.Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        ~WebWorker()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }
    }
}
