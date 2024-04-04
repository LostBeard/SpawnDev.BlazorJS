using Microsoft.JSInterop;
using System.Collections;
using System.Diagnostics;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Array object, as with arrays in other programming languages, enables storing a collection of multiple items under a single variable name, and has members for performing common array operations.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array
    /// </summary>
    public class Array : JSObject
    {
        /// <summary>
        /// Returns true if the argument is an array, or false otherwise.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsArray(JSObject obj) => JS.Call<bool>("Array.isArray", obj);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new Array
        /// </summary>
        public Array() : base(JS.New(nameof(Array))) { }
        /// <summary>
        /// Creates a new Array
        /// </summary>
        /// <param name="length"></param>
        public Array(uint length) : base(JS.New(nameof(Array), length)) { }
        /// <summary>
        /// Creates a new Array
        /// </summary>
        /// <param name="values"></param>
        public Array(params object[] values) : base(JS.NewApply(nameof(Array), values)) { }
        /// <summary>
        /// Reflects the number of elements in an array.
        /// </summary>
        public int Length => JSRef.Get<int>("length");
        /// <summary>
        /// Adds one or more elements to the end of an array, and returns the new length of the array.
        /// </summary>
        /// <param name="value"></param>
        public void Push(object? value) => JSRef.CallVoid("push", value);
        /// <summary>
        /// Adds one or more elements to the front of an array, and returns the new length of the array.
        /// </summary>
        /// <param name="value"></param>
        public void Unshift(object? value) => JSRef.CallVoid("unshift", value);
        /// <summary>
        /// Returns the array item at the given index. Accepts negative integers, which count back from the last item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <returns></returns>
        public T At<T>(int index) => JSRef.Call<T>("at", index);
        /// <summary>
        /// Returns the array item at the given index. Accepts negative integers, which count back from the last item.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public object? At(Type type, int index) => JSRef.Call(type, "at", index);
        /// <summary>
        /// Removes the last element from an array and returns that element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Pop<T>() => JSRef.Call<T>("pop");
        /// <summary>
        /// Removes the last element from an array and returns that element.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object? Pop(Type type) => JSRef.Call(type, "pop");
        /// <summary>
        /// Removes the first element from an array and returns that element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Shift<T>() => JSRef.Call<T>("shift");
        /// <summary>
        /// Removes the first element from an array and returns that element.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object? Shift(Type type) => JSRef.Call(type, "shift");
        /// <summary>
        /// Set the value of the item at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetItem(int index, object? value) => JSRef.Set(index, value);
        /// <summary>
        /// Returns the array item at the given index. Accepts negative integers, which count back from the last item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetItem<T>(int index) => JSRef.Get<T>(index);
        /// <summary>
        /// Returns the array item at the given index. Accepts negative integers, which count back from the last item.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public object? GetItem(Type type, int index) => JSRef.Get(type, index);
        /// <summary>
        /// Returns a new array that is the calling array joined with other array(s) and/or value(s).
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public Array Concat(Array array) => JSRef.Call<Array>("concat", array);
        /// <summary>
        /// Joins all elements of an array into a string.
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        public string Join(string separator = "") => JSRef.Call<string>("join", separator);
        /// <summary>
        /// Returns a new array containing the results of invoking a function on every element in the calling array.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <returns></returns>
        public Array<TResult> Map<TResult>(Function function) => JSRef.Call<Array<TResult>>("map", function);
        /// <summary>
        /// Returns a new array containing the results of invoking a function on every element in the calling array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="mapTo"></param>
        /// <returns></returns>
        public Array<TResult> Map<T, TResult>(Func<T, TResult> mapTo)
        {
            using var cb = Callback.Create(mapTo);
            return JSRef.Call<Array<TResult>>("map", cb);
        }
        /// <summary>
        /// Returns a new array containing all elements of the calling array for which the provided filtering function returns true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Array<T> Filter<T>(Func<T, bool> filter)
        {
            using var cb = Callback.Create(filter);
            return JSRef.Call<Array<T>>("filter", cb);
        }
        /// <summary>
        /// Calls a function for each element in the calling array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mapTo"></param>
        public void ForEach<T>(Action<T> mapTo)
        {
            using var cb = Callback.Create(mapTo);
            JSRef.CallVoid("forEach", cb);
        }
        /// <summary>
        /// Returns a .Net array of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T[] ToArray<T>() => JSRef!.As<T[]>();
        /// <summary>
        /// Returns the array as a .Net List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> ToList<T>() => JSRef!.As<List<T>>();
        /// <summary>
        /// Returns a .Net array of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public T[] ToArray<T>(int start, int count) => Enumerable.Range(start, count).Select(i => At<T>(i)).ToArray();
        /// <summary>
        /// Returns the array as a .Net List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<T> ToList<T>(int start, int count) => Enumerable.Range(start, count).Select(i => At<T>(i)).ToList();
    }
    /// <summary>
    /// The Array object, as with arrays in other programming languages, enables storing a collection of multiple items under a single variable name, and has members for performing common array operations.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array
    /// </summary>
    public class Array<T> : JSObject//, IEnumerable<T>
    {
        #region Enumerable like
        /// <summary>
        /// Returns first or default
        /// </summary>
        /// <returns></returns>
        public T? FirstOrDefault() => Length > 0 ? GetItem(0) : default(T?);
        /// <summary>
        /// Returns last or default
        /// </summary>
        /// <returns></returns>
        public T? LastOrDefault() => Length > 0 ? GetItem(Length - 1) : default(T?);
        /// <summary>
        /// Returns the array as a .Net List
        /// </summary>
        /// <returns></returns>
        public List<T> ToList() => ToArray().ToList();
        /// <summary>
        /// Returns the array as a .Net Array
        /// </summary>
        /// <returns></returns>
        public T[] ToArray() => JSRef!.As<T[]>();
        /// <summary>
        /// Returns the array as a .Net Array
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public T[] ToArray(int start, int count) => Enumerable.Range(start, count).Select(i => At(i)).ToArray();
        /// <summary>
        /// Returns the array as a .Net List
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<T> ToList(int start, int count) => Enumerable.Range(start, count).Select(i => At(i)).ToList();
        #endregion
        //#region Enable IEnumerable
        //public T[] ToArray() => JSRef!.As<T[]>();
        //public IEnumerator GetEnumerator() => new SimpleEnumerator<T>(this.At, () => this.Length);
        //IEnumerator<T> IEnumerable<T>.GetEnumerator() => new SimpleEnumerator<T>(this.At, () => this.Length);
        //#endregion
        public T this[int index]
        {
            get => GetItem(index);
            set => SetItem(index, value);
        }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Array() : base(JS.New(nameof(Array))) { }
        public Array(uint length) : base(JS.New(nameof(Array), length)) { }
        public Array(params T[] values) : base(JS.NewApply(nameof(Array), values == null ? null : values.Select(o => (object?)o).ToArray())) { }
        public int Length => JSRef.Get<int>("length");
        public void Push(T value) => JSRef.CallVoid("push", value);
        public void Unshift(T value) => JSRef.CallVoid("unshift", value);
        public T At(int index) => JSRef.Call<T>("at", index);
        public T Pop() => JSRef.Call<T>("pop");
        public T Shift() => JSRef.Call<T>("shift");
        public void SetItem(int index, T value) => JSRef.Set(index, value);
        public T GetItem(int index) => JSRef.Get<T>(index);
        public T GetItem(Type type, int index) => (T)JSRef.Get(type, index);
        public Array Concat(Array array) => JSRef.Call<Array>("concat", array);
        public string Join(string separator = "") => JSRef.Call<string>("join", separator);
        public Array<TResult> Map<TResult>(Function function) => JSRef.Call<Array<TResult>>("map", function);
        public Array<TResult> Map<TResult>(Func<T, TResult> mapTo)
        {
            using var cb = Callback.Create(mapTo);
            return JSRef.Call<Array<TResult>>("map", cb);
        }
        public Array<T> Filter(Func<T, bool> filter)
        {
            using var cb = Callback.Create(filter);
            return JSRef.Call<Array<T>>("filter", cb);
        }
        public void ForEach(Action<T> fn)
        {
            using var cb = Callback.Create(fn);
            JSRef.CallVoid("forEach", cb);
        }
    }
}
