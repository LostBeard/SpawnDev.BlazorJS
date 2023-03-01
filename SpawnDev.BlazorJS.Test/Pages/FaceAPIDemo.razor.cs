using Microsoft.AspNetCore.Components;
using Radzen;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Test.Services;
using SpawnDev.BlazorJS.Test.Shared;
using System.Diagnostics;

namespace SpawnDev.BlazorJS.Test.Pages
{
    public partial class FaceAPIDemo : IDisposable
    {
        [Inject]
        FaceAPIService? _faceAPIService { get; set; }

        [Inject]
        MediaDevicesService? _mediaDevicesService { get; set; }

        CallbackGroup _callbackGroup = new CallbackGroup();
        ElementReference _cameraCanvasProcessedElRef;
        HTMLCanvasElement? _cameraCanvasProcessedEl;
        CanvasRenderingContext2D? _cameraCanvasProcessedElCtx;
        List<DeviceInfo> _devices = new List<DeviceInfo>();
        DeviceInfo? _selectedDevice = null;
        VideoCapture? _videoCapture = null;
        MediaStream? _mediaStream = null;
        CancellationTokenSource? _loopCancelTokenSource;
        Size _videoFrameSize = new Size();
        Stopwatch _swUIUpdate = new Stopwatch();

        double _fps = 0;
        double _processedFrames = 0;
        bool _beenInit = false;
        bool _processingDisabled = false;
        bool _enableProcessing = false;
        ulong _frameIndex = 0;
        ulong _frameIndexReported = 0;
        int _facesFnd = 0;
        bool _withLandmarks = true;

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
                    StartProcessLoop();
                    _ = RefreshCameraList();
                }
                JS.CallVoid("PR.prettyPrint");
            }
        }

        private void MediaDevicesService_OnDeviceInfosChanged(DeviceInfo[] deviceInfos)
        {
            _ = RefreshCameraList();
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

        async void OnDeviceChange(DeviceInfo? selected)
        {
            _mediaStream?.Dispose();
            _mediaStream = null;
            if (_videoCapture != null)
            {
                _videoCapture.Video.Pause();
                _videoCapture.Video.SrcObject = null;
            }
            if (selected != null && _mediaDevicesService != null && _videoCapture != null)
            {
                _mediaStream = await _mediaDevicesService.GetMediaStream(videoDeviceId: selected.DeviceId);
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

        async Task RefreshCameraList()
        {
            await _mediaDevicesService.UpdateDeviceList();
            _devices = _mediaDevicesService.DeviceInfos.Where(o => o.Kind == "videoinput").ToList();
            StateHasChanged();
        }

        async Task<bool> ProcessNextFrame()
        {
            if (_videoCapture == null) return false;
            if (_enableProcessing)
            {
                var arrayBuffer = _videoCapture.ReadArrayBuffer(out var frameSize);
                if (arrayBuffer != null)
                {
                    await _faceAPIService.WhenReady();
                    var frameIndex = _frameIndex++;
                    _ = _faceAPIService.FaceDetection(arrayBuffer, frameSize.Width, frameSize.Height, _withLandmarks).ContinueWith(async (t) => {
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
            StopProcessLoop();
            _cameraCanvasProcessedElCtx?.Dispose();
            _cameraCanvasProcessedEl?.Dispose();
            _callbackGroup.Dispose();
            _mediaStream?.Dispose();
            _videoCapture?.Dispose();
        }
    }
}
