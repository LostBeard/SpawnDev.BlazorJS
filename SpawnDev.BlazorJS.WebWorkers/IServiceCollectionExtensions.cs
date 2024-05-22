﻿using Microsoft.Extensions.DependencyInjection;

namespace SpawnDev.BlazorJS.WebWorkers
{
    /// <summary>
    /// Adds SpawnDev.BlazorJS.WebWorkers specific methods to IServiceCollection
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        static internal Type? ServiceWorkerEventHandlerTService { get; set; } = null;
        static internal Type? ServiceWorkerEventHandlerTImplementation { get; set; } = null;
        static internal ServiceWorkerConfig? ServiceWorkerConfig { get; set; } = null;
        /// <summary>
        /// Adds WebWorkerService as a singleton service
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="configureCallback"></param>
        /// <returns></returns>
        public static IServiceCollection AddWebWorkerService(this IServiceCollection _this, Action<WebWorkerService>? configureCallback = null)
        {
            return _this.AddSingleton(sp =>
            {
                // create the service and pass it to the configureCallback to allow configuration at startup
                var webWorkerService = ActivatorUtilities.CreateInstance<WebWorkerService>(sp);
                configureCallback?.Invoke(webWorkerService);
                return webWorkerService;
            });
        }

        /// <summary>
        /// RegisterServiceWorker a class that implements ServiceWorkerEventHandler to handle ServiceWorker events
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="_this"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterServiceWorker<TService>(this IServiceCollection _this, ServiceWorkerConfig? config = null) where TService : ServiceWorkerEventHandler
        {
            ServiceWorkerConfig = config ?? new ServiceWorkerConfig { Register = ServiceWorkerStartupRegistration.Register };
            var typeTService = typeof(TService);
            ServiceWorkerEventHandlerTService = typeTService;
            ServiceWorkerEventHandlerTImplementation = typeTService;
            _this.AddSingleton<TService>(GlobalScope.ServiceWorker);
            _this.AddSingleton<ServiceWorkerEventHandler>(sp => sp.GetRequiredService<TService>(), GlobalScope.ServiceWorker);
            return _this;
        }
        /// <summary>
        /// RegisterServiceWorker a class that implements ServiceWorkerEventHandler to handle ServiceWorker events
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="_this"></param>
        /// <param name="startScope"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterServiceWorker<TService>(this IServiceCollection _this, GlobalScope startScope, ServiceWorkerConfig? config = null) where TService : ServiceWorkerEventHandler
        {
            ServiceWorkerConfig = config ?? new ServiceWorkerConfig { Register = ServiceWorkerStartupRegistration.Register };
            var typeTService = typeof(TService);
            ServiceWorkerEventHandlerTService = typeTService;
            ServiceWorkerEventHandlerTImplementation = typeTService;
            _this.AddSingleton<TService>(GlobalScope.ServiceWorker | startScope);
            _this.AddSingleton<ServiceWorkerEventHandler>(sp => sp.GetRequiredService<TService>(), GlobalScope.ServiceWorker);
            return _this;
        }
        /// <summary>
        /// If a ServiceWorker is no longer desired, it can be set to unregister.
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static IServiceCollection UnregisterServiceWorker(this IServiceCollection _this)
        {
            ServiceWorkerConfig = new ServiceWorkerConfig { Register = ServiceWorkerStartupRegistration.Unregister };
            return _this;
        }
    }
}
