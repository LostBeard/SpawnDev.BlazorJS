using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Static class that contains MethodInfo extension methods
    /// </summary>
    public static class MethodInfoExtension
    {
        private static Type AsyncStateMachineAttributeType = typeof(AsyncStateMachineAttribute);
        /// <summary>
        /// Returns true if the method has an async operator.<br />
        /// Checked by looking for AsyncStateMachineAttribute which indicates method has the async operator.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static bool IsAsyncMethod(this MethodInfo method) => method.GetCustomAttribute(AsyncStateMachineAttributeType) != null;

        /// <summary>
        /// Knuth hash<br />
        /// https://stackoverflow.com/a/9545731/3786270
        /// </summary>
        /// <param name="value"></param>
        /// <returns>UInt64 hash value</returns>
        static ulong CalculateHash(string? value)
        {
            if (string.IsNullOrEmpty(value)) return 0;
            ulong hashedValue = 3074457345618258791ul;
            for (int i = 0; i < value.Length; i++)
            {
                hashedValue += value[i];
                hashedValue *= 3074457345618258799ul;
            }
            return hashedValue;
        }

        /// <summary>
        /// Hash will not change if the signature does not change. (Unlike MethodInfo.GetHashCode() which can change between builds)<br />
        /// Return value is UInt64 Knuth hash of MethodInfo.ToString().<br />
        /// Result will be unique per Type but not among all Types.
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static ulong GetMethodHash(this MethodInfo _this) => CalculateHash(_this.ToString());

        /// <summary>
        /// Returns a string that represents the method in a format that matches the method's signature code as much as possible.<br />
        /// Needs work. Do not expect 100% accurate representation from this method at this time.<br />
        /// Implementation will likely change.
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="includeNames"></param>
        /// <returns></returns>
        public static string GetMethodSignature(this MethodInfo _this, bool includeNames = true)
        {
            string ret;
            var mi = _this;
            if (_this.IsGenericMethod)
            {
                mi = mi.GetGenericMethodDefinition();
            }
            var strBuilder = new StringBuilder();
            if (mi.IsPublic)
                strBuilder.Append("public ");
            else if (mi.IsPrivate)
                strBuilder.Append("private ");
            else if (mi.IsAssembly)
                strBuilder.Append("internal ");
            if (mi.IsFamily)
                strBuilder.Append("protected ");
            if (mi.IsStatic)
                strBuilder.Append("static ");
            if (includeNames)
            {
                var parameterInfos = mi.GetParameters();
                var paramStrings = new List<string>();
                foreach (var parameterInfo in parameterInfos)
                {
                    paramStrings.Add($"{parameterInfo.ParameterType.GetFormattedName()} {parameterInfo.Name}");
                }
                strBuilder.Append($"{mi.ReturnType.GetFormattedName()} {mi.Name}({string.Join(", ", paramStrings)})");
                ret = strBuilder.ToString();
            }
            else
            {
                var parameterTypes = mi.GetParameters().Select(o => o.ParameterType.GetFormattedName());
                ret = $"{strBuilder.ToString()}{mi.ReturnType.GetFormattedName()} {mi.Name}({string.Join(", ", parameterTypes)})";
            }
#if DEBUG
            Console.WriteLine($"GetMethodSignature: {ret}");
#endif
            return ret;
        }

        /// <summary>
        /// Returns a MethodInfo's Name with formatted generic arguments if any.
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public static string GetFormattedName(this MethodInfo mi)
        {
            try
            {
                if (mi.IsGenericMethod)
                {
                    var name = mi.Name;
                    var generics = mi.GetGenericArguments();
                    string genericArguments = generics.Select(x => x.GetFormattedName()).Aggregate((x1, x2) => $"{x1}, {x2}");
                    return $"{name}<{genericArguments}>";
                }
            }
            catch (Exception ex)
            {
                var nmt = true;
            }
            return mi.Name;
        }

        /// <summary>
        /// If the return type is a Task&lt;&gt; or ValueTask&lt;&gt; the Result Type is returned<br />
        /// If the return type is a Task or ValueTask typeof(void) is returned<br />
        /// otherwise MethodInfo.ReturnType is returned
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static Type GetFinalReturnType(this MethodInfo _this)
        {
            return _this.ReturnType.AsyncReturnType() ?? _this.ReturnType;
        }
    }
}
