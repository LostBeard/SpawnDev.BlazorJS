using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json;
using static SpawnDev.BlazorJS.IServiceCollectionExtensions;

namespace SpawnDev.BlazorJS
{
    public class BlazorJSRunOptions
    {
        /// <summary>
        /// If ServiceOnlyMode is true, Blazor will not load any components when running in a Window global scope<br />
        /// Singleton services that implement IBackgroundService or IAsyncBackgroundService will be started<br />
        /// ServiceOnlyMode is automatically enabled when not running in a Window global scope<br />
        /// This can be useful when running an extension background page (Ex. Firefox browser extension)
        /// </summary>
        public bool ServiceOnlyMode { get; set; }
    }
    public interface IBackgroundService
    {

    }
    public interface IAsyncBackgroundService : IBackgroundService
    {
        Task InitAsync();
    }
    public static class IServiceCollectionExtensions
    {
        //public static T CreateInstanceWithServices<T>(this IServiceProvider _this) where T : class => (T)_this.CreateInstanceWithServices(typeof(T));
        //public static object CreateInstanceWithServices(this IServiceProvider _this, Type type)
        //{
        //    var constructor = type.GetConstructors().Single();
        //    var parameters = constructor.GetParameters();
        //    var args = new object?[parameters.Length];
        //    for (var i = 0; i < parameters.Length; i++)
        //    {
        //        var parameter = parameters[i];
        //        var parameterType = parameter.ParameterType;
        //        // TODO - check if this is a keyed service
        //        var paramService = _this.GetService(parameterType);
        //        if (paramService != null)
        //        {
        //            args[i] = paramService;
        //        }
        //        else if (parameter.HasDefaultValue)
        //        {
        //            args[i] = parameter.DefaultValue;
        //        }
        //    }
        //    return Activator.CreateInstance(type, args)!;
        //}
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
            return _this.AddSingleton<BlazorJSRuntime>(BlazorJSRuntime.JS);
        }
        /// <summary>
        /// Returns a list of registered services represented as a Tuple - ServiceType, ServiceKey, ServiceDescriptor
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        internal static List<(Type, object?, ServiceDescriptor)> GetRegisteredServices(this IServiceCollection _this)
        {
            return _this.Select(x =>
            {
                object? serviceKey = null;
#if NET8_0_OR_GREATER
                serviceKey = x.ServiceKey;
#endif
                return (x.ServiceType, serviceKey, x);
            }).ToList();
        }
        internal static (Type, object?, ServiceDescriptor)? GetRegisteredServiceInfo(this IServiceCollection _this, Type serviceType, object? serviceKey)
        {
            var rets = _this.GetRegisteredServices().Where(o => o.Item1 == serviceType && o.Item2 == serviceKey).ToList();
            return rets.Any() ? rets.Last() : null;
        }
        internal static List<AutoStartedService> AutoStartedServices { get; private set; } = new List<AutoStartedService>();
        internal enum StartupState
        {
            None,
            ShouldStart,
            Starting,
            Constructing,
            Started,
        }
        internal class AutoStartedService
        {
            public Type ServiceType { get; set; }
            public Type ImplementationType { get; set; }
            public object? ServiceKey { get; set; } = null;
            public bool IsKeyedService { get; set; }
            public ServiceDescriptor ServiceDescriptor { get; set; }
            public object? ImplementationInstance
            {
                get
                {
#if NET8_0_OR_GREATER
                    return ServiceDescriptor.IsKeyedService ? ServiceDescriptor.KeyedImplementationInstance : null;
#else
                    return ServiceDescriptor.ImplementationInstance;
#endif
                }
            }
            public GlobalScope GlobalScope { get; set; }
            public bool ImplementsIBackgroundService { get; private set; }
            public bool ImplementsIAsyncBackgroundService { get; private set; }
            public StartupState StartupState { get; set; }
            public List<(Type, object?)> DependencyTypes { get; private set; }
            public int DependencyOrder { get; set; } = -1;
            public Type? DependencyOfType { get; set; }
            public bool InitAsyncCalled { get; set; }
            public ConstructorInfo? ConstructorInfo { get; private set; }
            public AutoStartedService(ServiceDescriptor serviceDescriptor, GlobalScope currentGlobalScope, IServiceCollection serviceCollection)
            {
                ServiceDescriptor = serviceDescriptor;
                ServiceType = ServiceDescriptor.ServiceType;
#if NET8_0_OR_GREATER
                IsKeyedService = ServiceDescriptor.IsKeyedService;
                if (ServiceDescriptor.IsKeyedService)
                {
                    ServiceKey = ServiceDescriptor.ServiceKey;
                    ImplementationType = ServiceDescriptor.KeyedImplementationType ?? (ServiceDescriptor.KeyedImplementationInstance != null ? ServiceDescriptor.KeyedImplementationInstance.GetType() : ServiceDescriptor.ServiceType);
                }
#endif
                if (ImplementationType == null)
                {
                    ImplementationType = ServiceDescriptor.ImplementationType ?? (ServiceDescriptor.ImplementationInstance != null ? ServiceDescriptor.ImplementationInstance.GetType() : ServiceDescriptor.ServiceType);
                }
                var isIBackgroundService = typeof(IBackgroundService).IsAssignableFrom(ServiceType) || typeof(IBackgroundService).IsAssignableFrom(ImplementationType);
                var isIAsyncBackgroundService = typeof(IAsyncBackgroundService).IsAssignableFrom(ServiceType) || typeof(IAsyncBackgroundService).IsAssignableFrom(ImplementationType);
                var serviceAutoStartScopeSet = GetAutoStartMode(ServiceType);
                var serviceAutoStartScope = GlobalScope.None;
                if (serviceAutoStartScopeSet == null || serviceAutoStartScopeSet.Value == GlobalScope.Default)
                {
                    serviceAutoStartScope = isIBackgroundService ? GlobalScope.All : GlobalScope.None;
                }
                else
                {
                    serviceAutoStartScope = serviceAutoStartScopeSet.Value;
                }
                var shouldStart = (currentGlobalScope & serviceAutoStartScope) != 0;
                GlobalScope = serviceAutoStartScope;
                ImplementsIAsyncBackgroundService = isIAsyncBackgroundService;
                ImplementsIBackgroundService = isIBackgroundService;
                StartupState = shouldStart ? StartupState.ShouldStart : StartupState.None;
                // Find the constructor and required services
                GetBestConstructor(serviceCollection, ImplementationType, out var constructorInfo, out var requiredServices);
                DependencyTypes = requiredServices;
                ConstructorInfo = constructorInfo;
            }
            void GetBestConstructor(IServiceCollection serviceCollection, Type type, out ConstructorInfo? constructorInfo, out List<(Type, object?)> requiredServices)
            {
                var availableServices = serviceCollection.GetRegisteredServices();
                var constructors = type.GetConstructors().OrderByDescending(o => o.GetParameters().Length).ToList();
                // check for a constructor marked for use when activating type using ActivatorUtilities
                // https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.activatorutilitiesconstructorattribute?view=dotnet-plat-ext-8.0
                var activatorUtilitiesConstructors = constructors.Where(o => o.GetCustomAttribute<ActivatorUtilitiesConstructorAttribute>() != null).ToList();
                // if any constructors have the attribute ActivatorUtilitiesConstructorAttribute, only try those constructors
                if (activatorUtilitiesConstructors.Any())
                {
                    constructors = activatorUtilitiesConstructors;
                }
                foreach (var constructor in constructors)
                {
                    // check if all parameters are resolvable
                    var constructorRequiredServices = new List<(Type, object?)>();
                    var paramInfos = constructor.GetParameters();
                    var allParamsResolve = true;
                    foreach (var paramInfo in paramInfos)
                    {
                        var paramType = paramInfo.ParameterType;
                        var iEnumerableType = paramType.IsInterface && paramType.IsGenericType && paramType.GetGenericTypeDefinition() == typeof(IEnumerable<>) ? paramType.GetGenericArguments()[0] : null;
                        object? paramServiceKey = null;
#if NET8_0_OR_GREATER
                        var fromKeyedServicesAttribute = paramInfo.GetCustomAttribute<FromKeyedServicesAttribute>();
                        if (fromKeyedServicesAttribute != null) paramServiceKey = fromKeyedServicesAttribute.Key;
#endif
                        var paramServiceType = iEnumerableType ?? paramType;
                        var servicesThatResolve = availableServices.Where(o => o.Item1 == paramServiceType && o.Item2 == paramServiceKey).ToList();
                        var serviceCanResolve = servicesThatResolve.Any();
                        if (serviceCanResolve)
                        {
                            constructorRequiredServices.Add((paramServiceType, paramServiceKey));
                        }
                        var hasDefaultValue = paramInfo.HasDefaultValue;
                        var paramResolves = hasDefaultValue || serviceCanResolve;
                        if (!paramResolves)
                        {
                            allParamsResolve = false;
                            break;
                        }
                    }
                    if (allParamsResolve)
                    {
                        constructorInfo = constructor;
                        requiredServices = constructorRequiredServices;
                        return;
                    }
                }
                requiredServices = new List<(Type, object?)>();
                constructorInfo = null;
            }
        }

