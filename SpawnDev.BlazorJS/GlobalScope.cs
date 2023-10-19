namespace SpawnDev.BlazorJS
{
    [Flags]
    public enum GlobalScope
    {
        None = 0,    // None. If IBackgroundService autostart is disabled. If IAsyncBackgroundService an exception is thrown because the InitAsync will not be called
        Window = 1,
        DedicatedWorker = 2,
        SharedWorker = 4,
        ServiceWorker = 8,
        DedicatedAndSharedWorkers = DedicatedWorker | SharedWorker,
        AllWorkers = DedicatedWorker | SharedWorker | ServiceWorker,
        All = Window | DedicatedWorker | SharedWorker | ServiceWorker,  // Default for IBackgroundService and IAsyncBackgroundService
    }
}
