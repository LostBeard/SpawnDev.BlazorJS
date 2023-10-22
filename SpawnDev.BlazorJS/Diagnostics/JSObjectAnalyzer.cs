using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.Diagnostics
{
    public class JSObjectAnalyzer
    {
        BlazorJSRuntime JS;
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        public JSObjectAnalyzer(BlazorJSRuntime js)
        {
            JS = js;
        }
        public JSObjectAnalysisResult? Analyze(JSObject obj)
        {
            if (obj == null || obj.JSRef == null) return null;
            var ret = new JSObjectAnalysisResult();
            ret.JSObjectType = obj.GetType();
            ret.JSConstrutorName = obj.JSRef.GetConstructorName();
            var jsPropsNames = obj.JSRef.GetPropertyNames().Where(o => !o.StartsWith("_")).OrderBy(o => o).ToList();
            ret.JSPropNamesHash = GetHashString(JsonSerializer.Serialize(jsPropsNames));
            var members = ret.JSObjectType.GetMembers();
            var jsoProps = ret.JSObjectType.GetProperties();
            var jsoPropNames = jsoProps.Select(o => o.Name).ToList();
            var jsoMethodNames = ret.JSObjectType.GetMethods().Select(o => o.Name).ToList();
            ret.JSProperties = jsPropsNames.Select(o => AnalyzePropertyInternal(obj, o)).Where(o => o != null).ToList();

            return ret;
        }
        bool ignoreUnderscoredProperties = true;
        JSPropertyInfo? AnalyzePropertyInternal(JSObject parent, string propertyName)
        {
            if (ignoreUnderscoredProperties && propertyName.StartsWith("_")) return null;
            var ret = new JSPropertyInfo();
            try
            {
                var descriptor = JS.Call<JSObject?>("Object.getOwnPropertyDescriptor", parent, propertyName);
                //var propertyPath = string.IsNullOrEmpty(parentFullName) ? propertyName : $"{parentFullName}.{propertyName}";
                var propertyType = parent.JSRef.PropertyType(propertyName);
                var instanceOf = "";
                switch (propertyType)
                {
                    case "undefined":
                    case "number":
                    case "string":
                    case "boolean":
                    case "bigint":
                    case "symbol":
                        break;
                    case "function":
                    case "object":
                    default:
                        instanceOf = parent.JSRef.PropertyInstanceOf(propertyName);
                        break;
                }
                ret.Name = propertyName;
                //ret.FullName = propertyPath;
                ret.InstanceOf = instanceOf;
                ret.TypeOf = propertyType;
                ret.Descriptor = descriptor;
                if (!string.IsNullOrEmpty(instanceOf))
                {
                    JSObject? obj = null;
                    try
                    {
                        obj = parent.JSRef.Get<JSObject?>(propertyName);
                    }
                    catch
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
            return ret;
        }
    }
}
