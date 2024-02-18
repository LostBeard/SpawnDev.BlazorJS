using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// MutationObserver.observe options
    /// </summary>
    public class MutationObserveOptions
    {
        /// <summary>
        /// Set to true to extend monitoring to the entire subtree of nodes rooted at target. All of the other properties are then extended to all of the nodes in the subtree instead of applying solely to the target node. The default value is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("subtree")]
        public bool? Subtree { get; set; }
        /// <summary>
        /// Set to true to monitor the target node (and, if subtree is true, its descendants) for the addition of new child nodes or removal of existing child nodes. The default value is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("childList")]
        public bool? ChildList { get; set; }
        /// <summary>
        /// Set to true to watch for changes to the value of attributes on the node or nodes being monitored. The default value is true if either of attributeFilter or attributeOldValue is specified, otherwise the default value is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("attributes")]
        public bool? Attributes { get; set; }
        /// <summary>
        /// An array of specific attribute names to be monitored. If this property isn't included, changes to all attributes cause mutation notifications.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("attributeFilter")]
        public IEnumerable<string>? AttributeFilter { get; set; }
        /// <summary>
        /// Set to true to record the previous value of any attribute that changes when monitoring the node or nodes for attribute changes; See Monitoring attribute values for an example of watching for attribute changes and recording values. The default value is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("attributeOldValue")]
        public bool? AttributeOldValue { get; set; }
        /// <summary>
        /// Set to true to monitor the specified target node (and, if subtree is true, its descendants) for changes to the character data contained within the node or nodes. The default value is true if characterDataOldValue is specified, otherwise the default value is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("characterData")]
        public bool? CharacterData { get; set; }
        /// <summary>
        /// Set to true to record the previous value of a node's text whenever the text changes on nodes being monitored. The default value is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("characterDataOldValue")]
        public bool? CharacterDataOldValue { get; set; }
    }
}
