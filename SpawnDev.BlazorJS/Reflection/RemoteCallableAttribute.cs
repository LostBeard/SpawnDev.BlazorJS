namespace SpawnDev.BlazorJS.Reflection
{
    /// <summary>
    /// Used to mark methods as callable
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class RemoteCallableAttribute : Attribute
    {
        /// <summary>
        /// Methods with the RemoteCallable attribute and NoReply = true will not send exceptions or results back to the caller<br/>
        /// That makes NoReply calls quicker
        /// </summary>
        public bool NoReply { get; set; }
        /// <summary>
        /// Gets or sets a comma delimited list of roles that are allowed to access the resource.
        /// </summary>
        public string? Roles { get; set; }
    }
}
