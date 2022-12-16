using Microsoft.JSInterop;
using System.Reflection;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    public static partial class JS
    {
        public static void _JSInteropCallVoid(string fn, params object?[] args)
        {
            AssertInit();
            _js.InvokeVoid($"JSInterop.{fn}", args);
        }

        public class TypeConversionInfo
        {
            public Type ReturnType { get; private set; }
            public bool usePropertyReader { get; private set; }
            public bool useJSObjectReader { get; private set; }
            public bool useIterationReader { get; private set; }
            public bool useDefaultReader { get; private set; }
            public Type? ElementType { get; set; } = null;
            public PropertyInfo[] ClassProperties { get; set; } = new PropertyInfo[0];
            public Dictionary<string, PropertyInfo> returnTypeProperties { get; private set; } = new Dictionary<string, PropertyInfo>();
            public List<string> TransferableProperties = new List<string>();
            public bool IsTransferable { get; private set; }

            static string GetPropertyJSName(PropertyInfo prop)
            {
                // todo - json name attribute
                var propName = prop.Name.Substring(0, 1).ToLowerInvariant() + prop.Name.Substring(1);
                return propName;
            }
            public TypeConversionInfo(Type returnType)
            {
                if (returnType == null) throw new Exception("Invalid Return Type");
                ReturnType = returnType;
                if (returnType.IsValueType || returnType == typeof(string))
                {
                    useDefaultReader = true;
                    return;
                }
                else if (returnType.IsArray && returnType.HasElementType)
                {
                    // array
                    // check if the element type requires per element import
                    ElementType = returnType.GetElementType();
                    var elementTypeConversionInfo = GetTypeConversionInfo(ElementType);
                    useIterationReader = !elementTypeConversionInfo.useDefaultReader || typeof(IJSInProcessObjectReference).IsAssignableFrom(ElementType);
                    if (useIterationReader) return;
                }
                else if (typeof(JSObject).IsAssignableFrom(returnType))
                {
                    IsTransferable = JSObject.TransferableTypes.Contains(returnType);
                    useJSObjectReader = true;
                    return;
                }
                else if (returnType.IsClass && !typeof(Delegate).IsAssignableFrom(returnType))
                {
                    // class
                    // check if the class types requires per property import
                    ClassProperties = returnType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    foreach (var prop in ClassProperties)
                    {
                        if (Attribute.IsDefined(prop, typeof(JsonIgnoreAttribute))) continue;
                        var propJSName = GetPropertyJSName(prop);
                        returnTypeProperties[propJSName] = prop;
                        var propertyTypeConversionInfo = GetTypeConversionInfo(prop.PropertyType);
                        if (!propertyTypeConversionInfo.useDefaultReader || typeof(IJSInProcessObjectReference).IsAssignableFrom(prop.PropertyType))
                        {
                            usePropertyReader = true;
                        }
                        if (JSObject.TransferableTypes.Contains(prop.PropertyType))
                        {
                            // can be transferred
                            if (!TransferableProperties.Contains(propJSName))
                            {
                                TransferableProperties.Add(propJSName);
                            }
                        }
                    }
                    if (usePropertyReader) return;
                }
                useDefaultReader = true;
            }
            public object[] GetTransferablePropertyValues(object? obj)
            {
                var ret = new List<object>();
                if (obj != null)
                {
                    if (IsTransferable)
                    {
                        ret.Add(obj);
                    }
                    else
                    {
                        foreach(var kvp in returnTypeProperties)
                        {
                            var prop = kvp.Value;
                            if (!prop.PropertyType.IsClass) continue;
                            var transferAttr = (WorkerTransferAttribute?)prop.GetCustomAttribute(typeof(WorkerTransferAttribute), false);
                            if (transferAttr != null && !transferAttr.Transfer)
                            {
                                // this property has been marked as non-stransferable
                                continue;
                            }
                            if (Attribute.IsDefined(prop, typeof(JsonIgnoreAttribute))) continue;
                            var propVal = prop.GetValue(obj);
                            if (propVal == null) continue;
                            var conversionInfo = GetTypeConversionInfo(prop.PropertyType);
                            var tmpp = conversionInfo.GetTransferablePropertyValues(propVal);
                            ret.AddRange(tmpp);
                        }
                    }
                }
                return ret.ToArray();
            }
            public object? FinishImport(IJSInProcessObjectReference? _ref)
            {
                object? ret = null;
                if (_ref == null) return null;
                if (usePropertyReader)
                {
                    var tmpRet = Activator.CreateInstance(ReturnType);
                    foreach (var kvp in returnTypeProperties)
                    {
                        var propName = kvp.Key;
                        var prop = kvp.Value;
                        var value = _ref.Get(prop.PropertyType, propName);
                        prop.SetValue(tmpRet, value);
                    }
                    ret = tmpRet;
                    _ref.Dispose();
                }
                else if (useIterationReader)
                {
                    var length = _ref.Get<int>("length");
                    var tmpRet = Array.CreateInstance(ElementType, length);
                    for (var i = 0; i < length; i++)
                    {
                        var value = _ref.Get(ElementType, i);
                        tmpRet.SetValue(value, i);
                    }
                    ret = (object)tmpRet;
                    _ref.Dispose();
                }
                else if (useJSObjectReader)
                {
                    if (_ref != null)
                        ret = Activator.CreateInstance(ReturnType, _ref);
                }
                return ret;
            }
        }

        static Dictionary<Type, TypeConversionInfo> _conversionInfo = new Dictionary<Type, TypeConversionInfo>();
        public static TypeConversionInfo GetTypeConversionInfo(Type type)
        {
            if (_conversionInfo.TryGetValue(type, out TypeConversionInfo conversionInfo)) return conversionInfo;
            conversionInfo = new TypeConversionInfo(type);
            _conversionInfo[type] = conversionInfo;
            return conversionInfo;
        }
        static TypeConversionInfo GetTypeConversionInfo<T>() => GetTypeConversionInfo(typeof(T));

        internal static T? _JSInteropCall<T>(string fn, params object?[] args)
        {
            AssertInit();
            T? ret = default;
            var returnType = typeof(T);
            var conversionInfo = GetTypeConversionInfo(returnType);
            if (!conversionInfo.useDefaultReader)
            {
                var _ref = _js.Invoke<IJSInProcessObjectReference?>($"JSInterop.{fn}", args);
                ret = (T?)conversionInfo.FinishImport(_ref);
            }
            else
            {
                ret = _js.Invoke<T>($"JSInterop.{fn}", args);
            }
            return ret;
        }
        public static object? _JSInteropCall(Type returnType, string fn, params object?[] args)
        {
            AssertInit();
            object? ret = null;
            var conversionInfo = GetTypeConversionInfo(returnType);
            if (!conversionInfo.useDefaultReader)
            {
                var _ref = _js.Invoke<IJSInProcessObjectReference?>($"JSInterop.{fn}", args);
                ret = conversionInfo.FinishImport(_ref);
            }
            else
            {
                ret = _js.Invoke(returnType, $"JSInterop.{fn}", args);
            }
            return ret;
        }
        public static async ValueTask _JSInteropCallVoidAsync(string fn, params object?[] args)
        {
            AssertInit();
            await _js.InvokeVoidAsync($"JSInterop.{fn}", args);
        }
        public static async ValueTask<T?> _JSInteropCallAsync<T>(string fn, params object?[] args)
        {
            AssertInit();
            T? ret = default;
            var returnType = typeof(T);
            var conversionInfo = GetTypeConversionInfo(returnType);
            if (!conversionInfo.useDefaultReader)
            {
                var _ref = await _js.InvokeAsync<IJSInProcessObjectReference?>($"JSInterop.{fn}", args);
                ret = (T?)conversionInfo.FinishImport(_ref);
            }
            else
            {
                ret = await _js.InvokeAsync<T>($"JSInterop.{fn}", args);
            }
            return ret;
        }
        public static async ValueTask<object?> _JSInteropCallAsync(Type returnType, string fn, params object?[] args)
        {
            AssertInit();
            object? ret = null;
            var conversionInfo = GetTypeConversionInfo(returnType);
            if (!conversionInfo.useDefaultReader)
            {
                var _ref = await _js.InvokeAsync<IJSInProcessObjectReference?>($"JSInterop.{fn}", args);
                ret = conversionInfo.FinishImport(_ref);
            }
            else
            {
                ret = await _js.InvokeAsync(returnType, $"JSInterop.{fn}", args);
            }
            return ret;
        }
    }
}
