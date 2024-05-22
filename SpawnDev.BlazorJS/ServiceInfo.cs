using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SpawnDev.BlazorJS
{
    internal class ServiceInfo
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
        internal ServiceInfo(ServiceDescriptor serviceDescriptor, GlobalScope currentGlobalScope, IServiceCollection serviceCollection)
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
            var serviceAutoStartScopeSet = WebAssmeblyServices.GetExtension(serviceCollection)!.GetAutoStartMode(ServiceType);
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
            var availableServices = WebAssmeblyServices.GetExtension(serviceCollection)!.GetRegisteredServices();
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
}
