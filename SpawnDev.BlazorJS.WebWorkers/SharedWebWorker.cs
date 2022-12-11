using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.WebWorkers
{
    public class SharedWebWorker : ServiceCallDispatcher, IDisposable
    {
        SharedWorker _shareWorker;
        public SharedWebWorker(string name, SharedWorker sharedWorker, IServiceProvider serviceProvider) : base(serviceProvider, sharedWorker.Port)
        {
            _shareWorker = sharedWorker;
            _port.Start();
        }

        public override void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            _shareWorker?.Dispose();
            _port?.Dispose();
            base.Dispose(disposing);
        }
    }
}
