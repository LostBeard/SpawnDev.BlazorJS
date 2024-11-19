using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using SpawnDev.BlazorJS.RemoteJSRuntime;
using System.Diagnostics.CodeAnalysis;
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
            if (!_this.Any(o => o.ServiceType == typeof(IServiceCollection)))
            {
                _this.AddSingleton<IServiceCollection>(_this);
            }
            if (!_this.Any(o => o.ServiceType == typeof(IWebAssemblyServices)))
            {
                _this.AddSingleton<IWebAssemblyServices>(WebAssemblyServices.GetExtension(_this, true)!);
            }
            if (!_this.Any(o => o.ServiceType == typeof(BlazorJSRuntime)) && BlazorJSRuntime.JS == null)
            {
                var JS = new BlazorJSRuntime();
                _this.AddSingleton<BlazorJSRuntime>(JS);
            }
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
            _this.AddBlazorJSRuntime();
            JS = BlazorJSRuntime.JS;
            return _this;
        }
        /// <summary>
        /// Adds the BlazorJSRuntime scoped service.
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static IServiceCollection AddBlazorJSRuntimeScoped(this IServiceCollection _this)
        {
            if (!_this.Any(o => o.ServiceType == typeof(IServiceCollection)))
            {
                _this.AddSingleton<IServiceCollection>(_this);
            }
            if (!_this.Any(o => o.ServiceType == typeof(IWebAssemblyServices)))
            {
                _this.AddSingleton<IWebAssemblyServices>(WebAssemblyServices.GetExtension(_this, true)!);
            }
            if (!_this.Any(o => o.ServiceType == typeof(BlazorJSRuntime)))
            {
                _this.AddScoped<BlazorJSRuntime>(sp => new BlazorJSRuntime(sp.GetRequiredService<IJSRuntime>()));
            }
            return _this;
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
            var webAssemblyServices = (WebAssemblyServices)_this.Services.GetRequiredService<IWebAssemblyServices>();
            if (webAssemblyServices.Started) return _this;
            await _this.Services.StartBackgroundServices();
            return _this;
        }
        /// <summary>
        /// Services implementing IBackgroundService or IAsyncBackgroundService will be started
        /// Services implementing IAsyncBackgroundService will have their IAsyncBackgroundService.Ready Task property awaited in parallel<br/>
        /// Singletons registered with an auto start GlobalScope that matches the current scope will be started<br/>
        /// Background services must be careful to not take too long in their InitAsync methods as other services are waiting to init and the app is waiting to start
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task StartBackgroundServices(this IServiceProvider _this)
        {
            var webAssemblyServices = (WebAssemblyServices)_this.GetRequiredService<IWebAssemblyServices>();
            if (webAssemblyServices.Started) return;
            webAssemblyServices.Started = true;
            webAssemblyServices.Services = _this;
            var JS = _this.GetRequiredService<BlazorJSRuntime>();
            var serviceCollection = _this.GetRequiredService<IServiceCollection>();
            webAssemblyServices.ServiceInformation = serviceCollection!.Select(o => new ServiceInformation(o, JS.GlobalScope, serviceCollection!)).ToList();
            var shouldStartInfos = webAssemblyServices.ServiceInformation.Where(o => o.CurrentScopeAutoStart).ToList();
            var services = new List<object>();
            foreach (var shouldStartInfo in shouldStartInfos)
            {
                var service = shouldStartInfo.GetService(_this)!;
                services.Add(service);
            }
            var asyncServiceReadyTasks = new List<Task>();
            foreach (var service in services)
            {
                if (service is IAsyncBackgroundService asyncBackgroundService)
                {
                    asyncServiceReadyTasks.Add(asyncBackgroundService.Ready);
                }
            }
            await Task.WhenAll(asyncServiceReadyTasks);
        }
        /// <summary>
        /// Returns the service of the given service type.<br/>
        /// If the service is implements IAsyncBackgroundService, IAsyncBackgroundService.Ready will be awaited.
        /// </summary>
        public static async Task<TService?> GetServiceAsync<TService>(this IServiceProvider _this)
        {
            return (TService?)await _this.GetServiceAsync(typeof(TService));
        }
        /// <summary>
        /// Returns the service of the given service type.<br/>
        /// If the service is implements IAsyncBackgroundService, IAsyncBackgroundService.Ready will be awaited.
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object?> GetServiceAsync(this IServiceProvider _this, Type type)
        {
            var service = _this.GetService(type);
            if (service is IAsyncBackgroundService asyncBackgroundService)
            {
                await asyncBackgroundService.Ready;
            }
            return service;
        }
        /// <summary>
        /// Returns the service of the given service type.<br/>
        /// If the service is implements IAsyncBackgroundService, IAsyncBackgroundService.Ready will be awaited.
        /// </summary>
        public static async Task<object?> GetServiceAsync(this IServiceProvider _this, Type type, object key)
        {
#if NET8_0_OR_GREATER
            try
            {
                var service = _this.GetRequiredKeyedService(type, key);
                if (service is IAsyncBackgroundService asyncBackgroundService)
                {
                    await asyncBackgroundService.Ready;
                }
                return service;
            }
            catch { }
#endif
            return null;
        }
        public static object? GetService(this IServiceProvider _this, Type type, object key)
        {
#if NET8_0_OR_GREATER
            try
            {
                return _this.GetRequiredKeyedService(type, key);
            }
            catch { }
#endif
            return null;
        }
        public static TService? GetService<TService>(this IServiceProvider _this, object key)
        {
#if NET8_0_OR_GREATER
            try
            {
                return (TService?)_this.GetRequiredKeyedService(typeof(TService), key);
            }
            catch { }
#endif
            return default;
        }

        public static ServiceDescriptor? GetServiceDescriptor(this IServiceProvider _this, Type type)
        {
            var descriptors = _this.GetRequiredService<IServiceCollection>();
            return descriptors.FirstOrDefault(o => o.ServiceType == type);
        }

        public static ServiceDescriptor? FindKeyedServiceDescriptor(this IServiceCollection _this, Type? type, object key, bool strict = false)
        {
            ServiceDescriptor? services = null;
            if (type == null) return services;
#if NET8_0_OR_GREATER
            services = _this.FirstOrDefault(o => o.IsKeyedService && Object.Equals(o.ServiceKey, key) && o.ServiceType == type);
            if (services != null || strict) return services;
            services = _this.FirstOrDefault(o => o.IsKeyedService && Object.Equals(o.ServiceKey, key) && o.ImplementationType == type);
            if (services != null) return services;
            services = _this.FirstOrDefault(o => o.IsKeyedService && Object.Equals(o.ServiceKey, key) && o.ServiceType.IsAssignableFrom(type));
#endif
            return services;
        }

        public static ServiceDescriptor? FindServiceDescriptor(this IServiceCollection _this, Type? type, bool strict = false)
        {
            if (type == null) return null;
            var services = _this.FirstOrDefault(o => o.ServiceType == type);
            if (services != null || strict) return services;
            services = _this.FirstOrDefault(o => o.ImplementationType == type);
            if (services != null) return services;
            services = _this.FirstOrDefault(o => o.ServiceType.IsAssignableFrom(type));
            return services;
        }

        /// <summary>
        /// Returns all ServiceDescriptors for services registered with the given service type<br/>
        /// Type can be the type or the implementing type
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<ServiceDescriptor> FindServiceDescriptors(this IServiceCollection _this, Type? type)
        {
            if (type == null) return new List<ServiceDescriptor>();
            var services = _this.Where(o => o.ServiceType == type).ToList();
            if (services.Count > 0) return services;
            services = _this.Where(o => o.ImplementationType == type).ToList();
            if (services.Count > 0) return services;
            services = _this.Where(o => o.ServiceType.IsAssignableFrom(type)).ToList();
            return services;
        }
        public static List<ServiceDescriptor> FindServiceDescriptors<TService>(this IServiceCollection _this, object key)
        {
            return _this.FindServiceDescriptors(typeof(TService), key);
        }
        public static List<ServiceDescriptor> FindServiceDescriptors(this IServiceCollection _this, Type type, object key)
        {
#if NET8_0_OR_GREATER
            if (type == null) return new List<ServiceDescriptor>();
            var services = _this.Where(o => o.ServiceType == type && Object.Equals(o.ServiceKey, key)).ToList();
            if (services.Count > 0) return services;
            services = _this.Where(o => o.ImplementationType == type && Object.Equals(o.ServiceKey, key)).ToList();
            if (services.Count > 0) return services;
            services = _this.Where(o => o.ServiceType.IsAssignableFrom(type) && Object.Equals(o.ServiceKey, key)).ToList();
            return services;
#else
            return new List<ServiceDescriptor>();
#endif
        }
        public static async Task<TService?> FindServiceAsync<TService>(this IServiceProvider _this)
        {
            return (TService?)await _this.FindServiceAsync(typeof(TService));
        }
        public static async Task<object?> FindServiceAsync(this IServiceProvider _this, Type? serviceType)
        {
            if (serviceType == null) return null;
            var serviceCollection = _this.GetService<IServiceCollection>();
            if (serviceCollection == null) return await _this.GetServiceAsync(serviceType);
            var info = serviceCollection.FindServiceDescriptors(serviceType)!.FirstOrDefault();
            return await _this.GetServiceAsync(info == null ? serviceType : info.ServiceType);
        }
        public static async Task<TService?> FindServiceAsync<TService>(this IServiceProvider _this, object key)
        {
            return (TService?)await _this.FindServiceAsync(typeof(TService), key);
        }
        public static async Task<object?> FindServiceAsync(this IServiceProvider _this, Type serviceType, object key)
        {
            if (serviceType == null) return null;
            var serviceCollection = _this.GetService<IServiceCollection>();
            if (serviceCollection == null) return await _this.GetServiceAsync(serviceType, key);
            var info = serviceCollection.FindServiceDescriptors(serviceType, key)!.FirstOrDefault();
            return await _this.GetServiceAsync(info == null ? serviceType : info.ServiceType, key);
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
                Console.WriteLine($"BlazorJSRunAsync mode: ServiceOnlyMode");
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
            WebAssemblyServices.GetExtension(services)!.AutoStartModes[typeof(TService)] = autoStartMode;
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
            WebAssemblyServices.GetExtension(services)!.AutoStartModes[serviceType] = autoStartMode;
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
            WebAssemblyServices.GetExtension(services)!.AutoStartModes[typeof(TService)] = autoStartMode;
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
            WebAssemblyServices.GetExtension(services)!.AutoStartModes[typeof(TService)] = autoStartMode;
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
            WebAssemblyServices.GetExtension(services)!.AutoStartModes[typeof(TService)] = autoStartMode;
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
            WebAssemblyServices.GetExtension(services)!.AutoStartModes[serviceType] = autoStartMode;
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
            WebAssemblyServices.GetExtension(services)!.AutoStartModes[typeof(TService)] = autoStartMode;
            return services.AddSingleton(typeof(TService), implementationInstance);
        }

        static void ThrowIfNull<T>(T? value)
        {
            if (value == null) throw new ArgumentNullException($"{typeof(T).Name} cannot be null");
        }
    }
}
