namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// IAsyncBackgroundServices are IAsyncServices started at app startup by default
    /// or started based on GlobalScope settings when registered and the current global scope<br/>
    /// </summary>
    public interface IAsyncBackgroundService : IBackgroundService, IAsyncService { }
}
