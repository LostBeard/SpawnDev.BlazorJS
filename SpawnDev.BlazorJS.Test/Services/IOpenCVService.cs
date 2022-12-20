//using OpenCvSharp;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Test.Services
{
    public interface IOpenCVService
    {
        bool IsReady { get; }
        int MaxWorkerCount { get; }
        int WorkerCount { get; }

        Task<ProcessFrameResult?> FaceDetection(ArrayBuffer? frameBuffer, int width, int height);
        Task<bool> SetWorkerCount(int count);
        Task WhenReady();
    }
}