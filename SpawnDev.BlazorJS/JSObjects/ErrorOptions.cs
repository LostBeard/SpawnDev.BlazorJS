using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options used when creating a new Error
    /// </summary>
    public class ErrorOptions
    {
        /// <summary>
        /// A value indicating the specific cause of the error, reflected in the cause property. When catching and re-throwing an error with a more-specific or useful error message, this property can be used to pass the original error.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Error? Cause { get; set; }
    }
}
