using System.Reflection;

namespace SpawnDev.BlazorJS.Reflection
{
    public interface ICallDispatcher
    {
        Task<object?> DispatchCall(MethodInfo methodInfo, object?[]? args = null);
    }
}
