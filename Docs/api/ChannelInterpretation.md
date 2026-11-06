# ChannelInterpretation

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/ChannelInterpretation.cs`  

> ChannelInterpretation https://www.w3.org/TR/webaudio/#enumdef-channelinterpretation

## Values

| Name | JSON Value | Description |
|---|---|---|
| `Speakers` | `"speakers"` | use up-mix equations or down-mix equations. In cases where the number of channels do not match any of these basic speaker layouts, revert to "discrete". |
| `Discrete` | `"discrete"` | Up-mix by filling channels until they run out then zero out remaining channels. Down-mix by filling as many channels as possible, then dropping remaining channels. |
