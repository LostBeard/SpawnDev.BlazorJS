using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DOMException interface represents an abnormal event (called an exception) that occurs as a result of calling a method or accessing a property of a web API. This is how error conditions are described in web APIs.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/DOMException
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
        /// Creates a new DOMException
        /// </summary>
        public DOMException() : base(JS.New(nameof(DOMException))) { }
        /// <summary>
        /// Creates a new DOMException
        /// </summary>
        /// <param name="message"></param>
        public DOMException(string? message) : base(JS.New(nameof(DOMException), message)) { }
        /// <summary>
        /// Creates a new DOMException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="name"></param>
        public DOMException(string? message, string? name) : base(JS.New(nameof(DOMException), message, name)) { }
        /// <summary>
        /// Returns a string representing a message or description associated with the given error name.
        /// </summary>
        public string? Message => JSRef!.Get<string?>("message");
        /// <summary>
        /// Returns a string that contains one of the strings associated with an error name.
        /// </summary>
        public string? Name => JSRef!.Get<string?>("name");
    }
    /// <summary>
    /// A .Net exception that represents a DOMException
    /// </summary>
    public class JSDOMException : Exception
    {
        /// <summary>
        /// DOMException.Name
        /// </summary>
        public string? DOMExceptionName { get; private set; }
        /// <summary>
        /// DOMException.Message
        /// </summary>
        public string? DOMExceptionMessage { get; private set; }
        /// <summary>
        /// Creates a new instance of JSDOMException from a DOMException
        /// </summary>
        /// <param name="domException"></param>
        public JSDOMException(DOMException domException) : base($"{domException.Name ?? "unknown"} - {domException.Message ?? "unknown"}")
        {
            DOMExceptionName = domException.Name ?? "unknown";
            DOMExceptionMessage = domException.Message ?? "unknown";
        }
        /// <summary>
        /// Creates a new instance of JSDOMException from a DOMException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="name"></param>
        public JSDOMException(string? message, string? name) : base($"{name ?? "unknown"} - {message ?? "unknown"}")
        {
            DOMExceptionName = name;
            DOMExceptionMessage = message;
        }
        /// <summary>
        /// Creates a new instance of JSDOMException from a DOMException
        /// </summary>
        /// <param name="message"></param>
        public JSDOMException(string? message) : base($"Error - {message ?? "unknown"}")
        {
            DOMExceptionMessage = message;
        }
    }
}
