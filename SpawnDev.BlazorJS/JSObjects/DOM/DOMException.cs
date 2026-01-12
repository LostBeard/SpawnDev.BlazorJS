using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DOMException interface represents an abnormal event (called an exception) that occurs as a result of calling a method or accessing a property of a web API. This is how error conditions are described in web APIs.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/DOMException
    /// </summary>
    public class DOMException : Error
    {
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
    }
}
