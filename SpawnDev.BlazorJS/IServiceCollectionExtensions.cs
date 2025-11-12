using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// SpawnDev.BlazorJS IServiceCollection extension methods
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// WARNING: Modifying the JSRuntime.JsonSerializerOptions can have unexpected results
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static IServiceCollection AddJSRuntimeJsonOptions(this IServiceCollection _this, Action<JsonSerializerOptions> configure)
        {
            if (BlazorJSRuntime.RuntimeJsonSerializerOptions != null) configure(BlazorJSRuntime.RuntimeJsonSerializerOptions);
            return _this;
        }
        /// <summary>
        /// Allows adding additional Javascript runtime JsonConverterFactory instances
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static IServiceCollection AddJSRuntimeJsonConverterFactories(this IServiceCollection _this, Action<JsonConverterCollection> configure)
        {
            if (BlazorJSRuntime.RuntimeJsonConverters != null) configure(BlazorJSRuntime.RuntimeJsonConverters);
            return _this;
        }
        /// <summary>
        /// Adds the BlazorJSRuntime singleton service and initializes it.
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static IServiceCollection AddBlazorJSRuntime(this IServiceCollection _this)
        {
            _this.GetBlazorJSRuntime();
            return _this;
        }
        /// <summary>
        /// Adds the BlazorJSRuntime singleton service and initializes it.
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="JS">BlazorJSRuntime singleton instance</param>
        /// <returns></returns>
        public static IServiceCollection AddBlazorJSRuntime(this IServiceCollection _this, out BlazorJSRuntime JS)
        {
            JS = _this.GetBlazorJSRuntime();
            return _this;
        }
        /// <summary>
        /// Gets BlazorJSRuntime from the current IServiceCollection, adding it if it is not found.
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static BlazorJSRuntime GetBlazorJSRuntime(this IServiceCollection _this) => _this.GetBlazorJSRuntime(true)!;
        /// <summary>
        /// Gets BlazorJSRuntime from the current IServiceCollection, adding it if it is not found and allowAdd == true.
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="allowAdd"></param>
        /// <returns></returns>
        public static BlazorJSRuntime? GetBlazorJSRuntime(this IServiceCollection _this, bool allowAdd)
        {
            var existing = _this.FirstOrDefault(o => o.ServiceType == typeof(BlazorJSRuntime));
            var JS = existing?.ImplementationInstance as BlazorJSRuntime;
            if (JS == null && allowAdd)
            {
                var bgManager = _this.GetBackgroundServiceManager();
                bgManager.OnStarted += BgManager_OnStarted;
                JS = new BlazorJSRuntime();
                // set global scope for background service manager
                _this.SetGlobalScope(JS.GlobalScope);
                _this.AddSingleton<BlazorJSRuntime>(JS);
            }
            return JS;
        }
        private static Task BgManager_OnStarted(BackgroundServiceManager bgManager, GlobalScope globalScope)
        {
            var JS = bgManager.Descriptors.GetBlazorJSRuntime(false);
            JS?.SetReady();
            return Task.CompletedTask;
        }
        /// <summary>
        /// Services implementing IBackgroundService or IAsyncBackgroundService will be started
        /// Services implementing IAsyncBackgroundService will have their IAsyncBackgroundService.Ready Task property awaited in parallel<br/>
        /// Singletons registered with an auto start GlobalScope that matches the current scope will be started<br/>
        /// Background services must be careful to not take too long in their InitAsync methods as other services are waiting to init and the app is waiting to start
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task<WebAssemblyHost> StartBackgroundServices(this WebAssemblyHost _this)
        {
            var JS = _this.Services.GetRequiredService<BlazorJSRuntime>();
            await _this.Services.StartBackgroundServices();
            return _this;
        }
        /// <summary>
        /// BlazorJSRunAsync() is a scope aware replacement for RunAsync(). BlazorJSRunAsync will:<br />
        /// - Start IBackgroundService services, IAsyncBackgroundService services and services registered with a GlobalScope enum value that is compatible the current GlobalScope.<br />
        /// - Call RunAsync(), but only if running in a Window global scope to prevent components from loading in Worker scopes.<br />
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="serviceOnlyMode">Disable component loading in a Window global scope.</param>
        /// <returns></returns>
        public static async Task BlazorJSRunAsync(this WebAssemblyHost _this, bool serviceOnlyMode = false)
        {
            await _this.StartBackgroundServices();
            var JS = _this.Services.GetRequiredService<BlazorJSRuntime>();
            if (JS.IsWindow && !serviceOnlyMode)
            {
#if DEBUG && true
                Console.WriteLine($"BlazorJSRunAsync mode: Default");
#endif
                // run as normal where Blazor has the window global context it expects
                await _this.RunAsync();
            }
            else
            {
#if DEBUG && true
                Console.WriteLine($"BlazorJSRunAsync mode: ServiceOnlyMode");
#endif
                // This is a worker so we are going to use this to allow services in workers without the html renderer trying to load pages
                var tcs = new TaskCompletionSource<object>();
                await tcs.Task;
            }
        }
    }
}
