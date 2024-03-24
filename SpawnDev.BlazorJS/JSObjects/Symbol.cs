using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Symbol is a built-in object whose constructor returns a symbol primitive — also called a Symbol value or just a Symbol — that's guaranteed to be unique. Symbols are often used to add unique property keys to an object that won't collide with keys any other code might add to the object, and which are hidden from any mechanisms other code will typically use to access the object. That enables a form of weak encapsulation, or a weak form of information hiding.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Symbol
    /// </summary>
    public class Symbol : JSObject
    {
        /// <summary>
        /// This is a non-standard implementation of the Symbol constructor which in Javascript will throw an exception. Call Symbol(description)
        /// </summary>
        /// <param name="description">A string. A description of the symbol which can be used for debugging but not to access the symbol itself.</param>
        public Symbol(string description) : base(JS.Call<IJSInProcessObjectReference>(nameof(Symbol), description)) { }

        /// <summary>
        /// This is a non-standard implementation of the Symbol constructor which in Javascript will throw an exception. Calls Symbol()
        /// </summary>
        public Symbol() : base(JS.Call<IJSInProcessObjectReference>(nameof(Symbol))) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Symbol(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The description accessor property of Symbol values returns a string containing the description of this symbol, or undefined if the symbol has no description.
        /// </summary>
        public string? Description => JSRef.Get<string?>("description");
        /// <summary>
        /// The Symbol.isConcatSpreadable static data property represents the well-known symbol @@isConcatSpreadable. The Array.prototype.concat() method looks up this symbol on each object being concatenated to determine if it should be treated as an array-like object and flattened to its array elements.<br />
        /// Do not dispose.
        /// </summary>
        public static Symbol IsConcatSpreadable => _IsConcatSpreadable.Value;
        private static Lazy<Symbol> _IsConcatSpreadable = new Lazy<Symbol>(() => JS.Get<Symbol>("Symbol.isConcatSpreadable"));
        /// <summary>
        /// The Symbol.iterator static data property represents the well-known symbol @@iterator. The iterable protocol looks up this symbol for the method that returns the iterator for an object. In order for an object to be iterable, it must have an @@iterator key.<br />
        /// Do not dispose.
        /// </summary>
        public static Symbol Iterator => _Iterator.Value;
        private static Lazy<Symbol> _Iterator = new Lazy<Symbol>(() => JS.Get<Symbol>("Symbol.iterator"));
        /// <summary>
        /// The Symbol.asyncIterator static data property represents the well-known symbol @@asyncIterator. The async iterable protocol looks up this symbol for the method that returns the async iterator for an object. In order for an object to be async iterable, it must have an @@asyncIterator key.<br />
        /// Do not dispose.
        /// </summary>
        public static Symbol AsyncIterator => _AsyncIterator.Value;
        private static Lazy<Symbol> _AsyncIterator = new Lazy<Symbol>(() => JS.Get<Symbol>("Symbol.asyncIterator"));
        /// <summary>
        /// The Symbol.hasInstance static data property represents the well-known symbol @@hasInstance. The instanceof operator looks up this symbol on its right-hand operand for the method used to determine if the constructor object recognizes an object as its instance.<br />
        /// Do not dispose.
        /// </summary>
        public static Symbol HasInstance => _HasInstance.Value;
        private static Lazy<Symbol> _HasInstance = new Lazy<Symbol>(() => JS.Get<Symbol>("Symbol.hasInstance"));
        /// <summary>
        /// The Symbol.for() static method searches for existing symbols in a runtime-wide symbol registry with the given key and returns it if found. Otherwise a new symbol gets created in the global symbol registry with this key.
        /// </summary>
        /// <param name="key">String, required. The key for the symbol (and also used for the description of the symbol).</param>
        /// <returns></returns>
        public static Symbol For(string key) => JS.Call<Symbol>($"{nameof(Symbol)}.for", key);
        /// <summary>
        /// The Symbol.keyFor() static method retrieves a shared symbol key from the global symbol registry for the given symbol.
        /// </summary>
        /// <param name="sym">Symbol, required. The symbol to find a key for.</param>
        /// <returns></returns>
        public static string? KeyFor(Symbol sym) => JS.Call<string?>($"{nameof(Symbol)}.keyFor", sym);
    }
}
