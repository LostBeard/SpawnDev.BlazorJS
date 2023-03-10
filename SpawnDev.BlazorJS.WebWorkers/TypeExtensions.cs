using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.WebWorkers {
    public static class TypeExtensions {
        public static bool IsAsync(this Type type) => type.IsTask() || type.IsValueTask();

        public static Type? AsyncReturnType(this Type type) => type.IsAsync() ? type.GetGenericArguments().FirstOrDefault() ?? typeof(void) : null;

        public static bool IsTask(this Type type) => typeof(Task).IsAssignableFrom(type);

        public static bool IsValueTask(this Type type) => typeof(ValueTask).IsAssignableFrom(type) || typeof(ValueTask<>).GetGenericTypeDefinition() == typeof(ValueTask<>);
    }
}
