using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DataTransferItemList object is a list of DataTransferItem objects representing items being dragged. During a drag operation, each DragEvent has a dataTransfer property and that property is a DataTransferItemList.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/DataTransferItemList
    /// </summary>
    public class DataTransferItemList : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DataTransferItemList(IJSInProcessObjectReference _ref) : base(_ref) { }
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

    }
}
