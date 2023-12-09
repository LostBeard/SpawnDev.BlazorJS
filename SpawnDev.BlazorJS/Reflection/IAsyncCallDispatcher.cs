using System.Reflection;

namespace SpawnDev.BlazorJS.Reflection
{
    public interface IAsyncCallDispatcher
    {
        Task<object?> Call(MethodInfo methodInfo, object?[]? args = null);
    }
}
