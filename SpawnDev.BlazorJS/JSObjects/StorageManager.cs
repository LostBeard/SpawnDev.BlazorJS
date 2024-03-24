using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The StorageManager interface of the Storage API provides an interface for managing persistence permissions and estimating available storage. You can get a reference to this interface using either navigator.storage or WorkerNavigator.storage.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/StorageManager
    /// </summary>
    public class StorageManager : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public StorageManager(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a Promise that resolves to true if persistence has already been granted for your site's storage.
        /// </summary>
        /// <returns></returns>
        public Task<bool> Persisted() => JSRef.CallAsync<bool>("persisted");
        /// <summary>
        /// Returns a Promise that resolves to true if the user agent is able to persist your site's storage.
        /// </summary>
        /// <returns></returns>
        public Task<bool> Persist() => JSRef.CallAsync<bool>("persist");
        /// <summary>
        /// Returns a Promise that resolves to an object containing usage and quota numbers for your origin.
        /// </summary>
        /// <returns></returns>
        public Task<StorageManagerEstimate> Estimate() => JSRef.CallAsync<StorageManagerEstimate>("estimate");
        /// <summary>
        /// The getDirectory() method of the StorageManager interface is used to obtain a reference to a FileSystemDirectoryHandle object allowing access to a directory and its contents, stored in the origin private file system (OPFS).
        /// </summary>
        /// <returns></returns>
        public Task<FileSystemDirectoryHandle> GetDirectory() => JSRef.CallAsync<FileSystemDirectoryHandle>("getDirectory");
    }
}
