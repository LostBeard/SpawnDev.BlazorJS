using Microsoft.JSInterop;
using System.Collections;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Array object, as with arrays in other programming languages, enables storing a collection of multiple items under a single variable name, and has members for performing common array operations.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array
    /// </summary>
    public class Array : JSObject
    {
        #region Enumerable like
        /// <summary>
        /// Returns first or default
        /// </summary>
        /// <returns></returns>
        public T FirstOrDefault<T>() => Length > 0 ? GetItem<T>(0) : default(T)!;
        /// <summary>
        /// Returns last or default
        /// </summary>
        /// <returns></returns>
        public T LastOrDefault<T>() => Length > 0 ? GetItem<T>(Length - 1) : default(T)!;
        /// <summary>
        /// Returns the array as a .Net List
        /// </summary>
        /// <returns></returns>
        public List<T> ToList<T>() => ToArray<T>().ToList();
        /// <summary>
        /// Returns the array as a .Net Array
        /// </summary>
        /// <returns></returns>
        public T[] ToArray<T>() => JSRef!.As<T[]>();
        /// <summary>
        /// Returns the array as a .Net Array
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public T[] ToArray<T>(int start, int count) => Enumerable.Range(start, count).Select(i => At<T>(i)).ToArray();
        /// <summary>
        /// Returns the array as a .Net List
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<T> ToList<T>(int start, int count) => Enumerable.Range(start, count).Select(i => At<T>(i)).ToList();
        #endregion
        /// <summary>
        /// Returns true if the argument is an array, or false otherwise.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsArray(object? obj) => JS.Call<bool>("Array.isArray", obj);
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
        /// The Array.of() static method creates a new Array instance from a variable number of arguments, regardless of number or type of the arguments.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Array Of(params object[] values) => new Array(values);
        /// <summary>
        /// Reflects the number of elements in an array.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// Adds one or more elements to the end of an array, and returns the new length of the array.
        /// </summary>
        /// <param name="value"></param>
        public void Push(object? value) => JSRef!.CallVoid("push", value);
        /// <summary>
        /// Adds one or more elements to the front of an array, and returns the new length of the array.
        /// </summary>
        /// <param name="value"></param>
        public void Unshift(object? value) => JSRef!.CallVoid("unshift", value);
        /// <summary>
        /// Returns the array item at the given index. Accepts negative integers, which count back from the last item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <returns></returns>
        public T At<T>(int index) => JSRef!.Call<T>("at", index);
        /// <summary>
        /// Returns the array item at the given index. Accepts negative integers, which count back from the last item.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public object? At(Type type, int index) => JSRef!.Call(type, "at", index);
        /// <summary>
        /// Removes the last element from an array and returns that element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Pop<T>() => JSRef!.Call<T>("pop");
        /// <summary>
        /// Removes the last element from an array and returns that element.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object? Pop(Type type) => JSRef!.Call(type, "pop");
        /// <summary>
        /// Removes the first element from an array and returns that element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Shift<T>() => JSRef!.Call<T>("shift");
        /// <summary>
        /// Removes the first element from an array and returns that element.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object? Shift(Type type) => JSRef!.Call(type, "shift");
        /// <summary>
        /// Set the value of the item at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetItem(int index, object? value) => JSRef!.Set(index, value);
        /// <summary>
        /// Returns the array item at the given index. Returns default TArrayItem for negative numbers (unlike at())
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetItem<T>(int index) => JSRef!.Get<T>(index);
        /// <summary>
        /// Returns the array item at the given index. Returns default TArrayItem for negative numbers (unlike at())
        /// </summary>
        /// <param name="type"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public object? GetItem(Type type, int index) => JSRef!.Get(type, index);
        /// <summary>
        /// Returns a new array that is the calling array joined with other array(s) and/or value(s).
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public Array Concat(Array array) => JSRef!.Call<Array>("concat", array);
        /// <summary>
        /// Returns a new array that is the calling array joined with other array(s) and/or value(s).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public Array<T> Concat<T>(Array array) => JSRef!.Call<Array<T>>("concat", array);
        /// <summary>
        /// Joins all elements of an array into a string.
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        public string Join(string separator = "") => JSRef!.Call<string>("join", separator);
        /// <summary>
        /// Returns a new array containing the results of invoking a function on every element in the calling array.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <returns></returns>
        public Array<TResult> Map<TResult>(Function function) => JSRef!.Call<Array<TResult>>("map", function);
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
            return JSRef!.Call<Array<TResult>>("map", cb);
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
            return JSRef!.Call<Array<T>>("filter", cb);
        }
        /// <summary>
        /// Extracts a section of the calling array and returns a new array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>A new array containing the extracted elements.</returns>
        public Array<T> Slice<T>() => JSRef!.Call<Array<T>>("slice");
        /// <summary>
        /// Extracts a section of the calling array and returns a new array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start">
        /// Zero-based index at which to start extraction, converted to an integer.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= start &lt; 0, start + array.length is used.<br/>
        /// - If start &lt; -array.length or start is omitted, 0 is used.<br/>
        /// - If start &gt;= array.length, nothing is extracted.
        /// </param>
        /// <returns>A new array containing the extracted elements.</returns>
        public Array<T> Slice<T>(int start) => JSRef!.Call<Array<T>>("slice", start);
        /// <summary>
        /// Extracts a section of the calling array and returns a new array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start">
        /// Zero-based index at which to start extraction, converted to an integer.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= start &lt; 0, start + array.length is used.<br/>
        /// - If start &lt; -array.length or start is omitted, 0 is used.<br/>
        /// - If start &gt;= array.length, nothing is extracted.
        /// </param>
        /// <param name="end">
        /// Zero-based index at which to end extraction, converted to an integer. slice() extracts up to but not including end.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= end &lt; 0, end + array.length is used.<br/>
        /// - If end &lt; -array.length, 0 is used.<br/>
        /// - If end &gt;= array.length or end is omitted, array.length is used, causing all elements until the end to be extracted.<br/>
        /// - If end implies a position before or at the position that start implies, nothing is extracted.<br/>
        /// </param>
        /// <returns>A new array containing the extracted elements.</returns>
        public Array<T> Slice<T>(int start, int end) => JSRef!.Call<Array<T>>("slice", start, end);
        /// <summary>
        /// Extracts a section of the calling array and returns a new array.
        /// </summary>
        /// <returns>A new array containing the extracted elements.</returns>
        public virtual Array Slice() => JSRef!.Call<Array>("slice");
        /// <summary>
        /// Extracts a section of the calling array and returns a new array.
        /// </summary>
        /// <param name="start">
        /// Zero-based index at which to start extraction, converted to an integer.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= start &lt; 0, start + array.length is used.<br/>
        /// - If start &lt; -array.length or start is omitted, 0 is used.<br/>
        /// - If start &gt;= array.length, nothing is extracted.
        /// </param>
        /// <returns>A new array containing the extracted elements.</returns>
        public virtual Array Slice(int start) => JSRef!.Call<Array>("slice", start);
        /// <summary>
        /// Extracts a section of the calling array and returns a new array.
        /// </summary>
        /// <param name="start">
        /// Zero-based index at which to start extraction, converted to an integer.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= start &lt; 0, start + array.length is used.<br/>
        /// - If start &lt; -array.length or start is omitted, 0 is used.<br/>
        /// - If start &gt;= array.length, nothing is extracted.
        /// </param>
        /// <param name="end">
        /// Zero-based index at which to end extraction, converted to an integer. slice() extracts up to but not including end.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= end &lt; 0, end + array.length is used.<br/>
        /// - If end &lt; -array.length, 0 is used.<br/>
        /// - If end &gt;= array.length or end is omitted, array.length is used, causing all elements until the end to be extracted.<br/>
        /// - If end implies a position before or at the position that start implies, nothing is extracted.<br/>
        /// </param>
        /// <returns>A new array containing the extracted elements.</returns>
        public virtual Array Slice(int start, int end) => JSRef!.Call<Array>("slice", start, end);
        /// <summary>
        /// Calls a function for each element in the calling array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mapTo"></param>
        public void ForEach<T>(Action<T> mapTo)
        {
            using var cb = Callback.Create(mapTo);
            JSRef!.CallVoid("forEach", cb);
        }
        /// <summary>
        /// Return a new reference to this array with an item type of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="disposeThis">If true, this Array JSObject will be disposed after the new cast</param>
        /// <returns></returns>
        public Array<T> Cast<T>(bool disposeThis = false) => disposeThis ? JSRefMove<Array<T>>() : JSRefCopy<Array<T>>();
        /// <summary>
        /// Return a new generic reference to this array
        /// </summary>        
        /// <param name="disposeThis">If true, this Array JSObject will be disposed after the new cast</param>
        /// <returns></returns>
        public Array Cast(bool disposeThis = false) => disposeThis ? JSRefMove<Array>() : JSRefCopy<Array>();
        /// <summary>
        /// Adds and/or removes elements from an array.
        /// </summary>
        /// <param name="start">
        /// Zero-based index at which to start changing the array, converted to an integer.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= start &lt; 0, start + array.length is used.<br/>
        /// - If start &lt; -array.length, 0 is used.<br/>
        /// - If start &gt;= array.length, no element will be deleted, but the method will behave as an adding function, adding as many elements as provided.<br/>
        /// - If start is omitted (and splice() is called with no arguments), nothing is deleted. This is different from passing undefined, which is converted to 0.<br/>
        /// </param>
        /// <returns></returns>
        public virtual Array Splice(int start) => JSRef!.Call<Array>("splice", start);
        /// <summary>
        /// Adds and/or removes elements from an array.
        /// </summary>
        /// <param name="start">
        /// Zero-based index at which to start changing the array, converted to an integer.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= start &lt; 0, start + array.length is used.<br/>
        /// - If start &lt; -array.length, 0 is used.<br/>
        /// - If start &gt;= array.length, no element will be deleted, but the method will behave as an adding function, adding as many elements as provided.<br/>
        /// - If start is omitted (and splice() is called with no arguments), nothing is deleted. This is different from passing undefined, which is converted to 0.<br/>
        /// </param>
        /// <param name="deleteCount">
        /// An integer indicating the number of elements in the array to remove from start.<rb />
        /// - If deleteCount is omitted, or if its value is greater than or equal to the number of elements after the position specified by start, then all the elements from start to the end of the array will be deleted. However, if you wish to pass any itemN parameter, you should pass Infinity as deleteCount to delete all elements after start, because an explicit undefined gets converted to 0.<br/>
        /// - If deleteCount is 0 or negative, no elements are removed. In this case, you should specify at least one new element (see below).
        /// </param>
        /// <returns></returns>
        public virtual Array Splice(int start, int deleteCount) => JSRef!.Call<Array>("splice", start, deleteCount);
        /// <summary>
        /// Adds and/or removes elements from an array.
        /// </summary>
        /// <param name="start">
        /// Zero-based index at which to start changing the array, converted to an integer.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= start &lt; 0, start + array.length is used.<br/>
        /// - If start &lt; -array.length, 0 is used.<br/>
        /// - If start &gt;= array.length, no element will be deleted, but the method will behave as an adding function, adding as many elements as provided.<br/>
        /// - If start is omitted (and splice() is called with no arguments), nothing is deleted. This is different from passing undefined, which is converted to 0.<br/>
        /// </param>
        /// <param name="deleteCount">
        /// An integer indicating the number of elements in the array to remove from start.<rb />
        /// - If deleteCount is omitted, or if its value is greater than or equal to the number of elements after the position specified by start, then all the elements from start to the end of the array will be deleted. However, if you wish to pass any itemN parameter, you should pass Infinity as deleteCount to delete all elements after start, because an explicit undefined gets converted to 0.<br/>
        /// - If deleteCount is 0 or negative, no elements are removed. In this case, you should specify at least one new element (see below).
        /// </param>
        /// <param name="addItems">The elements to add to the array, beginning from start. If you do not specify any elements, splice() will only remove elements from the array.</param>
        /// <returns></returns>
        public Array Splice(int start, int deleteCount, object?[] addItems) => JSRef!.CallApply<Array>("splice", new object[] { start, deleteCount }.Concat(addItems.Select(o => (object?)o)).ToArray());
        /// <summary>
        /// Adds and/or removes elements from an array.
        /// </summary>
        /// <param name="start">
        /// Zero-based index at which to start changing the array, converted to an integer.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= start &lt; 0, start + array.length is used.<br/>
        /// - If start &lt; -array.length, 0 is used.<br/>
        /// - If start &gt;= array.length, no element will be deleted, but the method will behave as an adding function, adding as many elements as provided.<br/>
        /// - If start is omitted (and splice() is called with no arguments), nothing is deleted. This is different from passing undefined, which is converted to 0.<br/>
        /// </param>
        /// <returns></returns>
        public Array<T> Splice<T>(int start) => JSRef!.Call<Array<T>>("splice", start);
        /// <summary>
        /// Adds and/or removes elements from an array.
        /// </summary>
        /// <param name="start">
        /// Zero-based index at which to start changing the array, converted to an integer.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= start &lt; 0, start + array.length is used.<br/>
        /// - If start &lt; -array.length, 0 is used.<br/>
        /// - If start &gt;= array.length, no element will be deleted, but the method will behave as an adding function, adding as many elements as provided.<br/>
        /// - If start is omitted (and splice() is called with no arguments), nothing is deleted. This is different from passing undefined, which is converted to 0.<br/>
        /// </param>
        /// <param name="deleteCount">
        /// An integer indicating the number of elements in the array to remove from start.<rb />
        /// - If deleteCount is omitted, or if its value is greater than or equal to the number of elements after the position specified by start, then all the elements from start to the end of the array will be deleted. However, if you wish to pass any itemN parameter, you should pass Infinity as deleteCount to delete all elements after start, because an explicit undefined gets converted to 0.<br/>
        /// - If deleteCount is 0 or negative, no elements are removed. In this case, you should specify at least one new element (see below).
        /// </param>
        /// <returns></returns>
        public Array<T> Splice<T>(int start, int deleteCount) => JSRef!.Call<Array<T>>("splice", start, deleteCount);
        /// <summary>
        /// Adds and/or removes elements from an array.
        /// </summary>
        /// <param name="start">
        /// Zero-based index at which to start changing the array, converted to an integer.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= start &lt; 0, start + array.length is used.<br/>
        /// - If start &lt; -array.length, 0 is used.<br/>
        /// - If start &gt;= array.length, no element will be deleted, but the method will behave as an adding function, adding as many elements as provided.<br/>
        /// - If start is omitted (and splice() is called with no arguments), nothing is deleted. This is different from passing undefined, which is converted to 0.<br/>
        /// </param>
        /// <param name="deleteCount">
        /// An integer indicating the number of elements in the array to remove from start.<rb />
        /// - If deleteCount is omitted, or if its value is greater than or equal to the number of elements after the position specified by start, then all the elements from start to the end of the array will be deleted. However, if you wish to pass any itemN parameter, you should pass Infinity as deleteCount to delete all elements after start, because an explicit undefined gets converted to 0.<br/>
        /// - If deleteCount is 0 or negative, no elements are removed. In this case, you should specify at least one new element (see below).
        /// </param>
        /// <param name="addItems">The elements to add to the array, beginning from start. If you do not specify any elements, splice() will only remove elements from the array.</param>
        /// <returns></returns>
        public Array<T> Splice<T>(int start, int deleteCount, T[] addItems) => JSRef!.CallApply<Array<T>>("splice", new object[] { start, deleteCount }.Concat(addItems.Select(o => (object?)o)).ToArray()); /// <summary>
        /// Sorts the elements of an array in place and returns the reference to the same array, now sorted. The default sort order is ascending, built upon converting the elements into strings, then comparing their sequences of UTF-16 code units values.
        /// </summary>
        /// <param name="compareFn">
        /// A function that determines the order of the elements. The function is called with the following arguments:<br/>
        /// a - The first element for comparison.<br/>
        /// b - The second element for comparison.<br/>
        /// It should return a number where:<br/>
        /// - A negative value indicates that a should come before b.<br/>
        /// - A positive value indicates that a should come after b.<br/>
        /// - Zero or NaN indicates that a and b are considered equal.<br/>
        /// To memorize this, remember that (a, b) => a - b sorts numbers in ascending order.<br/>
        /// If omitted, the array elements are converted to strings, then sorted according to each character's Unicode code point value.
        /// </param>
        /// <returns>This Array instance</returns>
        public Array Sort<T>(Func<T, T, int> compareFn)
        {
            using var cb = Callback.Create(compareFn);
            JSRef!.CallVoid("sort", cb);
            return this;
        }
    }
    /// <summary>
    /// The Array object, as with arrays in other programming languages, enables storing a collection of multiple items under a single variable name, and has members for performing common array operations.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array
    /// </summary>
    public class Array<TArrayItem> : Array, IEnumerable<TArrayItem>
    {
        #region IEnumerable
        /// <inheritdoc/>
        public IEnumerator<TArrayItem> GetEnumerator() => new SimpleEnumerator<TArrayItem>((i) => GetItem(i), () => Length);
        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
        /// <summary>
        /// Explicit cast to .Net array
        /// </summary>
        /// <param name="array"></param>
        public static explicit operator TArrayItem[]?(Array<TArrayItem>? array) => array == null ? null : array.ToArray();
        /// <summary>
        /// Explicit cast to .Net List
        /// </summary>
        public static explicit operator List<TArrayItem>?(Array<TArrayItem>? array) => array == null ? null : array.ToList();
        #region Enumerable like
        /// <summary>
        /// Returns first or default
        /// </summary>
        /// <returns></returns>
        public TArrayItem FirstOrDefault() => Length > 0 ? At(0) : default(TArrayItem)!;
        /// <summary>
        /// Returns last or default
        /// </summary>
        /// <returns></returns>
        public TArrayItem LastOrDefault() => Length > 0 ? At(Length - 1) : default(TArrayItem)!;
        /// <summary>
        /// Returns the array as a .Net List
        /// </summary>
        /// <returns></returns>
        public List<TArrayItem> ToList() => ToArray().ToList();
        /// <summary>
        /// Returns the array as a .Net Array
        /// </summary>
        /// <returns></returns>
        public TArrayItem[] ToArray() => JSRef!.As<TArrayItem[]>();
        /// <summary>
        /// Returns the array as a .Net Array
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public TArrayItem[] ToArray(int start, int count) => Enumerable.Range(start, count).Select(i => At(i)).ToArray();
        /// <summary>
        /// Returns the array as a .Net List
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<TArrayItem> ToList(int start, int count) => Enumerable.Range(start, count).Select(i => At(i)).ToList();
        #endregion
        /// <summary>
        /// Returns the array item at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>TArrayItem</returns>
        public TArrayItem this[int index]
        {
            get => GetItem(index);
            set => SetItem(index, value);
        }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The Array() constructor creates Array objects.
        /// </summary>
        public Array() : base(JS.New(nameof(Array))) { }
        /// <summary>
        /// The Array() constructor creates Array objects.
        /// </summary>
        /// <param name="length">If the only argument passed to the Array constructor is an integer between 0 and 232 - 1 (inclusive), this returns a new JavaScript array with its length property set to that number (Note: this implies an array of arrayLength empty slots, not slots with actual undefined values — see sparse arrays).</param>
        public Array(uint length) : base(JS.New(nameof(Array), length)) { }
        /// <summary>
        /// The Array() constructor creates Array objects.
        /// </summary>
        /// <param name="values">A JavaScript array is initialized with the given elements, except in the case where a single argument is passed to the Array constructor and that argument is a number (see the arrayLength parameter below). Note that this special case only applies to JavaScript arrays created with the Array constructor, not array literals created with the square bracket syntax.</param>
        public Array(params TArrayItem[] values) : base(JS.NewApply(nameof(Array), values == null ? null : values.Select(o => (object?)o).ToArray())) { }
        /// <summary>
        /// The Array.of() static method creates a new Array instance from a variable number of arguments, regardless of number or type of the arguments.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Array Of(params TArrayItem[] values) => new Array(values);
        /// <summary>
        /// Adds one or more elements to the end of an array, and returns the new length of the array.
        /// </summary>
        /// <param name="value"></param>
        public void Push(TArrayItem value) => JSRef!.CallVoid("push", value);
        /// <summary>
        /// Adds one or more elements to the front of an array, and returns the new length of the array.
        /// </summary>
        /// <param name="value"></param>
        public void Unshift(TArrayItem value) => JSRef!.CallVoid("unshift", value);
        /// <summary>
        /// Returns the array item at the given index. Accepts negative integers, which count back from the last item.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TArrayItem At(int index) => JSRef!.Call<TArrayItem>("at", index);
        /// <summary>
        /// Removes the last element from an array and returns that element.
        /// </summary>
        /// <returns></returns>
        public TArrayItem Pop() => JSRef!.Call<TArrayItem>("pop");
        /// <summary>
        /// Removes the first element from an array and returns that element.
        /// </summary>
        /// <returns></returns>
        public TArrayItem Shift() => JSRef!.Call<TArrayItem>("shift");
        /// <summary>
        /// Set the value at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetItem(int index, TArrayItem value) => JSRef!.Set(index, value);
        /// <summary>
        /// Returns the array item at the given index. Returns default TArrayItem for negative numbers (unlike at())
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TArrayItem GetItem(int index) => JSRef!.Get<TArrayItem>(index);
        /// <summary>
        /// Returns a new array that is the calling array joined with other array(s) and/or value(s).
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public Array<TArrayItem> Concat(Array<TArrayItem> array) => JSRef!.Call<Array<TArrayItem>>("concat", array);
        /// <summary>
        /// Returns a new array containing the results of invoking a function on every element in the calling array.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="mapTo"></param>
        /// <returns></returns>
        public Array<TResult> Map<TResult>(Func<TArrayItem, TResult> mapTo)
        {
            using var cb = Callback.Create(mapTo);
            return JSRef!.Call<Array<TResult>>("map", cb);
        }
        /// <summary>
        /// Returns a new array containing all elements of the calling array for which the provided filtering function returns true.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Array<TArrayItem> Filter(Func<TArrayItem, bool> filter)
        {
            using var cb = Callback.Create(filter);
            return JSRef!.Call<Array<TArrayItem>>("filter", cb);
        }
        /// <summary>
        /// Extracts a section of the calling array and returns a new array.
        /// </summary>
        /// <returns>A new array containing the extracted elements.</returns>
        public override Array<TArrayItem> Slice() => JSRef!.Call<Array<TArrayItem>>("slice");
        /// <summary>
        /// Extracts a section of the calling array and returns a new array.
        /// </summary>
        /// <param name="start">
        /// Zero-based index at which to start extraction, converted to an integer.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= start &lt; 0, start + array.length is used.<br/>
        /// - If start &lt; -array.length or start is omitted, 0 is used.<br/>
        /// - If start &gt;= array.length, nothing is extracted.
        /// </param>
        /// <returns>A new array containing the extracted elements.</returns>
        public override Array<TArrayItem> Slice(int start) => JSRef!.Call<Array<TArrayItem>>("slice", start);
        /// <summary>
        /// Extracts a section of the calling array and returns a new array.
        /// </summary>
        /// <param name="start">
        /// Zero-based index at which to start extraction, converted to an integer.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= start &lt; 0, start + array.length is used.<br/>
        /// - If start &lt; -array.length or start is omitted, 0 is used.<br/>
        /// - If start &gt;= array.length, nothing is extracted.
        /// </param>
        /// <param name="end">
        /// Zero-based index at which to end extraction, converted to an integer. slice() extracts up to but not including end.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= end &lt; 0, end + array.length is used.<br/>
        /// - If end &lt; -array.length, 0 is used.<br/>
        /// - If end &gt;= array.length or end is omitted, array.length is used, causing all elements until the end to be extracted.<br/>
        /// - If end implies a position before or at the position that start implies, nothing is extracted.<br/>
        /// </param>
        /// <returns>A new array containing the extracted elements.</returns>
        public override Array<TArrayItem> Slice(int start, int end) => JSRef!.Call<Array<TArrayItem>>("slice", start, end);
        /// <summary>
        /// Adds and/or removes elements from an array.
        /// </summary>
        /// <param name="start">
        /// Zero-based index at which to start changing the array, converted to an integer.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= start &lt; 0, start + array.length is used.<br/>
        /// - If start &lt; -array.length, 0 is used.<br/>
        /// - If start &gt;= array.length, no element will be deleted, but the method will behave as an adding function, adding as many elements as provided.<br/>
        /// - If start is omitted (and splice() is called with no arguments), nothing is deleted. This is different from passing undefined, which is converted to 0.<br/>
        /// </param>
        /// <returns></returns>
        public override Array<TArrayItem> Splice(int start) => JSRef!.Call<Array<TArrayItem>>("splice", start);
        /// <summary>
        /// Adds and/or removes elements from an array.
        /// </summary>
        /// <param name="start">
        /// Zero-based index at which to start changing the array, converted to an integer.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= start &lt; 0, start + array.length is used.<br/>
        /// - If start &lt; -array.length, 0 is used.<br/>
        /// - If start &gt;= array.length, no element will be deleted, but the method will behave as an adding function, adding as many elements as provided.<br/>
        /// - If start is omitted (and splice() is called with no arguments), nothing is deleted. This is different from passing undefined, which is converted to 0.<br/>
        /// </param>
        /// <param name="deleteCount">
        /// An integer indicating the number of elements in the array to remove from start.<rb />
        /// - If deleteCount is omitted, or if its value is greater than or equal to the number of elements after the position specified by start, then all the elements from start to the end of the array will be deleted. However, if you wish to pass any itemN parameter, you should pass Infinity as deleteCount to delete all elements after start, because an explicit undefined gets converted to 0.<br/>
        /// - If deleteCount is 0 or negative, no elements are removed. In this case, you should specify at least one new element (see below).
        /// </param>
        /// <returns></returns>
        public override Array<TArrayItem> Splice(int start, int deleteCount) => JSRef!.Call<Array<TArrayItem>>("splice", start, deleteCount);
        /// <summary>
        /// Adds and/or removes elements from an array.
        /// </summary>
        /// <param name="start">
        /// Zero-based index at which to start changing the array, converted to an integer.<br/>
        /// - Negative index counts back from the end of the array — if -array.length &lt;= start &lt; 0, start + array.length is used.<br/>
        /// - If start &lt; -array.length, 0 is used.<br/>
        /// - If start &gt;= array.length, no element will be deleted, but the method will behave as an adding function, adding as many elements as provided.<br/>
        /// - If start is omitted (and splice() is called with no arguments), nothing is deleted. This is different from passing undefined, which is converted to 0.<br/>
        /// </param>
        /// <param name="deleteCount">
        /// An integer indicating the number of elements in the array to remove from start.<rb />
        /// - If deleteCount is omitted, or if its value is greater than or equal to the number of elements after the position specified by start, then all the elements from start to the end of the array will be deleted. However, if you wish to pass any itemN parameter, you should pass Infinity as deleteCount to delete all elements after start, because an explicit undefined gets converted to 0.<br/>
        /// - If deleteCount is 0 or negative, no elements are removed. In this case, you should specify at least one new element (see below).
        /// </param>
        /// <param name="addItems">The elements to add to the array, beginning from start. If you do not specify any elements, splice() will only remove elements from the array.</param>
        /// <returns></returns>
        public Array<TArrayItem> Splice(int start, int deleteCount, TArrayItem[] addItems) => JSRef!.CallApply<Array<TArrayItem>>("splice", new object[] { start, deleteCount }.Concat(addItems.Select(o => (object?)o)).ToArray());
        /// <summary>
        /// Calls a function for each element in the calling array.
        /// </summary>
        /// <param name="fn"></param>
        public void ForEach(Action<TArrayItem> fn)
        {
            using var cb = Callback.Create(fn);
            JSRef!.CallVoid("forEach", cb);
        }
        /// <summary>
        /// Sorts the elements of an array in place and returns the reference to the same array, now sorted. The default sort order is ascending, built upon converting the elements into strings, then comparing their sequences of UTF-16 code units values.
        /// </summary>
        /// <param name="compareFn">
        /// A function that determines the order of the elements. The function is called with the following arguments:<br/>
        /// a - The first element for comparison.<br/>
        /// b - The second element for comparison.<br/>
        /// It should return a number where:<br/>
        /// - A negative value indicates that a should come before b.<br/>
        /// - A positive value indicates that a should come after b.<br/>
        /// - Zero or NaN indicates that a and b are considered equal.<br/>
        /// To memorize this, remember that (a, b) => a - b sorts numbers in ascending order.<br/>
        /// If omitted, the array elements are converted to strings, then sorted according to each character's Unicode code point value.
        /// </param>
        /// <returns>This Array instance</returns>
        public Array<TArrayItem> Sort(Func<TArrayItem, TArrayItem, int> compareFn)
        {
            using var cb = Callback.Create(compareFn);
            JSRef!.CallVoid("sort", cb);
            return this;
        }
    }
}
