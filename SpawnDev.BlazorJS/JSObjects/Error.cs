using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A .Net exception that represents a Javascript Error and makes the Error information available if needed
    /// </summary>
    public class JSException : Exception
    {
        /// <summary>
        /// Returns the error message
        /// </summary>
        public override string Message => _Message.Value;
        /// <summary>
        /// Returns the Error type name
        /// </summary>
        public string Name => _Name.Value;
        /// <summary>
        /// Returns the Error toString() value
        /// </summary>
        /// <returns></returns>
        public override string ToString() => _ToString.Value;
        private Lazy<string> _Message;
        private Lazy<string> _Name;
        private Lazy<string> _ToString;
        /// <summary>
        /// The Javascript Error this exception represents
        /// </summary>
        public Error? Error { get; private set; }
        /// <summary>
        /// Creates a new Exception to represent a Javascript Error
        /// </summary>
        public JSException(Error error) : base()
        {
            Error = error;
            _Message = new Lazy<string>(() => Error.Message ?? "");
            _Name = new Lazy<string>(() => Error.Name ?? "");
            _ToString = new Lazy<string>(() => Error.JSRef!.IsUndefined("toString") ? base.ToString() : Error.ToString() ?? base.ToString());
        }
        /// <summary>
        /// Creates a new Exception to represent a Javascript Error
        /// </summary>
        public JSException(string message, string? name = null) : base()
        {
            _Message = new Lazy<string>(message);
            _Name = new Lazy<string>(() => name ?? "");
            _ToString = new Lazy<string>(string.IsNullOrEmpty(name) ? $"{message}" : $"{name}: {message}");
        }
    }
    /// <summary>
    /// Error objects are thrown when runtime errors occur. The Error object can also be used as a base object for user-defined exceptions. See below for standard built-in error types.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Error
    /// </summary>
    public class Error : JSObject
    {
        /// <summary>
        /// Creates a new .Net exception to represent the error
        /// </summary>
        /// <returns></returns>
        public virtual JSException ToException() => new JSException(this);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Error(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new Error
        /// </summary>
        public Error() : base(JS.New(nameof(Error))) { }
        /// <summary>
        /// Creates a new Error
        /// </summary>
        /// <param name="message">A human-readable description of the error.</param>
        public Error(string message) : base(JS.New(nameof(Error), message)) { }
        /// <summary>
        /// Creates a new Error
        /// </summary>
        /// <param name="message">A human-readable description of the error.</param>
        /// <param name="options">Error options</param>
        public Error(string message, ErrorOptions options) : base(JS.New(nameof(Error), message, options)) { }
        /// <summary>
        /// Creates a new Error
        /// </summary>
        /// <param name="message">A human-readable description of the error.</param>
        /// <param name="fileName">The path to the file that raised this error, reflected in the fileName property. Defaults to the name of the file containing the code that called the Error() constructor.</param>
        public Error(string message, string fileName) : base(JS.New(nameof(Error), message, fileName)) { }
        /// <summary>
        /// Creates a new Error
        /// </summary>
        /// <param name="message">A human-readable description of the error.</param>
        /// <param name="fileName">The path to the file that raised this error, reflected in the fileName property. Defaults to the name of the file containing the code that called the Error() constructor.</param>
        /// <param name="lineNumber">The line number within the file on which the error was raised, reflected in the lineNumber property. Defaults to the line number containing the Error() constructor invocation.</param>
        public Error(string message, string fileName, int lineNumber) : base(JS.New(nameof(Error), message, fileName, lineNumber)) { }
        /// <summary>
        /// Represents the name for the type of error. For Error.prototype.name, the initial value is "Error". Subclasses like TypeError and SyntaxError provide their own name properties.
        /// </summary>
        public string? Name => JSRef!.Get<string?>("name");
        /// <summary>
        /// A non-standard property for a stack trace.
        /// </summary>
        public string? Stack => JSRef!.Get<string?>("stack");
        /// <summary>
        /// Error cause indicating the reason why the current error is thrown — usually another caught error. For user-created Error objects, this is the value provided as the cause property of the constructor's second argument.
        /// </summary>
        public Error? Cause => JSRef!.Get<Error?>("cause");
        /// <summary>
        /// A non-standard Mozilla property for the column number in the line that raised this error.
        /// </summary>
        public int? ColumnNumber => JSRef!.Get<int?>("columnNumber");
        /// <summary>
        /// A non-standard Mozilla property for the path to the file that raised this error.
        /// </summary>
        public string? FileName => JSRef!.Get<string?>("fileName");
        /// <summary>
        /// A non-standard Mozilla property for the line number in the file that raised this error.
        /// </summary>
        public int? LineNumber => JSRef!.Get<int?>("lineNumber");
        /// <summary>
        /// Error message. For user-created Error objects, this is the string provided as the constructor's first argument.
        /// </summary>
        public string? Message => JSRef!.Get<string?>("message");
        /// <summary>
        /// Returns a string representing the specified object. Overrides the Object.prototype.toString() method.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JSRef!.Call<string>("toString");
    }
}
