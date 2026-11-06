# EncodedAudioChunkType

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebCodecs/EncodedAudioChunkType.cs`  

> The type of the chunk.

## Values

| Name | JSON Value | Description |
|---|---|---|
| `Key` | `"key"` | The chunk is a key chunk, which does not rely on other frames for decoding. |
| `Delta` | `"delta"` | The chunk is a delta chunk, which relies on other frames for decoding. |
