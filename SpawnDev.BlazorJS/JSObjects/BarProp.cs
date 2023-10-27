using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BarProp interface of the Document Object Model represents the web browser user interface elements that are exposed to scripts in web pages. Each of the following interface elements are represented by a BarProp object.
    /// </summary>
    public class BarProp : JSObject
    {
        #region Constructors
        public BarProp(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// A Boolean, which is true if the bar represented by the used interface element is visible.
        /// </summary>
        public bool Visible => JSRef.Get<bool>("visible");
        #endregion
    }
}
