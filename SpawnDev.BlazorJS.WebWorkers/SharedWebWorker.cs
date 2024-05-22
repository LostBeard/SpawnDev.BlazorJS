using Microsoft.Extensions.DependencyInjection;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.WebWorkers
{
    public class SharedWebWorker : ServiceCallDispatcher, IDisposable
    {
        public static bool Supported;
        static SharedWebWorker()
        {
            Supported = !JS.IsUndefined("SharedWorker");
        }
        SharedWorker _shareWorker { get; set; }
        public string Name { get; }
        public SharedWebWorker(string name, SharedWorker sharedWorker, IWebAssemblyServices webAssemblyServices) : base(webAssemblyServices, sharedWorker.Port)
        {
            Name = name;
            _shareWorker = sharedWorker;
            if (_port is MessagePort port) port.Start();
        }

        protected override void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            _shareWorker?.Dispose();
            _port?.Dispose();
            base.Dispose(disposing);
        }
    }
}
