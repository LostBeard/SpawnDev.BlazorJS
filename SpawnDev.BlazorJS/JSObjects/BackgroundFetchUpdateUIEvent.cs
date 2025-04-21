using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BackgroundFetchUpdateUIEvent interface of the Background Fetch API is an event type for the backgroundfetchsuccess and backgroundfetchfail events, and provides a method for updating the title and icon of the app to inform a user of the success or failure of a background fetch.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchUpdateUIEvent
    /// </summary>
    public class BackgroundFetchUpdateUIEvent : BackgroundFetchEvent
    {
        /// <inheritdoc/>
        public BackgroundFetchUpdateUIEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The updateUI() method of the BackgroundFetchUpdateUIEvent interface updates the title and icon in the user interface to show the status of a background fetch.<br/>
        /// This method may only be run once, to notify the user on a failed or a successful fetch.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task UpdateUI(UpdateUIOptions? options = null) => options == null ? JSRef!.CallVoidAsync("updateUI") :  JSRef!.CallVoidAsync("updateUI", options);
    }
}
