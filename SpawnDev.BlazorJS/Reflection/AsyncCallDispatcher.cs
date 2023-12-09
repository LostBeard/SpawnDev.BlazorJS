using System.Linq.Expressions;
using System.Reflection;

namespace SpawnDev.BlazorJS.Reflection
{
    /// <summary>
    /// AsyncCallDispatcher converts a call into a MethodInfo and an object[] containing the arguments used for the call and asynchronously returns the value<br />
    /// The call is handled by a virtual Method that must be overridden by the inheriting class to be useful.<br />
    /// Usually this is done to allow serializing a call to be carried out elsewhere with the result being returned.<br />
    /// Task&lt;object?&gt; DispatchCall(MethodInfo methodInfo, object?[]? args = null)<br />
    /// Supported calling conventions:<br />
    /// Expressions - Supports generics, property get and set, asynchronous and synchronous method calls. (Recommended)<br />
    /// - Run, Set<br />
    /// Delegates - Supports generics, asynchronous and synchronous method calls.<br />
    /// - Invoke<br />
    /// Interface proxy - Supports generics, and asynchronous method calls. (uses DispatchProxy)<br />
    /// - GetService<br />
    /// Type and Method name - Supports property get and set (using special names), and asynchronous and synchronous method calls. Overloaded methods can cause errors.<br />
    /// - Call<br />
    /// MethodInfo - All calls funnel to this call. Supports generics, property get and set, asynchronous and synchronous method calls.<br />
    /// - Call<br />
    /// </summary>
    public partial class AsyncCallDispatcher : IAsyncCallDispatcher
    {
        /// <summary>
        /// The binding flags to use when searching for methods
        /// </summary>
        protected BindingFlags MethodBindingFlags { get; set; } = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;
        /// <summary>
        /// A debug version of DispatchCall that should be overridden
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual Task<object?> Call(MethodInfo methodInfo, object?[]? args = null)
        {
            var serializedMethodInfo = SerializableMethodInfo.SerializeMethodInfo(methodInfo);
            var argsCount = args == null ? 0 : args.Length;
            Console.WriteLine($"SendCall: {argsCount} {serializedMethodInfo}");
            var mi = SerializableMethodInfo.DeserializeMethodInfo(serializedMethodInfo);
            Console.WriteLine($"SendCall: {(mi == null ? "method NOT FOUND" : "method found")}");
            return Task.FromResult((object)"");
        }

        #region DispatchProxy
        Dictionary<Type, object> ServiceInterfaces = new Dictionary<Type, object>();

        public TServiceInterface GetService<TServiceInterface>() where TServiceInterface : class
        {
            var typeofT = typeof(TServiceInterface);
            if (ServiceInterfaces.TryGetValue(typeofT, out var serviceWorker)) return (TServiceInterface)serviceWorker;
            var ret = InterfaceCallDispatcher<TServiceInterface>.CreateInterfaceDispatcher(this);
            ServiceInterfaces[typeofT] = ret;
            return ret;
        }
        #endregion

        #region Type, Method Name, Argument count
        public Task<object?> Call(Type classType, string methodName, object?[]? args = null)
        {
            var parameterCount = args == null ? 0 : args.Length;
            var instanceMethods = classType.FindAllMethods(methodName, parameterCount, MethodBindingFlags, false);
            if (instanceMethods.Count > 1)
            {
                throw new Exception($"More than one method with the same name and compatible parameter count found: {classType.Name} {methodName} {parameterCount}");
            }
            var methodInfo = instanceMethods.FirstOrDefault();
            if (methodInfo == null)
            {
                throw new Exception($"Method not found: {classType.Name} {methodName} {parameterCount}");
            }
            return Call(methodInfo, args);
        }
        public Task<object?> Call(string className, string methodName, object?[]? args = null)
        {
            var classType = TypeExtensions.GetType(className);
            if (classType == null) throw new Exception($"Class Type not found: {className}");
            return Call(classType, methodName, args);
        }
        public Task<object?> Call<TClass>(string methodName, object?[]? args = null) => Call(typeof(TClass), methodName, args);
        public async Task<TResult> Call<TClass, TResult>(string methodName, object?[]? args = null) => (TResult)await Call(typeof(TClass), methodName, args);
        #endregion

