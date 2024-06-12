using System.Linq.Expressions;
using System.Reflection;

namespace SpawnDev.BlazorJS.Reflection
{
    /// <summary>
    /// AsyncCallDispatcherSlim converts a call into a MethodInfo and an object[] containing the arguments used for the call and asynchronously returns the value<br/>
    /// The call is handled by an abstract method that must be implemented by the inheriting class.<br/>
    /// Usually this is done to allow serializing a call to be carried out elsewhere with the result being returned asynchronously.<br/>
    /// Task&lt;object?&gt; DispatchCallAsync(MethodInfo methodInfo, object?[]? args = null)<br/>
    /// Supported calling features*:<br/>
    /// Expressions - Supports asynchronous/synchronous public/private instance/static methods with generics, and property get and set. (Recommended)<br/>
    /// - Run, Set<br/>
    /// Interface proxy - Supports asynchronous public instance methods with generics. (uses DispatchProxy)<br/>
    /// - GetService<br/>
    /// *Calling feature support dependent on call serialization and deserialization mechanisms used by the inheriting class
    /// </summary>
    public abstract class AsyncCallDispatcherSlim
    {
        /// <summary>
        /// All calls are handled by this method
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected abstract Task<object?> DispatchCallAsync(MethodInfo methodInfo, object?[]? args);
        #region Expressions
        /// <summary>
        /// Converts an Expression into a MethodInfo and a call arguments array<br/>
        /// Then calls DispatchCall with them
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="argsExt"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected Task<object?> CallExpression(Expression expr, object?[]? argsExt = null)
        {
            if (expr is MethodCallExpression methodCallExpression)
            {
                // method call
                var methodInfo = methodCallExpression.Method;
                var args = methodCallExpression.Arguments.Select(arg => Expression.Lambda<Func<object>>(Expression.Convert(arg, typeof(object)), null).Compile()()).ToArray();
                return DispatchCallAsync(methodInfo, args);
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
                    return DispatchCallAsync(methodInfo, null);
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
                    return DispatchCallAsync(methodInfo, argsExt);
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
        /// <summary>
        /// Asynchronously call a method
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public async Task Run(Expression<Action> expr) => await CallExpression(expr.Body);
        // Func<Task>
        /// <summary>
        /// Asynchronously call a method
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public async Task Run(Expression<Func<Task>> expr) => await CallExpression(expr.Body);
        // Func<ValueTask>
        /// <summary>
        /// Asynchronously call a method
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public async Task Run(Expression<Func<ValueTask>> expr) => await CallExpression(expr.Body);
        // Func<...,TResult>
        /// <summary>
        /// Asynchronously call a method
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public async Task<TResult> Run<TResult>(Expression<Func<TResult>> expr) => (TResult)await CallExpression(expr.Body);
        // Func<...,Task<TResult>>
        /// <summary>
        /// Asynchronously call a method
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public async Task<TResult> Run<TResult>(Expression<Func<Task<TResult>>> expr) => (TResult)await CallExpression(expr.Body);
        // Func<...,ValueTask<TResult>>
        /// <summary>
        /// Asynchronously call a method
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public async Task<TResult> Run<TResult>(Expression<Func<ValueTask<TResult>>> expr) => (TResult)await CallExpression(expr.Body);
        // Property set
        /// <summary>
        /// Set property value<br/>
        /// Ex<br/>
        /// await caller.Set&let;AsyncCallDispatcherTest, string>(s => s.IITestProp1, "Yay!");
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task Set<TProperty>(Expression<Func<TProperty>> expr, TProperty value) => await CallExpression(expr.Body, new object[] { value });
        // Instance
        // Method Calls and Property Getters
        // Action
        /// <summary>
        /// Asynchronously call a method
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public async Task Run<TInstance>(Expression<Action<TInstance>> expr) => await CallExpression(expr.Body);
        // Func<Task>
        /// <summary>
        /// Asynchronously call a method
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public async Task Run<TInstance>(Expression<Func<TInstance, Task>> expr) => await CallExpression(expr.Body);
        // Func<ValueTask>
        /// <summary>
        /// Asynchronously call a method
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public async Task Run<TInstance>(Expression<Func<TInstance, ValueTask>> expr) => await CallExpression(expr.Body);
        // Func<...,TResult>
        /// <summary>
        /// Asynchronously call a method
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public async Task<TResult> Run<TInstance, TResult>(Expression<Func<TInstance, TResult>> expr) => (TResult)await CallExpression(expr.Body);
        // Func<...,Task<TResult>>
        /// <summary>
        /// Asynchronously call a method
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public async Task<TResult> Run<TInstance, TResult>(Expression<Func<TInstance, Task<TResult>>> expr) => (TResult)await CallExpression(expr.Body);
        // Func<...,ValueTask<TResult>>
        /// <summary>
        /// Asynchronously call a method
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public async Task<TResult> Run<TInstance, TResult>(Expression<Func<TInstance, ValueTask<TResult>>> expr) => (TResult)await CallExpression(expr.Body);
        // Property set
        /// <summary>
        /// Set property value<br/>
        /// Ex<br/>
        /// await caller.Set&let;AsyncCallDispatcherTest, string&gt;(s =&gt; s.IITestProp1, "Yay!");
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task Set<TInstance, TProperty>(Expression<Func<TInstance, TProperty>> expr, TProperty value) => await CallExpression(expr.Body, new object[] { value });
        #endregion
    }
}
