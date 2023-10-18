using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace SpawnDev.BlazorJS
{
    public interface IBackgroundService
    {

    }
    public interface IAsyncBackgroundService : IBackgroundService
    {
        Task InitAsync();
    }
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// WARNING: Modifying the JSRuntime.JsonSerializerOptions can have unexpected results.
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static IServiceCollection AddJSRuntimeJsonOptions(this IServiceCollection _this, Action<JsonSerializerOptions> configure)
        {
            if (BlazorJSRuntime.RuntimeJsonSerializerOptions != null) configure(BlazorJSRuntime.RuntimeJsonSerializerOptions);
            return _this;
        }
        static IServiceCollection? serviceCollection = null;
        static bool _AddBlazorJSRuntimeCalled = false;
        /// <summary>
        /// Adds the BlazorJSRuntime singleton service and initializes it.
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static IServiceCollection AddBlazorJSRuntime(this IServiceCollection _this)
        {
            if (_AddBlazorJSRuntimeCalled) return _this;
            _AddBlazorJSRuntimeCalled = true;
            serviceCollection = _this;
            // add IServiceCollection singleton
            _this.AddSingleton<IServiceCollection>(_this);
            // add BlazorJSRuntime and IBlazorJSRuntime singleton
            BlazorJSRuntime.JS = new BlazorJSRuntime();
            return _this.AddSingleton<BlazorJSRuntime>(BlazorJSRuntime.JS).AddSingleton<IBlazorJSRuntime>(BlazorJSRuntime.JS);
        }
        internal static Dictionary<Type, IBackgroundService?> Services { get; private set; } = new Dictionary<Type, IBackgroundService?>();

        /// <summary>
        /// Services implementing IBackgroundService or IAsyncBackgroundService will be started
        /// Services implementing IAsyncBackgroundService will have their InitAsync methods called in the order the were registered
        /// Background services must be careful to not take too long in their InitAsync methods as other services are waiting to init and the app is waiting to start
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        static bool StartBackgroundServicesRan = false;
        public static async Task<WebAssemblyHost> StartBackgroundServices(this WebAssemblyHost _this)
        {
            if (StartBackgroundServicesRan) return _this;
            StartBackgroundServicesRan = true;
            var bgServices = serviceCollection.Where(o => typeof(IBackgroundService).IsAssignableFrom(o.ServiceType) || typeof(IBackgroundService).IsAssignableFrom(o.ImplementationType)).ToList();
            // let all the constructors fire first
            foreach (var kvp in bgServices)
            {
#if DEBUG
                Console.WriteLine($"Getting background service: {kvp.ServiceType.Name}");
#endif
                var service = (IBackgroundService)_this.Services.GetRequiredService(kvp.ServiceType);
                Services[kvp.ServiceType] = service;
            }
            // call InitAsync on each
            foreach (var kvp in Services)
            {
                if (kvp.Value is IAsyncBackgroundService asyncBG)
                {
#if DEBUG
                    Console.WriteLine($"InitAsync background service: {kvp.Key.Name}");
#endif
                    await asyncBG.InitAsync();
                }
            }
            return _this;
        }

        /// <summary>
        /// Calling this method is required for BlazorJS and some dependents, such as BlazorJS.WebWorkers, to function properly.<br />
        /// Using this extension method instead of RunAsync enables support for automatically starting all registered services that implement IBackgroundService or IAsyncBackgroundService 
        /// and to also disable component rendering in WebWorkers. RunAsync will be called internally when running in a Window global scope.<br />
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task BlazorJSRunAsync(this WebAssemblyHost _this, bool workersSkipPageRendering = true)
        {
            await _this.StartBackgroundServices();
            var tcs = new TaskCompletionSource<object>();
            if (BlazorJSRuntime.JS.IsWorker && workersSkipPageRendering)
            {
#if DEBUG
                Console.WriteLine($"BlazorJSRunAsync mode: Worker");
#endif
                // This is a worker so we are going to use this to allow services in workers without the html renderer trying to load pages
                await tcs.Task;
            }
            else
            {
#if DEBUG
                Console.WriteLine($"BlazorJSRunAsync mode: Default");
#endif
                // run as normal
                await _this.RunAsync();
            }
        }
    }
}
