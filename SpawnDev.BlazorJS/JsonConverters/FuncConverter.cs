using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System.Text.Json;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public class FuncConverter<TResult> : JSInProcessObjectReferenceConverterBase<Func<TResult>>
    {
        public override Func<TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<TResult>();
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Func<TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    public class FuncConverter<T0, TResult> : JSInProcessObjectReferenceConverterBase<Func<T0, TResult>>
    {
        public override Func<T0, TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, TResult>();
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Func<T0, TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    public class FuncConverter<T0, T1, TResult> : JSInProcessObjectReferenceConverterBase<Func<T0, T1, TResult>>
    {
        public override Func<T0, T1, TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, T1, TResult>();
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Func<T0, T1, TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    public class FuncConverter<T0, T1, T2, TResult> : JSInProcessObjectReferenceConverterBase<Func<T0, T1, T2, TResult>>
    {
        public override Func<T0, T1, T2, TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, T1, T2, TResult>();
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Func<T0, T1, T2, TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    public class FuncConverter<T0, T1, T2, T3, TResult> : JSInProcessObjectReferenceConverterBase<Func<T0, T1, T2, T3, TResult>>
    {
        public override Func<T0, T1, T2, T3, TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, T1, T2, T3, TResult>();
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Func<T0, T1, T2, T3, TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    public class FuncConverter<T0, T1, T2, T3, T4, TResult> : JSInProcessObjectReferenceConverterBase<Func<T0, T1, T2, T3, T4, TResult>>
    {
        public override Func<T0, T1, T2, T3, T4, TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, T1, T2, T3, T4, TResult>();
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Func<T0, T1, T2, T3, T4, TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    public class FuncConverter<T0, T1, T2, T3, T4, T5, TResult> : JSInProcessObjectReferenceConverterBase<Func<T0, T1, T2, T3, T4, T5, TResult>>
    {
        public override Func<T0, T1, T2, T3, T4, T5, TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, T1, T2, T3, T4, T5, TResult>();
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Func<T0, T1, T2, T3, T4, T5, TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    public class FuncConverter<T0, T1, T2, T3, T4, T5, T6, TResult> : JSInProcessObjectReferenceConverterBase<Func<T0, T1, T2, T3, T4, T5, T6, TResult>>
    {
        public override Func<T0, T1, T2, T3, T4, T5, T6, TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, T1, T2, T3, T4, T5, T6, TResult>();
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Func<T0, T1, T2, T3, T4, T5, T6, TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
}
