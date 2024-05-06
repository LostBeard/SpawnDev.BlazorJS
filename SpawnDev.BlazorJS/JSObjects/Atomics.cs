using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Atomics namespace object contains static methods for carrying out atomic operations. They are used with SharedArrayBuffer and ArrayBuffer objects.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Atomics
    /// </summary>
    public static class Atomics 
    {
        private static BlazorJSRuntime JS => BlazorJSRuntime.JS;
        /// <summary>
        /// The Atomics.add() static method adds a given value at a given position in the array and returns the old value at that position. This atomic operation guarantees that no other write happens until the modified value is written back.
        /// </summary>
        /// <typeparam name="T">TypedArray element .Net type</typeparam>
        /// <param name="typedArray">An integer typed array. One of Int8Array, Uint8Array, Int16Array, Uint16Array, Int32Array, Uint32Array, BigInt64Array, or BigUint64Array.</param>
        /// <param name="index">The position in the typedArray to add a value to.</param>
        /// <param name="value">The number to add.</param>
        /// <returns>The old value at the given position (typedArray[index]).</returns>
        public static T Add<T>(TypedArray<T> typedArray, long index, T value) where T : struct => JS.Call<T>("Atomics.add", typedArray, index, value);
        /// <summary>
        /// The Atomics.and() static method computes a bitwise AND with a given value at a given position in the array, and returns the old value at that position. This atomic operation guarantees that no other write happens until the modified value is written back.
        /// </summary>
        /// <typeparam name="T">TypedArray element .Net type</typeparam>
        /// <param name="typedArray">An integer typed array. One of Int8Array, Uint8Array, Int16Array, Uint16Array, Int32Array, Uint32Array, BigInt64Array, or BigUint64Array.</param>
        /// <param name="index">The position in the typedArray to compute the bitwise AND.</param>
        /// <param name="value">The number to compute the bitwise AND with.</param>
        /// <returns>The old value at the given position (typedArray[index]).</returns>
        public static T And<T>(TypedArray<T> typedArray, long index, T value) where T : struct => JS.Call<T>("Atomics.and", typedArray, index, value);
        /// <summary>
        /// The Atomics.compareExchange() static method exchanges a given replacement value at a given position in the array, if a given expected value equals the old value. It returns the old value at that position whether it was equal to the expected value or not. This atomic operation guarantees that no other write happens until the modified value is written back.
        /// </summary>
        /// <typeparam name="T">TypedArray element .Net type</typeparam>
        /// <param name="typedArray">An integer typed array. One of Int8Array, Uint8Array, Int16Array, Uint16Array, Int32Array, Uint32Array, BigInt64Array, or BigUint64Array.</param>
        /// <param name="index">The position in the typedArray to exchange a replacementValue.</param>
        /// <param name="expectedValue">The value to check for equality.</param>
        /// <param name="replacementValue">The number to exchange.</param>
        /// <returns>The old value at the given position (typedArray[index]).</returns>
        public static T CompareExchange<T>(TypedArray<T> typedArray, long index, T expectedValue, T replacementValue) where T : struct => JS.Call<T>("Atomics.compareExchange", typedArray, index, expectedValue, replacementValue);
        /// <summary>
        /// The Atomics.exchange() static method exchanges a given value at a given position in the array and returns the old value at that position. This atomic operation guarantees that no other write happens between the read of the old value and the write of the new value.
        /// </summary>
        /// <typeparam name="T">TypedArray element .Net type</typeparam>
        /// <param name="typedArray">An integer typed array. One of Int8Array, Uint8Array, Int16Array, Uint16Array, Int32Array, Uint32Array, BigInt64Array, or BigUint64Array.</param>
        /// <param name="index">The position in the typedArray to exchange a value.</param>
        /// <param name="value">The number to exchange.</param>
        /// <returns>The old value at the given position (typedArray[index]).</returns>
        public static T Exchange<T>(TypedArray<T> typedArray, long index, T value) where T : struct => JS.Call<T>("Atomics.exchange", typedArray, index, value);
        /// <summary>
        /// The Atomics.isLockFree() static method is used to determine whether the Atomics methods use locks or atomic hardware operations when applied to typed arrays with the given element byte size. It returns false if the given size is not one of the BYTES_PER_ELEMENT property of integer TypedArray types.
        /// </summary>
        /// <param name="size">The size in bytes to check.</param>
        /// <returns>A true or false value indicating whether the operation is lock free.</returns>
        public static bool IsLockFree(int size) => JS.Call<bool>("Atomics.isLockFree", size);
        /// <summary>
        /// The Atomics.load() static method returns a value at a given position in the array.
        /// </summary>
        /// <typeparam name="T">TypedArray element .Net type</typeparam>
        /// <param name="typedArray">An integer typed array. One of Int8Array, Uint8Array, Int16Array, Uint16Array, Int32Array, Uint32Array, BigInt64Array, or BigUint64Array.</param>
        /// <param name="index">The position in the typedArray to load from.</param>
        /// <returns>The value at the given position (typedArray[index]).</returns>
        public static T Load<T>(TypedArray<T> typedArray, long index) where T : struct => JS.Call<T>("Atomics.load", typedArray, index);
        /// <summary>
        /// The Atomics.notify() static method notifies up some agents that are sleeping in the wait queue.
        /// </summary>
        /// <param name="typedArray">An Int32Array or BigInt64Array that views a SharedArrayBuffer.</param>
        /// <param name="index">The position in the typedArray to wake up on.</param>
        /// <param name="count">The number of sleeping agents to notify. Defaults to Infinity.</param>
        /// <returns>
        /// - The number of woken up agents.<br/>
        /// - 0, if a non-shared ArrayBuffer object is used.
        /// </returns>
        public static int Notify(TypedArray typedArray, long index, int count) => JS.Call<int>("Atomics.notify", typedArray, index, count);
        /// <summary>
        /// The Atomics.or() static method computes a bitwise OR with a given value at a given position in the array, and returns the old value at that position. This atomic operation guarantees that no other write happens until the modified value is written back.
        /// </summary>
        /// <typeparam name="T">TypedArray element .Net type</typeparam>
        /// <param name="typedArray">An integer typed array. One of Int8Array, Uint8Array, Int16Array, Uint16Array, Int32Array, Uint32Array, BigInt64Array, or BigUint64Array.</param>
        /// <param name="index">The position in the typedArray to compute the bitwise OR.</param>
        /// <param name="value">The number to compute the bitwise OR with.</param>
        /// <returns></returns>
        public static T Or<T>(TypedArray<T> typedArray, long index, T value) where T : struct => JS.Call<T>("Atomics.or", typedArray, index, value);
        /// <summary>
        /// The Atomics.store() static method stores a given value at the given position in the array and returns that value.
        /// </summary>
        /// <typeparam name="T">TypedArray element .Net type</typeparam>
        /// <param name="typedArray">An integer typed array. One of Int8Array, Uint8Array, Int16Array, Uint16Array, Int32Array, Uint32Array, BigInt64Array, or BigUint64Array.</param>
        /// <param name="index">The position in the typedArray to store a value in.</param>
        /// <param name="value">The number to store.</param>
        /// <returns>The value that has been stored.</returns>
        public static T Store<T>(TypedArray<T> typedArray, long index, T value) where T : struct => JS.Call<T>("Atomics.store", typedArray, index, value);
        /// <summary>
        /// The Atomics.sub() static method subtracts a given value at a given position in the array and returns the old value at that position. This atomic operation guarantees that no other write happens until the modified value is written back.
        /// </summary>
        /// <typeparam name="T">TypedArray element .Net type</typeparam>
        /// <param name="typedArray">An integer typed array. One of Int8Array, Uint8Array, Int16Array, Uint16Array, Int32Array, Uint32Array, BigInt64Array, or BigUint64Array.</param>
        /// <param name="index">The position in the typedArray to subtract a value from.</param>
        /// <param name="value">The number to subtract.</param>
        /// <returns>The old value at the given position (typedArray[index]).</returns>
        public static T Sub<T>(TypedArray<T> typedArray, long index, T value) where T : struct => JS.Call<T>("Atomics.sub", typedArray, index, value);
        /// <summary>
        /// The Atomics.wait() static method verifies that a shared memory location still contains a given value and if so sleeps, awaiting a wake-up notification or times out. It returns a string which is either "ok", "not-equal", or "timed-out".
        /// </summary>
        /// <typeparam name="T">TypedArray element .Net type</typeparam>
        /// <param name="typedArray">An Int32Array or BigInt64Array that views a SharedArrayBuffer.</param>
        /// <param name="index">The position in the typedArray to wait on.</param>
        /// <param name="value">The expected value to test.</param>
        /// <returns>A string which is either "ok", "not-equal", or "timed-out".</returns>
        public static string Wait<T>(TypedArray<T> typedArray, long index, T value) where T : struct => JS.Call<string>("Atomics.wait", typedArray, index, value);
        /// <summary>
        /// The Atomics.wait() static method verifies that a shared memory location still contains a given value and if so sleeps, awaiting a wake-up notification or times out. It returns a string which is either "ok", "not-equal", or "timed-out".
        /// </summary>
        /// <typeparam name="T">TypedArray element .Net type</typeparam>
        /// <param name="typedArray">An Int32Array or BigInt64Array that views a SharedArrayBuffer.</param>
        /// <param name="index">The position in the typedArray to wait on.</param>
        /// <param name="value">The expected value to test.</param>
        /// <param name="timeout">Time to wait in milliseconds. Negative values become 0.</param>
        /// <returns>A string which is either "ok", "not-equal", or "timed-out".</returns>
        public static string Wait<T>(TypedArray<T> typedArray, long index, T value, int timeout) where T : struct => JS.Call<string>("Atomics.wait", typedArray, index, value, timeout);
        /// <summary>
        /// The Atomics.waitAsync() static method waits asynchronously on a shared memory location and returns a Promise.
        /// </summary>
        /// <typeparam name="T">TypedArray element .Net type</typeparam>
        /// <param name="typedArray">An Int32Array or BigInt64Array that views a SharedArrayBuffer.</param>
        /// <param name="index">The position in the typedArray to wait on.</param>
        /// <param name="value">The expected value to test.</param>
        /// <returns></returns>
        public static AtomicsWaitAsyncResult WaitAsync<T>(TypedArray<T> typedArray, long index, T value) where T : struct => JS.Call<AtomicsWaitAsyncResult>("Atomics.waitAsync", typedArray, index, value);
        /// <summary>
        /// The Atomics.waitAsync() static method waits asynchronously on a shared memory location and returns a Promise.
        /// </summary>
        /// <typeparam name="T">TypedArray element .Net type</typeparam>
        /// <param name="typedArray">An Int32Array or BigInt64Array that views a SharedArrayBuffer.</param>
        /// <param name="index">The position in the typedArray to wait on.</param>
        /// <param name="value">The expected value to test.</param>
        /// <param name="timeout">Time to wait in milliseconds. Negative values become 0.</param>
        /// <returns></returns>
        public static AtomicsWaitAsyncResult WaitAsync<T>(TypedArray<T> typedArray, long index, T value, int timeout) where T : struct => JS.Call<AtomicsWaitAsyncResult>("Atomics.waitAsync", typedArray, index, value, timeout);
        /// <summary>
        /// The Atomics.xor() static method computes a bitwise XOR with a given value at a given position in the array, and returns the old value at that position. This atomic operation guarantees that no other write happens until the modified value is written back.
        /// </summary>
        /// <typeparam name="T">TypedArray element .Net type</typeparam>
        /// <param name="typedArray">An integer typed array. One of Int8Array, Uint8Array, Int16Array, Uint16Array, Int32Array, Uint32Array, BigInt64Array, or BigUint64Array.</param>
        /// <param name="index">The position in the typedArray to compute the bitwise XOR.</param>
        /// <param name="value">The number to compute the bitwise XOR with.</param>
        /// <returns>The old value at the given position (typedArray[index]).</returns>
        public static T Xor<T>(TypedArray<T> typedArray, long index, T value) where T : struct => JS.Call<T>("Atomics.xor", typedArray, index, value);
    }
}
