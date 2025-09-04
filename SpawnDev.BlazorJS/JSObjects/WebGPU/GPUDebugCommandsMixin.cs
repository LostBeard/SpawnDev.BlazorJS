namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#gpudebugcommandsmixin
    /// </summary>
    public interface GPUDebugCommandsMixin
    {
        /// <summary>
        /// Begins a labeled debug group containing subsequent commands.
        /// </summary>
        /// <param name="groupLabel">The label for the command group.</param>
        void PushDebugGroup(string groupLabel);
        /// <summary>
        /// Ends the labeled debug group most recently started by pushDebugGroup().
        /// </summary>
        void PopDebugGroup();
        /// <summary>
        /// Marks a point in a stream of commands with a label.
        /// </summary>
        /// <param name="markerLabel">The label to insert.</param>
        void InsertDebugMarker(string markerLabel);
    }
}
