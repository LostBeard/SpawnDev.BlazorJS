using OpenCvSharp;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.OpenCVSharp4;
using SpawnDev.BlazorJS.WebWorkers;
using System.Data.SqlTypes;
using System.Reflection;

namespace SpawnDev.BlazorJS.Test.Services
{
    public class ProcessFrameResult
    {
        // below is unnecessary as by defaul transferable objects are transferred instead of copied (same for return values, and paramters)
        [WorkerTransfer(true)]
        public ArrayBuffer? ArrayBuffer { get; set; }
        public int FacesFound { get; set; }
    }
    public class FaceFeature
    {
        public Rect Face { get; set; }
        public Rect[] Eyes { get; set; } = new Rect[0];
    }
    // https://github.com/Tewr/BlazorWorker
    public class OpenCVService : IOpenCVService, IDisposable
    {
        WebWorkerService _webWorkerService;
        WebWorkerPool _workerPool;
        public int MaxWorkerCount => _workerPool.MaxWorkerCount;
        HttpClient _httpClient;

        CascadeClassifier? face_cascade = null;
        CascadeClassifier? eyes_cascade = null;

        public OpenCVService(WebWorkerService webWorkerService, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _webWorkerService = webWorkerService;
            // this worker pool belongs to this service
            // it could also be added as a service to be shared throughout the app
            _workerPool = new WebWorkerPool(webWorkerService);
        }

        // https://github.com/opencv/opencv/tree/master/data/haarcascades
        // https://github.com/VahidN/OpenCVSharp-Samples/blob/master/OpenCVSharpSample15/Program.cs
        // https://www.tech-quantum.com/have-fun-with-webcam-and-opencv-in-csharp-part-2/
        // TODO - test this !
        public List<FaceFeature> FaceDetect(Mat image)
        {
            var features = new List<FaceFeature>();
            var faces = DetectFaces(image);
            foreach (var item in faces)
            {
                //Get the region of interest where you can find facial features
                using Mat face_roi = image[item];
                //Detect eyes
                Rect[] eyes = DetectEyes(face_roi);
                //Record the facial features in a list
                features.Add(new FaceFeature()
                {
                    Face = item,
                    Eyes = eyes
                });
            }
            return features;
        }

        private void MarkFeatures(Mat image, List<FaceFeature> features)
        {
            foreach (FaceFeature feature in features)
            {
                Cv2.Rectangle(image, feature.Face, new Scalar(0, 255, 0), thickness: 1);
                using var face_region = image[feature.Face];
                foreach (var eye in feature.Eyes)
                {
                    Cv2.Rectangle(face_region, eye, new Scalar(255, 0, 0), thickness: 1);
                }
            }
        }

        private Rect[] DetectEyes(Mat image)
        {
            if (eyes_cascade == null)
            {
                eyes_cascade = new CascadeClassifier("./haarcascades/haarcascade_eye.xml");
            }
            Rect[] faces = eyes_cascade == null ? new Rect[0] : eyes_cascade.DetectMultiScale(image, 1.3, 5);
            return faces;
        }

        private Rect[] DetectFaces(Mat image)
        {
            if (face_cascade == null)
            {
                face_cascade = new CascadeClassifier("./haarcascades/haarcascade_frontalface_default.xml");
            }
            Rect[] faces = face_cascade == null ? new Rect[0] : face_cascade.DetectMultiScale(image, 1.3, 5);
            return faces;
        }

        public async Task WhenReady()
        {
            if (_workerPool.AreWorkersRunning) await _workerPool.WhenWorkerReady();
            else while (ProcessFrameRunningLocal) await Task.Delay(5);
        }
        public bool IsReady => _workerPool.AreWorkersRunning ? _workerPool.IsReady : ProcessFrameRunningLocal;
        public int WorkerCount => _workerPool.WorkersRunning;
        public Task<bool> SetWorkerCount(int count) => _workerPool.SetWorkerCount(count);

        // incoming parameters and return values are checked to see if they are transferable types and are automatically transferred added to the transferable postMessage list


