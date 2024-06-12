using System.Reflection;

namespace SpawnDev.BlazorJS.Reflection
{
    /// <summary>
    /// This Proxy presents itself as the interface it is created with but calls are converted to MethodInfos with arguments and passed onto the ICallDispatcher given at creation
    /// </summary>
    /// <typeparam name="TServiceInterface"></typeparam>
    public class InterfaceCallDispatcher<TServiceInterface> : DispatchProxy where TServiceInterface : class
    {
        private Func<MethodInfo, object?[]?, object?>? Resolver { get; set; }
        private Func<object?, MethodInfo, object?[]?, object?>? KeyedResolver { get; set; }
        private Func<MethodInfo, object?[]?, Task<object?>>? AsyncResolver { get; set; }
        private Func<object?, MethodInfo, object?[]?, Task<object?>>? AsyncKeyedResolver { get; set; }
        private object? Key { get; set; }
        private bool Keyed { get; set; }
        private Task<object?> CallAsync(MethodInfo methodInfo, object?[]? args)
        {
            if (AsyncKeyedResolver != null) return AsyncKeyedResolver(Key, methodInfo, args);
            if (AsyncResolver != null) return AsyncResolver(methodInfo, args);
            throw new NullReferenceException("No valid async call resolver found");
        }
        private object? Call(MethodInfo methodInfo, object?[]? args)
        {
            if (KeyedResolver != null) return KeyedResolver(Key, methodInfo, args);
            if (Resolver != null) return Resolver(methodInfo, args);
            throw new NullReferenceException("No valid call resolver found");
        }
        /// <summary>
        /// Handles all requests on interface TServiceInterface
        /// </summary>
        /// <param name="targetMethod"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
        {
            if (targetMethod == null) return null;
            var returnType = targetMethod.ReturnType;
            var isTask = returnType.IsTask();
            var isValueTask = !isTask && returnType.IsValueTask();
            Type finalReturnType = isTask || isValueTask ? returnType.GetGenericArguments().FirstOrDefault() ?? typeof(void) : returnType;
            if (isTask) return CallAsync(targetMethod, args).RecastTask(finalReturnType);
            if (isValueTask) return CallAsync(targetMethod, args).RecastValueTask(finalReturnType);
            return Call(targetMethod, args);
        }
        /// <summary>
        /// Creates a new AsyncInterfaceCallDispatcher returned as type TServiceInterface
        /// </summary>
        /// <param name="key"></param>
        /// <param name="keyedResolver"></param>
        /// <param name="asyncKeyedResolver"></param>
        /// <returns></returns>
        public static TServiceInterface CreateInterfaceDispatcher(object? key, Func<object?, MethodInfo, object?[]?, Task<object?>> keyedResolver, Func<object?, MethodInfo, object?[]?, Task<object?>>? asyncKeyedResolver = null)
        {
            var ret = Create<TServiceInterface, InterfaceCallDispatcher<TServiceInterface>>();
            var proxy = ret as InterfaceCallDispatcher<TServiceInterface>;
            proxy!.KeyedResolver = keyedResolver;
            proxy!.AsyncKeyedResolver = asyncKeyedResolver;
            proxy.Key = key;
            proxy.Keyed = true;
            return ret;
        }
        /// <summary>
        /// Creates a new AsyncInterfaceCallDispatcher returned as type TServiceInterface
        /// </summary>
        /// <param name="key"></param>
        /// <param name="asyncKeyedResolver"></param>
        /// <returns></returns>
        public static TServiceInterface CreateInterfaceDispatcher(object? key, Func<object?, MethodInfo, object?[]?, Task<object?>> asyncKeyedResolver)
        {
            var ret = Create<TServiceInterface, InterfaceCallDispatcher<TServiceInterface>>();
            var proxy = ret as InterfaceCallDispatcher<TServiceInterface>;
            proxy!.AsyncKeyedResolver = asyncKeyedResolver;
            proxy.Key = key;
            proxy.Keyed = true;
            return ret;
        }
        /// <summary>
        /// Creates a new AsyncInterfaceCallDispatcher returned as type TServiceInterface
        /// </summary>
        /// <param name="asyncResolver"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static TServiceInterface CreateInterfaceDispatcher(Func<MethodInfo, object?[]?, Task<object?>> asyncResolver)
        {
            var ret = Create<TServiceInterface, InterfaceCallDispatcher<TServiceInterface>>();
            var proxy = ret as InterfaceCallDispatcher<TServiceInterface>;
            proxy!.AsyncResolver = asyncResolver;
            return ret;
        }
        /// <summary>
        /// Creates a new AsyncInterfaceCallDispatcher returned as type TServiceInterface
        /// </summary>
        /// <param name="resolver"></param>
        /// <param name="asyncResolver"></param>
        /// <returns></returns>
        public static TServiceInterface CreateInterfaceDispatcher(Func<MethodInfo, object?[]?, object?> resolver, Func<MethodInfo, object?[]?, Task<object?>>? asyncResolver = null)
        {
            var ret = Create<TServiceInterface, InterfaceCallDispatcher<TServiceInterface>>();
            var proxy = ret as InterfaceCallDispatcher<TServiceInterface>;
            proxy!.AsyncResolver = asyncResolver;
            proxy.Resolver = resolver;
            return ret;
        }
    }
}
