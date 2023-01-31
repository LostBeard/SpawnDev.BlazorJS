using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.WebWorkers;
using System.Dynamic;

namespace SpawnDev.BlazorJS.Test.Services
{
    public class ProcessFrameResult : IDisposable
    {
        // below is unnecessary as by default transferable objects are transferred instead of copied (same for return values, and parameters)
        [WorkerTransfer(true)]
        public ArrayBuffer? ArrayBuffer { get; set; }
        public int FacesFound { get; set; }
        public void Dispose()
        {
            ArrayBuffer?.Dispose();
        }
    }
    public class FaceAPIService : IDisposable//, IOpenCVService
    {
        WebWorkerService _webWorkerService;
        WebWorkerPool _workerPool;
        public int MaxWorkerCount => _workerPool.MaxWorkerCount;
        HttpClient _httpClient;
        bool _beenInit = false;
        string AppBaseUri;
        string MODEL_URL = "weights";
        public FaceAPIService(NavigationManager navigator, WebWorkerService webWorkerService, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _webWorkerService = webWorkerService;
            // this worker pool belongs to this service
            // it could also be added as a service to be shared throughout the app
            _workerPool = new WebWorkerPool(webWorkerService);
            AppBaseUri = navigator.BaseUri;
            MODEL_URL = $"{AppBaseUri}{MODEL_URL}";
        }

        public async Task WhenReady()
        {
            if (_workerPool.AreWorkersRunning) await _workerPool.WhenWorkerReady();
            else while (ProcessFrameRunningLocal) await Task.Delay(5);
        }
        public bool IsReady => _workerPool.AreWorkersRunning ? _workerPool.IsReady : ProcessFrameRunningLocal;
        public int WorkersRunning => _workerPool.WorkersRunning;
        public int WorkerCountRequest
        {
            get => _workerPool == null ? 0 : _workerPool.WorkerCountRequest;
            set => _workerPool.WorkerCountRequest = value;
        }
        public int WorkersIdle => _workerPool.WorkersIdle;
        public Task<bool> SetWorkerCount(int count) => _workerPool.SetWorkerCount(count);

        bool ProcessFrameRunningLocal = false;
        public async Task<ProcessFrameResult?> FaceDetection(ArrayBuffer? frameBuffer, int width, int height)
        {
            try
            {
                if (_workerPool.AreWorkersRunning)
                {
                    var worker = await _workerPool.GetFreeWorkerAsync();
                    if (worker != null)
                    {
                        return await worker.InvokeAsync<FaceAPIService, ProcessFrameResult?>(nameof(FaceAPIService.FaceDetection), frameBuffer, width, height);
                    }
                }
                else if (!ProcessFrameRunningLocal)
                {
                    await Task.Delay(1);
                    ProcessFrameRunningLocal = true;
                    var ret = await FaceDetectionInternal(frameBuffer, width, height);
                    ProcessFrameRunningLocal = false;
                    return ret;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProcessFrame: " + ex.ToString());
            }
            return null;
        }

        static Task<T> GXThenAsync<T>(IJSInProcessObjectReference gxPromise)
        {
            var callbacks = new CallbackGroup();
            var t = new TaskCompletionSource<T>();
            using var promise = gxPromise.Call<IJSInProcessObjectReference>("then", Callback.Create<T>((e) =>
            {
                callbacks.Dispose();
                t.TrySetResult(e);
            }, callbacks));
            promise.CallVoid("catch", Callback.Create(() =>
            {
                callbacks.Dispose();
                t.TrySetException(new Exception("Failed"));
            }, callbacks));
            return t.Task;
        }

        private async Task<ProcessFrameResult?> FaceDetectionInternal(ArrayBuffer? frameBuffer, int width, int height)
        {
            var ret = new ProcessFrameResult();
            if (frameBuffer == null) return null;
            if (!_beenInit)
            {
                await InitAsync();
            }
            using var uint8 = new Uint8Array(frameBuffer);
            // the below only works if wbe workers becuase the faux environment will create an OffscreenCanvas instead of an HTMLCanvasElement if in a worker
            using var canvas = new HTMLCanvasElement(width, height);
            using var ctx = canvas.Get2DContext();
            using var imageData = ImageData.FromUint8Array(uint8, width, height);
            ctx.PutImageData(imageData, 0, 0);
            IJSInProcessObjectReference? detections = null;
            // detectAllFaces does not return an actual Promise ...
            // it returns an instance of "gx" (minified DetectAllFacesTask type) that has a "then" method property but NOT a "catch" method property
            // "then" will return a real promise that has the "catch" method property
            try
            {
                using var detectionsPromise = _faceapi.Call<Promise>("detectAllFaces", canvas);
                detections = await detectionsPromise.ThenAsync<IJSInProcessObjectReference>();
            }
            catch
            {
                // continue normally
            }
            if (detections != null)
            {
                JS.CallVoid("faceapi.draw.drawDetections", canvas, detections);
                var detectionsLength = detections.Get<int>("length");
                //for (var i = 0; i < detectionsLength; i++)
                //{
                //    // use detections
                //}
                ret.FacesFound = detectionsLength;
                detections.Dispose();
            }
            using var outImageData = ctx.GetImageData();
            using var uint8Clapmed = outImageData.Data;
            ret.ArrayBuffer = uint8Clapmed.Buffer;
            frameBuffer.Dispose();
            return ret;
        }

        IJSInProcessObjectReference? _faceapi = null;

        public async Task InitAsync()
        {
            if (_beenInit) return;
            _beenInit = true;
            // as of 2023-01-29 face-api.js does not support working in a worker. the fake dom environment created to enable Blazor in workers will also enable face-api.js
            // face-api.js has a function called isBrowser that will return false in a WebWorker if we don't add some of the types it checks for or requires
            // the webworker faux-env takes care of adding these types so convince scripts they are in a window environment
            // some scripts that already work fine in workers may not properly detect the worker environment due to our faux types
            // load lib
            await JS.LoadScript("libs/face-api.min.js", "faceapi");
            // get lib handle
            _faceapi = JS.Get<IJSInProcessObjectReference>("faceapi");
            // load models (load order matters ... load model before inference)
            await _faceapi.CallVoidAsync("loadSsdMobilenetv1Model", MODEL_URL);
            await _faceapi.CallVoidAsync("loadFaceLandmarkModel", MODEL_URL); // model to detect face landmark
            await _faceapi.CallVoidAsync("loadFaceRecognitionModel", MODEL_URL); //model to Recognise Face
            await _faceapi.CallVoidAsync("loadFaceExpressionModel", MODEL_URL); //model to detect face expression
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
