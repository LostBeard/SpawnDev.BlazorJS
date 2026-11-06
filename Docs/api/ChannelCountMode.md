# ChannelCountMode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/ChannelCountMode.cs`  

> The ChannelCountMode, in conjuction with the node’s channelCount and channelInterpretation values, is used to determine the computedNumberOfChannels that controls how inputs to a node are to be mixed. The computedNumberOfChannels is determined as shown below. See § 4 Channel Up-Mixing and Down-Mixing for more information on how mixing is to be done. https://www.w3.org/TR/webaudio/#enumdef-channelcountmode

## Values

| Name | JSON Value | Description |
|---|---|---|
| `Max` | `"max"` | computedNumberOfChannels is the maximum of the number of channels of all connections to an input. In this mode channelCount is ignored. |
| `ClampedMax` | `"clamped-max"` | computedNumberOfChannels is determined as for "max" and then clamped to a maximum value of the given channelCount. |
| `Explicit` | `"explicit"` | computedNumberOfChannels is the exact value as specified by the channelCount. |
