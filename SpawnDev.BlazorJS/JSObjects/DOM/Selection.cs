using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A Selection object represents the range of text selected by the user or the current position of the caret. To obtain a Selection object for examination or manipulation, call window.getSelection().<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Selection<br/>
    /// TODO - finish
    /// </summary>
    public class Selection : JSObject
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Selection(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the Node in which the selection begins. Can return null if selection never existed in the document (e.g., an iframe that was never clicked on).
        /// </summary>
        public Node AnchorNode => JSRef!.Get<Node>("anchorNode");
        /// <summary>
        /// Returns a number representing the offset of the selection's anchor within the anchorNode. If anchorNode is a text node, this is the number of characters within anchorNode preceding the anchor. If anchorNode is an element, this is the number of child nodes of the anchorNode preceding the anchor.
        /// </summary>
        public int AnchorOffset => JSRef!.Get<int>("anchorOffset");
        /// <summary>
        /// Returns the Node in which the selection begins.
        /// </summary>
        public Node BaseNode => JSRef!.Get<Node>("baseNode");
        /// <summary>
        /// Returns a number representing the offset of the selection's anchor within the baseNode.
        /// </summary>
        public int BaseOffset => JSRef!.Get<int>("baseOffset");
        /// <summary>
        /// Returns the Node in which the selection ends.
        /// </summary>
        public Node ExtentNode => JSRef!.Get<Node>("extentNode");
        /// <summary>
        /// Returns a number representing the offset of the selection's anchor within the extentNode.
        /// </summary>
        public int ExtentOffset => JSRef!.Get<int>("extentOffset");
        /// <summary>
        /// Returns the Node in which the selection ends. Can return null if selection never existed in the document (for example, in an iframe that was never clicked on).
        /// </summary>
        public Node FocusNode => JSRef!.Get<Node>("focusNode");
        /// <summary>
        /// Returns a number representing the offset of the selection's anchor within the focusNode. If focusNode is a text node, this is the number of characters within focusNode preceding the focus. If focusNode is an element, this is the number of child nodes of the focusNode preceding the focus.
        /// </summary>
        public int FocusOffset => JSRef!.Get<int>("focusOffset");
        /// <summary>
        /// Returns a Boolean indicating whether the selection's start and end points are at the same position.
        /// </summary>
        public bool IsCollapsed => JSRef!.Get<bool>("isCollapsed");
        /// <summary>
        /// Returns the number of ranges in the selection.
        /// </summary>
        public int RangeCount => JSRef!.Get<int>("rangeCount");
        /// <summary>
        /// Returns a string describing the type of the current selection.
        /// </summary>
        public string Type => JSRef!.Get<string>("type");
        #endregion

        #region Methods
        //public void AddRange() => JSRef!.CallVoid("addRange");
        //public void Collapse() => JSRef!.CallVoid("collapse");
        //public void CollapseToEnd() => JSRef!.CallVoid("collapseToEnd");
        //public void CollapseToStart() => JSRef!.CallVoid("collapseToStart");
        //public void ContainsNode() => JSRef!.CallVoid("containsNode");
        //public void DeleteFromDocument() => JSRef!.CallVoid("deleteFromDocument");
        //public void Empty() => JSRef!.CallVoid("empty");
        //public void Extend() => JSRef!.CallVoid("extend");
        //public void GetRangeAt() => JSRef!.CallVoid("getRangeAt");
        //public void Modify() => JSRef!.CallVoid("modify");
        //public void RemoveAllRanges() => JSRef!.CallVoid("removeAllRanges");
        //public void RemoveRange() => JSRef!.CallVoid("removeRange");
        //public void SelectAllChildren() => JSRef!.CallVoid("selectAllChildren");
        //public void SetBaseAndExtent() => JSRef!.CallVoid("setBaseAndExtent");
        //public void SetPosition() => JSRef!.CallVoid("setPosition");
        /// <summary>
        /// Returns a string representation of the selection.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JSRef!.Call<string>("toString");
        #endregion
    }
}
