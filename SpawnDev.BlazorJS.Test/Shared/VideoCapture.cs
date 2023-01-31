using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Test.Shared
{
    public class Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public Size() { }
        public static Size Zero => new Size();
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
        }

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
            _cameraCanvasElCtx.Dispose();
            _cameraCanvasEl.Dispose();
            Video.Dispose();
        }
    }
}
