using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Test.Services;
using System.Diagnostics;
using Size = OpenCvSharp.Size;
using VideoCapture = SpawnDev.BlazorJS.OpenCVSharp4.VideoCapture;
using Window = SpawnDev.BlazorJS.JSObjects.Window;

namespace SpawnDev.BlazorJS.Test.Pages
{
    public partial class OpenCVSharpWithWorkersFace : IDisposable
    {
        [Inject]
        FaceAPIService _openCVService { get; set; }

        [Inject]
        MediaDevicesService? mediaDevicesService { get; set; }

        CallbackGroup _callbackGroup = new CallbackGroup();

        Window? _window;
        Document? _document;

        ElementReference _rootDiv;

        ElementReference _cameraCanvasProcessedElRef;
        HTMLCanvasElement? _cameraCanvasProcessedEl;
        CanvasRenderingContext2D? _cameraCanvasProcessedElCtx;

        List<DeviceInfo> _devices = new List<DeviceInfo>();
        DeviceInfo? _selectedDevice = null;
        VideoCapture? _videoCapture = null;
        MediaStream? _mediaStream = null;

        Size _videoFrameSize = new Size();
        Stopwatch _swUIUpdate = new Stopwatch();

        void OnWebWorkerCountChange(int? value)
        {
            var count = value == null ? 0 : value.Value;
            _ = _openCVService.SetWorkerCount(count);
        }

        CancellationTokenSource? _loopCancelTokenSource;

