using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WindowControlsOverlay interface of the Window Controls Overlay API exposes information about the geometry of the title bar area in desktop Progressive Web Apps, and an event to know whenever it changes. This interface is accessible from Navigator.windowControlsOverlay.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/WindowControlsOverlay
    /// </summary>
    public class WindowControlsOverlay : EventTarget
    {
        #region Constructors
        public WindowControlsOverlay(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// A Boolean that indicates whether the window controls overlay is visible or not.
        /// </summary>
        public bool Visible => JSRef.Get<bool>("visible");
        #endregion

        #region Methods
        /// <summary>
        /// The getTitlebarAreaRect() method of the WindowControlsOverlay interface queries the current geometry of the title bar area of the Progressive Web App window.
        /// </summary>
        /// <returns></returns>
        public DOMRectReadOnly GetTitlebarAreaRect() => JSRef.Call<DOMRectReadOnly>("getTitlebarAreaRect");
        #endregion

        #region Events
        /// <summary>
        /// The geometrychange event is fired when the position, size, or visibility of a Progressive Web App's title bar area changes
        /// </summary>
        public JSEventCallback OnGeometrychange { get => new JSEventCallback(o => AddEventListener("geometrychange", o), o => RemoveEventListener("geometrychange", o)); set { /** required **/ } }
        #endregion
    }
    /// <summary>
    /// The CharacterData abstract interface represents a Node object that contains characters. This is an abstract interface, meaning there aren't any objects of type CharacterData: it is implemented by other interfaces like Text, Comment, CDATASection, or ProcessingInstruction, which aren't abstract.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/CharacterData
    /// </summary>
    public class CharacterData : Node
    {
        #region Constructors
        public CharacterData(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        public string Data => JSRef.Get<string>("data");
        public int Length => JSRef.Get<int>("length");
        public Element? NextElementSibling => JSRef.Get<Element?>("nextElementSibling");
        public Element? PreviousElementSibling => JSRef.Get<Element?>("previousElementSibling");
        #endregion

        #region Methods
        // TODO
        #endregion
    }
}
