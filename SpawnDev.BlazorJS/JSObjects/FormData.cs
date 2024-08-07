using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The FormData interface provides a way to construct a set of key/value pairs representing form fields and their values, which can be sent using the fetch(), XMLHttpRequest.send() or navigator.sendBeacon() methods. It uses the same format a form would use if the encoding type were set to "multipart/form-data".<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/FormData
    /// </summary>
    public class FormData : JSObject
    {
        /// <summary>
        /// The FormData() constructor creates a new FormData object.
        /// </summary>
        public FormData() : base(JS.New(nameof(FormData))) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public FormData(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Appends a new value onto an existing key inside a FormData object, or adds the key if it does not already exist.
        /// </summary>
        /// <param name="name">The name of the field whose data is contained in value.</param>
        /// <param name="value">The field's value. This can be a string or Blob (including subclasses such as File). If none of these are specified the value is converted to a string.</param>
        public void Append(string name, Union<string, Blob> value) => JSRef!.CallVoid("append", name, value);
        /// <summary>
        /// Appends a new value onto an existing key inside a FormData object, or adds the key if it does not already exist.
        /// </summary>
        /// <param name="name">The name of the field whose data is contained in value.</param>
        /// <param name="value">The field's value. This can be a string or Blob (including subclasses such as File). If none of these are specified the value is converted to a string.</param>
        /// <param name="filename">The filename reported to the server (a string), when a Blob or File is passed as the second parameter. The default filename for Blob objects is "blob". The default filename for File objects is the file's filename.</param>
        public void Append(string name, Union<string, Blob> value, string filename) => JSRef!.CallVoid("append", name, value, filename);
    }
}
