using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Demo.UnitTests
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
            if (!StorageManager.Supported)
            {
                throw new Exception("StorageManager not supported by browser. Expected failure.");
            }
            // storage
            using var storage = JS.Get<StorageManager>("navigator.storage");
            using var storageDir = await storage.GetDirectory();
            // fruitFile
            using var fruitFile = await storageDir.GetFileHandle("fruit.txt", true);
            // some browsers (like Safari 18) support StorageManager and FileSystemFileHandle but only partially
            if (fruitFile.JSRef!.IsUndefined("createWritable"))
            {
                throw new Exception("FileSystemFileHandle.createWritable not supported by browser. Expected failure.");
            }
            //if (!fruitFile.JSRef!.In("createWritable"))
            //{
            //    throw new Exception("FileSystemFileHandle.createWritable not supported by browser. Expected failure.");
            //}
            using var fruitFileStream = await fruitFile.CreateWritable();
            await fruitFileStream.Truncate(0);
            await fruitFileStream.Write("Hello apples!");
            await fruitFileStream.Close();
            // vegFile
            using var vegFile = await storageDir.GetFileHandle("vegetable.txt", true);
            using var vegFileStream = await vegFile.CreateWritable();
            await vegFileStream.Truncate(0);
            await vegFileStream.Write("Hello carrots!");
            await vegFileStream.Close();
            // list dir contents
            JS.Set("_storageDir", storageDir);
            var entries = await storageDir.ValuesList();

        }
    }
}
