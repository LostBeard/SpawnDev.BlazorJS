using Microsoft.JSInterop;
using System.Collections;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The FileList interface represents an object of this type returned by the files property of the HTML input element; this lets you access the list of files selected with the input type="file" element. It's also used for a list of files dropped into web content when using the drag and drop API; see the DataTransfer object for details on this usage.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileList
    /// </summary>
    public class FileList : JSObject, IEnumerable<File>
    {
        #region Enable IEnumerable
        public IEnumerator GetEnumerator() => new SimpleEnumerator<File>(this.Item, () => this.Length);
        IEnumerator<File> IEnumerable<File>.GetEnumerator() => new SimpleEnumerator<File>(this.Item, () => this.Length);
        #endregion
        public FileList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A read-only value indicating the number of files in the list.
        /// </summary>
        public int Length => JSRef.Get<int>("length");
        /// <summary>
        /// Returns a File object representing the file at the specified index in the file list.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public File Item(int index) => JSRef.Call<File>("item", index);
    }
}
