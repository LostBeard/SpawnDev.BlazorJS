using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ModuleNamespaceObject : JSObject
    {
        public ModuleNamespaceObject(IJSInProcessObjectReference _ref) : base(_ref) { }
        public List<string> GetExportNames() => JSRef.GetPropertyNames();
        public T GetExport<T>(string exportName) => JSRef.Get<T>(exportName);
    }
}