        #region Expressions

        /// <summary>
        /// Converts an Expression into a MethodInfo and a call arguments array<br />
        /// Then calls DispatchCall with them
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="argsExt"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected Task<object?> Call(Expression expr, object?[]? argsExt = null)
        {
            if (expr is MethodCallExpression methodCallExpression)
            {
                var methodInfo = methodCallExpression.Method;
                var args = methodCallExpression.Arguments.Select(arg => Expression.Lambda<Func<object>>(Expression.Convert(arg, typeof(object)), null).Compile()()).ToArray();
                return Call(methodInfo, args);
            }
            else if (expr is MemberExpression memberExpression)
            {
                if (argsExt == null || argsExt.Length == 0)
                {
                    // get call
                    var propertyInfo = (PropertyInfo)memberExpression.Member;
                    var methodInfo = propertyInfo.GetMethod;
                    if (methodInfo == null)
                    {
                        throw new Exception("Property getter does not exist.");
                    }
                    return Call(methodInfo);
                }
                else
                {
                    // set call
                    var propertyInfo = (PropertyInfo)memberExpression.Member;
                    var methodInfo = propertyInfo.SetMethod;
                    if (methodInfo == null)
                    {
                        throw new Exception("Property setter does not exist.");
                    }
                    return Call(methodInfo, argsExt);
                }
            }
            else
            {
                throw new Exception($"Unsupported dispatch call: {expr.GetType().Name}");
            }
        }

        // Static
        // Method Calls and Property Getters
        // Action
        public async Task Run(Expression<Action> expr) => await Call(expr.Body);
        // Func<Task>
        public async Task Run(Expression<Func<Task>> expr) => await Call(expr.Body);
        // Func<ValueTask>
        public async Task Run(Expression<Func<ValueTask>> expr) => await Call(expr.Body);
        // Func<...,TResult>
        public async Task<TResult> Run<TResult>(Expression<Func<TResult>> expr) => (TResult)await Call(expr.Body);
        // Func<...,Task<TResult>>
        public async Task<TResult> Run<TResult>(Expression<Func<Task<TResult>>> expr) => (TResult)await Call(expr.Body);
        // Func<...,ValueTask<TResult>>
        public async Task<TResult> Run<TResult>(Expression<Func<ValueTask<TResult>>> expr) => (TResult)await Call(expr.Body);
        // Property set
        public async Task Set<TProperty>(Expression<Func<TProperty>> expr, TProperty value) => await Call(expr.Body, new object[] { value });

        // Instance
        // Method Calls and Property Getters
        // Action
        public async Task Run<TInstance>(Expression<Action<TInstance>> expr) => await Call(expr.Body);
        // Func<Task>
        public async Task Run<TInstance>(Expression<Func<TInstance, Task>> expr) => await Call(expr.Body);
        // Func<ValueTask>
        public async Task Run<TInstance>(Expression<Func<TInstance, ValueTask>> expr) => await Call(expr.Body);
        // Func<...,TResult>
        public async Task<TResult> Run<TInstance, TResult>(Expression<Func<TInstance, TResult>> expr) => (TResult)await Call(expr.Body);
        // Func<...,Task<TResult>>
        public async Task<TResult> Run<TInstance, TResult>(Expression<Func<TInstance, Task<TResult>>> expr) => (TResult)await Call(expr.Body);
        // Func<...,ValueTask<TResult>>
        public async Task<TResult> Run<TInstance, TResult>(Expression<Func<TInstance, ValueTask<TResult>>> expr) => (TResult)await Call(expr.Body);
        // Property set
        public async Task Set<TInstance, TProperty>(Expression<Func<TInstance, TProperty>> expr, TProperty value) => await Call(expr.Body, new object[] { value });
        #endregion

