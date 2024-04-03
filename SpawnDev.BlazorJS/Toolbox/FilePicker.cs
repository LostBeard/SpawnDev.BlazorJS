using SpawnDev.BlazorJS.JSObjects;
using File = SpawnDev.BlazorJS.JSObjects.File;

namespace SpawnDev.BlazorJS.Toolbox
{
    public class FilePicker : IDisposable
    {
        public HTMLInputElement Input { get; }
        public event Action<FilePicker, File[]> OnChange;
        public string? Id { get; private set; }
        public FilePicker()
        {
            using var document = BlazorJSRuntime.JS.Get<Document>("document");
            Input = document.CreateElement<HTMLInputElement>("input");
            Input.Type = "file";
            Input.OnChange += Input_OnChange;
        }
        void Input_OnChange()
        {
            using var files = Input.Files;
            if (files != null && files.Length > 0)
            {
                OnChange?.Invoke(this, files.ToArray());
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
    }
}
