using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.Diagnostics
{
    public class JSPropertyInfo
    {
        public string Name { get; set; } = "";
        //public string FullName { get; set; } = "";
        public string TypeOf { get; set; }
        public string? InstanceOf { get; set; }
        public List<JSPropertyInfo> Props { get; set; } = new List<JSPropertyInfo>();
        public JSObject? JSObject { get; set; }
        public JSObject? Descriptor { get; set; }
        public int FunctionLength { get; set; }
    }
}
