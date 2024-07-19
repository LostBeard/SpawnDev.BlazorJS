using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public class FuncConverterFactory : JsonConverterFactory
    {
        static Dictionary<Type, Type> SupportedGenericTypes = new Dictionary<Type, Type> {
            { typeof(Func<>), typeof(FuncConverter<>) },
            { typeof(Func<,>), typeof(FuncConverter<,>) },
            { typeof(Func<,,>), typeof(FuncConverter<,,>) },
            { typeof(Func<,,,>), typeof(FuncConverter<,,,>) },
            { typeof(Func<,,,,>), typeof(FuncConverter<,,,,>) },
            { typeof(Func<,,,,,>), typeof(FuncConverter<,,,,,>) },
            { typeof(Func<,,,,,,>), typeof(FuncConverter<,,,,,,>) },
            { typeof(Func<,,,,,,,>), typeof(FuncConverter<,,,,,,,>) },
        };
        public override bool CanConvert(Type type)
        {
            var baseType = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
            return SupportedGenericTypes.ContainsKey(baseType);
        }
        public override JsonConverter? CreateConverter(Type type, JsonSerializerOptions options)
        {
            var baseType = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
            var genericTypes = type.GetGenericArguments();

            var returnType = genericTypes.Last();
            if (returnType.IsTask())
            {
                if (returnType.AsyncReturnType() == typeof(void))
                {
                    // Async Action (Func that returns Task with no value)
                    var nmt = true;
                }
                else
                {
                    // Async Func
                    var nmt = true;

                }
            }
            else
            {
                // Func
                var nmt = true;

            }
            if (SupportedGenericTypes.TryGetValue(baseType, out var converterBaseType))
            {
                var converterType = type.IsGenericType ? converterBaseType.MakeGenericType(genericTypes) : converterBaseType;
                JsonConverter converter = (JsonConverter)Activator.CreateInstance(converterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { }, culture: null)!;
                return converter;
            }
            return null;
        }
    }

    // ***********************************************************

    //public class AsyncActionConverter<T0> : JSInProcessObjectReferenceConverterBase<Func<T0, Task>>
    //{
    //    public override Func<T0, Task>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
    //    {
    //        if (_ref == null) return null;
    //        var fn = new Function(_ref);
    //        var ret = fn.ToFunc<T0, Task>();
    //        return ret;
    //    }
    //    public override void Write(Utf8JsonWriter writer, Func<T0, Task> value, JsonSerializerOptions options)
    //    {
    //        var ret = value.CallbackGet(true);
    //        JsonSerializer.Serialize(writer, ret, options);
    //    }
    //}

    // ***********************************************************

    //public class AsyncFuncConverter<TResult> : JSInProcessObjectReferenceConverterBase<Func<Task<TResult>>>
    //{
    //    public override Func<Task<TResult>>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
    //    {
    //        if (_ref == null) return null;
    //        var fn = new Function(_ref);
    //        var ret = fn.ToFunc<Task<TResult>>();
    //        return ret;
    //    }
    //    public override void Write(Utf8JsonWriter writer, Func<Task<TResult>> value, JsonSerializerOptions options)
    //    {
    //        var ret = value.CallbackGet(true);
    //        JsonSerializer.Serialize(writer, ret, options);
    //    }
    //}
    //public class AsyncFuncConverter<T0, TResult> : JSInProcessObjectReferenceConverterBase<Func<T0, Task<TResult>>>
    //{
    //    public override Func<T0, Task<TResult>>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
    //    {
    //        if (_ref == null) return null;
    //        var fn = new Function(_ref);
    //        var ret = fn.ToFunc<T0, Task<TResult>>();
    //        return ret;
    //    }
    //    public override void Write(Utf8JsonWriter writer, Func<T0, Task<TResult>> value, JsonSerializerOptions options)
    //    {
    //        var ret = value.CallbackGet(true);
    //        JsonSerializer.Serialize(writer, ret, options);
    //    }
    //}
}
