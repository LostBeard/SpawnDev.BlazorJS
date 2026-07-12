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
        /// <summary>
        /// Regression guard: HeapView.As&lt;TView&gt;() must size the JS view by the TARGET view element size,
        /// not the source HeapView element size. A cross-type view (source elem size != target elem size) must
        /// still yield exactly the source bytes - not an over-sized view that reads past the pinned data / throws
        /// "offset is out of bounds". This is the path TypedArray.Write&lt;T&gt; uses (HeapView&lt;T&gt; -&gt; As&lt;Uint8Array&gt;),
        /// which byte-&gt;byte tests can't exercise.
        /// </summary>
        [TestMethod]
        public void HeapViewCrossTypeAsTest()
        {
            var doubles = new double[] { double.NegativeZero, double.PositiveInfinity, double.NegativeInfinity, 3.14159265358979, -2.5e300, 0.0 };
            var expected = new byte[doubles.Length * sizeof(double)];
            for (var i = 0; i < doubles.Length; i++)
            {
                BitConverter.GetBytes(doubles[i]).CopyTo(expected, i * sizeof(double));
            }
            // HeapView<double> (source elem size 8) viewed As<Uint8Array> (target elem size 1)
            using var heapView = HeapView.Create(doubles);
            using var u8 = heapView.As<Uint8Array>();
            if (u8.Length != expected.Length) throw new Exception($"As<Uint8Array> length {u8.Length} != expected {expected.Length}");
            var actual = u8.ToArray();
            if (!actual.SequenceEqual(expected)) throw new Exception("Cross-type As<Uint8Array> byte content mismatch");
            // The exact failing round-trip: (Number)double boxing -> Float64Array.Write([value]) -> As<Uint8Array>
            foreach (var d in doubles)
            {
                JS.Set("_crossTypeNumber", (Number)d);
                double rb = JS.Get<Number>("_crossTypeNumber");
                if (!BitConverter.GetBytes(d).SequenceEqual(BitConverter.GetBytes(rb))) throw new Exception($"(Number) round-trip failed for {d}");
            }
        }
    }
}
