using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JsonConverters;
using System.Diagnostics.CodeAnalysis;
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
        internal static Dictionary<Type, object> Services { get; private set; } = new Dictionary<Type, object>();

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
            //
            var currentContext = AutoStartContext.Default;
            var JS = BlazorJSRuntime.JS;
            switch (JS.GlobalThisTypeName)
            {
                case nameof(DedicatedWorkerGlobalScope):
                    currentContext = AutoStartContext.DedicatedWorker;
                    break;
                case nameof(SharedWorkerGlobalScope):
                    currentContext = AutoStartContext.SharedWorker;
                    break;
                case nameof(ServiceWorkerGlobalScope):
                    currentContext = AutoStartContext.ServiceWorker;
                    break;
                case nameof(Window):
                    currentContext = AutoStartContext.Window;
                    break;
            }
            //
            var bgServices = serviceCollection.Where(o => 
                typeof(IBackgroundService).IsAssignableFrom(o.ServiceType) || 
                typeof(IBackgroundService).IsAssignableFrom(o.ImplementationType) ||
                GetAutoStartMode(o.ServiceType) != AutoStartContext.Default
            ).ToList();
            // let all the constructors fire first
            foreach (var kvp in bgServices)
            {
#if DEBUG
                Console.WriteLine($"Getting background service: {kvp.ServiceType.Name}");
#endif
                var autoStartMode = GetAutoStartMode(kvp.ServiceType);
                if (autoStartMode != AutoStartContext.Default)
                {
                    var autostartThisContext = (currentContext & autoStartMode) != 0;
                    if (!autostartThisContext)
                    {
#if DEBUG
                        Console.WriteLine($"Skipping background service in context: {JS.GlobalThisTypeName} {kvp.ServiceType.Name}");
#endif
                        continue;
                    }
                }
                var service = _this.Services.GetRequiredService(kvp.ServiceType);
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
        public static async Task BlazorJSRunAsync(this WebAssemblyHost _this)
        {
            await _this.StartBackgroundServices();
            if (BlazorJSRuntime.JS.IsWindow)
            {
#if DEBUG
                Console.WriteLine($"BlazorJSRunAsync mode: Default");
#endif
                // run as normal where Blazor has the window global context it expects
                await _this.RunAsync();
            }
            else
            {
#if DEBUG
                Console.WriteLine($"BlazorJSRunAsync mode: Worker");
#endif
                // This is a worker so we are going to use this to allow services in workers without the html renderer trying to load pages
                var tcs = new TaskCompletionSource<object>();
                await tcs.Task;
            }
        }

        static AutoStartContext GetAutoStartMode(Type type)
        {
            return AutoStartModes.TryGetValue(type, out var mode) ? mode : AutoStartContext.Default;
        }


        // AddSingleton overloads that also take AutoStartContext
        static Dictionary<Type, AutoStartContext> AutoStartModes = new Dictionary<Type, AutoStartContext>();

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
        public static IServiceCollection AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services, AutoStartContext autoStartMode)
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
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, AutoStartContext autoStartMode)
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
        public static IServiceCollection AddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IServiceCollection services, AutoStartContext autoStartMode)
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
            Func<IServiceProvider, TService> implementationFactory, AutoStartContext autoStartMode)
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
            Func<IServiceProvider, TImplementation> implementationFactory, AutoStartContext autoStartMode)
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
            object implementationInstance, AutoStartContext autoStartMode)
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
            TService implementationInstance, AutoStartContext autoStartMode)
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
    public enum AutoStartContext
    {
        Default = 0,    // None if not IBackgroundService, All if IBackgroundService
        Window = 1,
        DedicatedWorker = 2,
        SharedWorker = 4,
        ServiceWorker = 8,
        DedicatedAndSharedWorkers = DedicatedWorker | SharedWorker,
        AllWorkers = DedicatedWorker | SharedWorker | ServiceWorker,
        All = Window | DedicatedWorker | SharedWorker | ServiceWorker,
    }

}
