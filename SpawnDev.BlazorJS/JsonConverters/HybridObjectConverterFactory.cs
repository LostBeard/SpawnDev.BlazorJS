using Microsoft.JSInterop;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public class HybridObjectConverterFactory : JsonConverterFactory
    {
        // this converter is for converting class types that would normally be passed as JSON but has special property types that need to be loaded individually to work
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsClass) return false;
            if (typeToConvert.IsInterface) return false;
            if (typeToConvert.IsArray) return false;
            if (typeof(JSObject).IsAssignableFrom(typeToConvert)) return false;
            if (typeof(IJSObjectProxy).IsAssignableFrom(typeToConvert)) return false;
            if (typeof(Callback).IsAssignableFrom(typeToConvert)) return false;
            if (typeToConvert.IsAsync()) return false;
            var baseType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : typeToConvert;
            if (baseType == typeof(List<>)) return false;
            var classProps = typeToConvert.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var prop in classProps)
            {
                if (Attribute.IsDefined(prop, typeof(JsonIgnoreAttribute))) continue;
                var pType = prop.PropertyType;
                if (typeof(JSObject).IsAssignableFrom(pType))
                {
                    return true;
                }
                if (typeof(IJSObjectProxy).IsAssignableFrom(pType))
                {
                    return true;
                }
            }
            return false;
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converterType = typeof(HybridObjectConverter<>).MakeGenericType(typeToConvert);
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(converterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { }, culture: null)!;
            return converter;
        }
    }
    public class HybridObjectConverter<T> : JsonConverter<T>, IJSInProcessObjectReferenceConverter where T : class
    {

        PropertyInfo[] classProps;
        public HybridObjectConverter()
        {
            classProps = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
        }

        string GetPropertyJSName(PropertyInfo prop)
        {
            // TODO - json name attribute
            string propName = prop.Name;
            try
            {
                propName = string.IsNullOrEmpty(propName) ? "" : propName.Substring(0, 1).ToLowerInvariant() + propName.Substring(1);
            }
            catch
            {
                var nmt = true;
            }
            return propName;
        }
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            var tmpRet = (T)Activator.CreateInstance(typeof(T));
            foreach (var prop in classProps)
            {
                var propName = GetPropertyJSName(prop);
                object? value;
                try
                {
                    value = _ref.Get(prop.PropertyType, propName);
                }
                catch
                {
                    continue;
                }
                if (value == null) continue;
                prop.SetValue(tmpRet, value);
            }
            return tmpRet;
        }
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            foreach (var prop in classProps)
            {
                var propName = GetPropertyJSName(prop);
                object? propValue = prop.GetValue(value);
                writer.WritePropertyName(propName);
                JsonSerializer.Serialize(writer, propValue, options);
            }
            writer.WriteEndObject();
        }
    }
}
