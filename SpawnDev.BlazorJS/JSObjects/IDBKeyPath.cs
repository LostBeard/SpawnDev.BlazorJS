//using System.Collections.Generic;

//namespace SpawnDev.BlazorJS.JSObjects
//{
//    /// <summary>
//    /// A key path is a string or list of strings that defines how to extract a key from a value. A valid key path is one of:<br />
//    /// - An empty string.<br />
//    /// - An identifier, which is a string matching the IdentifierName production from the ECMAScript Language Specification [ECMA-262].<br />
//    /// - A string consisting of two or more identifiers separated by periods (U+002E FULL STOP).<br />
//    /// - A non-empty list containing only strings conforming to the above requirements.<br />
//    /// https://w3c.github.io/IndexedDB/#key-path-construct
//    /// </summary>
//    public class IDBKeyPath : Union<string, string[]>
//    {
//        public static implicit operator IDBKeyPath(string keyPath) => new IDBKeyPath(keyPath);
//        public static implicit operator IDBKeyPath(string[] keyPath) => new IDBKeyPath(keyPath);
//        /// <summary>
//        /// Constructor for string
//        /// </summary>
//        /// <param name="value"></param>
//        public IDBKeyPath(string value) : base(value) { }
//        /// <summary>
//        /// Constructor for IEnumerable<string>
//        /// </summary>
//        /// <param name="value"></param>
//        public IDBKeyPath(string[] value) : base(value) { }
//    }
//}
