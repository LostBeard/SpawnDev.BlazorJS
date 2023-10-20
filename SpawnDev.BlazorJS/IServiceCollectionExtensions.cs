using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JsonConverters;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using static SpawnDev.BlazorJS.IServiceCollectionExtensions;

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
        internal static List<AutoStartedService> AutoStartedServices { get; private set; } = new List<AutoStartedService>();

        internal class AutoStartedService
        {
            public object? Service { get; set; }
            public ServiceDescriptor ServiceDescriptor { get; set; }
            public GlobalScope GlobalScope { get; set; }
            public bool GlobalScopeDefault { get; set; }
            public bool ImplementsIBackgroundService { get; set; }
            public bool ImplementsIAsyncBackgroundService { get; set; }
        }

        /// <summary>
        /// AutoStartedServices implementing IBackgroundService or IAsyncBackgroundService will be started
        /// AutoStartedServices implementing IAsyncBackgroundService will have their InitAsync methods called in the order the were registered
        /// Background services must be careful to not take too long in their InitAsync methods as other services are waiting to init and the app is waiting to start
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        static bool StartBackgroundServicesRan = false;
        public static async Task<WebAssemblyHost> StartBackgroundServices(this WebAssemblyHost _this)
        {
            if (StartBackgroundServicesRan) return _this;
            StartBackgroundServicesRan = true;
            //
            var JS = BlazorJSRuntime.JS;
            // let all the constructors fire first
            serviceCollection!.ToList().ForEach(o =>
            {
                var isIBackgroundService = typeof(IBackgroundService).IsAssignableFrom(o.ServiceType) || typeof(IBackgroundService).IsAssignableFrom(o.ImplementationType);
                var isIAsyncBackgroundService = typeof(IAsyncBackgroundService).IsAssignableFrom(o.ServiceType) || typeof(IAsyncBackgroundService).IsAssignableFrom(o.ImplementationType);
                var serviceAutoStartScopeSet = GetAutoStartMode(o.ServiceType);
                var serviceAutoStartScope = GlobalScope.None;
                if (serviceAutoStartScopeSet != null)
                {
                    serviceAutoStartScope = serviceAutoStartScopeSet.Value;
                }
                else
                {
                    serviceAutoStartScope = isIBackgroundService ? GlobalScope.All : GlobalScope.None;
                }
                if (JS.IsScope(serviceAutoStartScope))
                {
#if DEBUG && false
                    Console.WriteLine($"Starting service: {o.ServiceType.Name} GlobalScope: {JS.GlobalScope} StartScope: {serviceAutoStartScope}");
#endif
                    var service = _this.Services.GetRequiredService(o.ServiceType);
                    var autoStartedService = new AutoStartedService
                    {
                        ServiceDescriptor = o,
                        Service = service,
                        GlobalScope = serviceAutoStartScope,
                        ImplementsIAsyncBackgroundService = isIAsyncBackgroundService,
                        ImplementsIBackgroundService = isIBackgroundService,
                        GlobalScopeDefault = serviceAutoStartScopeSet == null,
                    };
                    AutoStartedServices.Add(autoStartedService);
                }
                else
                {
#if DEBUG && false
                    Console.WriteLine($"Skipping service: {o.ServiceType.Name} GlobalScope: {JS.GlobalScope} StartScope: {serviceAutoStartScope}");
#endif
                }
            });
            // call InitAsync on each IAsyncBackgroundService
            foreach (var autoStartedService in AutoStartedServices)
            {
                if (autoStartedService.Service != null && autoStartedService.Service is IAsyncBackgroundService asyncBG)
                {
#if DEBUG && false
                    Console.WriteLine($"InitAsync background service: {autoStartedService.ServiceDescriptor.ServiceType.Name}");
#endif
                    await asyncBG.InitAsync();
                }
            }
            return _this;
        }

        /// <summary>
        /// BlazorJSRunAsync() is a scope aware replacement for RunAsync<br />
        /// RunAsync() will be called internally but only when running in a Window global scope to prevent components from loading in Worker scopes.<br />
        /// BlazorJSRunAsync() automatically starts IBackgroundService services, IAsyncBackgroundService services<br />
        /// and singletons services registered with a GlobalScope value that matches the current GlobalScope<br />
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task BlazorJSRunAsync(this WebAssemblyHost _this)
        {
            await _this.StartBackgroundServices();
            if (BlazorJSRuntime.JS.IsWindow)
            {
#if DEBUG && false
                Console.WriteLine($"BlazorJSRunAsync mode: Default");
#endif
                // run as normal where Blazor has the window global context it expects
                await _this.RunAsync();
            }
            else
            {
#if DEBUG && false
                Console.WriteLine($"BlazorJSRunAsync mode: Worker");
#endif
                // This is a worker so we are going to use this to allow services in workers without the html renderer trying to load pages
                var tcs = new TaskCompletionSource<object>();
                await tcs.Task;
            }
        }

        static GlobalScope? GetAutoStartMode(Type type)
        {
            return AutoStartModes.TryGetValue(type, out var mode) ? mode : null;
        }


        // AddSingleton overloads that also take GlobalScope
        static Dictionary<Type, GlobalScope> AutoStartModes = new Dictionary<Type, GlobalScope>();

        /// <summary>
        /// Adds a singleton service of the type specified in <typeparamref name="TService"/> with an
        /// implementation type specified in <typeparamref name="TImplementation"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services, GlobalScope autoStartMode)
            where TService : class
            where TImplementation : class, TService
        {
            ThrowIfNull(services);
            AutoStartModes.Add(typeof(TService), autoStartMode);

            return services.AddSingleton(typeof(TService), typeof(TImplementation));
        }

        /// <summary>
        /// Adds a singleton service of the type specified in <paramref name="serviceType"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="serviceType">The type of the service to register and the implementation to use.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton(
            this IServiceCollection services,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, GlobalScope autoStartMode)
        {
            ThrowIfNull(services);
            ThrowIfNull(serviceType);
            AutoStartModes.Add(serviceType, autoStartMode);

            return services.AddSingleton(serviceType, serviceType);
        }

        /// <summary>
        /// Adds a singleton service of the type specified in <typeparamref name="TService"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IServiceCollection services, GlobalScope autoStartMode)
            where TService : class
        {
            ThrowIfNull(services);
            AutoStartModes.Add(typeof(TService), autoStartMode);

            return services.AddSingleton(typeof(TService));
        }

        /// <summary>
        /// Adds a singleton service of the type specified in <typeparamref name="TService"/> with a
        /// factory specified in <paramref name="implementationFactory"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton<TService>(
            this IServiceCollection services,
            Func<IServiceProvider, TService> implementationFactory, GlobalScope autoStartMode)
            where TService : class
        {
            ThrowIfNull(services);
            ThrowIfNull(implementationFactory);
            AutoStartModes.Add(typeof(TService), autoStartMode);
            return services.AddSingleton(typeof(TService), implementationFactory);
        }

        /// <summary>
        /// Adds a singleton service of the type specified in <typeparamref name="TService"/> with an
        /// implementation type specified in <typeparamref name="TImplementation" /> using the
        /// factory specified in <paramref name="implementationFactory"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton<TService, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory, GlobalScope autoStartMode)
            where TService : class
            where TImplementation : class, TService
        {
            ThrowIfNull(services);
            ThrowIfNull(implementationFactory);
            AutoStartModes.Add(typeof(TService), autoStartMode);

            return services.AddSingleton(typeof(TService), implementationFactory);
        }

        /// <summary>
        /// Adds a singleton service of the type specified in <paramref name="serviceType"/> with an
        /// instance specified in <paramref name="implementationInstance"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="serviceType">The type of the service to register.</param>
        /// <param name="implementationInstance">The instance of the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton(
            this IServiceCollection services,
            Type serviceType,
            object implementationInstance, GlobalScope autoStartMode)
        {
            ThrowIfNull(services);
            ThrowIfNull(serviceType);
            ThrowIfNull(implementationInstance);
            AutoStartModes.Add(serviceType, autoStartMode);
            var serviceDescriptor = new ServiceDescriptor(serviceType, implementationInstance);
            services.Add(serviceDescriptor);
            return services;
        }

        /// <summary>
        /// Adds a singleton service of the type specified in <typeparamref name="TService" /> with an
        /// instance specified in <paramref name="implementationInstance"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="implementationInstance">The instance of the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton<TService>(
            this IServiceCollection services,
            TService implementationInstance, GlobalScope autoStartMode)
            where TService : class
        {
            ThrowIfNull(services);
            ThrowIfNull(implementationInstance);
            AutoStartModes.Add(typeof(TService), autoStartMode);
            return services.AddSingleton(typeof(TService), implementationInstance);
        }

        static void ThrowIfNull<T>(T? value)
        {
            if (value == null) throw new ArgumentNullException($"{typeof(T).Name} cannot be null");
        }
    }
}
