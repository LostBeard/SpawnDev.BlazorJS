# AudioWorkletNodeOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebAudio/AudioWorkletNode.cs`  

> Options for creating an AudioWorkletNode.

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `NumberOfInputs` | `int?` | get/set | The value to initialize the numberOfInputs property. Defaults to 1. |
| `NumberOfOutputs` | `int?` | get/set | The value to initialize the numberOfOutputs property. Defaults to 1. |
| `OutputChannelCount` | `int[]?` | get/set | An array defining the number of channels for each output. |
| `ParameterData` | `Dictionary<string, double>?` | get/set | An object containing the initial values of custom AudioParam objects on this node (as defined in the processor's parameterDescriptors static getter). |
| `ProcessorOptions` | `object?` | get/set | Any additional data that can be used for custom initialization of the underlying AudioWorkletProcessor. |
