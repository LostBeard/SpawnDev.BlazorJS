using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class BeforeInstallPromptEvent : Event
    {
        public BeforeInstallPromptEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string[] Platforms => JSRef.Get<string[]>("platforms");
        public Task<InstallPromptResult> UserChoice => JSRef.GetAsync<InstallPromptResult>("userChoice");
        public Task<InstallPromptResult> Prompt => JSRef.CallAsync<InstallPromptResult>("Prompt");
    }
}
