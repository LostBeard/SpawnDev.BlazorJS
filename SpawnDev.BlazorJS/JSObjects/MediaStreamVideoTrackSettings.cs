namespace SpawnDev.BlazorJS.JSObjects {
    public class MediaStreamTrackSettings {
        public string DeviceId { get; set; }
    }
    public class MediaStreamVideoTrackSettings : MediaStreamTrackSettings {
        public string ResizeMode { get; set; }
        public double AspectRatio { get; set; }
        public double Brightness { get; set; }
        public double ColorTemperature { get; set; }
        public double Contrast { get; set; }
        public double ExposureCompensation { get; set; }
        public double ExposureTime { get; set; }
        public double FrameRate { get; set; }
        public int Height { get; set; }
        public double Saturation { get; set; }
        public double Sharpness { get; set; }
        public int Width { get; set; }
    }
    public class MediaStreamAudioTrackSettings : MediaStreamTrackSettings {
        public double ChannelCount { get; set; }
        public double Latency { get; set; }
        public double SampleRate { get; set; }
        public double SampleSize { get; set; }
    }
}
