using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.WebGL.Extensions
{
    /// <summary>
    /// The WEBGL_lose_context extension is part of the WebGL API and exposes functions to simulate losing and restoring the WebGL context.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WEBGL_lose_context
    /// </summary>
    public class WEBGL_lose_context : JSObject
    {
        /// <inheritdoc/>
        public WEBGL_lose_context(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Simulates the losing of the context.
        /// </summary>
        public void LoseContext() => JSRef!.CallVoid("loseContext");
        /// <summary>
        /// Simulates the restoring of the context.
        /// </summary>
        public void RestoreContext() => JSRef!.CallVoid("restoreContext");
    }
}
