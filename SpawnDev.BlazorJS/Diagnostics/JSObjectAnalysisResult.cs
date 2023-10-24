using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.Diagnostics
{

    public class JSObjectAnalysisResult
    {
        public string JSObjectTypeName => JSObjectType == null ? "" : JSObjectType.Name;
        [JsonIgnore]
        public Type JSObjectType { get; set; }
        public string JSConstrutorName { get; set; }
        public List<JSPropertyInfo> JSProperties { get; set; }
        public string JSPropNamesHash { get; set; }
        //public List<string> Inheritance { get; set; } = new List<string>();
        public Dictionary<string, List<string>> Inheritance { get; set; } = new Dictionary<string, List<string>>();
    }
}
