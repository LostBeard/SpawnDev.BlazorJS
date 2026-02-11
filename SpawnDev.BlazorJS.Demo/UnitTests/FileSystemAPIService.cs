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
        public async Task FileSystemDirectoryHandleEntriesListTest()
        {
            // 1. Get OPFS root
            var storage = JS.Get<StorageManager>("navigator.storage");
            using var root = await storage.GetDirectory();
            // 2. Create a test file and a test directory
            using var testFile = await root.GetFileHandle("_test_entries_file.txt", true);
            using var testDir = await root.GetDirectoryHandle("_test_entries_dir", true);
            // 3. Use EntriesList() — this is the buggy path
            var entries = await root.EntriesList();
            Console.WriteLine($"EntriesList returned {entries.Count} entries");
            foreach (var (name, handle) in entries)
            {
                Console.WriteLine($"  Entry: '{name}'");
                Console.WriteLine($"  Kind: '{handle.Kind}'");
                // Also test type resolution
                Console.WriteLine($"    C# type: {handle.GetType().FullName}");
                Console.WriteLine($"    is FileSystemFileHandle: {handle is FileSystemFileHandle}");
                Console.WriteLine($"    is FileSystemDirectoryHandle: {handle is FileSystemDirectoryHandle}");
                handle?.Dispose();
            }
            // 4. Contrast with KeysList() — this works fine
            var keys = await root.KeysList();
            Console.WriteLine($"\nKeysList returned {keys.Count} keys");
            foreach (var key in keys)
            {
                Console.WriteLine($"  Key: '{key}'");
                // These calls work correctly:
                try
                {
                    using var fh = await root.GetFileHandle(key);
                    Console.WriteLine($"    → file handle OK, Kind={fh.Kind}");
                    continue;
                }
                catch { }
                try
                {
                    using var dh = await root.GetDirectoryHandle(key);
                    Console.WriteLine($"    → dir handle OK, Kind={dh.Kind}");
                }
                catch { }
            }
            // 5. Cleanup
            await root.RemoveEntry("_test_entries_file.txt");
            await root.RemoveEntry("_test_entries_dir");
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
