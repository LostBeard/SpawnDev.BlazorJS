using Microsoft.JSInterop;
using Microsoft.JSInterop.Implementation;
using SpawnDev.BlazorJS.JsonConverters;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS {
    public interface IWindow {
        string Name { get; set; }
        void Alert(string msg);
    }

    public class IJSObject : DispatchProxy {
        public IJSInProcessObjectReference JSRef { get; private set; }
        public Type InterfaceType { get; private set; }

#if NET8_0_OR_GREATER && false
        public static object GetInterface([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type interfaceType, IJSInProcessObjectReference _ref) {
            if (!interfaceType.IsInterface) throw new Exception("GetInterface must be called with an interface");
            var proxyType = typeof(IJSObject);
            var proxy = DispatchProxy.Create(interfaceType, proxyType) as IJSObject;
            proxy.JSRef = _ref;
            return proxy;
        }
#else
        static Dictionary<Type, MethodInfo?> GetInterfaceCache = new Dictionary<Type, MethodInfo?>();
        static MethodInfo? _GetInterfaceInfo = null;
        static MethodInfo? GetGetInterfaceGeneric(Type type) {
            if (GetInterfaceCache.TryGetValue(type, out var methodInfo)) return methodInfo;
            if (_GetInterfaceInfo == null) {
                var thenASyncParamTypes = new Type[] { typeof(IJSInProcessObjectReference) };
                var infos = typeof(IJSObject).GetMethods().Where(o => {
                    if (o.Name != "GetInterface") return false;
                    if (!o.IsGenericMethod) return false;
                    var paramInfos = o.GetParameters();
                    var paramTypes = paramInfos.Select(o => o.ParameterType).ToList();
                    if (!paramTypes.SequenceEqual(thenASyncParamTypes)) return false;
                    return true;
                }).ToList();
                _GetInterfaceInfo = infos.FirstOrDefault();
            }
            var methodInfoTyped = _GetInterfaceInfo.MakeGenericMethod(type);
            GetInterfaceCache[type] = methodInfoTyped;
            return methodInfoTyped;
        }

        public static object GetInterface(Type interfaceType, IJSInProcessObjectReference _ref) {
            var mi = GetGetInterfaceGeneric(interfaceType);
            var ret = mi.Invoke(null, new object[] { _ref });
            return ret;
        }
#endif

        public static TServiceInterface GetInterface<TServiceInterface>(IJSInProcessObjectReference _ref) where TServiceInterface : class {
            var typeofT = typeof(TServiceInterface);
            if (!typeofT.IsInterface) throw new Exception("GetInterface must be called with an interface");
            var proxy = Create<TServiceInterface, IJSObject>() as IJSObject;
            proxy.JSRef = _ref;
            proxy.InterfaceType = typeofT;
            return proxy as TServiceInterface;
        }

        string GetTargetMethodName(MethodInfo? targetMethod) {
            if (targetMethod == null) throw new ArgumentNullException(nameof(targetMethod));
            var name = targetMethod.Name;
            if (!string.IsNullOrEmpty(name)) {
                name = name.Substring(0, 1).ToLowerInvariant() + name.Substring(1);
            }
            // todo support JSName attribute
            return name;
        }

        string GetTargetPropertyName(MethodInfo? targetMethod) {
            if (targetMethod == null) throw new ArgumentNullException(nameof(targetMethod));
            var methodName = targetMethod.Name;
            var name = methodName.Substring(4);
            if (!string.IsNullOrEmpty(name)) {
                name = name.Substring(0, 1).ToLowerInvariant() + name.Substring(1);
            }
            // todo support JSName attribute
            return name;
        }

        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args) {
            object? ret = null;
            if (JSRef == null) throw new Exception("IJSObject.Invoke exception: reference has been disposed.");
            if (targetMethod == null) return ret;
            var methodName = targetMethod.Name;
            var returnType = targetMethod.ReturnType;
            var argsCount = args == null ? 0 : args.Length;
            Console.WriteLine($"IJSObject.Invoke({methodName}, args[{argsCount}])");
            try {
                if (targetMethod.IsSpecialName) {
                    if (methodName.StartsWith("get_")) {
                        var propName = GetTargetPropertyName(targetMethod);
                        ret = JSRef.Get(returnType, propName);
                    }
                    else if (methodName.StartsWith("set_")) {
                        var propName = GetTargetPropertyName(targetMethod);
                        JSRef.Set(propName, args[0]);
                    }
                    else {
                        var nmt = true;
                    }
                }
                else {
                    var mName = GetTargetMethodName(targetMethod);
                    if (returnType == typeof(void)) {
                        JSRef.CallApplyVoid(mName, args);
                    }
                    else {
                        ret = JSRef.CallApply(returnType, mName, args);
                    }
                }
            }
            catch (Exception ex) {
                var ttt = true;
            }
            return ret;
        }

        ~IJSObject() {
            Console.WriteLine("~IJSObject");
            JSRef?.Dispose();
            JSRef = null;
        }
    }
}
