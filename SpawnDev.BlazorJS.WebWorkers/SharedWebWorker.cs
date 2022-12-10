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
            //_ = Task.Run(async () =>
            //{
            //    _port.PostMessage("___");
            //    await Task.Delay(1000);
            //});
        }
        public bool IsDisposed { get; private set; } = false;
        public void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            IsDisposed = true;
            if (disposing)
            {

            }
            //_shareWorker.Terminate();
            _shareWorker.Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        ~SharedWebWorker()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }
    }
}
