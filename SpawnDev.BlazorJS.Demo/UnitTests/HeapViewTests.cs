using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;
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
        [TestMethod]
        public async Task HeapViewTest1()
        {
            var textDataBytes = new byte[16 * 1024 * 1024];
            for(var i = 0; i < 20; i++)
            {
                using var heapView = (HeapView)textDataBytes;
                using var heapu8 = heapView.As<Uint8ClampedArray>();
                JS.Set("_heapView1", heapu8);
                JS.Set("_heap1", heapu8.Buffer);
                textDataBytes[0] = 42;
                // force a heap growth to verify the heapu8 will recreate using the new heap when it is revived
                HeapView.ForceHeapGrowth();
                JS.Set("_heapView2", heapu8);
                // at this point _heapView2 is valid until the next heap growth and _heapView1 is now ivalid due to the heap resize we forced
                if (heapu8.ByteLength != textDataBytes.Length) throw new Exception("Uint8ClampedArray view of the heap not valid.");
                // _heapView1 and _heapView2 can be viewed in devtools console to verify
            }
        }
    }
}
