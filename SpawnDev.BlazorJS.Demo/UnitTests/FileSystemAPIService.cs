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
        public async Task FileReadWriteTest()
        {
            if (!StorageManager.Supported) return;
            using var storage = JS.Get<StorageManager>("navigator.storage");
            using var root = await storage.GetDirectory();

            var fileName = "test_" + Guid.NewGuid().ToString() + ".txt";
            var content = "Hello File System API! " + Guid.NewGuid().ToString();

            // Write
            using var fileHandle = await root.GetFileHandle(fileName, true);
            if (fileHandle.JSRef!.IsUndefined("createWritable")) return; // Browser limitation check

            using var writable = await fileHandle.CreateWritable();
            await writable.Write(content);
            await writable.Close();

            // Read back
            using var file = await fileHandle.GetFile();
            var readContent = await file.Text();

            if (readContent != content) throw new Exception("Read content does not match written content");

            // Cleanup
            await root.RemoveEntry(fileName);
        }

        [TestMethod]
        public async Task DirectoryManipulationTest()
        {
            if (!StorageManager.Supported) return;
            using var storage = JS.Get<StorageManager>("navigator.storage");
            using var root = await storage.GetDirectory();

            var dirName = "dir_" + Guid.NewGuid().ToString().Substring(0, 8);
            var fileName = "file_in_dir.txt";

            // Create dir
            using var dirHandle = await root.GetDirectoryHandle(dirName, true);

            // Create file in dir
            using var fileHandle = await dirHandle.GetFileHandle(fileName, true);

            // Verify file exists in dir listing
            var keys = await dirHandle.KeysList();
            if (!keys.Contains(fileName)) throw new Exception("File not found in directory listing");

            // Cleanup dir recursively
            await root.RemoveEntry(dirName, true);

            // Verify dir is gone
            keys = await root.KeysList();
            if (keys.Contains(dirName)) throw new Exception("Directory was not removed");
        }

        [TestMethod]
        public async Task ResolvePathTest()
        {
            if (!StorageManager.Supported) return;
            using var storage = JS.Get<StorageManager>("navigator.storage");
            using var root = await storage.GetDirectory();

            var dirName = "parent_" + Guid.NewGuid().ToString().Substring(0, 8);
            var subDirName = "child";
            var fileName = "target.txt";

            using var parent = await root.GetDirectoryHandle(dirName, true);
            using var child = await parent.GetDirectoryHandle(subDirName, true);
            using var file = await child.GetFileHandle(fileName, true);

            var path = await root.Resolve(file);
            if (path == null) throw new Exception("Resolve returned null");

            List<string> expectedPath = [dirName, subDirName, fileName];
            if (!path.SequenceEqual(expectedPath)) throw new Exception($"Path mismatch. Expected: {string.Join("/", expectedPath)}, Got: {string.Join("/", path)}");

            // Cleanup
            await root.RemoveEntry(dirName, true);
        }
    }
}
