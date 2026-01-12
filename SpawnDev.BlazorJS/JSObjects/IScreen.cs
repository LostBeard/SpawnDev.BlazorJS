namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The IScreen interface of the Screen API represents a screen, usually the one on which the current window is being rendered.
    /// </summary>
    public interface IScreen
    {
        /// <summary>
        /// Specifies the height of the screen, in pixels, minus permanent or semipermanent user interface features displayed by the operating system, such as the Taskbar on Windows.
        /// </summary>
        int AvailHeight { get; }
        /// <summary>
        /// Returns the first available pixel available from the left side of the screen.
        /// </summary>
        int AvailLeft { get; }
        /// <summary>
        /// Specifies the y-coordinate of the first pixel that is not allocated to permanent or semipermanent user interface features.
        /// </summary>
        int AvailTop { get; }
        /// <summary>
        /// Specifies the width of the screen, in pixels, minus permanent or semipermanent user interface features, such as the Taskbar on Windows.
        /// </summary>
        int AvailWidth { get; }
        /// <summary>
        /// Returns the color depth of the screen.
        /// </summary>
        int ColorDepth { get; }
        /// <summary>
        /// Returns the ratio of physical pixels to device independent pixels for the screen.
        /// </summary>
        double DevicePixelRatio { get; }
        /// <summary>
        /// Returns the height of the screen in pixels.
        /// </summary>
        int Height { get; }
        /// <summary>
        /// Returns true if the user's device has multiple screens.
        /// </summary>
        bool IsExtended { get; }
        /// <summary>
        /// Returns the ScreenOrientation instance associated with this screen.
        /// </summary>
        ScreenOrientation Orientation { get; }
        /// <summary>
        /// Gets the bit depth of the screen.
        /// </summary>
        int PixelDepth { get; }
        /// <summary>
        /// Returns the width of the screen.
        /// </summary>
        int Width { get; }
    }
}