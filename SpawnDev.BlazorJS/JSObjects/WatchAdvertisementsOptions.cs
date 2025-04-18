using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://webbluetoothcg.github.io/web-bluetooth/#dictdef-watchadvertisementsoptions
    /// </summary>
    public class WatchAdvertisementsOptions
    {
        /// <summary>
        /// Optional. The signal to abort the request.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AbortSignal? Signal { get; set; }
    }
}
