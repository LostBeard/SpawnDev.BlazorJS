using Microsoft.JSInterop;
using System.Collections;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The VTTRegionList interface represents a list of VTTRegion objects.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/VTTRegionList
    /// </summary>
    public class VTTRegionList : JSObject, IEnumerable<VTTRegion>
    {
        #region IEnumerable
        /// <inheritdoc/>
        public IEnumerator<VTTRegion> GetEnumerator() => new SimpleEnumerator<VTTRegion>((i) => Item(i), () => Length);
        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
        /// <inheritdoc/>
        public VTTRegionList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the number of regions in the list.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// Returns the VTTRegion object at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public VTTRegion Item(int index) => JSRef!.Call<VTTRegion>("item", index);
        /// <summary>
        /// Returns the VTTRegion object at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public VTTRegion this[int index] => Item(index);
        /// <summary>
        /// Returns the VTTRegion object with the specified ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VTTRegion? GetRegionById(string id) => JSRef!.Call<VTTRegion?>("getRegionById", id);
    }
}
