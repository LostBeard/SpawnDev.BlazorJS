//using OpenCvSharp;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.WebWorkers;
using System.Net.Http;
using SpawnDev.BlazorJS.OpenCVJS;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;

namespace SpawnDev.BlazorJS.Test.Services
{

    public class OpenCVJSService : IDisposable, IOpenCVService
    {
        WebWorkerService _webWorkerService;
        WebWorkerPool _workerPool;
        public int MaxWorkerCount => _workerPool.MaxWorkerCount;
        HttpClient _httpClient;
        bool _beenInit = false;
        public OpenCVJSService(WebWorkerService webWorkerService, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _webWorkerService = webWorkerService;
            // this worker pool belongs to this service
            // it could also be added as a service to be shared throughout the app
            _workerPool = new WebWorkerPool(webWorkerService);
        }
        public async Task InitAsync()
        {
            if (_beenInit) return;
            _beenInit = true;
            // of course we can't jsut load the opencv.js lib without problems... lol
            // apparentyl the fact that a wasm app has already been loaded breaks it's loading so we have to try and work around that issue
            // so...
            // copy Module
            var moduleOrig = JS.Get<IJSInProcessObjectReference>("Module");
            // null Module
            JS.Set("Module", null);
            // load opencv.js
            await JS.LoadScript("libs/opencv.js", "cv");
            //await JS.LoadScript("libs/utils.js", "cv");
            // restore Module
            JS.Set("Module", moduleOrig);
            while (JS.IsUndefined("cv.Mat"))
            {
                // some parts of cv do not load synchronously (I discovered)
                Console.WriteLine("Waiting for cv.Mat");
                await Task.Delay(500);
            }
        }

        public async Task WhenReady()
        {
            if (_workerPool.AreWorkersRunning) await _workerPool.WhenWorkerReady();
            else while (ProcessFrameRunningLocal) await Task.Delay(5);
        }
        public bool IsReady => _workerPool.AreWorkersRunning ? _workerPool.IsReady : ProcessFrameRunningLocal;
        public int WorkerCount => _workerPool.WorkersRunning;
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

        Dictionary<string, dynamic> _preloadedClassifers = new();
        async Task<dynamic?> GetCascadeClassifer(string url)
        {
            var path = Path.GetFileName(new Uri(_httpClient.BaseAddress, url).LocalPath);
            if (_preloadedClassifers.TryGetValue(path, out var ret1)) return ret1;
            var data = await _httpClient.GetByteArrayAsync(url);
            using dynamic cv = JS.Get<JSDynamicObject>("cv");
            cv.FS_createDataFile('/', path, data, true, false, false);
            dynamic cascade = new JSDynamicObject("cv.CascadeClassifier");
            cascade.load(path);
            _preloadedClassifers.Add(path, cascade);
            return cascade;
        }

        private async Task<ProcessFrameResult?> FaceDetectionInternal(ArrayBuffer? frameBuffer, int width, int height)
        {
            ProcessFrameResult ret = new ProcessFrameResult();
            if (frameBuffer == null) return null;
            if (!_beenInit)
            {
                await InitAsync();
            }
            var facesCount = 0;
            dynamic cv = JS.Get<JSDynamicObject>("cv");
            using var uint8 = new Uint8Array(frameBuffer);
            //using var canvas = HTMLCanvasElement.Create(width, height);
            //using var ctx = canvas.Get2DContext();
            //using var imageData = ImageData.FromUint8Array(uint8, width, height);
            //ctx.PutImageData(imageData, 0, 0);
            dynamic src = new JSDynamicObject("cv.Mat", width, height, cv.CV_8UC4<int>());
            dynamic srcData = src.data<JSDynamicObject>();
            srcData.set(uint8);
            dynamic gray = new JSDynamicObject("cv.Mat");
            cv.cvtColor(src, gray, cv.COLOR_RGBA2GRAY<int>(), 0);
            //dynamic faces = new JSDynamicObject("cv.RectVector");
            //dynamic eyes = new JSDynamicObject("cv.RectVector");
            //dynamic faceCascade = await GetCascadeClassifer("haarcascades/haarcascade_frontalface_default.xml");
            //dynamic eyeCascade = await GetCascadeClassifer("haarcascades/haarcascade_eye.xml");
            //dynamic msize = new JSDynamicObject("cv.Size", 0, 0);
            //faceCascade.detectMultiScale(gray, faces, 1.1, 3, 0, msize, msize);
            //facesCount = faces.size<int>();
            //for (var i = 0; i < facesCount; ++i)
            //{
            //    dynamic roiGray = gray.roi<JSDynamicObject>(faces.get<JSDynamicObject>(i));
            //    dynamic roiSrc = src.roi<JSDynamicObject>(faces.get<JSDynamicObject>(i));
            //    dynamic point1 = new JSDynamicObject("cv.Point", faces.get<JSDynamicObject>(i).x<int>(), faces.get<JSDynamicObject>(i).y<int>());
            //    dynamic point2 = new JSDynamicObject("cv.Point", faces.get<JSDynamicObject>(i).x<int>() + faces.get<JSDynamicObject>(i).width<int>(), faces.get<JSDynamicObject>(i).y<int>() + faces.get<JSDynamicObject>(i).height<int>());
            //    cv.rectangle(src, point1, point2, new int[] { 255, 0, 0, 255 });
            //    // detect eyes in face ROI
            //    eyeCascade.detectMultiScale(roiGray, eyes);
            //    for (var j = 0; j < eyes.size<int>(); ++j)
            //    {
            //        dynamic point1a = new JSDynamicObject("cv.Point", eyes.get<JSDynamicObject>(j).x<int>(), eyes.get<JSDynamicObject>(j).y<int>());
            //        dynamic point2a = new JSDynamicObject("cv.Point", eyes.get<JSDynamicObject>(j).x<int>() + eyes.get<JSDynamicObject>(j).width<int>(), eyes.get<JSDynamicObject>(j).y<int>() + eyes.get<JSDynamicObject>(j).height<int>());
            //        cv.rectangle(roiSrc, point1a, point2a, new uint[] { 0, 0, 255, 255 });
            //    }
            //    roiGray.delete();
            //    roiSrc.delete();
            //}
            //faces.delete();
            //eyes.delete();

            cv.cvtColor(gray, src, cv.COLOR_GRAY2RGBA<int>(), 0);

            uint8.JSRef.CallVoid("set", (object)srcData);

            ret.ArrayBuffer = frameBuffer;
            ret.FacesFound = facesCount;

            src.delete();
            gray.delete();

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
                foreach (var cascade in _preloadedClassifers.Values)
                {
                    cascade.delete();
                    cascade.Dispose();
                }
                _preloadedClassifers.Clear();
            }
        }
        ~OpenCVJSService()
        {
            Dispose(false);
        }
    }
}
