namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A number representing a given button<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent/button#value
    /// </summary>
    public enum MouseButton
    {
        /// <summary>
        /// Primary button (usually the left button)
        /// </summary>
        PrimaryButton = 0,
        /// <summary>
        /// Auxiliary button (usually the mouse wheel button or middle button)
        /// </summary>
        AuxiliaryButton = 1,
        /// <summary>
        /// Secondary button (usually the right button)
        /// </summary>
        SecondaryButton = 2,
        /// <summary>
        /// 4th button (typically the "Browser Back" button)
        /// </summary>
        FourthButton = 3,
        /// <summary>
        /// 5th button (typically the "Browser Forward" button)
        /// </summary>
        FifthButton = 4,
    }
}