        //static WebAssemblyHost? WebAssemblyHost { get; set; }

        //static IServiceProvider? Services { get; set; }

        static bool StartBackgroundServicesRan = false;
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
            if (StartBackgroundServicesRan) return _this;
            StartBackgroundServicesRan = true;
            var JS = BlazorJSRuntime.JS;
            //WebAssemblyHost = _this;
            //Services = _this.Services;
            AutoStartedServices = serviceCollection!.Select(o => new AutoStartedService(o, JS.GlobalScope, serviceCollection!)).ToList();
            foreach (var serviceInfo in AutoStartedServices)
            {
                await InitServiceAsync(serviceCollection!, _this.Services, serviceInfo, null, false);
            }
            return _this;
        }

        //static AutoStartedService GetAutoStartedServiceInfo(ServiceDescriptor o)
        //{
        //    var isIBackgroundService = typeof(IBackgroundService).IsAssignableFrom(o.ServiceType) || typeof(IBackgroundService).IsAssignableFrom(o.ImplementationType);
        //    var isIAsyncBackgroundService = typeof(IAsyncBackgroundService).IsAssignableFrom(o.ServiceType) || typeof(IAsyncBackgroundService).IsAssignableFrom(o.ImplementationType);
        //    var serviceAutoStartScopeSet = GetAutoStartMode(o.ServiceType);
        //    var serviceAutoStartScope = GlobalScope.None;
        //    if (serviceAutoStartScopeSet == null || serviceAutoStartScopeSet.Value == GlobalScope.Default)
        //    {
        //        serviceAutoStartScope = isIBackgroundService ? GlobalScope.All : GlobalScope.None;
        //    }
        //    else
        //    {
        //        serviceAutoStartScope = serviceAutoStartScopeSet.Value;
        //    }
        //    var implementationType = o.ImplementationType ?? o.ServiceType;
        //    var constructor = implementationType.GetConstructors().FirstOrDefault();
        //    var shouldStart = BlazorJSRuntime.JS.IsScope(serviceAutoStartScope);
        //    var autoStartedService = new AutoStartedService
        //    {
        //        ServiceDescriptor = o,
        //        GlobalScope = serviceAutoStartScope,
        //        ImplementsIAsyncBackgroundService = isIAsyncBackgroundService,
        //        ImplementsIBackgroundService = isIBackgroundService,
        //        StartupState = shouldStart ? StartupState.ShouldStart : StartupState.None,
        //        DependencyTypes = constructor != null ? constructor.GetParameters().Select(p => p.ParameterType).ToList() : new List<Type>(),
        //    };
        //    return autoStartedService;
        //}

        public static async Task<object?> GetServiceAsync(this IServiceProvider _this, Type type)
        {
            var serviceInfo = GetServiceInfo(type, null);
            if (serviceInfo == null) return null;
            await InitServiceAsync(serviceCollection!, _this, serviceInfo, null, true);
            return _this.GetService(type);
        }

        static AutoStartedService? GetServiceInfo(Type serviceType, object? serviceKey)
        {
            return AutoStartedServices.Where(o => o.ServiceType == serviceType && o.ServiceKey == serviceKey).LastOrDefault();
        }

        static List<AutoStartedService> GetServiceInfos(Type serviceType, object? serviceKey)
        {
            return AutoStartedServices.Where(o => o.ServiceType == serviceType && o.ServiceKey == serviceKey).ToList();
        }

        public static async Task<T?> GetServiceAsync<T>(this IServiceProvider _this) where T : class
        {
            return (T?)await _this.GetServiceAsync(typeof(T));
        }

        internal static async Task InitServiceAsync(IServiceCollection serviceDescriptors, IServiceProvider _this, AutoStartedService? serviceInfo, Type? dependencyOfType, bool isRequired = false)
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
            serviceInfo.StartupState = StartupState.Starting;
            foreach (var dependencyType in serviceInfo.DependencyTypes)
            {
                //var dependencyInfo = serviceDescriptors.GetRegisteredServiceInfo(dependencyType.Item1, dependencyType.Item2);
                var autoStartInfo = AutoStartedServices.Where(o => o.ServiceType == dependencyType.Item1 && o.ServiceKey == dependencyType.Item2).LastOrDefault();
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
            serviceInfo.DependencyOrder = AutoStartedServices.Where(o => o.StartupState == StartupState.Started).Count();
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

        public static async Task<object?> FindServiceAsync(this IServiceProvider _this, Type? type)
        {
            if (type == null) return null;
            var service = await _this.GetServiceAsync(type);
            if (service == null)
            {
                //Console.WriteLine($"serviceType not found: {type.Name}");
                foreach (var serviceDescriptor in serviceCollection)
                {
                    //var serviceType = serviceDescriptor.ServiceType;
                    //var implementationType = serviceDescriptor.ImplementationType != null ? serviceDescriptor.ImplementationType :
                    //    (serviceDescriptor.ImplementationInstance != null ? serviceDescriptor.ImplementationInstance.GetType() : null);
                    var autoStartInfo = AutoStartedServices.Where(o => o.ServiceDescriptor == serviceDescriptor).FirstOrDefault();
                    if (autoStartInfo == null)
                    {
                        continue;
                    }
                    var serviceType = autoStartInfo.ServiceType;
                    var implementationType = autoStartInfo.ImplementationType;

                    //var implementationTypeName = implementationType == null ? "[UNNAMED]" : implementationType.Name;
                    //Console.WriteLine($">>> {serviceType.Name} {implementationTypeName}");
                    if (type == implementationType)
                    {
                        //Console.WriteLine($"+++ serviceType found using implementation: {serviceType.Name} {implementationTypeName}");
                        service = await _this.GetServiceAsync(serviceType);
                        break;
                    }
                    else if (serviceType.IsAssignableFrom(type))
                    {
                        //Console.WriteLine($"+++ serviceType found using implementation: {serviceType.Name} {implementationTypeName}");
                        service = await _this.GetServiceAsync(serviceType);
                        break;
                    }
                }
            }
            return service;
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

        private static GlobalScope? GetAutoStartMode(Type type)
        {
            return AutoStartModes.TryGetValue(type, out var mode) ? mode : null;
        }

        // AddSingleton overloads that also take GlobalScope
        private static Dictionary<Type, GlobalScope> AutoStartModes = new Dictionary<Type, GlobalScope>();

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
            AutoStartModes[typeof(TService)] = autoStartMode;
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
        public static IServiceCollection AddSingleton(
            this IServiceCollection services,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, GlobalScope autoStartMode)
        {
            ThrowIfNull(services);
            ThrowIfNull(serviceType);
            AutoStartModes[serviceType] = autoStartMode;
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
            AutoStartModes[typeof(TService)] = autoStartMode;
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
            AutoStartModes[typeof(TService)] = autoStartMode;
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
            AutoStartModes[typeof(TService)] = autoStartMode;
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
            AutoStartModes[serviceType] = autoStartMode;
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
            AutoStartModes[typeof(TService)] = autoStartMode;
            return services.AddSingleton(typeof(TService), implementationInstance);
        }

        static void ThrowIfNull<T>(T? value)
        {
            if (value == null) throw new ArgumentNullException($"{typeof(T).Name} cannot be null");
        }
    }
}
