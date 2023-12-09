using System.Linq.Expressions;
using System.Reflection;

namespace SpawnDev.BlazorJS.Reflection
{
    public partial class CallDispatcher : ICallDispatcher
    {
        /// <summary>
        /// A debug version of DispatchCall that should be overridden
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual Task<object?> DispatchCall(MethodInfo methodInfo, object?[]? args = null)
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


        #region Expressions

        /// <summary>
        /// Converts an Expression into a MethodInfo and a call arguments array<br />
        /// Then calls DispatchCall with them
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="argsExt"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected Task<object?> DispatchCall(Expression expr, object?[]? argsExt = null)
        {
            if (expr is MethodCallExpression methodCallExpression)
            {
                var methodInfo = methodCallExpression.Method;
                var args = methodCallExpression.Arguments.Select(arg => Expression.Lambda<Func<object>>(Expression.Convert(arg, typeof(object)), null).Compile()()).ToArray();
                return DispatchCall(methodInfo, args);
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
                    return DispatchCall(methodInfo);
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
                    return DispatchCall(methodInfo, argsExt);
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
        public async Task Run(Expression<Action> expr) => await DispatchCall(expr.Body);
        // Func<Task>
        public async Task Run(Expression<Func<Task>> expr) => await DispatchCall(expr.Body);
        // Func<ValueTask>
        public async Task Run(Expression<Func<ValueTask>> expr) => await DispatchCall(expr.Body);
        // Func<...,TResult>
        public async Task<TResult> Run<TResult>(Expression<Func<TResult>> expr) => (TResult)await DispatchCall(expr.Body);
        // Func<...,Task<TResult>>
        public async Task<TResult> Run<TResult>(Expression<Func<Task<TResult>>> expr) => (TResult)await DispatchCall(expr.Body);
        // Func<...,ValueTask<TResult>>
        public async Task<TResult> Run<TResult>(Expression<Func<ValueTask<TResult>>> expr) => (TResult)await DispatchCall(expr.Body);
        // Property set
        public async Task Set<TProperty>(Expression<Func<TProperty>> expr, TProperty value) => await DispatchCall(expr.Body, new object[] { value });

        // Instance
        // Method Calls and Property Getters
        // Action
        public async Task Run<TInstance>(Expression<Action<TInstance>> expr) => await DispatchCall(expr.Body);
        // Func<Task>
        public async Task Run<TInstance>(Expression<Func<TInstance, Task>> expr) => await DispatchCall(expr.Body);
        // Func<ValueTask>
        public async Task Run<TInstance>(Expression<Func<TInstance, ValueTask>> expr) => await DispatchCall(expr.Body);
        // Func<...,TResult>
        public async Task<TResult> Run<TInstance, TResult>(Expression<Func<TInstance, TResult>> expr) => (TResult)await DispatchCall(expr.Body);
        // Func<...,Task<TResult>>
        public async Task<TResult> Run<TInstance, TResult>(Expression<Func<TInstance, Task<TResult>>> expr) => (TResult)await DispatchCall(expr.Body);
        // Func<...,ValueTask<TResult>>
        public async Task<TResult> Run<TInstance, TResult>(Expression<Func<TInstance, ValueTask<TResult>>> expr) => (TResult)await DispatchCall(expr.Body);
        // Property set
        public async Task Set<TInstance, TProperty>(Expression<Func<TInstance, TProperty>> expr, TProperty value) => await DispatchCall(expr.Body, new object[] { value });
        #endregion

        #region Lock
        public event Action<CallDispatcher> OnUnlocked;
        public event Action<CallDispatcher> OnLocked;
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
            return DispatchCall(methodDelegate.Method, args);
        }

        //protected virtual MethodInfo GetMethodInfo(Delegate methodDelegate)
        //{
        //    return methodDelegate.Method;
        //}

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
