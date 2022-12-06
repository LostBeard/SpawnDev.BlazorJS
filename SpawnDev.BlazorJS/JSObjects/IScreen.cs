namespace SpawnDev.BlazorJS.JSObjects
{
    public interface IScreen
    {
        int AvailHeight { get; }
        int AvailLeft { get; }
        int AvailTop { get; }
        int AvailWidth { get; }
        int ColorDepth { get; }
        double DevicePixelRatio { get; }
        int Height { get; }
        bool IsExtended { get; }
        ScreenOrientation Orientation { get; }
        int PixelDepth { get; }
        int Width { get; }
    }
}