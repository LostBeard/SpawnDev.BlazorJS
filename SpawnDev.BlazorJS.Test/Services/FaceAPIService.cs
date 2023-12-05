using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

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

    public interface IFaceAPIService
    {
        void Dispose();
        Task<ProcessFrameResult?> FaceDetection(ArrayBuffer? frameBuffer, int width, int height, bool withLandmarks);
    }

    public class FaceAPIService : IDisposable, IFaceAPIService, IBackgroundService
    {
        string _appBaseUri;
        string _modelPath = "weights";
        IJSInProcessObjectReference? _faceapi = null;
        BlazorJSRuntime JS;
        Task? _initTask = null;
        public FaceAPIService(BlazorJSRuntime js, NavigationManager navigator)
        {
            JS = js;
            _appBaseUri = navigator.BaseUri;
            _modelPath = $"{_appBaseUri}{_modelPath}";
            _initTask = InitAsync();
        }

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

        // The first time this is called it loads the weights which can take few seconds
        public async Task<ProcessFrameResult?> FaceDetection(ArrayBuffer? frameBuffer, int width, int height, bool withLandmarks)
        {
            var ret = new ProcessFrameResult();
            if (frameBuffer == null || width == 0 || height == 0) return null;
            await _initTask!;
            if (_faceapi == null) return null;
            using var uint8 = new Uint8Array(frameBuffer);
            // face-api.js wants an HTMLCanvasElement as input
            // the below works in web workers because the faux environment will create an OffscreenCanvas instead of an HTMLCanvasElement if in a worker
            using var canvas = new HTMLCanvasElement(width, height);
            using var ctx = canvas.Get2DContext(new ContextAttributes2D { WillReadFrequently = true });
            using var imageData = ImageData.FromUint8Array(uint8, width, height);
            ctx.PutImageData(imageData, 0, 0);
            JSObject? detections = null;
            try
            {
                if (withLandmarks)
                {
                    using var detectAllFacesTask = _faceapi.Call<JSObject>("detectAllFaces", canvas);
                    detections = await detectAllFacesTask.JSRef!.CallAsync<JSObject>("withFaceLandmarks");
                }
                else
                {
                    detections = await _faceapi.CallAsync<JSObject>("detectAllFaces", canvas);
                }
                //using var detectAllFacesTask = _faceapi.Call<Promise>("detectAllFaces", canvas);
                //if (withLandmarks) {
                //    using var detectAllFacesWithLandmarksTask = detectAllFacesTask.JSRef.Call<Promise>("withFaceLandmarks");
                //    detections = await detectAllFacesWithLandmarksTask.ThenAsync<JSObject>();
                //}
                //else {
                //    detections = await detectAllFacesTask.ThenAsync<JSObject>();
                //}
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
            IsDisposed = true;
            _faceapi?.Dispose();
            _faceapi = null;
        }
    }
}
