using System.Reflection;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Extension methods for Task
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// Returns the result of a Task
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task<object?> GetResult(this Task _this)
        {
            await _this;
            var typeofTask = _this.GetType();
            if (!typeofTask.IsGenericType) return null;
            var resultProperty = typeofTask.GetProperty("Result");
            if (resultProperty == null) return null;
            var retValue = resultProperty.GetValue(_this, null);
            return retValue;
        }

        private static async Task<TResult> ConvertTaskObjectTyped<TResult>(Task<object?> task) => (TResult)(await task)!;
        private static async Task ConvertTaskObjectVoid(Task<object?> task) => await task;
        private static Dictionary<Type, MethodInfo?> ConvertTaskObjectTypedCache = new Dictionary<Type, MethodInfo?>();
        private static MethodInfo? ConvertTaskObjectTypedInfo { get; set; }
        /// <summary>
        /// Recasts a Task&lt;object?&gt; to a Task&lt;T&gt; where T is the specified type
        /// </summary>
        /// <param name="task"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object RecastTask(this Task<object?> task, Type type)
        {
            if (type == typeof(void)) return ConvertTaskObjectVoid(task);
            if (!ConvertTaskObjectTypedCache.TryGetValue(type, out MethodInfo? convertTaskObjectTyped))
            {
                ConvertTaskObjectTypedInfo ??= typeof(TaskExtensions).GetMethod(nameof(ConvertTaskObjectTyped), BindingFlags.NonPublic | BindingFlags.Static) ?? throw new Exception($"WorkerServiceProxy static constructor error");
                convertTaskObjectTyped = ConvertTaskObjectTypedInfo!.MakeGenericMethod(type);
                ConvertTaskObjectTypedCache[type] = convertTaskObjectTyped;
            }
            return convertTaskObjectTyped!.Invoke(null, new object?[] { task })!;
        }

        private static async ValueTask<TResult> ConvertTaskObjectTypedValueTask<TResult>(Task<object?> task) => (TResult)(await task)!;
        private static async ValueTask ConvertTaskObjectTypedValueTaskVoid(Task<object?> task) => await task;
        private static Dictionary<Type, MethodInfo?> ConvertTaskObjectTypedValueTaskCache = new Dictionary<Type, MethodInfo?>();
        private static MethodInfo? ConvertTaskObjectTypedValueTaskInfo { get; set; }
        /// <summary>
        /// Recasts a Task&lt;object?&gt; to a ValueTask&lt;T&gt; where T is the specified type
        /// </summary>
        /// <param name="task"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object? RecastValueTask(this Task<object?> task, Type type)
        {
            if (type == typeof(void)) return ConvertTaskObjectTypedValueTaskVoid(task);
            if (!ConvertTaskObjectTypedValueTaskCache.TryGetValue(type, out MethodInfo? convertTaskObjectTyped))
            {
                ConvertTaskObjectTypedValueTaskInfo ??= typeof(TaskExtensions).GetMethod(nameof(ConvertTaskObjectTypedValueTask), BindingFlags.NonPublic | BindingFlags.Static) ?? throw new Exception($"WorkerServiceProxy static constructor error");
                convertTaskObjectTyped = ConvertTaskObjectTypedValueTaskInfo!.MakeGenericMethod(type);
                ConvertTaskObjectTypedValueTaskCache[type] = convertTaskObjectTyped;
            }
            return convertTaskObjectTyped!.Invoke(null, new object?[] { task });
        }
    }
}
