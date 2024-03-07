using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object that specifies characteristics about the event listener
    /// </summary>
    public class AddEventListenerOptions
    {
        /// <summary>
        /// A boolean value indicating that events of this type will be dispatched to the registered listener before being dispatched to any EventTarget beneath it in the DOM tree. If not specified, defaults to false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool Capture { get; set; } = false;
        /// <summary>
        /// A boolean value indicating that the listener should be invoked at most once after being added. If true, the listener would be automatically removed when invoked. If not specified, defaults to false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Once { get; set; } = null;
        /// <summary>
        /// A boolean value that, if true, indicates that the function specified by listener will never call preventDefault(). If a passive listener does call preventDefault(), the user agent will do nothing other than generate a console warning.<br />
        /// If this option is not specified it defaults to false – except that in browsers other than Safari, it defaults to true for wheel, mousewheel, touchstart and touchmove events. See Using passive listeners to learn more.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Passive { get; set; } = null;
        /// <summary>
        /// An AbortSignal. The listener will be removed when the given AbortSignal object's abort() method is called. If not specified, no AbortSignal is associated with the listener.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AbortSignal? Signal { get; set; } = null;
    }
}