
## NuGet

| Package | Description | Link |
|---------|-------------|------|
|**SpawnDev.Blazor.UnitTesting**| Blazor Unit Testing | [![NuGet version](https://badge.fury.io/nu/SpawnDev.Blazor.UnitTesting.svg)](https://www.nuget.org/packages/SpawnDev.Blazor.UnitTesting) |
 

# SpawnDev.BlazorJS
[![NuGet](https://img.shields.io/nuget/dt/SpawnDev.Blazor.UnitTesting.svg?label=SpawnDev.Blazor.UnitTesting)](https://www.nuget.org/packages/SpawnDev.Blazor.UnitTesting) 

Unit testing for Blazor

Supports .Net Blazor 6, 7, and 8.

Simply create a page for your test. Add the UnitTestsView component and assign the TestAssemblies and/or TestTypes parameters.

Example usage

Give your unit test class the TestClass attribute and tag your public instance test methods with the TestMethod attribute. Example unit test class below.

```cs
    [TestClass]
    public class UnitTestExamples {

        [TestMethod]
        public void NotImplementedTest() {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void ThreadSleepTest() {
            Thread.Sleep(1000);
        }

        [TestMethod]
        public async Task TaskDelayTest() {
            await Task.Delay(1000);
        }

        [TestMethod]
        public string ReturnAdditionalFailureInfo()
        {
            throw new Exception("Additional error info");
        }

        [TestMethod]
        public string ReturnValueTest()
        {
            return "Additional success info";
        }

        [TestMethod]
        public async Task<string> ReturnValueTestAsync()
        {
            await Task.Delay(1);
            return "Additional success info";
        }
    }
```


Example page for displaying your unit tests.
```cs
@using SpawnDev.Blazor.UnitTesting
@using System.Reflection

@page "/UnitTests"

<UnitTestsView TestAssemblies="_assemblies"></UnitTestsView>

@code {
    IEnumerable<Assembly>? _assemblies = new List<Assembly> {
        typeof(UnitTestsView).Assembly,
        typeof(UnitTests).Assembly
    };
}
```
