namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Returned from calls to navigator.getInstalledRelatedApps
    /// </summary>
    public class InstalledAppInfo
    {
        /// <summary>
        /// A string representing the ID used to represent the application on the specified platform. The exact form of the string will vary by platform.
        /// </summary>
        public string? Id { get; set; }
        /// <summary>
        /// A string representing the platform (ecosystem or operating system) the related app is associated with
        /// </summary>
        public string Platform { get; set; }
        /// <summary>
        /// A string representing the URL associated with the app. This is usually where you can read information about it and install it.
        /// </summary>
        public string? Url { get; set; }
        /// <summary>
        /// A string representing the related app's version.
        /// </summary>
        public string? Version { get; set; }
    }
}
