using SpawnDev.Blazor.UnitTesting;
using System.Diagnostics;

namespace SpawnDev.BlazorJS.Demo.UnitTests
{
    /// <summary>
    /// Interop hot-path microbenchmarks. Each test runs a FIXED workload of the interop layer's
    /// hottest call shapes, so the recorded test DURATION doubles as an A/B metric for
    /// SpawnDev.BlazorJS.lib.module.js / marshalling changes (compare durations across runs).
    /// These log throughput to the console and only FAIL on gross regressions (10x guard), so
    /// normal machine variance never reddens a run.
    /// </summary>
    [TestClass]
    public class InteropPerfTests
    {
        BlazorJSRuntime JS;
        public InteropPerfTests(BlazorJSRuntime js)
        {
            JS = js;
        }

        const int N = 1000;

        [TestMethod]
        public async Task InteropPerf_GlobalGet()
        {
            await Task.Delay(1); // let the test-runner UI render the running state before the sync loop blocks the thread
            JS.Set("_perfVal", 42);
            var sw = Stopwatch.StartNew();
            int v = 0;
            for (int i = 0; i < N; i++)
                v = JS.Get<int>("_perfVal");
            sw.Stop();
            if (v != 42) throw new Exception($"readback wrong: {v}");
            Report("GlobalGet", sw);
        }

        [TestMethod]
        public async Task InteropPerf_GlobalCall()
        {
            await Task.Delay(1); // let the test-runner UI render the running state before the sync loop blocks the thread
            var sw = Stopwatch.StartNew();
            double v = 0;
            for (int i = 0; i < N; i++)
                v = JS.Call<double>("Math.max", 1d, 2d);
            sw.Stop();
            if (v != 2d) throw new Exception($"result wrong: {v}");
            Report("GlobalCall", sw);
        }

        [TestMethod]
        public async Task InteropPerf_JSObjectCall()
        {
            await Task.Delay(1); // let the test-runner UI render the running state before the sync loop blocks the thread
            using var date = JS.New("Date");
            var sw = Stopwatch.StartNew();
            double v = 0;
            for (int i = 0; i < N; i++)
                v = date.Call<double>("getTime");
            sw.Stop();
            if (v <= 0) throw new Exception($"result wrong: {v}");
            Report("JSObjectCall", sw);
        }

        [TestMethod]
        public async Task InteropPerf_GlobalCallVoid()
        {
            await Task.Delay(1); // let the test-runner UI render the running state before the sync loop blocks the thread
            JS.Set("_perfSink", 0);
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < N; i++)
                JS.CallVoid("parseInt", "1");
            sw.Stop();
            Report("GlobalCallVoid", sw);
        }

        void Report(string label, Stopwatch sw)
        {
            double perOpUs = sw.Elapsed.TotalMilliseconds * 1000.0 / N;
            Console.WriteLine($"[InteropPerf] {label}: {N} ops in {sw.Elapsed.TotalMilliseconds:F0}ms = {perOpUs:F1}us/op ({N / sw.Elapsed.TotalSeconds:F0} ops/s)");
            // Gross-regression guard only: on interpreted (non-AOT) WASM a call is hundreds of
            // microseconds; 2000us/op means something is badly broken.
            if (perOpUs > 2000)
                throw new Exception($"{label} interop is grossly slow: {perOpUs:F1}us/op");
        }
    }
}
