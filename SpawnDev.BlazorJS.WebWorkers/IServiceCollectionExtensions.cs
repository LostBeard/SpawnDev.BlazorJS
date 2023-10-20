using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.WebWorkers
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds WebWorkerService as a singleton service
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static IServiceCollection AddWebWorkerService(this IServiceCollection _this)
        {
            return _this.AddSingleton<WebWorkerService>();
        }
        /// <summary>
        /// Register a class that implements ServiceWorkerEventHandler to handle ServiceWorker events
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterServiceWorker<TService>(this IServiceCollection _this, ServiceWorkerConfig? config = null) where TService : ServiceWorkerEventHandler
        {
            config = config ?? new ServiceWorkerConfig();
            _this.AddSingleton<ServiceWorkerConfig>(config);
            _this.AddSingleton(typeof(TService));
            _this.AddSingleton<ServiceWorkerEventHandler>(sp => sp.GetRequiredService<TService>());
            return _this;
        }
        /// <summary>
        /// If a ServiceWorker is no longer desired, it can be set unregister.
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static IServiceCollection UnregisterServiceWorker(this IServiceCollection _this)
        {
            var config = new ServiceWorkerConfig();
            config.Register = ServiceWorkerStartupRegistration.Unregister;
            _this.AddSingleton<ServiceWorkerConfig>(config);
            _this.AddSingleton<ServiceWorkerEventHandler>();
            return _this;
        }
    }
}
