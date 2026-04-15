# ModuleNamespaceObject

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ModuleNamespaceObject.cs`  
**MDN Reference:** [ModuleNamespaceObject on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/import#module_namespace_object)

> A module namespace object is an object that describes all exports from a module. It is a static object that is created when the module is evaluated. There are two ways to access the module namespace object of a module: through a namespace import (import * as name from moduleName), or through the fulfillment value of a dynamic import. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/import#module_namespace_object https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/import#forms_of_import_declarations

## Constructors

| Signature | Description |
|---|---|
| `ModuleNamespaceObject(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ExportNames` | `string[]` | get | Gets the names of all available exports. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetExportNames()` | `List<string>` | Returns a list of exported property names |
| `GetExport(string exportName)` | `T` | Returns the exported property as type T |
| `GetExportClass(string exportName)` | `Function` | Returns a Function that represents export. Function has methods allowing instantiation of the type. |
| `Export(params string[] exportNames)` | `ModuleNamespaceObject` | Exports the specified export to the JavaScript environment under the given name. The exports to export to the Javascript environment. |
| `ExportTo(string nameSpace, params string[] exportNames)` | `ModuleNamespaceObject` | Exports the specified module exports to a JavaScript namespace object. If the specified namespace does not exist in the JavaScript context, it will be created. The default export is not added to the namespace. Existing properties in the namespace with the same name as an export will be overwritten. The name of the JavaScript namespace to which the exports will be added. Cannot be null, empty, or whitespace. An array of export names to add to the namespace. If no names are specified, all available exports except the default export are added. The current `ModuleNamespaceObject` instance, allowing for method chaining. Thrown if `nameSpace` is null, empty, or consists only of white-space characters. Thrown if any specified export name does not exist in the module. |
| `ExportAs(string exportName, string asName)` | `ModuleNamespaceObject` | Exports a JavaScript export identified by the specified name and assigns it to a new name in the JavaScript context. The name of the JavaScript object to export. Cannot be null or empty. The name to assign to the exported object in the JavaScript context. Cannot be null or empty. |
| `ExportToAs(string nameSpace, string exportName, string asName)` | `ModuleNamespaceObject` | Exports the specified module export as a property with a new name on the given JavaScript namespace object. If the specified namespace object does not exist, it will be created. The export will be accessible on the namespace object using the provided alias. The name of the JavaScript namespace object to which the export will be added. Cannot be null, empty, or consist only of white-space characters. The name of the export in the current module to be added to the namespace. Must refer to an existing export. The property name to use for the export on the namespace object. Cannot be null or empty. The current `ModuleNamespaceObject` instance, enabling method chaining. Thrown if `asName` is null or empty, or if `nameSpace` is null, empty, or consists only of white-space characters. Thrown if `exportName` does not refer to an existing export in the module. |
| `ExportAs(params (string exportName, string asName)` | `ModuleNamespaceObject` | Exports the specified exports to the JavaScript environment under the given names. |
| `ExportToAs(string nameSpace, params (string exportName, string asName)` | `ModuleNamespaceObject` | Exports one or more module members to the specified JavaScript namespace under custom names. If the specified namespace does not exist in the JavaScript context, it will be created automatically. This method allows you to expose module exports under different names within the target namespace, which can be useful for avoiding naming conflicts or providing more descriptive aliases. The name of the JavaScript namespace to which the exports will be added. Cannot be null, empty, or whitespace. A collection of tuples specifying the export name and the corresponding alias to use in the namespace. Each tuple contains the original export name and the name to assign it under the namespace. The current `ModuleNamespaceObject` instance, enabling method chaining. Thrown if `nameSpace` is null, empty, or consists only of whitespace, or if any `asName` value in `exportAs` is null or empty. Thrown if an `exportName` specified in `exportAs` does not exist in the module. |
| `ExportExists(params string[] exportNames)` | `bool` | Determines whether an export with the specified name exists. The names of the exports to check. Cannot be null. true if an export with the specified name exists; otherwise, false. |
| `ExportDefaultAs(string asName)` | `ModuleNamespaceObject` | Exports the default export JavaScript object under the specified name. The name to assign to the exported default object. Cannot be null or empty. |
| `ExportDefaultToAs(string nameSpace, string asName)` | `ModuleNamespaceObject` | Exports the default export of the current module to the specified namespace under a new name. The target namespace to which the default export will be added. Cannot be null or empty. The name under which the default export will be accessible in the target namespace. Cannot be null or empty. A ModuleNamespaceObject representing the updated namespace with the default export added under the specified name. |
| `ExportNamespace(string name)` | `ModuleNamespaceObject` | Exports this module namespace object to the JavaScript environment under the specified name. The name to associate with the exported object in the JavaScript environment. Cannot be null or empty. |

