using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.Toolbox;
using System.Text;

namespace SpawnDev.BlazorJS.Demo.UnitTests
{
    public class HeapViewTests(BlazorJSRuntime JS)
    {
        /// <summary>
        /// Tests Heapview to JS serialization
        /// </summary>
        [TestMethod]
        public async Task HeapViewSerializationTest()
        {
            var textData = "Hello, this is my text content!";
            var textDataBytes = Encoding.UTF8.GetBytes(textData);

            using var heapView = (HeapView)textDataBytes;
            var heapViewList = Enumerable.Range(0, 1000).Select(o => heapView).ToList();


            // the HeapView JsonConverter should write a Uint8Array to JS so it ends being an Array of Uint8Array
            JS.Set("_heaps", heapViewList);

            // readback
            var heapsRB = JS.Get<List<JSObject>>("_heaps");

            var anyNull = heapsRB.Any(o => o is null);
            var length = heapsRB.Count;

            if (length != heapViewList.Count) throw new Exception("Invalid readback length");
            if (anyNull) throw new Exception("NULL values found");
        }
    }
}
