using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor.Rendering;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Test.Services;
using SpawnDev.BlazorJS.Test.Shared;
using SpawnDev.BlazorJS.WebWorkers;
using System.Diagnostics;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SpawnDev.BlazorJS.Test.Pages {
    public partial class FaceAPIDemo : IDisposable {
        [Inject]
        IFaceAPIService? _faceAPIService { get; set; }

        [Inject]
        MediaDevicesService? _mediaDevicesService { get; set; }

        [Inject]
        WebWorkerPool? _workerPool { get; set; }

        CallbackGroup _callbackGroup = new CallbackGroup();
        ElementReference _cameraCanvasProcessedElRef;
        HTMLCanvasElement? _cameraCanvasProcessedEl;
        CanvasRenderingContext2D? _cameraCanvasProcessedElCtx;
        List<DeviceInfo> _devices = new List<DeviceInfo>();
        DeviceInfo? _selectedDevice = null;
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

        protected override async Task OnAfterRenderAsync(bool firstRender) {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender) {
                if (!_beenInit) {
                    _beenInit = true;
                    _videoCapture = new VideoCapture();
                    _mediaDevicesService.OnDeviceInfosChanged += MediaDevicesService_OnDeviceInfosChanged;
                    _cameraCanvasProcessedEl = new HTMLCanvasElement(_cameraCanvasProcessedElRef);
                    _cameraCanvasProcessedElCtx = _cameraCanvasProcessedEl.Get2DContext(new ContextAttributes2D { WillReadFrequently = true });
                    //StartProcessLoop();
                    _ = RefreshCameraList();
                    _videoCapture.NewFrame += _videoCapture_NewFrame;
                    _workerPool.OnBusyStateChanged += _workerPool_OnBusyStateChanged;
                    _timer.Elapsed += _timer_Elapsed;
                    _timer.Enabled = true;
                }
                BlazorJSRuntime.JS.CallVoid("PR.prettyPrint");
            }
        }

        private void _timer_Elapsed(object? sender, ElapsedEventArgs e) {
            if (!_swUIUpdate.IsRunning) _swUIUpdate.Restart();
            if (_swUIUpdate.Elapsed.TotalSeconds >= 1d) {
                _fps = Math.Round(_processedFrames / _swUIUpdate.Elapsed.TotalSeconds, 1);
                _fpsDropped = Math.Round(_droppedFrames / _swUIUpdate.Elapsed.TotalSeconds, 1);
                _processedFrames = 0;
                _droppedFrames = 0;
                _swUIUpdate.Restart();
                StateHasChanged();
            }
        }

        Queue<ImageData> _images = new Queue<ImageData>();
        int maxQueueSize = 4;

        private void _workerPool_OnBusyStateChanged(WebWorker sender, bool busy) {
            if (!busy) {
                TryProcessFrame();
            }
        }

        //bool _allThreadsBusy => _mainThreadProcessing && (_workerPool == null || !_workerPool.AreWorkersRunning) || (_workerPool != null && _workerPool.AreWorkersRunning && _workerPool.WorkersIdle == 0);
        bool _mainThreadProcessing = false;
        ImageData image;
        Size frameSize;
        void TryProcessFrame() {
            if (_images.Count == 0) return;
            //if (_allThreadsBusy) return;
            if (!_enableProcessing) {
                if (!_images.TryDequeue(out image)) {
                    return;
                }
                frameSize = new Size(image.Width, image.Height);
                if (_videoFrameSize != frameSize) {
                    _videoFrameSize = frameSize;
                    OnInputFrameResized();
                }
                if (_cameraCanvasProcessedElCtx != null && _cameraCanvasProcessedEl != null) {
                    _cameraCanvasProcessedEl.Width = frameSize.Width;
                    _cameraCanvasProcessedEl.Height = frameSize.Height;
                    _cameraCanvasProcessedElCtx.PutImageData(image, 0, 0);
                }
                image.Dispose();
                _processedFrames++;
                return;
            }
            bool isMainThead;
            IFaceAPIService faceAPIService;
            if (_workerPool == null || !_workerPool.AreWorkersRunning) {
                if (_mainThreadProcessing) {
                    return;
                }
                if (!_images.TryDequeue(out image)) {
                    return;
                }
                isMainThead = true;
                faceAPIService = _faceAPIService;
                _mainThreadProcessing = true;
            }
            else if (_workerPool.TryGetIdleWorker(out var worker)) {
                if (!_images.TryDequeue(out image)) {
                    _workerPool.ReleaseIdleWorker(worker);
                    return;
                }
                isMainThead = false;
                faceAPIService = worker.GetService<IFaceAPIService>();
            }
            else {
                return;
            }
            frameSize = new Size(image.Width, image.Height);
            using var data = image.Data;
            image.Dispose();
            var arrayBuffer = data.Buffer;
            var frameIndex = _frameIndex++;
            _ = faceAPIService.FaceDetection(arrayBuffer, frameSize.Width, frameSize.Height, _withLandmarks).ContinueWith((t) => {
                if (isMainThead) _mainThreadProcessing = false;
                try {
                    using var result = t.Result;
                    if (t.IsFaulted || t.IsCanceled || result == null || frameIndex < _frameIndexReported) {
                        return;
                    }
                    _processedFrames++;
                    _frameIndexReported = frameIndex;
                    if (_videoFrameSize != frameSize) {
                        _videoFrameSize = frameSize;
                        OnInputFrameResized();
                    }
                    var resultArrayBuffer = result.ArrayBuffer;
                    if (resultArrayBuffer != null && !resultArrayBuffer.IsWrapperDisposed && resultArrayBuffer.ByteLength > 0) {
                        using var uint8 = new Uint8Array(resultArrayBuffer);
                        using var imgData = ImageData.FromUint8Array(uint8, frameSize.Width, frameSize.Height);
                        if (_cameraCanvasProcessedElCtx != null && _cameraCanvasProcessedEl != null) {
                            _cameraCanvasProcessedEl.Width = frameSize.Width;
                            _cameraCanvasProcessedEl.Height = frameSize.Height;
                            _cameraCanvasProcessedElCtx.PutImageData(imgData, 0, 0);
                        }
                    }
                    if (_facesFnd != result.FacesFound) {
                        _facesFnd = result.FacesFound;
                        StateHasChanged();
                    }
                }
                finally {
                    arrayBuffer.Dispose();
                }
            });
            if (_images.Count > 0) {
                TryProcessFrame();
            }
        }

        private void _videoCapture_NewFrame() {
            if (_images.Count < maxQueueSize) {
                var imageData = _videoCapture.ReadImageData();
                if (imageData != null) {
                    _images.Enqueue(imageData);
                }
            }
            else {
                _droppedFrames++;
            }
            TryProcessFrame();
        }

        private void MediaDevicesService_OnDeviceInfosChanged(DeviceInfo[] deviceInfos) {
            _ = RefreshCameraList();
        }

        void CloseMediaStream() {
            if (_mediaStream == null) return;
            _mediaStream.StopAllTracks();
            _mediaStream.Dispose();
            _mediaStream = null;
        }

        async void OnDeviceChange(DeviceInfo? selected) {
            CloseMediaStream();
            if (_videoCapture != null) {
                _videoCapture.Video.Pause();
                _videoCapture.Video.SrcObject = null;
            }
            if (selected != null && _mediaDevicesService != null && _videoCapture != null) {
                _mediaStream = await _mediaDevicesService.GetMediaStream(videoDeviceId: selected.DeviceId);
                _videoCapture.Video.SrcObject = _mediaStream;
                try {
                    await _videoCapture.Video.Play();
                }
                catch (Exception ex) {
                    Console.WriteLine("Play error");
                }
            }
        }

        async Task RefreshCameraList() {
            await _mediaDevicesService.UpdateDeviceList();
            _devices = _mediaDevicesService.DeviceInfos.Where(o => o.Kind == "videoinput").ToList();
            StateHasChanged();
        }
        void OnInputFrameResized() {
            Console.WriteLine($"Camera input resized: {_videoFrameSize.Width}x{_videoFrameSize.Height}");
            if (_cameraCanvasProcessedEl != null) {
                _cameraCanvasProcessedEl.Width = _videoFrameSize.Width;
                _cameraCanvasProcessedEl.Height = _videoFrameSize.Height;
            }
        }

        public void Dispose() {
            _images.Clear();
            CloseMediaStream();
            _videoCapture.NewFrame -= _videoCapture_NewFrame;
            _workerPool.OnBusyStateChanged -= _workerPool_OnBusyStateChanged;

            _cameraCanvasProcessedElCtx?.Dispose();
            _cameraCanvasProcessedEl?.Dispose();
            _callbackGroup.Dispose();
            _mediaStream?.Dispose();
            _videoCapture?.Dispose();
        }
    }
}
