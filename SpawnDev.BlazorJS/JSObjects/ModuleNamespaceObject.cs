using Microsoft.JSInterop;
using System.Collections.Immutable;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A module namespace object is an object that describes all exports from a module. 
    /// It is a static object that is created when the module is evaluated. 
    /// There are two ways to access the module namespace object of a module: 
    /// through a namespace import (import * as name from moduleName), 
    /// or through the fulfillment value of a dynamic import.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/import#module_namespace_object
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/import#forms_of_import_declarations
    /// </summary>
    public class ModuleNamespaceObject : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ModuleNamespaceObject(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Local cache of export names
        /// </summary>
        string[]? _ExportNames = null;
        /// <summary>
        /// Gets the names of all available exports.
        /// </summary>
        public string[] ExportNames => (_ExportNames ??= JSRef!.Keys().ToArray());
        /// <summary>
        /// Returns a list of exported property names
        /// </summary>
        /// <returns></returns>
        public List<string> GetExportNames() => ExportNames.ToList();
        /// <summary>
        /// Returns the exported property as type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exportName"></param>
        /// <returns></returns>
        public T GetExport<T>(string exportName) => JSRef!.Get<T>(exportName);
        /// <summary>
        /// Retrieves a JavaScript export by name from the underlying JavaScript module.
        /// </summary>
        /// <param name="exportName">The name of the export to retrieve. This value cannot be null.</param>
        /// <returns>A <see cref="JSObject"/> representing the requested export.</returns>
        public JSObject GetExport(string exportName) => JSRef!.Get<JSObject>(exportName);
        /// <summary>
        /// Returns a Function that represents export. Function has methods allowing instantiation of the type.
        /// </summary>
        /// <param name="exportName"></param>
        /// <returns></returns>
        public Function GetExportClass(string exportName) => JSRef!.Get<Function>(exportName);
        /// <summary>
        /// Exports the specified export to the JavaScript environment under the given name.
        /// </summary>
        /// <param name="exportNames">The exports to export to the Javascript environment.</param>
        public ModuleNamespaceObject Export(params string[] exportNames)
        {
            if (exportNames.Length == 0) exportNames = GetExportNames().ToArray();
            foreach (var exportName in exportNames)
            {
                if (exportName == "default") continue;
                if (!ExportExists(exportName)) throw new ArgumentException($"Export '{exportName}' does not exist in module.");
                using var exportObj = GetExport(exportName);
                JS.Set(exportName, exportObj);
            }
            return this;
        }
        /// <summary>
        /// Exports the specified module exports to a JavaScript namespace object.
        /// </summary>
        /// <remarks>If the specified namespace does not exist in the JavaScript context, it will be
        /// created. The default export is not added to the namespace. Existing properties in the namespace with the
        /// same name as an export will be overwritten.</remarks>
        /// <param name="nameSpace">The name of the JavaScript namespace to which the exports will be added. Cannot be null, empty, or
        /// whitespace.</param>
        /// <param name="exportNames">An array of export names to add to the namespace. If no names are specified, all available exports except
        /// the default export are added.</param>
        /// <returns>The current <see cref="ModuleNamespaceObject"/> instance, allowing for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="nameSpace"/> is null, empty, or consists only of white-space characters.</exception>
        /// <exception cref="ArgumentException">Thrown if any specified export name does not exist in the module.</exception>
        public ModuleNamespaceObject ExportTo(string nameSpace, params string[] exportNames)
        {
            if (string.IsNullOrWhiteSpace(nameSpace)) throw new ArgumentNullException(nameof(nameSpace));
            if (JS.IsUndefined(nameSpace)) JS.Set(nameSpace, new { });
            using var ns = JS.Get<JSObject>(nameSpace);
            if (exportNames.Length == 0) exportNames = GetExportNames().ToArray();
            foreach (var exportName in exportNames)
            {
                if (exportName == "default") continue;
                if (!ExportExists(exportName)) throw new ArgumentException($"Export '{exportName}' does not exist in module.");
                using var exportObj = GetExport(exportName);
                ns.JSRef!.Set(exportName, exportObj);
            }
            return this;
        }
        /// <summary>
        /// Exports a JavaScript export identified by the specified name and assigns it to a new name in the JavaScript
        /// context.
        /// </summary>
        /// <param name="exportName">The name of the JavaScript object to export. Cannot be null or empty.</param>
        /// <param name="asName">The name to assign to the exported object in the JavaScript context. Cannot be null or empty.</param>
        public ModuleNamespaceObject ExportAs(string exportName, string asName)
        {
            if (string.IsNullOrEmpty(asName)) throw new ArgumentNullException(nameof(asName));
            if (!ExportExists(exportName)) throw new ArgumentException($"Export '{exportName}' does not exist in module.");
            using var exportObj = GetExport(exportName);
            JS.Set(asName, exportObj);
            return this;
        }
        /// <summary>
        /// Exports the specified module export as a property with a new name on the given JavaScript namespace object.
        /// </summary>
        /// <remarks>If the specified namespace object does not exist, it will be created. The export will
        /// be accessible on the namespace object using the provided alias.</remarks>
        /// <param name="nameSpace">The name of the JavaScript namespace object to which the export will be added. Cannot be null, empty, or
        /// consist only of white-space characters.</param>
        /// <param name="exportName">The name of the export in the current module to be added to the namespace. Must refer to an existing export.</param>
        /// <param name="asName">The property name to use for the export on the namespace object. Cannot be null or empty.</param>
        /// <returns>The current <see cref="ModuleNamespaceObject"/> instance, enabling method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="asName"/> is null or empty, or if <paramref name="nameSpace"/> is null, empty, or
        /// consists only of white-space characters.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="exportName"/> does not refer to an existing export in the module.</exception>
        public ModuleNamespaceObject ExportToAs(string nameSpace, string exportName, string asName)
        {
            if (string.IsNullOrEmpty(asName)) throw new ArgumentNullException(nameof(asName));
            if (!ExportExists(exportName)) throw new ArgumentException($"Export '{exportName}' does not exist in module.");
            if (string.IsNullOrWhiteSpace(nameSpace)) throw new ArgumentNullException(nameof(nameSpace));
            if (JS.IsUndefined(nameSpace)) JS.Set(nameSpace, new { });
            using var ns = JS.Get<JSObject>(nameSpace);
            using var exportObj = GetExport(exportName);
            ns.JSRef!.Set(asName, exportObj);
            return this;
        }
        /// <summary>
        /// Exports the specified exports to the JavaScript environment under the given names.
        /// </summary>
        /// <param name="exportAs"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public ModuleNamespaceObject ExportAs(params (string exportName, string asName)[] exportAs)
        {
            foreach (var (exportName, asName) in exportAs)
            {
                if (string.IsNullOrEmpty(asName)) throw new ArgumentNullException(nameof(asName));
                if (!ExportExists(exportName)) throw new ArgumentException($"Export '{exportName}' does not exist in module.");
                using var exportObj = GetExport(exportName);
                JS.Set(asName, exportObj);
            }
            return this;
        }
        /// <summary>
        /// Exports one or more module members to the specified JavaScript namespace under custom names.
        /// </summary>
        /// <remarks>If the specified namespace does not exist in the JavaScript context, it will be
        /// created automatically. This method allows you to expose module exports under different names within the
        /// target namespace, which can be useful for avoiding naming conflicts or providing more descriptive
        /// aliases.</remarks>
        /// <param name="nameSpace">The name of the JavaScript namespace to which the exports will be added. Cannot be null, empty, or
        /// whitespace.</param>
        /// <param name="exportAs">A collection of tuples specifying the export name and the corresponding alias to use in the namespace. Each
        /// tuple contains the original export name and the name to assign it under the namespace.</param>
        /// <returns>The current <see cref="ModuleNamespaceObject"/> instance, enabling method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="nameSpace"/> is null, empty, or consists only of whitespace, or if any
        /// <c>asName</c> value in <paramref name="exportAs"/> is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown if an <c>exportName</c> specified in <paramref name="exportAs"/> does not exist in the module.</exception>
        public ModuleNamespaceObject ExportToAs(string nameSpace, params (string exportName, string asName)[] exportAs)
        {
            if (string.IsNullOrWhiteSpace(nameSpace)) throw new ArgumentNullException(nameof(nameSpace));
            if (JS.IsUndefined(nameSpace)) JS.Set(nameSpace, new { });
            using var ns = JS.Get<JSObject>(nameSpace);
            foreach (var (exportName, asName) in exportAs)
            {
                if (string.IsNullOrEmpty(asName)) throw new ArgumentNullException(nameof(asName));
                if (!ExportExists(exportName)) throw new ArgumentException($"Export '{exportName}' does not exist in module.");
                using var exportObj = GetExport(exportName);
                ns.JSRef!.Set(asName, exportObj);
            }
            return this;
        }
        /// <summary>
        /// Determines whether an export with the specified name exists.
        /// </summary>
        /// <param name="exportNames">The names of the exports to check. Cannot be null.</param>
        /// <returns>true if an export with the specified name exists; otherwise, false.</returns>
        public bool ExportExists(params string[] exportNames) => exportNames.Except(GetExportNames()).Count() == 0;
        /// <summary>
        /// Exports the default export JavaScript object under the specified name.
        /// </summary>
        /// <param name="asName">The name to assign to the exported default object. Cannot be null or empty.</param>
        public ModuleNamespaceObject ExportDefaultAs(string asName) => ExportAs("default", asName);
        /// <summary>
        /// Exports the default export of the current module to the specified namespace under a new name.
        /// </summary>
        /// <param name="nameSpace">The target namespace to which the default export will be added. Cannot be null or empty.</param>
        /// <param name="asName">The name under which the default export will be accessible in the target namespace. Cannot be null or empty.</param>
        /// <returns>A ModuleNamespaceObject representing the updated namespace with the default export added under the specified
        /// name.</returns>
        public ModuleNamespaceObject ExportDefaultToAs(string nameSpace, string asName) => ExportToAs(nameSpace, "default", asName);
        /// <summary>
        /// Exports this module namespace object to the JavaScript environment under the specified name.
        /// </summary>
        /// <param name="name">The name to associate with the exported object in the JavaScript environment. Cannot be null or empty.</param>
        public ModuleNamespaceObject ExportNamespace(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            JS.Set(name, this);
            return this;
        }
    }
}
