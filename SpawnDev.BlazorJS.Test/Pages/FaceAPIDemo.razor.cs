using Microsoft.AspNetCore.Components;
using Radzen;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Test.Services;
using SpawnDev.BlazorJS.Test.Shared;
using SpawnDev.BlazorJS.Toolbox;
using SpawnDev.BlazorJS.WebWorkers;
using System.Diagnostics;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SpawnDev.BlazorJS.Test.Pages
{
    public partial class FaceAPIDemo : IDisposable
    {
        [Inject]
        MediaDevicesService? _mediaDevicesService { get; set; }

        [Inject]
        WebWorkerService WebWorkerService { get; set; }

        CallbackGroup _callbackGroup = new CallbackGroup();
        ElementReference _cameraCanvasProcessedElRef;
        HTMLCanvasElement? _cameraCanvasProcessedEl;
        CanvasRenderingContext2D? _cameraCanvasProcessedElCtx;
        List<MediaDeviceInfo> _devices = new List<MediaDeviceInfo>();
        MediaDeviceInfo? _selectedDevice = null;
        VideoCapture? _videoCapture = null;
        MediaStream? _mediaStream = null;
        Size _videoFrameSize = new Size();
        Stopwatch _swUIUpdate = new Stopwatch();

        double _fps = 0;
        double _fpsDropped = 0;
        double _processedFrames = 0;
        double _droppedFrames = 0;
        bool _beenInit = false;
        bool _processingDisabled = false;
        bool _enableProcessing = false;
        ulong _frameIndex = 0;
        ulong _frameIndexReported = 0;
        int _facesFnd = 0;
        bool _withLandmarks = true;
        Timer _timer = new Timer(500);

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                if (!_beenInit)
                {
                    _beenInit = true;
                    _videoCapture = new VideoCapture();
                    _mediaDevicesService.OnDeviceInfosChanged += MediaDevicesService_OnDeviceInfosChanged;
                    _cameraCanvasProcessedEl = new HTMLCanvasElement(_cameraCanvasProcessedElRef);
                    _cameraCanvasProcessedElCtx = _cameraCanvasProcessedEl.Get2DContext(new ContextAttributes2D { WillReadFrequently = true });
                    _ = RefreshCameraList();
                    _videoCapture.OnNewFrameAsync = _videoCapture_NewFrame;
                    _timer.Elapsed += _timer_Elapsed;
                    _timer.Enabled = true;
                }
            }
        }

        private void _timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            if (!_swUIUpdate.IsRunning) _swUIUpdate.Restart();
            if (_swUIUpdate.Elapsed.TotalSeconds >= 1d)
            {
                _fps = Math.Round(_processedFrames / _swUIUpdate.Elapsed.TotalSeconds, 1);
                _fpsDropped = Math.Round(_droppedFrames / _swUIUpdate.Elapsed.TotalSeconds, 1);
                _processedFrames = 0;
                _droppedFrames = 0;
                _swUIUpdate.Restart();
                StateHasChanged();
            }
        }

        bool _mainThreadProcessing = false;

        Size frameSize;
        bool TryProcessFrame(ImageData image)
        {
            if (!_enableProcessing)
            {
                frameSize = new Size(image.Width, image.Height);
                if (_videoFrameSize != frameSize)
                {
                    _videoFrameSize = frameSize;
                    OnInputFrameResized();
                }
                if (_cameraCanvasProcessedElCtx != null && _cameraCanvasProcessedEl != null)
                {
                    _cameraCanvasProcessedEl.Width = frameSize.Width;
                    _cameraCanvasProcessedEl.Height = frameSize.Height;
                    _cameraCanvasProcessedElCtx.PutImageData(image, 0, 0);
                }
                image.Dispose();
                return true;
            }
            WebWorker? worker = null;
            IFaceAPIService faceAPIService;
            if (WebWorkerService.WorkerTask.PoolSize > 0 && WebWorkerService.WorkerTask.TryGetWorker(out worker))
            {
                faceAPIService = worker.GetService<IFaceAPIService>();
            }
            else if (!_mainThreadProcessing)
            {
                _mainThreadProcessing = true;
                faceAPIService = WebWorkerService.ServiceProvider.GetRequiredService<IFaceAPIService>();
            }
            else
            {
                // no workers 
                image.Dispose();
                return false;
            }
            frameSize = new Size(image.Width, image.Height);
            using var data = image.Data;
            image.Dispose();
            var arrayBuffer = data.Buffer;
            var frameIndex = _frameIndex++;
            _ = faceAPIService.FaceDetection(arrayBuffer, frameSize.Width, frameSize.Height, _withLandmarks).ContinueWith((t) =>
            {
                if (worker != null)
                {
                    worker.ReleaseLock();
                }
                else
                {
                    _mainThreadProcessing = false;
                }
                try
                {
                    using var result = t.Result;
                    if (t.IsFaulted || t.IsCanceled || result == null || frameIndex < _frameIndexReported)
                    {
                        return;
                    }
                    _frameIndexReported = frameIndex;
                    if (_videoFrameSize != frameSize)
                    {
                        _videoFrameSize = frameSize;
                        OnInputFrameResized();
                    }
                    var resultArrayBuffer = result.ArrayBuffer;
                    if (resultArrayBuffer != null && !resultArrayBuffer.IsWrapperDisposed && resultArrayBuffer.ByteLength > 0)
                    {
                        using var uint8 = new Uint8Array(resultArrayBuffer);
                        using var imgData = ImageData.FromUint8Array(uint8, frameSize.Width, frameSize.Height);
                        if (_cameraCanvasProcessedElCtx != null && _cameraCanvasProcessedEl != null)
                        {
                            _cameraCanvasProcessedEl.Width = frameSize.Width;
                            _cameraCanvasProcessedEl.Height = frameSize.Height;
                            _cameraCanvasProcessedElCtx.PutImageData(imgData, 0, 0);
                        }
                    }
                    if (_facesFnd != result.FacesFound)
                    {
                        _facesFnd = result.FacesFound;
                        StateHasChanged();
                    }
                }
                finally
                {
                    arrayBuffer.Dispose();
                }
            });
            return true;
        }

        private async Task _videoCapture_NewFrame()
        {
            var imageData = _videoCapture.ReadImageData();
            if (imageData != null)
            {
                //while (_images.Count >= maxQueueSize)
                //{
                //    var image = _images.Dequeue();
                //    image.Dispose();
                //    _droppedFrames++;
                //}
                //_images.Enqueue(imageData);
                if (TryProcessFrame(imageData))
                {
                    _processedFrames++;
                }
                else
                {
                    _droppedFrames++;
                }
            }
        }

        private void MediaDevicesService_OnDeviceInfosChanged()
        {
            _ = RefreshCameraList();
        }

        void CloseMediaStream()
        {
            if (_mediaStream == null) return;
            _mediaStream.StopAllTracks();
            _mediaStream.Dispose();
            _mediaStream = null;
        }

        async void OnDeviceChange(MediaDeviceInfo? selected)
        {
            CloseMediaStream();
            if (_videoCapture != null)
            {
                _videoCapture.Video.Pause();
                _videoCapture.Video.SrcObject = null;
            }
            if (selected != null && _mediaDevicesService != null && _videoCapture != null)
            {
                _mediaStream = await _mediaDevicesService.MediaDevices.GetMediaDeviceStream(selected.DeviceId, null);
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

        async Task RefreshCameraList(bool allowAsk = false)
        {
            await _mediaDevicesService.UpdateDeviceList(allowAsk);
            _devices = _mediaDevicesService.DeviceInfos.Where(o => o.Kind == "videoinput").ToList();
            StateHasChanged();
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
            //_images.Clear();
            CloseMediaStream();
            if (_videoCapture != null)
            {
                _videoCapture.Dispose();
                _videoCapture = null;
            }
            _cameraCanvasProcessedElCtx?.Dispose();
            _cameraCanvasProcessedEl?.Dispose();
            _mediaStream?.Dispose();
            _callbackGroup.Dispose();
        }
    }
}
