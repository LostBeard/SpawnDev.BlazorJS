using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.IJSObjects
{
    interface Symbol
    {
        string ToString();
        object ValueOf();
    }
    interface PropertyDescriptor
    {
        object Get();
        void Set(object v);
    }
    interface PropertyDescriptorMap
    {
    }
    interface PropertyKey
    {
    }
    interface Object
    {
        string ToString();
        string ToLocaleString();
        Object ValueOf();
        bool HasOwnProperty(PropertyKey v);
        bool IsPrototypeOf(Object v);
        bool PropertyIsEnumerable(PropertyKey v);
    }
    interface ObjectConstructor
    {
        object GetPrototypeOf(object o);
        object GetOwnPropertyDescriptor(object o, PropertyKey p);
        string[] GetOwnPropertyNames(object o);
        object Create(object o);
        object Create(object o, object properties);
        T DefineProperty<T>(T o, PropertyKey p, object attributes);
        T DefineProperties<T>(T o, object properties);
        T Seal<T>(T o);
        T Freeze<T>(T f);
        T PreventExtensions<T>(T o);
        bool IsSealed(object o);
        bool IsFrozen(object o);
        bool IsExtensible(object o);
        string[] Keys(object o);
    }
    interface Function
    {
        object Apply(object thisArg, object? argArray);
        object Call(object thisArg, params object[] argArray);
        object Bind(object thisArg, params object[] argArray);
        string ToString();
    }
    interface FunctionConstructor
    {
    }
    interface CallableFunction
    {
        T Apply<T, R>(T thisArg);
        T Apply<T, A, R>(T thisArg, A args);
        T Call<T, A, R>(T thisArg, params object[] args);
        T Bind<T>(T thisArg);
        Func<R> Bind<T, A0, A, R>(T thisArg, A0 arg0);
        Func<R> Bind<T, A0, A1, A, R>(T thisArg, A0 arg0, A1 arg1);
        Func<R> Bind<T, A0, A1, A2, A, R>(T thisArg, A0 arg0, A1 arg1, A2 arg2);
        Func<R> Bind<T, A0, A1, A2, A3, A, R>(T thisArg, A0 arg0, A1 arg1, A2 arg2, A3 arg3);
        Func<R> Bind<T, AX, R>(T thisArg, params object[] args);
    }
    interface NewableFunction
    {
        void Apply<T>(T thisArg);
        void Apply<T, A>(T thisArg, A args);
        void Call<T, A>(T thisArg, params object[] args);
        T Bind<T>(object thisArg);
        object Bind<A0, A, R>(object thisArg, A0 arg0);
        object Bind<A0, A1, A, R>(object thisArg, A0 arg0, A1 arg1);
        object Bind<A0, A1, A2, A, R>(object thisArg, A0 arg0, A1 arg1, A2 arg2);
        object Bind<A0, A1, A2, A3, A, R>(object thisArg, A0 arg0, A1 arg1, A2 arg2, A3 arg3);
        object Bind<AX, R>(object thisArg, params object[] args);
    }
    interface IArguments
    {
    }
    interface String
    {
        double LocaleCompare(string that, object? locales, object? options);
        string ToString();
        string CharAt(double pos);
        double CharCodeAt(double index);
        string Concat(params object[] strings);
        double IndexOf(string searchString, object? position);
        double LastIndexOf(string searchString, object? position);
        double LocaleCompare(string that);
        object Match(object regexp);
        string Replace(object searchValue, string replaceValue);
        string Replace(object searchValue, params Func<string>[] replacer);
        double Search(object regexp);
        string Slice(object? start, object? end);
        string[] Split(object separator, object? limit);
        string Substring(double start, object? end);
        string ToLowerCase();
        string ToLocaleLowerCase(object? locales);
        string ToUpperCase();
        string ToLocaleUpperCase(object? locales);
        string Trim();
        string Substr(double from, object? length);
        string ValueOf();
    }
    interface StringConstructor
    {
        string FromCharCode(params object[] codes);
    }
    interface Boolean
    {
        bool ValueOf();
    }
    interface BooleanConstructor
    {
    }
    interface Number
    {
        string ToLocaleString(object? locales, object? options);
        string ToString(object? radix);
        string ToFixed(object? fractionDigits);
        string ToExponential(object? fractionDigits);
        string ToPrecision(object? precision);
        double ValueOf();
    }
    interface NumberConstructor
    {
    }
    interface TemplateStringsArray
    {
    }
    interface ImportMeta
    {
    }
    interface ImportCallOptions
    {
    }
    interface ImportAssertions
    {
    }
    interface Math
    {
        double Abs(double x);
        double Acos(double x);
        double Asin(double x);
        double Atan(double x);
        double Atan2(double y, double x);
        double Ceil(double x);
        double Cos(double x);
        double Exp(double x);
        double Floor(double x);
        double Log(double x);
        double Max(params object[] values);
        double Min(params object[] values);
        double Pow(double x, double y);
        double Random();
        double Round(double x);
        double Sin(double x);
        double Sqrt(double x);
        double Tan(double x);
    }
    interface Date
    {
        string ToLocaleString(object? locales, object? options);
        string ToLocaleDateString(object? locales, object? options);
        string ToLocaleTimeString(object? locales, object? options);
        string ToString();
        string ToDateString();
        string ToTimeString();
        string ToLocaleString();
        string ToLocaleDateString();
        string ToLocaleTimeString();
        double ValueOf();
        double GetTime();
        double GetFullYear();
        double GetUTCFullYear();
        double GetMonth();
        double GetUTCMonth();
        double GetDate();
        double GetUTCDate();
        double GetDay();
        double GetUTCDay();
        double GetHours();
        double GetUTCHours();
        double GetMinutes();
        double GetUTCMinutes();
        double GetSeconds();
        double GetUTCSeconds();
        double GetMilliseconds();
        double GetUTCMilliseconds();
        double GetTimezoneOffset();
        double SetTime(double time);
        double SetMilliseconds(double ms);
        double SetUTCMilliseconds(double ms);
        double SetSeconds(double sec, object? ms);
        double SetUTCSeconds(double sec, object? ms);
        double SetMinutes(double min, object? sec, object? ms);
        double SetUTCMinutes(double min, object? sec, object? ms);
        double SetHours(double hours, object? min, object? sec, object? ms);
        double SetUTCHours(double hours, object? min, object? sec, object? ms);
        double SetDate(double date);
        double SetUTCDate(double date);
        double SetMonth(double month, object? date);
        double SetUTCMonth(double month, object? date);
        double SetFullYear(double year, object? month, object? date);
        double SetUTCFullYear(double year, object? month, object? date);
        string ToUTCString();
        string ToISOString();
        string ToJSON(object? key);
    }
    interface DateConstructor
    {
        double Parse(string s);
        double UTC(double year, double monthIndex, object? date, object? hours, object? minutes, object? seconds, object? ms);
        double Now();
    }
    interface RegExpMatchArray
    {
    }
    interface RegExpExecArray
    {
    }
    interface RegExp
    {
        object Exec(string str);
        bool Test(string str);
        object Compile(string pattern, object? flags);
    }
    interface RegExpConstructor
    {
    }
    interface Error
    {
    }
    interface ErrorConstructor
    {
    }
    interface EvalError
    {
    }
    interface EvalErrorConstructor
    {
    }
    interface RangeError
    {
    }
    interface RangeErrorConstructor
    {
    }
    interface ReferenceError
    {
    }
    interface ReferenceErrorConstructor
    {
    }
    interface SyntaxError
    {
    }
    interface SyntaxErrorConstructor
    {
    }
    interface TypeError
    {
    }
    interface TypeErrorConstructor
    {
    }
    interface URIError
    {
    }
    interface URIErrorConstructor
    {
    }
    interface JSON
    {
        object Parse(string text, object? reviver);
        string Stringify(object value, object? replacer, object? space);
    }
    interface ReadonlyArray<T>
    {
        string ToString();
        string ToLocaleString();
        T[] Concat(params object[] items);
        string Join(object? separator);
        T[] Slice(object? start, object? end);
        double IndexOf(T searchElement, object? fromIndex);
        double LastIndexOf(T searchElement, object? fromIndex);
        object Every<S>(Func<object> predicate, object? thisArg);
    }
    interface ConcatArray<T>
    {
        string Join(object? separator);
        T[] Slice(object? start, object? end);
    }
    interface Array<T>
    {
        string ToString();
        string ToLocaleString();
        object Pop();
        double Push(params object[] items);
        T[] Concat(params object[] items);
        string Join(object? separator);
        T[] Reverse();
        object Shift();
        T[] Slice(object? start, object? end);
        object Sort(object? compareFn);
        T[] Splice(double start, object? deleteCount);
        T[] Splice(double start, double deleteCount, params object[] items);
        double Unshift(params object[] items);
        double IndexOf(T searchElement, object? fromIndex);
        double LastIndexOf(T searchElement, object? fromIndex);
        object Every<S>(Func<object> predicate, object? thisArg);
        bool Every(Func<object> predicate, object? thisArg);
        bool Some(Func<object> predicate, object? thisArg);
        void ForEach(Action callbackfn, object? thisArg);
        U[] Map<U>(Func<U> callbackfn, object? thisArg);
        S[] Filter<S>(Func<object> predicate, object? thisArg);
        T[] Filter(Func<object> predicate, object? thisArg);
        T Reduce(Func<T> callbackfn);
        T Reduce(Func<T> callbackfn, T initialValue);
        U Reduce<U>(Func<U> callbackfn, U initialValue);
        T ReduceRight(Func<T> callbackfn);
        T ReduceRight(Func<T> callbackfn, T initialValue);
        U ReduceRight<U>(Func<U> callbackfn, U initialValue);
    }
    interface ArrayConstructor
    {
        object IsArray(object arg);
    }
    interface TypedPropertyDescriptor<T>
    {
    }
    interface PromiseLike<T>
    {
        TResult1 Then<TResult1, TResult2>(object? onfulfilled, object? onrejected);
    }
    interface Promise<T>
    {
        TResult1 Then<TResult1, TResult2>(object? onfulfilled, object? onrejected);
        TResult Catch<TResult>(object? onrejected);
    }
    interface ArrayLike<T>
    {
    }
    interface ThisType<T>
    {
    }
    interface ArrayBuffer
    {
        ArrayBuffer Slice(double begin, object? end);
    }
    interface ArrayBufferTypes
    {
    }
    interface ArrayBufferConstructor
    {
        object IsView(object arg);
    }
    interface ArrayBufferView
    {
    }
    interface DataView
    {
        double GetFloat32(double byteOffset, object? littleEndian);
        double GetFloat64(double byteOffset, object? littleEndian);
        double GetInt8(double byteOffset);
        double GetInt16(double byteOffset, object? littleEndian);
        double GetInt32(double byteOffset, object? littleEndian);
        double GetUint8(double byteOffset);
        double GetUint16(double byteOffset, object? littleEndian);
        double GetUint32(double byteOffset, object? littleEndian);
        void SetFloat32(double byteOffset, double value, object? littleEndian);
        void SetFloat64(double byteOffset, double value, object? littleEndian);
        void SetInt8(double byteOffset, double value);
        void SetInt16(double byteOffset, double value, object? littleEndian);
        void SetInt32(double byteOffset, double value, object? littleEndian);
        void SetUint8(double byteOffset, double value);
        void SetUint16(double byteOffset, double value, object? littleEndian);
        void SetUint32(double byteOffset, double value, object? littleEndian);
    }
    interface DataViewConstructor
    {
    }
    interface Int8Array
    {
        object CopyWithin(double target, double start, object? end);
        bool Every(Func<object> predicate, object? thisArg);
        object Fill(double value, object? start, object? end);
        Int8Array Filter(Func<object> predicate, object? thisArg);
        object Find(Func<bool> predicate, object? thisArg);
        double FindIndex(Func<bool> predicate, object? thisArg);
        void ForEach(Action callbackfn, object? thisArg);
        double IndexOf(double searchElement, object? fromIndex);
        string Join(object? separator);
        double LastIndexOf(double searchElement, object? fromIndex);
        Int8Array Map(Func<double> callbackfn, object? thisArg);
        double Reduce(Func<double> callbackfn);
        double Reduce(Func<double> callbackfn, double initialValue);
        U Reduce<U>(Func<U> callbackfn, U initialValue);
        double ReduceRight(Func<double> callbackfn);
        double ReduceRight(Func<double> callbackfn, double initialValue);
        U ReduceRight<U>(Func<U> callbackfn, U initialValue);
        Int8Array Reverse();
        void Set(ArrayLike<double> array, object? offset);
        Int8Array Slice(object? start, object? end);
        bool Some(Func<object> predicate, object? thisArg);
        object Sort(object? compareFn);
        Int8Array Subarray(object? begin, object? end);
        string ToLocaleString();
        string ToString();
        Int8Array ValueOf();
    }
    interface Int8ArrayConstructor
    {
        Int8Array Of(params object[] items);
        Int8Array From(ArrayLike<double> arrayLike);
        T From<T>(ArrayLike<T> arrayLike, Func<double> mapfn, object? thisArg);
    }
    interface Uint8Array
    {
        object CopyWithin(double target, double start, object? end);
        bool Every(Func<object> predicate, object? thisArg);
        object Fill(double value, object? start, object? end);
        Uint8Array Filter(Func<object> predicate, object? thisArg);
        object Find(Func<bool> predicate, object? thisArg);
        double FindIndex(Func<bool> predicate, object? thisArg);
        void ForEach(Action callbackfn, object? thisArg);
        double IndexOf(double searchElement, object? fromIndex);
        string Join(object? separator);
        double LastIndexOf(double searchElement, object? fromIndex);
        Uint8Array Map(Func<double> callbackfn, object? thisArg);
        double Reduce(Func<double> callbackfn);
        double Reduce(Func<double> callbackfn, double initialValue);
        U Reduce<U>(Func<U> callbackfn, U initialValue);
        double ReduceRight(Func<double> callbackfn);
        double ReduceRight(Func<double> callbackfn, double initialValue);
        U ReduceRight<U>(Func<U> callbackfn, U initialValue);
        Uint8Array Reverse();
        void Set(ArrayLike<double> array, object? offset);
        Uint8Array Slice(object? start, object? end);
        bool Some(Func<object> predicate, object? thisArg);
        object Sort(object? compareFn);
        Uint8Array Subarray(object? begin, object? end);
        string ToLocaleString();
        string ToString();
        Uint8Array ValueOf();
    }
    interface Uint8ArrayConstructor
    {
        Uint8Array Of(params object[] items);
        Uint8Array From(ArrayLike<double> arrayLike);
        T From<T>(ArrayLike<T> arrayLike, Func<double> mapfn, object? thisArg);
    }
    interface Uint8ClampedArray
    {
        object CopyWithin(double target, double start, object? end);
        bool Every(Func<object> predicate, object? thisArg);
        object Fill(double value, object? start, object? end);
        Uint8ClampedArray Filter(Func<object> predicate, object? thisArg);
        object Find(Func<bool> predicate, object? thisArg);
        double FindIndex(Func<bool> predicate, object? thisArg);
        void ForEach(Action callbackfn, object? thisArg);
        double IndexOf(double searchElement, object? fromIndex);
        string Join(object? separator);
        double LastIndexOf(double searchElement, object? fromIndex);
        Uint8ClampedArray Map(Func<double> callbackfn, object? thisArg);
        double Reduce(Func<double> callbackfn);
        double Reduce(Func<double> callbackfn, double initialValue);
        U Reduce<U>(Func<U> callbackfn, U initialValue);
        double ReduceRight(Func<double> callbackfn);
        double ReduceRight(Func<double> callbackfn, double initialValue);
        U ReduceRight<U>(Func<U> callbackfn, U initialValue);
        Uint8ClampedArray Reverse();
        void Set(ArrayLike<double> array, object? offset);
        Uint8ClampedArray Slice(object? start, object? end);
        bool Some(Func<object> predicate, object? thisArg);
        object Sort(object? compareFn);
        Uint8ClampedArray Subarray(object? begin, object? end);
        string ToLocaleString();
        string ToString();
        Uint8ClampedArray ValueOf();
    }
    interface Uint8ClampedArrayConstructor
    {
        Uint8ClampedArray Of(params object[] items);
        Uint8ClampedArray From(ArrayLike<double> arrayLike);
        T From<T>(ArrayLike<T> arrayLike, Func<double> mapfn, object? thisArg);
    }
    interface Int16Array
    {
        object CopyWithin(double target, double start, object? end);
        bool Every(Func<object> predicate, object? thisArg);
        object Fill(double value, object? start, object? end);
        Int16Array Filter(Func<object> predicate, object? thisArg);
        object Find(Func<bool> predicate, object? thisArg);
        double FindIndex(Func<bool> predicate, object? thisArg);
        void ForEach(Action callbackfn, object? thisArg);
        double IndexOf(double searchElement, object? fromIndex);
        string Join(object? separator);
        double LastIndexOf(double searchElement, object? fromIndex);
        Int16Array Map(Func<double> callbackfn, object? thisArg);
        double Reduce(Func<double> callbackfn);
        double Reduce(Func<double> callbackfn, double initialValue);
        U Reduce<U>(Func<U> callbackfn, U initialValue);
        double ReduceRight(Func<double> callbackfn);
        double ReduceRight(Func<double> callbackfn, double initialValue);
        U ReduceRight<U>(Func<U> callbackfn, U initialValue);
        Int16Array Reverse();
        void Set(ArrayLike<double> array, object? offset);
        Int16Array Slice(object? start, object? end);
        bool Some(Func<object> predicate, object? thisArg);
        object Sort(object? compareFn);
        Int16Array Subarray(object? begin, object? end);
        string ToLocaleString();
        string ToString();
        Int16Array ValueOf();
    }
    interface Int16ArrayConstructor
    {
        Int16Array Of(params object[] items);
        Int16Array From(ArrayLike<double> arrayLike);
        T From<T>(ArrayLike<T> arrayLike, Func<double> mapfn, object? thisArg);
    }
    interface Uint16Array
    {
        object CopyWithin(double target, double start, object? end);
        bool Every(Func<object> predicate, object? thisArg);
        object Fill(double value, object? start, object? end);
        Uint16Array Filter(Func<object> predicate, object? thisArg);
        object Find(Func<bool> predicate, object? thisArg);
        double FindIndex(Func<bool> predicate, object? thisArg);
        void ForEach(Action callbackfn, object? thisArg);
        double IndexOf(double searchElement, object? fromIndex);
        string Join(object? separator);
        double LastIndexOf(double searchElement, object? fromIndex);
        Uint16Array Map(Func<double> callbackfn, object? thisArg);
        double Reduce(Func<double> callbackfn);
        double Reduce(Func<double> callbackfn, double initialValue);
        U Reduce<U>(Func<U> callbackfn, U initialValue);
        double ReduceRight(Func<double> callbackfn);
        double ReduceRight(Func<double> callbackfn, double initialValue);
        U ReduceRight<U>(Func<U> callbackfn, U initialValue);
        Uint16Array Reverse();
        void Set(ArrayLike<double> array, object? offset);
        Uint16Array Slice(object? start, object? end);
        bool Some(Func<object> predicate, object? thisArg);
        object Sort(object? compareFn);
        Uint16Array Subarray(object? begin, object? end);
        string ToLocaleString();
        string ToString();
        Uint16Array ValueOf();
    }
    interface Uint16ArrayConstructor
    {
        Uint16Array Of(params object[] items);
        Uint16Array From(ArrayLike<double> arrayLike);
        T From<T>(ArrayLike<T> arrayLike, Func<double> mapfn, object? thisArg);
    }
    interface Int32Array
    {
        object CopyWithin(double target, double start, object? end);
        bool Every(Func<object> predicate, object? thisArg);
        object Fill(double value, object? start, object? end);
        Int32Array Filter(Func<object> predicate, object? thisArg);
        object Find(Func<bool> predicate, object? thisArg);
        double FindIndex(Func<bool> predicate, object? thisArg);
        void ForEach(Action callbackfn, object? thisArg);
        double IndexOf(double searchElement, object? fromIndex);
        string Join(object? separator);
        double LastIndexOf(double searchElement, object? fromIndex);
        Int32Array Map(Func<double> callbackfn, object? thisArg);
        double Reduce(Func<double> callbackfn);
        double Reduce(Func<double> callbackfn, double initialValue);
        U Reduce<U>(Func<U> callbackfn, U initialValue);
        double ReduceRight(Func<double> callbackfn);
        double ReduceRight(Func<double> callbackfn, double initialValue);
        U ReduceRight<U>(Func<U> callbackfn, U initialValue);
        Int32Array Reverse();
        void Set(ArrayLike<double> array, object? offset);
        Int32Array Slice(object? start, object? end);
        bool Some(Func<object> predicate, object? thisArg);
        object Sort(object? compareFn);
        Int32Array Subarray(object? begin, object? end);
        string ToLocaleString();
        string ToString();
        Int32Array ValueOf();
    }
    interface Int32ArrayConstructor
    {
        Int32Array Of(params object[] items);
        Int32Array From(ArrayLike<double> arrayLike);
        T From<T>(ArrayLike<T> arrayLike, Func<double> mapfn, object? thisArg);
    }
    interface Uint32Array
    {
        object CopyWithin(double target, double start, object? end);
        bool Every(Func<object> predicate, object? thisArg);
        object Fill(double value, object? start, object? end);
        Uint32Array Filter(Func<object> predicate, object? thisArg);
        object Find(Func<bool> predicate, object? thisArg);
        double FindIndex(Func<bool> predicate, object? thisArg);
        void ForEach(Action callbackfn, object? thisArg);
        double IndexOf(double searchElement, object? fromIndex);
        string Join(object? separator);
        double LastIndexOf(double searchElement, object? fromIndex);
        Uint32Array Map(Func<double> callbackfn, object? thisArg);
        double Reduce(Func<double> callbackfn);
        double Reduce(Func<double> callbackfn, double initialValue);
        U Reduce<U>(Func<U> callbackfn, U initialValue);
        double ReduceRight(Func<double> callbackfn);
        double ReduceRight(Func<double> callbackfn, double initialValue);
        U ReduceRight<U>(Func<U> callbackfn, U initialValue);
        Uint32Array Reverse();
        void Set(ArrayLike<double> array, object? offset);
        Uint32Array Slice(object? start, object? end);
        bool Some(Func<object> predicate, object? thisArg);
        object Sort(object? compareFn);
        Uint32Array Subarray(object? begin, object? end);
        string ToLocaleString();
        string ToString();
        Uint32Array ValueOf();
    }
    interface Uint32ArrayConstructor
    {
        Uint32Array Of(params object[] items);
        Uint32Array From(ArrayLike<double> arrayLike);
        T From<T>(ArrayLike<T> arrayLike, Func<double> mapfn, object? thisArg);
    }
    interface Float32Array
    {
        object CopyWithin(double target, double start, object? end);
        bool Every(Func<object> predicate, object? thisArg);
        object Fill(double value, object? start, object? end);
        Float32Array Filter(Func<object> predicate, object? thisArg);
        object Find(Func<bool> predicate, object? thisArg);
        double FindIndex(Func<bool> predicate, object? thisArg);
        void ForEach(Action callbackfn, object? thisArg);
        double IndexOf(double searchElement, object? fromIndex);
        string Join(object? separator);
        double LastIndexOf(double searchElement, object? fromIndex);
        Float32Array Map(Func<double> callbackfn, object? thisArg);
        double Reduce(Func<double> callbackfn);
        double Reduce(Func<double> callbackfn, double initialValue);
        U Reduce<U>(Func<U> callbackfn, U initialValue);
        double ReduceRight(Func<double> callbackfn);
        double ReduceRight(Func<double> callbackfn, double initialValue);
        U ReduceRight<U>(Func<U> callbackfn, U initialValue);
        Float32Array Reverse();
        void Set(ArrayLike<double> array, object? offset);
        Float32Array Slice(object? start, object? end);
        bool Some(Func<object> predicate, object? thisArg);
        object Sort(object? compareFn);
        Float32Array Subarray(object? begin, object? end);
        string ToLocaleString();
        string ToString();
        Float32Array ValueOf();
    }
    interface Float32ArrayConstructor
    {
        Float32Array Of(params object[] items);
        Float32Array From(ArrayLike<double> arrayLike);
        T From<T>(ArrayLike<T> arrayLike, Func<double> mapfn, object? thisArg);
    }
    interface Float64Array
    {
        object CopyWithin(double target, double start, object? end);
        bool Every(Func<object> predicate, object? thisArg);
        object Fill(double value, object? start, object? end);
        Float64Array Filter(Func<object> predicate, object? thisArg);
        object Find(Func<bool> predicate, object? thisArg);
        double FindIndex(Func<bool> predicate, object? thisArg);
        void ForEach(Action callbackfn, object? thisArg);
        double IndexOf(double searchElement, object? fromIndex);
        string Join(object? separator);
        double LastIndexOf(double searchElement, object? fromIndex);
        Float64Array Map(Func<double> callbackfn, object? thisArg);
        double Reduce(Func<double> callbackfn);
        double Reduce(Func<double> callbackfn, double initialValue);
        U Reduce<U>(Func<U> callbackfn, U initialValue);
        double ReduceRight(Func<double> callbackfn);
        double ReduceRight(Func<double> callbackfn, double initialValue);
        U ReduceRight<U>(Func<U> callbackfn, U initialValue);
        Float64Array Reverse();
        void Set(ArrayLike<double> array, object? offset);
        Float64Array Slice(object? start, object? end);
        bool Some(Func<object> predicate, object? thisArg);
        object Sort(object? compareFn);
        Float64Array Subarray(object? begin, object? end);
        string ToString();
        Float64Array ValueOf();
    }
    interface Float64ArrayConstructor
    {
        Float64Array Of(params object[] items);
        Float64Array From(ArrayLike<double> arrayLike);
        T From<T>(ArrayLike<T> arrayLike, Func<double> mapfn, object? thisArg);
    }
}
