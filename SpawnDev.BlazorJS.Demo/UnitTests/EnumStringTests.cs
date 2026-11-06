using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Demo.UnitTests
{
    /// <summary>
    /// Enums whose members are Javascript strings must reach Javascript as those strings.
    /// EncodedAudioChunkType, EncodedVideoChunkType and GPUStencilOperation carried
    /// [JsonConverter(typeof(JsonStringEnumConverter))], which ignores [JsonPropertyName] on enum members, so they were
    /// written as their C# NAMES: the browser refused new EncodedAudioChunk({ type: "Key", ... }) and a stencil op went
    /// out as "IncrementClamp" instead of "increment-clamp". They use EnumStringConverterFactory now (it reads
    /// [JsonPropertyName]). Parallel of SpawnDev.SpawnJS 3.0.7 / 3.0.8 (EnumStringWrapperTests).
    /// </summary>
    public class EnumStringTests(BlazorJSRuntime JS)
    {
        [TestMethod]
        public async Task EncodedAudioChunkTypeBothWays()
        {
            foreach (var type in new[] { EncodedAudioChunkType.Key, EncodedAudioChunkType.Delta })
            {
                using var data = new ArrayBuffer(8);
                // threw "TypeError: ... 'Key' is not a valid enum value of type EncodedAudioChunkType" with JsonStringEnumConverter
                using var chunk = new EncodedAudioChunk(new EncodedAudioChunkInit { Type = type, Timestamp = 40000, Duration = 20000, Data = data });
                var expected = type == EncodedAudioChunkType.Key ? "key" : "delta";
                var seen = chunk.JSRef!.Get<string>("type");
                if (seen != expected) throw new Exception($"browser's chunk.type is '{seen}', expected '{expected}'");
                if (chunk.Type != type) throw new Exception($"chunk.Type read back {chunk.Type}, expected {type}");
                if (chunk.Timestamp != 40000 || chunk.ByteLength != 8) throw new Exception($"timestamp {chunk.Timestamp}, byteLength {chunk.ByteLength}");
            }
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task EncodedVideoChunkTypeBothWays()
        {
            foreach (var type in new[] { EncodedVideoChunkType.Key, EncodedVideoChunkType.Delta })
            {
                using var data = new ArrayBuffer(16);
                using var chunk = new EncodedVideoChunk(new EncodedVideoChunkInit { Type = type, Timestamp = 33333, Data = data });
                var expected = type == EncodedVideoChunkType.Key ? "key" : "delta";
                var seen = chunk.JSRef!.Get<string>("type");
                if (seen != expected) throw new Exception($"browser's chunk.type is '{seen}', expected '{expected}'");
                if (chunk.Type != type) throw new Exception($"chunk.Type read back {chunk.Type}, expected {type}");
            }
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task GPUStencilOperationStrings()
        {
            const string key = "__enumStringStencilOp";
            try
            {
                foreach (var (op, expected) in new[] { (GPUStencilOperation.Keep, "keep"), (GPUStencilOperation.IncrementClamp, "increment-clamp"), (GPUStencilOperation.DecrementWrap, "decrement-wrap") })
                {
                    // the bare enum (the converter on the enum itself)
                    JS.Set(key, op);
                    var seen = JS.Get<string>(key);
                    if (seen != expected) throw new Exception($"GPUStencilOperation.{op} reached Javascript as '{seen}', expected '{expected}'");
                    var back = JS.Get<GPUStencilOperation>(key);
                    if (back != op) throw new Exception($"'{expected}' read back as {back}, expected {op}");
                    // inside the face state a depth-stencil descriptor sends
                    JS.Set(key, new GPUStencilFaceState { PassOp = op });
                    seen = JS.Get<string>($"{key}.passOp");
                    if (seen != expected) throw new Exception($"GPUStencilFaceState.PassOp {op} reached Javascript as '{seen}', expected '{expected}'");
                }
            }
            finally { JS.Delete(key); }
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task DisplayMediaStreamOptionsWindowAudioStrings()
        {
            // getDisplayMedia needs a user gesture and a picker, so this checks what the options object carries to Javascript.
            const string key = "__enumStringDisplayMediaOptions";
            try
            {
                foreach (var (value, expected) in new[] { (WindowAudioPreferenceEnum.Window, "window"), (WindowAudioPreferenceEnum.System, "system"), (WindowAudioPreferenceEnum.Exclude, "exclude") })
                {
                    JS.Set(key, new DisplayMediaStreamOptions { WindowAudio = value, SystemAudio = SystemAudioPreferenceEnum.Include });
                    var seen = JS.Get<string>($"{key}.windowAudio");
                    if (seen != expected) throw new Exception($"windowAudio is '{seen}', expected '{expected}'");
                    if (JS.Get<string>($"{key}.systemAudio") != "include") throw new Exception("systemAudio did not cross as 'include'");
                }
                JS.Set(key, new DisplayMediaStreamOptions());
                if (JS.Get<string?>($"{key}.windowAudio") != null) throw new Exception("an unset WindowAudio reached Javascript");
            }
            finally { JS.Delete(key); }
            await Task.CompletedTask;
        }
    }
}
