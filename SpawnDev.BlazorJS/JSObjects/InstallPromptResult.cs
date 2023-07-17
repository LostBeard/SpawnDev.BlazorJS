namespace SpawnDev.BlazorJS.JSObjects
{
    public class InstallPromptResult
    {
        /// <summary>
        /// A string indicating whether the user chose to install the app or not. It must be one of the following values:<br />
        /// "accepted": The user installed the app.<br />
        /// "dismissed": The user did not install the app.<br />
        /// </summary>
        public string Outcome { get; set; } = "";
        /// <summary>
        /// If the user chose to install the app, this is a string naming the selected platform, which is one of the values from the BeforeInstallPromptEvent.platforms property. If the user chose not to install the app, this is an empty string.
        /// </summary>
        public string? Platform { get; set; }
    }
}
