namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// IAsyncServices have a Ready Task property that completes successfully when the service is ready for use.<br/>
    /// </summary>
    public interface IAsyncService
    {
        /// <summary>
        /// Completes successfully when asynchronous initialization has completed
        /// </summary>
        Task Ready { get; }
    }
}
