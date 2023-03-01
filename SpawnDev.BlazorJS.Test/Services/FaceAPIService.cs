using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.WebWorkers;
using System.Dynamic;

namespace SpawnDev.BlazorJS.Test.Services
{
    public class ProcessFrameResult : IDisposable
    {
        public ArrayBuffer? ArrayBuffer { get; set; }
        public int FacesFound { get; set; }
        public JSObject? Detections { get; set; }
        public void Dispose()
        {
            ArrayBuffer?.Dispose();
            Detections?.Dispose();
        }
    }
    public class FaceAPIService : IDisposable
    {
        WebWorkerService _webWorkerService;
        WebWorkerPool _workerPool;
        bool _beenInit = false;
        bool _processFrameRunningLocal = false;
        string _appBaseUri;
        string _modelPath = "weights";
        public int MaxWorkerCount => _workerPool.MaxWorkerCount;
        public bool IsReady => _workerPool.AreWorkersRunning ? _workerPool.IsReady : _processFrameRunningLocal;
        public int WorkersRunning => _workerPool.WorkersRunning;
        public int WorkerCountRequest
        {
            get => _workerPool == null ? 0 : _workerPool.WorkerCountRequest;
            set => _workerPool.WorkerCountRequest = value;
        }
        public int WorkersIdle => _workerPool.WorkersIdle;
        public Task<bool> SetWorkerCount(int count) => _workerPool.SetWorkerCount(count);

        IJSInProcessObjectReference? _faceapi = null;

        public FaceAPIService(NavigationManager navigator, WebWorkerService webWorkerService)
        {
            _webWorkerService = webWorkerService;
            // this worker pool belongs to this service
            // it could also be added as a service to be shared throughout the app
            _workerPool = new WebWorkerPool(webWorkerService);
            _appBaseUri = navigator.BaseUri;
            _modelPath = $"{_appBaseUri}{_modelPath}";
            _initTask = InitAsync();
        }

        Task _initTask;

        async Task InitAsync()
        {
            // load lib
            await JS.LoadScript("libs/face-api.min.js", "faceapi");
            // get lib handle
            _faceapi = JS.Get<IJSInProcessObjectReference>("faceapi");
            // load models
            await _faceapi.CallVoidAsync("loadSsdMobilenetv1Model", _modelPath);
            await _faceapi.CallVoidAsync("loadFaceRecognitionModel", _modelPath); //model to recognize Face
            await _faceapi.CallVoidAsync("loadFaceLandmarkModel", _modelPath); // model to detect face landmark
            //await _faceapi.CallVoidAsync("loadFaceExpressionModel", _modelPath); //model to detect face expression
        }
        

        public async Task WhenReady()
        {
            if (_workerPool.AreWorkersRunning) await _workerPool.WhenWorkerReady();
            else while (_processFrameRunningLocal) await Task.Delay(5);
        }

        public async Task<ProcessFrameResult?> FaceDetection(ArrayBuffer? frameBuffer, int width, int height, bool withLandmarks)
        {
            try
            {
                if (_workerPool.AreWorkersRunning)
                {
                    var worker = await _workerPool.GetFreeWorkerAsync();
                    if (worker != null)
                    {
                        return await worker.InvokeAsync<FaceAPIService, ProcessFrameResult?>(nameof(FaceAPIService.FaceDetection), frameBuffer, width, height, withLandmarks);
                    }
                }
                else if (!_processFrameRunningLocal)
                {
                    _processFrameRunningLocal = true;
                    await Task.Delay(1);
                    var ret = await FaceDetectionInternal(frameBuffer, width, height, withLandmarks);
                    _processFrameRunningLocal = false;
                    return ret;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProcessFrame: " + ex.ToString());
            }
            return null;
        }

        private async Task<ProcessFrameResult?> FaceDetectionInternal(ArrayBuffer? frameBuffer, int width, int height, bool withLandmarks)
        {
            var ret = new ProcessFrameResult();
            if (frameBuffer == null || width == 0 || height == 0) return null;
            await _initTask;
            using var uint8 = new Uint8Array(frameBuffer);
            // face-api.js wants an HTMLCanvasElement as input
            // the below works in web workers becuase the faux environment will create an OffscreenCanvas instead of an HTMLCanvasElement if in a worker
            using var canvas = new HTMLCanvasElement(width, height);
            using var ctx = canvas.Get2DContext(new ContextAttributes2D { WillReadFrequently = true });
            using var imageData = ImageData.FromUint8Array(uint8, width, height);
            ctx.PutImageData(imageData, 0, 0);
            JSObject? detections = null;
            try
            {
                using var detectAllFacesTask = _faceapi.Call<Promise>("detectAllFaces", canvas);
                if (withLandmarks)
                {
                    using var detectAllFacesWithLandmarksTask = detectAllFacesTask.JSRef.Call<Promise>("withFaceLandmarks");
                    detections = await detectAllFacesWithLandmarksTask.ThenAsync<JSObject>();
                }
                else
                {
                    detections = await detectAllFacesTask.ThenAsync<JSObject>();
                }
            }
            catch
            {
                // continue
            }
            if (detections != null)
            {
                // https://github.com/justadudewhohacks/face-api.js/#getting-started-displaying-detection-results
                _faceapi.CallVoid("draw.drawDetections", canvas, detections);
                if (withLandmarks)
                {
                    _faceapi.CallVoid("draw.drawFaceLandmarks", canvas, detections);
                }
                ret.FacesFound = detections.JSRef.Get<int>("length");
                ret.Detections = detections;
                detections.Dispose();
            }
            using var outImageData = ctx.GetImageData();
            using var uint8Clapmed = outImageData.Data;
            ret.ArrayBuffer = uint8Clapmed.Buffer;
            frameBuffer.Dispose();
            return ret;
        }

        public bool IsDisposed { get; private set; }
        public void Dispose()
        {
            if (IsDisposed) return;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            IsDisposed = true;
            if (disposing)
            {
                _workerPool.Dispose();
                _faceapi?.Dispose();
            }
        }
        ~FaceAPIService()
        {
            Dispose(false);
        }
    }
}
