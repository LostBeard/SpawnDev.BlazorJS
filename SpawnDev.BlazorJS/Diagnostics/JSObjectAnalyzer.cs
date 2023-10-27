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
        public event Action<JSPropertyInfo> OnNewJSObjectTypeAdded;
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

        bool ignoreUnderscoredProperties = true;

        public JSPropertyInfo? Analyze<T>(T obj) where T : JSObject
        {
            if (obj == null || obj.JSRef == null) return null;
            var ret = new JSPropertyInfo();
            LoadObjectInf(ret, obj);
            return ret;
        }

        // analyzed types keyed on JSPropertyInfo.InstanceOf
        public Dictionary<string, JSPropertyInfo> Analyzed { get; private set; } = new Dictionary<string, JSPropertyInfo>();

        public bool ShouldAnalyze<T>(T obj) where T : JSObject
        {
            var typeOf = obj == null || obj.JSRef == null ? "" : JS.TypeOf(obj);
            if (string.IsNullOrEmpty(typeOf) || typeOf == "symbol") return false;
            var instanceOf = obj == null || obj.JSRef == null ? "" : obj.JSRef.GetConstructorName();
            return !string.IsNullOrEmpty(instanceOf) && !Analyzed.ContainsKey(instanceOf);
        }
        public void RequestFullAnalysis<T>(T obj, JSPropertyInfo jsp) where T : JSObject
        {
            jsp.FullAnalysis = false;
            var typeOf = obj == null || obj.JSRef == null ? "" : JS.TypeOf(obj);
            if (string.IsNullOrEmpty(typeOf) || typeOf == "symbol") return;
            var instanceOf = obj == null || obj.JSRef == null ? "" : obj.JSRef.GetConstructorName();
            if (string.IsNullOrEmpty(instanceOf)) return;
            var ret = !Analyzed.TryGetValue(instanceOf, out var propertyInfo);
            if (ret)
            {
                Analyzed.Add(instanceOf, jsp);
                jsp.FullAnalysis = true;
            }
            else
            {
                jsp.TypeOf = propertyInfo.TypeOf;
                jsp.FunctionLength = propertyInfo.FunctionLength;
                //jsp.Inheritance = propertyInfo.Inheritance;
                //jsp.JSProperties = propertyInfo.JSProperties;
                jsp.InstanceOf = propertyInfo.InstanceOf;
                jsp.InheritsFrom = propertyInfo.InheritsFrom;
                jsp.FullAnalysis = false;
            }
        }

        void LoadObjectInf(JSPropertyInfo ret, JSObject obj)
        {
            RequestFullAnalysis(obj, ret);
            if (!ret.FullAnalysis) return;
            ret.TypeOf = JS.TypeOf(obj);
            ret.FunctionLength = ret.TypeOf == "function" ? obj.JSRef.Get<int>("length") : 0;
            JSObject? proto = obj;
            var allProps = new List<string>();
            while (proto != null)
            {
                var protoName = proto.JSRef.GetConstructorName();

                if (string.IsNullOrEmpty(protoName))
                {
                    var art = true;
                }
                else
                {
                    var realKeys = new List<object>();
                    var propKeys = Reflect.OwnKeys(proto);
                    for (int i = 0; i < propKeys.Length; i++)
                    {
                        var typeofAt = JS.TypeOf(propKeys, i);
                        switch (typeofAt)
                        {
                            case "symbol":
                                {
                                    //var key = propKeys.At<Symbol>(i);
                                    //realKeys.Add(key);
                                }
                                break;
                            case "string":
                                {
                                    var keyStr = propKeys.At<string>(i);
                                    realKeys.Add(keyStr);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    var protoProps = realKeys.Select(o => o is string oStr && (!ignoreUnderscoredProperties || !oStr.StartsWith("_")) ? oStr : null).Where(o => !string.IsNullOrEmpty(o)).OrderBy(o => o).ToList();
                    allProps.AddRange(protoProps);
                    if (!ret.Inheritance.TryGetValue(protoName, out var currentProps))
                    {
                        currentProps = new Dictionary<string, PropertyDescriptor>();
                        ret.Inheritance.Add(protoName, currentProps);
                    }
                    foreach (var protoProp in protoProps)
                    {
                        currentProps[protoProp] = Reflect.GetOwnPropertyDescriptor(proto, protoProp);
                    }

                }
                try
                {
                    proto = Reflect.GetPrototypeOf(proto);
                }
                catch
                {
                    proto = null;
                }
            }
            ret.InstanceOf = ret.Inheritance.Count == 0 ? null : ret.Inheritance.Keys.FirstOrDefault();
            ret.InheritsFrom = ret.Inheritance.Count < 2 ? null : ret.Inheritance.Keys.ElementAt<string?>(1);
            allProps = allProps.Distinct().OrderBy(o => o).ToList();
            ret.JSProperties = allProps.Select(o => AnalyzePropertyValue(obj, o)).Where(o => o != null).ToDictionary(o => o.Name, o => o);
            JS.Log($"New type analyzed: {ret.InstanceOf}");
            OnNewJSObjectTypeAdded?.Invoke(ret);
        }

        JSPropertyInfo? AnalyzePropertyValue(JSObject parent, string propertyName)
        {
            if (ignoreUnderscoredProperties && propertyName.StartsWith("_")) return null;
            var ret = new JSPropertyInfo();
            ret.Name = propertyName;
            try
            {
                //ret.Descriptor = JS.Call<PropertyDescriptor?>("Object.getOwnPropertyDescriptor", parent, propertyName);
                ret.TypeOf = parent.JSRef.PropertyType(propertyName);
                var isObject = false;
                switch (ret.TypeOf)
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
                        isObject = true;
                        break;
                }
                if (isObject)
                {
                    JSObject? obj = null;
                    try
                    {
                        obj = parent.JSRef.Get<JSObject?>(propertyName);
                    }
                    catch { }
                    if (obj != null)
                    {
                        LoadObjectInf(ret, obj);
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
