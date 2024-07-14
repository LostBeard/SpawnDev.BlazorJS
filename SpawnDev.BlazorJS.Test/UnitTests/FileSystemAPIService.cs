using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Toolbox;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpawnDev.BlazorJS.Test.UnitTests
{
    public class FileSystemAPIService
    {
        BlazorJSRuntime JS;
        public FileSystemAPIService(BlazorJSRuntime js)
        {
            JS = js;
        }
        [TestMethod]
        public async Task StorageManagerExample()
        {
            // storage
            using var storage = JS.Get<StorageManager>("navigator.storage");
            using var storageDir = await storage.GetDirectory();
            // fruitFile
            using var fruitFile = await storageDir.GetFileHandle("fruit.txt", true);
            using var fruitFileStream = await fruitFile.CreateWritable();
            await fruitFileStream.Truncate(0);
            await fruitFileStream.Write("Hello apples!");
            fruitFileStream.Close();
            // vegFile
            using var vegFile = await storageDir.GetFileHandle("vegetable.txt", true);
            using var vegFileStream = await vegFile.CreateWritable();
            await vegFileStream.Truncate(0);
            await vegFileStream.Write("Hello carrots!");
            vegFileStream.Close();
            // list dir contents
            JS.Set("_storageDir", storageDir);
            var entries = await storageDir.Entries();
            var f = entries.Values.FirstOrDefault();
            var b = f.GetType().Name;

            JS.Set("_tmp", entries);
            JS.Log("_tmp", entries);
            var nmt = true;
        }
    }
}
