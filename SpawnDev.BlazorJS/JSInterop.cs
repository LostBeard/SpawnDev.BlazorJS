using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS
{
    public static partial class JS
    {

        public class TestClassInner
        {
            public Window[]? Windows { get; set; }
            public Window? Window { get; set; }
            public byte[] Data { get; set; } = new byte[] { 2, 4, 6, 8 };
        }
        public class TestClass
        {
            public TestClassInner Wow { get; set; } = new TestClassInner();
        }

        public static void _JSInteropCallVoid(string fn, params object?[] args)
        {
            AssertInit();
            try
            {
                _js.InvokeVoid($"JSInterop.{fn}", args);
            }
            catch (Exception ex)
            {
                var art = true;
            }
        }

        public class TypeConversionInfo
        {
            public Type ReturnType { get; private set; }
            public bool usePropertyReader { get; private set; }
            public bool useJSObjectReader { get; private set; }
            public bool useIterationReader { get; private set; }
            public bool useDefaultReader { get; private set; }
            public Type? ElementType { get; set; } = null;
            public PropertyInfo[] returnTypeProperties { get; private set; } = new PropertyInfo[0];
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
                    useJSObjectReader = true;
                    return;
                }
                else if (returnType.IsClass && !typeof(Delegate).IsAssignableFrom(returnType))
                {

                    // class
                    // check if the class types requires per property import
                    returnTypeProperties = returnType.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where((o) => {
                        // Some properties should be ignored when considering conversion type
                        return !Attribute.IsDefined(o, typeof(JsonIgnoreAttribute));
                    }).ToArray();
                    foreach (var prop in returnTypeProperties)
                    {
                        var propertyTypeConversionInfo = GetTypeConversionInfo(prop.PropertyType);
                        if (!propertyTypeConversionInfo.useDefaultReader || typeof(IJSInProcessObjectReference).IsAssignableFrom(prop.PropertyType))
                        {
                            usePropertyReader = true;
                            return;
                        }
                    }
                }
                useDefaultReader = true;
            }
            public object? FinishImport(IJSInProcessObjectReference? _ref)
            {
                object? ret = null;
                if (_ref == null) return null;
                if (usePropertyReader)
                {
                    var tmpRet = Activator.CreateInstance(ReturnType);
                    foreach (var prop in returnTypeProperties)
                    {
                        // some properties need to be skipped

                        var propName = prop.Name.Substring(0, 1).ToLowerInvariant() + prop.Name.Substring(1);
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
