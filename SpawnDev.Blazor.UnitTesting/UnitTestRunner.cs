using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace SpawnDev.Blazor.UnitTesting
{
    public class UnitTestRunner
    {
        public event Action TestStatusChanged;
        public TestState State { get; private set; } = TestState.None;
        public List<UnitTest> Tests { get; private set; } = new List<UnitTest>();
        public IEnumerable<Type> UnitTestTypes { get; private set; }
        public void SetTestTypes(IEnumerable<Type> unitTestTypes)
        {
            if (State == TestState.Running)
            {
                throw new Exception("Unit test types cannot be set while tests are running");
            }
            UnitTestTypes = unitTestTypes.Distinct().ToList();
            Tests.Clear();
            foreach (Type unitTestType in UnitTestTypes)
            {
                var methods = unitTestType.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(o => o.GetParameters().Length == 0).ToList();
                foreach (var method in methods)
                {
                    var testMethodAttr = method.GetCustomAttribute<TestMethodAttribute>();
                    if (testMethodAttr == null) continue;
                    Tests.Add(new UnitTest(unitTestType, method));
                }
            }
            State = TestState.None;
            TestStatusChanged?.Invoke();
        }

        public delegate void UnitTestResolverEventDelegate(UnitTestResolverEvent resolverEvent);
        public event UnitTestResolverEventDelegate OnUnitTestResolverEvent;

        public void ResetTests()
        {
            Tests.ForEach(o => o.Reset());
            State = TestState.None;
        }

        CancellationTokenSource? cancellationTokenSource { get; set; } = new CancellationTokenSource();

        public void CancelTests()
        {
            cancellationTokenSource?.Cancel();
            cancellationTokenSource = null;
        }
        Dictionary<Type, object> _instances = new Dictionary<Type, object>();
        object? GetTestTypeInstance(Type testType)
        {
            if (_instances.TryGetValue(testType, out var instance)) return instance;
            object? ret = null;
            var ev = new UnitTestResolverEvent(testType);
            OnUnitTestResolverEvent?.Invoke(ev);
            ret = ev.TypeInstance != null ? ev.TypeInstance : Activator.CreateInstance(testType);
            _instances[testType] = ret;
            return ret;
        }
        public async Task RunTests(UnitTest test)
        {
            var method = test.TestMethod;
            var testInstance = GetTestTypeInstance(test.TestType);
            test.Reset();
            test.State = TestState.Running;
            await FireStateChangeEvent();
            var sw = new Stopwatch();
            sw.Start();
            try
            {
                var ret = method.Invoke(testInstance, null);
                if (ret is Task task)
                {
                    ret = await task.GetResult();
                }
                test.Result = TestResult.Success;
                if (ret is string retStr && !string.IsNullOrEmpty(retStr))
                {
                    test.ResultText = retStr;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                test.StackTrace = ex.StackTrace ?? "";
                test.Error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                test.Result = TestResult.Error;
            }
            if (string.IsNullOrEmpty(test.ResultText)) test.ResultText = test.Result.ToString();
            test.State = TestState.Done;
            test.Duration = Math.Round(sw.Elapsed.TotalMilliseconds);
            await FireStateChangeEvent();
        }
        public async Task RunTests()
        {
            if (State == TestState.Done)
            {
                ResetTests();
            }
            if (State != TestState.None) return;
            using var tokenSource = new CancellationTokenSource();
            cancellationTokenSource = tokenSource;
            var token = cancellationTokenSource.Token;
            State = TestState.Running;
            await FireStateChangeEvent();
            foreach (var test in Tests)
            {
                if (token.IsCancellationRequested) break;
                if (test.State != TestState.None) continue;
                await RunTests(test);
            }
            cancellationTokenSource = null;
            State = TestState.Done;
            await FireStateChangeEvent();
        }

        async Task FireStateChangeEvent()
        {
            TestStatusChanged?.Invoke();
            await Task.Delay(100);
            // give Blazor UI sufficient time to update the UI to show the current state
        }
    }
}
