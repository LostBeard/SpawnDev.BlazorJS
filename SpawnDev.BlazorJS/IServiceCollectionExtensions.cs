using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace SpawnDev.BlazorJS
{
    public interface IBackgroundService
    {
        Task InitAsync();
    }
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the BlazorJSRuntime singleton service and initializes it.
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static IServiceCollection AddBlazorJSRuntime(this IServiceCollection _this)
        {
            _this.AddSingleton<IBlazorJSRuntime>(BlazorJSRuntime.JS);
            _this.AddSingleton(serviceProvider => (BlazorJSRuntime)serviceProvider.GetRequiredService<IBlazorJSRuntime>());
            return _this;
        }
        internal static List<Type> BackgroundServiceTypes { get; private set; } = new List<Type>();

        /// <summary>
        /// Background services are singletons that will be created immediately after app init
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static IServiceCollection AddBackgroundService<TService>(this IServiceCollection _this) where TService : class, IBackgroundService
        {
            BackgroundServiceTypes.Add(typeof(TService));
            _this.AddSingleton<TService>();
            return _this;
        }

        /// <summary>
        /// Background services are singletons that will be created immediately after app init
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static IServiceCollection AddBackgroundService<TService, TImplementation>(this IServiceCollection _this) where TImplementation : class, TService, IBackgroundService where TService : class
        {
            BackgroundServiceTypes.Add(typeof(TService));
            _this.AddSingleton<TService, TImplementation>();
            return _this;
        }

        /// <summary>
        /// Background services will have their InitAsync methods called in the order the were registered
        /// Background services must be careful to not take too long in their InitAsync methods as other services are waiting to init and the app is waiting to start
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task<WebAssemblyHost> StartBackgroundServices(this WebAssemblyHost _this)
        {
            foreach (var type in BackgroundServiceTypes)
            {
                var service = (IBackgroundService)_this.Services.GetRequiredService(type);
                await service.InitAsync();
            }
            return _this;
        }

        /// <summary>
        /// Use this method instead of RunAsync to enable BlazorJS support for IBackgroundService services registered with the IServiceCollection.AddBackgroundService method.
        /// And to also enable disable app rendering in workers to prevent unexpected behavior
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task BlazorJSRunAsync(this WebAssemblyHost _this)
        {
            await _this.StartBackgroundServices();
            var tcs = new TaskCompletionSource<object>();
            if (BlazorJSRuntime.JS.IsWorker)
            {
                // This is a worker so we are going to use this to allow services in workers without the html renderer trying to load pages
                await tcs.Task;
            }
            else
            {
                // run as normal
                await _this.RunAsync();
            }
        }
    }
}
