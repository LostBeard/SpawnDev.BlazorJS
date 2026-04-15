# IIRFilterNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioNode`  
**Source:** `JSObjects/WebAudio/IIRFilterNode.cs`  
**MDN Reference:** [IIRFilterNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IIRFilterNode)

> The IIRFilterNode interface of the Web Audio API is a AudioNode processor which implements a general infinite impulse response (IIR) filter; this type of filter can be used to implement tone control devices and graphic equalizers as well. It lets the parameters of the feedforward and feedback coefficients be specified, so that other types of filters can be implemented. https://developer.mozilla.org/en-US/docs/Web/API/IIRFilterNode

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetFrequencyResponse(Float32Array frequencyHz, Float32Array magResponse, Float32Array phaseResponse)` | `void` | Returns a Float32Array containing the frequency response for the specified number of frequencies. |

