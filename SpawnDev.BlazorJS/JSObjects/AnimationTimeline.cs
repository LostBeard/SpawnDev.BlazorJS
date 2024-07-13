using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AnimationTimeline interface of the Web Animations API represents the timeline of an animation.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/AnimationTimeline
    /// </summary>
    public class AnimationTimeline : JSObject
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AnimationTimeline(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the time value in milliseconds for this timeline or null if this timeline is inactive.
        /// </summary>
        public float? CurrentTime => JSRef!.Get<float?>("currentTime");
        #endregion
    }
}