using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BeforeInstallPromptEvent is the interface of the beforeinstallprompt event fired at the Window object before a user is prompted to "install" a website to a home screen on mobile.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BeforeInstallPromptEvent<br/>
    /// Experimental: This is an experimental technology. Check the Browser compatibility table (MDN) carefully before using this in production.
    /// </summary>
    public class BeforeInstallPromptEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public BeforeInstallPromptEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an array of string items containing the platforms on which the event was dispatched. This is provided for user agents that want to present a choice of versions to the user such as, for example, "web" or "play" which would allow the user to choose between a web version or an Android version.
        /// </summary>
        public string[] Platforms => JSRef!.Get<string[]>("platforms");
        /// <summary>
        /// Returns a Promise that resolves to an object describing the user's choice when they were prompted to install the app.
        /// </summary>
        public Task<InstallPromptResult> UserChoice => JSRef!.GetAsync<InstallPromptResult>("userChoice");
        /// <summary>
        /// Show a prompt asking the user if they want to install the app. This method returns a Promise that resolves to an object describing the user's choice when they were prompted to install the app.
        /// </summary>
        /// <returns></returns>
        public Task<InstallPromptResult> Prompt() => JSRef!.CallAsync<InstallPromptResult>("prompt");
    }
}
