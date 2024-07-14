using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object whose properties are functions that define the behavior of the proxy when an operation is performed on it.
    /// </summary>
    public class ProxyHandler : IDisposable
    {
        #region Apply
        /// <summary>
        /// The handler.apply() method is a trap for the [[Call]] object internal method, which is used by operations such as function calls.<br/>
        /// target - The target callable object.<br/>
        /// thisArg - The this argument for the call.<br/>
        /// argumentsList - The list of arguments for the call.<br/>
        /// Returns:<br/>
        /// The apply() method can return any value.
        /// </summary>
        [JsonIgnore]
        public Func<JSObject, JSObject, Array<JSObject?>, object?>? Apply
        {
            get => _Apply;
            set
            {
                _Apply = value;
                _ApplyCallback?.Dispose();
                _ApplyCallback = _Apply == null ? null : new FuncCallback<JSObject, JSObject, Array<JSObject?>, object?>(_Apply);
            }
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("apply")]
        [JsonInclude]
        private FuncCallback<JSObject, JSObject, Array<JSObject?>, object?>? ApplyCallback => _ApplyCallback;
        private Func<JSObject, JSObject, Array<JSObject?>, object?>? _Apply = null;
        private FuncCallback<JSObject, JSObject, Array<JSObject?>, object?>? _ApplyCallback = null;
        #endregion
        #region Get
        /// <summary>
        /// The handler.get() method is a trap for the [[Get]] object internal method, which is used by operations such as property accessors.<br/>
        /// target - The target object.<br/>
        /// property - The name or Symbol of the property to get.<br/>
        /// receiver - Either the proxy or an object that inherits from the proxy.<br/>
        /// Returns:<br/>
        /// The get() method can return any value.
        /// </summary>
        [JsonIgnore]
        public Func<JSObject, JSObject, JSObject, object?>? Get
        {
            get => _Get;
            set
            {
                _Get = value;
                _GetCallback?.Dispose();
                _GetCallback = _Get == null ? null : new FuncCallback<JSObject, JSObject, JSObject, object?>(_Get);
            }
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("get")]
        [JsonInclude]
        private FuncCallback<JSObject, JSObject, JSObject, object?>? GetCallback => _GetCallback;
        private Func<JSObject, JSObject, JSObject, object?>? _Get = null;
        private FuncCallback<JSObject, JSObject, JSObject, object?>? _GetCallback = null;
        #endregion
        #region Construct
        /// <summary>
        /// The handler.construct() method is a trap for the [[Construct]] object internal method, which is used by operations such as the new operator. In order for the new operation to be valid on the resulting Proxy object, the target used to initialize the proxy must itself be a valid constructor.<br/>
        /// target - The target object.<br/>
        /// argumentsList - The list of arguments for the constructor.<br/>
        /// newTarget - The constructor that was originally called.<br/>
        /// Returns:<br/>
        /// The construct method must return an object.
        /// </summary>
        [JsonIgnore]
        public Func<JSObject, Array<JSObject?>, JSObject, object?>? Construct
        {
            get => _Construct;
            set
            {
                _Construct = value;
                _ConstructCallback?.Dispose();
                _ConstructCallback = _Construct == null ? null : new FuncCallback<JSObject, Array<JSObject?>, JSObject, object?>(_Construct);
            }
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("construct")]
        [JsonInclude]
        private FuncCallback<JSObject, Array<JSObject?>, JSObject, object?>? ConstructCallback => _ConstructCallback;
        private Func<JSObject, Array<JSObject?>, JSObject, object?>? _Construct = null;
        private FuncCallback<JSObject, Array<JSObject?>, JSObject, object?>? _ConstructCallback = null;
        #endregion
        #region Set
        /// <summary>
        /// The handler.set() method is a trap for the [[Set]] object internal method, which is used by operations such as using property accessors to set a property's value.<br/>
        /// target - The target object.<br/>
        /// property - The name or Symbol of the property to set.<br/>
        /// value - The new value of the property to set.<br/>
        /// receiver - The object to which the assignment was originally directed. This is usually the proxy itself. But a set() handler can also be called indirectly, via the prototype chain or various other ways.<br/>
        /// Returns:<br/>
        /// The set() method should return a boolean value.
        /// </summary>
        [JsonIgnore]
        public Func<JSObject, JSObject, JSObject, bool>? Set
        {
            get => _Set;
            set
            {
                _Set = value;
                _SetCallback?.Dispose();
                _SetCallback = _Set == null ? null : new FuncCallback<JSObject, JSObject, JSObject, bool>(_Set);
            }
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("set")]
        [JsonInclude]
        private FuncCallback<JSObject, JSObject, JSObject, bool>? SetCallback => _SetCallback;
        private Func<JSObject, JSObject, JSObject, bool>? _Set = null;
        private FuncCallback<JSObject, JSObject, JSObject, bool>? _SetCallback = null;
        #endregion
        #region Has
        /// <summary>
        /// The handler.has() method is a trap for the [[HasProperty]] object internal method, which is used by operations such as the in operator.<br/>
        /// target - The target object.<br/>
        /// prop - The name or Symbol of the property to check for existence.<br/>
        /// Returns:<br/>
        /// The has() method must return a boolean value.
        /// </summary>
        [JsonIgnore]
        public Func<JSObject, JSObject, bool>? Has
        {
            get => _Has;
            set
            {
                _Has = value;
                _HasCallback?.Dispose();
                _HasCallback = _Has == null ? null : new FuncCallback<JSObject, JSObject, bool>(_Has);
            }
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("has")]
        [JsonInclude]
        private FuncCallback<JSObject, JSObject, bool>? HasCallback => _HasCallback;
        private Func<JSObject, JSObject, bool>? _Has = null;
        private FuncCallback<JSObject, JSObject, bool>? _HasCallback = null;
        #endregion
        #region OwnKeys
        /// <summary>
        /// The handler.ownKeys() method is a trap for the [[OwnPropertyKeys]] object internal method, which is used by operations such as Object.keys(), Reflect.ownKeys(), etc.<br/>
        /// target - The target object.<br/>
        /// Returns:<br/>
        /// The ownKeys() method must return an enumerable object.
        /// </summary>
        [JsonIgnore]
        public Func<JSObject, IEnumerable<Union<Symbol, string>>>? OwnKeys
        {
            get => _OwnKeys;
            set
            {
                _OwnKeys = value;
                _OwnKeysCallback?.Dispose();
                _OwnKeysCallback = _OwnKeys == null ? null : new FuncCallback<JSObject, IEnumerable<Union<Symbol, string>>>(_OwnKeys);
            }
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("ownKeys")]
        [JsonInclude]
        private FuncCallback<JSObject, IEnumerable<Union<Symbol, string>>>? OwnKeysCallback => _OwnKeysCallback;
        private Func<JSObject, IEnumerable<Union<Symbol, string>>>? _OwnKeys = null;
        private FuncCallback<JSObject, IEnumerable<Union<Symbol, string>>>? _OwnKeysCallback = null;
        #endregion
        #region DeleteProperty
        /// <summary>
        /// The handler.DeleteProperty() method is a trap for the [[Delete]] object internal method, which is used by operations such as the delete operator.<br/>
        /// target - The target object.<br/>
        /// property - The name or Symbol of the property to delete.<br/>
        /// Returns:<br/>
        /// The DeleteProperty() method must return a boolean value indicating whether or not the property has been successfully deleted.
        /// </summary>
        [JsonIgnore]
        public Func<JSObject, JSObject, bool>? DeleteProperty
        {
            get => _DeleteProperty;
            set
            {
                _DeleteProperty = value;
                _DeletePropertyCallback?.Dispose();
                _DeletePropertyCallback = _DeleteProperty == null ? null : new FuncCallback<JSObject, JSObject, bool>(_DeleteProperty);
            }
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("deleteProperty")]
        [JsonInclude]
        private FuncCallback<JSObject, JSObject, bool>? DeletePropertyCallback => _DeletePropertyCallback;
        private Func<JSObject, JSObject, bool>? _DeleteProperty = null;
        private FuncCallback<JSObject, JSObject, bool>? _DeletePropertyCallback = null;
        #endregion

        /// <summary>
        /// Disposes all callbacks
        /// </summary>
        public void Dispose()
        {
            Apply = null;
            Get = null;
            Construct = null;
            Set = null;
            Has = null;
            OwnKeys = null;
        }
    }
}
