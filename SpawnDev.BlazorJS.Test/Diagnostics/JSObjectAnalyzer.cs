//using SpawnDev.BlazorJS.JSObjects;
//using System.Security.Cryptography;
//using System.Text;

//namespace SpawnDev.BlazorJS.Diagnostics
//{
//    public class JavascriptObjectPropertyInfo
//    {
//        public string OwnerInterface => Inheritance.LastOrDefault();
//        public List<string> Inheritance { get; set; }
//        public string Name { get; set; }
//        public PropertyDescriptor Descriptor { get; set; }
//        public string ValueTypeOf { get; set; }
//        public string ValueConstructorName { get; set; }
//    }

//    public class JavascriptObjectReflection
//    {
//        BlazorJSRuntime JS;
//        public JavascriptObjectReflection(BlazorJSRuntime js)
//        {
//            JS = js;
//        }

//        public List<string>? GetJavascriptObjectInheritance(JSObject? obj, int maxDepth = 24)
//        {
//            if (obj == null) return null;
//            var o = obj;
//            var i = 0;
//            var inheritance = new List<string>();
//            while (o != null && i < maxDepth)
//            {
//                var typeName = o.JSRef!.ConstructorName();
//                if (string.IsNullOrEmpty(typeName)) break;
//                inheritance.Add(typeName);
//                o = Reflect.GetPrototypeOf(o);
//                i += 1;
//            }
//            return null;
//        }

//        public JavascriptObjectPropertyInfo? GetJavascriptObjectProperty(JSObject? obj, string property, int maxDepth = 24)
//        {
//            if(obj == null) return null;
//            var o = obj;
//            var i = 0;
//            var inheritance = new List<string>();
//            var propTypeOf = obj.JSRef!.TypeOf(property);
//            var propInstanceOf = obj.JSRef!.ConstructorName(property);
//            while(o != null && i < maxDepth)
//            {
//                var typeName = o.JSRef.ConstructorName();
//                if (string.IsNullOrEmpty(typeName)) break;
//                inheritance.Add(typeName);
//                var descriptor = Reflect.GetOwnPropertyDescriptor(o, property);
//                if (descriptor != null)
//                {
//                    return new JavascriptObjectPropertyInfo
//                    {
//                        Descriptor = descriptor,
//                        Inheritance = inheritance.Distinct().ToList(),
//                        Name = property,
//                        ValueTypeOf = propTypeOf,
//                        ValueConstructorName = propInstanceOf,
//                    };
//                }
//                o = Reflect.GetPrototypeOf(o);
//                i += 1;
//            }
//            return null;
//        }

//        public Dictionary<string, JavascriptObjectPropertyInfo>? GetJavascriptObjectProperties(JSObject? obj)
//        {
//            if (obj == null) return null;
//            var ret = new Dictionary<string, JavascriptObjectPropertyInfo>();
//            var propertyNames = obj.JSRef!.Keys();
//            foreach(var name in propertyNames)
//            {
//                var t = GetJavascriptObjectProperty(obj, name);
//                if (t != null)
//                {
//                    ret.Add(name, t);
//                }
//            }
//            return ret;
//        }
    
        
//    }

//    public class JSObjectAnalyzer
//    {
//        BlazorJSRuntime JS;
//        public event Action<JSPropertyInfo> OnNewJSObjectTypeAdded;
//        public JSObjectAnalyzer(BlazorJSRuntime js)
//        {
//            JS = js;
//        }

//        bool ignoreUnderscoredProperties = true;

//        public JSPropertyInfo? Analyze<T>(T obj) where T : JSObject
//        {
//            if (obj == null || obj.JSRef == null) return null;
//            var ret = new JSPropertyInfo();
//            LoadObjectInf(ret, obj);
//            return ret;
//        }

//        // analyzed types keyed on JSPropertyInfo.InstanceOf
//        public Dictionary<string, JSPropertyInfo> Analyzed { get; private set; } = new Dictionary<string, JSPropertyInfo>();

//        public bool ShouldAnalyze<T>(T obj) where T : JSObject
//        {
//            var typeOf = obj == null || obj.JSRef == null ? "" : obj.JSRef.TypeOf();
//            if (string.IsNullOrEmpty(typeOf) || typeOf == "symbol") return false;
//            var instanceOf = obj == null || obj.JSRef == null ? "" : obj.JSRef.ConstructorName();
//            return !string.IsNullOrEmpty(instanceOf) && !Analyzed.ContainsKey(instanceOf);
//        }
//        public void RequestFullAnalysis<T>(T obj, JSPropertyInfo jsp) where T : JSObject
//        {
//            jsp.FullAnalysis = false;
//            var typeOf = obj == null || obj.JSRef == null ? "" : obj.JSRef.TypeOf();
//            if (string.IsNullOrEmpty(typeOf)) return;
//            var instanceOf = obj == null || obj.JSRef == null ? "" : obj.JSRef.ConstructorName();
//            if (string.IsNullOrEmpty(instanceOf)) return;
//            var ret = !Analyzed.TryGetValue(instanceOf, out var propertyInfo);
//            if (ret)
//            {
//                Analyzed.Add(instanceOf, jsp);
//                jsp.FullAnalysis = true;
//            }
//            else
//            {
//                jsp.TypeOf = propertyInfo.TypeOf;
//                jsp.FunctionLength = propertyInfo.FunctionLength;
//                //jsp.Inheritance = propertyInfo.Inheritance;
//                //jsp.JSProperties = propertyInfo.JSProperties;
//                jsp.InstanceOf = propertyInfo.InstanceOf;
//                jsp.InheritsFrom = propertyInfo.InheritsFrom;
//                jsp.FullAnalysis = false;
//            }
//        }

