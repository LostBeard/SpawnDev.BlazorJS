using System.Runtime.CompilerServices;

namespace SpawnDev.BlazorJS
{
    public static class IEnumerableExtensions
    {
        #region Array
        /// <summary>
        /// Dispose all of the IDisposable object in the array
        /// </summary>
        /// <param name="target"></param>
        public static void DisposeAll(this IDisposable[] target)
        {
            foreach (var item in target) item?.Dispose();
        }
        /// <summary>
        /// Dispose all of the IDisposable object in the array
        /// </summary>
        /// <param name="target"></param>
        public static void Using<T>(this T[] target) where T : IDisposable
        {
            foreach (var item in target) item?.Dispose();
        }
        /// <summary>
        /// Iterate an array of IDisposable, disposing all when done
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        public static void UsingEach<T>(this T[] target, Action<T> use) where T : IDisposable
        {
            try
            {
                foreach (var item in target) use(item);
            }
            finally
            {
                foreach (var item in target) item?.Dispose();
            }
        }
        /// <summary>
        /// Iterate an array of IDisposable, disposing all when done
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        public static async Task  UsingEachAsync<T>(this T[] target, Func<T, Task> use) where T : IDisposable
        {
            try
            {
                foreach (var item in target) await use(item);
            }
            finally
            {
                foreach (var item in target) item?.Dispose();
            }
        }
        /// <summary>
        /// Iterate the disposable items, returning true to keep items, and false to dispose and discard
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        public static List<T> UsingWhere<T>(this T[] target, Func<T, bool> use) where T : IDisposable
        {
            var ret = new List<T>();
            try
            {
                foreach (var item in target)
                {
                    if (use(item)) ret.Add(item);
                }
                return ret;
            }
            finally
            {
                foreach (var item in target)
                {
                    if (!ret.Contains(item)) item?.Dispose();
                }
            }
        }
        /// <summary>
        /// Iterate the disposable items, returning true to keep items, and false to dispose and discard
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        /// <returns></returns>
        public static async Task<List<T>> UsingWhereAsync<T>(this T[] target, Func<T, Task<bool>> use) where T : IDisposable
        {
            var ret = new List<T>();
            try
            {
                foreach (var item in target)
                {
                    if (await use(item)) ret.Add(item);
                }
                return ret;
            }
            finally
            {
                foreach (var item in target)
                {
                    if (!ret.Contains(item)) item?.Dispose();
                }
            }
        }
        /// <summary>
        /// Use an array of IDisposable that will be disposed when done
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        public static void Using<T>(this T[] target, Action<T[]> use) where T : IDisposable
        {
            try
            {
                use(target);
            }
            finally
            {
                foreach (var item in target) item?.Dispose();
            }
        }
        /// <summary>
        /// Use an array of IDisposable that will be disposed when done
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        /// <returns></returns>
        public static async Task UsingAsync<T>(this T[] target, Func<T[], Task> use) where T : IDisposable
        {
            try
            {
                await use(target);
            }
            finally
            {
                foreach (var item in target) item?.Dispose();
            }
        }
        /// <summary>
        /// Use an array of IDisposable, returning a value before the array items are disposed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        public static TResult Using<T, TResult>(this T[] target, Func<T[], TResult> use) where T : IDisposable
        {
            try
            {
                return use(target);
            }
            finally
            {
                foreach (var item in target) item?.Dispose();
            }
        }
        /// <summary>
        /// Use an array of IDisposable, returning a value before the array items are disposed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        /// <returns></returns>
        public static async Task<TResult> UsingAsync<T, TResult>(this T[] target, Func<T[], Task<TResult>> use) where T : IDisposable
        {
            try
            {
                return await use(target);
            }
            finally
            {
                foreach (var item in target) item?.Dispose();
            }
        }
        #endregion
        #region List
        /// <summary>
        /// Dispose all of the IDisposable object in the List
        /// </summary>
        /// <param name="target"></param>
        public static void DisposeAll(this List<IDisposable> target)
        {
            foreach (var item in target) item?.Dispose();
        }
        /// <summary>
        /// Dispose all of the IDisposable object in the List
        /// </summary>
        /// <param name="target"></param>
        public static void Using<T>(this List<T> target) where T : IDisposable
        {
            foreach (var item in target) item?.Dispose();
        }
        /// <summary>
        /// Iterate an array of IDisposable, disposing all when done
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        public static void UsingEach<T>(this List<T> target, Action<T> use) where T : IDisposable
        {
            try
            {
                foreach (var item in target)
                {
                    use(item);
                }
            }
            finally
            {
                foreach (var item in target)
                {
                    item?.Dispose();
                }
            }
        }
        /// <summary>
        /// Iterate an array of IDisposable, disposing all when done
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        /// <returns></returns>
        public static async Task UsingEachAsync<T>(this List<T> target, Func<T, Task> use) where T : IDisposable
        {
            try
            {
                foreach (var item in target)
                {
                    await use(item);
                }
            }
            finally
            {
                foreach (var item in target)
                {
                    item?.Dispose();
                }
            }
        }
        /// <summary>
        /// Iterate the disposable items, returning true to keep items, and false to dispose and discard
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        public static List<T> UsingWhere<T>(this List<T> target, Func<T, bool> use) where T : IDisposable
        {
            var ret = new List<T>();
            try
            {
                foreach (var item in target)
                {
                    if (use(item)) ret.Add(item);
                }
                return ret;
            }
            finally
            {
                foreach (var item in target)
                {
                    if (!ret.Contains(item)) item?.Dispose();
                }
            }
        }
        /// <summary>
        /// Iterate the disposable items, returning true to keep items, and false to dispose and discard
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        /// <returns></returns>
        public static async Task<List<T>> UsingWhereAsync<T>(this List<T> target, Func<T, Task<bool>> use) where T : IDisposable
        {
            var ret = new List<T>();
            try
            {
                foreach (var item in target)
                {
                    if (await use(item)) ret.Add(item);
                }
                return ret;
            }
            finally
            {
                foreach (var item in target)
                {
                    if (!ret.Contains(item)) item?.Dispose();
                }
            }
        }
        /// <summary>
        /// Use an array of IDisposable that will be disposed when done
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        public static void Using<T>(this List<T> target, Action<List<T>> use) where T : IDisposable
        {
            try
            {
                use(target);
            }
            finally
            {
                foreach (var item in target) item?.Dispose();
            }
        }
        /// <summary>
        /// Use an array of IDisposable that will be disposed when done
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        /// <returns></returns>
        public static async Task UsingAsync<T>(this List<T> target, Func<List<T>, Task> use) where T : IDisposable
        {
            try
            {
                await use(target);
            }
            finally
            {
                foreach (var item in target) item?.Dispose();
            }
        }
        /// <summary>
        /// Use an array of IDisposable and return a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        public static TResult Using<T, TResult>(this List<T> target, Func<List<T>, TResult> use) where T : IDisposable
        {
            try
            {
                return use(target);
            }
            finally
            {
                foreach (var item in target) item?.Dispose();
            }
        }
        /// <summary>
        /// Use an array of IDisposable and return a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="target"></param>
        /// <param name="use"></param>
        /// <returns></returns>
        public static async Task<TResult> UsingAsync<T, TResult>(this List<T> target, Func<List<T>, Task<TResult>> use) where T : IDisposable
        {
            try
            {
                return await use(target);
            }
            finally
            {
                foreach (var item in target) item?.Dispose();
            }
        }
        #endregion
    }
}
