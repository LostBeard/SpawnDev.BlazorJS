using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JsonConverters;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS {
    public static partial class JS {
        public class TypeConversionInfo {
            public Type ReturnType { get; private set; }
            public bool useIJSWrapperReader { get; private set; }
            public bool usePropertyReader { get; private set; }
            public bool useJSObjectReader { get; private set; }
            public bool useIterationReader { get; private set; }
            public bool useDictionaryReader { get; private set; }
            public bool useInterfaceProxy { get; private set; }
            public bool useTaskReader { get; private set; }
            public bool isDispatchProxy { get; private set; }
            public bool isIJSObject { get; private set; }
            public bool useDefaultReader { get; private set; }
            public Type? ElementType { get; set; } = null;
            public Type? DictionaryKeyType { get; set; } = null;
            public Type? DictionaryValueType { get; set; } = null;
            public PropertyInfo[] ClassProperties { get; set; } = new PropertyInfo[0];
            public Dictionary<string, PropertyInfo> returnTypeProperties { get; private set; } = new Dictionary<string, PropertyInfo>();
            //public List<string> TransferableProperties = new List<string>();
            public bool IsTransferable { get; private set; }

            bool HasIJSInProcessObjectReferenceConstructor() {
                ConstructorInfo[] constructors;
                try {
                    constructors = ReturnType.GetConstructors();
                }
                catch {
                    return false;
                }
                foreach (var c in constructors) {
                    if (c.IsPrivate) continue;
                    var args = c.GetParameters();
                    if (args.Length != 1) continue;
                    if (args[0].ParameterType == typeof(IJSInProcessObjectReference)) return true;
                }
                return false;
            }

            static List<Type> IgnoreInterfaces = new List<Type> {
                typeof(IJSInProcessObjectReference),
                typeof(IJSObjectReference),
                typeof(IJSStreamReference),
            };

            static string GetPropertyJSName(PropertyInfo prop) {
                // TODO - json name attribute
                string propName = prop.Name;
                try {
                    propName = string.IsNullOrEmpty(propName) ? "" : propName.Substring(0, 1).ToLowerInvariant() + propName.Substring(1);
                }
                catch (Exception ex) {
                    var nmt = true;
                }
                return propName;
            }
            public TypeConversionInfo(Type returnType) {
#if DEBUG && false
                Console.WriteLine($"TypeConversionInfo loading: {returnType.Name}");
#endif
                if (returnType == null) throw new Exception("Invalid Return Type");
                ReturnType = returnType;
                if (returnType.IsValueType || returnType == typeof(string)) {
                    useDefaultReader = true;
                    return;
                }
                else if (returnType.IsInterface && !IgnoreInterfaces.Contains(returnType)) {
                    IsTransferable = false;
                    useJSObjectReader = false;
                    useDefaultReader = false;
                    useInterfaceProxy = true;
                    return;
                }
                else if (typeof(Callback).IsAssignableFrom(returnType)) {
                    useDefaultReader = true;
                    return;
                }
                else if (typeof(DotNetObjectReference).IsAssignableFrom(returnType)) {
                    useDefaultReader = true;
                    return;
                }
                else if (returnType.IsArray && returnType.HasElementType) {
                    // array
                    // check if the element type requires per element import
                    ElementType = returnType.GetElementType();
                    if (ElementType != null) {
                        var elementTypeConversionInfo = GetTypeConversionInfo(ElementType);
                        useIterationReader = !elementTypeConversionInfo.useDefaultReader || typeof(IJSInProcessObjectReference).IsAssignableFrom(ElementType);
                        if (useIterationReader) return;
                    }
                }
                else if (typeof(System.Collections.IDictionary).IsAssignableFrom(returnType)) {
                    Type[] arguments = returnType.GetGenericArguments();
                    if (arguments.Length == 2) {
                        DictionaryKeyType = arguments[0];
                        DictionaryValueType = arguments[1];
                        var keyTypeConversionInfo = GetTypeConversionInfo(DictionaryKeyType);
                        useDictionaryReader = !keyTypeConversionInfo.useDefaultReader || typeof(IJSInProcessObjectReference).IsAssignableFrom(DictionaryKeyType);
                        var valueTypeConversionInfo = GetTypeConversionInfo(DictionaryValueType);
                        useDictionaryReader = !valueTypeConversionInfo.useDefaultReader || typeof(IJSInProcessObjectReference).IsAssignableFrom(DictionaryValueType);
                        if (useDictionaryReader) return;
                    }
                }
                else if (typeof(IJSObject).IsAssignableFrom(returnType)) {
                    IsTransferable = false;
                    useJSObjectReader = false;
                    useDefaultReader = false;
                    isIJSObject = true;
                    return;
                }
                else if (typeof(DispatchProxy).IsAssignableFrom(returnType)) {
                    IsTransferable = false;
                    useJSObjectReader = false;
                    useDefaultReader = true;
                    isDispatchProxy = true;
                    return;
                }
                else if (typeof(Delegate).IsAssignableFrom(returnType)) {
                    // this type will likely fail, but is a class... so drop it here
                }
                else if (returnType.IsClass) {
                    if (typeof(JSObject).IsAssignableFrom(returnType)) {
                        IsTransferable = JSObject.TransferableTypes.Contains(returnType);
                        useJSObjectReader = true;
                        if (!IsTransferable) {
                            ClassProperties = returnType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                            foreach (var prop in ClassProperties) {
                                if (Attribute.IsDefined(prop, typeof(JsonIgnoreAttribute))) continue;
                                var propJSName = GetPropertyJSName(prop);
                                returnTypeProperties[propJSName] = prop;
                            }
                        }
                        return;
                    }
                    else if (returnType.IsTask()) {
                        IsTransferable = false;
                        useJSObjectReader = false;
                        useDefaultReader = false;
                        useTaskReader = true;
                        return;
                    }
                    else if (HasIJSInProcessObjectReferenceConstructor()) {
                        IsTransferable = false; // no way to tell from this conversion. this is a generic wrapper for IJSInProcessObjectRefrence
                        useIJSWrapperReader = true;
                        return;
                    }
                    else {
                        // class
                        // check if the class types requires per property import
                        ClassProperties = returnType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                        foreach (var prop in ClassProperties) {
                            if (Attribute.IsDefined(prop, typeof(JsonIgnoreAttribute))) continue;
                            var propJSName = GetPropertyJSName(prop);
                            returnTypeProperties[propJSName] = prop;
                            var propertyTypeConversionInfo = GetTypeConversionInfo(prop.PropertyType);
                            if (!propertyTypeConversionInfo.useDefaultReader || typeof(IJSInProcessObjectReference).IsAssignableFrom(prop.PropertyType)) {
                                usePropertyReader = true;
                            }
                        }
                        if (usePropertyReader) return;
                    }
                }
                useDefaultReader = true;
            }
            public object? PreExport(object? obj) {
                object? ret = obj;
                if (obj == null || ReturnType == null) return ret;
                if (useDefaultReader) return ret;
                if (ReturnType.IsTask()) {
                    var taskReturnType = ReturnType.AsyncReturnType();
                    if (taskReturnType == typeof(void)) {
                        ret = new Promise((Task)ret);
                    }
                    else {
                        ret = Promise.CreateTypedInstance(taskReturnType, ret);
                    }
                }
                else if (isIJSObject) {
                    var tmp = obj as IJSObject;
                    ret = tmp.JSRef;
                }
                return ret;
            }
            public object[] GetTransferablePropertyValues(object? obj) {
                var ret = new List<object>();
                if (obj != null) {
                    if (IsTransferable) {
                        ret.Add(obj);
                    }
                    else if (usePropertyReader) {
                        foreach (var kvp in returnTypeProperties) {
                            var prop = kvp.Value;
                            if (prop.PropertyType.IsValueType || prop.PropertyType == typeof(string)) {
                                continue;
                            }
                            if (!prop.PropertyType.IsClass) continue;
                            if (typeof(IJSInProcessObjectReference) == prop.PropertyType) continue;
                            var transferAttr = (WorkerTransferAttribute?)prop.GetCustomAttribute(typeof(WorkerTransferAttribute), false);
                            if (transferAttr != null && !transferAttr.Transfer) {
                                // this property has been marked as non-stransferable
                                continue;
                            }
                            object? propVal = null;
                            try {
                                propVal = prop.GetValue(obj);
                            }
                            catch { }
                            if (propVal == null) continue;
                            var conversionInfo = GetTypeConversionInfo(prop.PropertyType);
                            var tmpp = conversionInfo.GetTransferablePropertyValues(propVal);
                            ret.AddRange(tmpp);
                        }
                    }
                    else if (useJSObjectReader) {
                        foreach (var kvp in returnTypeProperties) {
                            var prop = kvp.Value;
                            if (prop.PropertyType.IsValueType || prop.PropertyType == typeof(string)) {
                                continue;
                            }
                            if (!prop.PropertyType.IsClass) continue;
                            if (typeof(IJSInProcessObjectReference) == prop.PropertyType) continue;
                            var transferAttr = (WorkerTransferAttribute?)prop.GetCustomAttribute(typeof(WorkerTransferAttribute), false);
                            if (transferAttr != null && !transferAttr.Transfer) {
                                // this property has been marked as non-stransferable
                                continue;
                            }
                            object? propVal = null;
                            try {
                                propVal = prop.GetValue(obj);
                            }
                            catch (Exception ex) {
                                var nmt = ex.Message;
                            }
                            if (propVal == null) continue;
                            var conversionInfo = GetTypeConversionInfo(prop.PropertyType);
                            var tmpp = conversionInfo.GetTransferablePropertyValues(propVal);
                            ret.AddRange(tmpp);
                        }
                    }
                    else if (useIterationReader && ElementType != null && obj is IEnumerable enumarable) {
                        var conversionInfo = GetTypeConversionInfo(ElementType);
                        foreach (var ival in enumarable) {
                            if (ival == null) continue;
                            var tmpp = conversionInfo.GetTransferablePropertyValues(ival);
                            ret.AddRange(tmpp);
                        }
                    }
                    else if (useDictionaryReader) {
                        if (DictionaryKeyType != null && DictionaryValueType != null) {
                            var keyTypeConversionInfo = GetTypeConversionInfo(DictionaryKeyType);
                            var valueTypeConversionInfo = GetTypeConversionInfo(DictionaryValueType);
                            if (obj is System.Collections.IDictionary dict) {
                                foreach (var key in dict.Keys) {
                                    var value = dict[key];
                                    if (key != null) {
                                        var tmpp = keyTypeConversionInfo.GetTransferablePropertyValues(key);
                                        ret.AddRange(tmpp);
                                    }
                                    if (value != null) {
                                        var tmpp = valueTypeConversionInfo.GetTransferablePropertyValues(value);
                                        ret.AddRange(tmpp);
                                    }
                                }
                            }
                        }
                    }
                    else if (useInterfaceProxy) {
                        // TODO
                        var nmt = true;
                    }
                }
                return ret.ToArray();
            }
            public object? FinishImport(IJSInProcessObjectReference? _ref) {
                object? ret = null;
                if (_ref == null || ReturnType == null) return null;
                if (usePropertyReader) {
                    var tmpRet = Activator.CreateInstance(ReturnType);
                    foreach (var kvp in returnTypeProperties) {
                        var propName = kvp.Key;
                        var prop = kvp.Value;
                        object? value;
                        try {
                            value = _ref.Get(prop.PropertyType, propName);
                        }
                        catch {
                            // Could not read property. Skipping
                            continue;
                        }
                        if (value == null) continue;
                        prop.SetValue(tmpRet, value);
                    }
                    ret = tmpRet;
                    _ref.Dispose();
                    _ref = null;
                }
                else if (useIterationReader) {
                    if (ElementType != null) {
                        var length = _ref.Get<int>("length");
                        var tmpRet = Array.CreateInstance(ElementType, length);
                        for (var i = 0; i < length; i++) {
                            object? value;
                            try {
                                value = _ref.Get(ElementType, i);
                            }
                            catch {
                                // Could not read property. Skipping
                                continue;
                            }
                            if (value == null) continue;
                            tmpRet.SetValue(value, i);
                        }
                        ret = (object)tmpRet;
                        _ref.Dispose();
                        _ref = null;
                    }
                }
                else if (useDictionaryReader) {
                    if (DictionaryKeyType != null && DictionaryValueType != null) {
                        var tmpRet = Activator.CreateInstance(ReturnType) as System.Collections.IDictionary;
                        if (tmpRet != null) {
                            using var keysArray = JS.Call<IJSInProcessObjectReference>("Object.keys", _ref);
                            if (keysArray != null) {
                                var length = keysArray.Get<int>("length");
                                if (length > 0) {
                                    using var valuesArray = JS.Call<IJSInProcessObjectReference>("Object.values", _ref);
                                    if (valuesArray != null) {
                                        for (var i = 0; i < length; i++) {
                                            object? key = null;
                                            object? value = null;
                                            try {
                                                key = keysArray.Get(DictionaryKeyType, i);
                                            }
                                            catch {
                                                // Could not read property. Skipping
                                                continue;
                                            }
                                            try {
                                                value = valuesArray.Get(DictionaryValueType, i);
                                            }
                                            catch { }
                                            tmpRet.Add(key, value);
                                        }
                                        ret = tmpRet;
                                        _ref.Dispose();
                                        _ref = null;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (useTaskReader) {
                    var taskReturnType = ReturnType.AsyncReturnType();
                    if (taskReturnType == typeof(void)) {
                        using var promise = new Promise(_ref);
                        ret = promise.ThenAsync();
                        _ref = null;    // ret now owns ret, prevent _ref's disposal.
                    }
                    else {
                        using var promise = new Promise(_ref);
                        ret = promise.ThenAsync(taskReturnType);
                        _ref = null;    // ret now owns ret, prevent _ref's disposal.
                    }
                }
                else if (useJSObjectReader) {
                    ret = Activator.CreateInstance(ReturnType, _ref);
                    _ref = null;    // ret now owns ret, prevent _ref's disposal.
                }
                else if (useIJSWrapperReader) {
                    ret = Activator.CreateInstance(ReturnType, _ref);
                    _ref = null;    // ret now owns ret, prevent _ref's disposal.
                }
                else if (useInterfaceProxy) {
                    ret = IJSObject.GetInterface(ReturnType, _ref);
                    _ref = null;    // ret now owns ret, prevent _ref's disposal.
                    var nmt = true;
                }
                // _ref must be contained in a JSObject that now owns the _ref and will dispose it later
                // OR
                // _ref must disposed before getting here
                // failure to dispose _ref (just like any IJSInProcessObjectReference) will cause a memory leak
                _ref?.Dispose();
                return ret;
            }

        }

        public static TypeConversionInfo? GetObjectTypeConversionInfo(object? obj) {
            if (obj == null) return null;
            return GetTypeConversionInfo(obj.GetType());
        }

        static Dictionary<Type, TypeConversionInfo> _conversionInfo = new Dictionary<Type, TypeConversionInfo>();
        public static TypeConversionInfo GetTypeConversionInfo(Type type) {
            if (_conversionInfo.TryGetValue(type, out TypeConversionInfo conversionInfo)) {
                return conversionInfo;
            }
            try {
                conversionInfo = new TypeConversionInfo(type);
            }
            catch (Exception ex) {
                var nmt = true;
            }
            _conversionInfo[type] = conversionInfo;
            return conversionInfo;
        }
        static TypeConversionInfo GetTypeConversionInfo<T>() => GetTypeConversionInfo(typeof(T));

        internal static T? _JSInteropCall<T>(string fn, params object?[] args) {
            T? ret = default;
            var returnType = typeof(T);
            var converter = RuntimeJsonSerializerOptions.GetConverter(returnType);
            if (converter.GetJSCallResultTypeOverride(out var jsReturnTypeOverride)) {
                fn = $"{(byte)jsReturnTypeOverride}JSInterop.{fn}";
            } else {
                fn = $"JSInterop.{fn}";
            }
            ret = _js.Invoke<T?>(fn, args);
            //var conversionInfo = GetTypeConversionInfo(returnType);
            //if (fn != "_call") args = PreExportArgs(args);
            //if (!conversionInfo.useDefaultReader) {
            //    var _ref = _js.Invoke<IJSInProcessObjectReference?>(fn, args);
            //    ret = (T?)conversionInfo.FinishImport(_ref);
            //}
            //else {
            //    ret = _js.Invoke<T?>(fn, args);
            //}
            return ret;
        }

        internal static object? _JSInteropCall(Type returnType, string fn, params object?[] args) {
            object? ret = null;
            var converter = RuntimeJsonSerializerOptions.GetConverter(returnType);
            if (converter.GetJSCallResultTypeOverride(out var jsReturnTypeOverride)) {
                fn = $"{(byte)jsReturnTypeOverride}JSInterop.{fn}";
            }
            else {
                fn = $"JSInterop.{fn}";
            }
            ret = _js.Invoke(returnType, fn, args);
            //var conversionInfo = GetTypeConversionInfo(returnType);
            //if (fn != "_call") args = PreExportArgs(args);
            //if (!conversionInfo.useDefaultReader) {
            //    var _ref = _js.Invoke<IJSInProcessObjectReference?>(fn, args);
            //    ret = conversionInfo.FinishImport(_ref);
            //}
            //else {
            //    ret = _js.Invoke(returnType, fn, args);
            //}
            return ret;
        }

        public static void _JSInteropCallVoid(string fn, params object?[] args) {
            if (fn != "_call") args = PreExportArgs(args);
            _js.InvokeVoid($"JSInterop.{fn}", args);
        }

        internal static async ValueTask _JSInteropCallVoidAsync(string fn, params object?[] args) {
            if (fn != "_call") args = PreExportArgs(args);
            await _js.InvokeVoidAsync($"JSInterop.{fn}", args);
        }
        internal static async ValueTask<T?> _JSInteropCallAsync<T>(string fn, params object?[] args) {
            T? ret = default;
            var returnType = typeof(T);
            var conversionInfo = GetTypeConversionInfo(returnType);
            if (fn != "_call") args = PreExportArgs(args);
            if (!conversionInfo.useDefaultReader) {
                var _ref = await _js.InvokeAsync<IJSInProcessObjectReference?>($"JSInterop.{fn}", args);
                ret = (T?)conversionInfo.FinishImport(_ref);
            }
            else {
                ret = await _js.InvokeAsync<T>($"JSInterop.{fn}", args);
            }
            return ret;
        }

        internal static object?[]? PreExportArgs(object?[]? args) => args == null ? null : args.Select(o => {
            var tci = GetObjectTypeConversionInfo(o);
            return tci == null ? o : tci.PreExport(o);
        }).ToArray();
        //internal static object?[]? PreExportArgs(object?[]? args) => args;

        public static async ValueTask<object?> _JSInteropCallAsync(Type returnType, string fn, params object?[] args) {
            object? ret = null;
            var conversionInfo = GetTypeConversionInfo(returnType);
            if (fn != "_call") args = PreExportArgs(args);
            if (!conversionInfo.useDefaultReader) {
                var _ref = await _js.InvokeAsync<IJSInProcessObjectReference?>($"JSInterop.{fn}", args);
                ret = conversionInfo.FinishImport(_ref);
            }
            else {
                ret = await _js.InvokeAsync(returnType, $"JSInterop.{fn}", args);
            }
            return ret;
        }



        internal static object? GetDynamic(Type? resultType, IJSInProcessObjectReference _ref, object identifier, object[] args) {
            object? result = null;
            if (identifier != "_call") args = PreExportArgs(args);
            if (resultType == null) {
                JS._JSInteropCallVoid("_getDynamic", _ref, identifier, args, "void", "void");
            }
            else {
                var finalReturnTypeName = resultType.Name;
                var isArray = resultType.IsArray;
                var isIJSObjectArray = false;
                Type? elementType = null;
                if (isArray) {
                    elementType = resultType.GetElementType();
                    isIJSObjectArray = elementType != null && typeof(JSObject).IsAssignableFrom(elementType);
                }
                var isIJSObject = resultType != null && typeof(JSObject).IsAssignableFrom(resultType);
                Type tmpType = isIJSObjectArray || isIJSObject ? typeof(IJSInProcessObjectReference) : resultType;
                var typeName = tmpType == null ? "void" : tmpType.Name;
                if (typeName == "Task") throw new Exception("TASK is not a valid return type!");
                result = JS._JSInteropCall(tmpType, "_getDynamic", new object[] { _ref, identifier, args, typeName, finalReturnTypeName });
            }
            return result;
        }
        internal static async Task<object?> GetDynamicAsync(Type? resultType, IJSInProcessObjectReference _ref, object identifier, object[] args) {
            object? result = null;
            if (identifier != "_call") args = PreExportArgs(args);
            if (resultType == null) {
                await JS._JSInteropCallVoidAsync("_getDynamic", _ref, identifier, args, "void", "void");
            }
            else {
                var finalReturnTypeName = resultType.Name;
                var isArray = resultType.IsArray;
                var isIJSObjectArray = false;
                Type? elementType = null;
                if (isArray) {
                    elementType = resultType.GetElementType();
                    isIJSObjectArray = elementType != null && typeof(JSObject).IsAssignableFrom(elementType);
                }
                var isIJSObject = resultType != null && typeof(JSObject).IsAssignableFrom(resultType);
                Type tmpType = isIJSObjectArray || isIJSObject ? typeof(IJSInProcessObjectReference) : resultType;
                var typeName = tmpType == null ? "void" : tmpType.Name;
                if (typeName == "Task") throw new Exception("TASK is not a valid return type!");
                result = await JS._JSInteropCallAsync(tmpType, "_getDynamic", new object[] { _ref, identifier, args, typeName, finalReturnTypeName });
            }
            return result;
        }
    }
}
