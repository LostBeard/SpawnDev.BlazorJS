using Microsoft.JSInterop;
using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Demo.UnitTests
{
    [TestClass]
    public class TypedArrayTests
    {
        BlazorJSRuntime JS;
        public TypedArrayTests(BlazorJSRuntime js)
        {
            JS = js;
        }

        [TestMethod]
        public void Int8ArrayTest()
        {
            sbyte[] testData = [1, -2, 3, -4, 5];
            using var typedArray = new Int8Array(testData);
            if (typedArray.Length != testData.Length) throw new Exception("Length mismatch");
            var readBack = typedArray.ToArray();
            if (!readBack.SequenceEqual(testData)) throw new Exception("Data mismatch");
            
            typedArray[0] = 10;
            if (typedArray[0] != 10) throw new Exception("Indexer set/get failed");
        }

        [TestMethod]
        public void Uint8ArrayTest()
        {
            byte[] testData = [1, 2, 3, 4, 5];
            using var typedArray = new Uint8Array(testData);
            if (typedArray.Length != testData.Length) throw new Exception("Length mismatch");
            var readBack = typedArray.ToArray();
            if (!readBack.SequenceEqual(testData)) throw new Exception("Data mismatch");

            typedArray[0] = 10;
            if (typedArray[0] != 10) throw new Exception("Indexer set/get failed");
        }

        [TestMethod]
        public void Uint8ClampedArrayTest()
        {
            byte[] testData = [1, 2, 3, 4, 255];
            using var typedArray = new Uint8ClampedArray(testData);
            if (typedArray.Length != testData.Length) throw new Exception("Length mismatch");
            var readBack = typedArray.ToArray();
            if (!readBack.SequenceEqual(testData)) throw new Exception("Data mismatch");

            typedArray[0] = 10;
            if (typedArray[0] != 10) throw new Exception("Indexer set/get failed");
            
            // Test clamping
            JS.Set("_clamped", typedArray);
            JS.CallVoid("eval", "_clamped[1] = 300"); // Should clamp to 255
            if (typedArray[1] != 255) throw new Exception("Clamping failed");
        }

        [TestMethod]
        public void Int16ArrayTest()
        {
            short[] testData = [1, -2, 3, -4, 32767];
            using var typedArray = new Int16Array(testData);
            if (typedArray.Length != testData.Length) throw new Exception("Length mismatch");
            var readBack = typedArray.ToArray();
            if (!readBack.SequenceEqual(testData)) throw new Exception("Data mismatch");
        }

        [TestMethod]
        public void Uint16ArrayTest()
        {
            ushort[] testData = [1, 2, 3, 4, 65535];
            using var typedArray = new Uint16Array(testData);
            if (typedArray.Length != testData.Length) throw new Exception("Length mismatch");
            var readBack = typedArray.ToArray();
            if (!readBack.SequenceEqual(testData)) throw new Exception("Data mismatch");
        }

        [TestMethod]
        public void Int32ArrayTest()
        {
            int[] testData = [1, -2, 3, -4, 2147483647];
            using var typedArray = new Int32Array(testData);
            if (typedArray.Length != testData.Length) throw new Exception("Length mismatch");
            var readBack = typedArray.ToArray();
            if (!readBack.SequenceEqual(testData)) throw new Exception("Data mismatch");
        }

        [TestMethod]
        public void Uint32ArrayTest()
        {
            uint[] testData = [1, 2, 3, 4, 4294967295];
            using var typedArray = new Uint32Array(testData);
            if (typedArray.Length != testData.Length) throw new Exception("Length mismatch");
            var readBack = typedArray.ToArray();
            if (!readBack.SequenceEqual(testData)) throw new Exception("Data mismatch");
        }

        [TestMethod]
        public void Float16ArrayTest()
        {
            // Float16Array might not be supported in all browsers yet
            if (JS.Get<int>("typeof Float16Array") == 0) return;

            Half[] testData = [(Half)1.1, (Half)(-2.2), (Half)3.3];
            using var typedArray = new Float16Array(testData);
            if (typedArray.Length != testData.Length) throw new Exception("Length mismatch");
            var readBack = typedArray.ToArray();
            // SequenceEqual for floats can be tricky, but Half should be exact enough for small values
            if (!readBack.SequenceEqual(testData)) throw new Exception("Data mismatch");
        }

        [TestMethod]
        public void Float32ArrayTest()
        {
            float[] testData = [1.1f, -2.2f, 3.3f];
            using var typedArray = new Float32Array(testData);
            if (typedArray.Length != testData.Length) throw new Exception("Length mismatch");
            var readBack = typedArray.ToArray();
            if (!readBack.SequenceEqual(testData)) throw new Exception("Data mismatch");
        }

        [TestMethod]
        public void Float64ArrayTest()
        {
            double[] testData = [1.1, -2.2, 3.3];
            using var typedArray = new Float64Array(testData);
            if (typedArray.Length != testData.Length) throw new Exception("Length mismatch");
            var readBack = typedArray.ToArray();
            if (!readBack.SequenceEqual(testData)) throw new Exception("Data mismatch");
        }

        [TestMethod]
        public void BigInt64ArrayTest()
        {
            if (!BigInt64Array.Supported) return;

            long[] testData = [1, -2, 3, -4, 9223372036854775807];
            using var typedArray = new BigInt64Array(testData);
            if (typedArray.Length != testData.Length) throw new Exception("Length mismatch");
            var readBack = typedArray.ToArray();
            if (!readBack.SequenceEqual(testData)) throw new Exception("Data mismatch");
            
            typedArray[0] = 10;
            if (typedArray[0] != 10) throw new Exception("Indexer set/get failed");
        }

        [TestMethod]
        public void BigUint64ArrayTest()
        {
            if (!BigUint64Array.Supported) return;

            ulong[] testData = [1, 2, 3, 4, 18446744073709551615];
            using var typedArray = new BigUint64Array(testData);
            if (typedArray.Length != testData.Length) throw new Exception("Length mismatch");
            var readBack = (ulong[])typedArray; // Test explicit operator
            if (!readBack.SequenceEqual(testData)) throw new Exception("Data mismatch");

            typedArray[0] = 10;
            if (typedArray[0] != 10) throw new Exception("Indexer set/get failed");
        }
    }
}
