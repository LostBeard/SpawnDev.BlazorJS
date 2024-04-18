namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The following constants identify which part of the keyboard the key event originates from.
    /// </summary>
    public enum KeyLocation
    {
        /// <summary>
        /// The key described by the event is not identified as being located in a particular area of the keyboard.<br/>
        /// https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent#constants
        /// </summary>
        DomKeyLocationStandard = 0x00,

        /// <summary>
        /// The key is one which may exist in multiple locations on the keyboard and, in this instance, is on the left side of the keyboard.<br/>
        /// https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent#constants
        /// </summary>        
        DomKeyLocationLeft = 0x01,

        /// <summary>
        /// The key is one which may exist in multiple positions on the keyboard and, in this case, is located on the right side of the keyboard.<br/>
        /// https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent#constants
        /// </summary>
        DomKeyLocationRight = 0x02,

        /// <summary>
        /// The key is located on the numeric keypad, or is a virtual key associated with the numeric keypad if there's more than one place the key could originate from.<br/>
        /// https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent#constants
        /// </summary>
        DomKeyLocationNumpad = 0x03,
    }
}