        bool ProcessFrameRunningLocal = false;
        [return: WorkerTransfer(true)]
        public async Task<ProcessFrameResult?> FaceDetection([WorkerTransfer(true)] ArrayBuffer? frameBuffer, int width, int height)
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
                else
                {
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


        Dictionary<string, CascadeClassifierCache> _cascadeClassifiers = new Dictionary<string, CascadeClassifierCache>();
        class CascadeClassifierCache : IDisposable
        {
            public FileStorage? FileStorage { get; private set; }
            public FileNode? RootNode { get; private set; }
            public CascadeClassifier? CascadeClassifier { get; private set; }
            public bool IsLoaded => CascadeClassifier != null;
            public CascadeClassifierCache(string xml)
            {
                if (!string.IsNullOrEmpty(xml))
                {
                    FileStorage = new FileStorage(".xml", FileStorage.Modes.Memory | FileStorage.Modes.Write);
                    FileStorage.Open(xml, FileStorage.Modes.Read | FileStorage.Modes.Memory);
                    if (FileStorage.IsOpened())
                    {
                        // The below line returns the xml I wrote
                        //var xmlTest = FileStorage.ReleaseAndGetString();
                        RootNode = FileStorage.GetFirstTopLevelNode();
                        if (RootNode != null)
                        {
                            var tmp = new CascadeClassifier();
                            if (tmp.Read(RootNode))
                            {
                                // gets here without any problems
                                // but errors when I try top use the CascadeClassifier
                                CascadeClassifier = tmp;
                            }
                        }
                    }
                }
            }

            public void Dispose()
            {
                FileStorage?.Dispose();
                RootNode?.Dispose();
                CascadeClassifier?.Dispose();
                FileStorage = null;
                RootNode = null;
                CascadeClassifier = null;
            }
        }
        public async Task<CascadeClassifier?> GetCascadeClassifer(string url)
        {
            CascadeClassifier? ret = null;
            if (_cascadeClassifiers.TryGetValue(url, out CascadeClassifierCache tmp)) return tmp.CascadeClassifier;
            try
            {
                var xml = await _httpClient.GetStringAsync(url);
                if (!string.IsNullOrEmpty(xml))
                {
                    var tmp1 = new CascadeClassifierCache(xml);
                    _cascadeClassifiers[url] = tmp1;
                    ret = tmp1.CascadeClassifier;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret;
        }

        private async Task<ProcessFrameResult?> FaceDetectionInternal(ArrayBuffer? frameBuffer, int width, int height)
        {
            ProcessFrameResult ret = new ProcessFrameResult();
            if (frameBuffer == null) return null;
            using var srcImage = new Mat(new Size(width, height), MatType.CV_8UC4);
            try
            {
                srcImage.SetRGBAArrayBuffer(frameBuffer);
            }
            catch
            {
                return ret;
            }
            using var grayImage = srcImage.CvtColor(ColorConversionCodes.RGBA2GRAY);
            if (face_cascade == null)
            {
                face_cascade = await GetCascadeClassifer("haarcascades/haarcascade_frontalface_default.xml");
            }
            if (face_cascade == null)
            {
                return ret;
            }
            if (eyes_cascade == null)
            {
                eyes_cascade = await GetCascadeClassifer("haarcascades/haarcascade_eye.xml");
            }
            if (eyes_cascade == null)
            {
                return ret;
            }
            Rect[] faces = face_cascade.DetectMultiScale(grayImage, 1.3, 5);
            var red = new Scalar(255, 0, 0, 255);
            var blue = new Scalar(0, 0, 255, 255);
            foreach (var faceRect in faces)
            {
                // draw rect aroun dthe face
                Cv2.Rectangle(srcImage, faceRect, red, 3);
                // find eyes in the face
                using var detectedFaceGray = new Mat(grayImage, faceRect);
                var nestedObjects = eyes_cascade.DetectMultiScale(
                    detectedFaceGray,
                    scaleFactor: 1.1,
                    minNeighbors: 2,
                    flags: HaarDetectionTypes.DoRoughSearch | HaarDetectionTypes.ScaleImage,
                    minSize: new Size(30, 30)
                    );

                foreach (var nestedObject in nestedObjects)
                {
                    var center = new Point
                    {
                        X = (int)(Math.Round(nestedObject.X + nestedObject.Width * 0.5, MidpointRounding.ToEven) + faceRect.Left),
                        Y = (int)(Math.Round(nestedObject.Y + nestedObject.Height * 0.5, MidpointRounding.ToEven) + faceRect.Top)
                    };
                    var radius = Math.Round((nestedObject.Width + nestedObject.Height) * 0.25, MidpointRounding.ToEven);
                    Cv2.Circle(srcImage, center, (int)radius, blue, thickness: 3);
                }
            }
            ret.FacesFound = faces.Count();
            ret.ArrayBuffer = srcImage.GetRGBAArrayBuffer();
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
                face_cascade?.Dispose();
                eyes_cascade?.Dispose();
            }
        }
        ~OpenCVService()
        {
            Dispose(false);
        }
    }
}
