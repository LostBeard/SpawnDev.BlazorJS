using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.WebWorkers
{
    public class SharedCancellationTokenJsonConverter : JsonConverter<SharedCancellationToken>, IJSInProcessObjectReferenceConverter
    {
        public override bool CanConvert(Type type) => typeof(SharedCancellationToken) == type;
        public override SharedCancellationToken Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jeRef = JsonSerializer.Deserialize<IJSInProcessObjectReference?>(ref reader, options);
            if (jeRef == null) return null;
            var typeOf = jeRef.PropertyType();
            switch (typeOf)
            {
                case "boolean":
                    {
                        var cancelled = jeRef.As<bool>();
                        jeRef.Dispose();
                        return new SharedCancellationToken(cancelled);
                    }
                case "object":
                    {
                        var sharedArrayBuffer = new SharedArrayBuffer(jeRef);
                        var source = new SharedCancellationTokenSource(sharedArrayBuffer);
                        return new SharedCancellationToken(source);
                    }
                default: throw new Exception("Invalid json input for SharedCancellationToken");
            }
        }
        public override void Write(Utf8JsonWriter writer, SharedCancellationToken value, JsonSerializerOptions options)
        {
            if (value != null && (!value.CanBeCanceled || value.IsCancellationRequested))
            {
                JsonSerializer.Serialize(writer, value.IsCancellationRequested, options);
            }
            else 
            {
                var _ref = value?._source?.SharedArrayBuffer;
                JsonSerializer.Serialize(writer, _ref, options);
            }
        }
    }
}
