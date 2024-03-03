using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// HTML script elements expose the HTMLScriptElement interface, which provides special properties and methods for manipulating the behavior and execution of script elements (beyond the inherited HTMLElement interface).<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLScriptElement
    /// </summary>
    public class HTMLScriptElement : HTMLElement
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLScriptElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Shortcut method for document.createElement('script')<br />
        /// Non-standard implementation
        /// </summary>
        public HTMLScriptElement() : base(JS.DocumentCreateElement("script")) { }
        #endregion

        #region Properties
        /// <summary>
        /// If the async attribute is present, then the script will be executed asynchronously as soon as it downloads.<br />
        /// If the async attribute is absent but the defer attribute is present, then the script is executed when the page has finished parsing.<br />
        /// If neither attribute is present, then the script is fetched and executed immediately, blocking further parsing of the page.<br />
        /// The defer attribute may be specified with the async attribute, so legacy browsers that only support defer (and not async) fall back to the defer behavior instead of the default blocking behavior.
        /// </summary>
        public bool Defer { get => JSRef.Get<bool>("defer"); set => JSRef.Set("defer", value); }
        /// <summary>
        /// If the async attribute is present, then the script will be executed asynchronously as soon as it downloads.<br />
        /// If the async attribute is absent but the defer attribute is present, then the script is executed when the page has finished parsing.<br />
        /// If neither attribute is present, then the script is fetched and executed immediately, blocking further parsing of the page.<br />
        /// The defer attribute may be specified with the async attribute, so legacy browsers that only support defer (and not async) fall back to the defer behavior instead of the default blocking behavior.
        /// </summary>
        public bool Async { get => JSRef.Get<bool>("async"); set => JSRef.Set("async", value); }
        /// <summary>
        /// A string reflecting the CORS setting for the script element. For classic scripts from other origins, this controls if error information will be exposed.
        /// </summary>
        public string CrossOrigin { get => JSRef.Get<string>("crossOrigin"); set => JSRef.Set("crossOrigin", value); }
        /// <summary>
        /// A string that joins and returns the contents of all Text nodes inside the script element (ignoring other nodes like comments) in tree order. On setting, it acts the same way as the textContent IDL attribute.
        /// </summary>
        public string Text { get => JSRef.Get<string>("text"); set => JSRef.Set("text", value); }
        /// <summary>
        /// A string representing the MIME type of the script. It reflects the type attribute.
        /// </summary>
        public string Type { get => JSRef.Get<string>("type"); set => JSRef.Set("type", value); }
        /// <summary>
        /// A string representing the URL of an external script. It reflects the src attribute.
        /// </summary>
        public string Src { get => JSRef.Get<string>("src"); set => JSRef.Set("src", value); }
        /// <summary>
        /// A boolean value that if true, stops the script's execution in browsers that support ES modules — used to run fallback scripts in older browsers that do not support JavaScript modules.
        /// </summary>
        public bool NoModule { get => JSRef.Get<bool>("noModule"); set => JSRef.Set("noModule", value); }
        /// <summary>
        /// A string that reflects the referrerPolicy HTML attribute indicating which referrer to use when fetching the script, and fetches done by that script.
        /// </summary>
        public string ReferrerPolicy { get => JSRef.Get<string>("referrerPolicy"); set => JSRef.Set("referrerPolicy", value); }
        /// <summary>
        /// An optional string representing a hint given to the browser on how it should prioritize fetching of an external script relative to other external scripts. If this value is provided, it must be one of the possible permitted values: high to fetch at a high priority, low to fetch at a low priority, or auto to indicate no preference (which is the default).
        /// </summary>
        public string FetchPriority { get => JSRef.Get<string>("fetchPriority"); set => JSRef.Set("fetchPriority", value); }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a task that will fulfill when the script load, or error event ar called<br />
        /// Non-standard implementation
        /// </summary>
        /// <returns></returns>
        public async Task OnLoadAsync()
        {
            var taskCompletionSource = new TaskCompletionSource();
            Action<Event>? onLoad = null;
            Action<Event>? onError = null;
            onLoad = new Action<Event>((e) =>
            {
                taskCompletionSource.TrySetResult();
            });
            onError = new Action<Event>((e) =>
            {
                taskCompletionSource.TrySetException(new Exception("Script load failed"));
            });
            OnLoad += onLoad;
            OnError += onError;
            try
            {
                await taskCompletionSource.Task;
            }
            finally
            {
                OnLoad -= onLoad;
                OnError -= onError;
            }
        }
        #endregion
    }
}
