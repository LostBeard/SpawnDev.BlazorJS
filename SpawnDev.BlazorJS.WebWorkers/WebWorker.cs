using Microsoft.Extensions.DependencyInjection;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.WebWorkers
{
    public class WebWorker : ServiceCallDispatcher, IDisposable
    {
        public static bool Supported;
        static WebWorker()
        {
            Supported = !JS.IsUndefined("Worker");
        }
        Worker _worker;
        public WebWorker(Worker worker, IServiceProvider serviceProvider, IServiceCollection serviceDescriptors) : base(serviceProvider, serviceDescriptors, worker)
        {
            _worker = worker;
        }
        /// <summary>
        /// Called when being Disposed, before the disposal
        /// </summary>
        public event Action<WebWorker> OnDisposing;
        /// <summary>
        /// Returns true if disposal has started
        /// </summary>
        public bool IsDisposing { get; protected set; } = false;
        protected override void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            if (IsDisposing) return;
            IsDisposing = true;
            OnDisposing?.Invoke(this);
            try
            {
                _worker?.Terminate();
            }
            catch { }
            _worker?.Dispose();
            base.Dispose(disposing);
        }
    }
}
