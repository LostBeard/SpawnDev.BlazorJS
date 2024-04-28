using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The FileList interface represents an object of this type returned by the files property of the HTML input element; this lets you access the list of files selected with the input type="file" element. It's also used for a list of files dropped into web content when using the drag and drop API; see the DataTransfer object for details on this usage.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileList
    /// </summary>
    public class FileList : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public FileList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A read-only value indicating the number of files in the list.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// Returns a File object representing the file at the specified index in the file list.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public File Item(int index) => JSRef!.Call<File>("item", index);
        #region Enumerable like
        /// <summary>
        /// Indexer property
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public File this[int i] => Item(i);
        /// <summary>
        /// Returns first or default
        /// </summary>
        /// <returns></returns>
        public File? FirstOrDefault() => Length > 0 ? Item(0) : null;
        /// <summary>
        /// Returns last or default
        /// </summary>
        /// <returns></returns>
        public File? LastOrDefault() => Length > 0 ? Item(Length - 1) : null;
        /// <summary>
        /// Returns the array as a .Net Array
        /// </summary>
        /// <returns></returns>
        public File[] ToArray() => Enumerable.Range(0, Length).Select(Item).ToArray();
        /// <summary>
        /// Returns the array as a .Net Array
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public File[] ToArray(int start, int count) => Enumerable.Range(start, count).Select(Item).ToArray();
        /// <summary>
        /// Returns the array as a .Net List
        /// </summary>
        /// <returns></returns>
        public List<File> ToList() => Enumerable.Range(0, Length).Select(Item).ToList();
        /// <summary>
        /// Returns the array as a .Net List
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<File> ToList(int start, int count) => Enumerable.Range(start, count).Select(Item).ToList();
        #endregion
    }
}
