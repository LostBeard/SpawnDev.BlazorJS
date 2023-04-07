using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DOMException interface represents an abnormal event (called an exception) that occurs as a result of calling a method or accessing a property of a web API. This is how error conditions are described in web APIs.
    /// </summary>
    public class DOMException : JSObject
    {
        public DOMException(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a string representing a message or description associated with the given error name.
        /// </summary>
        public string Message => JSRef.Get<string>("message");
        /// <summary>
        /// Returns a string that contains one of the strings associated with an error name.
        /// </summary>
        public string Name => JSRef.Get<string>("name");
    }
}
