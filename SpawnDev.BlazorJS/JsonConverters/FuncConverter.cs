using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System.Text.Json;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// Func JsonConverter
    /// </summary>
    public class FuncConverter<TResult> : JSInProcessObjectReferenceConverterBase<Func<TResult>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Func<TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<TResult>();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Func<TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    /// <summary>
    /// Func JsonConverter
    /// </summary>
    public class FuncConverter<T0, TResult> : JSInProcessObjectReferenceConverterBase<Func<T0, TResult>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Func<T0, TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, TResult>();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Func<T0, TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    /// <summary>
    /// Func JsonConverter
    /// </summary>
    public class FuncConverter<T0, T1, TResult> : JSInProcessObjectReferenceConverterBase<Func<T0, T1, TResult>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Func<T0, T1, TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, T1, TResult>();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Func<T0, T1, TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    /// <summary>
    /// Func JsonConverter
    /// </summary>
    public class FuncConverter<T0, T1, T2, TResult> : JSInProcessObjectReferenceConverterBase<Func<T0, T1, T2, TResult>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Func<T0, T1, T2, TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, T1, T2, TResult>();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Func<T0, T1, T2, TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    /// <summary>
    /// Func JsonConverter
    /// </summary>
    public class FuncConverter<T0, T1, T2, T3, TResult> : JSInProcessObjectReferenceConverterBase<Func<T0, T1, T2, T3, TResult>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Func<T0, T1, T2, T3, TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, T1, T2, T3, TResult>();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Func<T0, T1, T2, T3, TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    /// <summary>
    /// Func JsonConverter
    /// </summary>
    public class FuncConverter<T0, T1, T2, T3, T4, TResult> : JSInProcessObjectReferenceConverterBase<Func<T0, T1, T2, T3, T4, TResult>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Func<T0, T1, T2, T3, T4, TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, T1, T2, T3, T4, TResult>();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Func<T0, T1, T2, T3, T4, TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    /// <summary>
    /// Func JsonConverter
    /// </summary>
    public class FuncConverter<T0, T1, T2, T3, T4, T5, TResult> : JSInProcessObjectReferenceConverterBase<Func<T0, T1, T2, T3, T4, T5, TResult>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Func<T0, T1, T2, T3, T4, T5, TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, T1, T2, T3, T4, T5, TResult>();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Func<T0, T1, T2, T3, T4, T5, TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    /// <summary>
    /// Func JsonConverter
    /// </summary>
    public class FuncConverter<T0, T1, T2, T3, T4, T5, T6, TResult> : JSInProcessObjectReferenceConverterBase<Func<T0, T1, T2, T3, T4, T5, T6, TResult>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Func<T0, T1, T2, T3, T4, T5, T6, TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, T1, T2, T3, T4, T5, T6, TResult>();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Func<T0, T1, T2, T3, T4, T5, T6, TResult> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
}
