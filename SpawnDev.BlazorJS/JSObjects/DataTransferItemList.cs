using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DataTransferItemList object is a list of DataTransferItem objects representing items being dragged. During a drag operation, each DragEvent has a dataTransfer property and that property is a DataTransferItemList.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/DataTransferItemList
    /// </summary>
    public class DataTransferItemList : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DataTransferItemList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Indexer property
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public DataTransferItem this[int index]
        {
            get => JSRef!.Get<DataTransferItem>(index);
            set => JSRef!.Set(index, value);
        }
        /// <summary>
        /// Adds an item (either a File object or a string) to the drag item list and returns a DataTransferItem object for the new item.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTransferItem Add(string data) => JSRef!.Call<DataTransferItem>("add", data);
        /// <summary>
        /// Adds an item (either a File object or a string) to the drag item list and returns a DataTransferItem object for the new item.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTransferItem Add(File data) => JSRef!.Call<DataTransferItem>("add", data);
        /// <summary>
        /// An unsigned long that is the number of drag items in the list.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// Removes the drag item from the list at the given index.
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index) => JSRef!.CallVoid("remove", index);
        /// <summary>
        /// Removes all of the drag items from the list.
        /// </summary>
        /// <param name="index"></param>
        public void Clear(int index) => JSRef!.CallVoid("clear", index);
        #region Enumerable like
        /// <summary>
        /// Indexer property
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public DataTransferItem Item(int index) => JSRef!.Get<DataTransferItem>(index);
        /// <summary>
        /// Returns first or default
        /// </summary>
        /// <returns></returns>
        public DataTransferItem? FirstOrDefault() => Length > 0 ? Item(0) : null;
        /// <summary>
        /// Returns last or default
        /// </summary>
        /// <returns></returns>
        public DataTransferItem? LastOrDefault() => Length > 0 ? Item(Length - 1) : null;
        /// <summary>
        /// Returns the array as a .Net Array
        /// </summary>
        /// <returns></returns>
        public DataTransferItem[] ToArray() => Enumerable.Range(0, Length).Select(Item).ToArray();
        /// <summary>
        /// Returns the array as a .Net Array
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public DataTransferItem[] ToArray(int start, int count) => Enumerable.Range(start, count).Select(Item).ToArray();
        /// <summary>
        /// Returns the array as a .Net List
        /// </summary>
        /// <returns></returns>
        public List<DataTransferItem> ToList() => Enumerable.Range(0, Length).Select(Item).ToList();
        /// <summary>
        /// Returns the array as a .Net List
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<DataTransferItem> ToList(int start, int count) => Enumerable.Range(start, count).Select(Item).ToList();
        #endregion
    }
}
