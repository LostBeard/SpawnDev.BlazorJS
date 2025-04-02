using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BackgroundFetchRegistration interface of the Background Fetch API represents an individual background fetch.<br/>
    /// A BackgroundFetchRegistration instance is returned by the BackgroundFetchManager.fetch() or BackgroundFetchManager.get() methods, and therefore there has no constructor.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchRegistration
    /// </summary>
    public class BackgroundFetchRegistration : EventTarget
    {
        ///<inheritdoc/>
        public BackgroundFetchRegistration(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string containing the background fetch's ID.
        /// </summary>
        public string Id => JSRef!.Get<string>("id");
        /// <summary>
        /// A number containing the total number of bytes to be uploaded.
        /// </summary>
        public long UploadTotal => JSRef!.Get<long>("uploadTotal");
        /// <summary>
        /// A number containing the size in bytes successfully sent, initially 0.
        /// </summary>
        public long Uploaded => JSRef!.Get<long>("uploaded");
        /// <summary>
        /// A number containing the total size in bytes of this download. This is the value set when the background fetch was registered, or 0.
        /// </summary>
        public long DownoadTotal => JSRef!.Get<long>("downoadTotal");
        /// <summary>
        /// A number containing the size in bytes that has been downloaded, initially 0.
        /// </summary>
        public long Downoaded => JSRef!.Get<long>("downoaded");
        /// <summary>
        /// Returns an empty string initially, on completion either the string "success" or "failure".
        /// </summary>
        public string Result => JSRef!.Get<string>("result");
        /// <summary>
        /// A string with a value that indicates a reason for a background fetch failure. Can be one of the following values: "", "aborted", "bad-status", "fetch-error", "quota-exceeded", "download-total-exceeded".
        /// </summary>
        public string? FailureReason => JSRef!.Get<string?>("failureReason");
        /// <summary>
        /// A boolean indicating whether the recordsAvailable flag is set.
        /// </summary>
        public bool RecordsAvailable => JSRef!.Get<bool>("recordsAvailable");
        /// <summary>
        /// Aborts the background fetch. Returns a Promise that resolves with true if the fetch was successfully aborted.
        /// </summary>
        /// <returns></returns>
        public Task<bool> Abort() => JSRef!.CallAsync<bool>("abort");
        /// <summary>
        /// Returns a single BackgroundFetchRecord object which is the first match for the arguments.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<BackgroundFetchRecord> Match(string request, BackgroundFetchMatchOptions options) => JSRef!.CallAsync<BackgroundFetchRecord>("match", request, options);
        /// <summary>
        /// Returns a single BackgroundFetchRecord object which is the first match for the arguments.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<BackgroundFetchRecord> Match(Request request) => JSRef!.CallAsync<BackgroundFetchRecord>("match", request);
        /// <summary>
        /// Returns a single BackgroundFetchRecord object which is the first match for the arguments.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<BackgroundFetchRecord> Match(Request request, BackgroundFetchMatchOptions options) => JSRef!.CallAsync<BackgroundFetchRecord>("match", request, options);
        /// <summary>
        /// Returns a single BackgroundFetchRecord object which is the first match for the arguments.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<BackgroundFetchRecord> Match(string request) => JSRef!.CallAsync<BackgroundFetchRecord>("match", request);
        /// <summary>
        /// Returns a Promise that resolves with an array of BackgroundFetchRecord objects containing requests and responses.
        /// </summary>
        /// <returns></returns>
        public Task<BackgroundFetchRecord[]> MatchAll() => JSRef!.CallAsync<BackgroundFetchRecord[]>("matchAll");
        /// <summary>
        /// Returns a Promise that resolves with an array of BackgroundFetchRecord objects containing requests and responses.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<BackgroundFetchRecord[]> MatchAll(Request request) => JSRef!.CallAsync<BackgroundFetchRecord[]>("matchAll", request);
        /// <summary>
        /// Returns a Promise that resolves with an array of BackgroundFetchRecord objects containing requests and responses.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<BackgroundFetchRecord[]> MatchAll(Request request, BackgroundFetchMatchOptions options) => JSRef!.CallAsync<BackgroundFetchRecord[]>("matchAll", request, options);
        /// <summary>
        /// Returns a Promise that resolves with an array of BackgroundFetchRecord objects containing requests and responses.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<BackgroundFetchRecord[]> MatchAll(string request) => JSRef!.CallAsync<BackgroundFetchRecord[]>("matchAll", request);
        /// <summary>
        /// Returns a Promise that resolves with an array of BackgroundFetchRecord objects containing requests and responses.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<BackgroundFetchRecord[]> MatchAll(string request, BackgroundFetchMatchOptions options) => JSRef!.CallAsync<BackgroundFetchRecord[]>("matchAll", request, options);
        /// <summary>
        /// Fired when there is a change to any of the following properties: uploaded, downloaded, result or failureReason.
        /// </summary>
        public ActionEvent<Event> OnProgress { get => new ActionEvent<Event>("progress", AddEventListener, RemoveEventListener); set { } }
    }
}
