using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SpawnDev.BlazorJS.JsonConverters;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using static SpawnDev.BlazorJS.IServiceCollectionExtensions;

namespace SpawnDev.BlazorJS
{
    internal enum StartupState
    {
        None,
        ShouldStart,
        Starting,
        Constructing,
        Started,
    }
    public interface IBackgroundService { }
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
            if (!_this.Any(o => o.ServiceType == typeof(IServiceCollection)))
            {
                _this.AddSingleton<IServiceCollection>(_this);
            }
            if (!_this.Any(o => o.ServiceType == typeof(IWebAssemblyServices)))
            {
                _this.AddSingleton<IWebAssemblyServices>(WebAssmeblyServices.GetExtension(_this, true)!);
            }
            BlazorJSRuntime.JS ??= new BlazorJSRuntime();
            if (!_this.Any(o => o.ServiceType == typeof(BlazorJSRuntime)))
            {
                _this.AddSingleton<BlazorJSRuntime>(BlazorJSRuntime.JS);
            }
            return _this;
        }
        
        /// <summary>
        /// Services implementing IBackgroundService or IAsyncBackgroundService will be started
        /// Services implementing IAsyncBackgroundService will have their InitAsync methods called in the order the were constructed
        /// Singletons registered with an auto start GlobalScope that matches the current scope will be started
        /// Background services must be careful to not take too long in their InitAsync methods as other services are waiting to init and the app is waiting to start
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task<WebAssemblyHost> StartBackgroundServices(this WebAssemblyHost _this)
        {
            var webAssmeblyServices = (WebAssmeblyServices)_this.Services.GetRequiredService<IWebAssemblyServices>();
            if (webAssmeblyServices.Started) return _this;
            webAssmeblyServices.Started = true;
            webAssmeblyServices.Host = _this;
            webAssmeblyServices.Services = _this.Services;
            var JS = _this.Services.GetRequiredService<BlazorJSRuntime>();
            var serviceCollection = _this.Services.GetRequiredService<IServiceCollection>();
            webAssmeblyServices.AutoStartedServices = serviceCollection!.Select(o => new ServiceInfo(o, JS.GlobalScope, serviceCollection!)).ToList();
            foreach (var serviceInfo in webAssmeblyServices.AutoStartedServices)
            {
                await InitServiceAsync(serviceCollection!, _this.Services, serviceInfo, null, false);
            }
            return _this;
        }

        public static async Task<object?> GetServiceAsync(this IServiceProvider _this, Type type)
        {
            var webAssmeblyServices = (WebAssmeblyServices)_this.GetRequiredService<IWebAssemblyServices>();
            var serviceInfo = webAssmeblyServices.GetServiceInfo(type, null);
            if (serviceInfo == null)
            {
                return null;
            }
            var serviceCollection = _this.GetRequiredService<IServiceCollection>();
            await InitServiceAsync(serviceCollection, _this, serviceInfo, null, true);
            return _this.GetService(type);
        }

        public static ServiceDescriptor? GetServiceDescriptor(this IServiceProvider _this, Type type)
        {
            var webAssmeblyServices = (WebAssmeblyServices)_this.GetRequiredService<IWebAssemblyServices>();
            var serviceInfo = webAssmeblyServices.GetServiceInfo(type, null);
            return serviceInfo?.ServiceDescriptor;
        }

        public static async Task<T?> GetServiceAsync<T>(this IServiceProvider _this) where T : class
        {
            return (T?)await _this.GetServiceAsync(typeof(T));
        }

        internal static async Task InitServiceAsync(IServiceCollection serviceDescriptors, IServiceProvider _this, ServiceInfo? serviceInfo, Type? dependencyOfType, bool isRequired = false)
        {
            if (serviceInfo == null)
            {
                return;
            }
            var instanceExists = serviceInfo.ImplementationInstance != null;
            if (serviceInfo.StartupState == StartupState.None && (isRequired || dependencyOfType != null))
            {
                serviceInfo.StartupState = StartupState.ShouldStart;
                serviceInfo.DependencyOfType = dependencyOfType;
            }
            if (serviceInfo.StartupState != StartupState.ShouldStart)
            {
                return;
            }
            var webAssmeblyServices = (WebAssmeblyServices)_this.GetRequiredService<IWebAssemblyServices>();
            serviceInfo.StartupState = StartupState.Starting;
            foreach (var dependencyType in serviceInfo.DependencyTypes)
            {
                //var dependencyInfo = serviceDescriptors.GetRegisteredServiceInfo(dependencyType.Item1, dependencyType.Item2);
                var autoStartInfo = webAssmeblyServices.AutoStartedServices.Where(o => o.ServiceType == dependencyType.Item1 && o.ServiceKey == dependencyType.Item2).LastOrDefault();
                if (autoStartInfo != null)
                {
                    await InitServiceAsync(serviceDescriptors, _this, autoStartInfo, serviceInfo.ServiceType);
                }
            }
            // this actual creates the instance
            object? service = null;
#if NET8_0_OR_GREATER
            if (serviceInfo.IsKeyedService)
            {
                service = _this.GetRequiredKeyedService(serviceInfo.ServiceDescriptor.ServiceType, serviceInfo.ServiceKey);
            }
            else
            {
                service = _this.GetRequiredService(serviceInfo.ServiceDescriptor.ServiceType);
            }
#else
            service = _this.GetRequiredService(serviceInfo.ServiceDescriptor.ServiceType);
#endif
            serviceInfo.DependencyOrder = webAssmeblyServices.AutoStartedServices.Where(o => o.StartupState == StartupState.Started).Count();
            serviceInfo.StartupState = StartupState.Started;
#if DEBUG
            Console.WriteLine($"Processed service: {serviceInfo.DependencyOrder} {serviceInfo.ServiceDescriptor.ServiceType.Name}");
#endif
            if (!instanceExists)
            {
#if DEBUG && true
                if (serviceInfo.DependencyOfType != null)
                {
                    Console.WriteLine($"Started background service: {serviceInfo.DependencyOrder} {serviceInfo.ServiceDescriptor.ServiceType.Name} dependency of {serviceInfo.DependencyOfType.Name}");
                }
                else
                {
                    Console.WriteLine($"Started background service: {serviceInfo.DependencyOrder} {serviceInfo.ServiceDescriptor.ServiceType.Name}");
                }
#endif
            }
            //if (!serviceInfo.InitAsyncCalled && service is IAsyncBackgroundService asyncBG)
            if (!instanceExists && service is IAsyncBackgroundService asyncBG)
            {
#if DEBUG && true
                if (serviceInfo.DependencyOfType != null)
                {
                    Console.WriteLine($"InitAsync background service: {serviceInfo.DependencyOrder} {serviceInfo.ServiceDescriptor.ServiceType.Name} dependency of {serviceInfo.DependencyOfType.Name}");
                }
                else
                {
                    Console.WriteLine($"InitAsync background service: {serviceInfo.DependencyOrder} {serviceInfo.ServiceDescriptor.ServiceType.Name}");
                }
#endif
                serviceInfo.InitAsyncCalled = true;
                await asyncBG.InitAsync();
            }
        }

        public static List<ServiceDescriptor>? FindServiceDescriptors(this IServiceCollection _this, Type? type)
        {
            if (type == null) return null;
            var services = _this.Where(o => o.ServiceType == type).ToList();
            if (services.Count > 0) return services;
            services = _this.Where(o => o.ImplementationType == type).ToList();
            if (services.Count > 0) return services;
            services = _this.Where(o => o.ServiceType.IsAssignableFrom(type)).ToList();
            return services;
        }

        public static async Task<object?> FindServiceAsync(this IServiceProvider _this, Type? serviceType)
        {
            if (serviceType == null) return null;
            var serviceCollection = _this.GetService<IServiceCollection>();
            if (serviceCollection == null) return await _this.GetServiceAsync(serviceType);
            var info = serviceCollection.FindServiceDescriptors(serviceType)!.FirstOrDefault();
            return await _this.GetServiceAsync(info == null ? serviceType : info.ServiceType);
        }

        /// <summary>
        /// BlazorJSRunAsync() is a scope aware replacement for RunAsync().<br />
        /// RunAsync() will be called internally but only when running in a Window global scope to prevent components from loading in Worker scopes.<br />
        /// This also prevent Blazor from trying to change the current location<br />
        /// BlazorJSRunAsync() also automatically starts IBackgroundService services, IAsyncBackgroundService services<br />
        /// and singletons services registered with a GlobalScope enum value that is compatible the current GlobalScope.<br />
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="serviceOnlyMode">Disable component loading in a Window global scope.</param>
        /// <returns></returns>
        public static async Task BlazorJSRunAsync(this WebAssemblyHost _this, bool serviceOnlyMode = false)
        {
            await _this.StartBackgroundServices();
            BlazorJSRuntime.JS.SetReady();
            if (BlazorJSRuntime.JS.IsWindow && !serviceOnlyMode)
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
                Console.WriteLine($"BlazorJSRunAsync mode: Worker");
#endif
                // This is a worker so we are going to use this to allow services in workers without the html renderer trying to load pages
                var tcs = new TaskCompletionSource<object>();
                await tcs.Task;
            }
        }

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
        public static IServiceCollection AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services, GlobalScope autoStartMode) where TService : class where TImplementation : class, TService
        {
            ThrowIfNull(services);
            WebAssmeblyServices.GetExtension(services)!.AutoStartModes[typeof(TService)] = autoStartMode;
            return services.AddSingleton(typeof(TService), typeof(TImplementation));
        }

        /// <summary>
        /// Adds a singleton service of the type specified in <paramref name="serviceType"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="serviceType">The type of the service to register and the implementation to use.</param>
        /// <param name="autoStartMode">GlobalScope flags indicating in which scopes the service should be started automatically</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton(this IServiceCollection services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, GlobalScope autoStartMode)
        {
            ThrowIfNull(services);
            ThrowIfNull(serviceType);
            WebAssmeblyServices.GetExtension(services)!.AutoStartModes[serviceType] = autoStartMode;
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
        public static IServiceCollection AddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IServiceCollection services, GlobalScope autoStartMode) where TService : class
        {
            ThrowIfNull(services);
            WebAssmeblyServices.GetExtension(services)!.AutoStartModes[typeof(TService)] = autoStartMode;
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
        public static IServiceCollection AddSingleton<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory, GlobalScope autoStartMode) where TService : class
        {
            ThrowIfNull(services);
            ThrowIfNull(implementationFactory);
            WebAssmeblyServices.GetExtension(services)!.AutoStartModes[typeof(TService)] = autoStartMode;
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
        public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory, GlobalScope autoStartMode) where TService : class where TImplementation : class, TService
        {
            ThrowIfNull(services);
            ThrowIfNull(implementationFactory);
            WebAssmeblyServices.GetExtension(services)!.AutoStartModes[typeof(TService)] = autoStartMode;
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
        public static IServiceCollection AddSingleton(this IServiceCollection services, Type serviceType, object implementationInstance, GlobalScope autoStartMode)
        {
            ThrowIfNull(services);
            ThrowIfNull(serviceType);
            ThrowIfNull(implementationInstance);
            WebAssmeblyServices.GetExtension(services)!.AutoStartModes[serviceType] = autoStartMode;
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
        public static IServiceCollection AddSingleton<TService>(this IServiceCollection services, TService implementationInstance, GlobalScope autoStartMode) where TService : class
        {
            ThrowIfNull(services);
            ThrowIfNull(implementationInstance);
            WebAssmeblyServices.GetExtension(services)!.AutoStartModes[typeof(TService)] = autoStartMode;
            return services.AddSingleton(typeof(TService), implementationInstance);
        }

        static void ThrowIfNull<T>(T? value)
        {
            if (value == null) throw new ArgumentNullException($"{typeof(T).Name} cannot be null");
        }
    }
}