        #region Lock
        public event Action<AsyncCallDispatcher> OnUnlocked;
        public event Action<AsyncCallDispatcher> OnLocked;
        public bool IsLocked { get; private set; }
        public bool AcquireLock()
        {
            if (IsLocked) return false;
            IsLocked = true;
            //Console.WriteLine("............ AcquireLock");
            OnLocked?.Invoke(this);
            return true;
        }
        public bool ReleaseLock()
        {
            if (!IsLocked) return false;
            IsLocked = false;
            //Console.WriteLine("............ ReleaseLock");
            OnUnlocked?.Invoke(this);
            return true;
        }
        #endregion

        #region Delegates
        protected virtual Task<object?> DispatchCall(Delegate methodDelegate, object?[]? args = null)
        {
            return Call(methodDelegate.Method, args);
        }

        // Action
        public async Task Invoke(Action methodDelegate)
            => await DispatchCall(methodDelegate, null);
        public Task Invoke<T0>(Action<T0> methodDelegate, T0 arg0)
            => DispatchCall(methodDelegate, new object[] { arg0 });
        public Task Invoke<T0, T1>(Action<T0, T1> methodDelegate, T0 arg0, T1 arg1)
            => DispatchCall(methodDelegate, new object[] { arg0, arg1 });
        public Task Invoke<T0, T1, T2>(Action<T0, T1, T2> methodDelegate, T0 arg0, T1 arg1, T2 arg2)
            => DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2 });
        public Task Invoke<T0, T1, T2, T3>(Action<T0, T1, T2, T3> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            => DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3 });
        public Task Invoke<T0, T1, T2, T3, T4>(Action<T0, T1, T2, T3, T4> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public Task Invoke<T0, T1, T2, T3, T4, T5>(Action<T0, T1, T2, T3, T4, T5> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public Task Invoke<T0, T1, T2, T3, T4, T5, T6>(Action<T0, T1, T2, T3, T4, T5, T6> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public Task Invoke<T0, T1, T2, T3, T4, T5, T6, T7>(Action<T0, T1, T2, T3, T4, T5, T6, T7> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public Task Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8>(Action<T0, T1, T2, T3, T4, T5, T6, T7, T8> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public Task Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        public Task Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            => DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });

        // <TResult>
        public async Task<TResult> Invoke<TResult>(Func<TResult> methodDelegate)
            => (TResult)await DispatchCall(methodDelegate, null);
        public async Task<TResult> Invoke<T0, TResult>(Func<T0, TResult> methodDelegate, T0 arg0)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0 });
        public async Task<TResult> Invoke<T0, T1, TResult>(Func<T0, T1, TResult> methodDelegate, T0 arg0, T1 arg1)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1 });
        public async Task<TResult> Invoke<T0, T1, T2, TResult>(Func<T0, T1, T2, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, TResult>(Func<T0, T1, T2, T3, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, T4, TResult>(Func<T0, T1, T2, T3, T4, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, T4, T5, TResult>(Func<T0, T1, T2, T3, T4, T5, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, T4, T5, T6, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });

        // Task<TResult>
        public async Task<TResult> Invoke<TResult>(Func<Task<TResult>> methodDelegate)
            => (TResult)await DispatchCall(methodDelegate, null);
        public async Task<TResult> Invoke<T0, TResult>(Func<T0, Task<TResult>> methodDelegate, T0 arg0)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0 });
        public async Task<TResult> Invoke<T0, T1, TResult>(Func<T0, T1, Task<TResult>> methodDelegate, T0 arg0, T1 arg1)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1 });
        public async Task<TResult> Invoke<T0, T1, T2, TResult>(Func<T0, T1, T2, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, TResult>(Func<T0, T1, T2, T3, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, T4, TResult>(Func<T0, T1, T2, T3, T4, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, T4, T5, TResult>(Func<T0, T1, T2, T3, T4, T5, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, T4, T5, T6, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        public async Task<TResult> Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });

        // ValueTask<TResult>
        public async ValueTask<TResult> Invoke<TResult>(Func<ValueTask<TResult>> methodDelegate)
            => (TResult)await DispatchCall(methodDelegate, null);
        public async ValueTask<TResult> Invoke<T0, TResult>(Func<T0, ValueTask<TResult>> methodDelegate, T0 arg0)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0 });
        public async ValueTask<TResult> Invoke<T0, T1, TResult>(Func<T0, T1, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1 });
        public async ValueTask<TResult> Invoke<T0, T1, T2, TResult>(Func<T0, T1, T2, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2 });
        public async ValueTask<TResult> Invoke<T0, T1, T2, T3, TResult>(Func<T0, T1, T2, T3, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3 });
        public async ValueTask<TResult> Invoke<T0, T1, T2, T3, T4, TResult>(Func<T0, T1, T2, T3, T4, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public async ValueTask<TResult> Invoke<T0, T1, T2, T3, T4, T5, TResult>(Func<T0, T1, T2, T3, T4, T5, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public async ValueTask<TResult> Invoke<T0, T1, T2, T3, T4, T5, T6, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public async ValueTask<TResult> Invoke<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public async ValueTask<TResult> Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public async ValueTask<TResult> Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        public async ValueTask<TResult> Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, ValueTask<TResult>> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            => (TResult)await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });

        // Task
        public async Task Invoke(Func<Task> methodDelegate)
            => await DispatchCall(methodDelegate, null);
        public async Task Invoke<T0, TResult>(Func<T0, Task> methodDelegate, T0 arg0)
            => await DispatchCall(methodDelegate, new object[] { arg0 });
        public async Task Invoke<T0, T1, TResult>(Func<T0, T1, Task> methodDelegate, T0 arg0, T1 arg1)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1 });
        public async Task Invoke<T0, T1, T2, TResult>(Func<T0, T1, T2, Task> methodDelegate, T0 arg0, T1 arg1, T2 arg2)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2 });
        public async Task Invoke<T0, T1, T2, T3, TResult>(Func<T0, T1, T2, T3, Task> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3 });
        public async Task Invoke<T0, T1, T2, T3, T4, TResult>(Func<T0, T1, T2, T3, T4, Task> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public async Task Invoke<T0, T1, T2, T3, T4, T5, TResult>(Func<T0, T1, T2, T3, T4, T5, Task> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public async Task Invoke<T0, T1, T2, T3, T4, T5, T6, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, Task> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public async Task Invoke<T0, T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, Task> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public async Task Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, Task> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public async Task Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, Task> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        public async Task Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });

        // ValueTask
        public async ValueTask Invoke(Func<ValueTask> methodDelegate)
            => await DispatchCall(methodDelegate, null);
        public async ValueTask Invoke<T0>(Func<T0, ValueTask> methodDelegate, T0 arg0)
            => await DispatchCall(methodDelegate, new object[] { arg0 });
        public async ValueTask Invoke<T0, T1>(Func<T0, T1, ValueTask> methodDelegate, T0 arg0, T1 arg1)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1 });
        public async ValueTask Invoke<T0, T1, T2>(Func<T0, T1, T2, ValueTask> methodDelegate, T0 arg0, T1 arg1, T2 arg2)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2 });
        public async ValueTask Invoke<T0, T1, T2, T3>(Func<T0, T1, T2, T3, ValueTask> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3 });
        public async ValueTask Invoke<T0, T1, T2, T3, T4>(Func<T0, T1, T2, T3, T4, ValueTask> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public async ValueTask Invoke<T0, T1, T2, T3, T4, T5>(Func<T0, T1, T2, T3, T4, T5, ValueTask> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public async ValueTask Invoke<T0, T1, T2, T3, T4, T5, T6>(Func<T0, T1, T2, T3, T4, T5, T6, ValueTask> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public async ValueTask Invoke<T0, T1, T2, T3, T4, T5, T6, T7>(Func<T0, T1, T2, T3, T4, T5, T6, T7, ValueTask> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public async ValueTask Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, ValueTask> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public async ValueTask Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, ValueTask> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        public async ValueTask Invoke<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, ValueTask> methodDelegate, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            => await DispatchCall(methodDelegate, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });
        #endregion
    }
}
