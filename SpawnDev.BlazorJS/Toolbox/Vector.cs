using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics.Wasm;
#endif

namespace SpawnDev.BlazorJS.Toolbox
{
    public static class Vector
    {

        public static void Test()
        {
            var testData = Enumerable.Range(0, 20000000).Select(i => (float)i).ToArray();

            var sw = Stopwatch.StartNew();
            {
                sw.Restart();
                var avg = AvgScalar(testData);
                var elapsed = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine($"AvgScalar: {avg} {elapsed}");
            }

            {
                sw.Restart();
                var avg = AvgScalarDouble(testData);
                var elapsed = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine($"AvgScalarDouble: {avg} {elapsed}");
            }

            //sw.Restart();
            //var avg2 = AvgScalar2(testData);
            //var elapsed2 = sw.Elapsed.TotalMilliseconds;
            //Console.WriteLine($"AvgScalar2: {avg2} {elapsed2}");

            //sw.Restart();
            //var avg3 = AvgScalarLinq(testData);
            //var elapsed3 = sw.Elapsed.TotalMilliseconds;
            //Console.WriteLine($"AvgScalarLinq: {avg3} {elapsed3}");

            {
                sw.Restart();
                var avg4 = testData.AvgFastDouble();
                var elapsed4 = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine($"AvgFastDouble: {avg4} {elapsed4}");
            }

            {
                sw.Restart();
                var avg4 = testData.AvgFast();
                var elapsed4 = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine($"AvgFast: {avg4} {elapsed4}");
            }

            {
                sw.Restart();
                var avg1 = AvgSimdSingle(testData);
                var elapsed1 = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine($"AvgSIMD: {avg1} {elapsed1}");
            }
            var nmt = true;
        }

        // 2nd slowest, still much faster than Linq
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AvgScalar(float[] numbers)
        {
            var count = numbers.Length;
            if (count == 0) return 0;
            float result = 0;
            for (int i = 0; i < count; i++)
            {
                result += numbers[i];
            }
            return result / (float)count;
        }
        // 2nd slowest, still much faster than Linq
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AvgScalarDouble(float[] numbers)
        {
            var count = numbers.Length;
            if (count == 0) return 0;
            double result = 0;
            for (int i = 0; i < count; i++)
            {
                result += numbers[i];
            }
            return result / (double)count;
        }


        // 2nd fastest (casting from float[] to ReadOnlySpan<float> must be adding the extra time)
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AvgScalar2(ReadOnlySpan<float> numbers)
        {
            var count = numbers.Length;
            if (count == 0) return 0;
            float result = 0;
            int i = 0;
            int max = count - 32;
            for (; i < max; i += 32)
            {
                result += numbers[i] + numbers[i + 1] + numbers[i + 2] + numbers[i + 3];
                result += numbers[i + 4] + numbers[i + 5] + numbers[i + 6] + numbers[i + 7];
                result += numbers[i + 8] + numbers[i + 9] + numbers[i + 10] + numbers[i + 11];
                result += numbers[i + 12] + numbers[i + 13] + numbers[i + 14] + numbers[i + 15];
                result += numbers[i + 16] + numbers[i + 17] + numbers[i + 18] + numbers[i + 19];
                result += numbers[i + 20] + numbers[i + 21] + numbers[i + 22] + numbers[i + 23];
                result += numbers[i + 24] + numbers[i + 25] + numbers[i + 26] + numbers[i + 27];
                result += numbers[i + 28] + numbers[i + 29] + numbers[i + 30] + numbers[i + 31];
            }
            for (; i < numbers.Length; i++)
            {
                result += numbers[i];
            }
            return result / (float)count;
        }

        // slowest
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AvgLinq(IEnumerable<float> numbers)
        {
            return numbers.Average();
        }

        // fastest 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AvgFast(this float[] numbers)
        {
            float result = 0;
            int i = 0;
            var count = numbers.Length;
            if (count == 0) return 0;
            int max = count - 32;
            for (; i < max; i += 32)
            {
                result += numbers[i] + numbers[i + 1] + numbers[i + 2] + numbers[i + 3];
                result += numbers[i + 4] + numbers[i + 5] + numbers[i + 6] + numbers[i + 7];
                result += numbers[i + 8] + numbers[i + 9] + numbers[i + 10] + numbers[i + 11];
                result += numbers[i + 12] + numbers[i + 13] + numbers[i + 14] + numbers[i + 15];
                result += numbers[i + 16] + numbers[i + 17] + numbers[i + 18] + numbers[i + 19];
                result += numbers[i + 20] + numbers[i + 21] + numbers[i + 22] + numbers[i + 23];
                result += numbers[i + 24] + numbers[i + 25] + numbers[i + 26] + numbers[i + 27];
                result += numbers[i + 28] + numbers[i + 29] + numbers[i + 30] + numbers[i + 31];
            }
            for (; i < count; i++)
            {
                result += numbers[i];
            }
            return result / (float)count;
        }

