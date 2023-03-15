
## NuGet

| Package | Description | Link |
|---------|-------------|------|
|**SpawnDev.Blazor.UnitTesting**| Blazor WebAssembly WebWorkers and SharedWebWorkers | [![NuGet version](https://badge.fury.io/nu/SpawnDev.Blazor.UnitTesting.svg)](https://www.nuget.org/packages/SpawnDev.Blazor.UnitTesting) |
 

# SpawnDev.BlazorJS
[![NuGet](https://img.shields.io/nuget/dt/SpawnDev.Blazor.UnitTesting.svg?label=SpawnDev.Blazor.UnitTesting)](https://www.nuget.org/packages/SpawnDev.Blazor.UnitTesting) 

Unit testing for Blazor

Supports .Net Blazor 6, 7, and 8.

Simply create a page for your test. Add the UnitTestsView component and assign the TestAssemblies and/or TestTypes parameters.

Example usage

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
