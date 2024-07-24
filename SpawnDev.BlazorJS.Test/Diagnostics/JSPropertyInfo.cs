using SpawnDev.BlazorJS.JSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.Diagnostics
{
    public class JSPropertyInfo
    {
        public Dictionary<string, JSPropertyInfo> JSProperties { get; set; }
        public Dictionary<string, Dictionary<string, PropertyDescriptor>> Inheritance { get; set; } = new Dictionary<string, Dictionary<string, PropertyDescriptor>>();
        //public string JSPropNamesHash { get; set; }
        public string? InstanceOf { get; set; }  //=> Inheritance.Count == 0 ? null : Inheritance.Keys.FirstOrDefault();
        public string? InheritsFrom { get; set; } // => Inheritance.Count < 2 ? null : Inheritance.Keys.ElementAt<string?>(1);
        public int FunctionLength { get; set; }
        public bool FullAnalysis { get; set; }
        /// <summary>
        /// Property name
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// typeof property
        /// </summary>
        public string TypeOf { get; set; }
        public bool IsFunction => TypeOf == "function";
        //public PropertyDescriptor? Descriptor { get; set; }

    }
    //public class JSPropertyInfo
    //{
    //    /// <summary>
    //    /// Property name
    //    /// </summary>
    //    public string Name { get; set; } = "";
    //    /// <summary>
    //    /// typeof property
    //    /// </summary>
    //    public string TypeOf { get; set; }
    //    /// <summary>
    //    /// property.constructor.name
    //    /// </summary>
    //    public string? InstanceOf { get; set; }
    //    ///// <summary>
    //    ///// Handle to object if an object
    //    ///// </summary>
    //    //public JSObject? JSObject { get; set; }
    //    /// <summary>
    //    /// The PropertyDescriptor of the property (if one)
    //    /// </summary>
    //    public PropertyDescriptor? Descriptor { get; set; }
    //    /// <summary>
    //    /// If this property is a function, this is the number of arguments it takes (may not be accurate)
    //    /// </summary>
    //    public int FunctionLength { get; set; }

    //    public JSObjectAnalysisResult? ObjectAnalysisResult { get; set; }
    //}
}
