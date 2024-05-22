using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace SpawnDev.BlazorJS
{
    public interface IWebAssemblyServices
    {
        IServiceCollection Descriptors { get; }
        IServiceProvider Services { get; }
    }
    public class WebAssmeblyServices : IWebAssemblyServices
    {
        public IServiceProvider Services { get; internal set; }
        public WebAssemblyHost Host { get; internal set; }
        public bool Started { get; internal set; }
        internal List<ServiceInfo> AutoStartedServices { get; set; } = new List<ServiceInfo>();
        public Dictionary<Type, GlobalScope> AutoStartModes { get; private set; } = new Dictionary<Type, GlobalScope>();
        internal ServiceInfo? GetServiceInfo(Type serviceType, object? serviceKey)
        {
            return AutoStartedServices.Where(o => o.ServiceType == serviceType && o.ServiceKey == serviceKey).LastOrDefault();
        }
        internal List<ServiceInfo> GetServiceInfos(Type serviceType, object? serviceKey)
        {
            return AutoStartedServices.Where(o => o.ServiceType == serviceType && o.ServiceKey == serviceKey).ToList();
        }
        static Dictionary<IServiceCollection, WebAssmeblyServices> Extensions = new Dictionary<IServiceCollection, WebAssmeblyServices>();
        public IServiceCollection Descriptors { get; }
        public WebAssmeblyServices(IServiceCollection serviceCollection)
        {
            Descriptors = serviceCollection;
        }
        public static WebAssmeblyServices? GetExtension(IServiceCollection serviceCollection, bool allowCreate = true)
        {
            if (Extensions.TryGetValue(serviceCollection, out WebAssmeblyServices? extension) || !allowCreate) return extension;
            extension = new WebAssmeblyServices(serviceCollection);
            Extensions.Add(serviceCollection, extension);
            return extension;
        }
        /// <summary>
        /// Returns a list of registered services represented as a Tuple - ServiceType, ServiceKey, ServiceDescriptor
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public List<(Type, object?, ServiceDescriptor)> GetRegisteredServices()
        {
            return Descriptors.Select(x =>
            {
                object? serviceKey = null;
#if NET8_0_OR_GREATER
                serviceKey = x.ServiceKey;
#endif
                return (x.ServiceType, serviceKey, x);
            }).ToList();
        }
        public (Type, object?, ServiceDescriptor)? GetRegisteredServiceInfo(Type serviceType, object? serviceKey)
        {
            var rets = GetRegisteredServices().Where(o => o.Item1 == serviceType && o.Item2 == serviceKey).ToList();
            return rets.Any() ? rets.Last() : null;
        }
        public GlobalScope? GetAutoStartMode(Type type)
        {
            return AutoStartModes.TryGetValue(type, out var mode) ? mode : null;
        }
    }
}
