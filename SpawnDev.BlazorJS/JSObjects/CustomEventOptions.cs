using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object that, in addition of the properties defined in Event(), can have the following properties:
    /// </summary>
    public class CustomEventOptions
    {
        /// <summary>
        /// An event-dependent value associated with the event. This value is then available to the handler using the CustomEvent.detail property. It defaults to null.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Detail { get; set; }
    }
    /// <summary>
    /// An object that, in addition of the properties defined in Event(), can have the following properties:
    /// </summary>
    public class CustomEventOptions<TDetail>
    {
        /// <summary>
        /// An event-dependent value associated with the event. This value is then available to the handler using the CustomEvent.detail property. It defaults to null.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TDetail? Detail { get; set; }
    }
}
