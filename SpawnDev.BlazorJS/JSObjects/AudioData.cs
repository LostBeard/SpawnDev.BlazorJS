using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    
    public class AudioData : JSObject
    {
        public AudioData(IJSInProcessObjectReference _ref) : base(_ref)
        {
        }
    }
}
