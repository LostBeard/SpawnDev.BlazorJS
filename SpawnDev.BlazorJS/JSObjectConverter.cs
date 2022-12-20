using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    public class JSObjectConverter<T> : JsonConverter<T>
    {
        public override bool CanConvert(Type type)
        {
            return typeof(JSObject).IsAssignableFrom(type);
        }
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
                return (T)Activator.CreateInstance(typeof(T), _ref);
            }
            catch (Exception ex)
            {
                var nmt = true;
            }
            var destType = typeToConvert.Name;
            try
            {
                using var jsonDocument = JsonDocument.ParseValue(ref reader);
                var jsonText = jsonDocument.RootElement.GetRawText();
                if (jsonText == "{}")
                {
                    return default;
                }
                var ok = true;
            }
            catch (Exception ex)
            {
                var art = true;
            }
            return default;
        }
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            try
            {
                var ext = value as JSObject;
                JsonSerializer.Serialize(writer, ext?.JSRef, options);
            }
            catch (Exception ex)
            {
                var art = true;
            }
        }
    }
    //public class JSObjectConverter : JsonConverter<JSObject>
    //{
    //    public override bool CanConvert(Type type)
    //    {
    //        return typeof(JSObject).IsAssignableFrom(type);
    //    }
    //    public override JSObject Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
    //        return (JSObject)Activator.CreateInstance(typeToConvert, _ref);
    //    }
    //    public override void Write(Utf8JsonWriter writer, JSObject value, JsonSerializerOptions options)
    //    {
    //        JsonSerializer.Serialize(writer, value.JSRef, options);
    //    }
    //}
}
