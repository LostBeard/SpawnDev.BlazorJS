namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Exception thrown when a Promise is rejected and caught
    /// </summary>
    /// <typeparam name="TCatch"></typeparam>
    public class PromiseCatchException<TCatch> : Exception
    {
        /// <summary>
        /// The value that was caught
        /// </summary>
        public TCatch CatchValue { get; init; }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="catchValue"></param>
        public PromiseCatchException(TCatch catchValue)
        {
            CatchValue = catchValue;
        }
    }
}
