using Microsoft.Extensions.DependencyInjection;

namespace SpawnDev.BlazorJS
{
    public interface IWebAssemblyServices
    {
        IServiceCollection Descriptors { get; }
        IServiceProvider Services { get; }
    }
    public class WebAssemblyServices : IWebAssemblyServices
    {
        public IServiceProvider Services { get; internal set; }
        public bool Started { get; internal set; }
        public List<ServiceInformation> ServiceInformation { get; internal set; } = new List<ServiceInformation>();
        public Dictionary<Type, GlobalScope> AutoStartModes { get; private set; } = new Dictionary<Type, GlobalScope>();
        internal ServiceInformation? GetServiceInfo(Type serviceType, object? serviceKey)
        {
            return ServiceInformation.Where(o => o.ServiceType == serviceType && o.ServiceKey == serviceKey).LastOrDefault();
        }
        internal List<ServiceInformation> GetServiceInfos(Type serviceType, object? serviceKey)
        {
            return ServiceInformation.Where(o => o.ServiceType == serviceType && o.ServiceKey == serviceKey).ToList();
        }
        static Dictionary<IServiceCollection, WebAssemblyServices> Extensions = new Dictionary<IServiceCollection, WebAssemblyServices>();
        public IServiceCollection Descriptors { get; }
        public WebAssemblyServices(IServiceCollection serviceCollection)
        {
            Descriptors = serviceCollection;
        }
        public static WebAssemblyServices? GetExtension(IServiceCollection serviceCollection, bool allowCreate = true)
        {
            if (Extensions.TryGetValue(serviceCollection, out WebAssemblyServices? extension) || !allowCreate) return extension;
            extension = new WebAssemblyServices(serviceCollection);
            Extensions.Add(serviceCollection, extension);
            return extension;
        }
        /// <summary>
        /// Returns a list of registered services represented as a Tuple - ServiceType, ServiceKey, ServiceDescriptor
        /// </summary>
        /// <returns>Tuple (ServiceType, ServiceKey, ServiceDescriptor)</returns>
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
