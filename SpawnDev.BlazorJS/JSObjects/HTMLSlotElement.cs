using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLSlotElement interface of the Shadow DOM API enables access to the name and assigned nodes of an HTML slot element.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLSlotElement<br />
    /// TODO - finish interface
    /// </summary>
    public class HTMLSlotElement : HTMLElement
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLSlotElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        public string Name { get => JSRef.Get<string>("name"); set => JSRef.Set("name", value); }
    }
}
