using SpawnDev.BlazorJS.JSObjects;
using File = SpawnDev.BlazorJS.JSObjects.File;

namespace SpawnDev.BlazorJS.Toolbox
{
    public class FilePicker : IDisposable
    {
        public HTMLInputElement Input { get; }
        public event Action<FilePicker, File[]> OnChange;
        public string? Id { get; private set; }
        Action<File[]>? callback = null;
        public FilePicker()
        {
            using var document = BlazorJSRuntime.JS.Get<Document>("document");
            Input = document.CreateElement<HTMLInputElement>("input");
            Input.Type = "file";
            Input.OnChange += Input_OnChange;
        }
        void Input_OnChange()
        {
            var cb = callback;
            callback = null;
            using var files = Input.Files;
            if (files != null && files.Length > 0)
            {
                if (cb != null)
                {
                    cb(files.ToArray());
                }
                else
                {
                    OnChange?.Invoke(this, files.ToArray());
                }
            }
        }
        public void Dispose()
        {
            Input.OnChange -= Input_OnChange;
            Input.Dispose();
        }
        public void ShowFilePicker(string accept = "", bool multiple = false, string? id = null)
        {
            Id = id;
            Input.Multiple = multiple;
            Input.Accept = accept;
            Input.Click();
        }
        /// <summary>
        /// callback may never be called
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="accept"></param>
        /// <param name="multiple"></param>
        public void ShowFilePicker(Action<File[]> callback, string? accept = null, bool? multiple = null)
        {
            this.callback = callback;
            if (multiple != null) Input.Multiple = multiple.Value;
            if (accept != null) Input.Accept = accept;
            Input.Click();
        }
    }
}
