namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// A simple enumerator the can be created using 2 callbacks
    /// </summary>
    /// <typeparam name="TEnumerable"></typeparam>
    public class SimpleEnumerator<TEnumerable> : IEnumerator<TEnumerable>
    {
        int position = -1;
        Func<int, TEnumerable> ItemGetter;
        Func<int> LengthGetter;
        /// <summary>
        /// Creates a SimpleEnumerator instance
        /// </summary>
        /// <param name="itemGetter">called when an indexed item is needed</param>
        /// <param name="lengthGetter">called when </param>
        public SimpleEnumerator(Func<int, TEnumerable> itemGetter, Func<int> lengthGetter)
        {
            ItemGetter = itemGetter;
            LengthGetter = lengthGetter;
        }
        /// <summary>
        /// Increments the position
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            position++;
            return position < LengthGetter();
        }
        /// <summary>
        /// Resets the position
        /// </summary>
        public void Reset()
        {
            position = -1;
        }
        /// <summary>
        /// Not used. Here to satisfy IEnumerator implementation requirement
        /// </summary>
        public void Dispose() { }
        /// <summary>
        /// Returns the enumerator's current value asn an object?
        /// </summary>
        public object? Current => ItemGetter(position);
        /// <summary>
        /// Returns the enumerator's current value as type TEnumerable
        /// </summary>
        TEnumerable IEnumerator<TEnumerable>.Current => ItemGetter(position);
    }
}
