//using Microsoft.JSInterop;
//using SpawnDev.BlazorJS.JSObjects;
//using SpawnDev.BlazorJS.WebWorkers;
//using System.Net.Http;
//using SpawnDev.BlazorJS.OpenCVJS;
//using System.Xml.Serialization;
//using static System.Runtime.InteropServices.JavaScript.JSType;
//using System.Linq;
//using Microsoft.ML;
//using Microsoft.ML.OnnxRuntime;
//using Microsoft.ML.Transforms;
//using static Microsoft.ML.Transforms.Image.ImageResizingEstimator;
//using Microsoft.ML.Data;
//using SpawnDev.BlazorJS.Test.Services.MLNet;
//using Microsoft.ML.Transforms.Onnx;

//namespace SpawnDev.BlazorJS.Test.Services
//{
//    public class MLNetService : IDisposable, IOpenCVService
//    {
//        WebWorkerService _webWorkerService;
//        WebWorkerPool _workerPool;
//        public int MaxWorkerCount => _workerPool.MaxWorkerCount;
//        HttpClient _httpClient;
//        bool _beenInit = false;
//        public MLNetService(WebWorkerService webWorkerService, HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//            _webWorkerService = webWorkerService;
//            // this worker pool belongs to this service
//            // it could also be added as a service to be shared throughout the app
//            _workerPool = new WebWorkerPool(webWorkerService);
//        }

//        public async Task WhenReady()
//        {
//            if (_workerPool.AreWorkersRunning) await _workerPool.WhenWorkerReady();
//            else while (ProcessFrameRunningLocal) await Task.Delay(5);
//        }
//        public bool IsReady => _workerPool.AreWorkersRunning ? _workerPool.IsReady : ProcessFrameRunningLocal;
//        public int WorkerCount => _workerPool.WorkersRunning;
//        public Task<bool> SetWorkerCount(int count) => _workerPool.SetWorkerCount(count);

//        bool ProcessFrameRunningLocal = false;
//        public async Task<ProcessFrameResult?> FaceDetection(ArrayBuffer? frameBuffer, int width, int height)
//        {
//            try
//            {
//                if (_workerPool.AreWorkersRunning)
//                {
//                    var worker = await _workerPool.GetFreeWorkerAsync();
//                    if (worker != null)
//                    {
//                        return await worker.InvokeAsync<OpenCVService, ProcessFrameResult?>(nameof(OpenCVService.FaceDetection), frameBuffer, width, height);
//                    }
//                }
//                else
//                {
//                    ProcessFrameRunningLocal = true;
//                    var ret = await FaceDetectionInternal(frameBuffer, width, height);
//                    ProcessFrameRunningLocal = false;
//                    return ret;
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("ProcessFrame: " + ex.ToString());
//            }
//            return null;
//        }

//        private async Task<ProcessFrameResult?> FaceDetectionInternal(ArrayBuffer? frameBuffer, int width, int height)
//        {
//            ProcessFrameResult ret = new ProcessFrameResult();
//            if (frameBuffer == null) return null;
//            if (!_beenInit)
//            {
//                await InitAsync();
//            }

//            return ret;
//        }

//        TransformerChain<OnnxTransformer>? _model = null;
//        PredictionEngine<YoloV4BitmapData, YoloV4Prediction>? _predictionEngine { get; set; }

//        public async Task InitAsync()
//        {
//            if (_beenInit) return;
//            _beenInit = true;
//            MLContext mlContext = new MLContext();

//            // model is available here:
//            // https://github.com/onnx/models/tree/master/vision/object_detection_segmentation/yolov4
//            string modelPath = @"D:\MachineLearning\Models\yolo_models\yolov4.onnx";

//            // Define scoring pipeline
//            var pipeline = mlContext.Transforms.ResizeImages(inputColumnName: "ImageSource", outputColumnName: "input_1:0", imageWidth: 416, imageHeight: 416, resizing: ResizingKind.IsoPad)
//                .Append(mlContext.Transforms.ExtractPixels(outputColumnName: "input_1:0", scaleImage: 1f / 255f, interleavePixelColors: true))
//                .Append(mlContext.Transforms.ApplyOnnxModel(
//                    shapeDictionary: new Dictionary<string, int[]>()
//                    {
//                        { "input_1:0", new[] { 1, 416, 416, 3 } },
//                        { "Identity:0", new[] { 1, 52, 52, 3, 85 } },
//                        { "Identity_1:0", new[] { 1, 26, 26, 3, 85 } },
//                        { "Identity_2:0", new[] { 1, 13, 13, 3, 85 } },
//                    },
//                    inputColumnNames: new[]
//                    {
//                        "input_1:0"
//                    },
//                    outputColumnNames: new[]
//                    {
//                        "Identity:0",
//                        "Identity_1:0",
//                        "Identity_2:0"
//                    },
//                    modelFile: modelPath, recursionLimit: 100));
//            // Fit on empty list to obtain input data schema
//            _model = pipeline.Fit(mlContext.Data.LoadFromEnumerable(new List<YoloV4BitmapData>()));

//            // Create prediction engine
//            _predictionEngine = mlContext.Model.CreatePredictionEngine<YoloV4BitmapData, YoloV4Prediction>(_model);
//        }
//        public bool IsDisposed { get; private set; }
//        public void Dispose()
//        {
//            if (IsDisposed) return;
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//        protected virtual void Dispose(bool disposing)
//        {
//            if (IsDisposed) return;
//            IsDisposed = true;
//            if (disposing)
//            {
//                _workerPool.Dispose();

//            }
//        }
//        ~MLNetService()
//        {
//            Dispose(false);
//        }
//    }
//}
