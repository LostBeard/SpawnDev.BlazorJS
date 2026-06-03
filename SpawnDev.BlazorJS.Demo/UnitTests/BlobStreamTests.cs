using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Toolbox;
using System.Text;

namespace SpawnDev.BlazorJS.Demo.UnitTests
{
    public class BlobStreamTests(BlazorJSRuntime JS)
    {

        /// <summary>
        /// Tests BlobStream: Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        /// </summary>
        [TestMethod]
        public async Task BlobStreamTest1()
        {
            var textData = " Hello, this is my text content!";
            using var textBlob = new Blob([textData], new BlobOptions { Type = "text/plain" });
            using var blobStream = new BlobStream(textBlob);

            // move to the "H" in the text at position 1 (skip the space)
            blobStream.Position = 1;

            // our buffer
            var buffer = new byte[256];
            // use the Memory<byte> overload to read into a section of our buffer startiing at offest == 5
            var bytesRead = await blobStream.ReadAsync(buffer, 5, buffer.Length - 5);

            // convert back to text and make sure it matches textData.Substring(1)
            var readBackString = Encoding.UTF8.GetString(buffer, 5, bytesRead);
            if (textData.Substring(1) != readBackString) throw new Exception("Readback failed");
        }

        /// <summary>
        /// Tests BlobStream: Task<int> ReadAsync(Memory&lt;byte> buffer, CancellationToken? cancellationToken = null)
        /// </summary>
        [TestMethod]
        public async Task BlobStreamTestMemoryByteArray()
        {
            var textData = " Hello, this is my text content!";
            using var textBlob = new Blob([textData], new BlobOptions { Type = "text/plain" });
            using var blobStream = new BlobStream(textBlob);

            // move to the "H" in the text at position 1 (skip the space)
            blobStream.Position = 1;

            // our buffer
            var buffer = new byte[256];
            // use the Memory<byte> overload to read into a section of our buffer startiing at offest == 5
            var bytesRead = await blobStream.ReadAsync(new Memory<byte>(buffer, 5, buffer.Length - 5));

            // convert back to text and make sure it matches textData.Substring(1)
            var readBackString = Encoding.UTF8.GetString(buffer, 5, bytesRead);
            if (textData.Substring(1) != readBackString) throw new Exception("Readback failed");
        }
    }
}
