using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The audio HTML element is used to embed sound content in documents. It may contain one or more audio sources, represented using the src attribute or the source element: the browser will choose the most suitable one. It can also be the destination for streamed media, using a MediaStream.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/HTML/Element/audio<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLAudioElement/Audio
    /// </summary>
    public class HTMLAudioElement : HTMLMediaElement
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLAudioElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The Audio() constructor creates and returns a new HTMLAudioElement which can be either attached to a document for the user to interact with and/or listen to, or can be used offscreen to manage and play audio.
        /// </summary>
        /// <param name="url"></param>
        public HTMLAudioElement(string url) : base(JS.New(nameof(Audio), url)) { }
    }
}
