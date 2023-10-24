using SpawnDev.BlazorJS.JSObjects;
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
        public JSObjectAnalysisResult? Analyze<T>(T obj) where T : JSObject
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

            JSObject? proto = obj;
            var protoLast = "";
            while (proto != null)
            {
                var protoName = proto.JSRef.GetConstructorName();
                if (!string.IsNullOrEmpty(protoName))
                {
                    var protoProps = proto.JSRef.GetPropertyNames();
                    if (!ret.Inheritance.TryGetValue(protoName, out var currentProps))
                    {
                        ret.Inheritance.Add(protoName, protoProps);
                    }
                    else
                    {
                        currentProps.AddRange(protoProps);
                    }
                }
                proto = Reflect.GetPrototypeOf(proto);
            }
            var inheritance = ret.JSConstrutorName;
            var protoTypes = ret.Inheritance.Keys;
            if (ret.Inheritance.Count > 1)
            {
                inheritance = $"{protoTypes.First()} : {(string.Join(", ", protoTypes.Skip(1).ToArray()))}";
            }
            else if (ret.Inheritance.Count == 1)
            {
                inheritance = $"{protoTypes.First()}";
            }
            Console.WriteLine($"Inheritance: {inheritance}");
            return ret;
        }
        bool ignoreUnderscoredProperties = true;
        JSPropertyInfo? AnalyzePropertyInternal(JSObject parent, string propertyName)
        {
            if (ignoreUnderscoredProperties && propertyName.StartsWith("_")) return null;
            var ret = new JSPropertyInfo();
            try
            {
                var descriptor = JS.Call<PropertyDescriptor?>("Object.getOwnPropertyDescriptor", parent, propertyName);
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
