using SpawnDev.BlazorJS.JSObjects;
using File = SpawnDev.BlazorJS.JSObjects.File;

namespace SpawnDev.BlazorJS.Toolbox
{
    public class FilePicker
    {
        static BlazorJSRuntime JS => BlazorJSRuntime.JS;
        /// <summary>
        /// Show an open file(s) dialog<br />
        /// Similar to Window.ShowOpenFilePicker but, as of 2024-04-03, Window.ShowOpenFilePicker is not working in Firefox and some others
        /// </summary>
        /// <param name="accept"></param>
        /// <param name="multiple"></param>
        /// <returns></returns>
        public async Task<File[]?> ShowOpenFilePicker(string? accept = null, bool? multiple = null)
        {
            File[]? ret = null;
            using var document = JS.Get<Document>("document");
            using var input = document.CreateElement<HTMLInputElement>("input");
            var tcs = new TaskCompletionSource();
            Action<Event>? onEvent = null; 
            onEvent = new Action<Event>((e) =>
            {
                if (e.Type == "change")
                {
                    ret = input.Files?.ToArray();
                }
                input.OnChange -= onEvent!;
                input.OnCancel -= onEvent!;
                tcs.SetResult();
            });
            input.Type = "file";
            input.OnChange += onEvent;
            input.OnCancel += onEvent;
            if (multiple != null) input.Multiple = multiple.Value;
            if (accept != null) input.Accept = accept;
            input.Click();
            await tcs.Task;
            return ret;
        }
        /// <summary>
        /// Show an open file(s) dialog<br />
        /// Similar to Window.ShowOpenFilePicker but, as of 2024-04-03, Window.ShowOpenFilePicker is not working in Firefox and some others
        /// </summary>
        /// <param name="inputConfig"></param>
        /// <returns></returns>
        public async Task<File[]?> ShowOpenFilePicker(Action<HTMLInputElement> inputConfig)
        {
            File[]? ret = null;
            using var document = JS.Get<Document>("document");
            using var input = document.CreateElement<HTMLInputElement>("input");
            var tcs = new TaskCompletionSource();
            Action<Event>? onEvent = null;
            onEvent = new Action<Event>((e) =>
            {
                if (e.Type == "change")
                {
                    ret = input.Files?.ToArray();
                }
                input.OnChange -= onEvent!;
                input.OnCancel -= onEvent!;
                tcs.SetResult();
            });
            input.Type = "file";
            input.OnChange += onEvent;
            input.OnCancel += onEvent;
            inputConfig?.Invoke(input);
            input.Click();
            await tcs.Task;
            return ret;
        }
    }
}
