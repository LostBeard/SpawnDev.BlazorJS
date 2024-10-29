namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// GlobalScope is used in calls to IServiceCollection.AddSingleton() to control the scopes in which the service is automatically started.
    /// </summary>
    [Flags]
    public enum GlobalScope
    {
        /// <summary>
        /// If the service implements IBackgroundService or IAsyncBackgroundService, auto start scope is set to All.<br />
        /// Otherwise auto start is None and it will be started normally when first injected.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Window global scope
        /// </summary>
        Window = 1,
        /// <summary>
        /// DedicatedWorker global scope
        /// </summary>
        DedicatedWorker = 2,
        /// <summary>
        /// SharedWorker global scope
        /// </summary>
        SharedWorker = 4,
        /// <summary>
        /// ServiceWorker global scope
        /// </summary>
        ServiceWorker = 8,
        /// <summary>
        /// Server global scope
        /// </summary>
        Server = 16,
        /// <summary>
        /// Unknown global scope
        /// </summary>
        Unknown = 32,
        /// <summary>
        /// DedicatedWorker and SharedWorker global scopes
        /// </summary>
        DedicatedAndSharedWorkers = DedicatedWorker | SharedWorker,
        /// <summary>
        /// DedicatedWorker, SharedWorker, and ServiceWorker global scopes
        /// </summary>
        AllWorkers = DedicatedWorker | SharedWorker | ServiceWorker,
        /// <summary>
        /// All browser scopes
        /// </summary>
        AllBrowser = Window | DedicatedWorker | SharedWorker | ServiceWorker,
        /// <summary>
        /// All scopes
        /// </summary>
        All = Window | DedicatedWorker | SharedWorker | ServiceWorker | Server,
        /// <summary>
        /// If service implements IBackgroundService, auto start is disabled. It will be started normally when first injected.<br />
        /// If service implements IAsyncBackgroundService, an exception is thrown because the InitAsync will not be called.
        /// </summary>
        None = 256,
    }
}
