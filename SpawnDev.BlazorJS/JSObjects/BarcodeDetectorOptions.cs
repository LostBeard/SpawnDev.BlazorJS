using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An options object containing a series of BarcodeFormats to search for in the subsequent detect() calls. 
    /// </summary>
    public class BarcodeDetectorOptions
    {
        /// <summary>
        /// An Array of barcode formats as strings. To see a full list of supported formats see the Barcode Detection API.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Formats { get; set; }
    }
}
