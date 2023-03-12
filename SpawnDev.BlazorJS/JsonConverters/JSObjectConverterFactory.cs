using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public class JSObjectConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type type)
        {
            return typeof(JSObject).IsAssignableFrom(type);
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var covnerterType = typeof(JSObjectConverter<>).MakeGenericType(new Type[] { typeToConvert });
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(covnerterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { options }, culture: null)!;
            return converter;
        }
    }

    // https://github.com/dotnet/aspnetcore/blob/ccb861b89f62c445f175f6a3ca2142f93e7ce5db/src/Components/WebAssembly/JSInterop/src/WebAssemblyJSObjectReferenceJsonConverter.cs#L10
    // WebAssemblyJSObjectReferenceJsonConverter.cs
    public class JSObjectConverter<TJSObject> : JsonConverter<TJSObject>, IJSInProcessObjectReferenceConverter where TJSObject : JSObject
    {
        public JSCallResultType JSCallResultType { get; } = JSCallResultType.JSObjectReference;
        public bool OverrideResultType => true;
        JsonSerializerOptions _options;
        public JSObjectConverter(JsonSerializerOptions options)
        {
            _options = options;
        }
        public override bool CanConvert(Type type)
        {
            return typeof(TJSObject).IsAssignableFrom(type);
        }
        public override TJSObject Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            return _ref == null ? null :(TJSObject)Activator.CreateInstance(typeof(TJSObject), _ref);
        }
        public override void Write(Utf8JsonWriter writer, TJSObject value, JsonSerializerOptions options)
        {
            var obj = value as JSObject;
            var _ref = obj == null ? null : obj.JSRef;
            JsonSerializer.Serialize(writer, _ref, options);
        }
    }
}