        // fastest double return
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AvgFastDouble(this float[] numbers)
        {
            double result = 0;
            int i = 0;
            var count = numbers.Length;
            if (count == 0) return 0;
            int max = count - 32;
            for (; i < max; i += 32)
            {
                result += numbers[i] + numbers[i + 1] + numbers[i + 2] + numbers[i + 3];
                result += numbers[i + 4] + numbers[i + 5] + numbers[i + 6] + numbers[i + 7];
                result += numbers[i + 8] + numbers[i + 9] + numbers[i + 10] + numbers[i + 11];
                result += numbers[i + 12] + numbers[i + 13] + numbers[i + 14] + numbers[i + 15];
                result += numbers[i + 16] + numbers[i + 17] + numbers[i + 18] + numbers[i + 19];
                result += numbers[i + 20] + numbers[i + 21] + numbers[i + 22] + numbers[i + 23];
                result += numbers[i + 24] + numbers[i + 25] + numbers[i + 26] + numbers[i + 27];
                result += numbers[i + 28] + numbers[i + 29] + numbers[i + 30] + numbers[i + 31];
            }
            for (; i < count; i++)
            {
                result += numbers[i];
            }
            return result / (double)count;
        }



        // fastest double return
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PowFastFloat(this float[] numbers, float power)
        {
            int i = 0;
            var count = numbers.Length;
            int max = count - 16;
            for (; i < max; i += 16)
            {
                numbers[i] = (float)Math.Pow(numbers[i], power);
                numbers[i + 1] = (float)Math.Pow(numbers[i + 1], power);
                numbers[i + 2] = (float)Math.Pow(numbers[i + 2], power);
                numbers[i + 3] = (float)Math.Pow(numbers[i + 3], power);
                numbers[i + 4] = (float)Math.Pow(numbers[i + 4], power);
                numbers[i + 5] = (float)Math.Pow(numbers[i + 5], power);
                numbers[i + 6] = (float)Math.Pow(numbers[i + 6], power);
                numbers[i + 7] = (float)Math.Pow(numbers[i + 7], power);
                numbers[i + 8] = (float)Math.Pow(numbers[i + 8], power);
                numbers[i + 9] = (float)Math.Pow(numbers[i + 9], power);
                numbers[i + 10] = (float)Math.Pow(numbers[i + 10], power);
                numbers[i + 11] = (float)Math.Pow(numbers[i + 11], power);
                numbers[i + 12] = (float)Math.Pow(numbers[i + 12], power);
                numbers[i + 13] = (float)Math.Pow(numbers[i + 13], power);
                numbers[i + 14] = (float)Math.Pow(numbers[i + 14], power);
                numbers[i + 15] = (float)Math.Pow(numbers[i + 15], power);
            }
            for (; i < count; i++)
            {
                numbers[i] = (float)Math.Pow(numbers[i], power);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SquareFastFloat(this float[] numbers)
        {
            int i = 0;
            var count = numbers.Length;
            int max = count - 16;
            for (; i < max; i += 16)
            {
                numbers[i] = numbers[i] * numbers[i];
                numbers[i + 1] = numbers[i + 1] * numbers[i + 1];
                numbers[i + 2] = numbers[i + 2] * numbers[i + 2];
                numbers[i + 3] = numbers[i + 3] * numbers[i + 3];
                numbers[i + 4] = numbers[i + 4] * numbers[i + 4];
                numbers[i + 5] = numbers[i + 5] * numbers[i + 5];
                numbers[i + 6] = numbers[i + 6] * numbers[i + 6];
                numbers[i + 7] = numbers[i + 7] * numbers[i + 7];
                numbers[i + 8] = numbers[i + 8] * numbers[i + 8];
                numbers[i + 9] = numbers[i + 9] * numbers[i + 9];
                numbers[i + 10] = numbers[i + 10] * numbers[i + 10];
                numbers[i + 11] = numbers[i + 11] * numbers[i + 11];
                numbers[i + 12] = numbers[i + 12] * numbers[i + 12];
                numbers[i + 13] = numbers[i + 13] * numbers[i + 13];
                numbers[i + 14] = numbers[i + 14] * numbers[i + 14];
                numbers[i + 15] = numbers[i + 15] * numbers[i + 15];
            }
            for (; i < count; i++)
            {
                numbers[i] = numbers[i] * numbers[i];
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SquareAvgFastDouble(this float[] numbers)
        {
            int i = 0;
            var count = numbers.Length;
            if (count == 0) return 0;
            int max = count - 32;
            double result = 0;
            for (; i < max; i += 32)
            {
                result += numbers[i] * numbers[i] + numbers[i + 1] * numbers[i + 1] + numbers[i + 2] * numbers[i + 2] + numbers[i + 3] * numbers[i + 3];
                result += numbers[i + 4] * numbers[i + 4] + numbers[i + 5] * numbers[i + 5] + numbers[i + 6] * numbers[i + 6] + numbers[i + 7] * numbers[i + 7];
                result += numbers[i + 8] * numbers[i + 8] + numbers[i + 9] * numbers[i + 9] + numbers[i + 10] * numbers[i + 10] + numbers[i + 11] * numbers[i + 11];
                result += numbers[i + 12] * numbers[i + 12] + numbers[i + 13] * numbers[i + 13] + numbers[i + 14] * numbers[i + 14] + numbers[i + 15] * numbers[i + 15];
                result += numbers[i + 16] * numbers[i + 16] + numbers[i + 17] * numbers[i + 17] + numbers[i + 18] * numbers[i + 18] + numbers[i + 19] * numbers[i + 19];
                result += numbers[i + 20] * numbers[i + 20] + numbers[i + 21] * numbers[i + 21] + numbers[i + 22] * numbers[i + 22] + numbers[i + 23] * numbers[i + 23];
                result += numbers[i + 24] * numbers[i + 24] + numbers[i + 25] * numbers[i + 25] + numbers[i + 26] * numbers[i + 26] + numbers[i + 27] * numbers[i + 27];
                result += numbers[i + 28] * numbers[i + 28] + numbers[i + 29] * numbers[i + 29] + numbers[i + 30] * numbers[i + 30] + numbers[i + 31] * numbers[i + 31];
            }
            for (; i < count; i++)
            {
                result += numbers[i] * numbers[i];
            }
            return result / (double)count;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AvgSimdSingle(float[] numbers)
        {
            var count = numbers.Length;
            if (count == 0) return 0;
            var vectors = MemoryMarshal.Cast<float, Vector128<float>>(numbers);
            var acc = Vector128<float>.Zero;
            for (int i = 0; i < vectors.Length; i++)
            {
#if NET7_0_OR_GREATER
                acc = Vector128_Add(acc, vectors[i]);
#endif
            }
            var result = Vector128_Sum(acc);
            for (int i = vectors.Length * Vector128<float>.Count; i < numbers.Length; i++)
                result += numbers[i];
            return result / count;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AvgSimdDouble(float[] numbers)
        {
            var count = numbers.Length;
            if (count == 0) return 0;
            var vectors = MemoryMarshal.Cast<float, Vector128<float>>(numbers);
            var acc = Vector128<float>.Zero;
            for (int i = 0; i < vectors.Length; i++)
            {
#if NET7_0_OR_GREATER
                acc = Vector128_Add(acc, vectors[i]);
#endif
            }
            var result = Vector128_Sum(acc);
            for (int i = vectors.Length * Vector128<float>.Count; i < numbers.Length; i++)
                result += numbers[i];
            return result / numbers.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(ReadOnlySpan<float> numbers)
        {
            var count = numbers.Length;
            if (count == 0) return 0;
            var vectors = MemoryMarshal.Cast<float, Vector128<float>>(numbers);
            var acc = Vector128<float>.Zero;
            for (int i = 0; i < vectors.Length; i++)
            {
                acc = Vector128_Add(acc, vectors[i]);
            }
            var result = Vector128_Sum(acc);
            for (int i = vectors.Length * Vector128<float>.Count; i < numbers.Length; i++)
                result += numbers[i];
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Vector128_Sum(Vector128<float> vector)
        {
#if NET7_0_OR_GREATER && true
            return Vector128.Sum(vector);
#else
            return vector.GetElement(0) + vector.GetElement(1) + vector.GetElement(2) + vector.GetElement(3);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector128<float> Vector128_Add(Vector128<float> left, Vector128<float> right)
        {
#if NET8_0_OR_GREATER && true
            //return left + right;
            return PackedSimd.Add(left, right);
            //return Vector128.Add(left, right);
#else
            return Vector128.Create(
                left.GetElement(0) + right.GetElement(0),
                left.GetElement(1) + right.GetElement(1),
                left.GetElement(2) + right.GetElement(2),
                left.GetElement(3) + right.GetElement(3)
            );
#endif
        }
    }
}
