﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SpawnDev.BlazorJS
{
    public class ServiceInformation
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
        public GlobalScope ServiceAutoStartScope { get; set; }
        public bool ImplementsIBackgroundService { get; private set; }
        public bool ImplementsIAsyncBackgroundService { get; private set; }
        public bool CurrentScopeAutoStart { get; private set; }
        //public List<(Type, object?)> DependencyTypes { get; private set; }
        //public int DependencyOrder { get; set; } = -1;
        //public Type? DependencyOfType { get; set; }
        //public bool InitAsyncCalled { get; set; }
        //public ConstructorInfo? ConstructorInfo { get; private set; }
        public object? GetService(IServiceProvider serviceProvider)
        {
            object? service = null;
            if (IsKeyedService)
            {
#if NET8_0_OR_GREATER
                service = serviceProvider.GetRequiredKeyedService(ServiceType, ServiceKey);
#endif
            }
            else
            {
                service = serviceProvider.GetRequiredService(ServiceType);
            }
            return service;
        }
        public async Task<object?> GetServiceAsync(IServiceProvider serviceProvider)
        {
            object? service = GetService(serviceProvider);
            if (service is IAsyncBackgroundService asyncBackgroundService)
            {
                await asyncBackgroundService.Ready;
            }
            return service;
        }
        internal ServiceInformation(ServiceDescriptor serviceDescriptor, GlobalScope currentGlobalScope, IServiceCollection serviceCollection)
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
            var serviceAutoStartScopeSet = WebAssemblyServices.GetExtension(serviceCollection)!.GetAutoStartMode(ServiceType);
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
            ServiceAutoStartScope = serviceAutoStartScope;
            ImplementsIAsyncBackgroundService = isIAsyncBackgroundService;
            ImplementsIBackgroundService = isIBackgroundService;
            CurrentScopeAutoStart = shouldStart;// ? StartupState.ShouldStart : StartupState.None;
            // Find the constructor and required services
            //GetBestConstructor(serviceCollection, ImplementationType, out var constructorInfo, out var requiredServices);
            //DependencyTypes = requiredServices;
            //ConstructorInfo = constructorInfo;
        }
    }
}
