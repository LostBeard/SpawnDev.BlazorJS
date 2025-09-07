using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class XRDOMOverlayInit
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public HTMLElement? Root { get; set; }
    }
}
