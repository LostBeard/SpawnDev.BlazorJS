using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Iteration protocols aren't new built-ins or syntax, but protocols. These protocols can be implemented by any object by following some conventions.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Iteration_protocols
    /// </summary>
    public class Iterator : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Iterator(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the next IteratorResult
        /// </summary>
        /// <returns></returns>
        public IteratorResult Next() => JSRef!.Call<IteratorResult>("next");
        /// <summary>
        /// Returns the next IteratorResult&lt;TValue&gt;
        /// </summary>
        /// <returns></returns>
        public IteratorResult<TValue> Next<TValue>() => JSRef!.Call<IteratorResult<TValue>>("next");
        /// <summary>
        /// Returns all the enumerated results as a List
        /// </summary>
        /// <returns></returns>
        public List<TValue> ToList<TValue>() => ToEnumerable<TValue>().ToList();
        /// <summary>
        /// Returns all the enumerated results as a .Net Array
        /// </summary>
        /// <returns></returns>
        public TValue[] ToArray<TValue>() => ToEnumerable<TValue>().ToArray();
        /// <summary>
        /// Returns an IEnumerable&lt;TValue&gt;
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public IEnumerable<TValue> ToEnumerable<TValue>()
        {
            while (true)
            {
                using (var next = Next())
                {
                    if (next.Done) break;
                    yield return next.GetValue<TValue>();
                }
            }
        }
    }
    /// <summary>
    /// Iteration protocols aren't new built-ins or syntax, but protocols. These protocols can be implemented by any object by following some conventions.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Iteration_protocols
    /// </summary>
    public class Iterator<TValue> : JSObject
    {
        /// <summary>
        /// Converts this iterator to a List
        /// </summary>
        /// <param name="iterator"></param>
        public static implicit operator List<TValue>?(Iterator<TValue>? iterator) => iterator == null ? null : iterator.ToList();
        /// <summary>
        /// Converts this iterator to a .Net Array
        /// </summary>
        /// <param name="iterator"></param>
        public static implicit operator TValue[]?(Iterator<TValue>? iterator) => iterator == null ? null : iterator.ToArray();
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Iterator(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the next IteratorResult&lt;TValue&gt;
        /// </summary>
        /// <returns></returns>
        public IteratorResult<TValue> Next() => JSRef!.Call<IteratorResult<TValue>>("next");
        /// <summary>
        /// Returns all the enumerated results as a List
        /// </summary>
        /// <returns></returns>
        public List<TValue> ToList() => ToEnumerable().ToList();
        /// <summary>
        /// Returns all the enumerated results as a .Net Array
        /// </summary>
        /// <returns></returns>
        public TValue[] ToArray() => ToEnumerable().ToArray();
        /// <summary>
        /// Returns an IEnumerable&lt;TValue&gt;
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TValue> ToEnumerable()
        {
            while (true)
            {
                using (var next = Next())
                {
                    if (next.Done) break;
                    yield return next.Value;
                }
            }
        }
    }
}
