using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.Diagnostics
{

    public class JSObjectAnalysisResult
    {
        public string JSObjectTypeName => JSObjectType == null ? "" : JSObjectType.Name;
        public Type JSObjectType { get; set; }
        public string JSConstrutorName { get; set; }
        public List<JSPropertyInfo> JSProperties { get; set; }
        public string JSPropNamesHash { get; set; }
    }
}
