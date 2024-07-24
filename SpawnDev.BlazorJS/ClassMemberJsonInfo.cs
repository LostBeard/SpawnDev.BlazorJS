using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    public class ClassMemberJsonInfo
    {
        public object? DefaultValue { get; private set; }
        public string Name { get; private set; }
        public JsonIgnoreAttribute? JsonIgnoreAttribute { get; set; }
        public JsonPropertyNameAttribute? JsonPropertyNameAttribute { get; set; }
        public bool? JsonIncludeAttribute { get; set; }
        public PropertyInfo? PropertyInfo { get; private set; }
        public FieldInfo? FieldInfo { get; private set; }
        public ClassMemberJsonInfo(FieldInfo fieldInfo)
        {
            FieldInfo = fieldInfo;
            Name = FieldInfo.Name;
            DefaultValue = FieldInfo.FieldType.GetDefaultValue();
        }
        public ClassMemberJsonInfo(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
            Name = PropertyInfo.Name;
            DefaultValue = PropertyInfo.PropertyType.GetDefaultValue();
        }
        public bool GetShouldWrite(object? value, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            if (JsonIgnoreAttribute == null) return true;
            if (JsonIgnoreAttribute.Condition == JsonIgnoreCondition.Always) return false;
            if (JsonIgnoreAttribute.Condition == JsonIgnoreCondition.WhenWritingNull && value is null) return false;
            if (JsonIgnoreAttribute.Condition == JsonIgnoreCondition.WhenWritingDefault && value == DefaultValue) return false;
            return true;
        }
        public string GetJsonName(JsonSerializerOptions? jsonSerializerOptions = null)
        {
            if (JsonPropertyNameAttribute != null) return JsonPropertyNameAttribute.Name;
            var jsonNamingPolicy = jsonSerializerOptions?.PropertyNamingPolicy;
            return jsonNamingPolicy == null ? Name : jsonNamingPolicy.ConvertName(Name);
        }
    }
}
