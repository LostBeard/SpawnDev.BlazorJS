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
        /// 
        /// </summary>
        /// <param name="itemGetter">called when an indexed item is needed</param>
        /// <param name="lengthGetter">called when </param>
        public SimpleEnumerator(Func<int, TEnumerable> itemGetter, Func<int> lengthGetter)
        {
            ItemGetter = itemGetter;
            LengthGetter = lengthGetter;
        }
        public bool MoveNext()
        {
            position++;
            return (position < LengthGetter());
        }
        public void Reset()
        {
            position = -1;
        }
        public void Dispose() { }
        public object Current => ItemGetter(position);
        TEnumerable IEnumerator<TEnumerable>.Current => ItemGetter(position);
    }
}
