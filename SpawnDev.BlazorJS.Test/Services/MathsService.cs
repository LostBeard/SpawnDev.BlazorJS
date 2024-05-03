﻿using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BlazorJS.WebWorkers;
using System.Diagnostics;

namespace SpawnDev.BlazorJS.Test.Services
{
    public class PiProgress
    {
        public int Progress { get; set; }
    }
    public class CalculatePiProgress
    {
        public int Progress { get; set; }
    }

    public interface IMathsService {
        Task<string> CalculatePi(int digits);
        Task<string> CalculatePiWithActionProgress(int digits, Action<int>? progress = null);
        Task<double> EstimatePI(int sumLength);
        Task<double> EstimatePISlice(int sumStart, int sumLength);
        Task SetValueTest(string newValue);
        Task<string> GetValueTest();
        Task<string> ReadAppSettingsValue(string key);
        Task<double> TestMultiSigMethod(double value);
        Task<string> TestMultiSigMethod(string value);
        Task<double> TestMultiSigMethod(int value);
        Task<string> TestMultiSigMethod(string value, double dblValue);

        Task<T2> TestGenerics<T1, T2>(T1 value1, T2 value2);

        Task CancellationTokenTest(double maxRuntimeMS, CancellationToken token);
    }

    public class MathsService : IMathsService {
        WebWorkerService _webWorkerService;
        WebAssemblyHostConfiguration _configuration;
        public MathsService(WebWorkerService webWorkerService, WebAssemblyHostConfiguration configuration) {
            _webWorkerService = webWorkerService;
            _configuration = configuration;
        }

        // nicholas on StackOverflow
        // https://stackoverflow.com/questions/11677369/how-to-calculate-pi-to-n-number-of-places-in-c-sharp-using-loops
        public async Task<string> CalculatePi(int digits) {
            var sw = new Stopwatch();
            sw.Restart();
            digits++;
            uint[] x = new uint[digits * 10 / 3 + 2];
            uint[] r = new uint[digits * 10 / 3 + 2];
            uint[] pi = new uint[digits];
            for (int j = 0; j < x.Length; j++) x[j] = 20;
            for (int i = 0; i < digits; i++) {
                uint carry = 0;
                for (int j = 0; j < x.Length; j++) {
                    uint num = (uint)(x.Length - j - 1);
                    uint dem = num * 2 + 1;
                    x[j] += carry;
                    uint q = x[j] / dem;
                    r[j] = x[j] % dem;
                    carry = q * num;
                }
                pi[i] = (x[x.Length - 1] / 10);
                r[x.Length - 1] = x[x.Length - 1] % 10;
                for (int j = 0; j < x.Length; j++) x[j] = r[j] * 10;
            }
            var result = "";
            uint c = 0;
            for (int i = pi.Length - 1; i >= 0; i--) {
                pi[i] += c;
                c = pi[i] / 10;
                result = (pi[i] % 10).ToString() + result;
                // Put delays in progress for performance reasons
            }
            return result;
        }

        public async Task CancellationTokenTest(double maxRuntimeMS, CancellationToken token)
        {
            var tokenCanBeCanceled = token.CanBeCanceled;
            Console.WriteLine($"token.CanBeCanceled: {tokenCanBeCanceled} token.IsCancellationRequested: {token.IsCancellationRequested}");
            var startTime = DateTime.Now;
            var maxRunTime = TimeSpan.FromMilliseconds(maxRuntimeMS);
            while (DateTime.Now - startTime < maxRunTime)
            {
                // do some work (fake here)
                await Task.Delay(50);
                // check is cancel message received
                await token.ThrowIfCancellationRequestedAsync();
            }
        }

