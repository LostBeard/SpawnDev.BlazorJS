using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The UserActivation interface allows querying information about a window's user activation state. <br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/UserActivation<br />
    /// https://developer.mozilla.org/en-US/docs/Web/Security/User_activation
    /// </summary>
    public class UserActivation : JSObject
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public UserActivation(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// Indicates whether the current window has sticky user activation.
        /// </summary>
        public bool HasBeenActive => JSRef!.Get<bool>("hasBeenActive");
        /// <summary>
        /// Indicates whether the current window has transient user activation.
        /// </summary>
        public bool IsActive => JSRef!.Get<bool>("isActive");
        #endregion
    }
}
