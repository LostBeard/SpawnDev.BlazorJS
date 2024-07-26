using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System.Text.Json;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// Action JsonConverter
    /// </summary>
    public class ActionConverter : JSInProcessObjectReferenceConverterBase<Action>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Action FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return default!;
            var fn = new Function(_ref);
            var ret = fn.ToAction();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Action value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    /// <summary>
    /// Action JsonConverter
    /// </summary>
    public class ActionConverter<T0> : JSInProcessObjectReferenceConverterBase<Action<T0>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Action<T0> FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return default!;
            var fn = new Function(_ref);
            var ret = fn.ToAction<T0>();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Action<T0> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    /// <summary>
    /// Action JsonConverter
    /// </summary>
    public class ActionConverter<T0, T1> : JSInProcessObjectReferenceConverterBase<Action<T0, T1>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Action<T0, T1> FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return default!;
            var fn = new Function(_ref);
            var ret = fn.ToAction<T0, T1>();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Action<T0, T1> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    /// <summary>
    /// Action JsonConverter
    /// </summary>
    public class ActionConverter<T0, T1, T2> : JSInProcessObjectReferenceConverterBase<Action<T0, T1, T2>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Action<T0, T1, T2> FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return default!;
            var fn = new Function(_ref);
            var ret = fn.ToAction<T0, T1, T2>();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Action<T0, T1, T2> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    /// <summary>
    /// Action JsonConverter
    /// </summary>
    public class ActionConverter<T0, T1, T2, T3> : JSInProcessObjectReferenceConverterBase<Action<T0, T1, T2, T3>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Action<T0, T1, T2, T3> FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return default!;
            var fn = new Function(_ref);
            var ret = fn.ToAction<T0, T1, T2, T3>();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Action<T0, T1, T2, T3> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    /// <summary>
    /// Action JsonConverter
    /// </summary>
    public class ActionConverter<T0, T1, T2, T3, T4> : JSInProcessObjectReferenceConverterBase<Action<T0, T1, T2, T3, T4>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Action<T0, T1, T2, T3, T4> FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return default!;
            var fn = new Function(_ref);
            var ret = fn.ToAction<T0, T1, T2, T3, T4>();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Action<T0, T1, T2, T3, T4> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    /// <summary>
    /// Action JsonConverter
    /// </summary>
    public class ActionConverter<T0, T1, T2, T3, T4, T5> : JSInProcessObjectReferenceConverterBase<Action<T0, T1, T2, T3, T4, T5>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Action<T0, T1, T2, T3, T4, T5> FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return default!;
            var fn = new Function(_ref);
            var ret = fn.ToAction<T0, T1, T2, T3, T4, T5>();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Action<T0, T1, T2, T3, T4, T5> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    /// <summary>
    /// Action JsonConverter
    /// </summary>
    public class ActionConverter<T0, T1, T2, T3, T4, T5, T6> : JSInProcessObjectReferenceConverterBase<Action<T0, T1, T2, T3, T4, T5, T6>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Action<T0, T1, T2, T3, T4, T5, T6> FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return default!;
            var fn = new Function(_ref);
            var ret = fn.ToAction<T0, T1, T2, T3, T4, T5, T6>();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Action<T0, T1, T2, T3, T4, T5, T6> value, JsonSerializerOptions options)
        {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
}