        public async Task<string> CalculatePiWithActionProgress(int digits, Action<int>? progress = null) {
            var sw = new Stopwatch();
            sw.Restart();
            digits++;
            uint[] x = new uint[digits * 10 / 3 + 2];
            uint[] r = new uint[digits * 10 / 3 + 2];
            uint[] pi = new uint[digits];
            for (int j = 0; j < x.Length; j++) x[j] = 20;
            for (int i = 0; i < digits; i++) {
                uint carry = 0;
                for (int j = 0; j < x.Length; j++) {
                    uint num = (uint)(x.Length - j - 1);
                    uint dem = num * 2 + 1;
                    x[j] += carry;
                    uint q = x[j] / dem;
                    r[j] = x[j] % dem;
                    carry = q * num;
                }
                pi[i] = (x[x.Length - 1] / 10);
                r[x.Length - 1] = x[x.Length - 1] % 10;
                for (int j = 0; j < x.Length; j++) x[j] = r[j] * 10;
                if (sw.Elapsed.TotalMilliseconds > 200) {
                    progress?.Invoke(i);
                    sw.Restart();
                }
            }
            var result = "";
            uint c = 0;
            for (int i = pi.Length - 1; i >= 0; i--) {
                pi[i] += c;
                c = pi[i] / 10;
                result = (pi[i] % 10).ToString() + result;
            }
            return result;
        }

        private IEnumerable<int> AlternatingSequence(int start = 0) {
            int i;
            bool flip;
            if (start == 0) {
                yield return 1;
                i = 1;
                flip = false;
            }
            else {
                i = (start * 2) - 1;
                flip = start % 2 == 0;
            }

            while (true) yield return ((flip = !flip) ? -1 : 1) * (i += 2);
        }

        public async Task<double> EstimatePI(int sumLength) {
            var lastReport = 0;
            await Task.Delay(100);
            return (4 * AlternatingSequence().Take(sumLength)
                .Select((x, i) => {
                    // Keep reporting events down a bit, serialization is expensive!
                    var progressDelta = (Math.Abs(i - lastReport) / (double)sumLength) * 100;
                    if (progressDelta > 3 || i >= sumLength - 1) {
                        lastReport = i;
                        _webWorkerService.SendEventToParents("progress", new PiProgress() { Progress = i });
                    }
                    return x;
                })
                .Sum(x => 1.0 / x));
        }

        public async Task<double> EstimatePISlice(int sumStart, int sumLength) {
            Console.WriteLine($"EstimatePISlice({sumStart},{sumLength})");
            var lastReport = 0;
            return AlternatingSequence(sumStart)
                .Take(sumLength)
                .Select((x, i) => {

                    // Keep reporting events down a bit, serialization is expensive!
                    var progressDelta = (Math.Abs(i - lastReport) / (double)sumLength) * 100;
                    if (progressDelta > 3 || i >= sumLength - 1) {
                        lastReport = i;
                        _webWorkerService.SendEventToParents("progress", new PiProgress() { Progress = i });
                    }
                    return x;
                })
                .Sum(x => 1.0 / x);
        }

        string TestValue = "orig";

        public Task SetValueTest(string newValue)
        {
            TestValue = newValue;
            return Task.CompletedTask;
        }

        public Task<string> GetValueTest()
        {
            return Task.FromResult(TestValue);
        }

        public Task<string> ReadAppSettingsValue(string key)
        {
            return Task.FromResult(_configuration[key] ?? "");
        }

        public Task<double> TestMultiSigMethod(double value)
        {
            return Task.FromResult(value);
        }

        public Task<string> TestMultiSigMethod(string value)
        {
            return Task.FromResult(value);
        }

        public Task<double> TestMultiSigMethod(int value)
        {
            return Task.FromResult((double)value);
        }

        public Task<string> TestMultiSigMethod(string value, double dblValue)
        {
            return Task.FromResult(value + " " + dblValue);
        }

        public Task<T2> TestGenerics<T1, T2>(T1 value1, T2 value2)
        {
            var typeofT1 = typeof(T1);
            var typeofT2 = typeof(T2);
            return Task.FromResult(value2);
        }
    }
}
