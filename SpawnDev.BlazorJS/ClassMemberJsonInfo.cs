using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Determines information used for Json serialization for a specified Propert or Field
    /// </summary>
    public class ClassMemberJsonInfo
    {
        /// <summary>
        /// Type default value
        /// </summary>
        public object? DefaultValue { get; private set; }
        /// <summary>
        /// Field or Property name
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// JsonIgnoeAttribute
        /// </summary>
        public JsonIgnoreAttribute? JsonIgnoreAttribute { get; set; }
        /// <summary>
        /// JsonPropertyNameAttribute
        /// </summary>
        public JsonPropertyNameAttribute? JsonPropertyNameAttribute { get; set; }
        /// <summary>
        /// ProeprtyInfo is a property
        /// </summary>
        public PropertyInfo? PropertyInfo { get; private set; }
        /// <summary>
        /// FieldInfo if a field
        /// </summary>
        public FieldInfo? FieldInfo { get; private set; }
        /// <summary>
        /// New instance usign FieldInfo
        /// </summary>
        /// <param name="fieldInfo"></param>
        public ClassMemberJsonInfo(FieldInfo fieldInfo)
        {
            FieldInfo = fieldInfo;
            Name = FieldInfo.Name;
            DefaultValue = FieldInfo.FieldType.GetDefaultValue();
        }
        /// <summary>
        /// New instance usign PropertyInfo
        /// </summary>
        /// <param name="propertyInfo"></param>
        public ClassMemberJsonInfo(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
            Name = PropertyInfo.Name;
            DefaultValue = PropertyInfo.PropertyType.GetDefaultValue();
        }
        /// <summary>
        /// Returns if the Property/Field should be written when serialized
        /// </summary>
        /// <param name="value"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        public bool GetShouldWrite(object? value, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            if (JsonIgnoreAttribute == null) return true;
            if (JsonIgnoreAttribute.Condition == JsonIgnoreCondition.Always) return false;
            if (JsonIgnoreAttribute.Condition == JsonIgnoreCondition.WhenWritingNull && value is null) return false;
            if (JsonIgnoreAttribute.Condition == JsonIgnoreCondition.WhenWritingDefault && value == DefaultValue) return false;
            return true;
        }
        /// <summary>
        /// Get's the Json version of the Property/Field name
        /// </summary>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        public string GetJsonName(JsonSerializerOptions? jsonSerializerOptions = null)
        {
            if (JsonPropertyNameAttribute != null) return JsonPropertyNameAttribute.Name;
            var jsonNamingPolicy = jsonSerializerOptions?.PropertyNamingPolicy;
            return jsonNamingPolicy == null ? Name : jsonNamingPolicy.ConvertName(Name);
        }
    }
}
