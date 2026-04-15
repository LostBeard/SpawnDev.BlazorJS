# BiquadFilterNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioNode`  
**Source:** `JSObjects/WebAudio/BiquadFilterNode.cs`  
**MDN Reference:** [BiquadFilterNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BiquadFilterNode)

> https://developer.mozilla.org/en-US/docs/Web/API/BiquadFilterNode

## Constructors

| Signature | Description |
|---|---|
| `BiquadFilterNode(AudioContext context, BiquadFilterNodeOptions? options)` | The BiquadFilterNode() constructor of the Web Audio API creates a new BiquadFilterNode object, which represents a simple low-order filter. A reference to an AudioContext. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Frequency` | `float` | get | An a-rate AudioParam, a double representing a frequency in the current filtering algorithm measured in hertz (Hz). |
| `Detune` | `float` | get | An a-rate AudioParam representing detuning of the frequency in cents. |
| `Gain` | `float` | get | An a-rate AudioParam, a double representing the gain used in the current filtering algorithm. |
| `Type` | `string` | get | A string value defining the kind of filtering algorithm the node is implementing. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetFrequencyResponse(Float32Array frequencyArray, Float32Array magResponseOutput, Float32Array phaseResponseOutput)` | `void` | The getFrequencyResponse() method of the BiquadFilterNode interface takes the current filtering algorithm's settings and calculates the frequency response for frequencies specified in a specified array of frequencies. The two output arrays, magResponseOutput and phaseResponseOutput, must be created before calling this method; they must be the same size as the array of input frequency values (frequencyArray). A Float32Array containing an array of frequencies, specified in Hertz, which you want to filter. A Float32Array to receive the computed magnitudes of the frequency response for each frequency value in the frequencyArray. For any frequency in frequencyArray whose value is outside the range 0.0 to sampleRate/2 (where sampleRate is the sample rate of the AudioContext), the corresponding value in this array is NaN. These are unitless values. A Float32Array to receive the computed phase response values in radians for each frequency value in the input frequencyArray. For any frequency in frequencyArray whose value is outside the range 0.0 to sampleRate/2 (where sampleRate is the sample rate of the AudioContext), the corresponding value in this array is NaN. |

