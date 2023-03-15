using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.Blazor.UnitTesting
{
    public class UnitTest
    {
        public string TestTypeName { get; }
        public Type TestType { get; }
        public string TestMethodName { get; }
        public MethodInfo TestMethod { get; }
        public string ResultText { get; set; } = "";
        public TestResult Result { get; set; } = TestResult.None;
        public TestState State { get; set; } = TestState.None;
        public double Duration { get; set; }
        public string Error { get; set; } = "";
        public UnitTest(Type testClass, MethodInfo methodInfo)
        {
            TestType = testClass;
            TestTypeName = TestType.Name;
            TestMethod = methodInfo;
            TestMethodName = TestMethod.Name;
        }
        public void Reset()
        {
            Error = "";
            ResultText = "";
            Result = TestResult.None;
            Duration = 0;
            State = TestState.None;
        }
    }
}
