using SpawnDev.BlazorJS.JSObjects;
using System.Diagnostics;

namespace SpawnDev.BlazorJS.Test.Shared
{
    public class Size
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public Size() { }
        public static Size Zero { get; private set; } = new Size();
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            return Equals((Size)obj);
        }
        bool Equals(Size obj)
        {
            return obj.Width == Width && obj.Height == Height;
        }
        public static bool operator !=(Size obj1, Size obj2) => !(obj1 == obj2);
        public static bool operator ==(Size obj1, Size obj2)
        {
            if (ReferenceEquals(obj1, obj2))
                return true;
            if (ReferenceEquals(obj1, null))
                return false;
            if (ReferenceEquals(obj2, null))
                return false;
            return obj1.Equals(obj2);
        }
    }
    public class VideoCapture : IDisposable
    {
        public HTMLVideoElement Video { get; private set; }
        HTMLCanvasElement _cameraCanvasEl;
        CanvasRenderingContext2D _cameraCanvasElCtx;
        public Size SourceVideoFrameSize { get; private set; } = new Size(0, 0);

#nullable disable
        public event Action OnInputFrameResized;
#nullable enable

        public VideoCapture(HTMLVideoElement source)
        {
            Video = source;
            _cameraCanvasEl = new HTMLCanvasElement();
            _cameraCanvasElCtx = _cameraCanvasEl.Get2DContext(new ContextAttributes2D { WillReadFrequently = true });
        }

        public VideoCapture()
        {
            Video = new HTMLVideoElement();
            _cameraCanvasEl = new HTMLCanvasElement();
            _cameraCanvasElCtx = _cameraCanvasEl.Get2DContext(new ContextAttributes2D { WillReadFrequently = true });
            if (JS.WindowThis != null) JS.WindowThis.OnAnimationFrame += WindowThis_OnAnimationFrame;
        }

        public double CurrentFPS { get; private set; } = 0;
        int _frames = 0;
        int _unreportedCount = 0;
        Stopwatch sw = new Stopwatch();
        public double LastFromTime = -1;

        public event Action NewFrame;

        private void WindowThis_OnAnimationFrame(double timestamp) {
            if (!sw.IsRunning) sw.Start();
            var currentTime = CurrentTime;
            if (LastFromTime != currentTime) {
                _frames++;
                LastFromTime = currentTime;
                NewFrame?.Invoke();
            }
            var elapsed = sw.Elapsed.TotalSeconds;
            if (elapsed > 1d) {
                sw.Restart();
                CurrentFPS = _frames / elapsed;
                _frames = 0;
                //
                _unreportedCount++;
                if (_unreportedCount == 5) {
                    _unreportedCount = 0;
                }
            }
        }

        public double CurrentTime => Video.CurrentTime;

        private void VideoSizeChangedCheck()
        {
            var w = Video.VideoWidth;
            var h = Video.VideoHeight;
            var videoFrameSize = w == 0 || h == 0 ? Size.Zero : new Size(w, h);
            if (SourceVideoFrameSize != videoFrameSize)
            {
                _cameraCanvasEl.Width = w;
                _cameraCanvasEl.Height = h;
                var cw = _cameraCanvasEl.Width;
                var ch = _cameraCanvasEl.Height;
                if (cw == w && ch == h)
                {
                    SourceVideoFrameSize = videoFrameSize;
                    OnInputFrameResized?.Invoke();
                }
            }
        }

        public ImageData? ReadImageData(out Size frameSize)
        {
            ImageData? ret = null;
            VideoSizeChangedCheck();
            frameSize = new Size(SourceVideoFrameSize.Width, SourceVideoFrameSize.Height);
            if (SourceVideoFrameSize != Size.Zero)
            {
                _cameraCanvasElCtx.DrawImage(Video);
                ret = _cameraCanvasElCtx.GetImageData(0, 0, SourceVideoFrameSize.Width, SourceVideoFrameSize.Height);
            }
            return ret;
        }

        public ImageData? ReadImageData()
        {
            ImageData? ret = null;
            VideoSizeChangedCheck();
            if (SourceVideoFrameSize != Size.Zero)
            {
                _cameraCanvasElCtx.DrawImage(Video);
                ret = _cameraCanvasElCtx.GetImageData(0, 0, SourceVideoFrameSize.Width, SourceVideoFrameSize.Height);
            }
            return ret;
        }

        public ArrayBuffer? ReadArrayBuffer(out Size frameSize)
        {
            ArrayBuffer? ret = null;
            VideoSizeChangedCheck();
            frameSize = new Size(SourceVideoFrameSize.Width, SourceVideoFrameSize.Height);
            if (SourceVideoFrameSize != Size.Zero)
            {
                _cameraCanvasElCtx.DrawImage(Video);
                using var srcRGBA = _cameraCanvasElCtx.GetImageData(0, 0, SourceVideoFrameSize.Width, SourceVideoFrameSize.Height);
                using var data = srcRGBA.Data;
                ret = data.Buffer;
            }
            return ret;
        }

        public void Dispose()
        {
            if (JS.WindowThis != null) JS.WindowThis.OnAnimationFrame -= WindowThis_OnAnimationFrame;
            try {
                Video.Pause();
            }
            catch { }
            _cameraCanvasElCtx.Dispose();
            _cameraCanvasEl.Dispose();
            Video.Dispose();
        }
    }
}
