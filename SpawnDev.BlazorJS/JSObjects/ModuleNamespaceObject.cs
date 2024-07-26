using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Contains methods for listing and retrieving exported properties from Imported Modules.
    /// </summary>
    public class ModuleNamespaceObject : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ModuleNamespaceObject(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a list of exported property names
        /// </summary>
        /// <returns></returns>
        public List<string> GetExportNames() => JSRef!.Keys();
        /// <summary>
        /// Returns the exported property as type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exportName"></param>
        /// <returns></returns>
        public T GetExport<T>(string exportName) => JSRef!.Get<T>(exportName);
        /// <summary>
        /// Returns a Function that represents the class. Function has methods allowing instantiation of the type.
        /// </summary>
        /// <param name="exportName"></param>
        /// <returns></returns>
        public Function GetExportClass(string exportName) => JSRef!.Get<Function>(exportName);
    }
}
