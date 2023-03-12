using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;
using SpawnDev.BlazorJS.JsonConverters;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<XMLHttpRequestUpload>))]
    public class XMLHttpRequestUpload : EventTarget
    {
        public XMLHttpRequestUpload(IJSInProcessObjectReference _ref) : base(_ref) { }


    }
}
