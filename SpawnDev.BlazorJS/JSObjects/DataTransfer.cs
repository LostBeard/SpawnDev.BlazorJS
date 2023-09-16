using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class DataTransfer : JSObject
    {
        public DataTransferItemList Items => JSRef.Get<DataTransferItemList>("items");
        public DataTransfer(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Contains a list of all the local files available on the data transfer. If the drag operation doesn't involve dragging files, this property is an empty list.
        /// </summary>
        public Array<File>? Files => JSRef.Get<Array<File>?>("files");
        /// <summary>
        /// Gets the type of drag-and-drop operation currently selected or sets the operation to a new type. The value must be none, copy, link or move
        /// </summary>
        public string DropEffect { get => JSRef.Get<string>("dropEffect"); set => JSRef.Set("dropEffect", value); }
        /// <summary>
        /// Provides all of the types of operations that are possible. Must be one of none, copy, copyLink, copyMove, link, linkMove, move, all or uninitialized.
        /// </summary>
        public string EffectAllowed { get => JSRef.Get<string>("effectAllowed"); set => JSRef.Set("effectAllowed", value); }
        /// <summary>
        /// Set the image to be used for dragging if a custom one is desired.
        /// </summary>
        /// <param name="imgElement"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        public void SetDragImage(Element imgElement, long xOffset, long yOffset) => JSRef.CallVoid("setDragImage", imgElement, xOffset, yOffset);
        /// <summary>
        /// Set the data for a given type. If data for the type does not exist, it is added at the end, such that the last item in the types list will be the new format. If data for the type already exists, the existing data is replaced in the same position.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="data"></param>
        public void SetData(string format, string data) => JSRef.CallVoid("setData", format, data);
        /// <summary>
        /// Remove the data associated with a given type. The type argument is optional. If the type is empty or not specified, the data associated with all types is removed. If data for the specified type does not exist, or the data transfer contains no data, this method will have no effect.
        /// </summary>
        public void ClearData() => JSRef.CallVoid("clearData");
        /// <summary>
        /// Remove the data associated with a given type. The type argument is optional. If the type is empty or not specified, the data associated with all types is removed. If data for the specified type does not exist, or the data transfer contains no data, this method will have no effect.
        /// </summary>
        /// <param name="format"></param>
        public void ClearData(string format) => JSRef.CallVoid("clearData", format);
        /// <summary>
        /// Retrieves the data for a given type, or an empty string if data for that type does not exist or the data transfer contains no data.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string GetData(string format) => JSRef.Call<string>("getData", format);
        /// <summary>
        /// The DataTransfer.addElement() method sets the drag source to the given element. This element will be the element to which drag and dragend events are fired, and not the default target (the node that was dragged).
        /// </summary>
        /// <param name="element"></param>
        public void AddElement(Element element) => JSRef.CallVoid("addElement", element);
    }
}
