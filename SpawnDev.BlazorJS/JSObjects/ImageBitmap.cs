using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<ImageBitmap>))]
    public class ImageBitmap : JSObject
    {
        public ImageBitmap(IJSInProcessObjectReference _ref) : base(_ref)
        {
        }
    }
}
