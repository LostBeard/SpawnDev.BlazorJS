using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DocumentTimeline interface of the Web Animations API represents animation timelines, including the default document timeline (accessed via Document.timeline).<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/DocumentTimeline
    /// </summary>
    public class DocumentTimeline : AnimationTimeline
    {
        #region Constructors
        /// <summary>
        /// The DocumentTimeline() constructor of the Web Animations API creates a new instance of the DocumentTimeline object associated with the active document of the current browsing context.
        /// </summary>
        /// <param name="options"></param>
        public DocumentTimeline(DocumentTimelineOptions options) : base(JS.New(nameof(DocumentTimeline), options)) { }
        /// <summary>
        /// The DocumentTimeline() constructor of the Web Animations API creates a new instance of the DocumentTimeline object associated with the active document of the current browsing context.
        /// </summary>
        public DocumentTimeline() : base(JS.New(nameof(DocumentTimeline))) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DocumentTimeline(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
    }
}