        double _fps = 0;
        double _processedFrames = 0;
        bool _beenInit = false;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                if (!_beenInit)
                {
                    _beenInit = true;
                    //await _openCVService.InitAsync();
                    _window = JS.GetWindow<Window>();
                    _document = JS.GetDocument<Document>();
                    // near drop in VideoCapture replacement that works very similar to the OpenCV one for convenience
                    _videoCapture = new VideoCapture();

                    mediaDevicesService.OnDeviceInfosChanged += MediaDevicesService_OnDeviceInfosChanged;

                    // output canvas (for user feedback)
                    _cameraCanvasProcessedEl = new HTMLCanvasElement(_cameraCanvasProcessedElRef);
                    _cameraCanvasProcessedElCtx = _cameraCanvasProcessedEl.Get2DContext();

                    StartProcessLoop();
                }
            }
        }

        private void MediaDevicesService_OnDeviceInfosChanged(DeviceInfo[] deviceInfos)
        {
            _ = RefreshCameraList();
        }


        // https://pyimagesearch.com/2015/01/19/find-distance-camera-objectmarker-using-python-opencv/
        // TODO - add camera calibration step if calibration option (via menu... TODO)
        // calibration step helps determine focal length for use with distance calculations
        double GetCameraFocalLength(double widthReal, double widthPixels, double distanceReal)
        {
            // F = (P x D) / W
            // D = Distance between object and camera (real world. inches, cm, etc)
            // W = Width of object (real world)
            // P = Pixel width as viewd by camera
            // F = FocalLength
            return (widthPixels * distanceReal) / widthReal;
        }

        double GetCameraDistance(double widthReal, double widthPixels, double focalLength)
        {
            // D = (W x F) / P
            // W = Width of object (real world)
            // F = FocalLength
            // P = Pixel width as viewd by camera
            // D = Distance between object and camera (real world. inches, cm, etc)
            return (widthReal * focalLength) / widthPixels;
        }

        public Element? GetFullscreenElement()
        {
            try
            {
                return JS.Get<Element?>("document.fullscreenElement");
            }
            catch { }
            return null;
        }

        public bool IsFullscreen()
        {
            using var fullscreenElement = GetFullscreenElement();
            return fullscreenElement != null;
        }

        public bool IsWindowHeightEqualsDisplayHeight()
        {
            if (_window == null) return false;
            var screenHeight = JS.Get<int>("screen.height");
            var windowHeight = _window.InnerHeight;
            //Console.WriteLine($"screenHeight: {screenHeight} windowHeight: {windowHeight}");
            return windowHeight == screenHeight;
        }

        public async Task ExitFullscreen()
        {
            Console.WriteLine("ExitFullscreen start");
            try
            {
                await _document.ExitFullscreen();
                Console.WriteLine("ExitFullscreen success");
                StateHasChanged();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ExitFullscreen failed {ex.Message}");
            }
            Console.WriteLine("ExitFullscreen done");
        }

        void StopProcessLoop()
        {
            if (_loopCancelTokenSource == null) return;
            _loopCancelTokenSource.Cancel();
            _loopCancelTokenSource = null;
        }

        void StartProcessLoop()
        {
            if (_loopCancelTokenSource != null) return;
            var loopCancelTokenSource = new CancellationTokenSource();
            _loopCancelTokenSource = loopCancelTokenSource;
            var cancellationToken = loopCancelTokenSource.Token;
            _ = Task.Run(async () =>
            {
                try
                {
                    _swUIUpdate.Restart();
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var frameProcessed = false;
                        try
                        {
                            frameProcessed = await ProcessNextFrame();
                            if (frameProcessed) _processedFrames++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"ERROR: {ex.Message}");
                        }
                        if (_swUIUpdate.Elapsed.TotalSeconds > 1d)
                        {
                            _fps = Math.Round(_processedFrames / _swUIUpdate.Elapsed.TotalSeconds, 1);
                            _processedFrames = 0;
                            _swUIUpdate.Restart();
                            StateHasChanged();
                        }
                        await Task.Delay(1);
                    }
                }
                finally
                {
                    loopCancelTokenSource.Dispose();
                }
            });
        }

        void OnResizeObserved(IJSInProcessObjectReference e)
        {
            var length = e.Get<int>("length");
            //var devicePixelRatio = _window.DevicePixelRatio;
            //Console.WriteLine($"OnResizeObserved: {length}");
            for (var i = 0; i < length; i++)
            {
                using var obj = e.Get<ResizeObserverEntry>(i);
                var w = obj.ContentRect.Width;
                var h = obj.ContentRect.Height;
                //Console.WriteLine($"OnResizeObserved: {w}x{h}");
            }
            e.Dispose();
        }

        async void OnDeviceChange(DeviceInfo? selected)
        {
            //if (_localStorage == null) return;
            //if (selected == null)
            //{
            //    _localStorage.RemoveItem("selectedDeviceId");
            //}
            //else
            //{
            //    _localStorage.SetItem("selectedDeviceId", selected.DeviceId);
            //}
            JS.Log("OnDeviceChange", selected);
            _mediaStream?.Dispose();
            _mediaStream = null;
            if (_videoCapture != null)
            {
                _videoCapture.Video.Pause();
                _videoCapture.Video.SrcObject = null;
            }
            if (selected != null && mediaDevicesService != null && _videoCapture != null)
            {
                _mediaStream = await mediaDevicesService.GetMediaStream(videoDeviceId: selected.DeviceId);
                _videoCapture.Video.SrcObject = _mediaStream;
                try
                {
                    await _videoCapture.Video.Play();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Play error");
                }
            }
        }

        bool _processingDisabled = false;
        bool _enableProcessing = false;
        int _canny0 = 20;
        int _canny1 = 160;

        async Task RefreshCameraList()
        {
            await mediaDevicesService.UpdateDeviceList();
            //var enabled = await mediaDevicesService.RequestMediaPermissions();
            // TODO - use dialog box for camera selectio ntht can be updated when it it shown... current drop down is never updated
            _devices = mediaDevicesService.DeviceInfos.Where(o => o.Kind == "videoinput").ToList();
            StateHasChanged();
        }

        ulong _frameIndex = 0;
        ulong _frameIndexReported = 0;
        int _facesFnd = 0;
        async Task<bool> ProcessNextFrame()
        {
            if (_videoCapture == null) return false;
            if (_enableProcessing)
            {
                await _openCVService.WhenReady();
                var arrayBuffer = _videoCapture.ReadArrayBuffer(out var frameSize);
                if (arrayBuffer != null)
                {
                    if (_videoFrameSize != frameSize)
                    {
                        _videoFrameSize = frameSize;
                        OnInputFrameResized();
                    }
                    await Task.Delay(1);
                    var frameIndex = _frameIndex++;
                    _ = _openCVService.FaceDetection(arrayBuffer, frameSize.Width, frameSize.Height).ContinueWith((t) => {
                        // our result.ArrayBuffer is disposable... make sure it gets disposed after we are done with it
                        var result = t.Result;
                        using var resultArrayBuffer = result.ArrayBuffer;
                        if (resultArrayBuffer != null)
                        {
                            if (frameIndex < _frameIndexReported)
                            {
                                // arrived after a frame that is newer... drop it
                                return;
                            }
                            _frameIndexReported = frameIndex;
                            if (_facesFnd != result.FacesFound)
                            {
                                _facesFnd = result.FacesFound;
                                StateHasChanged();
                            }
                            using var uint8 = new Uint8Array(resultArrayBuffer);
                            using var imgData = ImageData.FromUint8Array(uint8, frameSize.Width, frameSize.Height);
                            if (_cameraCanvasProcessedElCtx != null && _cameraCanvasProcessedEl != null)
                            {
                                _cameraCanvasProcessedEl.Width = frameSize.Width;
                                _cameraCanvasProcessedEl.Height = frameSize.Height;
                                _cameraCanvasProcessedElCtx.PutImageData(imgData, 0, 0);
                            }
                        }
                        arrayBuffer?.Dispose();
                    });
                    return true;
                }
            }
            else
            {
                using var imgData = _videoCapture.ReadImageData(out var frameSize);
                if (imgData != null)
                {
                    if (_videoFrameSize != frameSize)
                    {
                        _videoFrameSize = frameSize;
                        OnInputFrameResized();
                    }
                    if (_cameraCanvasProcessedElCtx != null && _cameraCanvasProcessedEl != null)
                    {
                        _cameraCanvasProcessedEl.Width = frameSize.Width;
                        _cameraCanvasProcessedEl.Height = frameSize.Height;
                        _cameraCanvasProcessedElCtx.PutImageData(imgData, 0, 0);
                    }
                    return true;
                }
            }
            return false;
        }

        void OnInputFrameResized()
        {
            Console.WriteLine($"Camera input resized: {_videoFrameSize.Width}x{_videoFrameSize.Height}");
            if (_cameraCanvasProcessedEl != null)
            {
                _cameraCanvasProcessedEl.Width = _videoFrameSize.Width;
                _cameraCanvasProcessedEl.Height = _videoFrameSize.Height;
            }
        }

        public void Dispose()
        {
            // TODO - finish
            _callbackGroup.Dispose();
        }
    }
}
