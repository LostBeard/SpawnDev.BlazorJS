using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace SpawnDev.BlazorJS.Test.Services {
    public class TestMethodAttribute : Attribute {

    }
    public enum TestState {
        None,
        Running,
        Done,
    }
    public enum TestResult {
        None,
        Error,
        Success,
    }
    public class TestStatus {
        public TestResult Result { get; set; } = TestResult.None;
        public TestState State { get; set; } = TestState.None;
        public string TestTypeName => TestType == null ? "NONE" : TestType.Name;
        public Type TestType { get; set; }
        public string TestMethodName => TestMethod == null ? "NONE" : TestMethod.Name;
        public MethodInfo TestMethod { get; set; }
        public DateTime TestStarted { get; set; }
        public double Duration { get; set; }
        public string Error { get; set; } = "";
        public TestStatus(Type testClass, MethodInfo methodInfo) {
            TestType = testClass;
            TestMethod = methodInfo;
        }
    }
    public class UnitTestService {
        public event Action TestStatusChanged;
        public TestState State { get; private set; } = TestState.None;
        public List<TestStatus> Tests { get; private set; } = new List<TestStatus>();
        public IEnumerable<Type> UnitTestTypes { get; private set; }
        public void SetTestTypes(IEnumerable<Type> unitTestTypes) {
            if (State == TestState.Running) {
                throw new Exception("Unit test types cannot be set while tests are running");
            }
            UnitTestTypes = unitTestTypes;
            ResetTests();
        }

        CancellationTokenSource? cancellationTokenSource { get; set; } = new CancellationTokenSource();

        public void CancelTests() {
            cancellationTokenSource?.Cancel();
            cancellationTokenSource = null;
        }

        public void ResetTests() {
            Tests.Clear();
            foreach (var unitTestType in UnitTestTypes) {
                var methods = unitTestType.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(o => o.GetParameters().Length == 0).ToList();
                foreach (var method in methods) {
                    var testMethodAttr = method.GetCustomAttribute<TestMethodAttribute>();
                    if (testMethodAttr == null) continue;
                    Tests.Add(new TestStatus(unitTestType, method));
                }
            }
            State = TestState.None;
            TestStatusChanged?.Invoke();
        }
        public async Task RunTests() {
            if (State == TestState.Done) {
                ResetTests();
            }
            if (State != TestState.None) return;
            using var tokenSource = new CancellationTokenSource();
            cancellationTokenSource = tokenSource;
            var token = cancellationTokenSource.Token;
            State = TestState.Running;
            await FireStateChangeEvent();
            Type currentTestType = null;
            object? testInstance = null;
            var sw = new Stopwatch();
            foreach (var test in Tests) {
                if (token.IsCancellationRequested) break;
                var method = test.TestMethod;
                var testType = test.TestType;
                if (currentTestType != testType) {
                    currentTestType = testType;
                    testInstance = Activator.CreateInstance(currentTestType);
                }
                test.State = TestState.Running;
                await FireStateChangeEvent();
                sw.Restart();
                try {
                    var ret = method.Invoke(testInstance, null);
                    if (ret is Task task) {
                        await task;
                    }
                    test.Result = TestResult.Success;
                } catch (Exception ex) {
                    test.Error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    test.Result = TestResult.Error;
                }
                test.State = TestState.Done;
                test.Duration = Math.Round(sw.Elapsed.TotalMilliseconds);
                await FireStateChangeEvent();
            }
            cancellationTokenSource = null;
            State = TestState.Done;
            await FireStateChangeEvent();
        }

        async Task FireStateChangeEvent() {
            TestStatusChanged?.Invoke();
            await Task.Delay(100);
            // without sufficient Task.Delays the Blazor UI will not update the UI to show the current state
        }
    }
}
