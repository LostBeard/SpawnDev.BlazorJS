namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// The WorkerTransferAttribute is used to mark values that should be added to the transferred list when send to another context
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.ReturnValue | AttributeTargets.Parameter, Inherited = false, AllowMultiple = true)]
    public class WorkerTransferAttribute : Attribute
    {
        /// <summary>
        /// If true, the value will be added to the transferables list
        /// </summary>
        public bool Transfer { get; private set; } = true;
        /// <summary>
        /// New instance
        /// </summary>
        /// <param name="transfer"></param>
        public WorkerTransferAttribute(bool transfer = true) => Transfer = transfer;
    }
}
