using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS {
    public class DispatchProxyExtensions {
        //static Dictionary<Type, MethodInfo?> CreateCache = new Dictionary<Type, MethodInfo?>();
        //static MethodInfo? _CreateInfo = null;
        //static MethodInfo? GetCreateGeneric(Type type) {
        //    if (CreateCache.TryGetValue(type, out var methodInfo)) return methodInfo;
        //    if (_CreateInfo == null) {
        //        var infos = typeof(DispatchProxy).GetMethods().Where(o => o.Name == "Create" && o.GetParameters().Length == 0 && o.IsGenericMethod).FirstOrDefault();
        //        _CreateInfo = infos.FirstOrDefault();
        //    }
        //    var methodInfoTyped = _CreateInfo.MakeGenericMethod(type);
        //    CreateCache[type] = methodInfoTyped;
        //    return methodInfoTyped;
        //}
        //public static object Create(Type interfaceType, Type proxyType) {
        //    var createTyped = typeof(DispatchProxy).GetMethods().Where(o => o.Name == "Create" && o.GetParameters().Length == 0 && o.IsGenericMethod).FirstOrDefault();
        //    return createTyped.Invoke();
        //}
    }
}
