using Microsoft.JSInterop;
using SpawnDev.BlazorJS;
/// <summary>
/// The AnimationTimeline interface of the Web Animations API represents the timeline of an animation.
/// </summary>
public class AnimationTimeline : JSObject
{
    #region Constructors
    public AnimationTimeline(IJSInProcessObjectReference _ref) : base(_ref) { }
    #endregion

    #region Properties
    /// <summary>
    /// Returns the time value in milliseconds for this timeline or null if this timeline is inactive.
    /// </summary>
    public float? CurentTime => JSRef.Get<float?>("currentTime");
    #endregion
}
