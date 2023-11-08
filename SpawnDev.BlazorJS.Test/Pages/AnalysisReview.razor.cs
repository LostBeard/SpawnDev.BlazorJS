using Markdig;
using Markdown.ColorCode;
using Microsoft.AspNetCore.Components;
using SpawnDev.BlazorJS.Diagnostics;
using SpawnDev.BlazorJS.JSObjects;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SpawnDev.BlazorJS.Test.Pages
{
    public partial class AnalysisReview
    {
        [Inject]
        JSObjectAnalyzer JSObjectAnalyzer { get; set; }

        [Inject]
        BlazorJSRuntime JS { get; set; }

        List<Type> allJsObjectTypes = new List<Type>();

        [Parameter]
        public string? TypeName { get; set; }

        JSPropertyInfo? typeInfo { get; set; }

        string _markup = "";
        Type? JSObjectType { get; set; }

        MarkdownPipeline pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseColorCode().Build();

        bool isInit = false;
        public void Dispose()
        {
            if (isInit)
            {
                isInit = false;
                JSObjectAnalyzer.OnNewJSObjectTypeAdded -= JSObjectAnalyzer_OnNewJSObjectTypeAdded;
            }
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            typeInfo = !string.IsNullOrEmpty(TypeName) && JSObjectAnalyzer.Analyzed.TryGetValue(TypeName, out var jspi) ? jspi : null;
            JSObjectType = GetJSObjectTypeByName(TypeName);
            BuildTypeJSObjectCode();
        }

        void AppendToRegion(ref string cSharpCode, string region, string toAdd)
        {
            toAdd = "    " + toAdd.Trim() + Environment.NewLine;
            cSharpCode = Regex.Replace(cSharpCode, $@"(^[ \t]*#region {region}.+?)(^[ \t]*#endregion)", $@"$1{toAdd}$2", RegexOptions.Singleline | RegexOptions.Multiline);
        }

        void BuildTypeJSObjectCode()
        {
            if (string.IsNullOrEmpty(TypeName))
            {
                _markup = "";
                return;
            }
            var inheritsFrom = typeInfo == null || string.IsNullOrEmpty(typeInfo.InheritsFrom) || typeInfo.InheritsFrom == "Object" ? "JSObject" : typeInfo.InheritsFrom;
            var cSharpCode = $@"
public class {TypeName} : {inheritsFrom}
{{
    #region Constructors
    #endregion

    #region Properties
    #endregion

    #region Methods
    #endregion

    #region Events
    #endregion
}}
";
            if (typeInfo != null)
            {
                var constructors = $@"    public {TypeName}(IJSInProcessObjectReference _ref) : base(_ref) {{ }}";
                cSharpCode = Regex.Replace(cSharpCode, @"(^[ \t]*#region Constructors.+?)(^[ \t]*#endregion)", $@"$1{constructors}{Environment.NewLine}$2", RegexOptions.Singleline | RegexOptions.Multiline);
                var properties = new List<string>();
                var thisTypeDescriptors = typeInfo.Inheritance.First().Value;
                var withDecriptorCount = thisTypeDescriptors.Where(o => o.Value != null).Count();
                var eventNames = new List<string>();
                var inheritsEventTarget = typeInfo.Inheritance.Keys.Contains("EventTarget");
                var jsobjectProps = JSObjectType == null ? new System.Reflection.PropertyInfo[0] : JSObjectType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                var jsobjectMethods = JSObjectType == null ? new System.Reflection.MethodInfo[0] : JSObjectType.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                void Process(KeyValuePair<string, PropertyDescriptor> pkvp, bool existing)
                {
                    var propertyName = pkvp.Key;
                    if (propertyName == "constructor")
                    {
                        return;
                    }
                    var propertyNameCS = propertyName.Substring(0, 1).ToUpperInvariant() + propertyName.Substring(1);
                    var startsWithLowerCase = Regex.IsMatch(propertyName, "^[a-z]");
                    var startsWithUpperCase = Regex.IsMatch(propertyName, "^[A-Z]");
                    var eventNameMatch = propertyName != "one" && propertyName != "once" ? Regex.Match(propertyName, "^on([a-z].+)") : null;
                    var eventName = eventNameMatch != null ? eventNameMatch.Groups[1].Value : null;
                    var jsobjectProp = jsobjectProps.FirstOrDefault(o => o.Name.Equals(propertyNameCS, StringComparison.OrdinalIgnoreCase));
                    var jsobjectMethod = jsobjectMethods.FirstOrDefault(o => o.Name.Equals(propertyNameCS, StringComparison.OrdinalIgnoreCase));
                    var csExists = jsobjectProp != null || jsobjectMethod != null;

                    if (existing != csExists) return;

                    var propertyDescriptor = pkvp.Value;
                    // property names that start with a lowercase letter are likely normal properties
                    // property names that start with an uppercase letter might be a static method
                    if (propertyDescriptor == null)
                    {
                        return;
                    }
                    var pInfo = typeInfo.JSProperties.TryGetValue(propertyName, out var p) ? p : null;
                    if (pInfo == null)
                    {
                        return;
                    }
                    else
                    {

                    }
                    // skip properties that do not start with a lower case which implies instance property
                    if (!startsWithLowerCase)
                    {
                        return;
                    }

                    if (jsobjectProp != null)
                    {
                        var isJSEventCallback = typeof(EventCallbackBase).IsAssignableFrom(jsobjectProp.PropertyType);
                        if (isJSEventCallback)
                        {
                            var propertyValueType = jsobjectProp.PropertyType.GetFormattedName();
                            var propStr = $@"
    public {propertyValueType} {propertyNameCS} {{ ... }}
";
                            AppendToRegion(ref cSharpCode, "Events", propStr);
                        }
                        else
                        {
                            var propertyValueType = jsobjectProp.PropertyType.GetFormattedName();
                            if (jsobjectProp.CanWrite && jsobjectProp.CanRead)
                            {
                                var propStr = $@"
    public {propertyValueType} {propertyNameCS} 
    {{
        get => JSRef.Get<{propertyValueType}>(""{propertyName}"");
        set => JSRef.Set(""{propertyName}"", value);
    }}
";
                                AppendToRegion(ref cSharpCode, "Properties", propStr);
                            }
                            else if (jsobjectProp.CanRead)
                            {
                                var propStr = $@"
    public {propertyValueType} {propertyNameCS} => JSRef.Get<{propertyValueType}>(""{propertyName}"");
";
                                AppendToRegion(ref cSharpCode, "Properties", propStr);
                            }
                            else if (jsobjectProp.CanWrite)
                            {
                                var propStr = $@"
    public {propertyValueType} {propertyNameCS} {{ set => JSRef.Set(""{propertyName}"", value); }}
";
                                AppendToRegion(ref cSharpCode, "Properties", propStr);
                            }
                        }
                        return;
                    }
                    if (jsobjectMethod != null)
                    {
                        var paramStr = string.Join(", ", jsobjectMethod.GetParameters().Select(o => ParameterInfoToString(o)));

                        var isAsync = jsobjectMethod.ReturnType.IsAsync();
                        var propertyValueType = jsobjectMethod.ReturnType.GetFormattedName();
                        var isVoid = propertyValueType == "void";
                        var callMethod = "Call";
                        if (isVoid) callMethod += "Void";
                        if (isAsync) callMethod += "Async";
                        if (!isVoid) callMethod += $"<{propertyValueType}>";
                        var returnType = isAsync ? $"Task<{propertyValueType}>" : propertyValueType;
                        var propStr = $@"
    public {returnType} {propertyNameCS}() => ...
";
                        AppendToRegion(ref cSharpCode, "Methods", propStr);
                        return;
                    }
                    // does not exist
                    if (!string.IsNullOrEmpty(eventName))
                    {
                        var eventNameCS = "On" + eventName.Substring(0, 1).ToUpperInvariant() + eventName.Substring(1);
                        Console.WriteLine(eventName);
                        if (inheritsEventTarget)
                        {
                            var propStr = $@"
    public JSEventCallback {eventNameCS} {{ get => new JSEventCallback(o => AddEventListener(""{eventName}"", o), o => RemoveEventListener(""{eventName}"", o)); set {{ /** required **/ }} }}
";
                            AppendToRegion(ref cSharpCode, "Events", propStr);
                        }
                        else
                        {
                            var propStr = $@"
    public JSEventCallback {eventNameCS} {{ get => new JSEventCallback(o => JSRef.Set(""{propertyName}"", o), o => JSRef.Set(""{propertyName}"", null)); set {{ /** required **/ }} }}
";
                            AppendToRegion(ref cSharpCode, "Events", propStr);
                        }
                        return;
                    }
                    if (pInfo.TypeOf == "function")
                    {
                        var argsList = new List<string>();
                        var argss = Enumerable.Range(0, pInfo.FunctionLength).Select(o => $"object? arg{o}");
                        var argsstr = string.Join(", ", argss);
                        var propertyValueType = "void";
                        var propStr = $@"
    public {propertyValueType} {propertyNameCS}({argsstr}) => JSRef.CallVoid(""{propertyName}"");
";
                        AppendToRegion(ref cSharpCode, "Methods", propStr);
                    }
                    else
                    {
                        var propertyValueType = !string.IsNullOrEmpty(pInfo.InstanceOf) ? pInfo.InstanceOf : new Func<string>(() =>
                        {
                            switch (pInfo.TypeOf)
                            {
                                case "string": return "string";
                                case "number": return "float";
                                case "boolean": return "bool";
                                case "bigint": return "long";
                            }
                            return "void";
                        })();
                        if (propertyValueType == "Object") propertyValueType = "JSObject";
                        if (propertyDescriptor.CanBeWritten)
                        {
                            var propStr = $@"
    public {propertyValueType} {propertyNameCS} 
    {{
        get => JSRef.Get<{propertyValueType}>(""{propertyName}"");
        set => JSRef.Set(""{propertyName}"", value);
    }}
";
                            AppendToRegion(ref cSharpCode, "Properties", propStr);
                        }
                        else
                        {
                            var propStr = $@"
    public {propertyValueType} {propertyNameCS} => JSRef.Get<{propertyValueType}>(""{propertyName}"");
";
                            AppendToRegion(ref cSharpCode, "Properties", propStr);
                        }
                    }
                }
                AppendToRegion(ref cSharpCode, "Events", "// Existing");
                AppendToRegion(ref cSharpCode, "Methods", "// Existing");
                AppendToRegion(ref cSharpCode, "Properties", "// Existing");
                foreach (var pkvp in thisTypeDescriptors)
                {
                    Process(pkvp, true);
                }
                AppendToRegion(ref cSharpCode, "Events", "// New");
                AppendToRegion(ref cSharpCode, "Methods", "// New");
                AppendToRegion(ref cSharpCode, "Properties", "// New");
                foreach (var pkvp in thisTypeDescriptors)
                {
                    Process(pkvp, false);
                }
                var mmt = true;
            }
            //
            var markDown = $@"```cs
{cSharpCode}
```";
            _markup = Markdig.Markdown.ToHtml(markDown, pipeline);
        }
        string ParameterInfoToString(ParameterInfo o)
        {
            var ret = $"{o.ParameterType.GetFormattedName()} {o.Name}";
            if (o.HasDefaultValue)
            {
                ret += $" = {o.DefaultValue}";
            }
            return ret;
        }
        void JSObjectAnalyzer_OnNewJSObjectTypeAdded(JSPropertyInfo jspoi)
        {
            StateHasChanged();
        }

        protected override void OnInitialized()
        {

            base.OnInitialized();
        }

        bool isInitializing = false;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var isInitCall = false;
            if (!isInit)
            {
                isInitializing = true;
                StateHasChanged();
                await Task.Delay(500);
                isInit = true;
                isInitCall = true;
                JSObjectAnalyzer.OnNewJSObjectTypeAdded += JSObjectAnalyzer_OnNewJSObjectTypeAdded;
                var analyzing = false;
                JSObject.OnJSObjectCreated = (obj) =>
                {
                    try
                    {
                        if (JSObjectAnalyzer.ShouldAnalyze(obj) && !analyzing)
                        {
                            analyzing = true;
                            JSObjectAnalyzer.Analyze(obj);
                            analyzing = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        var nmt = ex.Message;
                    }
                };
                //var promise = new Promise();
                //var promiseInfo = jsobjectAnalyzer.Analyze(promise);
                //var window = JS.Get<Window>("window");
            }
            allJsObjectTypes = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var a in assemblies)
            {
                var aTypes = a.GetTypes();
                var axTypes = a.GetExportedTypes();
                var jsObjectTypes = aTypes.Where(o => typeof(JSObject).IsAssignableFrom(o));
                allJsObjectTypes.AddRange(jsObjectTypes);
            }
            await Task.Delay(500);
            if (isInitCall)
            {
                var window = JS.Get<Window>("window");
                isInitializing = false;
            }
        }
        Type? GetJSObjectTypeByName(string? instanceOf)
        {
            if (string.IsNullOrEmpty(instanceOf)) return null;
            return allJsObjectTypes.Find(o => o.Name == instanceOf);
        }
    }
}
