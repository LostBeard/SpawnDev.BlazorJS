using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.WebWorkers;
using System.Net.Http;
using SpawnDev.BlazorJS.OpenCVJS;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;
using OpenCvSharp.Dnn;

namespace SpawnDev.BlazorJS.Test.Services
{
    public class FaceAPIService : IDisposable//, IOpenCVService
    {
        WebWorkerService _webWorkerService;
        WebWorkerPool _workerPool;
        public int MaxWorkerCount => _workerPool.MaxWorkerCount;
        HttpClient _httpClient;
        bool _beenInit = false;
        public FaceAPIService(WebWorkerService webWorkerService, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _webWorkerService = webWorkerService;
            // this worker pool belongs to this service
            // it could also be added as a service to be shared throughout the app
            _workerPool = new WebWorkerPool(webWorkerService);
        }

        public async Task WhenReady()
        {
            if (_workerPool.AreWorkersRunning) await _workerPool.WhenWorkerReady();
            else while (ProcessFrameRunningLocal) await Task.Delay(5);
        }
        public bool IsReady => _workerPool.AreWorkersRunning ? _workerPool.IsReady : ProcessFrameRunningLocal;
        public int WorkersRunning => _workerPool.WorkersRunning;
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
                        return await worker.InvokeAsync<OpenCVService, ProcessFrameResult?>(nameof(OpenCVService.FaceDetection), frameBuffer, width, height);
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

        private async Task<ProcessFrameResult?> FaceDetectionInternal(ArrayBuffer? frameBuffer, int width, int height)
        {
            var ret = new ProcessFrameResult();
            if (frameBuffer == null) return null;
            if (!_beenInit)
            {
                await InitAsync();
            }
            using var uint8 = new Uint8Array(frameBuffer);
            using var canvas = HTMLCanvasElement.Create(width, height);
            using var ctx = canvas.Get2DContext();
            using var imageData = ImageData.FromUint8Array(uint8, width, height);
            ctx.PutImageData(imageData, 0, 0);
            IJSInProcessObjectReference? detections = null;
            var detectionsPromise = _faceapi.Call<Promise>("detectAllFaces", canvas);
            var holder = new SemaphoreSlim(1);
            _ = holder.WaitAsync();  // take the only ticket
            detectionsPromise.Then(Callback.CreateOne<IJSInProcessObjectReference>((ev) =>
            {
                detections = ev;
                holder.Release();
            }));
            await holder.WaitAsync();
            holder.Release();
            holder.Dispose();
            //var detections = await detectionsPromise.ThenAsync<IJSInProcessObjectReference>();
            if (detections != null)
            {
                // faceapi.draw.drawDetections(canvas, faceDescriptions)
                //using var draw = _faceapi.Get<IJSInProcessObjectReference>("draw");
                //draw.CallVoid("drawDetections", canvas, detections);
                JS.CallVoid("faceapi.draw.drawDetections", canvas, detections);
                //faceDescriptions = faceapi.resizeResults(faceDescriptions, img)
                // .withFaceLandmarks().withFaceDescriptors().withFaceExpressions()
                var detectionsLength = detections.Get<int>("length");
                for (var i = 0; i < detectionsLength; i++)
                {

                }
                ret.FacesFound = detectionsLength;
            }
            using var outImageData = ctx.GetImageData();
            using var uint8Clapmed = outImageData.Data;
            ret.ArrayBuffer = uint8Clapmed.Buffer;
            return ret;
        }

        IJSInProcessObjectReference? _faceapi = null;

        string MODEL_URL = "./weights";

        public async Task InitAsync()
        {
            if (_beenInit) return;
            _beenInit = true;
            // load lib
            await JS.LoadScript("libs/face-api.min.js", "faceapi");
            // get lib handle
            _faceapi = JS.Get<IJSInProcessObjectReference>("faceapi");
            // load models
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
