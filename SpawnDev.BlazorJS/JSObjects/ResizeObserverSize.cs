namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The content box size of the observed element<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserverEntry/contentBoxSize#value
    /// </summary>
    public class ResizeObserverSize
    {
        /// <summary>
        /// The length of the observed element's content box in the block dimension. For boxes with a horizontal writing-mode, this is the vertical dimension, or height; if the writing-mode is vertical, this is the horizontal dimension, or width.
        /// </summary>
        public double BlockSize { get; set; }
        /// <summary>
        /// The length of the observed element's content box in the inline dimension. For boxes with a horizontal writing-mode, this is the horizontal dimension, or width; if the writing-mode is vertical, this is the vertical dimension, or height.
        /// </summary>
        public double InlineSize { get; set; }
    }
}
