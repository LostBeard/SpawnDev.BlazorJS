using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DOMException interface represents an abnormal event (called an exception) that occurs as a result of calling a method or accessing a property of a web API. This is how error conditions are described in web APIs.
    /// </summary>
    public class DOMException : JSObject
    {
        /// <summary>
        /// Creates a new .Net exception to represent the DOMException
        /// </summary>
        /// <returns></returns>
        public JSDOMException ToException() => new JSDOMException(this);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
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
    /// <summary>
    /// A .Net exception that represents a DOMException
    /// </summary>
    public class JSDOMException : Exception
    {
        /// <summary>
        /// DOMException.Name
        /// </summary>
        public string DOMExceptionName { get; private set; }
        public string DOMExceptionMessage { get; private set; }
        public JSDOMException(DOMException domException) : base($"{domException.Name ?? "unknown"} - {domException.Message ?? "unknown"}")
        {
            DOMExceptionName = domException.Name ?? "unknown";
            DOMExceptionMessage = domException.Message ?? "unknown";
        }
    }
}
