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
        public JSEventCallback<WindowControlsOverlayGeometryChangeEvent> OnGeometryChange { get => new JSEventCallback<WindowControlsOverlayGeometryChangeEvent>(o => AddEventListener("geometrychange", o), o => RemoveEventListener("geometrychange", o)); set { /** required **/ } }
        #endregion
    }
}
