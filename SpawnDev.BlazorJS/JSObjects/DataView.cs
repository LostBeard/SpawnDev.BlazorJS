using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DataView view provides a low-level interface for reading and writing multiple number types in a binary ArrayBuffer, without having to care about the platform's endianness.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/DataView
    /// </summary>
    public class DataView : JSObject
    {
        /// <summary>
        /// Creates a new DataView object.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public DataView(ArrayBuffer arrayBuffer) : base(JS.New(nameof(DataView), arrayBuffer)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DataView(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The ArrayBuffer referenced by this view. Fixed at construction time and thus read only.
        /// </summary>
        public ArrayBuffer Buffer => JSRef!.Get<ArrayBuffer>("buffer");
        /// <summary>
        /// The length (in bytes) of this view. Fixed at construction time and thus read only.
        /// </summary>
        public long ByteLength => JSRef!.Get<long>("byteLength");
        /// <summary>
        /// The offset (in bytes) of this view from the start of its ArrayBuffer. Fixed at construction time and thus read only.
        /// </summary>
        public long ByteOffset => JSRef!.Get<long>("byteOffset");
        /// <summary>
        /// The getBigInt64() method of DataView instances reads 8 bytes starting at the specified byte offset of this DataView and interprets them as a 64-bit signed integer. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <returns>A BigInt from -263 to 263-1, inclusive.</returns>
        public long GetBigInt64(long byteOffset) => JSRef!.Call<BigInt<long>>("getBigInt64", byteOffset);
        /// <summary>
        /// The getBigInt64() method of DataView instances reads 8 bytes starting at the specified byte offset of this DataView and interprets them as a 64-bit signed integer. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is read.</param>
        /// <returns>A BigInt from -263 to 263-1, inclusive.</returns>
        public long GetBigInt64(long byteOffset, bool littleEndian) => JSRef!.Call<BigInt<long>>("getBigInt64", byteOffset, littleEndian);
        /// <summary>
        /// The getBigUint64() method of DataView instances reads 8 bytes starting at the specified byte offset of this DataView and interprets them as a 64-bit unsigned integer. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <returns>A BigInt from 0 to 264-1, inclusive.</returns>
        public ulong GetBigUint64(long byteOffset) => JSRef!.Call<BigInt<ulong>>("getBigUint64", byteOffset);
        /// <summary>
        /// The getBigUint64() method of DataView instances reads 8 bytes starting at the specified byte offset of this DataView and interprets them as a 64-bit unsigned integer. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is read.</param>
        /// <returns>A BigInt from 0 to 264-1, inclusive.</returns>
        public ulong GetBigUint64(long byteOffset, bool littleEndian) => JSRef!.Call<BigInt<ulong>>("getBigUint64", byteOffset, littleEndian);
        /// <summary>
        /// The getFloat16() method of DataView instances reads 2 bytes starting at the specified byte offset of this DataView and interprets them as a 16-bit floating point number. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <returns>A floating point number from -65504 to 65504.</returns>
        public Half GetFloat16(long byteOffset) => JSRef!.Call<Half>("getFloat16", byteOffset);
        /// <summary>
        /// The getFloat16() method of DataView instances reads 2 bytes starting at the specified byte offset of this DataView and interprets them as a 16-bit floating point number. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is read.</param>
        /// <returns>A floating point number from -65504 to 65504.</returns>
        public Half GetFloat16(long byteOffset, bool littleEndian) => JSRef!.Call<Half>("getFloat16", byteOffset, littleEndian);
        /// <summary>
        /// The getFloat32() method of DataView instances reads 4 bytes starting at the specified byte offset of this DataView and interprets them as a 32-bit floating point number. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <returns>A floating point number from -3.4e38 to 3.4e38.</returns>
        public float GetFloat32(long byteOffset) => JSRef!.Call<float>("getFloat32", byteOffset);
        /// <summary>
        /// The getFloat32() method of DataView instances reads 4 bytes starting at the specified byte offset of this DataView and interprets them as a 32-bit floating point number. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is read.</param>
        /// <returns>A floating point number from -3.4e38 to 3.4e38.</returns>
        public float GetFloat32(long byteOffset, bool littleEndian) => JSRef!.Call<float>("getFloat32", byteOffset, littleEndian);
        /// <summary>
        /// The getFloat64() method of DataView instances reads 8 bytes starting at the specified byte offset of this DataView and interprets them as a 64-bit floating point number. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <returns>Any number value.</returns>
        public double GetFloat64(long byteOffset) => JSRef!.Call<double>("getFloat64", byteOffset);
        /// <summary>
        /// The getFloat64() method of DataView instances reads 8 bytes starting at the specified byte offset of this DataView and interprets them as a 64-bit floating point number. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is read.</param>
        /// <returns>Any number value.</returns>
        public double GetFloat64(long byteOffset, bool littleEndian) => JSRef!.Call<double>("getFloat64", byteOffset, littleEndian);
        /// <summary>
        /// The getInt16() method of DataView instances reads 2 bytes starting at the specified byte offset of this DataView and interprets them as a 16-bit signed integer. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <returns>An integer from -32768 to 32767, inclusive.</returns>
        public short GetInt16(long byteOffset) => JSRef!.Call<short>("getInt16", byteOffset);
        /// <summary>
        /// The getInt16() method of DataView instances reads 2 bytes starting at the specified byte offset of this DataView and interprets them as a 16-bit signed integer. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is read.</param>
        /// <returns>An integer from -32768 to 32767, inclusive.</returns>
        public short GetInt16(long byteOffset, bool littleEndian) => JSRef!.Call<short>("getInt16", byteOffset, littleEndian);
        /// <summary>
        /// The getInt32() method of DataView instances reads 4 bytes starting at the specified byte offset of this DataView and interprets them as a 32-bit signed integer. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <returns>An integer from -2147483648 to 2147483647, inclusive.</returns>
        public int GetInt32(long byteOffset) => JSRef!.Call<int>("getInt32", byteOffset);
        /// <summary>
        /// The getInt32() method of DataView instances reads 4 bytes starting at the specified byte offset of this DataView and interprets them as a 32-bit signed integer. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is read.</param>
        /// <returns>An integer from -2147483648 to 2147483647, inclusive.</returns>
        public int GetInt32(long byteOffset, bool littleEndian) => JSRef!.Call<int>("getInt32", byteOffset, littleEndian);
        /// <summary>
        /// The getInt8() method of DataView instances reads 1 byte at the specified byte offset of this DataView and interprets it as an 8-bit signed integer.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <returns>An integer from -128 to 127, inclusive.</returns>
        public sbyte GetInt8(long byteOffset) => JSRef!.Call<sbyte>("getInt8", byteOffset);
        /// <summary>
        /// The getUint16() method of DataView instances reads 2 bytes starting at the specified byte offset of this DataView and interprets them as a 16-bit unsigned integer. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <returns>An integer from 0 to 65535, inclusive.</returns>
        public ushort GetUint16(long byteOffset) => JSRef!.Call<ushort>("getUint16", byteOffset);
        /// <summary>
        /// The getUint16() method of DataView instances reads 2 bytes starting at the specified byte offset of this DataView and interprets them as a 16-bit unsigned integer. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is read.</param>
        /// <returns>An integer from 0 to 65535, inclusive.</returns>
        public ushort GetUint16(long byteOffset, bool littleEndian) => JSRef!.Call<ushort>("getUint16", byteOffset, littleEndian);
        /// <summary>
        /// The getUint32() method of DataView instances reads 4 bytes starting at the specified byte offset of this DataView and interprets them as a 32-bit unsigned integer. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <returns>An integer from 0 to 4294967295, inclusive.</returns>
        public uint GetUint32(long byteOffset) => JSRef!.Call<uint>("getUint32", byteOffset);
        /// <summary>
        /// The getUint32() method of DataView instances reads 4 bytes starting at the specified byte offset of this DataView and interprets them as a 32-bit unsigned integer. There is no alignment constraint; multi-byte values may be fetched from any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is read.</param>
        /// <returns>An integer from 0 to 4294967295, inclusive.</returns>
        public uint GetUint32(long byteOffset, bool littleEndian) => JSRef!.Call<uint>("getUint32", byteOffset, littleEndian);
        /// <summary>
        /// The getUint8() method of DataView instances reads 1 byte at the specified byte offset of this DataView and interprets it as an 8-bit unsigned integer.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to read the data from.</param>
        /// <returns>An integer from 0 to 255, inclusive.</returns>
        public byte GetUint8(long byteOffset) => JSRef!.Call<byte>("getUint8", byteOffset);
        /// <summary>
        /// The setBigInt64() method of DataView instances takes a BigInt and stores it as a 64-bit signed integer in the 8 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set as a BigInt. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        public void SetBigInt64(long byteOffset, long value) => JSRef!.CallVoid("setBigInt64", byteOffset, (BigInt<long>)value);
        /// <summary>
        /// The setBigInt64() method of DataView instances takes a BigInt and stores it as a 64-bit signed integer in the 8 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set as a BigInt. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is written.</param>
        public void SetBigInt64(long byteOffset, long value, bool littleEndian) => JSRef!.CallVoid("setBigInt64", byteOffset, (BigInt<long>)value, littleEndian);
        /// <summary>
        /// The setBigUint64() method of DataView instances takes a BigInt and stores it as a 64-bit unsigned integer in the 8 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set as a BigInt. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        public void SetBigUint64(long byteOffset, ulong value) => JSRef!.CallVoid("setBigUint64", byteOffset, (BigInt<ulong>)value);
        /// <summary>
        /// The setBigUint64() method of DataView instances takes a BigInt and stores it as a 64-bit unsigned integer in the 8 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set as a BigInt. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is written.</param>
        public void SetBigUint64(long byteOffset, ulong value, bool littleEndian) => JSRef!.CallVoid("setBigUint64", byteOffset, (BigInt<ulong>)value, littleEndian);
        /// <summary>
        /// The setFloat16() method of DataView instances takes a number and stores it as a 16-bit floating point number in the 2 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        public void SetFloat16(long byteOffset, Half value) => JSRef!.CallVoid("setFloat16", byteOffset, value);
        /// <summary>
        /// The setFloat16() method of DataView instances takes a number and stores it as a 16-bit floating point number in the 2 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is written.</param>
        public void SetFloat16(long byteOffset, Half value, bool littleEndian) => JSRef!.CallVoid("setFloat16", byteOffset, value, littleEndian);
        /// <summary>
        /// The setFloat32() method of DataView instances takes a number and stores it as a 32-bit floating point number in the 4 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        public void SetFloat32(long byteOffset, float value) => JSRef!.CallVoid("setFloat32", byteOffset, value);
        /// <summary>
        /// The setFloat32() method of DataView instances takes a number and stores it as a 32-bit floating point number in the 4 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is written.</param>
        public void SetFloat32(long byteOffset, float value, bool littleEndian) => JSRef!.CallVoid("setFloat32", byteOffset, value, littleEndian);
        /// <summary>
        /// The setFloat64() method of DataView instances takes a number and stores it as a 64-bit floating point number in the 8 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        public void SetFloat64(long byteOffset, double value) => JSRef!.CallVoid("setFloat64", byteOffset, value);
        /// <summary>
        /// The setFloat64() method of DataView instances takes a number and stores it as a 64-bit floating point number in the 8 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is written.</param>
        public void SetFloat64(long byteOffset, double value, bool littleEndian) => JSRef!.CallVoid("setFloat64", byteOffset, value, littleEndian);
        /// <summary>
        /// The setInt16() method of DataView instances takes a number and stores it as a 16-bit signed integer in the 2 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is written.</param>
        public void SetInt16(long byteOffset, short value) => JSRef!.CallVoid("setInt16", byteOffset, value);
        /// <summary>
        /// The setInt16() method of DataView instances takes a number and stores it as a 16-bit signed integer in the 2 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is written.</param>
        public void SetInt16(long byteOffset, short value, bool littleEndian) => JSRef!.CallVoid("setInt16", byteOffset, value, littleEndian);
        /// <summary>
        /// The setInt32() method of DataView instances takes a number and stores it as a 32-bit signed integer in the 4 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        public void SetInt32(long byteOffset, int value) => JSRef!.CallVoid("setInt32", byteOffset, value);
        /// <summary>
        /// The setInt32() method of DataView instances takes a number and stores it as a 32-bit signed integer in the 4 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is written.</param>
        public void SetInt32(long byteOffset, int value, bool littleEndian) => JSRef!.CallVoid("setInt32", byteOffset, value, littleEndian);
        /// <summary>
        /// The setInt8() method of DataView instances takes a number and stores it as an 8-bit signed integer in the byte at the specified byte offset of this DataView.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        public void SetInt8(long byteOffset, sbyte value) => JSRef!.CallVoid("setInt8", byteOffset, value);
        /// <summary>
        /// The setUint16() method of DataView instances takes a number and stores it as a 16-bit unsigned integer in the 2 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        public void SetUint16(long byteOffset, ushort value) => JSRef!.CallVoid("setUint16", byteOffset, value);
        /// <summary>
        /// The setUint16() method of DataView instances takes a number and stores it as a 16-bit unsigned integer in the 2 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is written.</param>
        public void SetUint16(long byteOffset, ushort value, bool littleEndian) => JSRef!.CallVoid("setUint16", byteOffset, value, littleEndian);
        /// <summary>
        /// The setUint32() method of DataView instances takes a number and stores it as a 32-bit unsigned integer in the 4 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is written.</param>
        public void SetUint32(long byteOffset, uint value) => JSRef!.CallVoid("setUint32", byteOffset, value);
        /// <summary>
        /// The setUint32() method of DataView instances takes a number and stores it as a 32-bit unsigned integer in the 4 bytes starting at the specified byte offset of this DataView. There is no alignment constraint; multi-byte values may be stored at any offset within bounds.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        /// <param name="littleEndian">Indicates whether the data is stored in little- or big-endian format. If false or undefined, a big-endian value is written.</param>
        public void SetUint32(long byteOffset, uint value, bool littleEndian) => JSRef!.CallVoid("setUint32", byteOffset, value, littleEndian);
        /// <summary>
        /// The setUint8() method of DataView instances takes a number and stores it as an 8-bit unsigned integer in the byte at the specified byte offset of this DataView.
        /// </summary>
        /// <param name="byteOffset">The offset, in bytes, from the start of the view to store the data in.</param>
        /// <param name="value">The value to set. For how the value is encoded in bytes, see Value encoding and normalization.</param>
        public void SetUint8(long byteOffset, byte value) => JSRef!.CallVoid("setUint8", byteOffset, value);
    }
}