//        void LoadObjectInf(JSPropertyInfo ret, JSObject obj)
//        {
//            RequestFullAnalysis(obj, ret);
//            if (!ret.FullAnalysis) return;
//            ret.TypeOf = obj.JSRef.TypeOf();
//            ret.FunctionLength = ret.TypeOf == "function" ? obj.JSRef.Get<int>("length") : 0;
//            JSObject? proto = obj;
//            var allProps = new List<string>();
//            while (proto != null)
//            {
//                var protoName = proto.JSRef.ConstructorName();

//                if (string.IsNullOrEmpty(protoName))
//                {
//                    var art = true;
//                }
//                else
//                {
//                    var realKeys = new List<object>();
//                    JSObjects.Array? propKeys = null;
//                    try
//                    {
//                        propKeys = Reflect.OwnKeys(proto);
//                    }
//                    catch
//                    {

//                    }
//                    if (propKeys != null)
//                    {
//                        for (int i = 0; i < propKeys.Length; i++)
//                        {
//                            var typeofAt = propKeys.JSRef!.TypeOf(i);
//                            switch (typeofAt)
//                            {
//                                case "symbol":
//                                    {
//                                        //var key = propKeys.At<Symbol>(i);
//                                        //realKeys.Add(key);
//                                    }
//                                    break;
//                                case "string":
//                                    {
//                                        var keyStr = propKeys.At<string>(i);
//                                        realKeys.Add(keyStr);
//                                    }
//                                    break;
//                                default:
//                                    break;
//                            }
//                        }
//                    }
//                    var protoProps = realKeys.Select(o => o is string oStr && (!ignoreUnderscoredProperties || !oStr.StartsWith("_")) ? oStr : null).Where(o => !string.IsNullOrEmpty(o)).OrderBy(o => o).ToList();
//                    allProps.AddRange(protoProps);
//                    if (!ret.Inheritance.TryGetValue(protoName, out var currentProps))
//                    {
//                        currentProps = new Dictionary<string, PropertyDescriptor>();
//                        ret.Inheritance.Add(protoName, currentProps);
//                    }
//                    foreach (var protoProp in protoProps)
//                    {
//                        currentProps[protoProp] = Reflect.GetOwnPropertyDescriptor(proto, protoProp);
//                    }
//                }
//                try
//                {
//                    proto = Reflect.GetPrototypeOf(proto);
//                }
//                catch
//                {
//                    proto = null;
//                }
//            }
//            ret.InstanceOf = ret.Inheritance.Count == 0 ? null : ret.Inheritance.Keys.FirstOrDefault();
//            ret.InheritsFrom = ret.Inheritance.Count < 2 ? null : ret.Inheritance.Keys.ElementAt<string?>(1);
//            allProps = allProps.Distinct().OrderBy(o => o).ToList();
//            ret.JSProperties = allProps.Select(o => AnalyzePropertyValue(obj, o)).Where(o => o != null).ToDictionary(o => o.Name, o => o);
//            JS.Log($"New type analyzed: {ret.InstanceOf}");
//            OnNewJSObjectTypeAdded?.Invoke(ret);
//        }

//        JSPropertyInfo? AnalyzePropertyValue(JSObject parent, string propertyName)
//        {
//            if (ignoreUnderscoredProperties && propertyName.StartsWith("_")) return null;
//            var ret = new JSPropertyInfo();
//            ret.Name = propertyName;
//            try
//            {
//                //ret.Descriptor = JS.Call<PropertyDescriptor?>("Object.getOwnPropertyDescriptor", parent, propertyName);
//                ret.TypeOf = parent.JSRef!.TypeOf(propertyName);
//                var isObject = false;
//                switch (ret.TypeOf)
//                {
//                    case "undefined":
//                    case "number":
//                    case "string":
//                    case "boolean":
//                    case "bigint":
//                        //break;
//                    case "symbol":
//                    case "function":
//                    case "object":
//                    default:
//                        isObject = true;
//                        break;
//                }
//                if (isObject)
//                {
//                    JSObject? obj = null;
//                    try
//                    {
//                        obj = parent.JSRef.Get<JSObject?>(propertyName);
//                    }
//                    catch { }
//                    if (obj != null)
//                    {
//                        LoadObjectInf(ret, obj);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"error: {ex.Message}");
//            }
//            return ret;
//        }
//    }
//}
